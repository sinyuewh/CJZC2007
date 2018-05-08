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
using JSJ.SysFrame;
using JSJ.SysFrame.DB;

public partial class JueCeZhiChi_StatByFASP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData("", "");
            this.BeginTime.Attributes["onfocus"] = "setday(this)";
            this.EndTime.Attributes["onfocus"] = "setday(this)";
        }
    }


    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.BeginTime.Text, this.EndTime.Text);
    }

    private void BindData(string begintime, string endtime)
    {
        U_ZCTCBU zctc1 = new U_ZCTCBU();
        DataSet ds = zctc1.GetFASPByDepart();
        this.Repeater1.DataSource = ds;
        this.Repeater1.DataBind();
        zctc1.Close();
    }

    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lab1 = e.Item.FindControl("labDepart") as Label;
        if (lab1 != null)
        {
            U_ZCTCBU zctc1 = new U_ZCTCBU();
            DataSet ds1 = zctc1.GetFASP(this.BeginTime.Text, this.EndTime.Text, lab1.Text);
            zctc1.Close();
            GridView gridview1 = e.Item.FindControl("GridView1") as GridView;
            if (gridview1 != null)
            {
                gridview1.DataSource = ds1;
                gridview1.DataBind();
            }
            gridview1.Dispose();
        }

    }
}
