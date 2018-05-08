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
using System.Data.OleDb;


public partial class ReadData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        OleDbConnection myconn = new OleDbConnection();
        string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
        strConnection += @"Data Source=" + Server.MapPath("~/Common/Data/mydata.mdb");
        myconn.ConnectionString = strConnection;
        myconn.Open();

        OleDbCommand comm1 = new OleDbCommand("select * from mydata  ");
        comm1.Connection = myconn;
        OleDbDataReader dr = comm1.ExecuteReader();
        this.GridView1.DataSource = dr;
        this.GridView1.DataBind();
        comm1.Dispose();
        dr.Close();
        dr.Dispose();

        myconn.Close();
        myconn.Dispose();

    }
}
