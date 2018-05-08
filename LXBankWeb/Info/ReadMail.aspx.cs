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
using System.IO;

public partial class Info_ReadMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //判断该邮件是否需要回执
            this.BindData();
        }
    }


    //显示数据
    private void BindData()
    {
        ZX_EmailBu email = new ZX_EmailBu();
        bool huizhi = email.getHuiZhi(Request.QueryString["id"]);
        if (huizhi)
        {
            this.hidHuiZhi.Value = Request.QueryString["id"];
        }
        
        DataSet ds1 = email.GetUserMail(Request.QueryString["id"]);
        this.mailForm1.DataSource = ds1;
        if (ds1.Tables[0].Rows[0]["remark"] != DBNull.Value)
        {
            ds1.Tables[0].Rows[0]["remark"] = ds1.Tables[0].Rows[0]["remark"].ToString();
            
            //if (huizhi == false)
            //{
            //    ds1.Tables[0].Rows[0]["remark"] = Util.ChangeToShow(ds1.Tables[0].Rows[0]["remark"].ToString());
            //}
            //else
            //{
            //    ds1.Tables[0].Rows[0]["remark"] = ds1.Tables[0].Rows[0]["remark"].ToString();
            //}
        }

        this.mailForm1.DataBind();
        email.Close();
    }


    //返回数据
    protected void btn1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceiveMail.aspx", true);
    }

    //删除邮件
    protected void Button2_Click(object sender, EventArgs e)
    {
        ZX_EmailBu emal1 = new ZX_EmailBu();
        string id = Request.QueryString["id"];
        DataSet ds1 = emal1.GetUserMail(id);
        string file1 = ds1.Tables[0].Rows[0]["file1"].ToString();
        if (file1 != "" && file1 != null)
        {
            ZX_Email1BU email1 = new ZX_Email1BU();
            bool Cunzai = email1.IfCzFile(file1, "1");
            if (Cunzai == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file1));
            }
            email1.Dispose();
        }
        string file2 = ds1.Tables[0].Rows[0]["file2"].ToString();
        if (file2 != "" && file2 != null)
        {
            ZX_Email1BU email2 = new ZX_Email1BU();
            bool Cunzai2 = email2.IfCzFile(file2, "2");
            if (Cunzai2 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file2));
            }
            email2.Dispose();
        }
        string file3 = ds1.Tables[0].Rows[0]["file3"].ToString();
        if (file3 != "" && file3 != null)
        {
            ZX_Email1BU email3 = new ZX_Email1BU();
            bool Cunzai3 = email3.IfCzFile(file3, "3");
            if (Cunzai3 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file3));
            }
            email3.Dispose();
        }
        string file4 = ds1.Tables[0].Rows[0]["file4"].ToString();
        if (file4 != "" && file4 != null)
        {
            ZX_Email1BU email4 = new ZX_Email1BU();
            bool Cunzai4 = email4.IfCzFile(file4, "4");
            if (Cunzai4 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file4));
            }
            email4.Dispose();
        }
        string file5 = ds1.Tables[0].Rows[0]["file5"].ToString();
        if (file5 != "" && file5 != null)
        {
            ZX_Email1BU email5 = new ZX_Email1BU();
            bool Cunzai5 = email5.IfCzFile(file5, "5");
            if (Cunzai5 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file5));
            }
            email5.Dispose();
        }
        emal1.DelMail(id);
        Response.Redirect("ReceiveMail.aspx", true);
        emal1.Close();
    }


    //回复邮件
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteMail.aspx?back=1&inboxid=" + Request.QueryString["id"]);
    }


    //转发邮件
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteMail.aspx?transfer=1&inboxid=" + Request.QueryString["id"]);
    }


    protected void mailForm1_DataBinding(object sender, EventArgs e)
    {
       
    }
    protected void mailForm1_DataBound(object sender, EventArgs e)
    {
        Control con1 = this.mailForm1.FindControl("info2") as Control;
        if (con1 != null)
        {
            if (this.hidHuiZhi.Value == "")
            {
                con1.Visible = false;
            }
            else
            {
                con1.Visible = true;
            }
        }
    }
}
