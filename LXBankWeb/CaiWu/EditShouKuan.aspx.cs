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
    string[] arr1 = new string[] { "bill", "billtime", "danwei", "zeren", "pbj", "plx", "remark", "billmen" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
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
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        bool check1 = shoukuan1.CheckBill(Request.QueryString["id"], User.Identity.Name);
        shoukuan1.Close();
        if (check1)
        {
            PubComm.ShowInfo("提示：审核单据成功！", Application["root"] + "/Caiwu/CheckShouKuanList.aspx");
        }
        else
        {
            PubComm.ShowInfo("提示：审核单据失败，请重新审核！", Request.RawUrl);
        }
    }

    //更新票据的信息
    protected void Button3_Click(object sender, EventArgs e)
    {
        CommTable comm1 = new CommTable("CW_ShouKuan");
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
