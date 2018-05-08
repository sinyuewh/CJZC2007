using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web;
using System.Data.SqlClient;

namespace JSJ.CJZC.Business
{
    public enum SP
    {
        ��ʼ���� = 4, �������� = 11,
        ��Ҫ�ұ�� = 12, ���ίԱ������ = 13,
        ���ίԱ��ͬ�� = 14, ����ίԱ������ = 15,
        ����ίԱ��ͬ�� = 16, ����Ա���� = 17
    };

    /// <summary>
    /// �û�ҵ������
    /// </summary>
    public class U_ZCSPBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_ZCSP";
        private CommTable tabCommand = null;
        string CurrentUser = null;
        #endregion

        #region ���캯��
        public U_ZCSPBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public U_ZCSPBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�

        /// <summary>
        /// �õ���Ϊ���ʲ������б�
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public DataSet GetHistoryZcSp(string zcid)
        {
            string st1=(int)SP.���ίԱ��ͬ��+"";
            string st2=(int)SP.����ίԱ��ͬ��+"";
            string sql = "select * from u_zc2 where zcid=" + zcid + " and (status='"+st1+"' or status='"+st2+"') order by id desc";
            return this.tabCommand.TableComm.SearchData(sql);
        }

        /// <summary>
        /// ����������ִ�С��Ͳ�������������
        /// </summary>
        /// <param name="czid">�ʲ�����ID</param>
        /// <returns></returns>
        public string PiYueZcForDepart(string czid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string err1 = null;
                bool flag = this.GetNoEndSPByCZID(czid);
                if (flag == false)
                {
                    err1 = "������ʾ������δ��������Ļ��ڣ����ܽ����µ��������̣�";
                }
                else
                {
                    string leader=null;
                    String zeren = this.GetZeren(czid);
                    if (String.IsNullOrEmpty(zeren) == false)
                    {
                        U_UserNameBU user1 = new U_UserNameBU();
                        leader = user1.GetDirLeader(zeren);
                        user1.Close();
                    }
                    if (leader == null || leader.Trim() == "")
                    {
                        err1 = "������Ϣ�������ڵĲ���û�ж��岿�����ܣ��޷����ģ�";
                    }
                    else
                    {
                        err1 = this.SendSPPerson(leader, czid, SP.��������);
                    }
                }
                this.tabCommand.TableConnect.CommitTrans();
                return err1;
            }
            catch(Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
        }


        /// <summary>
        /// �õ�ĳ�ʲ�����CZID��������
        /// </summary>
        /// <param name="czid"></param>
        /// <returns></returns>
        private String GetZeren(String czid)
        {
            String userid = null;
            CommTable com1 = new CommTable();
            com1.TabName = "U_ZC2";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", czid, SearchFieldType.��ֵ��));
            DataSet ds1 = com1.SearchData("zeren", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds1.Tables[0].Rows[0];
                userid = dr["zeren"].ToString();
            }
            com1.Close();
            return userid;
        }

        //���ܣ�����������Ϣ
        public void SetPC(ListControl drop1, string czid)
        {
            string sql = "select pscount from U_ZCSP where czid=" + czid + "group by pscount";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = ds1.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    ListItem list0 = new ListItem(ds1.Tables[0].Rows[i][0].ToString(), ds1.Tables[0].Rows[i][0].ToString());
                    drop1.Items.Add(list0);
                }
            }
            ListItem list = new ListItem("ȫ��", "");
            drop1.Items.Add(list);
        }


        #region �ʲ�����
        /// <summary>
        /// ���������ʲ�
        /// </summary>
        /// <param name="spid">�ʲ�ID</param>
        /// <param name="ht">��������</param>
        /// <returns></returns>
        public string PiYueZcForOffice(string spid, Hashtable ht,out String czid)
        {
            czid = "";
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zeren = role1.GetRoleAllUsers("�ʲ�����Ա");
                role1.Close();

                if (zeren.Trim() != "��")
                {
                    czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "ͬ��")
                    {
                        string temp = this.SendSPPerson((zeren.Split(','))[0], czid, SP.����Ա����);
                        if (temp == null)
                        {
                            info1 = "��ʾ�������ʲ���ɣ���ת����Ա������";
                        }
                        else
                        {
                            info1 = "��ʾ������ʧ�ܣ��������ύ������";
                        }
                    }
                    else
                    {
                        info1 = " ��ʾ�������ʲ���ɣ����˻������ˣ�";
                    }
                }
                else
                {
                    info1 = "��ʾ�������ʲ�ʧ�ܣ�û�ж��塾����Ա������ѡ��";
                }
                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
        }


        /// <summary>
        /// ����Ա�����ʲ�
        /// </summary>
        /// <param name="spid">�ʲ�ID</param>
        /// <param name="ht">��������</param>
        /// <returns></returns>
        public string PiYueZcForPingShenYuan(string spid, Hashtable ht, out String czid)
        {
            /*
            czid = "";
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zeren = role1.GetRoleAllUsers("��Ҫ�ҵǼ���Ա");
                role1.Close();

                if (zeren.Trim() != "��")
                {
                    czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "ͬ��")
                    {
                        string temp = this.SendSPPerson((zeren.Split(','))[0], czid, SP.��Ҫ�ұ��);
                        if (temp == null)
                        {
                            info1 = "��ʾ�������ʲ���ɣ���ת�칫�ұ�Ŵ���";
                        }
                        else
                        {
                            info1 = "��ʾ������ʧ�ܣ��������ύ������";
                        }
                    }
                    else
                    {
                        info1 = " ��ʾ�������ʲ���ɣ����˻������ˣ�";
                    }
                }
                else
                {
                    info1 = "��ʾ�������ʲ�ʧ�ܣ�û�ж��塾��Ҫ�ҵǼ���Ա������ѡ��";
                }
                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }*/

            czid = ht["czid"].ToString();
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //�޸��ʲ��������еġ���Ŀ�걨�š�
                string xmsbh = ht["xmsbh"].ToString();    //��Ŀ�걨�ţ�
                string czid1 = ht["czid"].ToString();   //�ʲ�����Id
                this.tabCommand.TabName = "U_Zc2";
                List<SearchField> list0 = new List<SearchField>();
                list0.Add(new SearchField("id", czid1, SearchFieldType.��ֵ��));
                Hashtable ht0 = new Hashtable();
                ht0["xmsbh"] = xmsbh;
                this.tabCommand.EditQuickData(list0, ht0);
                this.tabCommand.TabName = TabName;

                ht.Remove("xmsbh");
                ht.Remove("czid");
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string sname1 = role1.GetRoleAllUsers("�ʲ����ίԱ��");
                string sname2 = role1.GetRoleAllUsers("���ίԱ����ϯ");
                role1.Close();

                if (sname1.Trim() == "��" || sname2.Trim() == "��")
                {
                    info1 = "��ʾ�������ʲ�ʧ�ܣ�û�ж��塾�ʲ����ίԱ�᡿�͡����ίԱ����ϯ������ѡ��";
                }
                else
                {
                    string zeren = sname1 + "," + sname2;
                    czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "ͬ��")
                    {
                        string temp = this.SendSPPerson(zeren, czid, SP.���ίԱ������);
                        if (temp == null)
                        {
                            info1 = "��ʾ�������ʲ���ɣ���ת���ίԱ��������";
                        }
                        else
                        {
                            info1 = "��ʾ������ʧ�ܣ��������ύ������";
                        }
                    }
                    else
                    {
                        info1 = " ��ʾ�������ʲ���ɣ����˻������ˣ�";
                    }

                }

                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
        }

        /// <summary>
        /// �����ʲ����칫������ִ�����ģ�
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public string PiYueZcForSHWeiYuan(string spid, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //�޸��ʲ��������еġ���Ŀ�걨�š�
                string xmsbh=ht["xmsbh"].ToString();    //��Ŀ�걨�ţ�
                string czid1 = ht["czid"].ToString();   //�ʲ�����Id
                this.tabCommand.TabName = "U_Zc2";
                List<SearchField> list0 = new List<SearchField>();
                list0.Add(new SearchField("id", czid1, SearchFieldType.��ֵ��));
                Hashtable ht0=new Hashtable();
                ht0["xmsbh"]=xmsbh;
                this.tabCommand.EditQuickData(list0, ht0);
                this.tabCommand.TabName = TabName;

                ht.Remove("xmsbh");
                ht.Remove("czid");
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string sname1 = role1.GetRoleAllUsers("�ʲ����ίԱ��");
                string sname2 = role1.GetRoleAllUsers("���ίԱ����ϯ");
                role1.Close();

                if (sname1.Trim() == "��" || sname2.Trim() == "��")
                {
                    info1 = "��ʾ�������ʲ�ʧ�ܣ�û�ж��塾�ʲ����ίԱ�᡿�͡����ίԱ����ϯ������ѡ��";
                }
                else
                {
                    string zeren = sname1 + "," + sname2;
                    string czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "ͬ��")
                    {
                        string temp = this.SendSPPerson(zeren, czid, SP.���ίԱ������);
                        if (temp == null)
                        {
                            info1 = "��ʾ�������ʲ���ɣ���ת���ίԱ��������";
                        }
                        else
                        {
                            info1 = "��ʾ������ʧ�ܣ��������ύ������";
                        }
                    }
                    else
                    {
                        info1 = " ��ʾ�������ʲ���ɣ����˻������ˣ�";
                    }
                    
                }

                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch(Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
        }

        /// <summary>
        /// �����ίԱ������ίԱ����ϯִ�����ģ�
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public string PiYueZcForSH1(string spid, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string sname1 = role1.GetRoleAllUsers("��˾����ίԱ��");
                string sname2 = role1.GetRoleAllUsers("����ίԱ����ϯ");

                string zx1 = role1.GetRoleAllUsers("���ίԱ����ϯ");
                role1.Close();

                if (sname1.Trim() == "��" || sname2.Trim() == "��")
                {
                    info1 = "��ʾ�������ʲ�ʧ�ܣ�û�ж��塾��˾����ίԱ�᡿�͡�����ίԱ����ϯ������ѡ��";
                }
                else
                {
                    string zeren = sname1 + "," + sname2;
                    string czid = this.PiYue(spid, ht);

                    if (ht["zeren"].ToString() == zx1)
                    {
                        if (ht["ps"].ToString() == "�;���ίԱ��")
                        {
                            string temp = this.SendSPPerson(zeren, czid, SP.����ίԱ������);
                            if (temp == null)
                            {
                                info1 = "��ʾ�������ʲ���ɣ���ת����ίԱ��������";
                            }
                            else
                            {
                                info1 = "��ʾ������ʧ�ܣ��������ύ������";
                            }
                        }
                        else if (ht["ps"].ToString() == "ͬ��")
                        {
                            //�����ʲ���״̬Ϊ1

                            info1 = " ��ʾ�������ʲ�����ɣ�";
                        }
                        else
                        {
                            info1 = " ��ʾ�������ʲ���ɣ����˻������ˣ�";
                        }
                    }
                    else
                    {
                        info1 = "��ʾ�������ʲ���ɣ��ȴ������ίԱ����ϯ���þ���";
                    }
                }

                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
        }
        #endregion

        

        //�����ʲ�������ίԱ��;���ίԱ����ϯִ�����ģ�
        public string PiYueZcForSH2(string spid, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zx1 = role1.GetRoleAllUsers("����ίԱ����ϯ");
                role1.Close();
  
                string czid = this.PiYue(spid, ht);
                if (ht["zeren"].ToString() == zx1)
                {
                    if (ht["ps"].ToString() == "ͬ��")
                    {
                        info1 = " ��ʾ�������ʲ�����ɣ�";
                    }
                    else
                    {
                        info1 = " ��ʾ�������ʲ���ɣ����˻������ˣ�";
                    }
                }
                else
                {
                    info1 = "��ʾ�������ʲ���ɣ��ȴ�������ίԱ����ϯ���þ���";
                }
                
                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
        }

        //�õ������˵��������
        public string GetManyYJ(string czid, string kind)
        {
            string yj = "";
            string sql = "select Ps from " + TabName + " where czid=" + czid + " and kind='" + kind + "' group by PS order by count(*) desc ";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                yj = ds1.Tables[0].Rows[0][0].ToString();
            }
            ds1.Dispose();
            return yj;
        }

        public bool GetNoEndSP(string zcid)
        {
            bool result = true;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField(" time1", "null", SearchOperator.��ֵ));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = false;
            }
            return result;
        }

        public bool GetNoEndSPByCZID(string czid)
        {
            bool result = true;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField(" time1", "null", SearchOperator.��ֵ));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = false;
            }
            return result;
        }


        /// <summary>
        /// �õ���ǰû��������ɵ���������
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public int GetNoEndSPCount(string zcid)
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField(" time1", "null", SearchOperator.��ֵ));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows.Count;
            }
            return result;
        }

        /// <summary>
        /// �õ���ǰû��������ɵ���������
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public int GetNoEndBSPCount(string zcid)
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            this.tabCommand.TabName = "U_ZCBSP";
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField(" time1", "null", SearchOperator.��ֵ));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows.Count;
            }
            this.tabCommand.TabName = TabName;
            return result;
        }

        //ɾ������
        public void DelSp(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.DeleteData(list1);
        }


        //�õ��ʲ������б�
        public DataSet GetZcSPList(string czid, string kind)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("kind", kind));
            list1.Add(new SearchField("pscount", "0", SearchOperator.����));

            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = i + 1;
            }
            //Util.Print(ds1.Tables[0].Rows.Count.ToString()+"czid="+czid+"kind="+kind);

            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //�õ��ʲ������б�
        public DataSet GetZcBSPList(string czid, string kind)
        {
            this.tabCommand.TabName = "ZCSP1View";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("kind", kind));
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = i + 1;
            }
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        //�õ��ʲ������б�
        public DataSet GetZcSPListByPC(string czid, string PC)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.��ֵ��));
            if (PC != "")
            {
                list1.Add(new SearchField("pscount", PC));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = i + 1;
            }
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //�жϻ�Ա�Ƿ�����
        public bool GetSPInfo(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("time1", "null", SearchOperator.��ֵ));
            list1.Add(new SearchField("zx", "null", SearchOperator.��ֵ));
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //�õ��������1
        public DataSet GetZcSPRemark(string czid, SP sp1)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("kind", (int)sp1 + ""));
            DataSet ds1 = this.tabCommand.SearchData("id,remark,time1,time0,zeren,ps", list1, "id desc");
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //�õ��������2
        public DataSet GetZcSPRemark1(string zcid, SP sp1)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("kind", (int)sp1 + ""));
            DataSet ds1 = this.tabCommand.SearchData("id,remark,time1,time0", list1, "id");
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        #endregion

        #region ˽�з���

        /// <summary>
        /// ���ķ���1�������ʲ�������ʱ��������������
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        private string PiYue(string spid, Hashtable ht)
        {
            string czid = "";
            List<SearchField> list1 = new List<SearchField>();

            //�޸����������е������Ϣ
            list1.Add(new SearchField("id", spid, SearchFieldType.��ֵ��));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            czid = ds1.Tables[0].Rows[0]["czid"].ToString();    //�õ��ʲ��������е�ID����
            String zeren1 = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DictionaryEntry item in ht)
                {
                    if (item.Key.ToString().ToLower() != "zeren")
                    {
                        if (ds1.Tables[0].Columns.Contains(item.Key.ToString().ToLower()))
                        {
                            ds1.Tables[0].Rows[0][item.Key.ToString()] = item.Value;
                        }
                    }
                    else
                    {
                        zeren1 = ds1.Tables[0].Rows[0]["zeren"].ToString();
                    }
                }
                ht["zeren"] = zeren1;
                this.tabCommand.Update(ds1);
            }


            //�޸��ʲ�����ص�����
            if(ds1.Tables[0].Rows.Count>0)
            {
                //����״̬
                String status = ds1.Tables[0].Rows[0]["kind"].ToString();
                
                //������־
                int flag = 0;
                if (ds1.Tables[0].Rows[0]["ps"].ToString().Trim() == "ͬ��")
                {
                    flag = 0;
                }
                else if (ds1.Tables[0].Rows[0]["ps"].ToString().Trim() == "��ͬ��")
                {
                    flag = 1;
                }
                else
                {
                    flag = 2;
                }

                //������ϯ��־
                bool ZhuXi = false;
                if (ds1.Tables[0].Rows[0]["zx"].ToString().Trim() == "1")
                {
                    ZhuXi = true;
                }

                String spstatus = "0";
                if (ZhuXi && ds1.Tables[0].Rows[0]["ps"].ToString().Trim() == "ͬ��")
                {
                    if (ds1.Tables[0].Rows[0]["kind"].ToString().Trim() == "13")
                    {
                        spstatus = "1";
                    }

                    if (ds1.Tables[0].Rows[0]["kind"].ToString().Trim() == "15")
                    {
                        spstatus = "2";
                    }
                }

                String newStatus = this.GetShenPiStatus(status, flag, ZhuXi);
                if (newStatus != null)
                {
                    //�����ʲ���״̬ (2010�������
                    list1.Clear();
                    string zcid = ds1.Tables[0].Rows[0]["zcID"].ToString();
                    if (String.IsNullOrEmpty(zcid) == false)
                    {
                        this.tabCommand.TabName = "U_ZC";
                        list1.Add(new SearchField("id", zcid, SearchFieldType.��ֵ��));
                        DataSet ds2 = this.tabCommand.SearchData("id,status", list1);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {

                            ds2.Tables[0].Rows[0]["status"] = newStatus;

                            this.tabCommand.Update(ds2);
                        }
                    }

                    //�����ʲ�����״̬ (2010��������
                    string zcbid = ds1.Tables[0].Rows[0]["zcbID"].ToString();
                    if (String.IsNullOrEmpty(zcbid) == false)
                    {
                        this.tabCommand.TabName = "U_ZCBao";
                        list1.Add(new SearchField("id", zcbid, SearchFieldType.��ֵ��));
                        DataSet ds2 = this.tabCommand.SearchData("id,bstatus", list1);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {

                            ds2.Tables[0].Rows[0]["bstatus"] = newStatus;

                            this.tabCommand.Update(ds2);
                        }
                    }


                    //�޸��ʲ�������״̬
                    list1.Clear();
                    if (String.IsNullOrEmpty(zcid)==false || String.IsNullOrEmpty(zcbid)==false )
                    {
                        this.tabCommand.TabName = "U_ZC2";
                        list1.Add(new SearchField("id", czid, SearchFieldType.��ֵ��));
                        Hashtable ht0 = new Hashtable();
                        ht0["status"] = newStatus;
                        if (spstatus != "0")
                        {
                            ht0["spstatus"] = spstatus;
                        }
                        this.tabCommand.EditQuickData(list1, ht0);
                        
                    }
                    this.tabCommand.TabName = TabName;
                }
            }
            return czid;
        }


        /// <summary>
        /// ����������ID�������־��ȷ���������״̬
        /// flag��0��ʾͬ�� 1��ʾ��ͬ�� 2ת����ίԱ��
        /// </summary>
        /// <param name="status"></param>
        /// <param name="flag"></param>
        /// <param name="ZhuXi"></param>
        /// <returns></returns>
        private String GetShenPiStatus(String status,int flag,bool ZhuXi)
        {
            String result = null;
            switch (status)
            {
                case "11":
                    if (flag == 0)
                    {
                        result = "17";      //ͬ��ת����Ա����
                    }
                    else
                    {
                        result = "04";      //��ͬ�������ύ
                    }
                    break;
                case "12":
                    result = "13";          //ת���ίԱ������
                    break;
                case "13":
                    if (ZhuXi)              //ֻ�ж���ϯ�����
                    {
                        if (flag == 0)
                        {
                            result = "14";
                        }
                        else if (flag == 1)
                        {
                            result = "04";
                        }
                        else
                        {
                            result = "15";
                        }
                    }
                    break;
                case "15":
                    if (ZhuXi)              //ֻ�ж���ϯ�����
                    {
                        if (flag == 0)
                        {
                            result = "16";
                        }
                        else 
                        {
                            result = "04";
                        }
                    }
                    break;
                case "17":
                    if (flag == 0)
                    {
                        result = "12";
                    }
                    else
                    {
                        result = "04";
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// ���ķ���2���ʲ����ķ���
        /// </summary>
        /// <param name="zeren">������</param>
        /// <param name="czid">�ʲ������걨Id</param>
        /// <param name="sp1">��������</param>
        /// <returns></returns>
        private string SendSPPerson(string zeren, string czid, SP sp1)
        {
            string[] Person1 = zeren.Split(',');
            string zcid = null;     //�ʲ���ID
            String zcbid = null;    //�ʲ�����ID

            //1)�����ʲ�����ID�õ��ʲ�ID
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "U_ZC2";
            DataSet ds0 = this.tabCommand.SearchData("id,zcid,zcbid,status,spstatus", list1);
            if (ds0.Tables[0].Rows.Count > 0)
            {
                zcid = ds0.Tables[0].Rows[0]["zcid"].ToString().Trim();
                zcbid = ds0.Tables[0].Rows[0]["zcbid"].ToString().Trim();
                ds0.Tables[0].Rows[0]["status"] = ((int)sp1).ToString().PadLeft(2, '0');
                if (sp1 == SP.��������)
                {
                    ds0.Tables[0].Rows[0]["spstatus"] = "0";
                }
                this.tabCommand.Update(ds0);        //����U_ZC2�е�״̬����
            }

            //2)ͬ�������ʲ�U_ZC�е�����
            /*--------�����޸�Ϊ�ʲ����ʲ����Ĳ�ͬ�������----------*/
            /*--------2010-1-3   ���ټ�                  ----------*/
            if (String.IsNullOrEmpty(zcid) == false)
            {
                this.tabCommand.TabName = "U_ZC";
                list1.Clear();
                list1.Add(new SearchField("id", zcid));
                Hashtable ht0 = new Hashtable();
                ht0.Add("status", ((int)sp1).ToString().PadLeft(2, '0'));
                this.tabCommand.EditQuickData(list1, ht0);
            }

            if (String.IsNullOrEmpty(zcbid) == false)
            {
                this.tabCommand.TabName = "U_ZCBao";
                list1.Clear();
                list1.Add(new SearchField("id", zcbid));
                Hashtable ht0 = new Hashtable();
                ht0.Add("bstatus", ((int)sp1).ToString().PadLeft(2, '0'));
                this.tabCommand.EditQuickData(list1, ht0);
            }

            
            //3)���������в�������
            this.tabCommand.TabName = TabName;
            list1.Clear();
            list1.Add(new SearchField("czid", czid));
            list1.Add(new SearchField("pscount", "0"));
            string result = null;
            try
            {
                //ɾ��Ϊ0��������¼
                //this.tabCommand.DeleteData(list1);

                //�����µ�������¼
                Hashtable ht1 = new Hashtable();
                ht1["czid"] = czid;     //�ʲ�����ID
                if (String.IsNullOrEmpty(zcid) == false)
                {
                    ht1["zcid"] = zcid;     //�ʲ�ID
                }
                if (String.IsNullOrEmpty(zcbid) == false)
                {
                    ht1["zcbid"] = zcbid;   //�ʲ���ID
                }
                //ht1["bid"] = zcbid;
                ht1["zeren"] = Person1;
                ht1["kind"] = ((int)sp1).ToString().PadLeft(2, '0');

                //������������
                U_ZCSPBU zcsp = new U_ZCSPBU();
                zcsp.SaveSP(ht1);
                zcsp.Close();
                
                ////���͵����ʼ�
                //ZX_Email1BU em1 = new ZX_Email1BU();
                //for (int i = 0; i < Person1.Length; i++)
                //{
                //    em1.SendToZcGL(Person1[i], "����Ҫ���������ʲ�����ע�⼰ʱ������");
                //}
                //em1.Close();
            }
            catch(Exception err)
            {
                result = "��ʾ������ʧ�ܣ��������ύ������";
            }
            return result;

        }

        /// <summary>
        /// ���ķ���2�������������ݣ�����ʱ��������������
        /// </summary>
        /// <param name="ht"></param>
        private void SaveSP(Hashtable ht)
        {
            //string zcid = ht["zcid"].ToString();
            string[] zeren = (string[])ht["zeren"];
            string kind = ht["kind"].ToString();
            SP SP1 = (SP)Int32.Parse(kind);
            
            //���ίԱ����ϯ�;���ίԱ����ϯֻ������һ���ˣ�����������⣩
            U_RolesBU role1 = new U_RolesBU();
            List<String> sname1 = role1.GetRoleAllUsersList1("����ίԱ����ϯ");
            List<String> sname2 = role1.GetRoleAllUsersList1("���ίԱ����ϯ");
            role1.Close();

            /*�õ���ǰ�����ġ����Ρ�
              �����ġ����Ρ�����ǰ�������������ġ����Ρ�Ϊ׼
              ��һ�β�������ʱ������Ϊ1 */

            this.tabCommand.TabName = TabName;
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("czid", ht["czid"].ToString(), SearchFieldType.��ֵ��));
            string temp1 = (int)SP.�������� + "";
            list2.Add(new SearchField("kind", temp1.PadLeft(2, '0')));
            DataSet dstemp = this.tabCommand.SearchData("pscount", list2, "id desc");
            int pscount = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["pscount"] != DBNull.Value)
                {
                    pscount = (int)dstemp.Tables[0].Rows[0]["pscount"];
                }
            }
            if (kind == temp1)
            {
                pscount++;  //��ǰ�����Ĵ�����
            }

            //��������������
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", ht["czid"].ToString(), SearchFieldType.��ֵ��));
            list1.Add(new SearchField("time1", "null", SearchOperator.��ֵ));
            list1.Add(new SearchField("kind", kind));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            Hashtable ht1 = new Hashtable();

            for (int i = 0; i < zeren.Length; i++)
            {
                if (ht1.ContainsKey(zeren[i]) == false)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["czid"] = ht["czid"];
                    if (ht.ContainsKey("zcid"))
                    {
                        dr["zcid"] = ht["zcid"].ToString();
                    }
                    if (ht.ContainsKey("zcbid"))
                    {
                        dr["zcbid"] = ht["zcbid"].ToString();
                    }

                    dr["time0"] = DateTime.Now.ToString();
                    dr["kind"] = kind;
                    dr["zeren"] = zeren[i];
                    dr["pscount"] = pscount;


                    if ((sname1.Contains(zeren[i]) && SP1 == SP.����ίԱ������) 
                        || sname2.Contains(zeren[i]) && SP1 == SP.���ίԱ������)
                    {
                        dr["zx"] = "1";  //������ϯ�ı�ʶ
                    }

                    ds.Tables[0].Rows.Add(dr);
                    ht1.Add(zeren[i], zeren[i]);    //ȥ���ظ�����ѡ
                }
            }

            this.tabCommand.Update(ds);
            ds.AcceptChanges();
        }


        #endregion

        #region ����֧��(���ټ�)
        /// <summary>
        /// �õ��ʲ�������ͳ������
        /// </summary>
        /// <param name="dt1">��ʼʱ��</param>
        /// <param name="dt2">����ʱ��</param>
        /// <returns></returns>
        public DataSet GetZcSpStatic(DateTime dt1,DateTime dt2)
        {
            SqlParameter[] para1 = new SqlParameter[2];
            string sql = @"select distinct u_zc.zeren,U_Username.depart,
                            u_zcsp.kind,u_zcsp.zcid,
                            u_depart.num dnum, U_userName.num snum
                            from u_zcsp inner join u_zc
                            on u_zcsp.zcid=u_zc.id
                            inner join u_username on U_zc.zeren=u_UserName.sname
                            inner join u_depart on U_username.depart=u_depart.depart
                            where u_zcsp.time0>=@time0 and u_zcsp.time0<=@time1
                            
                            order by u_depart.num,U_userName.num";


            string t1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
            string t2 = dt2.ToString("yyyy-MM-dd") + " 23:59:59";

            if (dt1 != default(DateTime))
            {
                para1[0] = new SqlParameter("@time0", t1);
            }
            else
            {
                para1[0] = new SqlParameter("@time0", "2000-01-01");
            }
            if (dt2 != default(DateTime))
            {
                para1[1] = new SqlParameter("@time1", t2);
            }
            else
            {
                para1[1] = new SqlParameter("@time1", DateTime.Now.AddYears(1).ToString());
            }

            HttpContext.Current.Items["time0"] = dt1;
            HttpContext.Current.Items["time1"] = dt2;
            return this.tabCommand.TableComm.SearchData(sql,CommandType.Text,para1);
        }
        #endregion

        #region IDisposable ��Ա
        public void Dispose()
        {
            this.Close();
        }

        public void Close()
        {
            if (this.tabCommand != null)
            {
                this.tabCommand.Close();
            }
        }
        #endregion
    }
}

