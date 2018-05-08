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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class ZcMng2_Zcsxxxb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
            this.time.Text = System.DateTime.Now.ToString();
        }
    }

    private void BindData()
    {
        if (Request["zcid"] != null)
        {
            U_ZCTimeBU time1 = new U_ZCTimeBU();
            DataSet ds1 = time1.GetTimeListByParentID(Request["zcid"]);
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();
            time1.Close();
            ds1.Dispose();

            string id = Request["zcid"];
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetDetailByID(id, "danwei");
            this.depart.Text = ds.Tables[0].Rows[0][0].ToString();
            zc1.Close();
        }
    }
}
