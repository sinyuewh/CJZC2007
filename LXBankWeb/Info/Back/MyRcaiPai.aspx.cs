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
            Page.DataBind();
            this.BindData();
        }
        this.begtime.Attributes["onfocus"] = "javaScript:setday(this);";
        this.endtime.Attributes["onfocus"] = "javaScript:setday(this);";
        this.seltime.Attributes["onChange"] = "javaScript:selectTime(this.value);";
        this.CalTime();
    }

    private void CalTime()
    {
        DateTime dt1 = DateTime.Now.Date;
        int day1 = (int)dt1.DayOfWeek;
        this.zt1 = dt1.AddDays(-day1).ToString("yyyy-MM-dd");
        this.zt2 = dt1.AddDays(6 - day1).ToString("yyyy-MM-dd");

        this.mt1 = dt1.Year + "-" + dt1.Month + "-1";
        int y1 = dt1.Year;
        int m1 = dt1.Month;
        if (m1 == 12)
        {
            m1 = 1;
            y1++;
        }
        else
        {
            m1++;
        }
        this.mt2 = DateTime.Parse(m1 + "-" + m1 + "-1").AddDays(-1).ToString("yyyy-MM-dd") ;

       this.yt1= dt1.Year + "-1-1";
       this.yt2 = dt1.Year + "-12-31" ;
               
    }

    //过滤信息的显示方式
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindData();
    }


    private void BindData()
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_RCAP";
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("sname", User.Identity.Name));
        if (this.begtime.Text != "")
        {
            list1.Add(new SearchField("plantime", this.begtime.Text, SearchOperator.大于等于));
        }

        if (this.endtime.Text != "")
        {
            list1.Add(new SearchField("plantime", this.endtime.Text+" 23:59:59", SearchOperator.小于等于));
        }
        DataSet ds = comm1.SearchData("*", list1,"plantime desc");

        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        comm1.Close();

    }


    //增加数据
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("RcanpaiDetails.aspx", true);
    }

    //删除选中的数据
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.Form["seldoc"]) == false)
        {
            string ids = Request.Form["seldoc"];
            CommTable comm1 = new CommTable();
            comm1.TabName = "ZX_RCAP";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", User.Identity.Name));
            list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
            comm1.DeleteData(list1);
            comm1.Close();

            this.BindData();
        }
    }
}
