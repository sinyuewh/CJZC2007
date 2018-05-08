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

public partial class Info_MyRcaiPai : System.Web.UI.Page
{
    public string zt1, zt2, mt1, mt2, yt1, yt2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.time1.Attributes["onfocus"] = "setday(this)";
            this.time2.Attributes["onfocus"] = "setday(this)";

            for (int i = 2006; i <= 2100; i++)
            {
               ListItem list1 = new ListItem(i + "", i + "");
               this.selyear.Items.Add(list1);
            }

            for (int i = 1; i <= 12; i++)
            {
                ListItem list1 = new ListItem(i + "", i + "");
                this.selMonth.Items.Add(list1);
            }

            this.selyear.SelectedValue = DateTime.Now.Year + "";
            this.selMonth.SelectedValue = DateTime.Now.Month + "";


            //设置表格数据
            this.SetTableInfo();
         }
    }


    private void SetTableInfo()
    {
        int year = Int32.Parse(this.selyear.SelectedValue);
        int month = Int32.Parse(this.selMonth.SelectedValue);

        //得到数据
        Hashtable ht = this.getCalenderData(year, month);

        DateTime dt0 = DateTime.Parse(year + "-" + month + "-1");
        int min = (int)dt0.DayOfWeek;
        if (month == 12)
        {
            year++;
            month = 1;
        }
        else
        {
            month++;
        }
        DateTime dt1 = DateTime.Parse(year + "-" + month + "-1").AddDays(-1);
        TimeSpan span1 = dt1 - dt0;
        int spanday = span1.Days;
        int max = min + spanday;
       
        string tab0 = @"<table width='95%' cellpadding='0' cellspacing='0' border='0' align='center'>
                        <tr align='center'>
                            <td>
                                <span style='font-weight:bold;font-size:19pt;font-family:Arial'>{0}</span>
                            </td>
                        </tr>
                        <tr align='left' height='50'>
                            <td valign='top'>
                                {1}
                            </td>
                        </tr>
                     </table>";

        int m = 0;
        for (int i = 0; i < this.tab1.Rows.Count; i++)
        {
            for (int j = 0; j < this.tab1.Rows[i].Cells.Count; j++)
            {
                int k = i * 7 + j;
               
                if (k >= min && k <= max)
                {
                    string temp=null;
                    string val1=null;
                    string begA="<a href='RcanpaiDetails.aspx?time0="+dt0.AddDays(m).ToString("yyyy-MM-dd");

                    string temp2 = dt0.AddDays(m).Day.ToString();
                    if (dt0.AddDays(m).Date==DateTime.Now.Date)
                    {
                        temp2 = "<span style='font-family:宋体;font-size:16pt'>今天</span>";
                    }

                    if (dt0.AddDays(m).DayOfWeek == DayOfWeek.Saturday || dt0.AddDays(m).DayOfWeek == DayOfWeek.Sunday)
                    {
                        temp = begA+"' style='color:#ff0000' title='点这里修改日程安排'>"+ temp2 + "</a>";
                    }
                    else
                    {
                        temp = begA + "' style='color:#000000' title='点这里修改日程安排'>" + temp2 + "</a>";
                    }

                    if (ht[dt0.AddDays(m).ToString("yyyy-MM-dd")] != null)
                    {
                        string temp0 = ht[dt0.AddDays(m).ToString("yyyy-MM-dd")].ToString();
                        string temp1 = temp0;
                        if (temp1.Length > 25)
                        {
                            temp1 = temp1.Substring(0, 25)+"…";
                        }
                        val1 = begA + "' title='"+temp0+"'>" +temp1+ "</A>";
                    }
                    this.tab1.Rows[i].Cells[j].InnerHtml = string.Format(tab0, temp,val1 );
                    m++;
                }
            }
        }

        //隐藏不显示的行
        if (this.tab1.Rows[this.tab1.Rows.Count - 1].Cells[0].InnerHtml.Trim()=="")
        {
            this.tab1.Rows[this.tab1.Rows.Count - 1].Visible = false; ;
        }
        
    }


    private Hashtable getCalenderData(int year,int month)
    {
        Hashtable ht = new Hashtable();
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_RCAP";
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("sname", User.Identity.Name));
        list1.Add(new SearchField("year(plantime)", year + "", SearchFieldType.数值型));
        list1.Add(new SearchField("month(plantime)", month + "", SearchFieldType.数值型));
        DataSet ds = comm1.SearchData("*", list1,"plantime");
        comm1.Close();
        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string ptime = DateTime.Parse(dt.Rows[i]["plantime"].ToString()).ToString("yyyy-MM-dd");
            string subject = "";
            if (dt.Rows[i]["subject"] != DBNull.Value)
            {
                subject = dt.Rows[i]["subject"].ToString();
            }
            ht[ptime] = subject;
        }
        return ht;

    }

    //过滤信息的显示方式
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.tab1.Rows[this.tab1.Rows.Count - 1].Visible = true;
        for (int i = 0; i < this.tab1.Rows.Count; i++)
        {
            for (int j = 0; j < this.tab1.Rows[i].Cells.Count; j++)
            {
                this.tab1.Rows[i].Cells[j].InnerHtml = "";
            }
        }
        this.SetTableInfo();
    }


}
