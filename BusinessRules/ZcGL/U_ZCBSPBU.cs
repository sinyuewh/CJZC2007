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

namespace JSJ.CJZC.Business
{
    //public enum SP
    //{
    //    ��ʼ���� = 4, �������� = 11,
    //    ��Ҫ�ұ�� = 12, ���ίԱ������ = 13,
    //    ���ίԱ��ͬ�� = 14, ����ίԱ������ = 15,
    //    ����ίԱ��ͬ�� = 16
    //};

    /// <summary>
    /// �û�ҵ������
    /// </summary>
    public class U_ZCBSPBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_ZCBSP";
        private CommTable tabCommand = null;
        string CurrentUser = null;
        #endregion

        #region ���캯��
        public U_ZCBSPBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public U_ZCBSPBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�
        /// <summary>
        /// ������ִ�С��Ͳ�������������
        /// </summary>
        /// <param name="czid">�ʲ�������ID</param>
        /// <returns></returns>
        public string PiYueZcBForDepart(string czid)
        {
            string err1 = null;
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                bool flag = this.GetNoEndSPByCZID(czid);
                if (flag == false)
                {
                    err1 = "������ʾ������δ��������Ļ��ڣ����ܽ����µ��������̣�";
                }
                else
                {
                    U_UserNameBU user1 = new U_UserNameBU();
                    string leader = user1.GetDirLeader();
                    user1.Close();
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
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "��ϵͳ���󡿣����ݿ��������������������ύ��";
            }
            
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
        /// ���ķ���2���ʲ����ķ���
        /// </summary>
        /// <param name="zeren">������</param>
        /// <param name="czid">�ʲ������걨Id</param>
        /// <param name="sp1">��������</param>
        /// <returns></returns>
        private string SendSPPerson(string zeren, string czid, SP sp1)
        {
            string[] Person1 = zeren.Split(',');
            string bid = null;     //�ʲ���ID

            //�����ʲ�����ID�õ��ʲ�ID
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "U_ZCB2";
            Hashtable ht0 = this.tabCommand.SearchData(list1);
            bid = ht0["bid"].ToString();

            U_ZCBAOBU zc1 = new U_ZCBAOBU();
            zc1.UpdateZcstatus(bid, ((int)sp1).ToString().PadLeft(2, '0'),"0");
            zc1.Close();

            this.tabCommand.TabName = TabName;
            string result = null;
            try
            {
                Hashtable ht1 = new Hashtable();
                ht1["bid"] = bid;
                ht1["czid"] = czid;
                ht1["zeren"] = Person1;
                ht1["kind"] = ((int)sp1).ToString().PadLeft(2, '0');
                this.SaveSP(ht1);
                
                ////���͵����ʼ�
                //ZX_Email1BU em1 = new ZX_Email1BU();
                //for (int i = 0; i < Person1.Length; i++)
                //{
                //    em1.SendToZcGL(Person1[i], "����Ҫ���������ʲ�������ע�⼰ʱ������");
                //}
                //em1.Close();
            }
            catch
            {
                result = "��ʾ������ʧ�ܣ��������ύ������";
            }
            return result;

        }

        private void SaveSP(Hashtable ht)
        {
            string bid = ht["bid"].ToString();
            string[] zeren = (string[])ht["zeren"];
            string kind = ht["kind"].ToString();
            SP SP1 = (SP)Int32.Parse(kind);

            //�����ʲ�������״̬
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", bid, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "U_ZCBAO";
            DataSet ds = this.tabCommand.SearchData("id,bstatus", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string status1 = ds.Tables[0].Rows[0]["bstatus"].ToString();
                if (kind.CompareTo(status1) > 0)
                {
                    ds.Tables[0].Rows[0]["bstatus"] = kind;
                    this.tabCommand.Update(ds);
                }
            }

            //���ίԱ����ϯ�;���ίԱ����ϯֻ������һ���ˣ�����������⣩
            U_RolesBU role1 = new U_RolesBU();
            string sname1 = role1.GetRoleAllUsers("����ίԱ����ϯ");
            string sname2 = role1.GetRoleAllUsers("���ίԱ����ϯ");
            role1.Close();

            this.tabCommand.TabName = TabName;
            //��������������

            Hashtable ht0 = new Hashtable();
            for (int i = 0; i < zeren.Length; i++)
            {
                list1.Clear();
                ds.Clear();

                list1.Add(new SearchField("bid", bid, SearchFieldType.��ֵ��));
                list1.Add(new SearchField("zeren", zeren[i]));
                list1.Add(new SearchField("time1", "null", SearchOperator.��ֵ));
                list1.Add(new SearchField("kind", kind));
                ds = this.tabCommand.SearchData("*", list1);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["bid"] = bid;
                    dr["czid"] = ht["czid"];
                    dr["time0"] = DateTime.Now.ToString();
                    dr["kind"] = kind;
                    dr["zeren"] = zeren[i];
                    //dr["pscount"] = pscount;
                    if ((zeren[i] == sname1 && SP1 == SP.����ίԱ������) || zeren[i] == sname2 && SP1 == SP.���ίԱ������)
                    {
                        dr["zx"] = "1";
                    }
                    ds.Tables[0].Rows.Add(dr);

                    //ht0["czid"] = ht["czid"];
                    //ht0["bid"] = bid;
                    //ht0["time0"] = DateTime.Now.ToString();
                    //ht0["kind"] = kind;
                    //ht0["zeren"] = zeren[i];
                    //if ((zeren[i] == sname1 && SP1 == SP.����ίԱ������) || zeren[i] == sname2 && SP1 == SP.���ίԱ������)
                    //{
                    //    ht0["zx"] = "1";
                    //}
                    //this.tabCommand.InsertData(ht0);
                }
                this.tabCommand.Update(ds);
                ds.AcceptChanges();
            }
        }

        //ɾ������
        public void DelSp(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.DeleteData(list1);
        }

        /// <summary>
        /// �õ���ǰû��������ɵ���������
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public int GetNoEndSPCount(string bid)
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bid", bid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField(" time1", "null", SearchOperator.��ֵ));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows.Count;
            }
            return result;
        }

        //����Ϣ���Ƶ����е��ʲ�
        public bool CopyZcBCzsbbtoZc(string bid, string id)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("bid", bid, SearchFieldType.��ֵ��));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                string ids = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            ids = ds.Tables[0].Rows[i]["zcid"].ToString();
                        }
                        else
                        {
                            ids = ids + "," + ds.Tables[0].Rows[i]["zcid"].ToString();
                        }
                    }
                }
                this.tabCommand.TabName = "U_ZCB2";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
                Hashtable ht = this.tabCommand.SearchData(list2);
                ht.Remove("id");
                ht.Remove("bid");
                this.tabCommand.TabName = "U_ZC2";
                if (ids != "")
                {
                    string[] str = ids.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        ht["zcid"] = str[i];
                        this.tabCommand.InsertData(ht);
                    }
                }
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch(Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        //����Ϣ���Ƶ����е��ʲ�
        public bool CopyZcBCzczfstoZc(string bid, string id)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("bid", bid, SearchFieldType.��ֵ��));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                string ids = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            ids = ds.Tables[0].Rows[i]["zcid"].ToString();
                        }
                        else
                        {
                            ids = ids + "," + ds.Tables[0].Rows[i]["zcid"].ToString();
                        }
                    }
                }
                this.tabCommand.TabName = "U_ZCB21";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
                Hashtable ht = this.tabCommand.SearchData(list2);
                ht.Remove("id");
                ht.Remove("bid");

                this.tabCommand.TabName = "U_ZC21";

                U_ZCBU zc1 = new U_ZCBU();
                if (ids != "")
                {
                    string[] str = ids.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        
                        ht["czid"] = zc1.GetCurrentZcCZbyID1(str[i])["zcczid"];
                        
                        ht["zcid"] = str[i];
                        this.tabCommand.InsertData(ht);
                    }
                }
                zc1.Close();
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch (Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        //�õ��ʲ������б�
        public DataSet GetZcSPList(string czid, string kind)
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


        //�����ʲ������ž���ִ��������
        public string PiYueZcForOffice(string spid, Hashtable ht,string bid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zeren = role1.GetRoleAllUsers("��Ҫ�ҵǼ���Ա");
                role1.Close();

                if (zeren.Trim() != "��")
                {
                    string czid = this.PiYue(spid, ht);

                    this.CopySPInfoToZC(bid, spid);

                    if (ht["ps"].ToString() == "ͬ��")
                    {
                        string temp = this.SendSPPerson((zeren.Split(','))[0], czid, SP.��Ҫ�ұ��);
                        if (temp == null)
                        {
                            info1 = "��ʾ�������ʲ���ɣ���ת�칫��������";
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
            }
        }


        //�����ʲ����칫������ִ�����ģ�
        public string PiYueZcForSHWeiYuan(string spid, Hashtable ht,string bid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //�޸��ʲ��������еġ���Ŀ�걨�š�
                string xmsbh = ht["xmsbh"].ToString();    //��Ŀ�걨�ţ�
                string czid1 = ht["czid"].ToString();   //�ʲ�����Id
                this.tabCommand.TabName = "U_ZCB2";
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
                    string czid = this.PiYue(spid, ht);

                    this.CopySPInfoToZC(bid, spid);

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

        //�����ʲ������ίԱ������ίԱ����ϯִ�����ģ�
        public string PiYueZcForSH1(string spid, Hashtable ht,string bid)
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

                    this.CopySPInfoToZC(bid, spid);

                    if (ht["zeren"].ToString() == zx1)
                    {
                        if (ht["ps"].ToString() == "�;���ίԱ��")
                        {
                            string temp = this.SendSPPerson(zeren, czid, SP.����ίԱ������);
                            if (temp == null)
                            {
                                info1 = "��ʾ�������ʲ���ɣ���ת���ίԱ��������";
                            }
                            else
                            {
                                info1 = "��ʾ������ʧ�ܣ��������ύ������";
                            }
                        }
                        else if (ht["ps"].ToString() == "ͬ��")
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

        //�����ʲ�������ίԱ��;���ίԱ����ϯִ�����ģ�
        public string PiYueZcForSH2(string spid, Hashtable ht,string bid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zx1 = role1.GetRoleAllUsers("����ίԱ����ϯ");
                role1.Close();

                string czid = this.PiYue(spid, ht);

                this.CopySPInfoToZC(bid, spid);

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
            string zcspstatus = "";
            string czid = "";
            List<SearchField> list1 = new List<SearchField>();

            //�޸����������е������Ϣ
            list1.Add(new SearchField("id", spid, SearchFieldType.��ֵ��));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            czid = ds1.Tables[0].Rows[0]["czid"].ToString();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DictionaryEntry item in ht)
                {
                    ds1.Tables[0].Rows[0][item.Key.ToString()] = item.Value;
                }
                this.tabCommand.Update(ds1);
            }

            //�޸��ʲ�����ص�����
            int NewStatus = 0;                      //��ʾ�ʲ��������״̬��
            list1.Clear();
            string bid = ds1.Tables[0].Rows[0]["bID"].ToString();
            this.tabCommand.TabName = "U_ZCBAO";
            list1.Add(new SearchField("id", bid, SearchFieldType.��ֵ��));
            DataSet ds2 = this.tabCommand.SearchData("id,bstatus", list1);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                int curStatus = Int32.Parse(ds2.Tables[0].Rows[0]["bstatus"].ToString());//��ʾ�ʲ��ĵ�ǰ״̬��
                NewStatus = curStatus;

                SP curSP = (SP)curStatus;                             //�ʲ���ǰ״̬��ö��ֵ
                if (curStatus == 4) curStatus = 10;
                int NextStatus = curStatus + 1;         //��ʾ�ʲ�����һ��״̬
                int BeginStatus = (int)SP.��ʼ����;      //��ʾ�ʲ������Ŀ�ʼ״̬


                //�������ίԱ��;���ίԱ����ϯ�����
                U_RolesBU role1 = new U_RolesBU();
                string zxname1 = role1.GetRoleAllUsers("���ίԱ����ϯ");
                bool zx1 = false;
                if (ht["zeren"].ToString() == zxname1)
                {
                    zx1 = true;
                }
                string zxname2 = role1.GetRoleAllUsers("����ίԱ����ϯ");
                bool zx2 = false;
                if (ht["zeren"].ToString() == zxname2)
                {
                    zx2 = true;
                }
                role1.Close();


                //�����ʲ��ĵ�ǰ״�����в�ͬ�Ĵ���
                if (ht["ps"].ToString() == "��ͬ��")
                {
                    if (curSP == SP.��������
                        || (curSP == SP.���ίԱ������ && zx1)
                        || (curSP == SP.����ίԱ������ && zx2)
                        )
                    {
                        NewStatus = BeginStatus;    //�ص�ԭ����״̬
                    }
                }
                else if (ht["ps"].ToString() == "ͬ��")
                {
                    if (curSP == SP.��������
                        || curSP == SP.��Ҫ�ұ��
                        || (curSP == SP.���ίԱ������ && zx1)
                        || (curSP == SP.����ίԱ������ && zx2)
                        )
                    {
                        NewStatus = curStatus + 1;    //ǰ������һ��״̬
                    }
                }
                else
                {
                    if (curSP == SP.���ίԱ������ && zx1)
                    {
                        NewStatus = curStatus + 1;    //ǰ����"����ίԱ������"
                    }
                }
                string sp1 = NewStatus + "";
                ds2.Tables[0].Rows[0]["bstatus"] = sp1.PadLeft(2, '0');
                this.tabCommand.Update(ds2);
            }

            this.tabCommand.TabName = TabName;
            //�޸��ʲ�������״̬
            zcspstatus = NewStatus + "";
            zcspstatus = zcspstatus.PadLeft(2, '0');
            list1.Clear();
            if (bid != "" && zcspstatus != "")
            {
                this.tabCommand.TabName = "U_ZCB2";
                list1.Add(new SearchField("id", czid, SearchFieldType.��ֵ��));
                Hashtable ht0 = new Hashtable();
                ht0["status"] = zcspstatus;
                this.tabCommand.EditQuickData(list1, ht0);
                this.tabCommand.TabName = TabName;
            }

            U_ZCBAOBU zc1 = new U_ZCBAOBU();
            zc1.UpdateZcstatus(bid,zcspstatus , "0");
            zc1.Close();

            return czid;
        }

        private void CopySPInfoToZC(string bid,string spid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", spid, SearchFieldType.��ֵ��));
            Hashtable ht = this.tabCommand.SearchData(list1);
            ht.Remove("bid");

            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            string ids = zcb1.GetZCIDByBID(bid);
            zcb1.Close();
            string[] str = ids.Split(',');
            U_ZCBU zc1 = new U_ZCBU();
            this.tabCommand.TabName = "U_ZCSP";
            for (int i = 0; i < str.Length; i++)
            {
                if (zc1.GetCurrentZcCZbyID1(str[i]) != null)
                {
                    string czid = zc1.GetCurrentZcCZbyID1(str[i])["zcczid"].ToString();
                    ht["zcid"] = str[i];
                    ht["czid"] = czid;
                    ht["PSCount"] = "0";
                    this.tabCommand.InsertData(ht);
                }
            }

            this.tabCommand.TabName = TabName;
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
