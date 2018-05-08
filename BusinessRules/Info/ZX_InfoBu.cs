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
    public class ZX_InfoBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "ZX_Info";
        private CommTable tabCommand = null;
        private string curuser = null;
        #endregion

        #region 构造函数
        public ZX_InfoBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.curuser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public ZX_InfoBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法

        //得到今天最新的今日信息
        public int GetNewInfoCount()
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("time0",DateTime.Now.ToString("yyyy-MM-dd"),SearchOperator.大于等于));
            list1.Add(new SearchField("time0",DateTime.Now.ToString("yyyy-MM-dd 23:59:59"),SearchOperator.小于等于));
            DataSet ds1 = this.tabCommand.SearchData("count(*) as infoCount", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = Int32.Parse(ds1.Tables[0].Rows[0][0].ToString());
                ds1.Dispose();
            }
            return result;
        }
        public DataSet GetInfo(string selValue,string txt,int curpage,int pageSize,string orderBy,out int totalRow)
        {
           // this.tabCommand.TabName = "ZX_InfoView";

            List<SearchField> list1 = new List<SearchField>();
            if (selValue != null && selValue.Trim() != "")
            {
                list1.Add(new SearchField("kind", selValue));
            }
            if (txt != null && txt.Trim() != "")
            { 
                list1.Add(new SearchField("title",txt,SearchOperator.包含));
            }
           // list1.Add(new SearchField(" ( ydren","='"+this.curuser+"' or ydren is null )",SearchOperator.用户定义));
            

            DataSet ds = this.tabCommand.SearchData("*", list1,orderBy,curpage,pageSize,out totalRow);
            return ds;
        }
        public DataSet GetInfo(string selValue, string txt)
        {
            // this.tabCommand.TabName = "ZX_InfoView";

            List<SearchField> list1 = new List<SearchField>();
            if (selValue != null && selValue.Trim() != "")
            {
                list1.Add(new SearchField("kind", selValue));
            }
            if (txt != null && txt.Trim() != "")
            {
                list1.Add(new SearchField("title", txt, SearchOperator.包含));
            }
            // list1.Add(new SearchField(" ( ydren","='"+this.curuser+"' or ydren is null )",SearchOperator.用户定义));


            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        //是否为已读信息
        public bool IfRead(string id)
        {
            this.tabCommand.TabName = "ZX_InfoView1";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("(ydren", "='" + this.curuser + "')", SearchOperator.用户定义));
            list1.Add(new SearchField("ID",id));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public DataSet GetInfoByID(string id)
        {
            SearchField serach1 = new SearchField("id", id);
            DataSet ds = this.tabCommand.SearchData("title,time0,remark,kind", new SearchField[] { serach1});

            return ds;
        }


        public DataSet ReadInfoByID(string id)
        {
            SearchField serach1 = new SearchField("id", id);
            DataSet ds = this.tabCommand.SearchData("*", new SearchField[] { serach1 });

            //set read info
            this.tabCommand.TabName = "ZX_infoRead";
            List<SearchField> list1=new List<SearchField>();
            list1.Add(new SearchField("infoid", id, SearchFieldType.数值型));
            list1.Add(new SearchField("ydren", this.curuser));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count <= 0)
            {
                DataRow dr = ds1.Tables[0].NewRow();
                dr["infoid"] = id;
                dr["ydren"] = this.curuser;
                dr["ydtime"] = System.DateTime.Now.ToString();
                ds1.Tables[0].Rows.Add(dr);

                this.tabCommand.Update(ds1);
            }
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //delete data
        public void DeleteData(string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.数值型));
        }
        //update data
        public bool UpdateData(string id, Hashtable ht)
        {
            try
            {
                //List<SearchField> list1 = new List<SearchField>();
                //list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                this.tabCommand.EditQuickData(new SearchField("id", id, SearchFieldType.数值型), ht);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //insert data
        public bool InsertData(Hashtable ht)
        {
            try
            {
                this.tabCommand.InsertData(ht);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditInfo(string id, Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                this.tabCommand.EditQuickData(list1, ht);
                return true;
            }
            catch
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
