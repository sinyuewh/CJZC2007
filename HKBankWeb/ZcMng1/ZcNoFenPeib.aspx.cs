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
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;
using System.Collections.Generic;

public partial class ZcMng1_ZcNoFenPeib : System.Web.UI.Page
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
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetNoZerenZc(null);
        zc1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
}
