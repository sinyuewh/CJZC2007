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

public partial class DangAn_FileJieyue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData1(null);
            //this.BindData();
        }
    }
    private void BindData1(string zeren)
    {
        DA_JieYuanBU jyue1 = new DA_JieYuanBU();
        DataSet ds = jyue1.GetJieyueList1(zeren);
        //DataSet ds = jyue1.GetJieyueList();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        jyue1.Close();
    }
    private void BindData2(DA_JieYuanBU jyue1)
    {
        this.GridView1.DataSource = jyue1.GetAllBill();
        this.GridView1.DataBind();
    }
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData1(this.zeren.Text.Trim());
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DA_JieYuanBU jyue2 = new DA_JieYuanBU();
        //if (e.Row.DataItem != null)
        //{
        //    DataRow dr = ((DataRowView)e.Row.DataItem).Row;
        //    bool result= jyue2.PuDuanStatus(dr["id"].ToString());
        //    //HyperLink link1 = (HyperLink)e.Row.FindControl("HyperLink1");
        //    if(result)
        //    {
        //        ((Label)e.Row.FindControl("status")).Text = "已确定";
        //        //link1.Visible = false; 
        //    }
        //}
        DA_JieYuanBU jyue2 = new DA_JieYuanBU();
        if (e.Row.DataItem != null)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            string status = jyue2.PuDuanStatus1(dr["id"].ToString());
            LinkButton link1 = (LinkButton)e.Row.FindControl("LinkbutEdit");
            LinkButton link2 = (LinkButton)e.Row.FindControl("Delbut");
            LinkButton link3 = (LinkButton)e.Row.FindControl("paybut");
            if (status == "1")
            {
                ((Label)e.Row.FindControl("status")).Text = "已确定";
                link1.Visible = false;
                link2.Visible = false; 
            }
            else if (status =="")
            {
                ((Label)e.Row.FindControl("status")).Text = "新单据";
                link2.Visible = true;
                link1.Visible = true;
                link3.Visible = false;
            }
            if (status == "2")
            {
                ((Label)e.Row.FindControl("status")).Text = "已归还";
                link1.Visible = false;
                link2.Visible = true;
                link3.Visible = false;
            }
        }
    }
    //删除一条数据
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        DA_JieYuanBU jyue3 = new DA_JieYuanBU();
        string bill = jyue3.GetbillById(id);
        jyue3.DeleteData(bill,id);
        this.BindData2(jyue3);
        jyue3.Close();
    }
    //归还借阅文件
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //DA_JieYuanBU jyue4 = new DA_JieYuanBU();
        //jyue4.UpdatePaytime();
    }
}
