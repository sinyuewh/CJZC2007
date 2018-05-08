using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �ʲ�����ҵ������
    /// ���룺���ټ�
    /// ʱ�䣺2007��9��17��
    /// </summary>
    public class U_ZcFPLogBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_ZcFPLog";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public U_ZcFPLogBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ZcFPLogBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�

        //��������
        public void InsertData(string ZcIDS,string newzeren)
        {
            string domen = System.Web.HttpContext.Current.User.Identity.Name;
            string sql = " insert into " + TabName + " ( zcid,domen,zeren1,zeren2 ) ";
            sql+=" select  id,'"+domen+"',zeren,'"+newzeren+"' from U_ZC where id in ("+ZcIDS+")";
            this.tabCommand.TableComm.ExecuteNoQuery(sql);
        }

        /// <summary>
        /// �����ʲ�����Э���˵���־
        /// </summary>
        /// <param name="ZcIDS"></param>
        /// <param name="newzeren"></param>
        public void InsertXieGuanlLogData(string ZcIDS, string newzeren)
        {
            string domen = System.Web.HttpContext.Current.User.Identity.Name;
            string sql = " insert into " + TabName + " ( zcid,domen,zeren1,zeren2 ) ";
            sql += " select  id,'" + domen + "',zeren1,'" + newzeren + "(Э��)' from U_ZC where id in (" + ZcIDS + ")";
            this.tabCommand.TableComm.ExecuteNoQuery(sql);
        }


        //ɾ������
        public void DeleteData(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.DeleteData(list1);
        }


        //����ĳ���ض����ʲ�������־�б�
        public DataSet GetZcFpLogList(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid , SearchFieldType.��ֵ��));
            return this.tabCommand.SearchData("*", list1, "id desc");
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
