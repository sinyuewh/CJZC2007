using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Web;
using System.Web.Security;
using System.Collections;


namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �û�ҵ������
    /// </summary>
    public class DA_AnJuanBU:IDisposable
    {
        
        #region ���Զ���
        private const string TabName = "DA_AnJuan";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public DA_AnJuanBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CommTable TabCommand
        {
            get
            {
                return this.tabCommand;
            }
        }
        public DA_AnJuanBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�

        //��ʾ�����б�
        public DataSet GetAnJuanList(List<SearchField> list)
        {
            DataSet ds = this.tabCommand.SearchData("*", list);
            return ds;
        }
        //�õ�������ۺϲ�ѯ���
        public DataSet GetSearchResult(List<SearchField> list1)
        {
            U_RolesBU role1 = new U_RolesBU();
            String sql = null;
            String condition = SearchField.GetSearchCondition(list1);
            if (role1.isRole(new string[] { "��˾�쵼", "���󲿽�ɫ", "���", "����", "��������Ա" }))
            {

                sql = "select * from DA_AnJuan ";
                if (condition != null && condition.Trim() != String.Empty)
                {
                    sql = sql + " where " + condition;
                }
            }
            else
            {
                sql = @"select DA_AnJuan.*  from DA_AnJuan inner join U_ZC on
                        DA_AnJuan.ajnum=U_ZC.num2 where U_ZC.zeren='" + Comm.CurUser + "'";

                if (condition != null && condition.Trim() != String.Empty)
                {
                    sql = sql + " and " + condition;
                }
            }
            
            
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            return ds1;
        }

        //�õ�������ۺϲ�ѯ���
        public DataSet GetSearchResult_file(List<SearchField> list1)
        {
            this.tabCommand.TabName = "DA_AnJuanFileView";
            DataSet ds1 = this.tabCommand.SearchData("distinct id,ajnum,ajname,ajkind,ajstatus,time0 ", list1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        //ͨ��ID�õ�������ϸ
        public DataSet GetDetailByID1(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "DA_AnJuan";
            DataSet ds = this.tabCommand.SearchData("*",list2);
            return ds;
        }

        //ͨ��ajnum�õ�������ϸ
        public DataSet GetDetailByID2(string ajnum)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("ajnum", ajnum, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "DA_AnJuan";
            DataSet ds = this.tabCommand.SearchData("*", list2);
            return ds;
        }

        /// <summary>
        /// ͨ�������ŵõ�ID
        /// </summary>
        /// <param name="ajnum"></param>
        /// <returns></returns>
        public string GetIdByAjnum(string ajnum)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ajnum", ajnum, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string id = ds.Tables[0].Rows[0]["id"].ToString();
            return id;
        }

        //�ж��Ƿ��ƽ�
        public bool IsOrNotYiJiao(string GridViewID)
        {
                
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", GridViewID, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows[0]["yjdanwei"] != DBNull.Value && ds.Tables[0].Rows[0]["yjdanwei"].ToString().Trim()!="")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //��ȡ�ƽ�״ֵ̬
        public string ReadAjstatus(string GridViewID)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", GridViewID, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("ajstatus", list1);
            if (ds.Tables[0].Rows[0]["ajstatus"].ToString() != null)
            {
                return ds.Tables[0].Rows[0]["ajstatus"].ToString().Trim();
            }
            else
            {
                return null;
            }
        }
        //�ƽ�����
        public bool MoveAnJuan(string ajID,Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", ajID, SearchFieldType.��ֵ��));
                this.tabCommand.EditQuickData(list1, ht);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //�ж��ƽ������е��ļ��Ƿ񱻽���
        //public  bool IsOrNotJyue()
        //���°�����Ϣ
        public void UpdateAnJuanData(string id,Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list1, ht);
        }
        //����һ�ݰ���
        public bool AddAnJuanData(Hashtable ht)
        {
            try
            {
                this.tabCommand.TabName = "DA_AnJuanView";
                    this.tabCommand.InsertData(ht);
                    this.tabCommand.TabName = TabName;
                    return true;
            }
            catch
            {
                return false;
            }
        }
        //�õ������ѯ���
        public DataSet GetDangAnSearch(List<SearchField> list1)
        {
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }
        #endregion

        #region ˽�з���
        
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
