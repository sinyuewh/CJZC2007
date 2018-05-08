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

public partial class DangAn_ShowPrintDetail : System.Web.UI.Page
{
    string[] arr0 = new string[] { "bill", "billtime", "billmen", "zeren", "remark" };
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
            DA_CopyBU print1 = new DA_CopyBU();
            DataSet ds = print1.GetDetailByID(id);
            print1.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < arr0.Length; i++)
                {
                    Util.SetControlValue(this.bill.Parent.FindControl(arr0[i]), ds.Tables[0].Rows[0][arr0[i]]);
                }

                this.billtime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["billtime"].ToString()).ToString("yyyy-MM-dd");
            }
            ds.Dispose();
        }
    }
    private void BindFiles(DA_CopyBU print)
    {
        bool flag = false;
        if (print == null)
        {
            print = new DA_CopyBU();
            flag = true;
        }
        DA_CopyBU print1 = new DA_CopyBU();
        DataSet ds1 = print1.GetFileList(this.bill.Text.ToString());
        Repeater1.DataSource = ds1;
        Repeater1.DataBind();
        if (flag)
        {
            print1.Close();
        }
    }
    //返回
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Print.aspx");
    }
}
