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
using System.IO;

public partial class ZcMng2_PiYue11 : System.Web.UI.Page
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
        }
    }


    //提交部门审批意见
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["remark"] = this.remark.Text.Trim();
        ht["zeren"] = User.Identity.Name;
        ht["time1"] = DateTime.Now.ToString();
        ht["ps"] = this.piyue.SelectedValue;

        if (ht["ps"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示：请选择一个审批意见!");
        }
        else if (Request["bkind"].ToString() == "0")
        {
            U_ZCSPBU sp1 = new U_ZCSPBU();
            String czid = "";
            string info1 = sp1.PiYueZcForOffice(ViewState["id"].ToString(), ht,out czid);
            sp1.Close();
            Comm.ShowInfo(info1, Application["root"] + "/ZcMng2/ZcDetail3.aspx?id=" + ViewState["zcid"].ToString());
        }
        else
        {
            U_ZCBSPBU sp2 = new U_ZCBSPBU();
            string info2 = sp2.PiYueZcForOffice(ViewState["id"].ToString(), ht, ViewState["zcid"].ToString());
            sp2.Close();
            Comm.ShowInfo(info2, Application["root"] + "/ZcMng2/ZcBaoDetail3.aspx?id=" + ViewState["zcid"].ToString());
        }
    }
}
