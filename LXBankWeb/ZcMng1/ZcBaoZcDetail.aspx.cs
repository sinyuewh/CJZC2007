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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class ZcMng1_ZcBaoZcDetail : System.Web.UI.Page
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
        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        string ids = zcb1.GetZCIDByBID(Request["id"].ToString());
        zcb1.Close();
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
        list1.Add(new SearchField("zeren",User.Identity.Name,SearchFieldType.字符型));
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetSearchResult(list1);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        ds.Dispose();
        zc1.Close();
    }
}
