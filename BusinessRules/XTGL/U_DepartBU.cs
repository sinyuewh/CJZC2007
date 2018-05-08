using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Web.UI.WebControls;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// ����ҵ������
    /// ���룺���ټ�
    /// ʱ�䣺2007��8��5��
    /// </summary>
    public class U_DepartBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_Depart";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public U_DepartBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_DepartBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�
        //���ܣ��õ����еĲ����б�
        public DataSet GetAllDepart()
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("*", list1, "num");
            return ds;
        }

        //���ܣ��õ����еĲ����б�
        public DataSet GetAllDepart1()
        {
            string sql = "select * from U_depart where exists ( select * from U_userName where depart=U_depart.depart ) order by num ";
            DataSet ds = this.tabCommand.TableComm.SearchData(sql);
            return ds;
        }

        //���ܣ�����һ���²���
        public bool InsertData(Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("depart", ht["depart"].ToString()));
                DataSet ds1 = this.tabCommand.SearchData("num,depart,remark", list1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    this.tabCommand.InsertData(ht);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //���ܣ�ɾ��һ������
        public void DeleteData(string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.��ֵ��));
        }


        //���ܣ��޸�һ������
        public bool UpdataData(string id, Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("depart", ht["depart"].ToString()));
                list1.Add(new SearchField("id", id, SearchOperator.������, SearchFieldType.��ֵ��));
                DataSet ds1 = this.tabCommand.SearchData("num,depart,remark", list1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    this.tabCommand.EditQuickData(new SearchField("id", id, SearchFieldType.��ֵ��), ht);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        //���ò��ŵ�������
        public void SetDepartList(ListControl drop1, string blankvalue)
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("depart", list1, "num");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem l1 = new ListItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][0].ToString());
                drop1.Items.Add(l1);
            }

            if (blankvalue != null && blankvalue != "")
            {
                ListItem l1 = new ListItem(blankvalue, "");
                drop1.Items.Insert(0, l1);
            }
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

