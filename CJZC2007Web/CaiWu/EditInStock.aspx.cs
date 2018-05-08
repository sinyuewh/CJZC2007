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
        CW_InStockBU instock1 = new CW_InStockBU();
        Hashtable ht = instock1.GetObjectByID(Request.QueryString["id"]);
        for (int i = 0; i < arr1.Length; i++)
        {
            Util.SetControlValue(this.bill.Parent.FindControl(arr1[i]), ht[arr1[i]]);
        }
       
        //调整票据时间显示
        if (this.billtime.Text != "" && this.billtime.Text != null)
        {
            this.billtime.Text = DateTime.Parse(this.billtime.Text).ToString("yyyy-M-d");
        }
        string bill = this.bill.Text;
        DataSet ds1 = instock1.GetInStockBill(bill);
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();

        instock1.Close();
        if (ht["checktime"] != DBNull.Value)
        {
            this.Button1.Visible = false;
            this.Button2.Attributes["onclick"] = "history.go(-1);return false;";
        }
        else
        {
            this.Button2.Attributes["onclick"] = "top.location.href='CheckShouKuanList.aspx';return false;";
        }
    }

    //审核入库单
    protected void SaveDataClick(object sender, EventArgs e)
    {
        CW_InStockBU instock1 = new CW_InStockBU();
        bool check1 = instock1.CheckBill(Request.QueryString["id"], User.Identity.Name);
        instock1.Close();

        if (check1)
        {
            Comm.ShowInfo("提示：审核单据成功！", Application["root"] + "/Caiwu/CheckInStockList.aspx");
        }
        else
        {
            Comm.ShowInfo("提示：审核单据失败，请重新审核！", Request.RawUrl);
        }
    }
}
