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

public partial class XtGL_XtGlIndex : System.Web.UI.Page
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
        U_DepartBU depart1 = new U_DepartBU();
        this.GridView1.DataSource = depart1.GetAllDepart();
        this.GridView1.DataBind();
        depart1.Close();
    }

    //bind data2
    private void BindData(U_DepartBU depart1)
    {
        this.GridView1.DataSource = depart1.GetAllDepart();
        this.GridView1.DataBind();
    }

    //delete data
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        U_DepartBU depart1 = new U_DepartBU();
        depart1.DeleteData(id);
        this.BindData(depart1);
        depart1.Close();
    }

    //edit data
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        this.BindData();
    }

    //cancel edit
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.GridView1.EditIndex = -1;
        this.BindData();
    }

    //update data
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        Hashtable ht = new Hashtable();
        string[] Arr1 = new string[] { "num", "depart", "remark" };
        for (int i = 0; i < Arr1.Length; i++)
        {
            ht.Add(Arr1[i],Util.GetControlValue(this.GridView1.Rows[e.RowIndex].Cells[i].Controls[0]));
        }

        if (ht["num"].ToString().Trim() == "" || ht["depart"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示：部门编号和部门名称不能为空！");
        }
        else
        {
            U_DepartBU depart1 = new U_DepartBU();
            bool result=depart1.UpdataData(id, ht);
            depart1.Close();

            if (result)
            {
                this.GridView1.EditIndex = -1;
                this.BindData(depart1);
            }
            else
            {
                Util.alert(this.Page, "错误提示：部门名称【" + ht["depart"].ToString() + "】已经存在！");
            }
        }

    }

    //Add data
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddDepart.aspx", true);
    }

}
