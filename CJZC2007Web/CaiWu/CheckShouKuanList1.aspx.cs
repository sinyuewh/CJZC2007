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

public partial class CaiWu_CheckShouKuanList1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ChangeData();
            this.BindData();
        }
    }

    private void ChangeData()
    {
        CommTable com1 = new CommTable();
        com1.TabName = "CW_ShouKuan1";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("Bzeren is null", "", SearchOperator.用户定义));
        condition.Add(new SearchField("checktime is null", "", SearchOperator.用户定义));
        com1.DeleteData(condition);
        com1.Close();
    }

    private void BindData()
    {
        List<SearchField> list1 = new List<SearchField>();
        string kind = "0";
        CW_ShouKuan1BU shoukuan1 = new CW_ShouKuan1BU();
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
            CW_ShouKuan1BU sk1 = new CW_ShouKuan1BU();
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
            if (Comm.IsRole("会计") == false)
            {
                link1.Visible = false;
            }
        }
    }
}
