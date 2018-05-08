using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using WebFrame.Data;
using WebFrame.Util;
using WebFrame;


/// <summary>
/// Comm 的摘要说明
/// 网站通用、常用的代码（要求写成静态方法，方便调用）
/// 编码：金寿吉
/// 时间：2007年8月4日
/// </summary>
//public enum SearchStaticType { 按年统计, 按月统计, 按季度统计, 按用户自定义时间统计 };

public class PubComm
{
    /// <summary>
    /// 系统升级
    /// </summary>
    public static void Upgrade()
    {
        String time1 = ConfigurationManager.AppSettings["gradeDate"];
        if (String.IsNullOrEmpty(time1) == false)
        {
            DateTime t1 = DateTime.Parse(time1);
            if (DateTime.Today <= t1)
            {
               
                JConnect conn1 = JConnect.GetConnect("DefaultConnstring");
                JCommand comm1 = new JCommand(conn1);
                comm1.CommandText = "select * from u_zc1 where 0=1";
                DataTable dt1 = comm1.SearchData(-1).Tables[0];

                //1--增加保证合同字段
                if (dt1.Columns.Contains("bzhtong") == false)
                {
                    String sql = "alter table u_zc1 add bzhtong nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                //2--抵押物
                if (dt1.Columns.Contains("dyw") == false)
                {
                    String sql = "alter table u_zc1 add dyw nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                //3--是否有抵押合同
                if (dt1.Columns.Contains("sfydyht") == false)
                {
                    String sql = "alter table u_zc1 add sfydyht nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                //4--对应抵押金额
                if (dt1.Columns.Contains("dyje") == false)
                {
                    String sql = "alter table u_zc1 add dyje nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                //5--抵押是否有效
                if (dt1.Columns.Contains("dysfyx") == false)
                {
                    String sql = "alter table u_zc1 add dysfyx nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                //6--抵押文件
                if (dt1.Columns.Contains("dywj") == false)
                {
                    String sql = "alter table u_zc1 add dywj nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                //7--抵押物评估报告
                if (dt1.Columns.Contains("dypgbg") == false)
                {
                    String sql = "alter table u_zc1 add dypgbg nvarchar(200)";
                    comm1.CommandText = sql;
                    comm1.ExecuteNoQuery();
                }

                
                JConnect.CloseConnect();
            }
        }
    }


    public static String MD5(String str1)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str1, "MD5"); ;
    }

    public static void SetProfile(String keyName,
        ListControl con1, String blankvalue)
    {
        PubComm.SetProfile(keyName, con1, "", blankvalue);
    }

    public static void SetProfile(String keyName,
        ListControl con1)
    {
        PubComm.SetProfile(keyName, con1, "", "");
    }

    /// <summary>
    /// 根据配置条目设置控制的类型
    /// </summary>
    /// <param name="keyName"></param>
    /// <param name="con1"></param>
    /// <param name="defaultValue"></param>
    public static void SetProfile(String keyName,
        ListControl con1, String defaultValue,String blankvalue)
    {
        String str1 = ConfigurationManager.AppSettings[keyName];
        if (String.IsNullOrEmpty(str1) == false)
        {
            String[] arr1 = str1.Split(',');
            foreach (String m in arr1)
            {
                ListItem list1 = new ListItem(m, m);
                con1.Items.Add(list1);
            }
        }

        if (String.IsNullOrEmpty(blankvalue) == false)
        {
            ListItem list1 = new ListItem(blankvalue, "");
            con1.Items.Insert(0, list1);
        }

        if (defaultValue == null)
        {
            defaultValue = "";
        }

        if (con1.Items.FindByValue(defaultValue) != null)
        {
            con1.SelectedValue = defaultValue;
        }
    }
    
    public static String GetMd5(String str1)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(str1, "MD5");
    }

    //设置数字的显示格式
    public static string GetNumberFormat(object num1)
    {
        if (num1==DBNull.Value  || num1 == null || num1.ToString().Trim() == "")
        {
            return "";
        }
        else
        {
           return  (double.Parse(num1.ToString())).ToString("n");
        }
    }


    /// <summary>
    /// 鉴别输入的字符串是否是数值型
    /// </summary>
    /// <param name="value1"></param>
    /// <returns></returns>
    public static bool isNumeric(String value1)
    {
        Regex r = new Regex(@"^\d+(\.)?\d*$");
        return r.IsMatch(value1);
    }

    //获取部分字符串
    public static string GetString(object num1)
    {
        if (num1 == DBNull.Value || num1 == null || num1.ToString().Trim() == "")
        {
            return "";
        }
        else
        {
            string[] str = num1.ToString().Split('_');
            return str[str.Length - 1];
        }
    }
    //获取部分字符串
    public static string GetString1(object num1)
    {
        if (num1 == DBNull.Value || num1 == null || num1.ToString().Trim() == "")
        {
            return "";
        }
        else
        {
            string[] str = num1.ToString().Split('－');
            return str[str.Length - 1];
        }
    }
    //设置政策包类别
    public static void SetZCB(ListControl drop1, string blankValue)
    {
        U_ItemBU item1 = new U_ItemBU();
        item1.ItemName = "政策包";
        item1.SetLiteralControl(drop1, blankValue);
        item1.Close();
    }


    //设置资产警告时间
    public static void SetTimeDays(ListControl drop1)
    {
        for (int i = 30; i <= 300; i++)
        {
            ListItem list1 = new ListItem(i.ToString() + "天", i.ToString());
            drop1.Items.Add(list1);
        }
    }

    //设置业务部门
    public static void SetDepart(ListControl drop1, string blankValue)
    {
        U_UserNameBU user1 = new U_UserNameBU();
        string[] arr = user1.GetZcJobDepart();
        if (arr != null)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                ListItem list1 = new ListItem(arr[i], arr[i]);
                drop1.Items.Add(list1);
            }
            if (blankValue != null && blankValue != "")
            {
                ListItem list1 = new ListItem(blankValue, "");
                drop1.Items.Insert(0, list1);
            }
        }
        user1.Close();
    }

    //设置责任人

    
    public static void SetZeRen(ListControl drop1, string depart, string blankValue)
    {
        drop1.Items.Clear();
        U_UserNameBU user1 = new U_UserNameBU();
        string[] arr = user1.GetAllPerson(depart);
        if (arr != null)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                ListItem list1 = new ListItem(arr[i], arr[i]);
                drop1.Items.Add(list1);
            }
        }

        if (blankValue != null && blankValue != "")
        {
            ListItem list1 = new ListItem(blankValue, "");
            drop1.Items.Insert(0, list1);
        }

    }

    //设置资产状态






    public static void SetZCStatus(ListControl drop1, string blankValue)
    {
        ZCStatusBU status1 = new ZCStatusBU();
        DataSet ds1 = status1.GetAllZcStatus();
        status1.Close();
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            ListItem list1 = new ListItem(ds1.Tables[0].Rows[i][0].ToString(), ds1.Tables[0].Rows[i][1].ToString());
            drop1.Items.Add(list1);
        }

        if (blankValue != null && blankValue != "")
        {
            ListItem list1 = new ListItem(blankValue, "");
            drop1.Items.Insert(0, list1);
        }
    }

    
    //设置处理后的转向
    public static void ShowInfo(string info, string url)
    {
        PubComm.ShowInfo(info, url, true);
    }

    public static void ShowInfo(string info, string url, bool AutoTrans)
    {
        System.Web.HttpContext.Current.Items["actioninfo"] = info;
        if (url != null)
        {
            System.Web.HttpContext.Current.Items["defaulturl"] = url;
        }
        System.Web.HttpContext.Current.Items["autotrans"] = AutoTrans;
        System.Web.HttpContext.Current.Server.Transfer("~/DoAction.aspx");
    }


    //设置当前用户是否有角色的权限，没有则转错误页
    public static void SetAccess(string curuser, string RoleName)
    {
        U_RolesBU role1 = new U_RolesBU();
        bool check1 = role1.isRole(RoleName);
        role1.Close();

        if (check1 == false)
        {
            System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx?info=NoAccess", true);
        }
    }


    public static bool IsRole(string curuser, string RoleName)
    {
        U_RolesBU role1 = new U_RolesBU();
        bool check1 = role1.isRole(RoleName);
        role1.Close();
        return check1;
    }

    
    public static bool IsRole(string RoleName)
    {
        U_RolesBU role1 = new U_RolesBU();
        bool check1 = role1.isRole(RoleName);
        role1.Close();
        return check1;
    }

    //判断某用户对某资产是否有维护的权限
    public static bool IsZcMng(string zcid, string username)
    {
        bool result = false;
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetDetailByID(zcid, "zeren");
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() == username)
            {
                result = true;
            }
        }
        zc1.Close();
        return result;
    }

    //判断某用户对某资产包是否有维护的权限
    public static bool IsZcBaoMng(string bid, string username)
    {
        bool result = false;
        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        DataSet ds1 = zcb1.GetDetailByID(bid, "bzeren");
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() == username)
            {
                result = true;
            }
        }
        zcb1.Close();
        return result;
    }


    //向当前用户的直接领导发送邮件提醒功能
    public static void SendMailToLeader(string title,string remark,string url)
    {
        string user1 = HttpContext.Current.User.Identity.Name;
        string leader=null;
        if (String.IsNullOrEmpty(user1) == false)
        {
            U_UserNameBU userBU = new U_UserNameBU();
            leader = userBU.GetDirLeader();
            userBU.Close();
        }

        if (leader != null)
        {
            ZX_EmailBu email1 = new ZX_EmailBu();
            Hashtable ht = new Hashtable();
            ht["time0"] = System.DateTime.Now.ToString();
            ht["title"] = title;
            ht["remark"] = remark;
            ht["from1"] = user1;
            ht["to1"] = leader;
            ht["back"] = "1";
            ht["url"] = url;

            email1.AddMail(ht);
            email1.Close();
        }
    }
}

