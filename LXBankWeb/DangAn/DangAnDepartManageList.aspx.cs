using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame.DB;
using JSJ.CJZC;
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using System.Data;

public partial class DangAn_DangAnDepartManageList : System.Web.UI.Page
{
    //load data
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    //bind data1
    private void BindData()
    {
        DataSet ds1=DangAnBU.GetAdminList();
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
    }
 
    //delete data
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        DangAnBU.DeleteAdmin(id);
        this.BindData();
    }

    
    //Add data
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAdmin.aspx", true);
    }


    protected override void OnPreRenderComplete(EventArgs e)
    {
        U_RolesBU bu1 = new U_RolesBU();
        bool flag1 = bu1.isRole("档案管理员");
        bu1.Close();
        foreach (GridViewRow row1 in this.GridView1.Rows)
        {
            LinkButton link1 = row1.FindControl("butDelete") as LinkButton;
            if (link1 != null)
            {
                link1.Enabled = flag1;
                link1.ToolTip = "提示：只有档案管理员才能进行删除操作";
            }

            HyperLink hyper1 = row1.FindControl("hyper1") as HyperLink;
            if(hyper1 != null)
            {
                hyper1.Enabled = flag1;
                hyper1.ToolTip = "提示：只有档案管理员才能进行此操作";
            }
        }
        base.OnPreRenderComplete(e);
    }
}
