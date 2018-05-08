using System;
using System.Data;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace JSJ.CJZC.Business
{
    public sealed class Comm
    {
        //计算本人&本人领导
        public static List<String> GetMyPersonList1(String zr1)
        {
            List<String> list1 = new List<string>();
            if (String.IsNullOrEmpty(zr1) == false)
            {
                list1.Add(zr1);     //加入自己

                //得到自己的下属姓名
                String sql1 = String.Format("select sname,leader from u_username where charindex('{0}',leader)>0", zr1);
                CommTable com1 = new CommTable();
                DataSet ds1 = com1.TableComm.SearchData(sql1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
                    {
                        String leader1 = dr1["leader"].ToString().Trim();
                        String sname1 = dr1["sname"].ToString().Trim();
                        if (leader1 != String.Empty)
                        {
                            String[] arr1 = leader1.Split(',');
                            if (Array.IndexOf(arr1, leader1) >= 0 && sname1 != String.Empty)
                            {
                                if (list1.Contains(sname1) == false)
                                { list1.Add(sname1); }
                            }
                        }
                    }
                }

                
                //关闭连接
                com1.Close();
            }
            return list1;
        }

        //计算本人 & 本人领导的所有人员 &　资产协管人员
        public static List<String> GetMyPersonList(String zr1)
        {
            List<String> list1 = new List<string>();
            if (String.IsNullOrEmpty(zr1) == false)
            {
                list1.Add(zr1);     //加入自己

                //得到自己的下属姓名
                String sql1 = String.Format("select sname,leader from u_username where charindex('{0}',leader)>0", zr1);
                CommTable com1 = new CommTable();
                DataSet ds1 = com1.TableComm.SearchData(sql1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
                    {
                        String leader1 = dr1["leader"].ToString().Trim();
                        String sname1 = dr1["sname"].ToString().Trim();
                        if (leader1 != String.Empty)
                        {
                            String[] arr1 = leader1.Split(',');
                            if (Array.IndexOf(arr1, leader1) >= 0 && sname1 != String.Empty)
                            {
                                if (list1.Contains(sname1) == false)
                                { list1.Add(sname1); }
                            }
                        }
                    }
                }

                //得到自己协管的人员姓名
                sql1 = String.Format("select distinct zeren from u_zc where zeren1 ='{0}'", zr1);
                ds1.Clear();
                ds1 = com1.TableComm.SearchData(sql1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
                    {
                        String sname1 = dr1["zeren"].ToString().Trim();
                        if (sname1 != String.Empty)
                        {
                            if (list1.Contains(sname1) == false)
                            { list1.Add(sname1); }
                        }
                    }
                }

                //关闭连接
                com1.Close();
            }
            return list1;
        }

        public static void Print(Object obj1)
        {
            if (obj1 != null)
            {
                System.Web.HttpContext.Current.Response.Write(obj1.ToString());
            }
        }


        public static void RndUrl()
        {
            System.Web.HttpRequest Request = System.Web.HttpContext.Current.Request;
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;

            if (Request["Rnd"] == null || Request["Rnd"].Trim() == String.Empty)
            {
                String time0 = DateTime.Now.ToString();
                time0 = FormsAuthentication.HashPasswordForStoringInConfigFile(time0, "MD5");
                if (Request.RawUrl.IndexOf("?") < 0)
                {
                    Response.Redirect(Request.RawUrl + "?Rnd=" + time0, true);
                }
                else
                {
                    Response.Redirect(Request.RawUrl + "&Rnd=" + time0, true);
                }
            }
        }
        
        /// <summary>
        /// 获取或设置当前用户名的信息
        /// </summary>
        public static String CurUserName
        {
            get
            {
                return System.Web.HttpContext.Current.User.Identity.Name;
            }
            
        }
        
        /// <summary>
        /// 得到赞同委员和反对委员等信息
        /// </summary>
        /// <param name="czid"></param>
        /// <returns></returns>
        public static void GetWeiYuan1(String czid,
            String kind,
            out String weiyuan1,
            out String weiyuan2,
            out String weiyuan3,

            out String zhuxi,
            out String zhuxiTime,
            out string zhuxiyijian)
        {
            weiyuan1 = "";
            weiyuan2 = "";
            weiyuan3 = "";

            zhuxi = "";
            zhuxiTime = "";
            zhuxiyijian = "";

            CommTable com1 = new CommTable();
            com1.TabName = "U_ZCSP";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("czid", czid));
            condition.Add(new SearchField("kind", kind));
            condition.Add(new SearchField("time1 is not null", "", SearchOperator.用户定义));

            DataSet ds = com1.SearchData("zeren,ps,remark,zx,time1", condition);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //非主席意见
                if (dr["zx"].ToString().Trim() == String.Empty)
                {
                    if (dr["ps"].ToString().Trim() == "同意")
                    {
                        if (weiyuan1 == "")
                        {
                            weiyuan1 = dr["zeren"].ToString();
                        }
                        else
                        {
                            weiyuan1 = weiyuan1 + ";" + dr["zeren"].ToString();
                        }
                    }
                    else
                    {
                        if (dr["ps"].ToString().Trim() == "不同意")
                        {
                            if (weiyuan2 == "")
                            {
                                weiyuan2 = dr["zeren"].ToString();
                            }
                            else
                            {
                                weiyuan2 = weiyuan2 + ";" + dr["zeren"].ToString();
                            }
                        }
                        else
                        {
                            if (weiyuan3 == "")
                            {
                                weiyuan3 = dr["zeren"].ToString();
                            }
                            else
                            {
                                weiyuan3 = weiyuan3 + ";" + dr["zeren"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    zhuxi = dr["zeren"].ToString();
                    zhuxiTime = DateTime.Parse(dr["time1"].ToString()).ToString("yyyy-MM-dd");
                    if (dr["remark"].ToString().Trim() != String.Empty)
                    {
                        zhuxiyijian = dr["ps"].ToString() + "(" + dr["remark"].ToString() + ")";
                    }
                    else
                    {
                        zhuxiyijian = dr["ps"].ToString();
                    }
                }
            }
            com1.Close();
        }


        /// <summary>
        /// 判断用户是否有负责的资产
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public  static bool HaveZC()
        {
            bool result = false;
            CommTable com1 = new CommTable();
            com1.TabName = "u_zc";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zeren", Comm.CurUser));
            DataSet ds = com1.SearchData("count(*) count1", condition);
            com1.Close();
            if (ds!=null && ds.Tables[0].Rows.Count > 0)
            {
                if (Int32.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    result = true;
                }
            }
            return result;
        }


        //判断用户是否有部门的资产
        public static bool HaveBuZC()
        {
            U_UserNameBU user1 = new U_UserNameBU();
            String userName1 = user1.GetSelfAndXiaShu(Comm.CurUser);
            user1.Close();

            bool result = false;
            CommTable com1 = new CommTable();
            com1.TabName = "u_zc";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zeren", userName1,SearchOperator.集合));
            DataSet ds = com1.SearchData("count(*) count1", condition);
            com1.Close();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (Int32.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        
        public static string GetMD5String(String str1)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str1, "MD5");
        }
        /// <summary>
        /// 得到当前的用户
        /// </summary>
        public static String CurUser
        {
            get
            {
                return System.Web.HttpContext.Current.User.Identity.Name;
            }
        }


        public static SearchField GetSearchFieldOR(SearchField su1, SearchField su2)
        {
            string str1 = SearchField.GetSearchCondition(new SearchField[] { su1 });
            string str2 = SearchField.GetSearchCondition(new SearchField[] { su2 }); ;
            string sname = " ( " + str1 + " ) or ( " + str2 + " ) ";
            return new SearchField(sname, "", SearchOperator.用户定义);
        }
    }
}
