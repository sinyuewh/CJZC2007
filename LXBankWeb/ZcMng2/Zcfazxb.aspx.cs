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
using JSJ.SysFrame;

public partial class ZcMng2_Zcfazxb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            this.BindTC(null);
            this.BindSSQK();
        }
    }

    #region 绑定资产调查的明细内容
    private void BindData()
    {
        if (Request["zcid"] != null)
        {
            string id = Request["zcid"];
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetDetailByID(id, "depart,zeren,status,statusText,danwei");
            zc1.Close();


            this.danwei.Text = ds.Tables[0].Rows[0]["danwei"].ToString();
            this.depart.Text = ds.Tables[0].Rows[0]["depart"].ToString();
            this.zeren.Text = ds.Tables[0].Rows[0]["zeren"].ToString();
            this.status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            this.statusText.Text = ds.Tables[0].Rows[0]["statusText"].ToString();
            if (this.statusText.Text == "")
            {
                this.statusText.Text = "阅卷";
            }
            ds.Dispose();
        }
    }

    private void BindSSQK()
    {
        if (Request["zcid"] != null)
        {
            U_ZCBU zc2 = new U_ZCBU();
            DataSet ds = zc2.GetZCDBInfoByID(Request["zcid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.lssws.Text = ds.Tables[0].Rows[0]["lssws"].ToString();
                this.frdb.Text = ds.Tables[0].Rows[0]["frdb"].ToString();
                this.wtls.Text = ds.Tables[0].Rows[0]["wtls"].ToString();
                this.lxdh.Text = ds.Tables[0].Rows[0]["lxdh"].ToString();
                this.dwdz.Text = ds.Tables[0].Rows[0]["dwdz"].ToString();
                this.dzyj.Text = ds.Tables[0].Rows[0]["dzyj"].ToString();
                ds.Dispose();
            }
            zc2.Close();
        }
    }

    private void BindTC(U_ZCTCBU tc1)
    {
        bool flag = false;
        if (tc1 == null)
        {
            tc1 = new U_ZCTCBU();
            flag = true;
        }

        for (int i = 1; i <= 7; i++)
        {
            Repeater repeater1 = this.Repeater1.Parent.FindControl("Repeater" + i) as Repeater;
            if (repeater1 != null)
            {
                DataSet ds1 = tc1.GetTCList("2" + i, Request["zcid"]);
                repeater1.DataSource = ds1;
                repeater1.DataBind();

                if (ds1.Tables[0].Rows.Count == 0)
                {
                    repeater1.Visible = false;
                }
            }
        }
        if (flag)
        {
            tc1.Close();
        }
    }

    #endregion

}
