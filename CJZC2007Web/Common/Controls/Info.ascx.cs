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

public partial class Common_Controls_Info : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_RolesBU role1 = new U_RolesBU();
            bool check1 = role1.isRole("系统管理员");
            bool check2 = role1.isRole("资讯管理员");
            role1.Close();
            if (check1 || check2)
            {
                this.ZX_menu1.Visible = true;
                this.ZX_menu0.Visible = true;
            }
            else
            {
                this.ZX_menu1.Visible = false;
                this.ZX_menu0.Visible = false;
            }
        }
    }
}
