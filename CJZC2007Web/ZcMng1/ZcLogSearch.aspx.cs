using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;

public partial class ZcMng1_ZcLogSearch : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.SearchZcLog1.SearchEvent += new EventHandler(SearchZcLog1_SearchEvent);
        this.Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
        base.OnInit(e);
    }

    //处理特殊的显示信息
    void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = e.Item.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            Label lab1 = e.Item.FindControl("kindCaption") as Label;
            String kind1 = dr["kind"].ToString();
            if (lab1 != null)
            {
                if (kind1 == "01")
                {
                    lab1.Text = "尽职调查-阅卷";
                }
                else if (kind1 == "02")
                {
                    lab1.Text = "尽职调查-下户";
                }
                else if (kind1 == "03")
                {
                    lab1.Text = "尽职调查-取证";
                }
                else if (kind1 == "04")
                {
                    lab1.Text = "尽职调查-报告";
                }
                else if (kind1 == "2")
                {
                    lab1.Text = "方案执行-"+dr["status1"].ToString().Trim();
                }
                else
                {
                }
            }


            //判断责任人
            String zeren1 = dr["zeren"].ToString();
            U_UserNameBU u1 = new U_UserNameBU();
            bool isLeader = false;
            String leader1 = u1.GetDirLeader(zeren1);
            if (leader1 == Page.User.Identity.Name)
            {
                isLeader = true;
            }

            Control con1 = e.Item.FindControl("info1") as Control;
            if (con1 != null)
            {
                con1.Visible = isLeader;
            }
        }
    }

    void SearchZcLog1_SearchEvent(object sender, EventArgs e)
    {
        String condition = this.SearchZcLog1.SearchCondition;
        String sql1 = "select top 500 u_zctc.*,left(u_zctc.remark,100) remark1,u_username.depart,fcount=0,u_zc.danwei from u_zctc ";
        sql1 = sql1 + " inner join u_username on u_zctc.zeren=u_username.sname inner join u_zc on u_zctc.zcid=u_zc.id ";
        sql1=sql1+" where ((u_zctc.kind='2' and u_zctc.status1 is not null) or u_zctc.kind<>'2') ";
        if (String.IsNullOrEmpty(condition) == false)
        {
            sql1 = sql1 + " and "+condition;
        }
        sql1 = sql1 + " order by u_zctc.time0 desc";
       // Response.Write(sql1);

        this.SearchInfo.Visible = true;
        CommTable com1 = new CommTable();
        DataSet ds1=com1.TableComm.SearchData(sql1);
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();

        com1.Close();

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnUnload(EventArgs e)
    {
       // JSJ.SysFrame.DB.SinConnect
        base.OnUnload(e);
    }
}
