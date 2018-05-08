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
using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using System.Drawing;

public partial class JueCeZhiChi_StatZhiChu : System.Web.UI.Page
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
            this.DataBind();
        }
    }

    //统计事件处理
    void SelectTime1_StaticEvent(object sender, EventArgs e)
    {
        string dt1 = "";
        string dt2 = "";
        if (this.SelectTime1.BeginTime != "")
        {
            dt1 = this.SelectTime1.BeginTime;
        }

        if (this.SelectTime1.EndTime != "")
        {
            dt2 = this.SelectTime1.EndTime;
        }

        CW_PayBU pay1 = new CW_PayBU();
        DataSet ds = pay1.GetZhiChuStaticDataByDefineTime(dt1, dt2);
        pay1.Close();

        //显示表头信息
        string tableTitle = "";
        switch (this.SelectTime1.StaticType)
        {
            case SearchStaticType.按年统计:
                tableTitle = this.SelectTime1.StaticYear + "年度支出汇总表";
                break;
            case SearchStaticType.按月统计:
                tableTitle = this.SelectTime1.StaticYear + "年" + this.SelectTime1.StaticMonth + "月支出汇总表";
                break;
            case SearchStaticType.按季度统计:
                tableTitle = this.SelectTime1.StaticYear + "年" + this.SelectTime1.StaticJidu + "季度支出汇总表";
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
                tableTitle = begtime + "～" + endtime + "支出汇总表";
                break;
        }
        this.SetTableData(tableTitle, ds);
    }


    #region 私有方法
    /// <summary>
    /// 设置报表的数据
    /// </summary>
    /// <param name="tabTitle"></param>
    /// <param name="ds"></param>
    private void SetTableData(string tabTitle, DataSet ds)
    {
        //设置报表标题
        this.SetTableTitle(tabTitle);

        //填充数据
        DataTable dt1 = ds.Tables[0];
        if (dt1.Rows.Count > 0)
        {
            double[] val1 = new double[12];   //个人数据
            double[] val2 = new double[12];   //部门数据
            double[] val3 = new double[12];   //公司数据

            string depart = "";
            for (int i = 0; i < val1.Length; i++)
            {
                val1[i] = 0;
                val2[i] = 0;
                val3[i] = 0;
            }

            /////////////////////////////////////////////////////
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string zeren = dt1.Rows[i]["zeren"].ToString();
                for (int k = 0; k < val1.Length; k++)
                {
                    val1[k] = double.Parse(dt1.Rows[i]["fee" + (k + 1)].ToString());
                    val3[k] = val3[k] + val1[k];
                }

                if (depart != dt1.Rows[i]["depart"].ToString())
                {
                    //插入部门数据
                    if (depart != "")
                    {
                        this.InsertRow(depart, "", val2);
                    }

                    depart = dt1.Rows[i]["depart"].ToString();
                    for (int k = 0; k < val1.Length; k++)
                    {
                        val2[k] = double.Parse(dt1.Rows[i]["fee" + (k + 1)].ToString());
                    }

                    //插入个人数据
                    this.InsertRow(depart, zeren, val1);
                }
                else
                {
                    this.InsertRow("", zeren, val1);
                    for (int k = 0; k < val1.Length; k++)
                    {
                        val2[k] = val2[k]+double.Parse(dt1.Rows[i]["fee" + (k + 1)].ToString());
                    }
                }
            }

            //插入最后数据
            this.InsertRow(depart, "", val2);
            this.InsertRow("", "", val3);
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
    /// 插入一行表格数据
    /// </summary>
    /// <param name="depart">部门</param>
    /// <param name="zeren">责任人</param>
    /// <param name="val1">费用数组</param>
    private void InsertRow(string depart, string zeren, double[] val)
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
            tc1.Text = "<b><font color='#ff0000'>公司总计</font></b>";
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

        //第3-14列
        double sum1 = 0;
        for (int k = 0; k < val.Length; k++)
        {
            TableCell tc3 = new TableCell();
            tc3.HorizontalAlign = HorizontalAlign.Right;
            tc3.Text = "￥"+Comm.GetNumberFormat(val[k]);
            sum1 = sum1 + val[k];
            tr.Cells.Add(tc3);
        }

        //第15列
        TableCell tc15 = new TableCell();
        tc15.HorizontalAlign = HorizontalAlign.Right;
        HyperLink link1 = new HyperLink();
        link1.Text = "<u>￥" + Comm.GetNumberFormat(sum1)+"</u>";
        link1.Target = "_blank";
        link1.ForeColor = Color.Blue;
        link1.ToolTip = "点击浏览详细";
        link1.NavigateUrl = string.Format("TJ_ZhiChu_List.aspx?dt1={0}&dt2={1}&zeren={2}&depart={3}", time1, time2, Server.UrlEncode(zeren), Server.UrlEncode(depart));
        
        tc15.Controls.Add(link1);

        tr.Cells.AddAt(2,tc15);
        this.Table1.Rows.Add(tr);
    }

    #endregion 私有方法
}
