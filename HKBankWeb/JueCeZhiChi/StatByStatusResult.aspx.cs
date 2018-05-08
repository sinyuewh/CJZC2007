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
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;

public partial class JueCeZhiChi_StatByStatusResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            if (HttpContext.Current.Items["SearchCondition"] != null)
            {
                ViewState["SearchCondition"] = HttpContext.Current.Items["SearchCondition"];
                ViewState["SearchKind"] = HttpContext.Current.Items["SearchKind"];
                this.BindData();
            }
            else
            {
                Response.Redirect(Application["root"]+"JueCeZhiChi/StatByStatus.aspx", true);
            }
        }
    }
    private void BindData()
    {
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition"];
        U_ZCBU zc1 = new U_ZCBU();

        DataSet ds1 = zc1.GetDetailByID(list1, "*,isnull(pbj,0)+isnull(plx,0) as hbxh,isnull(bj,0)+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) as bxh,isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0)+isnull(fee13,0)+isnull(fee14,0)+isnull(fee15,0)+isnull(fee16,0)+isnull(fee17,0)+isnull(fee18,0)+isnull(fee19,0)+isnull(fee20,0) as fyhj");
        zc1.Close();

        this.hs.Text = ds1.Tables[0].Rows.Count.ToString();
        double bxh1 = 0;
        double bxh2 = 0;
        double hbxh1 = 0;
        double hbxh2 = 0;
        double fyhj = 0;
        string id = "";
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            if (ds1.Tables[0].Rows[i]["huobi"].ToString() == "美元")
            {
                bxh2 = bxh2 + double.Parse(ds1.Tables[0].Rows[i]["bxh"].ToString());
                hbxh2 = hbxh2 + double.Parse(ds1.Tables[0].Rows[i]["hbxh"].ToString());
            }
            else
            {
                bxh1 = bxh1 + double.Parse(ds1.Tables[0].Rows[i]["bxh"].ToString());
                hbxh1 = hbxh1 + double.Parse(ds1.Tables[0].Rows[i]["hbxh"].ToString());
            }


            fyhj = fyhj + double.Parse(ds1.Tables[0].Rows[i]["fyhj"].ToString());
            if (i == 0)
            {
                id = ds1.Tables[0].Rows[i]["id"].ToString();
            }
            else
            {
                id = id + "," + ds1.Tables[0].Rows[i]["id"].ToString();
            }
        }
        this.bxh1.Text = PubComm.GetNumberFormat(bxh1.ToString()) + "元";
        this.bxh2.Text = PubComm.GetNumberFormat(bxh2.ToString()) + "美元";
        this.hbxh1.Text = PubComm.GetNumberFormat(hbxh1.ToString()) + "元";
        this.hbxh2.Text = PubComm.GetNumberFormat(hbxh2.ToString()) + "美元";
        this.fyhj.Text = PubComm.GetNumberFormat(fyhj.ToString()) + "元";
        ViewState["id"] = id;

    }
    protected void hs_Click(object sender, EventArgs e)
    {
        if (ViewState["id"].ToString() != "" && ViewState["id"] != null)
        {
            Context.Items["id"] = ViewState["id"].ToString();
            Server.Transfer("StatZcInfo.aspx", false);
        }
    }
}
