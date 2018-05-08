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

public partial class ZcMng2_ZcDetail8 : System.Web.UI.Page
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
        DataSet ds1 = file1.GetAttachListByZCID(Request["id"].ToString());

        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();

        string id = Request["id"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetDetailByID(id, "depart,zeren,danwei");
        zc1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.danwei.Text = ds.Tables[0].Rows[0]["danwei"].ToString();
            this.depart.Text = ds.Tables[0].Rows[0]["depart"].ToString();
            this.zeren.Text = ds.Tables[0].Rows[0]["zeren"].ToString();
        }
        if (flag)
        {
            file1.Close();
        }
    }
}
