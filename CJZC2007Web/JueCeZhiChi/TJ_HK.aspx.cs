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

public partial class JueCeZhiChi_StatHuiKuan1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.time1.Attributes["onfocus"] = "setday(this)";
            this.time2.Attributes["onfocus"] = "setday(this)";

            for (int i = 2000; i <= 2100; i++)
            {
                ListItem list1 = new ListItem(i + "", i + "");
                this.byear1.Items.Add(list1);
                this.byear2.Items.Add(list1);
                this.byear3.Items.Add(list1);

                this.byear1.SelectedValue = DateTime.Now.Year + "";
                this.byear2.SelectedValue = DateTime.Now.Year + "";
                this.byear3.SelectedValue = DateTime.Now.Year + "";
            }

            for (int i = 1; i <= 12; i++)
            {
                ListItem list1 = new ListItem(i + "", i + "");
                this.bmonth1.Items.Add(list1);
                this.bmonth1.SelectedValue = DateTime.Now.Month + "";
            }

            for (int i = 1; i <= 4; i++)
            {
                ListItem list1 = new ListItem(i + "", i + "");
                this.jidu.Items.Add(list1);
                int month0 = DateTime.Now.Month;
                this.jidu.SelectedValue = ((month0 - 1) / 3 + 1) + "";
            }
        }
    }


    #region 统计回款
    //按用户自定义的时间段统计
    protected void butSt1_Click(object sender, EventArgs e)
    {
        string begtime = this.time1.Text;
        string endtime = this.time2.Text;
        CW_ShouKuanBU shou1 = new CW_ShouKuanBU();
        DataSet ds = shou1.GetHuiKuanStaticDataByDefineTime(begtime, endtime);
        shou1.Close();
        if (begtime == "")
        {
            begtime = "过去";
        }
        if (endtime == "")
        {
            endtime = "现在";
        }
        this.SetTableData(begtime + "～" + endtime + "长江资产回款汇总表", ds);
    }

    //按月统计回款数据
    protected void butSt2_Click(object sender, EventArgs e)
    {
        int y1 = int.Parse(this.byear1.SelectedValue);
        int m1 = int.Parse(this.bmonth1.SelectedValue);
        CW_ShouKuanBU shou1 = new CW_ShouKuanBU();
        DataSet ds = shou1.GetHuiKuanStaticDataByYearAndMonth(y1,m1);
        shou1.Close();
        this.SetTableData(y1 + "年" + m1 + "月长江资产回款汇总表", ds);
    }

    //按年和季度统计数据
    protected void butSt3_Click(object sender, EventArgs e)
    {
        int y1 = int.Parse(this.byear2.SelectedValue);
        int jd1 = int.Parse(this.jidu.SelectedValue);
        CW_ShouKuanBU shou1 = new CW_ShouKuanBU();
        DataSet ds = shou1.GetHuiKuanStaticDataByYearAndQuarty(y1,jd1);
        shou1.Close();
        this.SetTableData(y1 + "年" + jd1 + "季度长江资产回款汇总表", ds);
    }

    //按年统计
    protected void butSt4_Click(object sender, EventArgs e)
    {
        int y1 = int.Parse(this.byear3.SelectedValue);
        CW_ShouKuanBU shou1 = new CW_ShouKuanBU();
        DataSet ds = shou1.GetHuiKuanStaticDataByYear(y1);
        shou1.Close();
        this.SetTableData(y1 + "年度长江资产回款汇总表", ds);
    }
    #endregion

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
        double sumDepart = 0.0;     //部门汇总
        double sumAll = 0.0;        //所有汇总
        if (dt1.Rows.Count > 0)
        {
            string depart = "";  //表示部门
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string zeren=dt1.Rows[i]["zeren"].ToString();
                double val=double.Parse(dt1.Rows[i]["pbj"].ToString());
                sumAll = sumAll + val;

                if (depart != dt1.Rows[i]["depart"].ToString())
                {
                    //插入部门小计
                    if (depart != "")
                    {
                        this.InsertRow(depart, "", sumDepart);
                    }

                    depart=dt1.Rows[i]["depart"].ToString();
                    sumDepart = double.Parse(dt1.Rows[i]["pbj"].ToString());
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
    /// <param name="huikuan">金额</param>
    private void InsertRow(string depart, string zeren, double huikuan)
    {
        string time1 = "";
        if (HttpContext.Current.Items["time0"].ToString() != "")
        {
            time1 = (DateTime.Parse(HttpContext.Current.Items["time0"].ToString())).ToString("yyyy-MM-dd");
        }

        string time2 = "";
        if(HttpContext.Current.Items["time1"].ToString()!="")
        {
            time2=(DateTime.Parse(HttpContext.Current.Items["time1"].ToString())).ToString("yyyy-MM-dd");
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
        if (depart == "" && zeren=="")
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
        tc3.HorizontalAlign = HorizontalAlign.Right;
        if (huikuan != 0)
        {
            HyperLink link1 = new HyperLink();
            link1.Text = "￥"+Comm.GetNumberFormat(huikuan)+ "&nbsp;&nbsp;&nbsp;&nbsp;";
            link1.NavigateUrl = string.Format("TJ_HK_List.aspx?dt1={0}&dt2={1}&depart={2}&zeren={3}", time1, time2, Server.UrlEncode(depart), Server.UrlEncode(zeren));
            link1.Target = "_blank";
            link1.ForeColor = Color.Blue;
            link1.ToolTip = "点击浏览详细";
            link1.Font.Underline = true;
            tc3.Controls.Add(link1);
        }
        else
        {
            tc3.Text =  "0￥" + "&nbsp;&nbsp;&nbsp;&nbsp;"; ;
        }
        tr.Cells.Add(tc3);
        this.Table1.Rows.Add(tr);
    }

    #endregion

}
