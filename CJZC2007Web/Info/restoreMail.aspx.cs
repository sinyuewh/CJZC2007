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

public partial class Info_restoreMail : System.Web.UI.Page
{
    ZX_EmailBu email2 = new ZX_EmailBu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds1=email2.GetUserMail(Request.QueryString["id"]);
            this.to1.Text = ds1.Tables[0].Rows[0]["to1"].ToString();
            this.title.Text = "Re：" + ds1.Tables[0].Rows[0]["title"].ToString();
        }
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "title","remark"};
        for (int i = 0; i < arr1.Length; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.to1.Parent.FindControl(arr1[i])));
        }
        ht.Add("to1", this.to1.Text);
        ht.Add("time0", DateTime.Now.ToString());
        ht.Add("from1", User.Identity.Name);
      
        if (ht["title"].ToString().Trim() == "" || ht["remark"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示，请输入标题或正文");
        }
        else
        {
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
        Response.Redirect("ReceiveMail.aspx", true);
    }
}
