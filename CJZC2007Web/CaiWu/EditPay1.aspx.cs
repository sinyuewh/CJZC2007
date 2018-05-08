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

public partial class CaiWu_EditPay1 : System.Web.UI.Page
{
    string[] arr1 = new string[] { "bill", "billtime", "bname", "bzeren", "remark", "billmen", "fee1", 
                                   "fee2","fee3","fee4","fee5","fee6","fee7","fee8","fee9","fee10",
                                   "fee11","fee12" };
    string[] arr2 = new string[]{"fee1","fee2","fee3","fee4","fee5","fee6","fee7","fee8","fee9","fee10",
                                   "fee11","fee12"};
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CW_Pay1BU pay1 = new CW_Pay1BU();
            Hashtable ht = pay1.GetObjectByID(Request.QueryString["id"]);
            pay1.Close();

            for (int i = 0; i < arr1.Length; i++)
            {
                Util.SetControlValue(this.bill.Parent.FindControl(arr1[i]), ht[arr1[i]]);
            }
            if (this.billtime.Text != "" && this.billtime.Text != null)
            {
                this.billtime.Text = DateTime.Parse(this.billtime.Text).ToString("yyyy-M-d");
            }

            for (int j = 0; j < arr2.Length; j++)
            {
                Label lab1 = this.bill.Parent.FindControl(arr2[j]) as Label;
                if (lab1 != null)
                {
                    lab1.Text = Comm.GetNumberFormat(lab1.Text);
                }
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
        }
    }
    protected void SaveDataClick(object sender, EventArgs e)
    {
        CW_Pay1BU pay1 = new CW_Pay1BU();
        bool check1 = pay1.CheckBill(Request.QueryString["id"], User.Identity.Name);
        pay1.Close();

        if (check1)
        {
            Comm.ShowInfo("提示：审核单据成功！", Application["root"] + "/Caiwu/CheckPayList1.aspx");
        }
        else
        {
            Comm.ShowInfo("提示：审核单据失败，请重新审核！", Request.RawUrl);
        }
    }
}
