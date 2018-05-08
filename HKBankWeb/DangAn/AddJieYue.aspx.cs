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
public partial class DangAn_AddJieYue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DA_JieYuanBU jyue1 = new DA_JieYuanBU();
            string bill = jyue1.GetBillNum();

            this.zeren.Attributes["readonly"] = "";
            this.bill.Text = bill;
            this.billtime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.billtime.Attributes["onfocus"] = "setday(this)";
            this.paytime.Attributes["onfocus"] = "setday(this)";
            this.billmen.Text = User.Identity.Name;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        object[] obj0=new object[]{bill, billtime, billmen, zeren,paytime,remark };
        object[] obj1 = new object[] { bill, billtime, billmen, zeren, paytime};
        string[] info = new string[] { "单据编号", "开票时间", "开票员", "借阅人","要求归还时间" };
        bool check = true;
        for (int i = 0; i < info.Length; i++)
        { 
            if(Util.GetControlValue((Control)obj1[i])==null || Util.GetControlValue((Control)obj1[i])=="")
            {
                check =false;
                Util.alert(this.Page,"错误提示：【" + info[i] + "】栏目不能为空！");
                break;
            }
        }
        if(check)
        {
            try
            {
                Hashtable ht=new Hashtable();
                Util.getPageData(obj0,ht);
                //ht.Add("status", "0");
                DA_JieYuanBU jyue1=new DA_JieYuanBU();
                jyue1.TabCommand.InsertData(ht);
                jyue1.Close();
                Util.alert(this.Page,"增加借阅单成功！");
                DA_JieYuanBU jyue2 = new DA_JieYuanBU();
                string id= jyue2.GetIdBybill(this.bill.Text.ToString());
                Response.Redirect("EditJieYueInfo.aspx?id="+id);
            }
            catch
            {
                Util.alert(this.Page, "错误提示：增加资产数据失败，可能的原因是数据类型有错误，请检查后重新输入！");
            }
        }
    }
}
