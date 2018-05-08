using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class CaiWu_SearchResult : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            if (HttpContext.Current.Items["SearchCondition"] != null)
            {
                ViewState["SearchCondition"] = HttpContext.Current.Items["SearchCondition"];
                ViewState["SearchKind"] = HttpContext.Current.Items["SearchKind"];
                this.BindData();
            }
            else
            {
                Response.Redirect("CaiwuIndex.aspx", true);
            }
        }
    }


    private void BindData()
    {
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetSearchResult(list1);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        zc1.Close();
        ds1.Dispose();
    }
}
