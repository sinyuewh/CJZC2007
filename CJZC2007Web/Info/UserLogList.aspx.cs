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
using JSJ.CJZC.Business;

public partial class XtGL_UserLogList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        string time0 = Request.QueryString["dt1"].Trim();
        string time1 = Request.QueryString["dt2"].Trim();
        string depart = Request.QueryString["depart"].Trim();
        string zeren = Request.QueryString["zeren"].Trim();


        XT_UserLogBU logo1 = new XT_UserLogBU();
        this.GridView1.DataSource = logo1.GetUserLogList(time0, time1, depart, zeren);
        this.GridView1.DataBind();
        logo1.Close();
    }


    
}
