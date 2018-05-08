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
            /*
            U_ItemBU item1 = new U_ItemBU();
            item1.ItemName = "资产时效";
            item1.SetLiteralControl(timename, null);
            item1.Close();*/

            U_TimeTypeBU.SetLiteralControl(this.timename, "");

            PubComm.SetTimeDays(tellday);
            this.SetPageData();

        }
    }

    //更新资料
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
                //Util.alert(this.Page, "错误信息：时效日期不能为空！");
                //check = false;
                ht.Remove("time0");
            }
            
            
            if (check)
            {
                U_ZCTimeBU time1 = new U_ZCTimeBU();
                string remark;
                int parentid=time1.EditTimeData(Request["tcid"],ht,out remark);
                time1.Close();

                string title = String.Format("{0}已修改了{1}时效管理数据，请审阅",User.Identity.Name,this.hidCorp.Value);
                
                //发送邮件
                if (remark != "")
                {
                    PubComm.SendMailToLeader(title, remark, Application["root"] + "/ZcMng2/ZcDetail1.aspx?id=" + this.HiddenField1.Value);
                }
                Response.Redirect("ZcDetail6.aspx?id=" + parentid, true);
            }
             
        }
    }

    private void SetPageData()
    {
        if (Request["tcid"] != null)
        {
            U_ZCTimeBU time1 = new U_ZCTimeBU();
            Hashtable ht = time1.GetTimeDataByID(Request["tcid"]);
            time1.Close();
            if (ht.Count > 0)
            {
                foreach (string item in arr1)
                {
                    Util.SetControlValue(this.timename.Parent.FindControl(item), ht[item]);
                }
            }
            if (this.time0.Text != "" && this.time0.Text != null)
            {
                this.time0.Text = DateTime.Parse(this.time0.Text).ToString("yyyy-M-d");
            }

            string sName = "";
            string zcid = ht["zcid"].ToString();
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds2=zc1.GetDetailByID(zcid);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                sName = ds2.Tables[0].Rows[0]["danwei"].ToString();
            }
            zc1.Close();
            this.hidCorp.Value = sName;
            this.HiddenField1.Value = ht["zcid"].ToString();
        }
    }
}
