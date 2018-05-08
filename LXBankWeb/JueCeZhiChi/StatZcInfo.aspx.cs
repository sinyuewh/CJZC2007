using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class JueCeZhiChi_StatZcInfo : System.Web.UI.Page
{
    public double d1 = 0;
    public double d2 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Items["id"] != null && Context.Items["id"].ToString()!="")
        {
            ViewState["id"] = Context.Items["id"].ToString();
            this.BindDate();
            
        }
    }
    private void BindDate()
    {
        List<SearchField> list1 = new List<SearchField>();
        string idlist = ViewState["id"].ToString();
        string[] arr = idlist.Split(',');
        string temp = "";
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == 0)
            {
                temp = " id =" + arr[i];
            }
            else
            {
                temp = temp + " or id =" + arr[i];
            }
        }
        if (temp != "")
        {
            list1.Add(new SearchField("", temp, SearchOperator.用户定义));
        }
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetSearchResult(list1);
        zc1.Close();
        this.GridView1.DataSource = ds;
        

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            d1 = d1 + double.Parse(dr["bj"].ToString());
            d2 = d2 + double.Parse(dr["lx1"].ToString());
        }
        this.GridView1.DataBind();
        //TableCell cell1=new TableCell();
        //cell1.Text = "123456";
        //this.GridView1.Rows[this.GridView1.Rows.Count-1].Cells.Add(cell1);
        ds.Dispose();


    }
}
