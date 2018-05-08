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
using System.Text;
using System.Data.SqlClient;
using JSJ.SysFrame.DB;

public partial class JueCeZhiChi_CorpZcList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
    }

    private void BindData()
    {
        SqlParameter[] para=new SqlParameter[2];
        string kind = Request.QueryString["status"];
        string depart = Request.QueryString["depart"];
        StringBuilder str1 = new StringBuilder(" select *,left(danwei,20) as danwei1 from zcView where 1=1 ");
        if (String.IsNullOrEmpty(kind) == false && kind!="00")
        {
            str1.Append(" and status=@status ");
            para[0] = new SqlParameter("@status", kind);
        }
        else
        {
            if (kind == "00")
            {
                str1.Append(" and status is null ");
            }
        }

        if (String.IsNullOrEmpty(depart) == false)
        {
            str1.Append(" and depart=@depart ");
            para[1] = new SqlParameter("@depart", depart);
        }

        CommTable comm1 = new CommTable();
        DataSet ds = comm1.TableComm.SearchData(str1.ToString(), CommandType.Text, para);
        comm1.Close();
        DataView dv = ds.Tables[0].DefaultView;
        dv.Sort = "num2";
        this.GridView1.DataSource = dv;
        this.GridView1.DataBind();
    }
}
