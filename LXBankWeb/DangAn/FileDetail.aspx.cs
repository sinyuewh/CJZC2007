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

public partial class DangAn_FileDetail : System.Web.UI.Page
{
    string[] arr0 = new string[] { "ajnum", "fileno", "title", "danwei", "depart", "zeren", "filenum", "filecount", "beginPage", "endPage","jyue","jyuetime","djtime","dtmen" };
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

            if (Request["id"] != null)
            {
                string fileID = Request["id"];
                DA_FilesBU file1 = new DA_FilesBU();

                DataSet ds1 = file1.GetFileDetailByID(fileID);
                file1.Close();

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    string dt1 = DateTime.Parse(ds1.Tables[0].Rows[0]["jyuetime"].ToString()).ToString("yyyy-MM-dd");
                    string dt2 = DateTime.Parse(ds1.Tables[0].Rows[0]["djtime"].ToString()).ToString("yyyy-MM-dd");
                    for (int i = 0; i < arr0.Length; i++)
                    {
                        Util.SetControlValue(this.ajnum.Parent.FindControl(arr0[i]), ds1.Tables[0].Rows[0][arr0[i]]);
                    }
                    Util.SetControlValue(this.ajnum.Parent.FindControl("jyuetime"), dt1);
                    Util.SetControlValue(this.ajnum.Parent.FindControl("djtime"), dt2);
                }
                ds1.Dispose();
            }
        }
    }
}
