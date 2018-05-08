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
using JSJ.CJZC.Business;

public partial class ZcMng2_ZcTcDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != null)
            {
                U_ZCTCBU zctc1 = new U_ZCTCBU();
                DataSet ds1 = zctc1.GetDetailByID(Request["id"].ToString());
                this.TextBox1.Text = ds1.Tables[0].Rows[0]["remark"].ToString();

                zctc1.Close();
            }

        }
    }
}
