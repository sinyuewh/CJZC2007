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
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class JueCeZhiChi_StatHuiKuanInfo : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        string time0 = Request.QueryString["dt1"].Trim();
        string time1 = Request.QueryString["dt2"].Trim();
        string depart = Request.QueryString["depart"].Trim();
        string zeren = Request.QueryString["zeren"].Trim();
        CW_ShouKuanBU sk1 = new CW_ShouKuanBU();
        DataSet ds1 = sk1.GetShoukuanBillBySearchData(time0, time1, depart, zeren,0);
        DataView dv = ds1.Tables[0].DefaultView;
        dv.Sort = "danwei";
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();


        string ids = "";
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            ids = ids + dr["zcid"].ToString();
            ids = ids + ",";
        }
        //Response.Write(ids);


        DataSet ds2 = sk1.GetShoukuanBillBySearchData(time0, time1, depart, zeren, 1);
        this.GridView2.DataSource = ds2;
        this.GridView2.DataBind();
    }

    #region 以往代码
    private void BindData1()
    {
        CW_ShouKuanBU sk1 = new CW_ShouKuanBU();
        if (Request["zcid"] != null && Request["zcid"].ToString() != "")
        {
            DataSet ds1 = sk1.GetBillByID("0",Request["zcid"].ToString());
            
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds1.Tables[0].NewRow();
                dr["danwei1"] = "合计";

                dr["bxhj"] = "0";
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j]["bxhj"].ToString() != "" && ds1.Tables[0].Rows[j]["bxhj"] != null)
                    {
                        dr["bxhj"] = double.Parse(dr["bxhj"].ToString()) + double.Parse(ds1.Tables[0].Rows[j]["bxhj"].ToString());
                    }
                }
                ds1.Tables[0].Rows.Add(dr);
            }
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
        }


        if (Request["bid"] != null && Request["bid"].ToString() != "")
        {
            DataSet ds2 = sk1.GetBillByID("2", Request["bid"].ToString());
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds2.Tables[0].NewRow();
                dr["bname"] = "合计";

                dr["bxhj"] = "0";
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    if (ds2.Tables[0].Rows[j]["bxhj"].ToString() != "" && ds2.Tables[0].Rows[j]["bxhj"] != null)
                    {
                        dr["bxhj"] = double.Parse(dr["bxhj"].ToString()) + double.Parse(ds2.Tables[0].Rows[j]["bxhj"].ToString());
                    }
                }
                ds2.Tables[0].Rows.Add(dr);
            }
            this.GridView2.DataSource = ds2;
            this.GridView2.DataBind();
        }
    }
    #endregion


}
