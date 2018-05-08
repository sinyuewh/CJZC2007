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

public partial class DangAn_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData1(null);
        }
    }
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData1(this.zeren.Text.Trim());
    }
    private void BindData1(string zeren)
    {
        DA_CopyBU print1 = new DA_CopyBU();
        DataSet ds = print1.GetPrintList1(zeren);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        print1.Close();
        ds.Dispose();
    }
    private void BindData2(DA_CopyBU print1)
    {
        this.GridView1.DataSource = print1.GetAllBill();
        this.GridView1.DataBind();
    }


    //删除数据

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
       DA_CopyBU copy1 = new DA_CopyBU();
       copy1.DelCopyData(id);
       this.BindData2(copy1);
       copy1.Close();
       
    }
}
