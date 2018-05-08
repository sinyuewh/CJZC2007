using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Web;
using System.Data.SqlClient;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// 用户业务处理类
    /// </summary>
    public class XT_UserLogBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "XT_UserLog";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public XT_UserLogBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public XT_UserLogBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        /// <summary>
        /// 功能说明：增加当前用户的登录日志
        /// </summary>
        public void AddLogo(string username)
        {
            
            string depart = "";
            //根据当前用户名得到所在的部门
            U_UserNameBU user1 = new U_UserNameBU();
            depart = user1.GetDepart1(username);
            user1.Close();


            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname",username));
            list1.Add(new SearchField("endlogin", "", SearchOperator.空值));
            list1.Add(new SearchField("beginlogin", "", SearchOperator.非空值));
            DataSet ds=this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //表示没有用户登录日志记录，则增加一条新的数据记录；
                DataRow dr = ds.Tables[0].NewRow();
                dr["sname"] = username;
                dr["depart"] = depart;
                dr["beginlogin"] = DateTime.Now.ToString();
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                //表示存在没有完整的用户日志记录
                DateTime dt0 = DateTime.Now;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    DateTime dt1 = DateTime.Parse(dr["beginlogin"].ToString());
                    if (dt0.Date != dt1.Date)
                    {
                        //日期不相等，则直接修改结束日期为17：30
                        dr["endlogin"] = dt1.Date.ToString("yyyy-MM-dd") + " 17:30:00";
                        DateTime dt2 = DateTime.Parse(dr["endlogin"].ToString());
                        TimeSpan sp1 = dt2 - dt1;
                        dr["time1"] = sp1.Minutes.ToString();

                        //同时新增一条当他记录
                        DataRow dr1 = ds.Tables[0].NewRow();
                        dr1["sname"] = username;
                        dr1["depart"] = depart;
                        dr1["beginlogin"] = DateTime.Now.ToString();
                        ds.Tables[0].Rows.Add(dr1);
                    }
                }
            }
            this.tabCommand.Update(ds);
            ds.AcceptChanges();
        }



        /// <summary>
        /// 功能说明：调整当前用户的登录日志
        /// </summary>
        public void SignOutLogo(string username)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", username));
            list1.Add(new SearchField("endlogin", "", SearchOperator.空值));
            list1.Add(new SearchField("beginlogin", "", SearchOperator.非空值));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count != 0)
            {
                //表示存在没有完整的用户日志记录
                DateTime dt0 = DateTime.Now;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    DateTime dt1 = DateTime.Parse(dr["beginlogin"].ToString());
                    if (dt0.Date != dt1.Date)
                    {
                        //日期不相等，则直接修改结算日期为18：00点钟
                        dr["endlogin"] = dt1.Date.ToString("yyyy-MM-dd") + " 17:30:00";
                    }
                    else
                    {
                        dr["endlogin"] = dt0.ToString();
                    }


                    DateTime dt2 = DateTime.Parse(dr["endlogin"].ToString());
                    TimeSpan sp1 = dt2 - dt1;
                    dr["time1"] = sp1.Minutes.ToString();
                }
            }
            this.tabCommand.Update(ds);
            ds.AcceptChanges();

        }


        public DataSet GetUserLogList(String time0, String time1)
        {
            string sql = @"select U_username.num as snum , U_depart.num as dnum,
                            XT_userlog.depart as depart,XT_userlog.sname as zeren ,sum(datediff(mi,beginlogin,endlogin)) as time1
                            from XT_UserLog 
                            inner join U_UserName on XT_userlog.sname=U_username.sname
                            inner join U_depart on XT_userlog.depart=U_depart.depart
                            where xt_userlog.sname<>'admin' and endlogin is not null
                            and beginlogin>=@time0
                            and beginlogin<=@time1
                            group by U_username.num , U_depart.num ,XT_userlog.depart ,XT_userlog.sname
                            order by U_depart.num,U_username.num";

            SqlParameter[] para1 = new SqlParameter[2];
            if (time0 != null && time0.Trim() != "")
            {
                para1[0] = new SqlParameter("@time0", DateTime.Parse(time0).ToString("yyyy-MM-dd") + " 00:00:00");
            }
            else
            {
                sql = sql.Replace("beginlogin>=@time0", " 1=1 ");
            }

            if (time1 != null && time1.Trim() != "")
            {
                para1[1] = new SqlParameter("@time1", DateTime.Parse(time1).ToString("yyyy-MM-dd") + " 23:59:59");
            }
            else
            {
                sql = sql.Replace("beginlogin<=@time2", " 1=1");
            }

            //设置统计的时间
            HttpContext.Current.Items["time0"] = time0;
            HttpContext.Current.Items["time1"] = time1;

            DataSet ds = this.tabCommand.TableComm.SearchData(sql,CommandType.Text,para1);

            return ds;
        }


        public DataSet GetUserLogList(string time0, string time1, string depart, string zeren)
        {
            string sql = @"select U_username.num as snum , U_depart.num as dnum,
                            XT_userlog.depart as depart,XT_userlog.sname as zeren ,
                            beginlogin,endlogin,datediff(mi,beginlogin,endlogin) as time1
                            from XT_UserLog 
                            inner join U_UserName on XT_userlog.sname=U_username.sname
                            inner join U_depart on XT_userlog.depart=U_depart.depart
                            where xt_userlog.sname<>'admin' and time1>0 
                            and beginlogin>=@time0
                            and beginlogin<=@time1
                            and xt_userlog.depart=@depart
                            and xt_userlog.sname=@zeren
                            order by U_depart.num,U_username.num";

            SqlParameter[] para1 = new SqlParameter[4];
            if (time0 != null && time0.Trim() != "")
            {
                para1[0] = new SqlParameter("@time0", DateTime.Parse(time0).ToString("yyyy-MM-dd") + " 00:00:00");
            }
            else
            {
                sql = sql.Replace("beginlogin>=@time0", " 1=1 ");
            }

            if (time1 != null && time1.Trim() != "")
            {
                para1[1] = new SqlParameter("@time1", DateTime.Parse(time1).ToString("yyyy-MM-dd") + " 23:59:59");
            }
            else
            {
                sql = sql.Replace("beginlogin<=@time2", " 1=1");
            }

            if (String.IsNullOrEmpty(depart)==false)
            {
                para1[2] = new SqlParameter("@depart", depart);
            }
            else
            {
                sql = sql.Replace("xt_userlog.depart=@depart", " 1=1 ");
            }
            if (String.IsNullOrEmpty(zeren)==false)
            {
                para1[3] = new SqlParameter("@zeren", zeren);
            }
            else
            {
                sql = sql.Replace("xt_userlog.sname=@zeren", " 1=1 ");
            }


            DataSet ds = this.tabCommand.TableComm.SearchData(sql, CommandType.Text, para1);
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
