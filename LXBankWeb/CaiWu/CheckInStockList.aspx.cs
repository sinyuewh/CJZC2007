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
        string kind= "2";
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        DataSet ds = shoukuan1.GetBillList(kind, list1, false);
        shoukuan1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string bill = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (bill != "")
        {
            CW_InStockBU is1 = new CW_InStockBU();
            is1.DelInStockDJ(bill);
            is1.Close();
            this.BindData();
        }
    }
}
