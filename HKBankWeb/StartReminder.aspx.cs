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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class StartReminder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZX_EmailBu email1 = new ZX_EmailBu();
            this.newmail.Text = email1.GetNewMailCount() + "";
            email1.Close();

            ZX_InfoBU info1 = new ZX_InfoBU();
            this.newinfo.Text = info1.GetNewInfoCount()+"";
            info1.Close();

            U_ZCTimeBU time1 = new U_ZCTimeBU();
            DataSet ds1 = time1.GetMyTimeList(User.Identity.Name, null, 1);
            this.MyTime.Text = ds1.Tables[0].Rows.Count + "";
            ds1.Dispose();
            time1.Close();
        }
    }


    //设置是否再次出现登录提示信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (this.CheckBox1.Checked)
        //{
            HttpCookie cookie = new HttpCookie("noReminder_"+User.Identity.Name,User.Identity.Name);
            cookie.Expires = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,23,59,59);
            Response.Cookies.Add(cookie);
        //}
        Session["noReminder_" + User.Identity.Name] = User.Identity.Name;

        string js = "window.close();";
        if (!this.Page.ClientScript.IsStartupScriptRegistered("WinClose"))
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),"WinClose",js,true);
        }
    }
}
