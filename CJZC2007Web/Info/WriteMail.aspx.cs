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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.IO;

public partial class Info_WriteMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.to1.Attributes["ReadOnly"] = "";
            this.setMail();
            this.BindData();
        }
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //如果是转发邮件，需要判断邮件的数量(2008年6月1日)
            //编码：金寿吉 时间：2008年6月1日
            /*----判断上传附件的数量---------*/
            int MaxFile = 0;
            int begin = 0;
            String[] TranFile = new String[5];
            if (Request.QueryString["inboxid"] != null)
            {
                foreach (RepeaterItem item in this.tranReapeater.Items)
                {
                    CheckBox chk1 = item.FindControl("chkfile") as CheckBox;
                    if (chk1.Checked)
                    {
                        Label lab2 = item.FindControl("labTransFile") as Label;
                        TranFile[begin] = lab2.Text;        //保存转发的附件
                        MaxFile++;
                        begin++;
                    }
                }

                //累计用户上传的附件
                if (MaxFile <= 5)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        FileUpload file = this.FileUpload1.Parent.FindControl("FileUpload" + i) as FileUpload;
                        if (file != null && file.PostedFile != null && file.PostedFile.FileName != String.Empty)
                        {
                            MaxFile++;
                        }
                    }
                }
            }
            

            //处理附件上传
            if (MaxFile <= 5)
            {
                Hashtable ht = new Hashtable();
                ht["to1"] = this.to1.Text;
                ht["title"] = this.title.Text.Trim();
                ht["remark"] = this.remark.Text;
                ht["time0"] = DateTime.Now.ToString();
                ht["from1"] = User.Identity.Name;

                //处理转发的附件
                int hbegin = 1;
                for (int i = 0; i < TranFile.Length; i++)
                {
                    if (TranFile[i] != null && TranFile[i] != String.Empty)
                    {
                        ht["file" + hbegin] = TranFile[i];
                        hbegin++;
                    }
                }


                //处理上传的附件
                if (this.FileUpload1.PostedFile != null)
                {
                    string ExcelName1 = FileUpload1.PostedFile.FileName;
                    string file1 = User.Identity.Name + "_" + Util.GetRandomString(9) + "_" + Path.GetFileName(ExcelName1);
                    if (Path.GetFileName(ExcelName1) != "")
                    {
                        ht["file" + hbegin] = file1;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file1));
                        hbegin++;
                    }
                }
                if (this.FileUpload2.PostedFile != null)
                {
                    string ExcelName2 = FileUpload2.PostedFile.FileName;
                    string file2 = User.Identity.Name + "_" + Util.GetRandomString(9) + "_" + Path.GetFileName(ExcelName2);
                    if (Path.GetFileName(ExcelName2) != "")
                    {
                        ht["file" + hbegin] = file2;
                        FileUpload2.PostedFile.SaveAs(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file2));
                        hbegin++;
                    }
                }
                if (this.FileUpload3.PostedFile != null)
                {
                    string ExcelName3 = FileUpload3.PostedFile.FileName;
                    string file3 = User.Identity.Name + "_" + Util.GetRandomString(9) + "_" + Path.GetFileName(ExcelName3);
                    if (Path.GetFileName(ExcelName3) != "")
                    {
                        ht["file" + hbegin] = file3;
                        FileUpload3.PostedFile.SaveAs(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file3));
                        hbegin++;
                    }
                }
                if (this.FileUpload4.PostedFile != null)
                {
                    string ExcelName4 = FileUpload4.PostedFile.FileName;
                    string file4 = User.Identity.Name + "_" + Util.GetRandomString(9) + "_" + Path.GetFileName(ExcelName4);
                    if (Path.GetFileName(ExcelName4) != "")
                    {
                        ht["file" + hbegin] = file4;
                        FileUpload4.PostedFile.SaveAs(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file4));
                        hbegin++;
                    }
                }
                if (this.FileUpload5.PostedFile != null)
                {
                    string ExcelName5 = FileUpload5.PostedFile.FileName;
                    string file5 = User.Identity.Name + "_" + Util.GetRandomString(9) + "_" + Path.GetFileName(ExcelName5);
                    if (Path.GetFileName(ExcelName5) != "")
                    {
                        ht["file" + hbegin] = file5;
                        FileUpload5.PostedFile.SaveAs(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file5));
                        hbegin++;
                    }
                }
                
                //发送邮件操作
                ZX_EmailBu email2 = new ZX_EmailBu();
                bool result = false;
                result = email2.AddMailTwo(ht);

                if (result)
                {
                    Comm.ShowInfo("操作提示：邮件发送成功！", Application["root"] + "/Info/SendMail.aspx");
                }
                else
                {
                    Util.alert(this.Page, "错误提示：邮件发送失败！");
                }
            }
            else
            {
                Util.alert(this.Page, "错误提示：上传的附件数量不等超过5个！");
            }
        }
    }


    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceiveMail.aspx", true);
    }


    //设置邮件信息
    private void setMail()
    {
        DataSet ds1=null;
        string id = null;

        if (Request.QueryString["tousers"] != null)
        {
            this.to1.Text = Server.UrlDecode(Request.QueryString["tousers"]);
        }

        if (Request.QueryString["sendid"] != null || Request.QueryString["inboxid"] != null)
        {
            //来自发件箱
            if (Request.QueryString["sendid"] != null)
            {
                id = Request.QueryString["sendid"];
                ZX_Email1BU email1 = new ZX_Email1BU();
                ds1 = email1.GetSendMail(id);
                email1.Close();
            }
            else
            {
                //来自收件箱
                id = Request.QueryString["inboxid"];
                ZX_EmailBu email2 = new ZX_EmailBu();
                ds1 = email2.GetUserMail(id);
                email2.Close();
            }
        }

        if (ds1 != null)
        {
            DataRow dr = ds1.Tables[0].Rows[0];
            if (Request["back"] != null)
            {
                this.Title = "回复邮件";    //回复邮件
                this.title.Text = "回复：" + dr["title"].ToString();
                this.to1.Text = dr["from1"].ToString();
                if (dr["remark"] != DBNull.Value)
                {
                    this.remark.Text = "<br><br><b>原邮件内容</b>：<br><hr>" + dr["remark"].ToString();
                }
            }
            else if (Request["transfer"] != null)
            {
                this.Title = "转发邮件";   //转发邮件
                this.title.Text = "转发：" + dr["title"].ToString();
                if (dr["remark"] != DBNull.Value)
                {
                    this.remark.Text = dr["remark"].ToString();
                }
                
                //设置转发邮件列表(2008年6月1日)
                //编码：金寿吉 时间：2008年6月1日
                /*----设置转发邮件---------*/ 
                DataTable FileTable = ViewState["FileTable"] as DataTable;
                if (FileTable==null)
                {
                    FileTable = new DataTable();
                    FileTable.Columns.Add("FileName");
                    FileTable.Columns.Add("FileName1");
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dr["file" + i].ToString().Trim() != String.Empty)
                        {
                            DataRow dr1 = FileTable.NewRow();
                            dr1["FileName"] = dr["file" + i].ToString().Trim();
                            dr1["FileName1"] = dr["file" + i].ToString().Trim().Split('_')[2];
                            FileTable.Rows.Add(dr1);
                        }
                    }
                    ViewState["FileTable"] = FileTable;
                }
                if (FileTable.Rows.Count > 0)
                {
                    this.transRow.Visible = true;
                    this.tranReapeater.DataSource = FileTable;
                    this.tranReapeater.DataBind();
                }
                /*----设置转发邮件---------*/ 

            }
            else if (Request["again"] != null)
            {
                this.Title = "重发邮件";   //重发邮件
                this.title.Text = dr["title"].ToString();
                this.to1.Text = dr["to1"].ToString();
                if (dr["remark"] != DBNull.Value)
                {
                    this.remark.Text = dr["remark"].ToString();
                }
            }
            else
            {
                ;
            }
        }

    }


    //绑定有人员的部门数据
    private void BindData()
    {
        U_DepartBU depart1 = new U_DepartBU();
        DataSet ds1 = depart1.GetAllDepart1();
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
        depart1.Close();
        
    }


    //绑定人员
    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lab1 = e.Item.FindControl("labDepart") as Label;
        if (lab1 != null)
        {
            U_UserNameBU user1 = new U_UserNameBU();
            DataSet Person1 = user1.GetAllUserList(lab1.Text);
            user1.Close();

            DataList datalist1 = e.Item.FindControl("DataListForPerson") as DataList;
            if (datalist1 != null)
            {
                datalist1.DataSource = Person1;
                datalist1.DataBind();
            }
            datalist1.Dispose();
        }
    }
}
