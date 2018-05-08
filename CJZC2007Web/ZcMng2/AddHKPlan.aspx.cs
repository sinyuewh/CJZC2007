using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;

public partial class ZcMng1_AddHKPlan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.time0.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.pbj.Text = "0";
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Button1.Click += new EventHandler(Button1_Click);
        base.OnInit(e);
    }

    void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            CommTable com1 = new CommTable("CW_ShouKuanPlan");
            Hashtable ht1 = new Hashtable();
            if (String.IsNullOrEmpty(Request.QueryString["zcid"]) == false)
            {
                ht1["zcid"] = Request.QueryString["zcid"];
            }
            ht1["kind"] = Request.QueryString["kind"];
            ht1["pbj"] = double.Parse(this.pbj.Text);
            ht1["plx"] = "0";
            ht1["time0"] = DateTime.Parse(this.time0.Text).ToString("yyyy-MM-dd");
            ht1["remark"] = this.remark.Text;
            com1.InsertData(ht1);
            com1.Close();

            if (Request.QueryString["kind"] == "0")
            {
                Response.Redirect("ZcDetail5.aspx?id=" + Request.QueryString["zcid"], true);
            }
            else
            {
               Response.Redirect("ZcBaoDetail5.aspx?id=" + Request.QueryString["zcid"], true);
            }
        }
        catch (Exception err)
        {
            JSJ.SysFrame.Util.alert(this.Page, "错误：数据类型输入有错，请检查！");
        }
    }
}
