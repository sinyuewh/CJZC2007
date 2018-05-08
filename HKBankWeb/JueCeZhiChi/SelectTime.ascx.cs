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

public partial class JueCeZhiChi_selectTime : System.Web.UI.UserControl
{
    #region 属性定义
    //统计的开始时间段
    string dt1 = "";
    public string BeginTime
    {
        get
        {
            return this.dt1;
        }
    }

    
    //统计的结束时间段
    string dt2 = "";
    public string EndTime
    {
        get
        {
            return this.dt2;
        }
    }

    //统计年
    int byear = -1;
    public int StaticYear
    {
        get
        {
            return byear;
        }
    }


    //统计月
    int bmonth = -1;
    public int StaticMonth
    {
        get
        {
            return this.bmonth;
        }
    }

    //统计季度
    int bjidu = -1;
    public int StaticJidu
    {
        get
        {
            return this.bjidu;
        }
    }

    //统计方式
    private SearchStaticType statictype ;
    public SearchStaticType StaticType
    {
        get
        {
            return this.statictype;
        }
    }

    public event EventHandler StaticEvent;
    #endregion

    /// <summary>
    /// 发送事件
    /// </summary>
    private void onStaticEvent()
    {
        if (StaticEvent != null)
        {
            StaticEvent(this, new EventArgs());
        }
    }


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


    //按年统计
    protected void butSt4_Click(object sender, EventArgs e)
    {
        this.byear =  int.Parse(this.byear3.SelectedValue);
        this.dt1 = this.byear + "-1-1";
        this.dt2 = this.byear + "-12-31";
        this.statictype = SearchStaticType.按年统计;
        this.onStaticEvent();
    }

    //按月统计
    protected void butSt2_Click(object sender, EventArgs e)
    {
        this.byear = int.Parse(this.byear1.SelectedValue);
        this.bmonth = int.Parse(this.bmonth1.SelectedValue);
        this.dt1 = this.byear + "-"+this.bmonth+"-1";

        int y1 = this.byear;
        int m1 = this.bmonth;
        if (m1 == 12)
        {
            y1++;
        }
        else
        {
            m1++;
        }
        this.dt2 = DateTime.Parse(y1 + "-" + m1 + "-1").AddDays(-1).ToString("yyyy-MM-dd");

        this.statictype = SearchStaticType.按月统计;
        this.onStaticEvent();
    }

    //按季统计
    protected void butSt3_Click(object sender, EventArgs e)
    {
        int y1 = int.Parse(this.byear2.SelectedValue);
        this.byear = y1;

        int jd1 = int.Parse(this.jidu.SelectedValue);
        this.bjidu = jd1;

        int m1 = (jd1 - 1) * 3 + 1;
        this.dt1 = y1 + "-" + m1 + "-1";

        int m2 = m1 + 2;
        if (m2 == 12)
        {
            y1++;
        }
        else
        {
            m2++;
        }
        this.dt2 = DateTime.Parse(y1 + "-" + m2 + "-1").AddDays(-1).ToString("yyyy-MM-dd");
        this.statictype = SearchStaticType.按季度统计;
        this.onStaticEvent();
    }

    //按用户自定义时间统计
    protected void butSt1_Click(object sender, EventArgs e)
    {
        this.dt1 = this.time1.Text;
        this.dt2 = this.time2.Text;
        this.statictype = SearchStaticType.按用户自定义时间统计;
        this.onStaticEvent();
    }
}
