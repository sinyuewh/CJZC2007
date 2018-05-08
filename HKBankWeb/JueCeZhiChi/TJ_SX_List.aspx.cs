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
using System.Data.SqlClient;


public partial class JueCeZhiChi_TJ_SX_List : System.Web.UI.Page
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
        string year = Request.QueryString["year"];
        string month = Request.QueryString["month"];
        string timeName = Request.QueryString["timename"];
        SqlParameter[] para = new SqlParameter[3];

        string str1=@" select *,left(danwei,20) as danwei1 from zcView
                      where id in ( select zcid from U_ZcTime
                      where year(time0)=@year1
                      and month(time0)=@month1
                      and timeName=@timeName )";


        para[0] = new SqlParameter("@year1", year);
        para[1] = new SqlParameter("@month1", month);
        para[2] = new SqlParameter("@timeName", timeName);

        CommTable comm1 = new CommTable();
        DataSet ds = comm1.TableComm.SearchData(str1, CommandType.Text,para);
        comm1.Close();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();

    }
}
