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

public partial class ZcMng3_SearchFangAn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
       {
           
           /*SearchStruct info1 = Session["SearchXiangMu"] as SearchStruct;
           if (info1 != null)
           {
               this.SearchData(info1);
           }*/

            //设置方案执行结果
           PubComm.SetProfile("方案执行结果", this.spresult,"全部...");
           PubComm.SetProfile("方案执行状态大类", this.status1, "全部...");
           PubComm.SetProfile(this.status1.SelectedValue, this.status2, "全部...");
       }
    }

    protected override void OnInit(EventArgs e)
    {
        this.time1.Attributes["onfocus"] = "setday(this)";
        this.time2.Attributes["onfocus"] = "setday(this)";
        base.OnInit(e);
    }


    //查询项目
    protected void Button1_Click(object sender, EventArgs e)
    {
        SearchStruct info1 = new SearchStruct();
        info1.xmmc = this.xmmc.Text.Trim();
        info1.xmsbh = this.xmsbh.Text.Trim();
        info1.num2 = this.num2.Text.Trim();
        info1.danwei = this.danwei.Text.Trim();
        info1.spstatus = this.spstatus.SelectedValue.Trim();
        info1.spresult = this.spresult.SelectedValue.Trim();
        info1.status1 = this.status1.SelectedValue.Trim();
        info1.status2 = this.status2.SelectedValue.Trim();
        info1.zckind = this.zckind.SelectedValue.Trim();
        info1.time1 = this.time1.Text.Trim();
        info1.time2 = this.time2.Text.Trim();
        
        Session["SearchXiangMu"] = info1;

        this.SearchData(info1);
    }


    //执行查询
    private void SearchData(SearchStruct info1)
    {
        this.SearchTable.Visible = false;
        this.SearchInfo.Visible = true;

        U_FASPBU bu1 = new U_FASPBU();
        DataSet ds1=bu1.GetShenPiListBySearchCondition(info1);

        ////////////////////////////////////////////////////////
        DataTable[] ArrData = new DataTable[] { new DataTable(),new DataTable()};

        #region Code1
        ds1.Tables[0].Columns.Add("sort1");                 //增加排序列
        ds1.Tables[0].Columns.Add("Money1", typeof(Double));
        ds1.Tables[0].Columns.Add("money2", typeof(double));

        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            //将查询结果的列写入Dt1和Dt2
            ArrayList colName=new ArrayList();
            foreach(DataColumn col1 in ds1.Tables[0].Columns)
            {
                DataColumn newCol1 = new DataColumn(col1.ColumnName, col1.DataType);
                DataColumn newCol2 = new DataColumn(col1.ColumnName, col1.DataType);

                ArrData[0].Columns.Add(newCol1);
                ArrData[1].Columns.Add(newCol2);
                colName.Add(col1.ColumnName);       //得到列的数组
            }

            //得到资产包的ID列表；
            ArrayList baozclist = this.GetZcbaoIDList();   

            //将数据写入Dt1和Dt2
            //DataRow dr2=null;
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                //设置Sort1的值
                String str1 = dr1["xmsbh"].ToString().Trim().Replace('－', '-');
                String str2 = null;
                if (str1.IndexOf('-') > 0)
                {
                    String temp1 = str1.Split('-')[0].PadLeft(5, '0');
                    String temp2 = str1.Split('-')[1].PadLeft(5, '0');
                    str2 = temp1 + "-" + temp2;
                }
                else
                {
                    str2 = str1.PadLeft(5, '0') + "-" + "00000";
                }

                str2 = str2 + "-" + dr1["num2"].ToString();
                dr1["sort1"] = str2;

                //将数据分别移到数据1表和数据2表
                int i = 0;
                String id = dr1["zcid"].ToString().Trim();
                if (baozclist.Contains(id))
                {
                    i = 1;
                }

                DataRow newdr = ArrData[i].NewRow();
                foreach (String m in colName)
                {
                    newdr[m] = dr1[m];
                }
                ArrData[i].Rows.Add(newdr);
            }
        }
        #endregion 

        #region code2
        for (int i = 0; i < ArrData.Length; i++)
        {
            //分别计算合计的户数和数据
            if (ArrData[i] != null && ArrData[i].Rows.Count > 0)
            {
                ArrayList arr1 = new ArrayList();
                double d1 = 0, d2 = 0, d3 = 0;
                foreach (DataRow dr1 in ArrData[i].Rows)
                {
                    String num2 = dr1["num2"].ToString().Trim();
                    if (String.IsNullOrEmpty(num2) == false)
                    {
                        if (arr1.Contains(num2) == false)
                        {
                            arr1.Add(num2);
                        }
                    }

                    /////////////////////////////////////////////////////
                    String temp = dr1["benjin"].ToString().Replace(",", "");
                    if (String.IsNullOrEmpty(temp))
                    {
                        temp = "0";
                    }
                    d1 = d1 + double.Parse(temp);

                    temp = dr1["lixi"].ToString().Replace(",", "");
                    if (String.IsNullOrEmpty(temp))
                    {
                        temp = "0";
                    }
                    d2 = d2 + double.Parse(temp);

                    temp = dr1["zqce"].ToString().Replace(",", "");
                    if (String.IsNullOrEmpty(temp))
                    {
                        temp = "0";
                    }
                    d3 = d3 + double.Parse(temp);
                }

                DataRow dr = ArrData[i].NewRow();
                ArrData[i].Rows.Add(dr);
                dr["status1"] = DBNull.Value;
                dr["spstatus"] = "&nbsp;";
                dr["num2"] = "&nbsp;";
                dr["xmmc"] = "<center><b>合  计(" + arr1.Count + "户) </b></center>";
                dr["benjin"] = d1.ToString();
                dr["lixi"] = d2.ToString();
                dr["zqce"] = d3.ToString();
                dr["sort1"] = "ZZZZZ";
            } 
        }
        #endregion code2

        //绑定数据
        DataView view1 =null;
        if (ArrData[0].Rows.Count + ArrData[1].Rows.Count > 0)
        {
            if (ArrData[0] == null || ArrData[0].Rows.Count == 0)
            {
                view1 = ArrData[1].DefaultView;
                view1.Sort = "sort1";
                this.GridView1.DataSource = view1;
                this.GridView1.DataBind();
            }
            else
            {
                view1 = ArrData[0].DefaultView;
                view1.Sort = "sort1";
                this.GridView1.DataSource = view1;
                this.GridView1.DataBind();

                view1 = ArrData[1].DefaultView;
                view1.Sort = "sort1";
                this.GridView2.DataSource = view1;
                this.GridView2.DataBind();
            }
        }

        //展开导航项
        Common_Master_Zcsp master1 = this.Master as Common_Master_Zcsp;
        if (master1 != null)
        {
           master1.SetShowMax();
        }
    }


    //重新查询
    protected void butSearch_Click(object sender, EventArgs e)
    {
        Session.Remove("SearchXiangMu");
        this.SearchTable.Visible = true;
        this.SearchInfo.Visible = false;


        //展开导航项
        Common_Master_Zcsp master1 = this.Master as Common_Master_Zcsp;
        if (master1 != null)
        {
           master1.SetShowMin();
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ZcspBU bu1 = new ZcspBU();
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;

            //设置档案号
            HyperLink link2 = e.Row.FindControl("Link2") as HyperLink;
            if (link2 != null)
            {
                if (dr["zcid"].ToString().Trim() != String.Empty)
                {
                    link2.NavigateUrl = "~/ZcMng2/ZcDetail1.aspx?id=" + dr["zcid"].ToString();
                    link2.ToolTip = "浏览资产的详细情况";
                }

                if (dr["zcbid"].ToString().Trim() != String.Empty)
                {
                    link2.NavigateUrl = "~/ZcMng2/ZcBaoDetail1.aspx?id=" + dr["zcbid"].ToString();
                    link2.ToolTip = "浏览资产包的详细情况";
                }
                link2.Target = "_blank";

                String num = dr["num2"].ToString().Trim();
                if (num == String.Empty) num = "无编号";
                link2.Text = num;
            }

            //设置项目名称
            //设置资产处置链接的地址
            HyperLink link1 = e.Row.FindControl("Link1") as HyperLink;
            if (link1 != null)
            {
                if (dr["id"].ToString().Trim() != String.Empty)
                {
                    link1.NavigateUrl = "EditSbb.aspx?id=" + dr["id"].ToString();
                }
                link1.Text = JSJ.SysFrame.Util.GetMaxLenth(dr["xmmc"].ToString(),20);
                link1.Target = "_blank";
            }

            //计算本金
            String temp = null;
            Label lab1 = e.Row.FindControl("benjin") as Label;
            if (lab1 != null)
            {
                temp = dr["benjin"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp))
                {
                    temp = "0";
                }
                lab1.Text = double.Parse(temp).ToString("n");
            }

            //计算利息
            lab1 = e.Row.FindControl("lixi") as Label;
            if (lab1 != null)
            {
                temp = dr["lixi"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp))
                {
                    temp = "0";
                }
                lab1.Text = double.Parse(temp).ToString("n");
            }

            //计算总额
            lab1 = e.Row.FindControl("zqce") as Label;
            if (lab1 != null)
            {
                temp = dr["zqce"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp))
                {
                    temp = "0";
                }
                lab1.Text = double.Parse(temp).ToString("n");
            }

            //审批状态
            lab1 = e.Row.FindControl("spstatus") as Label;
            if (lab1 != null && dr["id"].ToString().Trim()!=String.Empty)
            {
                int status1 = bu1.GetShenPiStatus(dr["id"].ToString());
                
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


            //执行状态
            lab1 = e.Row.FindControl("zxzt") as Label;
            if (lab1 != null)
            {
                if (dr["status1"].ToString().Trim() != String.Empty)
                {
                    temp = dr["status1"].ToString() + "-" + dr["status2"].ToString();
                }
                else
                {
                    temp = "&nbsp;";
                }
                lab1.Text = temp;
            }

            lab1 = e.Row.FindControl("zcid") as Label;
            if (lab1 != null)
            {
                lab1.Text = dr["zcid"].ToString().Trim();
            }

            lab1 = e.Row.FindControl("zcbid") as Label;
            if (lab1 != null)
            {
                lab1.Text = dr["zcbid"].ToString().Trim();
            }
        }   
    }


    //更改方案执行状态的大类
    protected void status1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.status2.Items.Clear();
        PubComm.SetProfile(this.status1.SelectedValue, this.status2, "全部...");
    }



    protected void GridView1_Sorted(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        GridView[] arr1 = new GridView[] { this.GridView1, this.GridView2 };
        Label lab1 = null;
        Label lab2 = null;
        Label lab3 = null;

        String zcid = null;
        String zcbid = null;
        ArrayList list1 = new ArrayList();
        ArrayList list2 = new ArrayList();
        ZcspBU bu1 = new ZcspBU();

        for(int i=0;i<arr1.Length;i++)
        {
            double d1 = 0;
            double d2 = 0;
            double d0 = 0;

            foreach (GridViewRow row in arr1[i].Rows)
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
                        if (list1.Contains(zcid) == false)
                        {
                            list1.Add(zcid);
                            d0 = bu1.GetHuiKuan(zcid, ZCKind.单条资产);
                            d1 = d1+d0;
                            lab2.Text = d0.ToString("n");

                            d0= bu1.GetZhiChu(zcid, ZCKind.单条资产);
                            d2 = d2+d0;
                            lab3.Text = d0.ToString("n");
                        }
                        else
                        {
                            lab2.Text = "-";
                            lab3.Text ="-";
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(zcbid) == false)
                        {
                            if (list2.Contains(zcbid) == false)
                            {
                                list2.Add(zcbid);
                                d0 = bu1.GetHuiKuan(zcbid, ZCKind.资产包);
                                d1 = d1 + d0;
                                lab2.Text = d0.ToString("n");

                                d0  = bu1.GetZhiChu(zcbid, ZCKind.资产包);
                                d2 = d2 + d0;
                                lab3.Text = d0.ToString("n");
                            }
                            else
                            {
                                lab2.Text = "-";
                                lab3.Text = "-";
                            }
                        }
                        else
                        {
                            lab2.Text =d1.ToString("n");
                            lab3.Text =d2.ToString("n");
                        }
                    }
                }
            }
        }

        base.OnPreRender(e);
    }
    #region Private Function
    private ArrayList GetZcbaoIDList()
    {
        ArrayList list1 = new ArrayList();
        CommTable comm1 = new CommTable();
        comm1.TabName = "U_ZcBAoInfo";
        DataSet ds1=comm1.SearchData("distinct zcid");
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                list1.Add(dr[0].ToString().Trim());
            }
        }
        comm1.Close();
        return list1;
    }
    #endregion
}


