using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class DangAn_BorrowList : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
        this.GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
        base.OnInit(e);
    }

    //处理数据的绑定
    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            LinkButton link1 = e.Row.FindControl("link1") as LinkButton;
            LinkButton link2 = e.Row.FindControl("link2") as LinkButton;
            if (dr != null && link1!=null && link2!=null)
            {
                String checktime = dr["CheckTime"].ToString();
                if (checktime != String.Empty)   //表示是已审批过的档案列表
                {
                    link1.Visible = false;
                    link2.Visible = false;
                }
                else
                {
                    bool isAdmin = DangAnBU.IsAdminForDAByID(dr["ajnum"].ToString().Trim());
                    if (isAdmin == false)
                    {
                        link2.Visible = false;
                        link1.Visible = false;
                    }
                    else
                    {
                        link2.Visible = true;
                        link1.Visible = true;
                    }
                }
            }
        }
    }

    //处理档案数据的处理
    void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        bool flag=false;
        String do1 = e.CommandName;
        String arg = e.CommandArgument.ToString();
        if (do1 == "agree")
        {
            flag = true;
        }
        DangAnBU.ShenPiDangAn(arg, flag);
        this.BindData();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    //查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindData();

    }
    //绑定数据
    private void BindData()
    {
        int totalRow = 0;
        int curpage = 1;

        if (ViewState["curpage"] != null)
        {
            curpage = (int)ViewState["curpage"];
        }

        DataSet ds1 = this.GetData(curpage, out totalRow);
        if (ds1 != null)
        {

            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();

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
    }

    //翻页处理
    protected void PageNavigator1_onPageChangeEvent(object sender,
        JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData();
    }

    /// <summary>
    /// 档案申请单的查询范围
    /// 1、admin可以查询所有，并可处理所有
    /// 2、可以查询自己申请
    /// 3、可以查询自己负责审批的所有单据
    /// </summary>
    /// <param name="curpage"></param>
    /// <param name="totalRow"></param>
    /// <returns></returns>
    private DataSet GetData(int curpage, out int totalRow)
    {
        return DangAnBU.GetBorrowList(curpage, this.PageNavigator1.PageSize,
            out totalRow, this.ajnum.Text, this.domen.Text);
    }
}
