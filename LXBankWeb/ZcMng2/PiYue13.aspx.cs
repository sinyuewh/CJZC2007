using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using System.IO;

public partial class ZcMng2_PiYue13 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items["zhuxi"] != null && Context.Items["zhuxi"].ToString() == "1")
            {
                this.piyue.Items.Remove("同意");
            }
            else
            {
                this.piyue.Items.Remove("送决策委员会");
            }
            ViewState["zcid"] = Context.Items["zcid"];
            ViewState["id"] = Context.Items["id"];
            ViewState["kind"] = Context.Items["kind"];
            ViewState["bkind"] = Request["bkind"];
            this.Button2.Attributes["onclick"] = "javascript:if( confirm('警告：您确定提交审批意见吗？')==false) return false;";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Hashtable ht = new Hashtable();
            ht["remark"] = this.remark.Text.Trim();
            ht["zeren"] = User.Identity.Name;
            ht["time1"] = DateTime.Now.ToString();
            ht["ps"] = this.piyue.SelectedValue;

            if (Request["bkind"].ToString() == "0")
            {
                U_ZCSPBU sp1 = new U_ZCSPBU();
                string info1 = sp1.PiYueZcForSH1(ViewState["id"].ToString(), ht);
                sp1.Close();
                PubComm.ShowInfo(info1, Application["root"] + "/ZcMng2/ZcDetail3.aspx?id=" + ViewState["zcid"].ToString());
            }
            else
            {
                U_ZCBSPBU sp2 = new U_ZCBSPBU();
                string info2 = sp2.PiYueZcForSH1(ViewState["id"].ToString(), ht, ViewState["zcid"].ToString());
                sp2.Close();
                PubComm.ShowInfo(info2, Application["root"] + "/ZcMng2/ZcBaoDetail3.aspx?id=" + ViewState["zcid"].ToString());
            }
        } 
    }

}
