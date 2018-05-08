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

using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;

public partial class DangAn_DangAnIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            if (HttpContext.Current.Items["SearchCondition1"] != null)
            {
                ViewState["SearchCondition1"] = HttpContext.Current.Items["SearchCondition1"];
                ViewState["SearchKind"] = HttpContext.Current.Items["SearchKind"];
                this.BindData1();
            }
            else
            {
                ViewState["SearchCondition2"] = HttpContext.Current.Items["SearchCondition2"];
                ViewState["SearchKind"] = HttpContext.Current.Items["SearchKind"];
                this.BindData2();
            }
        }
    }
    private void BindData1()
    { 
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition1"];
        DA_AnJuanBU anjuan1 = new DA_AnJuanBU();
        this.GridView1.DataSource = anjuan1.GetSearchResult(list1);
        this.GridView1.DataBind();
        anjuan1.Close();
    }
    private void BindData2()
    {
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition2"];
        DA_AnJuanBU anjuan2 = new DA_AnJuanBU();
        this.GridView1.DataSource = anjuan2.GetSearchResult_file(list1);
        this.GridView1.DataBind();
        anjuan2.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DA_AnJuanBU anjuan3 = new DA_AnJuanBU();
        if (e.Row.DataItem != null)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            bool result = anjuan3.IsOrNotYiJiao(dr["id"].ToString());
            if (result)
            {
                ((Label)e.Row.FindControl("ajstatus")).Text = "已移交";
            }
            else
            {
                ((Label)e.Row.FindControl("ajstatus")).Visible = false;
            }
        }
    }
}
