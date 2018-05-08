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
using JSJ.SysFrame;

public partial class XtGL_ModifyPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
        }
    }

    //修改用户的登录密码
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            U_UserNameBU user1 = new U_UserNameBU();
            bool result = user1.ModifyPass(this.pass1.Text, this.pass2.Text);
            user1.Close();
            if (result)
            {
                Util.alert(this.Page, "提示：修改密码成功，新密码下次登录起作用",true);
            }
            else
            {
                Util.alert(this.Page, "提示：修改密码失败，可能的原因是老密码输入不正确");
             }
        }
    }
}
