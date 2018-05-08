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
using System.IO;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class ZcMng1_ZCDirectoryInfo : System.Web.UI.Page
{
    bool isOwner = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.isOwner = PubComm.IsRole("系统管理员");
        if (!Page.IsPostBack)
        {
            this.BindData();
            if (isOwner == false)
            {
                this.Tab1.Visible = false;
            }
        }


    }

    private void BindData()
    {
        DataTable dt = new DataTable("fileTab");
        dt.Columns.Add("filename");
        dt.Columns.Add("filetime");
        
        DirectoryInfo fileDir = new DirectoryInfo(Server.MapPath(Application["root"] + "/Common/Downloads"));
        foreach (FileInfo file1 in fileDir.GetFiles())
        {
            DataRow dr = dt.NewRow();
            dr["filename"] = file1.Name;
            dr["filetime"] = file1.LastWriteTime.ToString();
            dt.Rows.Add(dr);
        }
        this.Repeater1.DataSource = dt;
        this.Repeater1.DataBind();
        dt.Dispose();

        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.PostedFile != null)
        {
            string ExcelName = FileUpload1.PostedFile.FileName;
            string file1 = Path.GetFileName(ExcelName);
            if (file1 != "")
            {
                FileUpload1.PostedFile.SaveAs(Server.MapPath(Application["root"] + "/Common/Downloads/" + file1));
            }
            else
            {
                Util.alert(this.Page, "请选择要上传的附件！");
            }
        }
        this.BindData();
    }


    //处理删除文件的代码
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lab1 = e.Item.FindControl("labFile") as Label;
        if (lab1 != null)
        {
            File.Delete(Server.MapPath(Application["root"] + "/Common/Downloads/" + lab1.Text));
            this.BindData();
        }
    }

    //处理DataBond事件
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        LinkButton link1 = e.Item.FindControl("butDel") as LinkButton;
        if (link1 != null && isOwner==false)
        {
            link1.Visible = false;
        }
    }


    protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Label lab1 = e.Item.FindControl("labDelete") as Label;
        if (lab1 != null && isOwner == false)
        {
            lab1.Visible = false;
        }
    }
}
