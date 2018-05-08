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
    /// 用户业务处理类
    /// </summary>
    public class CW_StockBillBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "CW_StockBill";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
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

        #region 业务方法
        public DataSet GetStockListByZcID(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField("num", "0",  SearchOperator.大于,SearchFieldType.数值型));
            return this.tabCommand.SearchData("*",list1,"id");
        }

        public DataSet GetStockListByZcID1(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            return this.tabCommand.SearchData("*", list1, "id");
        }

        public DataSet GetStockList(string danwei, string gname,bool flag)
        {
            this.tabCommand.TabName = "CW_StockBillView";
            List<SearchField> list1 = new List<SearchField>();
            if (flag)
            {
                list1.Add(new SearchField("num", "0", SearchOperator.大于, SearchFieldType.数值型));
            }
            else
            {
                list1.Add(new SearchField("id", "0", SearchOperator.大于, SearchFieldType.数值型));
            }

            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            if (gname != null && gname.Trim() != "")
            {
                list1.Add(new SearchField("gname", gname, SearchOperator.包含));
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
                list1.Add(new SearchField("num", "0", SearchOperator.大于, SearchFieldType.数值型));
            }
            else
            {
                list1.Add(new SearchField("id", "0", SearchOperator.大于, SearchFieldType.数值型));
            }

            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            if (gname != null && gname.Trim() != "")
            {
                list1.Add(new SearchField("gname", gname, SearchOperator.包含));
            }
            if (gkind != null && gkind.Trim() != "")
            {
                list1.Add(new SearchField("gkind", gkind.Trim(), SearchOperator.等于));
            }
            DataSet ds = this.tabCommand.SearchData("*,left(danwei,20) as danwei1", list1, "danwei");
            this.tabCommand.TabName = TabName;
            return ds;
        }
        #endregion

        #region 私有方法
        #endregion

        #region IDisposable 成员
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

