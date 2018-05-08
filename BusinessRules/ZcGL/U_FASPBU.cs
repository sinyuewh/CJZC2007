using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Web.UI.WebControls;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �����ѯ�����ݽṹ
    /// </summary>
    public class SearchStruct
    {
        public String xmmc;         //��Ŀ����
        public String xmsbh;        //��Ŀ�걨��
        public String num2;         //������ 
        public String danwei;       //��λ����
        public String spstatus;     //��Ŀ����״̬
        public String spresult;     //����ִ�н��
        public String status1;      //����ִ��״̬1
        public String status2;      //����ִ��״̬2
        public String zckind;       //�ʲ����
        public String time1;        //����ʱ��1
        public String time2;        //����ʱ��2
    }

    public class ShenPi
    {
        public String YiJian;
        public String Ren;
        public String ShiJian;
    }
    /// <summary>
    /// ��������ҵ������
    /// </summary>
    public class U_FASPBU
    {
        #region �õ��������
        /// <summary>
        /// �õ����������ô������
        /// </summary>
        /// <param name="czid"></param>
        /// <returns></returns>
        public ShenPi GetBuMenYiJian(String czid)
        {
            return this.GetYiJian(czid,"11");
        }


        //�õ�����Ա���
        public ShenPi GetPSYYiJian(String czid)
        {
            return this.GetYiJian(czid, "17");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="czid"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        private ShenPi GetYiJian(String czid,String kind)
        {
            ShenPi info1 = null;
            CommTable comm1 = new CommTable();
            comm1.TabName = "U_ZCSP";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("czid", czid));
            condition.Add(new SearchField("kind", kind));
            condition.Add(new SearchField("pscount", "0", SearchOperator.����));
            condition.Add(new SearchField("time1 is not null", "", SearchOperator.�û�����));
            DataSet ds = comm1.SearchData("top 1 zeren,PS,remark,time1", condition, "id desc");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                info1 = new ShenPi();
                info1.Ren = ds.Tables[0].Rows[0]["zeren"].ToString();
                info1.ShiJian = ds.Tables[0].Rows[0]["time1"].ToString();
                String temp1 = ds.Tables[0].Rows[0]["PS"].ToString().Trim();
                String temp2 = ds.Tables[0].Rows[0]["remark"].ToString().Trim();
                if (temp2 != String.Empty && kind!="11" && kind!="17")
                {
                    info1.YiJian = temp1 + "(" + temp2 + ")";
                }
                else
                {
                    info1.YiJian = temp1;
                }
            }
            comm1.Close();
            return info1;
        }
        #endregion

        /// <summary>
        /// ���ݲ�ѯ�������õ���ѯ���
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiListBySearchCondition(
            String xmmc, String num1, String danwei,
            String status, String time0, String time1,String status1,String status2)
        {
            List<SearchField> condition = new List<SearchField>();
            if (xmmc != String.Empty)
            {
                condition.Add(new SearchField("xmmc", xmmc, SearchOperator.����));
            }
            if (num1 != String.Empty)
            {
                condition.Add(new SearchField("num2", num1));
            }
            if (danwei != String.Empty)
            {
                condition.Add(new SearchField("danwei", danwei, SearchOperator.����));
            }
            if (status != String.Empty)
            {
                condition.Add(new SearchField("spstatus", status));
            }

            if (time0 != String.Empty)
            {
                condition.Add(new SearchField("shijian1", time0, SearchOperator.���ڵ���));
            }

            if (time1 != String.Empty)
            {
                condition.Add(new SearchField("shijian1", time1, SearchOperator.С�ڵ���));
            }

            if (status1 != String.Empty)
            {
                condition.Add(new SearchField("status1", status1));
            }

            if (status2 != String.Empty)
            {
                condition.Add(new SearchField("status2", status1));
            }

            //���ò�ѯ��Χ
            U_RolesBU role1 = new U_RolesBU();
            bool isAllCanSee = role1.isRole(new string[] { "��˾�쵼", "���󲿽�ɫ", "�ۺϹ���", "���", "����", "�쵼����" });
            role1.Close();
            //1)��˾�쵼����ơ����ɡ��쵼���� �ɲ�ѯ���е���Ŀ
            if (isAllCanSee==false)
            {
                //��ͨ���û�ֻ�ܲ�ѯ�Լ����𣨻������������Ŀ��
                List<SearchField> condition1 = new List<SearchField>();
                U_UserNameBU user1 = new U_UserNameBU();
                String userName1 = user1.GetSelfAndXiaShu(Comm.CurUser);
                user1.Close();
                if (userName1 != String.Empty)
                {
                    condition.Add(new SearchField("zeren", userName1, SearchOperator.����));
                }     
            }
           
            return this.GetShenPiList(condition);
        }

        public DataSet GetShenPiListBySearchCondition(SearchStruct searchinfo)
        {
            DataSet ds1 = null;
           
            List<SearchField> condition = new List<SearchField>();

            //ȥ��û��������¼������
            //2010-3-22�յ���
            SearchField search0 = new SearchField(" exists (select * from u_zcsp where u_zcsp.czid=u_zc2.id ) ", "", SearchOperator.�û�����);
            condition.Add(search0);

            //��Ŀ����
            if(String.IsNullOrEmpty(searchinfo.xmmc)==false)
            {
                condition.Add(new SearchField("xmmc", searchinfo.xmmc, SearchOperator.����));
            }

            //��Ŀ�걨��
            if (String.IsNullOrEmpty(searchinfo.xmsbh) == false)
            {
                condition.Add(new SearchField("xmsbh", searchinfo.xmsbh));
            }

            //��Ŀ������
            if (String.IsNullOrEmpty(searchinfo.num2) == false)
            {
                condition.Add(new SearchField("num2", searchinfo.num2));
            }

            //��λ����
            if (String.IsNullOrEmpty(searchinfo.danwei) == false)
            {
                condition.Add(new SearchField("danwei", searchinfo.danwei, SearchOperator.����));
            }

            //��Ŀ����״̬
            if (String.IsNullOrEmpty(searchinfo.spstatus) == false)
            {
                condition.Add(new SearchField("spstatus", searchinfo.spstatus));
            }


            //��Ŀִ�н��
            if (String.IsNullOrEmpty(searchinfo.spresult) == false)
            {
                condition.Add(new SearchField("spresult", searchinfo.spresult));
            }

            //��Ŀִ��״̬1
            if (String.IsNullOrEmpty(searchinfo.status1) == false)
            {
                condition.Add(new SearchField("status1", searchinfo.status1));
            }

            //��Ŀִ��״̬2
            if (String.IsNullOrEmpty(searchinfo.status2) == false)
            {
                condition.Add(new SearchField("status2", searchinfo.status2));
            }

            //�ʲ����
            if (String.IsNullOrEmpty(searchinfo.zckind) == false)
            {
                if (searchinfo.zckind == "0")   //�����ʲ�
                {
                    condition.Add(new SearchField("zcbid is null", "",SearchOperator.�û�����));
                }
                else
                {
                    condition.Add(new SearchField("zcbid is not null", "", SearchOperator.�û�����));
                }
            }

            //����ʱ��1
            if (String.IsNullOrEmpty(searchinfo.time1) == false)
            {
                condition.Add(new SearchField("cast(isnull(hysj2,hysj1) as datetime)", 
                    searchinfo.time1, SearchOperator.���ڵ���));
            }


            //����ʱ��2
            if (String.IsNullOrEmpty(searchinfo.time2) == false)
            {
                condition.Add(new SearchField("cast(isnull(hysj2,hysj1) as datetime)", 
                    searchinfo.time2, SearchOperator.С�ڵ���));
            }

            //��ѯ����������
            //string sql = SearchField.GetSearchCondition(condition);
            //System.Web.HttpContext.Current.Response.Write(sql);

            CommTable com2 = new CommTable();
            com2.TabName = "U_ZC2";
            ds1 = com2.SearchData(@"*,cast(isnull(hysj2,hysj1) as datetime) hysj",condition,"num2");
            com2.Close();            

            return ds1;
        }

        /// <summary>
        /// �õ����˸�����ʲ����ñ�
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList1()
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zeren", Comm.CurUser));      
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// �õ��Һ����������ʲ��б�
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList2()
        {
            List<SearchField> condition = new List<SearchField>();
            U_UserNameBU user1 = new U_UserNameBU();
            String userName1 = user1.GetSelfAndXiaShu(Comm.CurUser);
            user1.Close();
            if (userName1 != String.Empty)
            {
                condition.Add(new SearchField("zeren", userName1, SearchOperator.����));
                condition.Add(new SearchField("exists(select * from u_zcsp where czid=u_zc2.id)","",SearchOperator.�û�����));

            }     
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// �õ���˾����Ŀ�б�
        /// "��˾�쵼", "���", "���"
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList3()
        {
            U_RolesBU role1 = new U_RolesBU();
            bool isAllCanSee = role1.isRole(new string[] { "��˾�쵼", "�ۺϹ���", "���󲿽�ɫ", "���", "����", "�쵼����" });
            role1.Close();
            List<SearchField> condition = new List<SearchField>();
            if (isAllCanSee)
            {
                condition.Add(new SearchField("id>1","",SearchOperator.�û�����));     
            }
            else
            {
                condition.Add(new SearchField("id", "-1"));
            }

            //�����˷����ύ������Ҫ��11��7��5�յ�����
            condition.Add(new SearchField("exists(select * from u_zcsp where czid=u_zc2.id)", "", SearchOperator.�û�����));
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// �õ���Ҫ����������Ŀ�б�
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList4()
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id and  time1 is null and zeren='"+Comm.CurUser+"' )", "",SearchOperator.�û�����));     
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// �õ�������������Ŀ�б�
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList5()
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id and  time1 is not null and zeren='" + Comm.CurUser + "' )", "", SearchOperator.�û�����));
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// �õ��쵼����İ칫��Ŀ
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList6()
        {              
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("not exists ( select * from U_ZCSP where CZID=U_ZC2.id and ps='ͬ��' and zx is not null and (kind='13' or kind='15' ) )", "", SearchOperator.�û�����));
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id )", "", SearchOperator.�û�����));
            return this.GetShenPiList(condition);
            
        }

        
        /// <summary>
        /// �õ��ض��������ʲ���������
        /// </summary>
        /// <param name="condition">�ض��Ĳ�ѯ����</param>
        /// <returns></returns>
        public DataSet GetShenPiList(List<SearchField> condition)
        {
            CommTable comm1 = new CommTable("U_ZC2");
            List<SearchField> condition1 = new List<SearchField>();
            if (condition != null)
            {
                foreach (SearchField search1 in condition)
                {
                    condition1.Add(search1);
                }
            }

            DataSet ds1 = comm1.SearchData("*,isNull(num2,'δ���') num3 ", condition1,"num2");
            comm1.Close();
            return ds1;
        }
        
        /// <summary>
        /// �����������õ�ѡ����ʲ�
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataSet GetSelectZcList(List<SearchField> condition)
        {
            CommTable com1 = new CommTable();
            com1.TabName = "ZCView";
            List<SearchField> condition1 = new List<SearchField>();
            if (condition != null)
            {
                foreach (SearchField search1 in condition)
                {
                    condition1.Add(search1);
                }
            }
            condition1.Add(new SearchField("zeren", Comm.CurUser));

            /* 
             * ���Ӳ����ʲ���������(2010��1��2���޸� */
            SearchField search2=new SearchField("not exists (select * from u_zcbaoinfo where zcid=zcView.id)","",SearchOperator.�û�����);
            condition1.Add(search2);

            DataSet ds = com1.SearchData("*,left(danwei,20) as danwei1", condition1, "num2");
            com1.Close();
            return ds;
        }


        /// <summary>
        /// �õ��ʲ��������Ĭ����Ϣ1
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public Hashtable GetInfo1(String zcid)
        {
            Hashtable ht = new Hashtable();
            CommTable com1 = new CommTable();
            String sql = @"select zcview.num2,zcview.depart,zcview.zeren,zcview.danwei,
                            bxhj lixi,bj benjin,hjbx zqce,
                            bzrmc from ZcView left outer
                            join U_zc1 on zcview.id=u_zc1.id where zcview.id="
                            + zcid + " and zcview.zeren='" + Comm.CurUser + "'";
            //JSJ.SysFrame.Util.Print(sql);
            DataSet ds1 = com1.TableComm.SearchData(sql);
            //�õ���֤��λ
            com1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for(int i=0;i<ds1.Tables[0].Columns.Count;i++)
                {
                    String key1 = ds1.Tables[0].Columns[i].ColumnName.ToLower();
                    object value1 = ds1.Tables[0].Rows[0][key1];
                    ht.Add(key1, value1.ToString().Trim());
                }
                
            }
            return ht;
        }


        /// <summary>
        /// �õ��ʲ����������Ϣ1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hashtable GetInfo2(String id)
        {
            Hashtable ht = new Hashtable();
            CommTable com1 = new CommTable();
            String sql = @"select * from U_Zc2 where id="+id;
            DataSet ds1 = com1.TableComm.SearchData(sql);
            //�õ���֤��λ
            com1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Columns.Count; i++)
                {
                    String key1 = ds1.Tables[0].Columns[i].ColumnName.ToLower();
                    object value1 = ds1.Tables[0].Rows[0][key1];
                    ht.Add(key1, value1);
                }
            }
            return ht;
        }

        /// <summary>
        /// �����µ��ʲ�����������
        /// </summary>
        /// <param name="data"></param>
        public int InsertData(Hashtable data)
        {
            int zcid = 0;
            CommTable com1 = new CommTable("U_ZC2");
            
            com1.TableConnect.BeginTrans();
            try
            {
                com1.InsertData(data);
                String sql = "select @@identity as zcid";
                DataSet ds=com1.TableComm.SearchData(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    zcid=int.Parse(ds.Tables[0].Rows[0]["zcid"].ToString());
                }
                com1.TableConnect.CommitTrans();
            }
            catch (Exception err)
            {
                com1.TableConnect.RollBackTrans();
            }
            com1.Close();
            return zcid;
        }


        /// <summary>
        /// �޸�����������
        /// </summary>
        /// <param name="data">����</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public void  EditData(Hashtable data,String id)
        {
            CommTable com1 = new CommTable("U_ZC2");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id));
            com1.EditQuickData(condition, data);
            com1.Close();
        }
    }
}
