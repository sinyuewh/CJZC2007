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

public partial class ZcMng1_ShenPiZcDone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData(null);
            this.AdvanceSearch1.SetDepartRow(false);
        }
        this.AdvanceSearch1.OnMySearchClick += new EventHandler(AdvanceSearch1_OnMySearchClick);
    }


    //Bind data
    private void BindData(string danwei)
    {
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetMyShenPiZc(User.Identity.Name, danwei, 1);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        zc1.Close();
        ds1.Dispose();
    }

    //search data
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.danwei.Text);
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

            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds1 = zc1.GetMyShenPiZcInfo(list1, User.Identity.Name, this.danwei.Text, 1);
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
            zc1.Close();
            ds1.Dispose();
        }
    }
}
