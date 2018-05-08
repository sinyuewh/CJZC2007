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

public partial class DangAn_JieyueDetail : System.Web.UI.Page
{
    string[] arr0 = new string[] { "bill", "billtime", "billmen", "zeren", "paytime", "paytime1", "remark" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetControlData();
            this.BindFiles(null);
        }
    }
    private void SetControlData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            DA_JieYuanBU jyue1 = new DA_JieYuanBU();
            DataSet ds = jyue1.GetDetailByID(id);
            jyue1.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < arr0.Length; i++)
                {
                    Util.SetControlValue(this.bill.Parent.FindControl(arr0[i]), ds.Tables[0].Rows[0][arr0[i]]);
                }

                if (ds.Tables[0].Rows[0]["paytime1"].ToString() == "")
                {
                    //this.paytime.Text = "";
                    this.paytime1.Text = "";
                }
                else
                {
                    
                    this.paytime1.Text = DateTime.Parse(ds.Tables[0].Rows[0]["paytime1"].ToString()).ToString("yyyy-MM-dd");
                }
                this.paytime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["paytime"].ToString()).ToString("yyyy-MM-dd");
                this.billtime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["billtime"].ToString()).ToString("yyyy-MM-dd");
            }
            ds.Dispose();
        }
    }
    private void BindFiles(DA_JieYuanBU jyue)
    {
        bool flag = false;
        if (jyue == null)
        {
            jyue = new DA_JieYuanBU();
            flag = true;
        }
        DA_JieYuanBU jyue2 = new DA_JieYuanBU();
        DataSet ds1 = jyue2.GetFileList(this.bill.Text.ToString());
        Repeater1.DataSource = ds1;
        Repeater1.DataBind();
        if (flag)
        {
            jyue2.Close();
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("FileJieyue.aspx");
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}
