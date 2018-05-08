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

public partial class ZcMng1_ShenPiZcBIng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData(null);
        }
    }
    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.Bname.Text);
    }

    //绑定数据
    private void BindData(string bname)
    {
        U_ZCBAOBU zc1 = new U_ZCBAOBU();
        DataSet ds1 = zc1.GetMyShenPiZcB(User.Identity.Name, bname, 0);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        zc1.Close();
        ds1.Dispose();
    }
}
