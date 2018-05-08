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

public partial class Common_Master_Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
        }
        base.OnInit(e);
    }
    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }


    #region Code
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.SetShow();
    }


    public void SetShow()
    {
        this.Nav.Visible = !(this.Nav.Visible);
        if (this.Nav.Visible == true)
        {
            this.Button1.Text = "-";
            this.Button1.ToolTip = "隐藏导航栏";
        }
        else
        {
            this.Button1.Text = "+";
            this.Button1.ToolTip = "显示导航栏";
        }
    }

    public void SetShowMax()
    {
        this.Nav.Visible = false;
        if (this.Nav.Visible == true)
        {
            this.Button1.Text = "-";
            this.Button1.ToolTip = "隐藏导航栏";
        }
        else
        {
            this.Button1.Text = "+";
            this.Button1.ToolTip = "显示导航栏";
        }
    }


    public void SetShowMin()
    {
        this.Nav.Visible = true;
        if (this.Nav.Visible == true)
        {
            this.Button1.Text = "-";
            this.Button1.ToolTip = "隐藏导航栏";
        }
        else
        {
            this.Button1.Text = "+";
            this.Button1.ToolTip = "显示导航栏";
        }
    }

    public void HideNav()
    {
        this.Nav.Visible = false;
    }

    public void ShowNav()
    {
        this.Nav.Visible = true;
    }
    #endregion
}
