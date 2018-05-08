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

public partial class XtGL_test2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Response.Write(e.Keys[0].ToString());
        Response.Write(e.NewValues["depart"].ToString());
        Response.Write(e.OldValues["depart"].ToString());
        e.Cancel = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PubComm.ShowInfo("操作成功", Request.RawUrl);
    }
}
