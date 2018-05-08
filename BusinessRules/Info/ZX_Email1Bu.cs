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
    /// 发件箱业务处理类
    /// 编码人：
    /// 时间：8月13日
    /// </summary>
    public class ZX_Email1BU : IDisposable
    {
        #region 属性定义
        private const string TabName = "ZX_Email1";
        private CommTable tabCommand = null;
        private string curUser;
        public string CurUser
        {
            get
            {
                return curUser;
            }
        }
        #endregion

        #region 构造函数
        public ZX_Email1BU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            curUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public ZX_Email1BU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        //return send mail list
        public DataSet GetSendMail(int curpage, int pageSize, string orderBy, out int totalRow)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("from1", curUser));
            DataSet ds1 = new DataSet();
            ds1 = this.tabCommand.SearchData("*", list1,orderBy,curpage,pageSize,out totalRow);
            for (int i = 0; i < ds1.Tables[0].Rows.Count;i++ )
            {
                string temp = ds1.Tables[0].Rows[i]["to1"].ToString();
                if (temp.Split(',').Length > 1)
                {
                    ds1.Tables[0].Rows[i]["to1"] = (temp.Split(','))[0] + "等";
                }

            }
            return ds1;
        }


        public DataSet GetSendMail(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("from1", curUser));
            list1.Add(new SearchField("id",id));
            DataSet ds1 = new DataSet();
            ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }
        public DataSet GetSendMail1(string ids)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));

            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }

        //zcgl
        public void SendToZcGL(string to1, string remark)
        {
            this.tabCommand.TabName = "ZX_Email";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", "-1", SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            string []arr1=to1.Split(',');
            for(int i=0;i<arr1.Length;i++)
            {
                DataRow dr = ds1.Tables[0].NewRow();
                dr["to1"] = arr1[i];
                dr["from1"] = this.curUser;
                dr["time0"] = DateTime.Now.ToString();
                dr["remark"] = remark;
                dr["title"] = "需要审批资产";
                ds1.Tables[0].Rows.Add(dr);
            }
            this.tabCommand.Update(ds1);
            this.tabCommand.TabName = TabName;
        }

        //del mail
        public void DelMail(string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.数值型));
        }
        //send mail
        public bool AddMail(Hashtable ht)
        {
            try
            {
                //List<SearchField> list1 = new List<SearchField>();
                //list1.Add(new SearchField("from1", curUser));
                this.tabCommand.InsertData(ht);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IfCzFile(string file, string kind)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("file" + kind, file));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
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
