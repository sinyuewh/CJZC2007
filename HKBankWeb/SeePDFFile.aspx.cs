using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Data;

public partial class DangAn_SeePDFFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int pos1 = Request.Url.AbsoluteUri.LastIndexOf("/");
            String url1 = Request.Url.AbsoluteUri.Substring(0, pos1);

            this.pdffont.Value = url1 + "/SC_TC_JP_KR.CAB";
            this.pdfdoc.Value = url1 + "/Common/AttachFiles/";

            if (String.IsNullOrEmpty(Request.QueryString["pdf"]) == false)
            {
                this.pdfdoc.Value = this.pdfdoc.Value + Request.QueryString["pdf"];
            }
            else
            {
                this.pdfdoc.Value = "";
            }
        }
    }


    protected void button1_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString["pdf"]) == false)
        {
            String trueFile = Request.QueryString["pdf"];
            CommTable comm1 = new CommTable("DA_AJDZFile");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("ajtrueFile", trueFile));
            DataSet ds1 = comm1.SearchData("*", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                String fileName = dr1["ajFile"].ToString();
                if (String.IsNullOrEmpty(fileName) == false)
                {
                    JSJ.CJZC.Business.DangAnBU.WriteDAFileLog(trueFile, "下载");
                    this.SendFile(fileName, trueFile);
                }
            }
            comm1.Close();
        }
    }

    //将文件输出到浏览器
    private void SendFile(String fileName,String trueFileName)
    {
        String fullname = Server.MapPath("~/Common/AttachFiles/" + trueFileName);
        if (File.Exists(fullname))
        {
            FileStream fileStream = File.OpenRead(fullname);
            long fileSize = fileStream.Length;
            Context.Response.ContentType = "application/octet-stream";
            Context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" 
                + HttpUtility.UrlEncode(fileName , System.Text.Encoding.UTF8) + "\"");
            Context.Response.AddHeader("Content-Length", fileSize.ToString());
            byte[] fileBuffer = new byte[fileSize];
            fileStream.Read(fileBuffer, 0, (int)fileSize);
            fileStream.Close();
            Response.BinaryWrite(fileBuffer);
            Response.End();
        }
    }
}
