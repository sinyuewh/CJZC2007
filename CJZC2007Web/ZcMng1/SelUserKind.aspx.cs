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

public partial class ZcMng1_SelUserKind : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["kind"] != null && Request.QueryString["kind"] == "31")
            {
                U_ZCBU zc1 = new U_ZCBU();
                zc1.SetUserKind(Request.QueryString["id"], "31", "");
                zc1.Close();
                Comm.ShowInfo("提示：清除用户自定义分类操作成功！",Application["root"]+"/ZcMng1/FixZcUserKind.aspx");
            }
            else if (Request.QueryString["kind"] != null && Request.QueryString["kind"] == "32")
            {
                U_ZCBU zc1 = new U_ZCBU();
                zc1.SetUserKind(Request.QueryString["id"], "32", "");
                zc1.Close();
                Comm.ShowInfo("提示：清除用户自定义分类操作成功！", Application["root"] + "/ZcMng1/MyFixZcUserKind.aspx");
            }
            else
            {
                U_ItemBU item = new U_ItemBU();
                item.Setuserkind(this.userkind);
                item.Close();
                if (this.userkind.Items.Count > 0)
                {
                    this.userkind.SelectedIndex = 0;
                }
            }
        }
    }


    //调整用户自定义分类
    protected void Button1_Click(object sender, EventArgs e)
    {
        U_ZCBU zc1 = new U_ZCBU();
        zc1.SetUserKind(Request.QueryString["id"], Request.QueryString["kind"], this.userkind.SelectedValue);
        zc1.Close();
        string info = "提示：替换用户自定义分类操作成功！";
        if (Request.QueryString["kind"] == "21" || Request.QueryString["kind"] == "22")
        {
            info = "提示：追加用户自定义分类操作成功！";
        }
        if (Request.QueryString["kind"] == "21" || Request.QueryString["kind"] == "11")
        {
            Comm.ShowInfo(info, Application["root"] + "/ZcMng1/FixZcUserKind.aspx");
        }
        else
        {
            Comm.ShowInfo(info, Application["root"] + "/ZcMng1/MyFixZcUserKind.aspx");
        }
    }
}
