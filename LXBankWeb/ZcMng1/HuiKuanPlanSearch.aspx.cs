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

public partial class ZcMng1_HuiKuanPlanSearch : System.Web.UI.Page
{
    public double HeJi
    {
        get
        {
            if (ViewState["HeJi"] == null)
            {
                return 0;
            }
            else
            {
                return (double)ViewState["HeJi"];
            }
        }
        set
        {
            ViewState["HeJi"] = value;
        }
    }
    protected override void OnInit(EventArgs e)
    {
        this.SearchHuiKuanPlan1.SearchEvent += new EventHandler(SearchHuiKuanPlan1_SearchEvent);
        this.Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
        base.OnInit(e);
    }

    void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = e.Item.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            this.HeJi = this.HeJi + double.Parse(dr["pbj"].ToString());
        }
    }

    void SearchHuiKuanPlan1_SearchEvent(object sender, EventArgs e)
    {
        this.HeJi = 0;
        String condition = this.SearchHuiKuanPlan1.SearchCondition;
        String sql1 = "select top 500 * from ( ";
        sql1=sql1+" select CW_ShouKuanPlan.id,CW_ShouKuanPlan.zcid zcbid,zcid=null,";
        sql1=sql1+" u_zcbao.bzeren zeren,u_zcbao.bzeren1 zeren1,CW_ShouKuanPlan.time0,CW_ShouKuanPlan.pbj,";
        sql1=sql1+" CW_ShouKuanPlan.remark,u_username.depart,num2=null,bname danwei,kind,kind1='资产包'";
        sql1=sql1+" from CW_ShouKuanPlan ";
        sql1=sql1+" inner join u_zcbao on CW_ShouKuanPlan.zcid=u_zcbao.id ";
        sql1=sql1+" inner join u_username on u_zcbao.bzeren=u_username.sname ";
        sql1=sql1+ "where kind='1'";
        sql1=sql1+" union ";
        sql1=sql1+" select CW_ShouKuanPlan.id,zcbid=null,CW_ShouKuanPlan.zcid zcid,";
        sql1=sql1+" u_zc.zeren zeren,u_zc.zeren1 zeren1,CW_ShouKuanPlan.time0,CW_ShouKuanPlan.pbj, ";
        sql1 = sql1 + " CW_ShouKuanPlan.remark,u_username.depart,num2,danwei,kind ,kind1='资产'";
        sql1=sql1+" from CW_ShouKuanPlan ";
        sql1=sql1+" inner join u_zc on CW_ShouKuanPlan.zcid=u_zc.id ";
        sql1=sql1+" inner join u_username on u_zc.zeren=u_username.sname ";
        sql1=sql1+" where kind='0') a ";

        if (String.IsNullOrEmpty(condition) == false)
        {
            sql1 = sql1 + " where " + condition;
        }
        sql1 = sql1 + " order by time0 desc";

        
        this.SearchInfo.Visible = true;
        CommTable com1 = new CommTable();
        DataSet ds1 = com1.TableComm.SearchData(sql1);
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();

        com1.Close();
        
    }

  

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        this.heji.Text = this.HeJi.ToString("n");
        base.OnPreRender(e);
    }
}
