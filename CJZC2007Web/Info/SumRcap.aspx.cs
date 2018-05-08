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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;

public partial class Info_SumRcap : System.Web.UI.Page
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
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_RCAP";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("sname", User.Identity.Name));
        
        if (Request.QueryString["time0"] != null && Request.QueryString["time0"] != String.Empty)
        {
            condition.Add(new SearchField("plantime", Request.QueryString["time0"], SearchOperator.大于等于));
        }

        if (Request.QueryString["time1"] != null && Request.QueryString["time1"] != String.Empty)
        {
            condition.Add(new SearchField("plantime", Request.QueryString["time1"], SearchOperator.小于等于));
        }

        DataSet ds1 = comm1.SearchData("*", condition,"plantime");
        comm1.Close();

        this.repeater1.DataSource = ds1;
        this.repeater1.DataBind();
    }
}
