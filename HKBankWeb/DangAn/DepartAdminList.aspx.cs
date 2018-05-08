using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JSJ.SysFrame.DB;

public partial class DangAn_DepartAdminList : System.Web.UI.Page
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
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("num", typeof(int));
        dt1.Columns.Add("depart");
        dt1.Columns.Add("admin");

        //读取部门信息
        CommTable com1 = new CommTable("U_Depart");
        List<SearchField> search1 = null;
        DataSet ds1= com1.SearchData("*", search1, "num");
        int i=1;
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            DataRow dr2 = dt1.NewRow();
            dr2["num"] = i;
            dr2["depart"] = "";
        }
    }
}
