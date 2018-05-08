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
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;

public partial class JueCeZhiChi_SXSearchResult : System.Web.UI.Page
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
                Response.Redirect("~/JueCeZhiCHi/StatBySX.aspx", true);
            }
        }
    }
    private void BindData()
    { 
        List<SearchField> list1=(List<SearchField>)ViewState["SearchCondition"];
        U_ZCTimeBU zc1 = new U_ZCTimeBU();
        TableRow row1 = new TableRow();
        TableCell cell1 = new TableCell();
        string[] arr1 = new string[] { "诉讼时效", "保证时效", "抵押时效", "执行时效" };
        for (int i = 0; i < arr1.Length; i++)
        {
            DataSet ds1 = zc1.GetSXList1(list1, arr1[i]);
            if (ds1.Tables[0].Rows.Count > 0)
            {
               
            }
        }
        
    }
}
