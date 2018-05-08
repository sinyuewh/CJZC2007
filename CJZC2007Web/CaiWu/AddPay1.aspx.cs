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

public partial class CaiWu_AddPay1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.billtime.Text = DateTime.Now.ToString("yyyy-M-d");
            this.billmen.Text = User.Identity.Name;
            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            DataSet ds = zcb1.GetDetailByID(Request["bid"].ToString(), "Bname,Bzeren");
            zcb1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Util.SetControlValue(bname, ds.Tables[0].Rows[0]["Bname"]);
                Util.SetControlValue(bzeren, ds.Tables[0].Rows[0]["Bzeren"]);

                CW_Pay1BU Pay1 = new CW_Pay1BU();
                this.bill.Text = Pay1.GetBillNum();
                Pay1.Close();
            }
            this.billtime.Attributes["onfocus"] = "setday(this)";
        }
    }
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "bill", "billtime", "bname", "bzeren", "remark", "billmen" ,
                                       "fee1","fee2","fee3","fee4","fee5","fee6","fee7","fee8",
                                       "fee9","fee10","fee11","fee12"};
        for (int i = 0; i < arr1.Length; i++)
        {
            object obj1 = Util.GetControlValue(this.billmen.Parent.FindControl(arr1[i]));
            if (obj1 != null && obj1.ToString().Trim() != "")
            {
                ht.Add(arr1[i], obj1);
            }
        }
        ht.Add("bid", Request.QueryString["bid"]);
        try
        {
            CW_Pay1BU Pay1 = new CW_Pay1BU();
            bool result = Pay1.InsertData(ht);
            Pay1.Close();
            if (result)
            {
                Comm.ShowInfo("【增加支出单据】操作成功!", Application["root"] + "/Caiwu/ZcBaoSearch.aspx");
            }
        }
        catch
        {
            Comm.ShowInfo("【增加支出单据】操作失败，可能的原因是单据编号重复，请重新输入!", Request.RawUrl);
        }
    }
}
