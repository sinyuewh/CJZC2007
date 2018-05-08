using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.IO;
using System.Collections.Generic;

public partial class ZcMng3_OpenFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (String.IsNullOrEmpty(Request["id"]) == false)
            {
                String fullname = null;
                String truename = null;
                CommTable comm1 = new CommTable();
                comm1.TabName = "U_CZFile";
                List<SearchField> condition = new List<SearchField>();
                condition.Add(new SearchField("id", Request["id"], SearchFieldType.数值型));
                DataSet ds1 = comm1.SearchData("*", condition);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    fullname = ds1.Tables[0].Rows[0]["fileName"].ToString();
                    fullname = Server.MapPath("~/Common/AttachFiles/" + fullname);
                    truename = ds1.Tables[0].Rows[0]["trueName"].ToString();
                }
                comm1.Close();
                //////////////////////////////////////////////
                if (String.IsNullOrEmpty(fullname) == false)
                {
                    FileStream fileStream = File.OpenRead(fullname);
                    long fileSize = fileStream.Length;
                    Context.Response.ContentType = "application/octet-stream";
                    Context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlEncode(truename, System.Text.Encoding.UTF8) + "\"");
                    Context.Response.AddHeader("Content-Length", fileSize.ToString());
                    byte[] fileBuffer = new byte[fileSize];
                    fileStream.Read(fileBuffer, 0, (int)fileSize);
                    fileStream.Close();
                    Response.BinaryWrite(fileBuffer);
                    Response.End();
                }
            }
        }
    }


    protected override void OnUnload(EventArgs e)
    {
        JSJ.SysFrame.Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
