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

public partial class Common_Controls_DangAn : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            U_RolesBU role1=new U_RolesBU();
            bool user = role1.isRole("档案管理员");
            role1.Close();
            if (user == false)
            {
                for (int i = 1; i <= 2; i++)
                {
                    this.AJM1.Parent.FindControl("DAG" + i).Visible = false;
                }
            }
        }
    }
}
