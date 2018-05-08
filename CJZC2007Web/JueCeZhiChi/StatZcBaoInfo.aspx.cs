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

public partial class JueCeZhiChi_StatZcBaoInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Items["bid"] != null && Context.Items["bid"].ToString() != "")
        {
            ViewState["bid"] = Context.Items["bid"].ToString();
            this.BindDate();
        }
    }

    private void BindDate()
    {
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("id", ViewState["bid"].ToString(), SearchOperator.集合,SearchFieldType.数值型));
        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        DataSet ds = zcb1.GetDetail(list1, "*");
        zcb1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        ds.Dispose();
    }
}
