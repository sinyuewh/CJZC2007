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

public partial class JueCeZhiChi_ZcTcList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
    }

    private void BindData()
    {
        DateTime  dt1 = DateTime.Parse(Request.QueryString["dt1"]);
        DateTime dt2 = DateTime.Parse(Request.QueryString["dt2"]);
        int kind = int.Parse(Request.QueryString["kind"]);
        string zeren = Request.QueryString["zeren"];
        string depart = Request.QueryString["depart"];
        string searchtype = Request.QueryString["searchtype"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = null;
        ds = zc1.GetDCZclist(dt1, dt2, kind, zeren, depart, searchtype);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
}
