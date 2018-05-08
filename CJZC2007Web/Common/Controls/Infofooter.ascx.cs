using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Common_Controls_Infofooter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DataBind();
            Page.Title = Page.Title + "（资产管理资讯平台）";
        }
    }
}
