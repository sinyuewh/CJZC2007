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
    /// 资产分配业务处理类
    /// 编码：金寿吉
    /// 时间：2007年9月17日
    /// </summary>
    public class U_ZcFPLogBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZcFPLog";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
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

        #region 业务方法

        //增加数据
        public void InsertData(string ZcIDS,string newzeren)
        {
            string domen = System.Web.HttpContext.Current.User.Identity.Name;
            string sql = " insert into " + TabName + " ( zcid,domen,zeren1,zeren2 ) ";
            sql+=" select  id,'"+domen+"',zeren,'"+newzeren+"' from U_ZC where id in ("+ZcIDS+")";
            this.tabCommand.TableComm.ExecuteNoQuery(sql);
        }

        /// <summary>
        /// 插入资产调整协管人的日志
        /// </summary>
        /// <param name="ZcIDS"></param>
        /// <param name="newzeren"></param>
        public void InsertXieGuanlLogData(string ZcIDS, string newzeren)
        {
            string domen = System.Web.HttpContext.Current.User.Identity.Name;
            string sql = " insert into " + TabName + " ( zcid,domen,zeren1,zeren2 ) ";
            sql += " select  id,'" + domen + "',zeren1,'" + newzeren + "(协管)' from U_ZC where id in (" + ZcIDS + ")";
            this.tabCommand.TableComm.ExecuteNoQuery(sql);
        }


        //删除数据
        public void DeleteData(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
        }


        //返回某个特定的资产分配日志列表
        public DataSet GetZcFpLogList(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid , SearchFieldType.数值型));
            return this.tabCommand.SearchData("*", list1, "id desc");
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
