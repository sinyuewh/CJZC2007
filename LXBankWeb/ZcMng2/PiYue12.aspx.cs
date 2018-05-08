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

public partial class ZcMng2_PiYue12 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["zcid"] = Context.Items["zcid"];
            ViewState["id"] = Context.Items["id"];
            ViewState["kind"] = Context.Items["kind"];
            ViewState["czid"] = Context.Items["czid"];
            ViewState["bkind"] = Request["bkind"];

            this.Button2.Attributes["onclick"] = "javascript:if( confirm('警告：您确定提交审批意见吗？')==false) return false;";
        }
    }

    //办公室主任审批（送审核委员会成员和主席）
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Hashtable ht = new Hashtable();
            ht["remark"] = this.remark.Text.Trim();
            ht["zeren"] = User.Identity.Name;
            ht["time1"] = DateTime.Now.ToString();
            ht["xmsbh"]=this.xmsbh.Text;    //项目申报号；
            ht["czid"] = ViewState["czid"]; //资产处置ID
            ht["ps"] = "同意";

            if (Request["bkind"] == "0")
            {
                U_ZCSPBU sp1 = new U_ZCSPBU();
                string info1 = sp1.PiYueZcForSHWeiYuan(ViewState["id"].ToString(), ht);
                sp1.Close();
                PubComm.ShowInfo(info1, Application["root"] + "/ZcMng2/ZcDetail3.aspx?id=" + ViewState["zcid"].ToString());
            }
            else
            {
                U_ZCBSPBU sp2 = new U_ZCBSPBU();
                string info2 = sp2.PiYueZcForSHWeiYuan(ViewState["id"].ToString(), ht, ViewState["zcid"].ToString());
                sp2.Close();
                PubComm.ShowInfo(info2, Application["root"] + "/ZcMng2/ZcBaoDetail3.aspx?id=" + ViewState["zcid"].ToString());
            }
        }
    }
}
