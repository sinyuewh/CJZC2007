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
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;

public partial class Info_WriteMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.to1.Text = Server.UrlDecode(Request.QueryString["tousers"]);
            this.Title = "发送短信息给"+this.to1.Text;
        }
    }

    //发送消息
    protected void Button1_Click(object sender, EventArgs e)
    {
        CommTable com1 = null;
        Hashtable ht = new Hashtable();
        com1 = new CommTable();
        com1.TabName = "ZX_QuickTalk";
        ht["fmen"] = User.Identity.Name;
        ht["tmen"] = this.to1.Text;
        ht["remark"] = this.remark.Text;
        ht["time0"] = DateTime.Now.ToString();
        ht["isread"] = "0";
        com1.InsertData(ht);

        Response.Write("<b><center>发送信息成功，请关闭窗口！</center></b>");
        Response.End();
            
    }
}
