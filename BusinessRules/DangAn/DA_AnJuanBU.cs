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
    /// 用户业务处理类
    /// </summary>
    public class DA_AnJuanBU:IDisposable
    {
        
        #region 属性定义
        private const string TabName = "DA_AnJuan";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
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

        #region 业务方法

        //显示案卷列表
        public DataSet GetAnJuanList(List<SearchField> list)
        {
            DataSet ds = this.tabCommand.SearchData("*", list);
            return ds;
        }
        //得到案卷的综合查询结果
        public DataSet GetSearchResult(List<SearchField> list1)
        {
            U_RolesBU role1 = new U_RolesBU();
            String sql = null;
            String condition = SearchField.GetSearchCondition(list1);
            if (role1.isRole(new string[] { "公司领导", "评审部角色", "会计", "出纳", "档案管理员" }))
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

        //得到案卷的综合查询结果
        public DataSet GetSearchResult_file(List<SearchField> list1)
        {
            this.tabCommand.TabName = "DA_AnJuanFileView";
            DataSet ds1 = this.tabCommand.SearchData("distinct id,ajnum,ajname,ajkind,ajstatus,time0 ", list1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        //通过ID得到案卷详细
        public DataSet GetDetailByID1(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "DA_AnJuan";
            DataSet ds = this.tabCommand.SearchData("*",list2);
            return ds;
        }

        //通过ajnum得到案卷详细
        public DataSet GetDetailByID2(string ajnum)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("ajnum", ajnum, SearchFieldType.数值型));
            this.tabCommand.TabName = "DA_AnJuan";
            DataSet ds = this.tabCommand.SearchData("*", list2);
            return ds;
        }

        /// <summary>
        /// 通过案卷编号得到ID
        /// </summary>
        /// <param name="ajnum"></param>
        /// <returns></returns>
        public string GetIdByAjnum(string ajnum)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ajnum", ajnum, SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string id = ds.Tables[0].Rows[0]["id"].ToString();
            return id;
        }

        //判断是否移交
        public bool IsOrNotYiJiao(string GridViewID)
        {
                
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", GridViewID, SearchFieldType.数值型));
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
        //读取移交状态值
        public string ReadAjstatus(string GridViewID)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", GridViewID, SearchFieldType.数值型));
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
        //移交案卷
        public bool MoveAnJuan(string ajID,Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", ajID, SearchFieldType.数值型));
                this.tabCommand.EditQuickData(list1, ht);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //判断移交案卷中的文件是否被借阅
        //public  bool IsOrNotJyue()
        //更新案卷信息
        public void UpdateAnJuanData(string id,Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list1, ht);
        }
        //增加一份案卷
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
        //得到案卷查询结果
        public DataSet GetDangAnSearch(List<SearchField> list1)
        {
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
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
