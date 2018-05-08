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
using System.Collections.Generic;


public partial class CaiWu_EditShouKuan : System.Web.UI.Page
{
    string[] arr1 = new string[] { "bill", "billtime", "danwei", "zeren", "remark", "billmen", "fee1", 
                                   "fee2","fee3","fee4","fee5","fee6","fee7","fee8","fee9","fee10",
                                   "fee11","fee12" };
    string[] arr2 = new string[]{"fee1","fee2","fee3","fee4","fee5","fee6","fee7","fee8","fee9","fee10",
                                   "fee11","fee12"};
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CW_PayBU pay1 = new CW_PayBU();
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


            //会计和出纳和修改单据的信息
            U_RolesBU role1 = new U_RolesBU();
            bool caiwu = role1.isRole(new string[] { "会计", "出纳" });
            role1.Close();

            if (caiwu == false)
            {
                this.Button3.Visible = false;
            }
        }
    }

    //审核单据
    protected void SaveDataClick(object sender, EventArgs e)
    {
        CW_PayBU pay1 = new CW_PayBU();
        bool check1 = pay1.CheckBill(Request.QueryString["id"], User.Identity.Name);
        pay1.Close();

        if (check1)
        {
            Comm.ShowInfo("提示：审核单据成功！", Application["root"] + "/Caiwu/CheckPayList.aspx");
        }
        else
        {
            Comm.ShowInfo("提示：审核单据失败，请重新审核！", Request.RawUrl);
        }
    }

    //更新支持票据
    protected void Button3_Click(object sender, EventArgs e)
    {
        CommTable comm1 = new CommTable("CW_pay");
        Hashtable ht = new Hashtable();
        ht["bill"] = this.bill.Text;
        ht["remark"] = this.remark.Text;
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", Request.QueryString["id"], SearchFieldType.数值型));
        comm1.EditData(condition, ht);
        comm1.Close();

        Util.alert(this.Page, "提示：更新票据信息成功！");
    }
}
