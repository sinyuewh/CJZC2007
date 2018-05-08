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

public partial class ZcMng1_LawGwBaoList : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.SearchControl1.SearchEvent += new EventHandler(SearchControl1_SearchEvent);
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //查询数据
    void SearchControl1_SearchEvent(object sender, EventArgs e)
    {
        List<SearchField> condition = this.SearchControl1.SearchConditionList;
        ZcBu bu1 = new ZcBu();
        DataSet ds1 = null;
        double benjin = 0, lixi = 0;
        double hs = 0;

        if (this.SearchControl1.SearchType == SearchDataType.单条资产)
        {
            ds1 = bu1.GetZcList(condition);

        }
        else
        {
            ds1 = bu1.GetZcBaoList(condition);
        }


        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                benjin = benjin + double.Parse(dr1["bj"].ToString());
                lixi = lixi + double.Parse(dr1["lx"].ToString());
                hs = hs + double.Parse(dr1["hs"].ToString());
            }

            //增加合计行
            DataRow dr = ds1.Tables[0].NewRow();
            dr["bname"] = "<b>合 计</b>";
            dr["bj"] = benjin;
            dr["lx"] = lixi;
            dr["hs"] = hs;
            ds1.Tables[0].Rows.Add(dr);
        }
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();

        this.SearchTable.Visible = false;
        this.SearchInfo.Visible = true;
    }


    //重新查询资产
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.SearchTable.Visible = true;
        this.SearchInfo.Visible = false;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        String temp = null;
        ZcspBU bu1 = new ZcspBU();
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            HyperLink link1 = e.Row.FindControl("link1") as HyperLink;
            if (link1 != null)
            {
                link1.Text = JSJ.SysFrame.Util.GetMaxLenth(dr["bname"].ToString().Trim(), 18);
                if (dr["id"].ToString().Trim() != String.Empty)
                {
                    link1.NavigateUrl = "~/ZcMng2/ZcBaoDetail1.aspx?id=" + dr["id"].ToString();
                    link1.ToolTip = "浏览资产包的详细情况";
                    //link1.Target = "_blank";
                }
            }

            //计算本金
            double benjin = 0;
            Label lab1 = e.Row.FindControl("benjin") as Label;
            if (lab1 != null)
            {
                temp = dr["bj"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp))
                {
                    temp = "0";
                }
                benjin = double.Parse(temp);
                lab1.Text = benjin.ToString("n");
            }

            //计算利息
            double lixi = 0;
            lab1 = e.Row.FindControl("lixi") as Label;
            if (lab1 != null)
            {
                temp = dr["lx"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp)) temp = "0";
                lixi = double.Parse(temp);
                lab1.Text = lixi.ToString("n");
            }


            //计算总额
            lab1 = e.Row.FindControl("zqce") as Label;
            if (lab1 != null)
            {
                lab1.Text = (benjin + lixi).ToString("n");
            }


            DataRow info1 = bu1.GetShenPiInfo("spstatus,spresult,status1,status2 ", dr["id"].ToString(), "2");

            //审批状态
            lab1 = e.Row.FindControl("spstatus") as Label;
            if (lab1 != null && dr["id"].ToString().Trim() != String.Empty)
            {
                String s1 = String.Empty;
                if (info1 != null)
                {
                    s1 = info1["spstatus"].ToString().Trim();
                }
                if (s1 == String.Empty) s1 = "-1";
                int status1 = int.Parse(s1);
                if (status1 == -1)
                {
                    lab1.Text = "<span title='未启动审批'>□</span>";
                }
                if (status1 == 0)
                {
                    lab1.Text = "<span title='审批中'><font color='blue'>○</font></span>";
                }
                if (status1 == 1)
                {
                    lab1.Text = "<span title='审核委员会批'><font color='Red'>☆</font></span>";
                }
                if (status1 == 2)
                {
                    lab1.Text = "<span title='决策委员会批'><font color='Red'>☆☆</font></span>";
                }

            }

            //执行结果
            lab1 = e.Row.FindControl("spresult") as Label;
            if (lab1 != null && dr["id"].ToString().Trim() != String.Empty)
            {
                if (info1 != null)
                {
                    lab1.Text = info1["spresult"].ToString().Trim();
                }
            }

            //执行状态
            lab1 = e.Row.FindControl("zxzt") as Label;
            if (lab1 != null && dr["id"].ToString().Trim() != String.Empty)
            {
                if (info1 != null)
                {
                    if (info1["status1"].ToString().Trim() != String.Empty)
                    {
                        temp = info1["status1"].ToString() + "-" + info1["status2"].ToString();
                    }
                    else
                    {
                        temp = "&nbsp;";
                    }
                    lab1.Text = temp;
                }
            }
        }
    }
}
