using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame;

using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Data;

public partial class ZcMng1_FixLawGwList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
        this.GridView1.RowDeleting += new GridViewDeleteEventHandler(GridView1_RowDeleting);
        this.Button1.Click += new EventHandler(Button1_Click);
        base.OnInit(e);
    }

    //增加法律顾问的权限
    void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("FixLawGwEdit.aspx", true);
    }

    void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }

    void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String key1 = e.CommandArgument.ToString();
        this.DeleteData(key1);
        this.BindData();
    }

    private void BindData()
    {
        CommTable comm1 = new CommTable("U_LawZC");
        int totalRow = 0;
        DataSet ds1 = comm1.SearchData("*", null, "sname,id desc", -1, -1, out totalRow);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        comm1.Close();
    }

    private void DeleteData(String key)
    {
        CommTable comm1 = new CommTable("U_LawZC");
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", key, SearchFieldType.数值型));
        comm1.DeleteData(condition);
        comm1.Close();
    }
}
