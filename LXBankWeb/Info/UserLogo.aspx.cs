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
using System.Drawing;

public partial class XtGL_UserLogo : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.SelectTime1.StaticEvent += new EventHandler(SelectTime1_StaticEvent);
        base.OnInit(e);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
        }
    }


    //处理统计事件
    void SelectTime1_StaticEvent(object sender, EventArgs e)
    {
        string dt1 = this.SelectTime1.BeginTime;
        string dt2 = this.SelectTime1.EndTime;
        
        DataSet ds1 = new DataSet();
        XT_UserLogBU userlog1 = new XT_UserLogBU();
        DataSet ds = userlog1.GetUserLogList(dt1,dt2);
        userlog1.Close();

        string tableTitle = "";
        switch (this.SelectTime1.StaticType)
        {
            case SearchStaticType.按年统计:
                tableTitle = this.SelectTime1.StaticYear + "年度用户上线统计表";
                break;
            case SearchStaticType.按月统计:
                tableTitle = this.SelectTime1.StaticYear + "年" + this.SelectTime1.StaticMonth + "月用户上线统计表";
                break;
            case SearchStaticType.按季度统计:
                tableTitle = this.SelectTime1.StaticYear + "年" + this.SelectTime1.StaticJidu + "季度用户上线统计表";
                break;
            default:
                string begtime = this.SelectTime1.BeginTime;
                if (begtime == "")
                {
                    begtime = "过去";
                }

                string endtime = this.SelectTime1.EndTime;
                if (endtime == "")
                {
                    endtime = "现在";
                }
                tableTitle = begtime + "～" + endtime + "用户上线统计表";
                break;

        }
        this.SetTableData(tableTitle, ds);
    }

    #region 私有数据
    /// <summary>
    /// 设置报表的数据
    /// </summary>
    /// <param name="tabTitle"></param>
    /// <param name="ds"></param>
    private void SetTableData(string tabTitle, DataSet ds)
    {
        this.SetTableTitle(tabTitle);

        //填充数据
        DataTable dt1 = ds.Tables[0];
        double sumDepart = 0;     //部门汇总
        double sumAll = 0;        //所有汇总
        if (dt1.Rows.Count > 0)
        {
            string depart = "";  //表示部门
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string zeren = dt1.Rows[i]["zeren"].ToString();
                double val = double.Parse(dt1.Rows[i]["time1"].ToString());
                sumAll = sumAll + val;

                if (depart != dt1.Rows[i]["depart"].ToString())
                {
                    //插入部门小计
                    if (depart != "")
                    {
                        this.InsertRow(depart, "", sumDepart);
                    }

                    depart = dt1.Rows[i]["depart"].ToString();
                    sumDepart = double.Parse(dt1.Rows[i]["time1"].ToString());
                    this.InsertRow(depart, zeren, val);
                }
                else
                {
                    this.InsertRow("", zeren, val);
                    sumDepart = sumDepart + val;
                }
            }

            //插入最后一个部门小计和公司合计
            this.InsertRow(depart, "", sumDepart);
            this.InsertRow("", "", sumAll);
        }
    }



    /// <summary>
    /// 设置表格Title数据
    /// <param name="tabTitle">表格的标题</param>
    /// </summary>
    private void SetTableTitle(string tabTitle)
    {
        this.Table1.Visible = true;
        this.Table1.Rows[0].Cells[0].Text = tabTitle;
        this.Table1.Rows[0].Cells[0].Font.Size = FontUnit.Parse("12pt");
        this.Table1.Rows[0].Height = Unit.Parse("25pt");
    }
    /// <summary>
    /// 插入表格1行数据
    /// </summary>
    /// <param name="depart">部门</param>
    /// <param name="zeren">责任人</param>
    /// <param name="shangxiantime">上线时间</param>
    private void InsertRow(string depart, string zeren, double shangxiantime)
    {
        string time1 = "";
        if (HttpContext.Current.Items["time0"].ToString() != "")
        {
            time1 = (DateTime.Parse(HttpContext.Current.Items["time0"].ToString())).ToString("yyyy-MM-dd");
        }

        string time2 = "";
        if (HttpContext.Current.Items["time1"].ToString() != "")
        {
            time2 = (DateTime.Parse(HttpContext.Current.Items["time1"].ToString())).ToString("yyyy-MM-dd");
        }

        TableRow tr = new TableRow();
        tr.HorizontalAlign = HorizontalAlign.Center;
        if (depart != "" && zeren == "")
        {
            tr.BackColor = Color.FromArgb(0xcc, 0xff, 0xcc);
        }
        else
        {
            tr.BackColor = Color.White;
        }

        tr.Height = Unit.Parse("18pt");

        //第1列
        TableCell tc1 = new TableCell();
        if (depart == "" && zeren == "")
        {
            tc1.Text = "<b><font color='#ff0000'>总计</font></b>";
        }
        else if (zeren == "")
        {
            tc1.Text = String.Format("{0}小计", depart);
        }
        else
        {
            tc1.Text = depart;
        }
        tr.Cells.Add(tc1);

        //第2列
        TableCell tc2 = new TableCell();
        tc2.Text = zeren;
        if (tc2.Text == "")
        {
            tc2.Text = "----";
        }
        tr.Cells.Add(tc2);

        //第3列
        TableCell tc3 = new TableCell();
        tc3.HorizontalAlign = HorizontalAlign.Center;
        if (shangxiantime != 0)
        {
            HyperLink link1 = new HyperLink();
            link1.Text =shangxiantime+"";
            link1.NavigateUrl = string.Format("UserLogList.aspx?dt1={0}&dt2={1}&depart={2}&zeren={3}", time1, time2, Server.UrlEncode(depart), Server.UrlEncode(zeren));
            link1.Target = "_blank";
            link1.ForeColor = Color.Blue;
            link1.ToolTip = "点击浏览详细";
            link1.Font.Underline = true;
            tc3.Controls.Add(link1);
        }
        else
        {
            tc3.Text = "0" + "&nbsp;&nbsp;&nbsp;&nbsp;"; ;
        }
        tr.Cells.Add(tc3);
        this.Table1.Rows.Add(tr);
    }

    #endregion
}
