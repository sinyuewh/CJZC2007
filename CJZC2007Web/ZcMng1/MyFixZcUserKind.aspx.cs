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
using System.Collections.Generic;
using JSJ.SysFrame.DB;

public partial class ZcMng1_MyFixZcUserKind : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData(null);
        }
        this.AdvanceSearch1.OnMySearchClick += new EventHandler(AdvanceSearch1_OnMySearchClick);
    }

    void AdvanceSearch1_OnMySearchClick(object sender, EventArgs e)
    {
        ZcMng1_AdvanceSearch search1 = sender as ZcMng1_AdvanceSearch;
        if (search1 != null)
        {
            int totalRow = 0;
            int curpage = 1;

            List<SearchField> list1 = search1.SearchConditon;
            list1.Add(new SearchField("zeren", User.Identity.Name, SearchOperator.等于));

            U_ZCBU Zc1 = new U_ZCBU();
            DataSet ds1 = Zc1.GetZcUserkingList(list1, curpage, -1, out totalRow);
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
            ds1.Dispose();
            Zc1.Close();

            this.PageNavigator1.TotalRows = totalRow;
            this.PageNavigator1.CurrentPage = curpage;
        }

    }

    //显示资产数据
    private void BindData(string danwei)
    {
        int totalRow = 0;
        int curpage = 1;
        if (ViewState["curpage"] != null)
        {
            curpage = (int)ViewState["curpage"];
        }

        U_ZCBU Zc1 = new U_ZCBU();
        List<SearchField> list1 = new List<SearchField>();
        if (danwei != null)
        {
            list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
        }

        list1.Add(new SearchField("zeren", User.Identity.Name, SearchOperator.等于));
        DataSet ds1 = Zc1.GetZcUserkingList(list1, curpage, -1, out totalRow);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        ds1.Dispose();
        Zc1.Close();

        this.PageNavigator1.TotalRows = totalRow;
        this.PageNavigator1.CurrentPage = curpage;
    }

    //查询资产数据
    protected void butSearch_Click(object sender, EventArgs e)
    {
        if (this.danwei.Text.Trim() != "")
        {
            this.BindData(this.danwei.Text.Trim());
        }
        else
        {
            this.BindData(null);
        }
    }

    protected void PageNavigator1_onPageChangeEvent(object sender, JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData(this.danwei.Text.Trim());
    }

    //显示和隐藏高级查询的对话框
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.AdvanceRow.Visible = !this.AdvanceRow.Visible;
        if (this.AdvanceRow.Visible == false)
        {
            this.LinkButton1.Text = "显示高级查询>> ";

            if (this.danwei.Text.Trim() != "")
            {
                this.BindData(this.danwei.Text.Trim());
            }
            else
            {
                this.BindData(null);
            }
        }
        else
        {
            this.LinkButton1.Text = "隐藏高级查询>> ";
        }
    }
}
