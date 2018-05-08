using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JSJ.CJZC.Business;

public partial class ZcMng2_SeeZcTimeLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           DataTable dt1= U_TimeTypeBU.GetLogoTable(Request.QueryString["timeid"]);
           this.Repeater1.DataSource = dt1;
           this.Repeater1.DataBind();
        }
    }

    protected override void OnUnload(EventArgs e)
    {
        JSJ.SysFrame.Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
