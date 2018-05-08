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

public partial class NewEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmailID"] != null)
            {
                ZX_EmailBu email1 = new ZX_EmailBu();
                Hashtable ht = email1.GetMailDetailByID(Request.QueryString["EmailID"]);
                if (ht.Count > 0)
                {
                    this.from1.Text = ht["from1"].ToString();
                    this.fromtime.Text = ht["time0"].ToString();
                    this.subject.Text = ht["title"].ToString(); 
                }
                email1.Close();
            }
        }
    }


    //将最新的邮件写入Cookie
    protected void Button1_Click(object sender, EventArgs e)
    {
        Util.setCookie("NewEmailID", Request.QueryString["EmailID"]);
        string js = "window.close();";
        if(!Page.ClientScript.IsStartupScriptRegistered("WinCloseJS"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "WinCloseJS", js,true);
        }

    }
    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
