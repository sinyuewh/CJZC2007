using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Default1 : System.Web.UI.Page
{
    public String HankBankUrl
    {
        get
        {
            String url1 = ConfigurationManager.AppSettings["hkbankurl"];
            url1 = url1 + Server.UrlEncode(Page.User.Identity.Name);
            return url1;
        }
    }


    public String LxBankUrl
    {
        get
        {
            String url1 = ConfigurationManager.AppSettings["lxbankurl"];
            url1 = url1 + Server.UrlEncode(Page.User.Identity.Name);
            return url1;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.TongBuData();
        }
    }


    private void TongBuData()
    {
        WebFrame.Data.JConnect conn0 = WebFrame.Data.JConnect.GetConnect("DefaultConnstring");
        WebFrame.Data.JConnect conn1 = WebFrame.Data.JConnect.GetConnect("HKConnstring");
        if (conn0 != null && conn1 != null)
        {
            WebFrame.Data.JTable tab0 = new WebFrame.Data.JTable(conn0, "U_UserName");
            WebFrame.Data.JTable tab1 = new WebFrame.Data.JTable(conn1, "U_UserName");
            List<WebFrame.Data.SearchField> condition = new List<WebFrame.Data.SearchField>();

            DataSet ds0 = tab0.SearchData(null,-1,"*");
            DataSet ds1=null;
            DataRow dr1 = null;
            String[] arr1 = new String[]{"num","sname","px","depart","job","password","cell","email","login","leader",
                                     "phone","lockflag","zeren1"};
            foreach (DataRow dr0 in ds0.Tables[0].Rows)
            {
                condition.Clear();
                condition.Add(new WebFrame.Data.SearchField("Sname",dr0["Sname"].ToString()));

                ds1 = tab1.SearchData(condition, -1, "*");
                if (ds1 != null)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dr1 = ds1.Tables[0].Rows[0];
                    }
                    else
                    {
                        dr1 = ds1.Tables[0].NewRow();
                    }

                    
                }
            }


            conn0.Dispose();
            conn1.Dispose();
        }

    }
}
