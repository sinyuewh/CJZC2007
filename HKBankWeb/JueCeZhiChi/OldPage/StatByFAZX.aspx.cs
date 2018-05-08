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

public partial class JueCeZhiChi_StatByFAZX : System.Web.UI.Page
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
        DataSet ds = zctc1.GetJZDCByDepart();
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
            DataSet ds1 = zctc1.GetJZDCFromZCTC(this.BeginTime.Text, this.EndTime.Text, lab1.Text);
            zctc1.Close();
            bool first = false;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i]["count13"].ToString() != "0")
                {
                    first = true;
                }
            }
            GridView gridview1 = e.Item.FindControl("GridView1") as GridView;
            if (gridview1 != null)
            {
                gridview1.DataSource = ds1;
                gridview1.DataBind();
                if (first==false)
                {
                    gridview1.Visible = false;
                    //e.Item.Visible = false;
                }
            }
            gridview1.Dispose();
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lab1 = e.Row.FindControl("LabHJ") as Label;
        if (lab1 != null)
        {
            if (lab1.Text == "0")
            {
                e.Row.Visible = false;
            }
        }
    }
}
