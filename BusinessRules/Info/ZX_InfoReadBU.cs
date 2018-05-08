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
    public class ZX_InfoReadBU: IDisposable
    {
        #region 属性定义
        private const string TabName = "ZX_InfoRead";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public ZX_InfoReadBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public ZX_InfoReadBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        //删除一条信息，删除读过该信息的所有用户
        public void DelDataByID(string id)
        {
            this.tabCommand.DeleteData(new SearchField("infoid", id, SearchFieldType.数值型));
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
