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
    /// �û�ҵ������
    /// </summary>
    public class CW_StockBillBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "CW_StockBill";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public CW_StockBillBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CW_StockBillBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�
        public DataSet GetStockListByZcID(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("num", "0",  SearchOperator.����,SearchFieldType.��ֵ��));
            return this.tabCommand.SearchData("*",list1,"id");
        }

        public DataSet GetStockListByZcID1(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            return this.tabCommand.SearchData("*", list1, "id");
        }

        public DataSet GetStockList(string danwei, string gname,bool flag)
        {
            this.tabCommand.TabName = "CW_StockBillView";
            List<SearchField> list1 = new List<SearchField>();
            if (flag)
            {
                list1.Add(new SearchField("num", "0", SearchOperator.����, SearchFieldType.��ֵ��));
            }
            else
            {
                list1.Add(new SearchField("id", "0", SearchOperator.����, SearchFieldType.��ֵ��));
            }

            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.����));
            }
            if (gname != null && gname.Trim() != "")
            {
                list1.Add(new SearchField("gname", gname, SearchOperator.����));
            }
            DataSet ds = this.tabCommand.SearchData("*,left(danwei,20) as danwei1", list1, "danwei");
            this.tabCommand.TabName = TabName;
            return ds;
        }

        public DataSet GetStockList1(string danwei, string gname, string gkind, bool flag)
        {
            this.tabCommand.TabName = "CW_StockBillView";
            List<SearchField> list1 = new List<SearchField>();
            if (flag)
            {
                list1.Add(new SearchField("num", "0", SearchOperator.����, SearchFieldType.��ֵ��));
            }
            else
            {
                list1.Add(new SearchField("id", "0", SearchOperator.����, SearchFieldType.��ֵ��));
            }

            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.����));
            }
            if (gname != null && gname.Trim() != "")
            {
                list1.Add(new SearchField("gname", gname, SearchOperator.����));
            }
            if (gkind != null && gkind.Trim() != "")
            {
                list1.Add(new SearchField("gkind", gkind.Trim(), SearchOperator.����));
            }
            DataSet ds = this.tabCommand.SearchData("*,left(danwei,20) as danwei1", list1, "danwei");
            this.tabCommand.TabName = TabName;
            return ds;
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

