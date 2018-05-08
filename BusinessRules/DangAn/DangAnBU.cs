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
    public class DangAnBU
    {
        //写入档案日志
        public static void WriteDAFileLog(String FileName, String remark)
        {
            CommTable tab1 = new CommTable("DA_AJDZFile");
            List<SearchField> condition = new List<SearchField>();
            SearchField search1 = new SearchField("ajTrueFile", FileName);
            condition.Add(search1);
            DataSet ds1 = tab1.SearchData("*", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                tab1.TabName = "DA_AJDZFileSeeLog";
                Hashtable ht1 = new Hashtable();
                ht1["ajnum"] = dr1["ajnum"].ToString();
                ht1["time0"] = DateTime.Now.ToString();
                ht1["domen"] = Comm.CurUser.ToLower();
                ht1["ajFile"] = dr1["ajFile"].ToString();
                if (String.IsNullOrEmpty(remark) == false)
                {
                    ht1["remark"] = remark;
                }
                tab1.InsertData(ht1);
            }
            tab1.Dispose();
            tab1.Close();
        }


        //删除过期的档案申请
        private  static void DeleteGuoQiBill()
        {
            CommTable com1 = new CommTable("DA_JyBill");
            List<SearchField> condition = new List<SearchField>();
            DateTime dt1=DateTime.Now.AddYears(-1);
            condition.Add(new SearchField("time0", dt1.ToString(), SearchOperator.小于));
            com1.DeleteData(condition);
            com1.Close();
        }


        //审批档案，agree为true表示同意，agree为false表示不同意
        public static void ShenPiDangAn(String ID, bool agree)
        {
            CommTable com1 = new CommTable("DA_JyBill");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", ID, SearchFieldType.数值型));
            DataSet ds1 = com1.SearchData("*", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                if (agree)
                {
                    dr1["status"] = "1";
                }
                else
                {
                    dr1["status"] = "0";
                }
                dr1["checkman"] = Comm.CurUser;
                dr1["checktime"] = DateTime.Now.ToString();
                dr1["time1"] = DateTime.Now.AddMonths(1);
                com1.Update(ds1);
            }
            com1.Close();
        }

        //判断是否可以管理某档案
        public static bool IsAdminForDAByID(String ajnum)
        {
            bool result = false;
            if (String.IsNullOrEmpty(ajnum) == false)
            {
                String sql = "SELECT U_ZC.depart FROM DA_JyBill LEFT OUTER JOIN U_ZC ON DA_JyBill.ajnum = U_ZC.num2 where ajnum = '" + ajnum.Trim() + "'";
                CommTable com1 = new CommTable();
                DataSet ds1 = com1.TableComm.SearchData(sql);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    String depart = ds1.Tables[0].Rows[0][0].ToString();
                    if (String.IsNullOrEmpty(depart) == false)
                    {
                        sql = "select id from U_DepartDangAnAdminUsers where depart='"+depart+"' and sname='"+Comm.CurUser+"'";
                        ds1.Clear();
                        ds1 = com1.TableComm.SearchData(sql);
                        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr1 = ds1.Tables[0].Rows[0];
                            if (dr1[0].ToString().Trim() != String.Empty)
                            {
                                result = true;
                            }
                        }
                    }
                }
                com1.Close();
            }
            return result;
        }

        //得到申请表的列表
        public static DataSet GetBorrowList(int curpage,int pageSize,
            out int totalRow,
            String ajnum,String domen)
        {
            //执行删除过去数据的操作
            DeleteGuoQiBill();
            
            totalRow = 0;
            DataSet ds1 = new DataSet();
            String sql = "SELECT DA_JyBill.*, U_Zc.danwei, U_ZC.depart FROM DA_JyBill LEFT OUTER JOIN U_ZC ON DA_JyBill.ajnum = U_ZC.num2 where ( 1=1)";
            CommTable com1 = new CommTable();

            if (ajnum.Trim() != String.Empty)
            {
                sql = sql + " and ( ajnum = '" + ajnum.Trim() + "') ";
            }

            if (domen.Trim() != String.Empty)
            {
                sql = sql + " and ( borrow like = '%" + domen.Trim() + "%') ";
            }

            //不是管理员，则增加过滤条件
            if (Comm.CurUser.ToLower() != "admin")
            {
                String condition1 = "( borrow= '" + Comm.CurUser.ToLower() + "' )) ";

                String[] depart1 = DangAnBU.GetManageDepart();
                if (depart1 != null && depart1.Length > 0)
                {
                    //得到合适部门列表
                    String temp = "";
                    foreach (String m in depart1)
                    {
                        if (temp == "")
                        {
                            temp = m;
                        }
                        else
                        {
                            temp = temp + "," + m;
                        }
                    }
                    temp = temp.Replace(",", "','");
                    temp = "'" + temp + "'";


                    condition1 = condition1 + " or (U_ZC.depart in ( " + temp + " ) ) ";
                }
                condition1 = "( " + condition1;
                sql = sql + " and " + condition1;
            }
            sql = sql + " order by DA_JyBill.id desc ";

            ds1 = com1.TableComm.SearchData(sql, CommandType.Text, null, curpage, pageSize , "table1", out totalRow);
            return ds1;
            //System.Web.HttpContext.Current.Response.Write(sql);
            //return null;
        }

        //得到当前用户管理的档案部门
        public static String[] GetManageDepart()
        {
            String[] result = null;
            String user1 = Comm.CurUser;
            if (String.IsNullOrEmpty(user1) == false)
            {
                CommTable com1 = new CommTable("U_DepartDangAnAdminUsers");
                List<SearchField> condition = new List<SearchField>();
                condition.Add(new SearchField("sname", user1));
                DataSet ds1 = com1.SearchData("distinct depart", condition);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    result = new String[ds1.Tables[0].Rows.Count];
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        result[i] = ds1.Tables[0].Rows[i][0].ToString();
                    }
                }
                com1.Close();
            }
            return result;
        }

        //判断当前用户是否为某部门的档案管理员
        public static bool IsAdminForDepart(String depart)
        {
            bool result = false;
            String user1 = Comm.CurUser;
            if (user1.ToLower() == "admin")
            {
                result = true;
            }
            else
            {
                if (String.IsNullOrEmpty(user1) == false)
                {
                    CommTable com1 = new CommTable("U_DepartDangAnAdminUsers");
                    List<SearchField> condition = new List<SearchField>();
                    condition.Add(new SearchField("sname", user1));
                    condition.Add(new SearchField("depart", depart));
                    DataSet ds1 = com1.SearchData("count(*)", condition);
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        if (int.Parse(ds1.Tables[0].Rows[0][0].ToString()) > 0)
                        {
                            result = true;
                        }
                    }
                    com1.Close();
                }
            }
            return result;
        }

        //判断是否能浏览档案
        public static bool isCanSeeFile(String ajnum)
        {
            bool result = false;
            //判断是否为“档案管理员”
            String[] allowRoles = new String[] { "档案管理员", "公司领导", "评审部角色" };
            U_RolesBU role1 = new U_RolesBU();

            //判断是否为“公司领导”
            result = role1.isRole(allowRoles);

            //判断是否为该资产责任人的 “领导”
            //判断是否为该资产的责任人或“协办人"
            if (result == false)
            {
                //普通的用户只能查询自己负责（或下属负责的项目）
                U_UserNameBU user1 = new U_UserNameBU();
                String userName1 = user1.GetSelfAndXiaShu(Comm.CurUser);
                user1.Close();

                String[] userArr = userName1.Split(',');
                CommTable tab1 = new CommTable("U_ZC");
                List<SearchField> condition = new List<SearchField>();
                condition.Add(new SearchField("num2",ajnum));
                DataSet ds1=tab1.SearchData("*",condition);
                if (ds1 != null && ds1.Tables[0].Rows.Count>0)
                {
                    DataRow dr1 = ds1.Tables[0].Rows[0];
                    String u1 = dr1["Zeren"].ToString().Trim();
                    string u2 = dr1["Zeren1"].ToString().Trim();
                    if (u1 != String.Empty && Array.IndexOf(userArr, u1) >= 0)
                    {
                        result = true;    //判断是否为资产的责任人（或责任人领导）
                    }


                    //判断是否为资产的协办人
                    if (result == false)
                    {
                        if (u2 != String.Empty && u2==Comm.CurUser)
                        {
                            result = true;
                        }
                    }
                }
            }

            //判断是否通过了借阅申请
            if (result == false)
            {
                CommTable comm1 = new CommTable("DA_JyBill");
                List<SearchField> condition = new List<SearchField>();
                condition.Add(new SearchField("ajnum", ajnum));
                condition.Add(new SearchField("borrow", Comm.CurUser));
                condition.Add(new SearchField("status", "1"));
                condition.Add(new SearchField("time1", DateTime.Now.ToString("yyyy-MM-dd"), SearchOperator.大于等于));
                DataSet ds1=comm1.SearchData("count(*)", condition);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    DataRow dr1 = ds1.Tables[0].Rows[0];
                    if (int.Parse(dr1[0].ToString().Trim()) > 0)
                    {
                        result = true;
                    }
                }
                comm1.Close();
            }

            return result;
        }

        //提交借阅申请
        public static String BorrorAnJuan(String ajnum,
            String time0,String borrow,String remark)
        {
            String result = String.Empty;
            if (String.IsNullOrEmpty(ajnum) == false
                && String.IsNullOrEmpty(time0) == false
                && String.IsNullOrEmpty(borrow) == false)
            {
                CommTable tab1 = new CommTable();
                tab1.TabName = "DA_JyBill";
                List<SearchField> condition = new List<SearchField>();
                condition.Add(new SearchField("ajnum", ajnum));
                condition.Add(new SearchField("borrow", borrow));
                condition.Add(new SearchField("time1 is null", "",SearchOperator.用户定义));
                DataSet ds1 = tab1.SearchData("*", condition);
                if (ds1 != null)
                {
                    if (ds1.Tables[0].Rows.Count == 0)
                    {
                        DataRow dr1 = ds1.Tables[0].NewRow();
                        dr1["ajnum"] = ajnum;
                        dr1["time0"] = time0;
                        dr1["borrow"] = borrow;
                        dr1["remark"] = remark;
                        dr1["status"] = "0";
                        ds1.Tables[0].Rows.Add(dr1);
                        tab1.Update(ds1);
                        tab1.Close();
                    }
                    else
                    {
                        result = "错误：你已借阅过了，正等待管理员审批！";
                    }
                }
            }
            return result;
        }

        //得到档案管理员列表
        public static DataSet GetAdminList()
        {
            CommTable comm1 = new CommTable("U_DepartDangAnAdminUsers");
            List<SearchField> condition = null;
            DataSet ds1 = comm1.SearchData("*",condition);
            comm1.Close();
            return ds1;
        }

        //删除档案管理员
        public static void DeleteAdmin(String id)
        {
            CommTable comm1 = new CommTable("U_DepartDangAnAdminUsers");
            List<SearchField> condition =new List<SearchField>();
            condition.Add(new SearchField("id", id, SearchFieldType.数值型));
            comm1.DeleteData(condition);
            comm1.Close();
        }

        //得到档案管理员的姓名
        public static DataRow GetAdmin(String id)
        {
            DataRow dr1 = null;
            CommTable comm1 = new CommTable("U_DepartDangAnAdminUsers");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = comm1.SearchData("*", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                dr1 = ds1.Tables[0].Rows[0];
            }
            comm1.Close();
            return dr1;
        }

        //更新管理员
        public static void UpdateAdmin(String id, String num, 
            String depart, String sname)
        {
            if (String.IsNullOrEmpty(id))
            {
                id = "-1";
            }

            DataRow dr1 = null;
            CommTable comm1 = new CommTable("U_DepartDangAnAdminUsers");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = comm1.SearchData("*", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                dr1 = ds1.Tables[0].Rows[0];
                dr1["num"] = num;
                dr1["depart"] = depart;
                dr1["sname"] = sname;
            }
            else
            {
                dr1 = ds1.Tables[0].NewRow();
                dr1["num"] = num;
                dr1["depart"] = depart;
                dr1["sname"] = sname;
                ds1.Tables[0].Rows.Add(dr1);
            }
            comm1.Update(ds1);
            comm1.Close();
        }
    }
}
