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

public partial class ZcMng2_Zcdbqkb : System.Web.UI.Page
{
    string[] arr1 = new string[] { "zwrhsgz", "bzrhsgz", "qthsgz", "hssj", "qsqk", "remark",
                                   "bzrmc","bzje","bzyx","bzcznl","bzczyy","bzwxsm","Remark1",
                                   "qdza1","qdzayy1","czza1","zzzayy1","bxny1","klazfy","flyj1",
                                   "dyhsgz1","Remark2","qdza2","qdzayy2","czza2","zzzayy2","bxny2",
                                   "flyj2","dyhsgz2","Remark3" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
            this.BindDZYW();
        }
    }

    private void BindData()
    {
        if (Request["zcid"] != null)
        {
            string zcid = Request["zcid"].ToString();
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetZCDBInfoByID(zcid);
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Util.SetControlValue(this.bzyx.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
                }
                if (ds.Tables[0].Rows[0]["hssj"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["hssj"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.bzyx.Parent.FindControl("hssj"), dt);
                }
            }
            string[] num1 = new string[] { "zwrhsgz", "bzrhsgz", "qthsgz", "bzje", "klazfy", "dyhsgz1", "dyhsgz2" };
            for (int i = 0; i < num1.Length; i++)
            {
                Label l1 = this.zwrhsgz.Parent.FindControl(num1[i]) as Label;
                if (l1 != null)
                {
                    l1.Text = PubComm.GetNumberFormat(l1.Text);
                }
            }
            ds.Dispose();
        }
    }

    private void BindDZYW()
    {
        if (Request["zcid"] != null)
        {
            string zcid = Request["zcid"].ToString();
            U_ZCBU zc2 = new U_ZCBU();
            for (int i = 1; i < 3; i++)
            {
                Repeater repeater1 = this.repeater1.Parent.FindControl("repeater" + i) as Repeater;
                if (repeater1 != null)
                {
                    int wpkind = i - 1;
                    DataSet ds = zc2.GetDZYWInfo(zcid, wpkind.ToString());
                    repeater1.DataSource = ds;
                    repeater1.DataBind();

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        repeater1.Visible = false;
                    }
                }
            }

            zc2.Close();
        }
    }
}
