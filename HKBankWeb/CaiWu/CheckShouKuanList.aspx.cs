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

public partial class CaiWu_CheckingBill : System.Web.UI.Page
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
        List<SearchField> list1=new List<SearchField>();
        string kind= "0";
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        DataSet ds = shoukuan1.GetBillList(kind, list1, false);
        shoukuan1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (id != "")
        {
            CW_ShouKuanBU sk1 = new CW_ShouKuanBU();
            sk1.DelShoukuanDJ(id);
            sk1.Close();
            this.BindData();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.FindControl("dellinBtn") != null)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("dellinBtn");
            if (PubComm.IsRole("会计")==false)
            {
                link1.Visible = false;
            }
        }
    }
}
