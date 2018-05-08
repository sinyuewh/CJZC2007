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
    public class ZCStatusBU : IDisposable
    {
        #region 属性定义

        private const string TabName = "U_ZCStatus";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数

        public ZCStatusBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public ZCStatusBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        //得到所有的状态

        public DataSet GetAllZcStatus()
        {
            List<SearchField> list1 = null;
            DataSet ds1 = this.tabCommand.SearchData("statusText,statusValue", list1, "num");
            return ds1;
        }


        public String GetTextByStatus(String status)
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("statusValue",status));
            Hashtable ht = this.tabCommand.SearchData(condition);
            if (ht != null && ht.Count > 0)
            {
                return ht["statustext"].ToString();
            }
            else
            {
                return "";
            }
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
