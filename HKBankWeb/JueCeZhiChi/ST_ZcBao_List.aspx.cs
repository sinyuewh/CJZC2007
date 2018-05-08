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
using System.Data.SqlClient;
using System.Text;

public partial class JueCeZhiChi_ST_ZcBao_List : System.Web.UI.Page
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
        SqlParameter[] para = new SqlParameter[2];
        string kind = Request.QueryString["status"];
        string depart = Request.QueryString["depart"];
        StringBuilder str1 = new StringBuilder(" select * from zcBaoView where 1=1 ");
        if (String.IsNullOrEmpty(kind) == false && kind != "00")
        {
            str1.Append(" and bstatus=@status ");
            para[0] = new SqlParameter("@status", kind);
        }
        else
        {
            if (kind == "00")
            {
                str1.Append(" and bstatus is null ");
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
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
}
