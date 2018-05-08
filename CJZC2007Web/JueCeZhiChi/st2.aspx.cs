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

public partial class JueCeZhiChi_st2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Comm.SetDepart(this.depart, null);
            this.depart.SelectedIndex = 0;
        }
    }

    //按部门统计资产
    protected void Button1_Click(object sender, EventArgs e)
    {
        Context.Items["seldepart"] = this.depart.SelectedValue;
        Server.Transfer("st1.aspx", false);
    }
}
