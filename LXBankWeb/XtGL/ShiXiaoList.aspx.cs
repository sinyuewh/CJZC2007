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
using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class XtGL_ShiXiaoList : System.Web.UI.Page
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
        CommTable com1 = new CommTable("U_TimeType");
        List<SearchField> condition = new List<SearchField>();
        DataSet ds1 = com1.SearchData("*", condition, "num");
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        com1.Close();
    }
}
