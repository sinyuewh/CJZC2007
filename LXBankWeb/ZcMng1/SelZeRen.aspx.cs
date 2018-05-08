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

public partial class ZcMng1_SelZeRen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PubComm.SetAccess(User.Identity.Name, "资产管理员");  

            if (Request["id"] == null || Request["id"] == "")
            {
                Response.Redirect("~/Error.aspx", true);
            }
            else
            {
                U_UserNameBU user1 = new U_UserNameBU();
                user1.SetZcZeren(this.zeren);
                user1.Close();
            }
        }
    }


    //设置资产责任人
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.zeren.SelectedValue == "")
        {
            Util.alert(this.Page, "错误提示：请选择一个责任人！");
        }
        else
        {
            U_ZCBU zc1 = new U_ZCBU();
            String kind = "0";
            if(String.IsNullOrEmpty(Request.QueryString["renkind"])==false)
            {
                kind=Request.QueryString["renkind"];
            }
            bool check1 = zc1.SetZeren(Request["id"], this.zeren.SelectedValue,kind);
            zc1.Close();
            string info = null;
            if (check1)
            {
                info ="提示：成功地将资产的责任人设置为【" + this.zeren.SelectedValue + "】！";
            }
            else
            {
                info="提示：设置资产责任人操作失败！";
            }

            string url=Application["root"] + "/ZcMng1/ZiChangFengPei.aspx";
            if (Request["ReturnUrl"] != null && Request["ReturnUrl"] != "")
            {
                url = Request["ReturnUrl"];
            }
            PubComm.ShowInfo(info ,url );
        }
    }
}
