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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using System.Collections.Generic;

public partial class ZcMng1_EditZcBao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Bind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ZcBaoGL.aspx", false);
    }


    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["Bname"] = this.Bname.Text;
        ht["Bjsf"] = this.Bjsf.Text;
        ht["Bremark"] = this.Bremark.Text;
        ht["Bzeren"] = this.Bzeren.Text;
        ht["Bzeren1"] = this.Bzeren1.Text;
        ht["Bzeren2"] = this.Bzeren2.Text;

        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        if (Request["ID"] != null && ViewState["Bname"].ToString() == this.Bname.Text)
        {
            bool first = zcb1.UpdateZcBaoInfo(Request["ID"].ToString(), ht);
            if (first)
            {
                Util.alert(this.Page, "恭喜您，修改资产包成功！");
            }
            else
            {
                Util.alert(this.Page, "很遗憾，修改资产包失败！");
            }
        }
        else
        {
            bool first = zcb1.UpdateZcBaoInfoTrans(Request["ID"].ToString(), ht);
            if (first)
            {
                Util.alert(this.Page, "恭喜您，修改资产包成功！");
                ViewState["Bname"] = this.Bname.Text;
            }
            else
            {
                Util.alert(this.Page, "很遗憾，修改资产包失败！");
            }
        }
    }


    private void Bind()
    {
        if (Request["ID"] != null)
        {
            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            DataSet ds = zcb1.GetZCBAOInfoByID(Request["ID"].ToString());
            this.Bname.Text = ds.Tables[0].Rows[0]["Bname"].ToString();
            this.Bjsf.Text = ds.Tables[0].Rows[0]["Bjsf"].ToString();
            this.Bzeren.Text = ds.Tables[0].Rows[0]["Bzeren"].ToString();
            this.Bzeren1.Text = ds.Tables[0].Rows[0]["bzeren1"].ToString();
            this.Bzeren2.Text = ds.Tables[0].Rows[0]["bzeren2"].ToString();

            this.Bremark.Text = ds.Tables[0].Rows[0]["Bremark"].ToString();
            ViewState["Bname"] = ds.Tables[0].Rows[0]["Bname"].ToString();
            string ids = zcb1.GetZCIDByBID(Request["ID"].ToString());
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds1 = zc1.GetZCInfoByID(ids);
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();
            zcb1.Close();

        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            zcb1.DelZCFromZcBao(e.CommandArgument.ToString());
            zcb1.Close();
            this.Bind();
        }
    }
}
