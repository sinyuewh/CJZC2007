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

public partial class Common_Controls_SystemAdmin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //防止用户直接输入网页的权限设置
            //string currentuser = Page.User.Identity.Name;
            //U_RolesBU role1 = new U_RolesBU();
            //bool check1=role1.isRole(currentuser, "系统管理员");
            //role1.Close();
            //if (check1==false)
            //{
            //    Response.Redirect("~/Error.aspx?info=NoAccess",true);
            //}
        }
    }
}
