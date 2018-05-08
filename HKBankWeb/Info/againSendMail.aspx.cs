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

public partial class Info_againSendMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }
    private void BindData()
    {
        string id=Request.QueryString["id"];
        ZX_Email1BU email1 = new ZX_Email1BU();
        DataSet ds1 = email1.GetSendMail(id);
        this.title.Text = ds1.Tables[0].Rows[0]["title"].ToString();
        this.remark.Text = (Util.ChangeToShow(ds1.Tables[0].Rows[0]["remark"].ToString())).Replace("<br>", "");
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "to1", "title", "remark", "time0", "from1" };
        for (int i = 0; i < arr1.Length - 2; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.to1.Parent.FindControl(arr1[i])));
        }
        ht.Add(arr1[3], DateTime.Now.ToString());
        ht.Add(arr1[4], User.Identity.Name);

        /////////////////////////////////////////////////////
        if (ht["title"].ToString().Trim() == "" || ht["remark"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示，请输入标题或正文");
        }
        else
        {
            ////sender
            //ZX_Email1BU email1 = new ZX_Email1BU();
            //bool result = email1.AddMail(ht);

            //inbox
            ZX_EmailBu email2 = new ZX_EmailBu();
            bool result = email2.AddMailTwo(ht);

            if (result)
            {
                Response.Redirect("ReceiveMail.aspx", true);
            }
            else
            {
                Util.alert(this.Page, "错误提示：邮件发送失败！");
            }
        }
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("sendMail.aspx", true);
    }
}
