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

public partial class ZcMng1_MyDepartZc : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.SearchControl1.SearchEvent += new EventHandler(SearchControl1_SearchEvent);
        base.OnInit(e);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // this.BindData(null,null);
           // this.AdvanceSearch1.SetDepartRow(false);
           // this.NewBindData();

           // this.SearchControl1.GetSearchCondition();
           // this.NewBindData();
           
        }
        //this.AdvanceSearch1.OnMySearchClick += new EventHandler(AdvanceSearch1_OnMySearchClick);
        
    }

    void SearchControl1_SearchEvent(object sender, EventArgs e)
    {
        this.NewBindData();
    }

   
    private void NewBindData()
    {
        bool AllZc = false;
        AllZc = this.SearchControl1.AllZC;
        string zcid = "";

        List<SearchField> list1 = this.SearchControl1.SearchConditionList;
       // Response.Write( JSJ.SysFrame.DB.SearchField.GetSearchCondition(list1));
        if (list1 != null)
        {
           // list1.Add(new SearchField(String.Format("(u_zc.zeren='{0}')", User.Identity.Name), "", SearchOperator.用户定义));

            ZcBu bu1 = new ZcBu();
            DataSet ds1 = null;
            double benjin = 0, lixi = 0;

            if (this.SearchControl1.SearchType == SearchDataType.单条资产)
            {
                ds1 = bu1.GetZcList(list1, AllZc);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    
                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
                    {
                        benjin = benjin + double.Parse(dr1["bj"].ToString());
                        lixi = lixi + double.Parse(dr1["lx"].ToString());
                    }

                    //增加合计行
                    DataRow dr = ds1.Tables[0].NewRow();
                    dr["danwei"] = "<b>合 计</b>";
                    dr["bj"] = benjin;
                    dr["lx"] = lixi;
                    ds1.Tables[0].Rows.Add(dr);

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
            }
            else
            {
                ds1 = bu1.GetZcBaoList(list1);
            }


            Session["Myzcid"] = zcid;
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
            ds1.Dispose();
        }
    }

    //search data
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.danwei.Text,this.zeren.Text);
    }


    #region old code

    //Bind data
    private void BindData(string danwei, string zenren)
    {
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetDepartZc(User.Identity.Name, danwei, zenren);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        zc1.Close();
        ds1.Dispose();
    }


    //显示高级查询
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.AdvanceRow.Visible = !this.AdvanceRow.Visible;
        if (this.AdvanceRow.Visible == false)
        {
            this.LinkButton1.Text = "显示高级查询>> ";

            /*
            if (this.danwei.Text.Trim() != "")
            {
                this.BindData(this.danwei.Text.Trim(), this.zeren.Text.Trim());
            }
            else
            {
                this.BindData(null, null);
            }*/
        }
        else
        {
            this.LinkButton1.Text = "隐藏高级查询>> ";
        }
        this.NewBindData();
    }

    void AdvanceSearch1_OnMySearchClick(object sender, EventArgs e)
    {
        ZcMng1_AdvanceSearch search1 = sender as ZcMng1_AdvanceSearch;
        if (search1 != null)
        {
            List<SearchField> list1 = search1.SearchConditon;

            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds1 = zc1.GetDepartZcInfo(list1,User.Identity.Name,this.danwei.Text,this.zeren.Text);
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
            zc1.Close();
            ds1.Dispose();
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;

            //审批状态
            Label lab1 = e.Row.FindControl("spstatus") as Label;
            if (lab1 != null)
            {
                String temp = dr["spstatus0"].ToString();
                if (String.IsNullOrEmpty(temp))
                {
                    temp = "0";
                }
                if (temp == "0") lab1.Text = "No";
                if (temp == "1") lab1.Text = "<span title='审核委员会批'>☆</span>";
                if (temp == "2") lab1.Text = "<span title='决策委员会批'>☆☆</span>";
            }
        }
    }
    #endregion

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
        if (!Page.IsPostBack)
        {
            // this.BindData(null,null);
            // this.AdvanceSearch1.SetDepartRow(false);
            // this.NewBindData();

            this.SearchControl1.GetSearchCondition();
            this.NewBindData();

        }
        
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
