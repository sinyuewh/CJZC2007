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

public partial class CaiWu_EditShouKuan1 : System.Web.UI.Page
{
    string[] arr1 = new string[] { "bill", "billtime", "bname", "bzeren", "pbj", "plx", "remark", "billmen" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CW_ShouKuan1BU shoukuan1 = new CW_ShouKuan1BU();
            Hashtable ht = shoukuan1.GetObjectByID(Request.QueryString["id"]);
            for (int i = 0; i < arr1.Length; i++)
            {
                Util.SetControlValue(this.bill.Parent.FindControl(arr1[i]), ht[arr1[i]]);
            }
            if (this.billtime.Text != "" && this.billtime.Text != null)
            {
                this.billtime.Text = DateTime.Parse(this.billtime.Text).ToString("yyyy-M-d");
            }
            this.pbj.Text = PubComm.GetNumberFormat(this.pbj.Text);
            this.plx.Text = PubComm.GetNumberFormat(this.plx.Text);
            shoukuan1.Close();
            if (ht["checktime"] != DBNull.Value)
            {
                this.Button1.Visible = false;
                this.Button2.Attributes["onclick"] = "history.go(-1);return false;";
            }
            else
            {
                this.Button2.Attributes["onclick"] = "top.location.href='CheckShouKuanList1.aspx';return false;";
            }

        }
    }
    protected void SaveDataClick(object sender, EventArgs e)
    {
        CW_ShouKuan1BU shoukuan1 = new CW_ShouKuan1BU();
        bool check1 = shoukuan1.CheckBill(Request.QueryString["id"], User.Identity.Name);
        shoukuan1.Close();
        if (check1)
        {
            PubComm.ShowInfo("提示：审核单据成功！", Application["root"] + "/Caiwu/CheckShouKuanList1.aspx");
        }
        else
        {
            PubComm.ShowInfo("提示：审核单据失败，请重新审核！", Request.RawUrl);
        }
    }
}
