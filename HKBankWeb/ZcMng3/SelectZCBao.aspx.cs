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

public partial class ZcMng3_SelectZCBao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData(null);
        }
    }
    
    private void BindData(string Bname)
    {
        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        DataSet ds1 = zcb1.GetSearchResult2(Bname, User.Identity.Name);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        zcb1.Close();
        ds1.Dispose();
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            String id1 = dr["id"].ToString();

            HyperLink hyp2 = e.Row.FindControl("HyperLink1") as HyperLink;
            if (hyp2 != null)
            {
                ZcspBU bu1 = new ZcspBU();
                int zcspCount = bu1.GetZcCount(int.Parse(id1), ZCKind.资产包);
                hyp2.NavigateUrl = String.Format("javascript:myAddZc({0},{1});", id1, zcspCount);
                hyp2.Target = "_self";
            }
        }
    }

}
