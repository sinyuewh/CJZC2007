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

public partial class ZcMng2_ZcDetail6 : System.Web.UI.Page
{
    bool zcMng = false;
    protected void Page_Load(object sender, EventArgs e)
    {       
        zcMng = Comm.IsZcMng(Request["id"], User.Identity.Name);  //得到权限
        if (!Page.IsPostBack)
        {
            this.BindData();

            //控制时效的增加权限
            if (this.zcMng == false)
            {
                this.butAdd.Visible = false;
            }
            if (Comm.IsRole("系统管理员"))
            {
                this.Button2.Visible = true;
            }
            else
            {
                this.Button2.Visible = false;
            }
        }
    }


    private void BindData()
    {
        if (Request["id"] != null)
        {
            U_ZCTimeBU time1 = new U_ZCTimeBU();
            DataSet ds1 = time1.GetTimeListByParentID(Request["id"]);
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();
            time1.Close();
            ds1.Dispose();

            string id = Request["id"];
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetDetailByID(id,"danwei");
            this.depart.Text = ds.Tables[0].Rows[0][0].ToString();
            zc1.Close();
        }
    }

    private void BindData(U_ZCTimeBU time1)
    {
        if (Request["id"] != null)
        {
            DataSet ds1 = time1.GetTimeListByParentID(Request["id"]);
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();
            ds1.Dispose();
        }
    }

    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            DataRow dr = ((DataRowView)e.Item.DataItem).Row;

            if (dr["ZcTime0"] != DBNull.Value && dr["ZcTime0"].ToString() != "" && dr["ZcTime"] != DBNull.Value && dr["ZcTime"].ToString() != "")
            {
                DateTime dt = (DateTime)dr["ZcTime0"];
                DateTime dt1 = (DateTime)dr["ZcTime"];

                if (dt.CompareTo(DateTime.Now) < 0)
                {

                    TimeSpan sp1 = (dt1 - DateTime.Now);
                    int day1 = sp1.Days;
                    if (day1 <= 30)
                    {
                        ((Literal)e.Item.FindControl("redStar")).Text = "<font color='#ff0000'>★</font><font color='#ff0000'>★</font><font color='#ff0000'>★</font>";
                    }
                    else
                    {
                        if (day1 <= 60)
                        {
                            ((Literal)e.Item.FindControl("redStar")).Text = "<font color='#ff0000'>★</font><font color='#ff0000'>★</font>";
                        }
                        else
                        {
                            ((Literal)e.Item.FindControl("redStar")).Text = "<font color='#ff0000'>★</font>";
                        }
                    }
                }
            }




            //控制编辑和删除的权限
            LinkButton link1 = e.Item.FindControl("butEdit") as LinkButton;
            LinkButton link2 = e.Item.FindControl("butDel") as LinkButton;
            if (this.zcMng == false)
            {
                link1.Visible = false;
                link2.Visible = false;
            }
        }
    }


    protected void Repeater1_Command(object sender, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("infoid") != null)
        {
            Literal liter1 = e.Item.FindControl("infoid") as Literal;
            string timeid = liter1.Text;

            if (e.CommandName == "delete")
            {
                U_ZCTimeBU time1 = new U_ZCTimeBU();
                time1.DelTimeData(timeid);
                this.BindData(time1);
                time1.Close();
            }
            else
            {
                Response.Redirect("EditTime.aspx?tcid="+timeid,true);
            } 
        }
    }

    //Add Time 
    protected void butAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddTime.aspx?parentid=" + Request["id"],true);
    }
}
