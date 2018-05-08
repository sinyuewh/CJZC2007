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

public partial class ZcMng2_EditZcCzfs1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items["id"] != null)
            {
                U_ZCBU zc1 = new U_ZCBU();
                DataSet ds1 = zc1.GetBCZFSInfoByID(Context.Items["id"].ToString());
                zc1.Close();

                ViewState["id"] = Context.Items["id"];

                Util.SetControlValue(czfs, ds1.Tables[0].Rows[0]["czfs"]);
                Util.SetControlValue(czjg, ds1.Tables[0].Rows[0]["czjg"]);
                Util.SetControlValue(czss, ds1.Tables[0].Rows[0]["czss"]);
                Util.SetControlValue(qcl, ds1.Tables[0].Rows[0]["qcl"]);
                Util.SetControlValue(yjfy, ds1.Tables[0].Rows[0]["yjfy"]);
            }
            if (Context.Items["zcid"] != null)
            {
                ViewState["zcid"] = Context.Items["zcid"];
            }
            if (Context.Items["czid"] != null)
            {
                ViewState["czid"] = Context.Items["czid"];
            }
        }
    }
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["bid"] = ViewState["zcid"].ToString();
        ht["czid"] = ViewState["czid"].ToString();
        ht["czfs"] = this.czfs.Text;
        if (this.czjg.Text != "")
        {
            ht["czjg"] = this.czjg.Text;
        }
        if (this.czss.Text != "")
        {
            ht["czss"] = this.czss.Text;
        }
        if (this.qcl.Text != "")
        {
            ht["qcl"] = this.qcl.Text;
        }
        if (this.yjfy.Text != "")
        {
            ht["yjfy"] = this.yjfy.Text;
        }
        U_ZCBU zc2 = new U_ZCBU();
        if (ViewState["id"] == null)
        {
            zc2.InsertBCZFS(ht);
        }
        else
        {
            zc2.UpdateBCZFSInfo(ViewState["id"].ToString(), ht);
        }
        zc2.Close();
        Response.Redirect("ZcBaoDetail3.aspx?id=" + ViewState["zcid"].ToString(), true);
    }
}
