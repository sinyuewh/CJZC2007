using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.username.Text = Util.getCookieValue("currentuser");    //得到最近登录的用户名

            if (WebFrame.Util.JCookie.GetCookieValue("myPassWord") != String.Empty)
            {
                this.password.Attributes["value"] = WebFrame.Util.JCookie.GetCookieValue("myPassWord");
                this.chk1.Checked = true;
            }
            else
            {
                this.chk1.Checked = false;
            }
            
            this.username.Attributes["onKeyPress"] = "javaScript:CheckEnter();";
            this.password.Attributes["onKeyPress"] = "javaScript:CheckEnter1();";
            Page.DataBind();
            if (Request["loginout"] != null)
            {
                string js = "window.close();";
                Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "CloseJS", js, true);
            }
        }
        else
        {
            this.btnCheck_Click();
        }
    }

    //用户登录
    protected void btnCheck_Click()
    {
        U_UserNameBU user1 = new U_UserNameBU();
        bool login1 = user1.Login(this.username.Text.Trim(), this.password.Text.Trim());
        user1.Close();
        if (login1 == false)
        {
            Util.alert(this.Page, "提示：用户名或密码不正确！");
        }
        else
        {
            Hashtable ht = (Hashtable)Application["OnLineUser"];
            ht[this.username.Text.Trim()] = this.username.Text.Trim();

            //System.Web.Security.FormsAuthentication.SetAuthCookie(this.username.Text.Trim(), false);
            //FormsAuthentication.RedirectFromLoginPage(this.username.Text.Trim(), false);

            //设置登录信息
            //建立身份验证票对象
            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, this.username.Text,
                DateTime.Now, DateTime.Today.AddDays(1),true,this.username.Text,"/");

            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串
            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);
            Response.Cookies.Add(UserCookie); //输出Cookie



            //写入用户登录日志(管理员忽略不写）
            if (this.username.Text.Trim() != "admin")
            {
                XT_UserLogBU logo1 = new XT_UserLogBU();
                logo1.AddLogo(this.username.Text.Trim());
                logo1.Close();
            }

            if (this.chk1.Checked)
            {
                WebFrame.Util.JCookie.SetCookieValue("myPassWord", this.password.Text);
            }
            else
            {
                WebFrame.Util.JCookie.SetCookieValue("myPassWord", "");
            }

            this.WirteLoginInfo(this.username.Text.Trim());
            

            //调整错误的数据
            this.RestoreErrorData();

            //进行数据的转向处理
            if (this.db.SelectedIndex == 0)  //转老资产管理数据库
            {
                Response.Redirect("default0.aspx", true);
            }
            else                             //转汉口银行资产管理数据库
            {
                String url1 = ConfigurationManager.AppSettings["hkbankurl"];
                url1 = url1 + Server.UrlEncode(this.username.Text);
                Response.Redirect(url1, true);
            }

        }
    }

    private void RestoreErrorData()
    {
        CommTable com1 = new CommTable();
        //资产包中的重复数据
        String sql1="delete from u_zcbaoinfo where id in ( select min(id) from u_zcbaoinfo group by bid,zcid having count(*)>=2 )";
        String sql2="delete from u_zcbaoinfo where id in ( select min(id) from u_zcbaoinfo group by zcid having count(*)>=2 )";

        //项目审批表中的矛盾数据
        String sql3="update u_zc2 set zeren=u_zc.zeren from u_zc2 inner join u_zc on u_zc2.zcid=u_zc.id and u_zc2.zeren <>u_zc.zeren";

        //调整资产审批表和资产（资产包中的未启动的数据）
        String sql4 = "update u_zc set status1='未调查' where spresult='未启动' and (status1 is null or status1 ='' ) and (status2 is null or status2 ='' )";
        String sql5 = "update u_zcbao  set status1='未调查' where spresult='未启动' and (status1 is null or status1 ='' ) and (status2 is null or status2 ='' )";
        String sql6 = "update  u_zc2  set status1='未调查' where spresult='未启动' and (status1 is null or status1 ='' ) and (status2 is null or status2 ='' )";

        com1.TableComm.ExecuteNoQuery(sql1);
        com1.TableComm.ExecuteNoQuery(sql2);
        com1.TableComm.ExecuteNoQuery(sql3);
        com1.TableComm.ExecuteNoQuery(sql4);
        com1.TableComm.ExecuteNoQuery(sql5);
        com1.TableComm.ExecuteNoQuery(sql6);

        com1.Close();
    }

    /// <summary>
    /// 写入用户的登录日志
    /// </summary>
    /// <param name="userid"></param>
    private void WirteLoginInfo(String userid)
    {
        CommTable com1 = new CommTable();
        com1.TabName = "UserLogin";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("UserName", userid));
        DataSet ds1 = com1.SearchData("*", condition);
        DataRow dr = null;
        DateTime now1 = DateTime.Now;
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            dr = ds1.Tables[0].Rows[0];
            if (now1.Year.ToString() == dr["year1"].ToString().Trim()
                && now1.Month.ToString() == dr["month1"].ToString().Trim()
                && now1.Day.ToString() == dr["day1"].ToString().Trim()
                )
            {
                dr["loginCount"] = int.Parse(dr["loginCount"].ToString()) + 1;
            }
            else
            {
                dr["year1"] = now1.Year.ToString();
                dr["month1"] = now1.Month.ToString();
                dr["day1"] = now1.Day.ToString();
                dr["loginCount"] = 1;
            }
        }
        else
        {
            dr = ds1.Tables[0].NewRow();
            dr["UserName"] = userid;
            dr["year1"] = now1.Year.ToString();
            dr["month1"] = now1.Month.ToString();
            dr["day1"] = now1.Day.ToString();
            dr["loginCount"] = 1;
            ds1.Tables[0].Rows.Add(dr);
        }
        com1.Update(ds1);
        com1.Close();
    }
}
