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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using System.Collections.Generic;

public partial class ZcMng1_MyZc1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            this.BindData(null);
        }
        this.AdvanceSearch1.SetDepartRow(false);
        this.AdvanceSearch1.OnMySearchClick += new EventHandler(AdvanceSearch1_OnMySearchClick);
    }

    void AdvanceSearch1_OnMySearchClick(object sender, EventArgs e)
    {
        ZcMng1_AdvanceSearch search1 = sender as ZcMng1_AdvanceSearch;
        if (search1 != null)
        {
            List<SearchField> list1 = search1.SearchConditon;
            list1.Add(new SearchField(String.Format("(zeren1='{0} or zeren2='{0}')", User.Identity.Name), "", SearchOperator.用户定义));

            U_ZCBU Zc1 = new U_ZCBU();
            DataSet ds1 = Zc1.GetMyZcInfo(list1);
            string zcid = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        zcid = ds1.Tables[0].Rows[i]["id"].ToString();
                    }
                    else
                    {
                        zcid = zcid + "," + ds1.Tables[0].Rows[i]["id"].ToString();
                    }
                }
            }
            Session["Myzcid"] = zcid;
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
            ds1.Dispose();
            Zc1.Close();
        }

    }

    //Bind data
    private void BindData(string danwei)
    {
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetMyZc11(User.Identity.Name, danwei);
        string zcid = "";
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {
                    zcid = ds1.Tables[0].Rows[i]["id"].ToString();
                }
                else
                {
                    zcid = zcid + "," + ds1.Tables[0].Rows[i]["id"].ToString();
                }
            }
        }
        Session["Myzcid"] = zcid;
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        String temp = null;
        ZcspBU bu1 = new ZcspBU();

        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;

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

            DataRow info1 = bu1.GetShenPiInfo("spstatus,spresult,status1,status2 ", dr["id"].ToString(), "1");

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


            //计算资产回款和支持用
            lab1 = e.Row.FindControl("zcid") as Label;
            if (lab1 != null)
            {
                lab1.Text = dr["id"].ToString().Trim();
            }
        }
    }

    //计算回款和支持
    protected override void OnPreRender(EventArgs e)
    {
        Label lab1 = null;
        Label lab2 = null;
        Label lab3 = null;

        String zcid = null;
        String zcbid = null;
        ArrayList list1 = new ArrayList();
        ArrayList list2 = new ArrayList();
        ZcspBU bu1 = new ZcspBU();

        double d1 = 0;
        double d2 = 0;
        double d0 = 0;

        foreach (GridViewRow row in this.GridView1.Rows)
        {
            lab1 = row.FindControl("zcid") as Label;
            if (lab1 != null)
            {
                zcid = lab1.Text.Trim();
            }

            lab1 = row.FindControl("zcbid") as Label;
            if (lab1 != null)
            {
                zcbid = lab1.Text.Trim();
            }

            lab2 = row.FindControl("huikuan") as Label;
            lab3 = row.FindControl("zhichu") as Label;
            if (lab2 != null && lab3 != null)
            {
                if (String.IsNullOrEmpty(zcid) == false)
                {
                    d0 = bu1.GetHuiKuan(zcid, ZCKind.单条资产);
                    d1 = d1 + d0;
                    lab2.Text = d0.ToString("n");

                    d0 = bu1.GetZhiChu(zcid, ZCKind.单条资产);
                    d2 = d2 + d0;
                    lab3.Text = d0.ToString("n");
                }
                else
                {
                    if (String.IsNullOrEmpty(zcbid) == false)
                    {
                        d0 = bu1.GetHuiKuan(zcbid, ZCKind.资产包);
                        d1 = d1 + d0;
                        lab2.Text = d0.ToString("n");

                        d0 = bu1.GetZhiChu(zcbid, ZCKind.资产包);
                        d2 = d2 + d0;
                        lab3.Text = d0.ToString("n");
                    }
                    else
                    {
                        lab2.Text = d1.ToString("n");
                        lab3.Text = d2.ToString("n");
                    }
                }
            }
        }
    }
}
