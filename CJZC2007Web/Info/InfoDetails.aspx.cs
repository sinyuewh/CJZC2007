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
using System.IO;
public partial class Info_InfoDetails : System.Web.UI.Page
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
        ZX_InfoBU info1=new ZX_InfoBU();
        string  ID = Request.QueryString["id"];
        DataSet ds1 = info1.ReadInfoByID(ID);
        this.FormView1.DataSource = ds1;
        this.FormView1.DataBind();

        Repeater rep1 = this.file;
        if (rep1 != null)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("filename");
                dt.Columns.Add("filename1");
                for (int i = 1; i <= 5; i++)
                {
                    if (ds1.Tables[0].Rows[0]["file" + i].ToString() != String.Empty)
                    {
                        DataRow dr = dt.NewRow();
                        dr["filename"] = ds1.Tables[0].Rows[0]["file" + i].ToString();
                        String fname = Path.GetFileNameWithoutExtension(dr["filename"].ToString());
                        fname = fname.Substring(0, fname.Length - 32);
                        dr["filename1"] = fname + Path.GetExtension(dr["filename"].ToString());
                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    rep1.DataSource = dt;
                    rep1.DataBind();
                }
            }
        }
    }

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("InfoBrowse.aspx", true);
    //}
    protected void btn1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoBrowse.aspx", true);
    }
}
