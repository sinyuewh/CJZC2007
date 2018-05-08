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
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class ZcMng2_TcDoc : System.Web.UI.Page
{
    bool owner = false;
    public string AttachFileName = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.owner = Comm.IsZcMng(Request["zcid"], User.Identity.Name);
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["zcid"] != null)
            {
                string id = Request["zcid"];
                U_ZCBU zc1 = new U_ZCBU();
                DataSet ds = zc1.GetDetailByID(id, "*");
                zc1.Close();
                

                //////////////////////////////////////////////////////////////////////
                bool AttachFile=false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        AttachFile = true;
                        AttachFileName = ds.Tables[0].Rows[0][0].ToString();
                        this.OldFileName.Value = AttachFileName;
                    }
                }

                if (owner == false)
                {
                    this.Row3.Visible = false;
                    this.Row1.Visible = false;
                    if (AttachFile == false)
                    {
                        Response.Write("<br><center>提示：资产负责人没有上传【不良资产逐户调查表！】<center>");
                        Response.End();
                    }
                }
                else
                {
                    if (AttachFile == false)
                    {
                        this.Row2.Visible = false;
                    }
                    else
                    {
                        this.Row1.Visible = false;
                    }
                }

                Page.DataBind();
            }
        }
    }

    //上传长江资产公司不良贷款逐户调查表.doc
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.FileName != null && this.FileUpload1.PostedFile.ContentLength > 0)
        {
            string filename = null;
            if (this.OldFileName.Value == "")
            {
                filename = Request["zcid"].ToString() + "_" + Util.GetRandomString(9) + "_" + this.FileUpload1.FileName;
                this.OldFileName.Value = filename;
            }
            else
            {
                filename = this.OldFileName.Value;
            }
           
            string filename1 = Server.MapPath("~/Common/AttachFiles/") + filename;
            this.FileUpload1.SaveAs(filename1);  //保存文件到系统

            //更新数据库中的数据
            if (this.OldFileName.Value != "")
            {
                 Hashtable ht = new Hashtable();
                 ht["tcdoc"] = this.OldFileName.Value;
                U_ZCBU zc1 = new U_ZCBU();
                zc1.UpdateInfo(Request["zcid"].ToString(), ht);
                zc1.Close();
            }

            ////////////////////////////////////////
            Util.alert(this.Page, "文件上传成功，请关闭当前窗口！");
        }
        else
        {
            Util.alert(this.Page, "错误提示：请选择一个【不良资产逐户调查表】文件上传！");
        }
    }
}
