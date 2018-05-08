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
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;
using System.Collections.Generic;

public partial class ZiChan_ZiChangFengPei : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_RolesBU role1 = new U_RolesBU();
            bool check1 = role1.isRole("资产管理员");
            role1.Close();

            if (check1 == false)
            {
                Response.Redirect("~/Error.aspx?info=NoAccess", true);
            }
            else
            {
                this.BindData(null);
            }

            this.AdvanceSearch1.SetDepartRow(false);
        }
        this.AdvanceSearch1.OnMySearchClick += new EventHandler(AdvanceSearch1_OnMySearchClick);
    }

    //BindData
    private void BindData(string danwei)
    {
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetNoZerenZc(danwei);
        zc1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }

    //根据单位名称查询资产
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.danwei.Text.Trim());
    }


    //显示高级查询
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

    void AdvanceSearch1_OnMySearchClick(object sender, EventArgs e)
    {
        ZcMng1_AdvanceSearch search1 = sender as ZcMng1_AdvanceSearch;
        if (search1 != null)
        {
            List<SearchField> list1 = search1.SearchConditon;
            list1.Add(new SearchField("zeren", "null", SearchOperator.空值));

            U_ZCBU Zc1 = new U_ZCBU();
            DataSet ds1 = Zc1.GetSearchResult(list1);
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
            ds1.Dispose();
            Zc1.Close();
        }
    }
}
