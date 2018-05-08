using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.CJZC.Business;

public partial class ZcMng1_SelZcBao2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            zcb1.SetBstatus(this.Bstatus,"");
            zcb1.Close();
            if (this.Bstatus.Items.Count > 0)
            {
                this.Bstatus.SelectedIndex = 0;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        U_ZCBU zc1 = new U_ZCBU();
        zc1.SetBstatus(Request.QueryString["id"],this.Bstatus.SelectedValue);
        zc1.Close();
        string info = "提示：资产打包操作成功！";
        PubComm.ShowInfo(info, Application["root"] + "/ZcMng1/FixZcBao.aspx");
    }
}
