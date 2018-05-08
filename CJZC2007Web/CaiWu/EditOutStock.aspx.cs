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
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;

public partial class CaiWu_EditShouKuan : System.Web.UI.Page
{
    string[] arr1 = new string[] { "bill", "billtime", "danwei", "zeren", "remark", "billmen" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           this.BindData();
        }
    }

    private void BindData()
    {
        CW_OutStockBU out1 = new CW_OutStockBU();
        Hashtable ht = out1.GetObjectByID(Request.QueryString["id"]);
      

        for (int i = 0; i < arr1.Length; i++)
        {
            Util.SetControlValue(this.bill.Parent.FindControl(arr1[i]), ht[arr1[i]]);
        }
        if (this.billtime.Text != "" && this.billtime.Text != null)
        {
            this.billtime.Text = DateTime.Parse(this.billtime.Text).ToString("yyyy-M-d");
        }
        if (ht["checktime"] != DBNull.Value)
        {
            this.Button1.Visible = false;
            this.Button2.Attributes["onclick"] = "history.go(-1);return false;";
        }
        else
        {
            this.Button2.Attributes["onclick"] = "top.location.href='CheckShouKuanList.aspx';return false;";
        }

        ///////////////////////////////////////////
        this.Repeater1.DataSource = out1.GetOutStockBill(this.bill.Text);
        this.Repeater1.DataBind();

        out1.Close();
    }

    //审核出库单
    protected void SaveDataClick(object sender, EventArgs e)
    {
        CW_OutStockBU out1 = new CW_OutStockBU();
        bool check1 = out1.CheckBill(Request.QueryString["id"], User.Identity.Name);
        out1.Close();

        if (check1)
        {
            Comm.ShowInfo("提示：审核单据成功！", Application["root"] + "/Caiwu/CheckOutStockList.aspx");
        }
        else
        {
            Comm.ShowInfo("提示：审核单据失败，请重新审核！", Request.RawUrl);
        }
    }
}
