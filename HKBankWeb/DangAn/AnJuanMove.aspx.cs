using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class DangAn_AnJuanMove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetControlData();
            this.yjtime.Attributes["onfocus"] = "setday(this)";
            this.yjtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.jsren.Text = User.Identity.Name;
        }
    }
    //绑定页面控件的值

    private void SetControlData()
    {
        if (Request.QueryString["id"] != null)
        {
            string anjuanID = Request.QueryString["id"];
            DA_AnJuanBU anjuan1 = new DA_AnJuanBU();
            DataSet ds1 = anjuan1.GetDetailByID1(anjuanID);
            anjuan1.Close();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds1.Tables[0].Rows[0];
                this.ajname.Text = dr["ajname"].ToString();
                this.ajnum.Text = dr["ajnum"].ToString();
                this.ajstatus.Text = dr["ajstatus"].ToString();
            }
            else
            {
                throw new Exception("错误信息：案卷" + Request.QueryString["id"] + "不存在！");
            }
        }
    }
    //提交--移交案卷
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ajID = Request.QueryString["id"];

        this.ajstatus.Text = "2";
        object[] obj1 = new object[] { yjtime, yjdanwei, jsren, ajstatus,remark1 };
        string [] info=new string[]{"移交时间","移交单位","经手人"};
        bool check = true;
        for (int i = 0; i < info.Length; i++)
        {
            if (Util.GetControlValue((Control)obj1[i]) == null || Util.GetControlValue((Control)obj1[i]) == "")
            {
                check = false;
                Util.alert(this.Page, "错误提示：【" + info[i] + "】栏目不能为空！");
                break;
            }
        }

        if(check)
        {
            Hashtable ht = new Hashtable();
            Util.getPageData(obj1, ht);
            ht["ajstatus"] = "2";

            DA_AnJuanBU anjuan2 = new DA_AnJuanBU();
            bool result= anjuan2.MoveAnJuan(ajID, ht);
            anjuan2.Close();
            if (result)
            {
                string url = Application["root"]+"/DangAn/AnJuanWeiHu.aspx";
                PubComm.ShowInfo("提示：移交案卷成功！", url, true);
            }
            else 
            {
                Util.alert(this.Page, "错误提示：修改数据错误！");
            }
        }
    }
    //返回--按钮
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AnJuanWeiHu.aspx");
    }
}
