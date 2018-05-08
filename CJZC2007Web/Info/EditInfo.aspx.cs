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

public partial class Info_EditInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    //bind data
    private void BindData()
    {
        ZX_InfoBU info1 = new ZX_InfoBU();
        DataSet ds1 = info1.GetInfoByID(Request.QueryString["ID"]);
        this.title.Text = ds1.Tables[0].Rows[0]["title"].ToString();
        this.kind.SelectedValue = ds1.Tables[0].Rows[0]["kind"].ToString();
        this.remark.Text = ds1.Tables[0].Rows[0]["remark"].ToString();
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "title","kind","remark","time0"};
        for (int i = 0; i < arr1.Length-1; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.title.Parent.FindControl(arr1[i])));
        }
       
        ht["remark"] = this.remark.Text;
        ht.Add(arr1[3], DateTime.Now.ToString());
        ZX_InfoBU info1 = new ZX_InfoBU();
        bool result = info1.EditInfo(Request["ID"], ht);
        info1.Close();
        if (result)
        {
            //Util.alert(this.Page, "修改数据成功,按返回按钮，返回信息维护页面！");
            string newurl = Application["root"] + "/Info/InfoMaintenance.aspx";
            //Util.alert(this.Page, "修改数据成功,按确定按钮，返回信息维护页面！",newurl);
            Response.Redirect(newurl, true);
        }
        else
        {
            Util.alert(this.Page, "错误提示：修改数据错误！");
        }
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoMaintenance.aspx", true);
    }
}
