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
using System.IO;

public partial class Info_AlreadySendMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    //绑定数据
    private void BindData()
    {
        string id=Request.QueryString["id"].ToString();
        ZX_Email1BU emal1 = new ZX_Email1BU();
        DataSet ds1 = emal1.GetSendMail(id);
        this.mailForm1.DataSource = ds1;
        this.mailForm1.DataBind();
        emal1.Close();
    }


    //返回发件箱
    protected void btn1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SendMail.aspx", true);
    }


    //删除邮件
    protected void Button1_Click(object sender, EventArgs e)
    {
        ZX_Email1BU emal1 = new ZX_Email1BU();
        string id = Request.QueryString["id"];
        DataSet ds1 = emal1.GetSendMail(id);
        string file1 = ds1.Tables[0].Rows[0]["file1"].ToString();
        if (file1 != "" && file1 != null)
        {
            ZX_EmailBu email1 = new ZX_EmailBu();
            bool Cunzai = email1.IfCzFile(file1, "1");
            if(Cunzai == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file1));
            }
            email1.Dispose();
        }
        string file2 = ds1.Tables[0].Rows[0]["file2"].ToString();
        if (file2 != "" && file2 != null)
        {
            ZX_EmailBu email2 = new ZX_EmailBu();
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
            ZX_EmailBu email3 = new ZX_EmailBu();
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
            ZX_EmailBu email4 = new ZX_EmailBu();
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
            ZX_EmailBu email5 = new ZX_EmailBu();
            bool Cunzai5 = email5.IfCzFile(file5, "5");
            if (Cunzai5 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file5));
            }
            email5.Dispose();
        }
        emal1.DelMail(id);
        emal1.Close();
        PubComm.ShowInfo("操作提示：删除留言数据成功！", Application["root"] + "/info/SendMail.aspx");
    }

    //转发邮件
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteMail.aspx?transfer=1&sendid=" + Request.QueryString["id"], true);
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteMail.aspx?again=1&sendid=" + Request.QueryString["id"], true);
    }
}
