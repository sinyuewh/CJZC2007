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

public partial class ZcMng2_AddZcTc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items["id"] != null)
            {
                U_ZCTCBU tc1 = new U_ZCTCBU();
                DataSet ds=tc1.GetDetailByID(Context.Items["id"].ToString());
                tc1.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["id"] = Context.Items["id"];
                    ViewState["kind"] = ds.Tables[0].Rows[0]["kind"].ToString();
                    ViewState["parentid"] = ds.Tables[0].Rows[0]["zcid"].ToString();
                    ViewState["Bkind"] = ds.Tables[0].Rows[0]["Bkind"].ToString();

                    Util.SetControlValue(remark, ds.Tables[0].Rows[0]["remark"]);
                    Util.SetControlValue(didian, ds.Tables[0].Rows[0]["didian"]);
                    Util.SetControlValue(jieguo, ds.Tables[0].Rows[0]["jieguo"]);
                }
            }
            else
            {
                ViewState["kind"] = Context.Items["kind"].ToString();
                ViewState["parentid"] = Context.Items["parentid"].ToString();
                ViewState["Bkind"] = Context.Items["Bkind"].ToString();
            }

            ////////////////////////////////////////////////////////////
            string kind=ViewState["kind"].ToString();
            switch (kind)
            {
                case "01":
                    this.dckind.Text = "尽职调查－阅卷记录";
                    this.Title = "尽职调查－阅卷记录";
                    break;
                case "02":
                    this.dckind.Text = "尽职调查－下户记录";
                    this.Title = "尽职调查－下户记录";
                    break;
                case "03":
                    this.dckind.Text = "尽职调查－取证记录";
                    this.Title = "尽职调查－取证记录";
                    break;
                case "04":
                    this.dckind.Text = "尽职调查－报告记录";
                    this.Title = "尽职调查－报告记录";
                    break;
                case "21":
                    this.dckind.Text = "方案执行－协商谈判";
                    this.Title = "方案执行－协商谈判";
                    break;
                case "22":
                    this.dckind.Text = "方案执行－诉讼";
                    this.Title = "方案执行－诉讼";
                    break;
                case "23":
                    this.dckind.Text = "方案执行－申请执行";
                    this.Title = "方案执行－申请执行";
                    break;
                case "24":
                    this.dckind.Text = "方案执行－强制执行";
                    this.Title = "方案执行－强制执行";
                    break;
                case "25":
                    this.dckind.Text = "方案执行－中止执行";
                    this.Title = "方案执行－中止执行";
                    break;
                case "26":
                    this.dckind.Text = "方案执行－终止执行";
                    this.Title = "方案执行－终止执行";
                    break;
                case "27":
                    this.dckind.Text = "方案执行－办结";
                    this.Title = "方案执行－办结";
                    break;
                default:
                    this.dckind.Text = "尽职调查－阅卷记录";
                    this.Title = "尽职调查－阅卷记录";
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
