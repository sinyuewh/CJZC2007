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

public partial class ZcMng2_AddTime : System.Web.UI.Page
{
    string[] arr1 = new string[] { "timename", "time0", "tellday", "remark" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_TimeTypeBU.SetLiteralControl(this.timename, "");

            PubComm.SetTimeDays(tellday);
            this.time0.Attributes["onfocus"] = "javascript:setday(this);";
        }
    }

    //增加资产时效
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool check = true;
            Hashtable ht = new Hashtable();
            foreach (string item in arr1)
            {
                ht.Add(item, Util.GetControlValue(this.timename.Parent.FindControl(item)));
            }
            if (ht["time0"].ToString().Trim() == "")
            {
                ht.Remove("time0");
            }
            ht["ZCID"] = Request["parentid"];

            /////////////////////////////////////////////////////
            if (check)
            {
                U_ZCTimeBU time1 = new U_ZCTimeBU();
                string err1 = time1.InsertTimeData(ht);
                time1.Close();
                if (err1 == null)
                {
                    Response.Redirect("ZcDetail6.aspx?id=" + Request["parentid"], true);
                }
                else
                {
                    Util.alert(this.Page, err1);
                }
            }
        }
    }
}
