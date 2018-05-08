using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using System.Data;

public partial class XtGL_EditShiXiaoType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String timetypecode1 = Request.QueryString["TimeTypeCode"];
            this.SetPageData();
            this.BindData(timetypecode1);
        }
    }

    private void SetPageData()
    {
        String timetypecode1 = Request.QueryString["TimeTypeCode"];
        DataRow dr1 = GetTimeData(timetypecode1);
        if (dr1 != null)
        {
            Control[] con1 = new Control[] { num,timetypecode,timetypename,remark};
            foreach (Control con in con1)
            {
                String value1 = dr1[con.ID].ToString();
                Util.SetControlValue(con, value1);
            }
        }
    }

    //得到时效数据
    private DataRow GetTimeData(String timetypecode)
    {
        DataRow dr1 = null;
        CommTable comm1 = new CommTable("U_TimeType");
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("timetypecode", timetypecode));
        DataSet ds1 = comm1.SearchData("*", condition);
        if (ds1 != null)
        {
            dr1 = ds1.Tables[0].Rows[0];
        }
        comm1.Close();
        return dr1;
    }

    private void BindData(String timetypecode)
    {
        CommTable comm1 = new CommTable("U_TimeTypeDetail");
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("timetypecode", timetypecode));
        DataSet ds1 = comm1.SearchData("*", condition,"num");
        comm1.Close();

        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
    }
}
