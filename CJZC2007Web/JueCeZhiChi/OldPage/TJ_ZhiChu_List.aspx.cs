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

public partial class JueCeZhiChi_StatZhiChuB : System.Web.UI.Page
{
    double AllHK = 0;
    string btime = "";
    string etime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["btime"] != null)
            {
                btime = Request["btime"].ToString();
            }
            if (Request["etime"] != null)
            {
                etime = Request["etime"].ToString();
            }
            this.BindData(btime, etime);
        }
    }


    private void BindData(string begintime, string endtime)
    {
        CW_PayBU pay1 = new CW_PayBU();
        DataSet ds = pay1.GetZhiChuByDepart(begintime, endtime);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ds.Tables[0].Rows[i]["Sumfee"] = Comm.GetNumberFormat(ds.Tables[0].Rows[i]["Sumfee"].ToString());
            AllHK = AllHK + double.Parse(ds.Tables[0].Rows[i]["Sumfee"].ToString());
        }
        this.Repeater1.DataSource = ds;
        this.Repeater1.DataBind();
        pay1.Close();
    }


    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        CW_PayBU pay1 = new CW_PayBU();

        DataSet ds10 = pay1.GetGSFYHJ(btime, etime);
        ds10.Tables[0].Rows[0]["fyhj"] = Comm.GetNumberFormat(AllHK);

        GridView gridview10 = e.Item.FindControl("GridView10") as GridView;
        if (gridview10 != null)
        {
            gridview10.ShowHeader = false;
            gridview10.DataSource = ds10;
            gridview10.DataBind();
        }
        Label lab1 = e.Item.FindControl("labDepart") as Label;
        if (lab1 != null)
        {

            DataSet ds1 = pay1.GetZhiChu(btime, etime, lab1.Text);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                for (int k = 1; k < 13; k++)
                {
                    ds1.Tables[0].Rows[i]["Sumfee" + k] = Comm.GetNumberFormat(ds1.Tables[0].Rows[i]["Sumfee" + k].ToString());
                }
                ds1.Tables[0].Rows[i]["Sumfee"] = Comm.GetNumberFormat(ds1.Tables[0].Rows[i]["Sumfee"].ToString());
            }
            GridView gridview1 = e.Item.FindControl("GridView1") as GridView;
            if (gridview1 != null)
            {
                gridview1.DataSource = ds1;
                gridview1.DataBind();
            }
            gridview1.Dispose();
        }
        pay1.Close();
    }
}
