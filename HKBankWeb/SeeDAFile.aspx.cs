using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using System.Data;
using System.Collections;

public partial class SeeDAFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (String.IsNullOrEmpty(Request.QueryString["fileName"]) == false)
            {
                WriteDAFileLog(Request.QueryString["fileName"]);
                String fileName = Request.QueryString["fileName"].ToLower();
                String ext = Path.GetExtension(fileName);
                this.fileName.Value = fileName;
                this.filetype.Value = ext;

                if (ext == ".pdf")
                {
                    Response.Redirect("SeePDFFile.aspx?pdf=" + fileName, false);
                }
                else if (ext == ".doc" || ext == ".xls" || ext == ".ppt")
                {
                    Response.Redirect("SeeWordFile.aspx?doc=" + fileName, false);
                }
                else
                {
                    int pos1 = Request.Url.AbsoluteUri.LastIndexOf("/");
                    String url1 = Request.Url.AbsoluteUri.Substring(0, pos1);
                    url1 = url1 + "/Common/AttachFiles/" + fileName;
                    Response.Redirect(url1, false);
                }
            }
        }
    }

    //将浏览档案文件的日志写入
    private void WriteDAFileLog(String FileName)
    {
        JSJ.CJZC.Business.DangAnBU.WriteDAFileLog(FileName, "");
    }
}
