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

public partial class DangAn_PayInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            this.paytim1.Attributes["onfocus"] = "javascript:setday(this);";
        }
    }
    protected void BindData()
    {
        if (Request.QueryString["id"] != null)
        {
            DA_JieYuanBU jyue1 = new DA_JieYuanBU();
            DataSet ds = jyue1.GetDetailByID(Request.QueryString["id"]);
            jyue1.Close();
            this.bill.Text = ds.Tables[0].Rows[0]["bill"].ToString();
            this.paytime.Text =DateTime.Parse( ds.Tables[0].Rows[0]["paytime"].ToString()).ToString("yyyy-MM-dd");
            this.paytim1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    //返回借阅单列表
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("FileJieyue.aspx");
    }
    //归还借阅文件
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht=new Hashtable();
        ht.Add("paytime1",this.paytim1.Text.ToString());
        ht.Add("status", "2");
        DA_JieYuanBU jyue1 = new DA_JieYuanBU();
        jyue1.UpdatePaytime(Request.QueryString["id"], ht);
        Hashtable ht1=new Hashtable();
        ht1.Add("jyue",DBNull.Value);
        ht1.Add("jyuetime",DBNull.Value);
        ht1.Add("djtime",DBNull.Value);
        ht1.Add("dtmen",DBNull.Value);
        string[] allId = jyue1.GetAllIdBybill(this.bill.Text);
        for (int i = 0; i < allId.Length; i++)
        {
            DA_FilesBU file1 = new DA_FilesBU();
            file1.RemoveJieyueInfo(allId[i].ToString(), ht1);
        }

        Response.Redirect("FileJieyue.aspx");

    }
}
