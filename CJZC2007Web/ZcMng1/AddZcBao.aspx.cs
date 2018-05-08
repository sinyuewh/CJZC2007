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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using System.Collections.Generic;

public partial class ZcMng1_AddZcBao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["Bname"] = this.Bname.Text;
        ht["Bjsf"] = this.Bjsf.Text;
        ht["Bremark"] = this.Bremark.Text;
        ht["Bzeren"] = this.Bzeren.Text;
        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        DataSet ds1 = zcb1.GetZCBAOInfo(this.Bname.Text);
        if (ds1.Tables[0].Rows.Count <= 0)
        {
            ht.Add("Bren", this.User.Identity.Name);
            zcb1.InsertData(ht);
            string url = Request.RawUrl;
            Comm.ShowInfo("增加资产包成功！", url, true);
        }
        else
        {
            Util.alert(this.Page, "该包名已经存在，请重新输入！");
        }
    }
}
