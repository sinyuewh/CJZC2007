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

using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class DangAn_ShowFileInfo : System.Web.UI.Page
{
    string[] arr0 = new string[] { "ajnum", "title", "danwei",  "filecount", "beginPage", "endPage", "jyue",  "dtmen","remark","filefs" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetControlData();
        }
    }
    //绑定页面控件的值

    private void SetControlData()
    {
        if (Request.QueryString["id"] != null)
        {
                string fileID = Request["id"];
                DA_FilesBU file1 = new DA_FilesBU();

                DataSet ds1 = file1.GetFileDetailByID(fileID);
                file1.Close();

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    
                    for (int i = 0; i < arr0.Length; i++)
                    {
                        Util.SetControlValue(this.ajnum.Parent.FindControl(arr0[i]), ds1.Tables[0].Rows[0][arr0[i]]);
                    }

                    if (ds1.Tables[0].Rows[0]["jyuetime"] != DBNull.Value && ds1.Tables[0].Rows[0]["jyuetime"].ToString().Trim()!="")
                    {
                        this.jyuetime.Text = DateTime.Parse(ds1.Tables[0].Rows[0]["jyuetime"].ToString()).ToString("yyyy-MM-dd");
                        this.djtime.Text = DateTime.Parse(ds1.Tables[0].Rows[0]["djtime"].ToString()).ToString("yyyy-MM-dd");
                    }
                }
                ds1.Dispose();

        }
    }
}
