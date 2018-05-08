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

public partial class XtGL_EditRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != null)
            {
                U_RolesBU role1 = new U_RolesBU();
                Hashtable ht = role1.GetRoleDetailByID(Request["id"]);
                this.role.Text = ht["role"].ToString();
                this.remark.Text = ht["remark"].ToString();
                role1.SetRoleUsers(this.AllUsers, ht["roleusers"].ToString());
                role1.Close();
            }
            else
            {
                Response.Redirect("~/Error.aspx", true);
            }
        }

    }

    //提交数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("remark", this.remark.Text);
        ht.Add("roleusers", Util.getListControlValue(this.AllUsers));
        if (ht["roleusers"] == null) ht["roleusers"] = String.Empty;
       
        U_RolesBU role1 = new U_RolesBU();
        role1.SaveRoles(Request["id"], ht);
        role1.Close();

        Util.alert(this.Page, "提示：操作成功！");
    }

    //退出返回
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("RolesList.aspx", true);
    }

}
