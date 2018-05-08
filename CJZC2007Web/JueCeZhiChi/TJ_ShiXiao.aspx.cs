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
using JSJ.CJZC.Business;
using System.Drawing;

public partial class JueCeZhiChi_TJ_ShiXiao : System.Web.UI.Page
{
    enum ShiXiao { 执行时效 = 0, 保证时效 = 1, 诉讼时效 = 2, 抵押时效=3}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            for (int i = 2000; i <= 2100; i++)
            {
                ListItem list1 = new ListItem(i + "", i + "");
                this.byear3.Items.Add(list1);
            }

            this.byear3.SelectedValue = DateTime.Now.Year + "";
            this.butSt4_Click(sender, e);
        }
    }

    //统计时效
    protected void butSt4_Click(object sender, EventArgs e)
    {
        CommTable tab1 = new CommTable();
        string sql = @"select month(time0) as month0,TimeName,count(*) as count0 from U_ZcTime
                        where time0 is not null and TimeName is not null and year(time0)=@year
                        group by month(time0) ,TimeName
                        order by month(time0) ,TimeName";
        sql = sql.Replace("@year", this.byear3.SelectedValue);
        DataSet ds=tab1.TableComm.SearchData(sql);
        tab1.Close();

        //创建表格
        this.CreateTable(ds);
    }


    private void CreateTable(DataSet ds)
    {
        this.SetTableTitle(this.byear3.SelectedValue+"年度时效统计汇总表");
        DataTable dt = ds.Tables[0];

        string month1 = "";
        int[] time0 = new int[] { 0, 0, 0, 0 };
        if (dt.Rows.Count > 0)
        {
            month1 = dt.Rows[0]["month0"].ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (month1 == dr["month0"].ToString())
                {
                    ShiXiao shixiao1 = (ShiXiao)Enum.Parse(typeof(ShiXiao), dr["TimeName"].ToString());
                    time0[(int)shixiao1] = time0[(int)shixiao1] + Int32.Parse(dr["count0"].ToString());
                }
                else
                {
                    this.InsertRow(month1, time0);
                    for (int k = 0; k < time0.Length; k++)
                    {
                        time0[k] = 0;
                    }
                    month1 = dr["month0"].ToString();
                    ShiXiao shixiao1 = (ShiXiao)Enum.Parse(typeof(ShiXiao), dr["TimeName"].ToString());
                    time0[(int)shixiao1] = time0[(int)shixiao1] + Int32.Parse(dr["count0"].ToString());
                }
            }
            this.InsertRow(month1, time0);
        }
    }


    private void SetTableTitle(string tabTitle)
    {
        this.Table1.Visible = true;
        this.Table1.Rows[0].Cells[0].Text = tabTitle;
        this.Table1.Rows[0].Cells[0].Font.Size = FontUnit.Parse("12pt");
        this.Table1.Rows[0].Height = Unit.Parse("25pt");
    }

    /// <summary>
    /// 插入数据行
    /// <param name="month1">时效的月份</param>
    /// <param name="time0">时效的统计数量</param>
    /// </summary>
    private void InsertRow(string month1,int[] time0)
    {
        TableRow tr = new TableRow();
        tr.HorizontalAlign = HorizontalAlign.Center;
        tr.BackColor = Color.White;
        tr.Height = Unit.Parse("20pt");
        tr.Height = Unit.Parse("18pt");
        //第1列
        TableCell tc1 = new TableCell();
        tc1.Text = month1 + "月";
        tr.Cells.Add(tc1);

        //其他4列
        for (int i = 0; i < time0.Length; i++)
        {
            TableCell tc2 = new TableCell();
            if (time0[i] == 0)
            {
                tc2.Text = time0[i] + "";
            }
            else
            {
                HyperLink link1 = new HyperLink();
                link1.Text = time0[i] + "";
                link1.NavigateUrl = string.Format("TJ_SX_List.aspx?year={0}&month={1}&timename={2}", this.byear3.SelectedValue, month1,Server.UrlEncode(((ShiXiao)i).ToString()));
                link1.Target = "_blank";
                link1.ForeColor = Color.Blue;
                link1.ToolTip = "点击浏览详细";
                link1.Font.Underline = true;
                tc2.Controls.Add(link1);
            }

            tr.Cells.Add(tc2);
        }

        //加入行
        this.Table1.Rows.Add(tr);
    }
}
