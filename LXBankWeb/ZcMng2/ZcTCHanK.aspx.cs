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

public partial class ZcMng2_ZcTCHanK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items["id"] != null)
            {
                U_ZCTCBU tc1 = new U_ZCTCBU();
                DataSet ds = tc1.GetDetailByID(Context.Items["id"].ToString());
                tc1.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["id"] = Context.Items["id"];
                    ViewState["kind"] = ds.Tables[0].Rows[0]["kind"].ToString();
                    ViewState["parentid"] = ds.Tables[0].Rows[0]["zcid"].ToString();
                    ViewState["Bkind"] = ds.Tables[0].Rows[0]["Bkind"].ToString();

                    Util.SetControlValue(remark, ds.Tables[0].Rows[0]["remark"]);
                    Util.SetControlValue(remark1, ds.Tables[0].Rows[0]["remark1"]);
                    Util.SetControlValue(didian, ds.Tables[0].Rows[0]["didian"]);
                    Util.SetControlValue(jieguo, ds.Tables[0].Rows[0]["jieguo"]);
                }
            }
            else
            {
                ViewState["kind"] = Context.Items["kind"].ToString();
                ViewState["parentid"] = Context.Items["parentid"].ToString();
                ViewState["Bkind"] = Context.Items["Bkind"].ToString();

                this.didian.Text = Page.User.Identity.Name;
                this.jieguo.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            ////////////////////////////////////////////////////////////
            string kind = ViewState["kind"].ToString();
            switch (kind)
            {
                case "01":
                    this.dckind.Text = "尽职调查－非现场调查（档案核查）";
                    this.Title = "尽职调查－非现场调查（档案核查）";
                    break;
                case "02":
                    this.dckind.Text = "尽职调查－现场调查（抵质押物）";
                    this.Title = "尽职调查－现场调查（抵质押物）";
                    break;
                case "03":
                    this.dckind.Text = "尽职调查－现场调查（保证人）";
                    this.Title = "尽职调查－现场调查（保证人）";
                    break;
                case "04":
                    this.dckind.Text = "尽职调查－现场调查（借款人）";
                    this.Title = "尽职调查－现场调查（借款人）";
                    break;
                
                default:
                    this.dckind.Text = "尽职调查－非现场调查（档案核查）";
                    this.Title = "尽职调查－非现场调查（档案核查）";
                    break;
            }
        }
    }

    //Save Data
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Hashtable ht = new Hashtable();
            ht["kind"] = ViewState["kind"].ToString();
            ht["zcid"] = ViewState["parentid"].ToString();
            ht["bkind"] = ViewState["Bkind"].ToString();
            ht["zeren"] = User.Identity.Name;
            ht["remark"] = this.remark.Text;
            ht["didian"] = didian.Text;
            ht["jieguo"] = jieguo.Text;
            ht["remark1"] = this.remark1.Text;

            U_ZCTCBU tc1 = new U_ZCTCBU();
            if (ViewState["id"] == null)
            {
                tc1.InsertData(ht);     //Add a data
            }
            else
            {
                tc1.EditTc(ViewState["id"].ToString(), ht); //Edit tc
            }
            tc1.Close();
            if (ViewState["Bkind"].ToString() == "0")
            {
                if (Int32.Parse(ViewState["kind"].ToString()) >= 20)
                {
                    Response.Redirect("ZcDetail4.aspx?id=" + ViewState["parentid"].ToString(), true);
                }
                else
                {
                    Response.Redirect("ZcDetail2.aspx?id=" + ViewState["parentid"].ToString(), true);
                }
            }
            else
            {
                if (Int32.Parse(ViewState["kind"].ToString()) >= 20)
                {
                    Response.Redirect("ZcBaoDetail4.aspx?id=" + ViewState["parentid"].ToString(), true);
                }
                else
                {
                    Response.Redirect("ZcBaoDetail2.aspx?id=" + ViewState["parentid"].ToString(), true);
                }
            }
        }
    }
}
