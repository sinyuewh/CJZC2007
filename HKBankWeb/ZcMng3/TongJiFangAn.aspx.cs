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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;

public partial class ZcMng3_TongJiFangAn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["tjkind"] == "0")
            {
                this.tjkind.Text = "单个资产";
            }
            else
            {
                this.tjkind.Text = "资产包";
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.SelectTime1.StaticEvent += new EventHandler(SelectTime1_StaticEvent);
        base.OnInit(e);
    }

    void SelectTime1_StaticEvent(object sender, EventArgs e)
    {
        String time0 = this.SelectTime1.BeginTime;
        String time1 = this.SelectTime1.EndTime;

        /*
        this.lt1.Text = time0;
        this.lt2.Text = time1;

        this.repeater1.DataSource = this.GetTongJiData(time0, time1);
        this.repeater1.DataBind();

        this.SearchTable.Visible = false;
        this.SearchInfo.Visible = true;*/

        Response.Write("<Script language='javascript'>");
        Response.Write("var hid1=window.screen.availHeight-10;");
	    Response.Write("var wid1=window.screen.availWidth-10;");
        Response.Write(String.Format("window.open(\"FangAnChuZhiTongJi.aspx?tjkind={0}&time0={1}&time1={2}\",\"\",\"location=no,Status=no,Menubar=yes,Scrollbars=yes,resizable=yes,left=5,top=5\");",Request["tjkind"],time0,time1));
        Response.Write("</Script>");
    }


    /// <summary>
    /// 统计方案数据
    /// </summary>
    /// <param name="time0"></param>
    /// <param name="time1"></param>
    /// <returns></returns>
    private DataSet GetTongJiData(String time0, String time1)
    {
        DataSet ds0 = new DataSet();
        DataTable dt0 = new DataTable("Table0");
        ds0.Tables.Add(dt0);

        dt0.Columns.Add("depart");
        for (int i = 1; i <= 12; i++)
        {
            dt0.Columns.Add("num" + i);
        }
       
        List<SearchField> condition = new List<SearchField>();
        if (time0.Trim() != String.Empty)
        {
            condition.Add(new SearchField("shijian1", time0, SearchOperator.大于等于));
        }
        if (time1.Trim() != String.Empty)
        {
            condition.Add(new SearchField("shijian1", time1, SearchOperator.小于等于));
        }
        //设置查询范围
        U_RolesBU role1 = new U_RolesBU();
        bool isAllCanSee = role1.isRole(new string[] { "公司领导", "评审部角色","会计", "出纳", "领导秘书" });
        role1.Close();
        //1)公司领导、会计、出纳、领导秘书 可查询所有的项目
        if (isAllCanSee == false)
        {
            //普通的用户只能查询自己负责（或下属负责的项目）
            List<SearchField> condition1 = new List<SearchField>();
            U_UserNameBU user1 = new U_UserNameBU();
            String userName1 = user1.GetSelfAndXiaShu(User.Identity.Name);
            user1.Close();
            if (userName1 != String.Empty)
            {
                condition.Add(new SearchField("zeren", userName1, SearchOperator.集合));
            }
        }


        //2)统计新数据
        int[] sum1 = new int[12];
        String fdepart = "";
        CommTable comm1 = new CommTable();   
        comm1.TabName= "U_ZC2";
        DataSet ds1 = comm1.SearchData("id,depart,status,spstatus,spkind", condition, "depart");
        DataRow dr1=null;
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            if (dr["depart"].ToString().Trim() != fdepart)
            {
                if (dr1 != null)
                {
                    ds0.Tables[0].Rows.Add(dr1);
                }
                //设置初值
                dr1 = ds0.Tables[0].NewRow();
                dr1["depart"] = dr["depart"];
                fdepart = dr["depart"].ToString().Trim();
                for (int i = 1; i <= 12; i++)
                {
                    dr1["num" + i] = 0;
                }
            }

            //设置值
            String spstatus = dr["spstatus"].ToString().Trim();
            if (spstatus == "0")
            {
                dr1["num1"] = int.Parse(dr1["num1"].ToString()) + 1;
                sum1[0] += 1;
            }
            else if (spstatus == "1")
            {
                dr1["num2"] = int.Parse(dr1["num2"].ToString()) + 1;
                dr1["num4"] = int.Parse(dr1["num4"].ToString()) + 1;
                sum1[1] += 1;
                sum1[3] += 1;
            }
            else if (spstatus == "2")
            {
                dr1["num3"] = int.Parse(dr1["num3"].ToString()) + 1;
                dr1["num4"] = int.Parse(dr1["num4"].ToString()) + 1;
                sum1[2] += 1;
                sum1[3] += 1;
            }

            String status = dr["status"].ToString().Trim();
            if (status == "21")
            {
                dr1["num5"] = int.Parse(dr1["num5"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[4] += 1;
                sum1[11] += 1;
            }
            else if (status == "22")
            {
                dr1["num6"] = int.Parse(dr1["num6"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[5] += 1;
                sum1[11] += 1;
            }
            else if (status == "23")
            {
                dr1["num7"] = int.Parse(dr1["num7"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[6] += 1;
                sum1[11] += 1;
            }
            else if (status == "24")
            {
                dr1["num8"] = int.Parse(dr1["num8"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[7] += 1;
                sum1[11] += 1;
            }
            else if(status=="25")
            {
                dr1["num9"] = int.Parse(dr1["num9"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[8] += 1;
                sum1[11] += 1;
            }
            else if (status == "26")
            {
                dr1["num10"] = int.Parse(dr1["num10"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[9] += 1;
                sum1[11] += 1;
            }
            else if (status == "27")
            {
                dr1["num11"] = int.Parse(dr1["num11"].ToString()) + 1;
                dr1["num12"] = int.Parse(dr1["num12"].ToString()) + 1;
                sum1[10] += 1;
                sum1[11] += 1;
            }
            else
            {
                ;
            }
            
        }

        if (dr1 != null)
        {
            ds0.Tables[0].Rows.Add(dr1);

            dr1 = ds0.Tables[0].NewRow();
            dr1["depart"] = "合计";
            for (int i = 1; i <= 12; i++)
            {
                dr1["num" + i] = sum1[i - 1];
            }
            ds0.Tables[0].Rows.Add(dr1);
        }
        comm1.Close();
        return ds0;
    }


    protected void but1_Click(object sender, EventArgs e)
    {
        Response.Redirect("TongJiFangAn.aspx", true);
    }
}
