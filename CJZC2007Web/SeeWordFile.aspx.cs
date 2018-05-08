using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using WebFrame; 

public partial class DangAn_SeeWordFile : System.Web.UI.Page
{
    public bool IsDangAnAdmin
    {
        get
        {
            if (ViewState["IsDangAnAdmin"] == null)
            {
                return false;
            }
            else
            {
                return (bool)ViewState["IsDangAnAdmin"];
            }
        }
        private set
        {
            ViewState["IsDangAnAdmin"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int pos1 = Request.Url.AbsoluteUri.LastIndexOf("/");
            String url1 = "http://" + FrameLib.ServerHost;
            if (FrameLib.ServerPort != "80")
            {
                url1 = url1 + ":" + FrameLib.ServerPort;
            }
           
            this.wordUrl.Value = url1 + "/Common/AttachFiles/";

            if (String.IsNullOrEmpty(Request.QueryString["doc"]) == false)
            {
                this.wordUrl.Value = this.wordUrl.Value + Request.QueryString["doc"];
                String ext = Path.GetExtension(Request.QueryString["doc"]).Replace(".","");
                this.wordExt.Value = ext;
                this.saveDoc.Value =  url1 + "/saveWordDoc.aspx";
                this.filename.Value = Request.QueryString["doc"];
            }
            else
            {
                this.wordUrl.Value = "";
            }

            U_RolesBU role1 = new U_RolesBU();
            bool user = role1.isRole("档案管理员");
            role1.Close();
            if (user)
            {
                this.isAdmin.Value = "1";
            }
            else
            {
                this.isAdmin.Value = "";
            }
            this.but2.Visible = user;
            this.Row1.Visible = user;

        }
    }
}
