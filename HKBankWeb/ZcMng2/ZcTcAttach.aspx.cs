using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;

public partial class ZcMng2_ZcTcAttach : System.Web.UI.Page
{
    bool owner = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["bkind"].ToString() == "0")
        {
            this.owner = PubComm.IsZcMng(Request["zcid"].ToString(), User.Identity.Name);
        }
        else
        {
            this.owner = PubComm.IsZcBaoMng(Request["zcid"].ToString(), User.Identity.Name);
        }


        if (!Page.IsPostBack)
        {
            if (this.owner == false)
            {
                this.Row1.Visible = false;
            }
            this.BindData(null);
        }
    }

    protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("fileid") != null)
        {
            Label lab1 = e.Item.FindControl("fileid") as Label;
            string id = lab1.Text;
            U_ZCFilesBU file1 = new U_ZCFilesBU();
            file1.DeleteFile(id);
            this.BindData(file1);
            file1.Close();
        }
    }

    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("butDel") != null)
        {
            LinkButton link1 = e.Item.FindControl("butDel") as LinkButton;
            if (this.owner == false)
            {  
                link1.Visible = false;
            }
        }
    }

    //Bind data
    private void BindData(U_ZCFilesBU file1)
    {
        bool flag = false;
        if (file1 == null)
        {
            file1 = new U_ZCFilesBU();
            flag = true;
        }
        this.Repeater1.DataSource = file1.GetAttachList(Request["id"].ToString(),Request["bkind"].ToString());
        this.Repeater1.DataBind();
        if (flag)
        {
            file1.Close();
        }
    }

    //上传附件
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.FileName != null && this.FileUpload1.PostedFile.ContentLength > 0)
        {
            Hashtable ht = new Hashtable();
            string filename = User.Identity.Name + "_" + Util.GetRandomString(9) + "_" + this.FileUpload1.FileName;
            ht["attachfile"] = filename;
            ht["tcid"] = Request["id"].ToString();
            ht["zcid"] = Request["zcid"].ToString();
            ht["bkind"] = Request["bkind"].ToString();

            string filename1 = Server.MapPath("~/Common/AttachFiles/") + filename;

            //保存文件到系统
            this.FileUpload1.SaveAs(filename1);
            

            U_ZCFilesBU file1 = new U_ZCFilesBU();
            file1.InsertData(ht);
            file1.Close();
            Response.Redirect(Request.RawUrl, true);
        }   
    }
}
