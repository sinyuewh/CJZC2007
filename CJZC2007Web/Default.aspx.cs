using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections.Generic;
using System.Collections;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.username.Text = User.Identity.Name;
            this.SetPageInfo();
            this.SetLawPage();
            
        }
    }

    private void SetPageInfo()
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "UserLogin";
        //U_RolesBU role1 = new U_RolesBU();
        
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("UserName", User.Identity.Name));
        DataSet ds = comm1.SearchData("loginCount", list1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.labLogin.Text = ds.Tables[0].Rows[0]["loginCount"].ToString();
        }
        else
        {
            this.labLogin.Text = "1";
        }


        //设置未读邮件
        comm1.TabName = "ZX_Email";
        list1.Clear();
        list1.Add(new SearchField("to1", User.Identity.Name));
        list1.Add(new SearchField("readcount", "",SearchOperator.空值));
        ds.Clear();
        ds=comm1.SearchData("count(*)",list1);
        this.HypEmail.Text = ds.Tables[0].Rows[0][0].ToString();
        
        //设置未读消息
        comm1.TabName = "ZX_QuickTalk";
        list1.Clear();
        list1.Add(new SearchField("tmen", User.Identity.Name));
        list1.Add(new SearchField("isRead", "0", SearchFieldType.数值型));
        ds.Clear();
        ds = comm1.SearchData("count(*)", list1);
        this.HypMessage.Text = ds.Tables[0].Rows[0][0].ToString();

        //资产批阅申请
        comm1.TabName = "U_ZCSP";
        list1.Clear();
        list1.Add(new SearchField("zeren", User.Identity.Name));
        list1.Add(new SearchField("time1", "", SearchOperator.空值));
        ds.Clear();
        ds = comm1.SearchData("distinct czid", list1);
        if(ds.Tables[0].Rows.Count>0)
        {
            this.HyperZc.Text = ds.Tables[0].Rows.Count+"";
        }


        //设置今天工作安排
        comm1.TabName = "ZX_RCAP";
        list1.Clear();
        list1.Add(new SearchField("sname", User.Identity.Name));
        list1.Add(new SearchField("year(plantime)", DateTime.Now.Year+"", SearchFieldType.数值型));
        list1.Add(new SearchField("month(plantime)", DateTime.Now.Month+"", SearchFieldType.数值型));
        list1.Add(new SearchField("day(plantime)", DateTime.Now.Day+"", SearchFieldType.数值型));
        ds.Clear();
        ds = comm1.SearchData("distinct id,subject", list1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.HypToday.Text = ds.Tables[0].Rows[0]["subject"].ToString();
            this.HypToday.NavigateUrl = "~/Info/RcanpaiDetails.aspx?id=" + ds.Tables[0].Rows[0]["id"].ToString();
        }

        //计算本周的日程安排
        ds.Clear();
        list1.Clear();
        list1.Add(new SearchField("sname", User.Identity.Name));
        DateTime dt1 = DateTime.Now.Date;
        int day1 = (int)dt1.DayOfWeek;
        string begtime = dt1.AddDays(-day1).ToString("yyyy-MM-dd");
        string endtime = dt1.AddDays(6 - day1).ToString("yyyy-MM-dd")+" 23:59:59";
        list1.Add(new SearchField("plantime", begtime, SearchOperator.大于等于));
        list1.Add(new SearchField("plantime", endtime, SearchOperator.小于等于));
        DataSet  ds1 = comm1.SearchData("*", list1, "plantime");
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();


        //设置在线用户
        Hashtable ht = (Hashtable)Application["OnLineUser"];
        this.DataList1.DataSource = ht;
        this.DataList1.DataBind();


        U_RolesBU role1 = new U_RolesBU();
        //设置个人时效警告数据
        string sql = @"select U_Zctime.* from U_Zctime inner join U_ZC
                    On U_zctime.zcid=U_ZC.id and U_ZC.zeren='{0}'
                    AND U_Zctime.time0 is not null and DateAdd(dd,-tellday,U_Zctime.time0)<getdate()";
        sql = String.Format(sql, User.Identity.Name);
        ds.Clear();
        ds = comm1.TableComm.SearchData(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.HypTime1.Text = ds.Tables[0].Rows.Count+"";
        }

        //设置部门时效的数据
        bool check1 = role1.isRole("资产部门领导");
        if (check1 == false)
        {
            this.BLeader.Visible = false;
        }
        else
        {
            sql = @"select U_Zctime.* from U_Zctime inner join U_ZC
                    On U_zctime.zcid=U_ZC.id 
                    inner join U_UserName on U_zc.zeren=u_username.sname
                    inner join U_depart on u_username.depart=U_depart.depart
                    where ( U_UserName.sname='{0}' or U_Username.leader='{1}')
                    AND U_Zctime.time0 is not null and 
                    DateAdd(dd,-tellday,U_Zctime.time0)<getdate()";
            sql = String.Format(sql, User.Identity.Name,User.Identity.Name);
            ds.Clear();
            ds = comm1.TableComm.SearchData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.HypTime2.Text = ds.Tables[0].Rows.Count + "";
            }
        }

        comm1.Close();
    }

    
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HyperLink link1 = e.Item.FindControl("HyperLink1") as HyperLink;
        if (link1 != null)
        {
            DictionaryEntry data1 = (DictionaryEntry)e.Item.DataItem;
            if (data1.Value.ToString()!= User.Identity.Name)
            {
                link1.NavigateUrl = String.Format("javascript:SendMessage('{0}');",data1.Value);
            }
        }

    }

    private void SetLawPage()
    {
        bool isLaw = this.isOnlyLaw();
        if (isLaw)
        {
            this.count3.Visible = false;
            this.count4.Visible = false;
            this.count5.Visible = false;
            this.count6.Visible = false;
            this.count7.Visible = false;
            this.BLeader.Visible = false;
        }
    }

    //判断当前用户是否只有法律顾问
    private bool isOnlyLaw()
    {
        return LawBU.isOnlyLaw();
    }
}
