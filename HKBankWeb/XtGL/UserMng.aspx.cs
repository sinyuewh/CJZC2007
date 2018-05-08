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
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class XtGL_UserMng : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Button2.Click += new EventHandler(Button2_Click);
        this.Button3.Click += new EventHandler(Button3_Click);
        this.Button4.Click += new EventHandler(Button4_Click);
        this.Button5.Click += new EventHandler(Button5_Click);
        this.GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
        this.PageNavigator1.onPageChangeEvent += new JSJ.SysFrame.Controls.MyPageChangeHandler(PageNavigator1_onPageChangeEvent);
        base.OnInit(e);
    }

    //成批更换用户的直接主管
    void Button5_Click(object sender, EventArgs e)
    {
        String sname1 = Request.Form["selDoc"];
        String leader1 = Request.Form["leader"];
        if (String.IsNullOrEmpty(sname1) == false
            && String.IsNullOrEmpty(leader1)==false)
        {
            U_UserNameBU bu1 = new U_UserNameBU();
            bu1.ChangeUserLeader(sname1, leader1);
            this.BindData();
        }
    }

    //更换用户所在的部门
    void Button4_Click(object sender, EventArgs e)
    {
        String sname1 = Request.Form["selDoc"];
        if (String.IsNullOrEmpty(sname1) == false)
        {
            U_UserNameBU bu1 = new U_UserNameBU();
            bu1.ChangeUserDepart(sname1, this.depart.SelectedValue);
            this.BindData();
        }
    }

    protected void PageNavigator1_onPageChangeEvent(object sender, JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData();
    }

    //更新用户的数据状态
    private void SetUserNameStatus(String userNames,String status)
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "U_UserName";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("sname", userNames, SearchOperator.集合));
        Hashtable ht1 = new Hashtable();
        if (String.IsNullOrEmpty(status) == false)
        {
            ht1.Add("lockflag", "1");
        }
        else
        {
            ht1.Add("lockflag", DBNull.Value);
        }
        comm1.EditQuickData(condition, ht1);
        comm1.Close();
    }

    //调整数据的显示
    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr=dv.Row;
            Label lab1 = e.Row.FindControl("lab1") as Label;
            if (lab1 != null && dr["lockflag"].ToString().Trim()!=String.Empty)
            {
                lab1.Text = "[已停]";
                lab1.ForeColor = System.Drawing.Color.Blue;
            }
        }
    }

    //启用用户
    void Button3_Click(object sender, EventArgs e)
    {
        String sname1 = Request.Form["selDoc"];
        if (String.IsNullOrEmpty(sname1) == false)
        {
            this.SetUserNameStatus(sname1, String.Empty);
            this.BindData();
        }
    }

    //停用用户
    void Button2_Click(object sender, EventArgs e)
    {
        String sname1 = Request.Form["selDoc"];
        if (String.IsNullOrEmpty(sname1) == false)
        {
            this.SetUserNameStatus(sname1, "1");
            this.BindData();
        }
    }

       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_DepartBU depart1 = new U_DepartBU();
            depart1.SetDepartList(this.depart, null);
            this.BindData();
        }
    }

    //绑定数据1
    private void BindData()
    {
        U_UserNameBU user1 = new U_UserNameBU();

        int totalRow = 0;
        int curpage = 1;
        if (ViewState["curpage"] != null)
        {
            curpage = (int)ViewState["curpage"];
        }

        DataSet ds1 = user1.GetAllUserList(curpage,this.status1.SelectedValue,this.PageNavigator1.PageSize,out totalRow);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        user1.Close();

        this.PageNavigator1.TotalRows = totalRow;
        this.PageNavigator1.CurrentPage = curpage;

        if (ds1.Tables[0].Rows.Count == 0 && curpage > 1)
        {
            ViewState["curpage"] = curpage - 1;
            this.BindData();
        }

        if (totalRow == 0)
        {
            this.PageNavigator1.Visible = false;
        }
    }

    //绑定数据2
    private void BindData(U_UserNameBU user1)
    {
        this.GridView1.DataSource = user1.GetAllUserList();
        this.GridView1.DataBind();
    }

    //删除数据
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        U_UserNameBU user1 = new U_UserNameBU();
        user1.DeleteUser(id);
        this.BindData(user1);
        user1.Close();
    }

    //增加数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUser.aspx", true);
    }
    protected void button11_Click(object sender, EventArgs e)
    {
        this.BindData();
    }
}
