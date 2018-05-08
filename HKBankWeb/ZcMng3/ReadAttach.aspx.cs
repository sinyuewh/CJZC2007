using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class ZcMng3_ReadAttach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["did"] != null && Request.QueryString["did"] != String.Empty)
        {
            String truename = "";
            String fullname = "";
            
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
