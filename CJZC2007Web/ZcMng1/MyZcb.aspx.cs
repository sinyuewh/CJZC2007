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

public partial class ZcMng1_MyZcb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Myzcid"] != null && Session["Myzcid"].ToString() != "")
            {
                this.Label1.Text = System.DateTime.Now.ToString();
                this.BindDate();
            }
        }
    }

    private void BindDate()
    {
        List<SearchField> list1 = new List<SearchField>();
        string idlist = Session["Myzcid"].ToString();
        string[] arr = idlist.Split(',');
        string temp = "";
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == 0)
            {
                temp = " id =" + arr[i];
            }
            else
            {
                temp = temp + " or id =" + arr[i];
            }
        }
        if (temp != "")
        {
            list1.Add(new SearchField("", temp, SearchOperator.用户定义));
        }

        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetSearchResultByID("*,isnull(pbj,0)+isnull(plx,0) as hbxh,isnull(bj,0)+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0)-isnull(pbj,0)-isnull(plx,0) as bxhjye", list1);
        zc1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        ds.Dispose();
    }
}
