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

public partial class JueCeZhiChi_StatHuiKuanInfoB : System.Web.UI.Page
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
        string time0 = Request.QueryString["dt1"];
        string time1 = Request.QueryString["dt2"];
        string depart = Request.QueryString["depart"];
        string zeren = Request.QueryString["zeren"];
        CW_ShouKuanBU sk1 = new CW_ShouKuanBU();
        DataSet ds1 = sk1.GetShoukuanBillBySearchData(time0, time1, depart, zeren, 0);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();

        DataSet ds2 = sk1.GetShoukuanBillBySearchData(time0, time1, depart, zeren, 1);
        this.GridView2.DataSource = ds2;
        this.GridView2.DataBind();
    }
}
