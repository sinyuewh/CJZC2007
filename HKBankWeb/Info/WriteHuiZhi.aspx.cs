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

public partial class Info_WriteHuiZhi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //提交批阅意见
    protected void Button1_Click(object sender, EventArgs e)
    {
        ZX_EmailBu email1 = new ZX_EmailBu();
        string id = Request.QueryString["id"];
        email1.setReplyEmail(id, this.TextBox1.Text);
        email1.Close();
        Response.Write("<br><br><br><br><br><br><center><font size='4'>您的信息已提交，请关闭窗口！<font></center>");
        Response.End();

    }
}
