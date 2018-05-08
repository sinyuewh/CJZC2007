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
using JSJ.SysFrame.DB;

public partial class ZcMng2_ZcBaoDetail6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData(null);
        }
    }

    private void BindData(U_ZCFilesBU file1)
    {
        bool flag = false;
        if (file1 == null)
        {
            file1 = new U_ZCFilesBU();
            flag = true;
        }
        DataSet ds1 = file1.GetAttachListByBID(Request["id"].ToString());

        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();

        string id = Request["id"];
        U_ZCBAOBU zc1 = new U_ZCBAOBU();
        DataSet ds = zc1.GetDetailByID(id, "depart,bzeren,bname");
        zc1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.Bname.Text = ds.Tables[0].Rows[0]["bname"].ToString();
            this.depart.Text = ds.Tables[0].Rows[0]["depart"].ToString();
            this.zeren.Text = ds.Tables[0].Rows[0]["bzeren"].ToString();
        }
        if (flag)
        {
            file1.Close();
        }
    }
}
