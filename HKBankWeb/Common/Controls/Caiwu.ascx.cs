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

public partial class Common_Controls_Caiwu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // hide menu
            U_RolesBU role1 = new U_RolesBU();

            //财务开票权限设置
            if (role1.isRole("会计") == false && role1.isRole("出纳") == false)
            {
                this.ZCCWKP.Visible = false;
                this.ZCBCWKP.Visible = false;
            }

            //单据审核权限设置
            if (role1.isRole("会计") == false)
            {
                this.DJSH.Visible = false;
            }
            role1.Close();


            this.SetMenu();
        }
    }


    /// <summary>
    /// 根据用户的选择设置Menu
    /// </summary>
    private void SetMenu()
    {
        /*
        string OpenFlag = JSJ.SysFrame.Util.getCookieValue("CaiwuMenu");
        if (OpenFlag != "")
        {
            this.Row1.Visible = true;
            this.Row2.Visible = true;
            this.ImageButton1.ImageUrl = "~/images/treeClose.GIF";
            this.ImageButton1.ToolTip = "折叠节点";
        }
        else
        {
            this.Row1.Visible = false;
            this.Row2.Visible = false;
            this.ImageButton1.ImageUrl = "~/images/treeOpen.GIF";
            this.ImageButton1.ToolTip = "展开节点";
        }
         * */
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string OpenFlag = JSJ.SysFrame.Util.getCookieValue("CaiwuMenu");
        if (OpenFlag == "")
        {
            JSJ.SysFrame.Util.setCookie("CaiwuMenu", "1");
        }
        else
        {
            JSJ.SysFrame.Util.setCookie("CaiwuMenu", "");
        }
        this.SetMenu();
    }
}
