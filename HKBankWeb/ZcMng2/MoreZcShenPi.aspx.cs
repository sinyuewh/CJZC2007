using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Data;

public partial class ZcMng2_MoreZcShenPi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        CommTable comm1 = new CommTable("U_ZC2");
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("zcid", Request.QueryString["id"], SearchFieldType.数值型));
        DataSet ds1 = comm1.SearchData("*", condition,"id desc");
        this.repeater1.DataSource = ds1;
        this.repeater1.DataBind();
        comm1.Close();
    }

    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
