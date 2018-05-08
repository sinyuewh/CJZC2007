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
using System.IO;

public partial class Info_DelEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["kind"] != null && Request["kind"] == "1")
            {
                ZX_EmailBu Email = new ZX_EmailBu();
                DataSet ds1 = Email.GetUserMail1(Request["id"].ToString());
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string file1 = ds1.Tables[0].Rows[i]["file1"].ToString();
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
                    string file2 = ds1.Tables[0].Rows[i]["file2"].ToString();
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
                    string file3 = ds1.Tables[0].Rows[i]["file3"].ToString();
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
                    string file4 = ds1.Tables[0].Rows[i]["file4"].ToString();
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
                    string file5 = ds1.Tables[0].Rows[i]["file5"].ToString();
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
                    string id = ds1.Tables[0].Rows[i]["id"].ToString();
                    Email.DelMail(id);
                    Email.Close();
                }
                Response.Redirect("ReceiveMail.aspx",false);
            }
            else if (Request["kind"] != null && Request["kind"] == "2")
            {
                ZX_Email1BU emal1 = new ZX_Email1BU();
                DataSet ds1 = emal1.GetSendMail1(Request["id"].ToString());
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string file1 = ds1.Tables[0].Rows[0]["file1"].ToString();
                    if (file1 != "" && file1 != null)
                    {
                        ZX_EmailBu email1 = new ZX_EmailBu();
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
                    string id = ds1.Tables[0].Rows[i]["id"].ToString();
                    emal1.DelMail(id);
                    emal1.Close();
                }
                Response.Redirect("SendMail.aspx",false);
            }
        }
    }
}
