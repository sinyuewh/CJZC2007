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

public partial class XtGL_SeeRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != null)
            {
                U_RolesBU role1 = new U_RolesBU();
                Hashtable ht = role1.GetRoleDetailByID(Request["id"]);
                this.TextBox1.Text = ht["roleusers"].ToString();
               
                role1.Close();
            }
            
        }
    }
}
