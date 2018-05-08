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

public partial class DangAn_AddJieyueFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string bill = Request.QueryString["bill"];
            this.bill.Text = bill.ToString();
        }
    }

    //确定文件的借阅
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Files = "";
        Hashtable ht=new Hashtable();
        for (int i = 1; i < 6; i++)
        {
            string temp = Util.GetControlValue(this.title1.Parent.FindControl("title" + i));
            string temp1 = Util.GetControlValue(this.title1.Parent.FindControl("ajnum" + i));
            if (temp.Trim() != "")
            {
                ht[temp.Trim()] = temp.Trim()+"_"+temp1.Trim();
            }
            if (temp != "" && temp1 == "")
            {
                if (Files == "")
                {
                    Files = i.ToString();
                }
                else
                {
                    Files = Files + "," + i;
                }
            }
        }

        if (ht.Count == 0)
        {
            Util.alert(this.Page, "错误提示：你至少需要输入一个文件名称");
        }
        else
        {
            if (Files != "")
            {
                Util.alert(this.Page, "错误提示：请检查文件" + Files + "是否输入档案编号!");
            }
            else
            {
                DA_JieYuanBU jyue1 = new DA_JieYuanBU();
                string result = jyue1.AddJyueFileData(Request.QueryString["bill"], ht);
                string id = jyue1.GetIdBybill(Request.QueryString["bill"]);
                jyue1.Close();
                if (result == null)
                {
                    Comm.ShowInfo("提示：增加文件成功！", Application["root"] + "/DangAn/EditJieyueInfo.aspx?id=" + id);
                }
                else
                {
                    Util.alert(this.Page, result);
                }
            }

        }
    }

    //返回到借阅单
    protected void Button2_Click(object sender, EventArgs e)
    {
        DA_JieYuanBU jyue1 = new DA_JieYuanBU();
        string id = jyue1.GetIdBybill(Request.QueryString["bill"]);
        jyue1.Close();
        Response.Redirect("EditJieyueInfo.aspx?id="+id, true);
    }
}
