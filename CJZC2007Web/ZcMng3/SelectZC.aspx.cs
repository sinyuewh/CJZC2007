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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;

public partial class ZcMng3_SelectZC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    //查询资产数据
    protected void butSearch_Click(object sender, EventArgs e)
    {
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("danwei", this.danwei.Text.Trim(), SearchOperator.包含));
        ViewState["SearchCondition"] = condition;
        this.BindData();
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.AdvanceRow.Visible = !(this.AdvanceRow.Visible);
        if (this.AdvanceRow.Visible)
        {
            this.LinkButton1.Text = "隐藏高级查询>> ";
        }
        else
        {
            this.LinkButton1.Text = "显示高级查询>> ";
            ViewState["SearchCondition"] = null;
            this.BindData();
        }
    }


    /// <summary>
    /// 绑定数据
    /// </summary>
    private void BindData()
    {
        U_FASPBU bu1 = new U_FASPBU();
        DataSet ds = bu1.GetSelectZcList(ViewState["SearchCondition"] as List<SearchField>);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }


    protected override void OnLoad(EventArgs e)
    {
        this.AdvanceSearch1.OnMySearchClick += new EventHandler(AdvanceSearch1_OnMySearchClick);
        base.OnLoad(e);
    }

    void AdvanceSearch1_OnMySearchClick(object sender, EventArgs e)
    {
        ViewState["SearchCondition"] = this.AdvanceSearch1.SearchConditon;
        this.BindData();
    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            String id1 = dr["id"].ToString();
            HyperLink Hyper1 = e.Row.FindControl("ChuZhiCount") as HyperLink;
            if (Hyper1 != null)
            {
                if (dv != null)
                {
                    ZC2BU bu1 = new ZC2BU();
                    Hyper1.Text = bu1.GetChuZhiCountByID(int.Parse(id1)).ToString();
                    if (Hyper1.Text == "0")
                    {
                        Hyper1.Text = "";
                    }
                }
            }

            HyperLink hyp2 = e.Row.FindControl("HyperLink1") as HyperLink;
            if (hyp2 != null)
            {
                ZcspBU bu1 = new ZcspBU();
                int zcspCount = bu1.GetZcCount(int.Parse(id1), ZCKind.单条资产);
                hyp2.NavigateUrl = String.Format("javascript:myAddZc({0},{1});",id1,zcspCount);
                hyp2.Target = "_self";
            }
        }
    }


}
