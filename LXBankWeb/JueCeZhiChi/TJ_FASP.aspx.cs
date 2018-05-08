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

public partial class JueCeZhiChi_TJ_FASP : System.Web.UI.Page
{
    private string prevDepart = "";
    private int curRow = 0;

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
        DateTime dt1 = default(DateTime);
        DateTime dt2 = default(DateTime);
        if (this.SelectTime1.BeginTime != "")
        {
            dt1 = DateTime.Parse(this.SelectTime1.BeginTime);
        }

        if (this.SelectTime1.EndTime != "")
        {
            dt2 = DateTime.Parse(this.SelectTime1.EndTime);
        }

        U_ZCSPBU sp1 = new U_ZCSPBU();
        DataSet ds = sp1.GetZcSpStatic(dt1,dt2);
        sp1.Close();

        string tableTitle = "";
        switch (this.SelectTime1.StaticType)
        {
            case SearchStaticType.按年统计:
                tableTitle = this.SelectTime1.StaticYear + "年度方案审批统计表";
                break;
            case SearchStaticType.按月统计:
                tableTitle = this.SelectTime1.StaticYear + "年" + this.SelectTime1.StaticMonth + "月方案审批统计表";
                break;
            case SearchStaticType.按季度统计:
                tableTitle = this.SelectTime1.StaticYear + "年" + this.SelectTime1.StaticJidu + "季度方案审批统计表";
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
                tableTitle = begtime + "～" + endtime + "方案审批统计表";
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
            //设置部门、责任人、尽职调查的初始值
            int[] val1 = new int[] { 0, 0, 0, 0,0,0 };   //个人数据
            int[] val2 = new int[] { 0, 0, 0, 0 ,0,0};   //部门小计
            int[] val3 = new int[] { 0, 0, 0, 0,0,0 };  //公司合计

            string person0 = dt1.Rows[0]["zeren"].ToString();
            string depart0 = dt1.Rows[0]["depart"].ToString();

            int kind1 = int.Parse(dt1.Rows[0]["kind"].ToString()) - 11;
            val1[kind1]++;
            val2[kind1]++;
            val3[kind1]++;

            /////////////////////////////////////////////////////
            for (int i = 1; i < dt1.Rows.Count; i++)
            {
                string depart1 = dt1.Rows[i]["depart"].ToString();
                string person1 = dt1.Rows[i]["zeren"].ToString();
                kind1 = int.Parse(dt1.Rows[i]["kind"].ToString()) - 11;
                val3[kind1]++;  //公司数据++

                if (person1 == person0)
                {
                    val1[kind1]++;
                    val2[kind1]++;
                }
                else
                {
                    //输出Person0的数据
                    this.InserRow(depart0, person0, val1);
                    person0 = person1;
                    for (int k = 0; k < val1.Length; k++)
                    {
                        val1[k] = 0;
                    }
                    val1[kind1]++;


                    ///////////////////////////////////////////////
                    if (depart0 == depart1)
                    {
                        val2[kind1]++;
                    }
                    else
                    {
                        //输出Depart0的数据
                        this.InserRow(depart0, "", val2);
                        depart0 = depart1;
                        for (int k = 0; k < val2.Length; k++)
                        {
                            val2[k] = 0;
                        }
                        val2[kind1]++;
                    }
                }
            }

            //输出最后数据
            this.InserRow(depart0, person0, val1);
            this.InserRow(depart0, "", val2);
            this.InserRow("", "", val3);
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
    /// <param name="depart">实际部门</param>
    /// <param name="depart1">显示的部门</param>
    /// <param name="zeren">责任人</param>
    /// <param name="val1">尽职调查数据数组</param>
    private void InserRow(string depart, string zeren, int[] val1)
    {
        this.curRow++;

        //得到统计的时间
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

        //输出表格的一行数据
        TableRow tr = new TableRow();
        tr.HorizontalAlign = HorizontalAlign.Center;
        if (zeren == "" && depart != "")
        {
            tr.BackColor = Color.FromArgb(0xcc, 0xff, 0xcc);
        }
        else
        {
            tr.BackColor = Color.White;
        }
        tr.Height = Unit.Parse("18pt");

        //部门
        TableCell tc1 = new TableCell();
        if (zeren == "" && depart == "")
        {
            tc1.Text = "<b><font color='#ff0000'>总计</font></b>";
        }
        else if (zeren == "")
        {
            tc1.Text = String.Format("{0}小计", depart);
        }
        else
        {
            if (depart == this.prevDepart)
            {
                tc1.Text = "";
            }
            else
            {
                tc1.Text = depart;
                this.prevDepart = depart;
            }
        }
        tr.Cells.Add(tc1);

        //责任人
        TableCell tc2 = new TableCell();
        if (zeren != "")
        {
            tc2.Text = zeren;
        }
        else
        {
            tc2.Text = "----";
        }
        tr.Cells.Add(tc2);

        //尽职调查数据
        for (int k = 0; k < 6; k++)
        {
            TableCell tck = new TableCell();
            if (val1[k] != 0)
            {
                HyperLink link1 = new HyperLink();
                link1.Text = val1[k].ToString();
                link1.Target = "_blank";
                link1.NavigateUrl = string.Format("TJ_JZTC_List.aspx?searchtype=1&dt1={0}&dt2={1}&kind={2}&zeren={3}&depart={4}", time1, time2, k + 1+10, Server.UrlEncode(zeren), Server.UrlEncode(depart));
                link1.ForeColor = Color.Blue;
                link1.ToolTip = "点击浏览详细";
                link1.Font.Underline = true;
                tck.Controls.Add(link1);
            }
            else
            {
                tck.Text = val1[k] + "";
            }
            tr.Cells.Add(tck);
        }

        //输出汇总数据
        TableCell tckAll = new TableCell();
        tckAll.Text = (val1[0] + val1[1] + val1[2] + val1[3] + val1[4] + val1[5]) + "";
        tr.Cells.AddAt(2,tckAll);
        this.Table1.Rows.Add(tr);
    }

    #endregion 私有方法
}
