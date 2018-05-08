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
using System.Collections.Generic;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;


public partial class ZiChan_ZongHeSearchResult : System.Web.UI.Page
{
    bool first = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            if (HttpContext.Current.Items["SearchCondition"] != null)
            {
                ViewState["SearchCondition"] = HttpContext.Current.Items["SearchCondition"];
                ViewState["SearchKind"] = HttpContext.Current.Items["SearchKind"];
                ViewState["str"] = HttpContext.Current.Items["str"];
                this.BindData();       
            }
            else
            {
                Response.Redirect("~/ZiChan/ZongHeSearch.aspx", true);
            }
        }
    }

    private void BindData()
    {
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetSearchResult(list1);
        string zcid = "";
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
            {
                zcid = ds1.Tables[0].Rows[i]["id"].ToString();
            }
            else
            {
                zcid = zcid + "," + ds1.Tables[0].Rows[i]["id"].ToString();
            }
        }
        this.zcid.Text = zcid;
        DataTable dt = ds1.Tables[0];
        DataView dv1 = dt.DefaultView;
        dv1.Sort = "num2";

        //DataView dv = dt.DefaultView;
        //dv.Sort = "num2";

        this.GridView1.DataSource = dv1;
        this.GridView1.DataBind();
        zc1.Close();
        ds1.Dispose();
        string[] str = (string[])ViewState["str"];
        this.danwei.Text = str[0];
        this.zcbao.Text = str[1];
        this.depart.Text = str[2];
        this.zeren.Text = str[3];
        this.quyu.Text = str[4];
        this.bstatus.Text = str[5];
        this.hangye.Text = str[6];
        this.fenlei.Text = str[7];
        this.status.Text = str[8];
        this.userkind.Text = str[9];
        Session["zcid"] = this.zcid.Text;
    }
}
