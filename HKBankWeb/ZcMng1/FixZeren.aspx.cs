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

public partial class ZcMng1_FixZeren : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PubComm.SetAccess(User.Identity.Name, "资产管理员");  
            this.BindData(null);

            this.ChangeTable();  //调整表的结构
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
            list1.Add(new SearchField("zeren", "null", SearchOperator.非空值));

            U_ZCBU Zc1 = new U_ZCBU();
            DataSet ds1 = Zc1.GetSearchResult(list1);
            DataView dv = ds1.Tables[0].DefaultView;
            dv.Sort = "num2";
            this.GridView1.DataSource = dv;
            this.GridView1.DataBind();
            ds1.Dispose();
            Zc1.Close();
        }

    }


    //Bind data
    private void BindData(string zeren)
    {
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1= zc1.GetHaveZerenZc(zeren);
        DataView dv = ds1.Tables[0].DefaultView;
        dv.Sort = "num2";
        this.GridView1.DataSource = dv;
        this.GridView1.DataBind();
        zc1.Close();
    }

    //Search Data
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.zeren.Text.Trim());
    }


    //显示高级查询
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.AdvanceRow.Visible = !this.AdvanceRow.Visible;
        if (this.AdvanceRow.Visible == false)
        {
            this.LinkButton1.Text = "显示高级查询>> ";

            if (this.zeren.Text.Trim() != "")
            {
                this.BindData(this.zeren.Text.Trim());
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

    private void ChangeTable()
    {
        WebFrame.Data.JConnect conn0 = WebFrame.Data.JConnect.GetConnect("DefaultConnstring");
       
        if (conn0 != null )
        {
            WebFrame.Data.JCommand comm1 = new WebFrame.Data.JCommand(conn0);
            comm1.CommandText = "select * from u_zc where 0=1";
            DataSet ds1 = comm1.SearchData(-1);
            if (ds1 != null)
            {
                DataTable dt1 = ds1.Tables[0];
                if (dt1.Columns.Contains("zeren2") == false)
                {
                    comm1.CommandText = "alter table u_zc add zeren2 varchar(50)";
                    comm1.ExecuteNoQuery();
                }
            }

            /*-------------------------------------------------------*/
            comm1.CommandText = "select * from u_zcbao where 0=1";
            DataSet ds2 = comm1.SearchData(-1);
            if (ds2 != null)
            {
                DataTable dt2 = ds2.Tables[0];
                if (dt2.Columns.Contains("bzeren2") == false)
                {
                    comm1.CommandText = "alter table u_zcbao add bzeren2 varchar(50)";
                    comm1.ExecuteNoQuery();
                }
            }
            conn0.Dispose();
        }

    }
}
