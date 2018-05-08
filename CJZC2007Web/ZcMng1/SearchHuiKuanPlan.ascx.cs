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

public partial class ZcMng1_SearchHuiKuanPlan : System.Web.UI.UserControl
{
    public event EventHandler SearchEvent;
    public String SearchCondition
    {
        get
        {
            if (ViewState["SearchCondition"] == null)
            {
                return String.Empty;
            }
            else
            {
                return ViewState["SearchCondition"].ToString();
            }
        }
        set
        {
            ViewState["SearchCondition"] = value;
        }
    }

    public bool IsAllSeeMember
    {
        get
        {
            if (ViewState["IsAllSeeMember"] == null)
            {
                return false;
            }
            else
            {
                return (bool)ViewState["IsAllSeeMember"];
            }
        }
        set
        {
            ViewState["IsAllSeeMember"] = value;
        }
    }

    public String AllSelectPerson
    {
        get
        {
            if (ViewState["AllSelectPerson"] == null)
            {
                return String.Empty;
            }
            else
            {
                return ViewState["AllSelectPerson"].ToString();
            }
        }
        set
        {
            ViewState["AllSelectPerson"] = value;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        //this.depart.SelectedIndexChanged += new EventHandler(depart_SelectedIndexChanged);
        this.quickSelect.SelectedIndexChanged += new EventHandler(quickSelect_SelectedIndexChanged);
        this.Button1.Click += new EventHandler(Button1_Click);
        this.time1.Attributes["onfocus"] = "setday(this)";
        this.time2.Attributes["onfocus"] = "setday(this)";
        base.OnInit(e);
    }

    void quickSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        String value1 = this.quickSelect.SelectedValue;
        if (value1 == "")
        {
            this.time1.Text = "";
            this.time2.Text = "";
        }
        else if (value1 == "0")
        {
            this.time1.Text = DateTime.Today.ToString("yyyy-MM-dd");
            this.time2.Text = this.time1.Text;
        }
        else if (value1 == "1")
        {
            this.time2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            this.time1.Text = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd");
        }
        else if (value1 == "2")   //本周
        {
            int day1 = (int)DateTime.Now.DayOfWeek;
            this.time1.Text = DateTime.Today.AddDays(-day1).ToString("yyyy-MM-dd");
            this.time2.Text = DateTime.Today.AddDays(6 - day1).ToString("yyyy-MM-dd");
        }
        else if (value1 == "3")  //本月
        {
            int year1 = DateTime.Now.Year;
            int year2 = year1;

            int month1 = DateTime.Now.Month;
            int month2 = month1;

            if (month1 == 12)
            {
                year2 = year1 + 1;
                month2 = 1;
            }
            else
            {
                month2++;
            }

            this.time1.Text = DateTime.Parse(year1 + "-" + month1 + "-1").ToString("yyyy-MM-dd");
            this.time2.Text = DateTime.Parse(year2 + "-" + month2 + "-1").AddDays(-1).ToString("yyyy-MM-dd");
        }
        else
        {
            int year1 = DateTime.Now.Year;
            this.time1.Text = year1 + "-01-01";
            this.time2.Text = year1 + "-12-31";
        }
    }

    void Button1_Click(object sender, EventArgs e)
    {
        String Condition = " (1 =1 ) ";

        #region Code1
        /*
        if (this.depart.SelectedValue != "")
        {
            Condition = Condition + " and ( u_username.depart='" + this.depart.SelectedValue + "') ";
        }
        
        //选择人的问题
        String selPerson1 = String.Empty;
        if (this.IsAllSeeMember)
        {
            if (this.zeren.SelectedValue != "")
            {
                selPerson1 = JSJ.SysFrame.Util.GetControlValue(this.zeren);
            }
        }
        else
        {
            if (this.zeren1.SelectedValue != "")
            {
                selPerson1 = JSJ.SysFrame.Util.GetControlValue(this.zeren1);
            }
            else
            {
                selPerson1 = this.AllSelectPerson;  //所有的可选人员
            }
        }

        if (String.IsNullOrEmpty(selPerson1) == false)
        {
            selPerson1 = "'" + selPerson1.Replace(",", "','") + "'";
            Condition = Condition + " and ( u_zctc.zeren in (" + selPerson1 + ")) ";
        }*/
        #endregion

        //设置人员的浏览范围
        if (this.IsAllSeeMember==false)
        {
            List<string> list1 = JSJ.CJZC.Business.Comm.GetMyPersonList1(Page.User.Identity.Name);
            String person1 = "";
            foreach (String m in list1)
            {
                if (person1 == "")
                {
                    person1 = m;
                }
                else
                {
                    person1 = person1 + "," + m;
                }
            }
            
            Condition = Condition + " and ( zeren in ('" + person1.Trim()+"' ) or zeren1='"+Page.User.Identity.Name+"' )";
        }

        //选择时间的问题
        if (this.time1.Text != String.Empty)
        {
            Condition = Condition + " and ( time0>='" + this.time1.Text + "') ";
        }

        if (this.time2.Text != String.Empty)
        {
            Condition = Condition + " and ( time0<='" + this.time2.Text + " 23:59:59') ";
        }

        //选择资产的类别
        if (this.kind.SelectedValue!= String.Empty)
        {
            Condition = Condition + " and ( kind='" + this.kind.SelectedValue + "') ";
        }

        this.SearchCondition = Condition;
        //Response.Write(Condition);
        if (SearchEvent != null)
        {
            SearchEvent(this, new EventArgs());
        }

    }

    void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "");*/
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_RolesBU role1 = new U_RolesBU();
            String[] arr1 = new String[] { "系统管理员", "公司领导", "资产评审员" };
            bool isAllSee = role1.isRole(arr1);
            this.IsAllSeeMember = isAllSee;

            this.time2.Text = DateTime.Parse((DateTime.Today.Year+1)+"-1-1").AddDays(-1).ToString("yyyy-MM-dd");
            this.time1.Text = DateTime.Today.Year+"-1-1";

            //isAllSee = false;
            if (isAllSee == false)
            {
               // this.Row1.Visible = false;
               // this.Row2.Visible = true;
            }
            else
            {
               // this.Row1.Visible = true;
               // this.Row2.Visible = false;
            }

            //设置人员1和人员2
            /*
            this.SetMyData();
            List<String> list1 = JSJ.CJZC.Business.Comm.GetMyPersonList(Page.User.Identity.Name);
            if (list1.Count > 0)
            {
                this.zeren1.DataSource = list1;
                this.zeren1.DataBind();
                String temp1 = String.Empty;
                foreach (String m in list1)
                {
                    if (temp1 == String.Empty)
                    {
                        temp1 = m;
                    }
                    else
                    {
                        temp1 = temp1 + "," + m;
                    }
                }
                this.AllSelectPerson = temp1;
            }*/
        }
    }

    
    /// <summary>
    /// 初始化代码
    /// </summary>
    private void SetMyData()
    {
        /*
        Comm.SetDepart(this.depart, "所有部门");
        this.depart.SelectedValue = "";
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "");*/
    }
}
