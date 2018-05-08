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

public partial class Common_Controls_footer : System.Web.UI.UserControl
{
    public String ParentUrl
    {
        get
        {
            String url1 = ConfigurationManager.AppSettings["parenturl"];
            return url1;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DataBind();
            Page.Title = Page.Title + "（联想不良资产包）";
        }
    }


    protected void budRelogin_Click(object sender, EventArgs e)
    {
        Hashtable ht = (Hashtable)Application["OnLineUser"];
        ht.Remove(Page.User.Identity.Name.Trim());

        XT_UserLogBU user1 = new XT_UserLogBU();
        user1.SignOutLogo(Page.User.Identity.Name);
        user1.Close();

        FormsAuthentication.SignOut();

        //返回父系统登录主页
        String url1 = ConfigurationManager.AppSettings["parenturl"];
        //url1 = url1 + Server.UrlDecode(this.username.Text);
        Response.Redirect(url1, true);

        //Response.Redirect("~/login.aspx", true);
    }
    protected void butExit_Click(object sender, EventArgs e)
    {
        //Hashtable ht = (Hashtable)Application["OnLineUser"];
        //ht.Remove(Page.User.Identity.Name.Trim());

        //XT_UserLogBU user1 = new XT_UserLogBU();
        //user1.SignOutLogo(Page.User.Identity.Name);
        //user1.Close();

       // FormsAuthentication.SignOut();

       // Response.Redirect("~/login.aspx?loginout=1", true);

        String url1 = ConfigurationManager.AppSettings["parenturl"];
        //url1 = url1 + Server.UrlDecode(this.username.Text);
        Response.Redirect(url1, true);
    }
}
