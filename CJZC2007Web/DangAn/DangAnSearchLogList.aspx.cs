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

public partial class DangAn_DangAnSearchLogList : System.Web.UI.Page
{
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
        DataSet ds1 = this.GetData(curpage,out totalRow);
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
    
    //翻页处理
    protected void PageNavigator1_onPageChangeEvent(object sender, 
        JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData();
    }

    private DataSet GetData(int curpage,out int totalRow)
    {
        totalRow = 0;
        DataSet ds1 = new DataSet();
        CommTable com1 = new CommTable("DA_AJDZFileSeeLog");
        List<SearchField> condition = new List<SearchField>();

        if (this.ajnum.Text.Trim() != String.Empty)
        {
            condition.Add(new SearchField("ajnum",this.ajnum.Text.Trim()));
        }

        if (this.domen.Text.Trim() != String.Empty)
        {
            condition.Add(new SearchField("domen", this.domen.Text.Trim(),SearchOperator.包含));
        }

        String[] arr1 = new String[] {"*"};
        if (condition.Count == 0) condition = null;

        ds1=com1.SearchData(arr1, condition, "id desc",
            curpage,
            this.PageNavigator1.PageSize,
            out totalRow);
        com1.Close();
        return ds1;
    }
    
}
