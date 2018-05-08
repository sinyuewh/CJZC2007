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

public partial class ZcMng2_EditZcDB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_ItemBU item1 = new U_ItemBU();
            if (Context.Items["wpkind"].ToString() == "0")
            {
                item1.ItemName = "抵押物类别";
                item1.SetLiteralControl(this.wplb, "请选择...");

            }
            else
            {
                item1.ItemName = "质押物类别";
                item1.SetLiteralControl(this.wplb, "请选择...");
            }
            item1.Close();

            if (Context.Items["id"] != null)
            {
                U_ZCBU zc1 = new U_ZCBU();
                DataSet ds1 = zc1.GetDZYWInfoByID(Context.Items["id"].ToString());
                zc1.Close();

                ViewState["id"] = Context.Items["id"];

                Util.SetControlValue(wplb, ds1.Tables[0].Rows[0]["wplb"]);
                Util.SetControlValue(wpsl, ds1.Tables[0].Rows[0]["wpsl"]);
                Util.SetControlValue(wpdw, ds1.Tables[0].Rows[0]["wpdw"]);
                Util.SetControlValue(wpjz, ds1.Tables[0].Rows[0]["wpjz"]);
            }
                //////////////////////////////////////////////////////////////
            string wpkind = Context.Items["wpkind"].ToString();
            if (wpkind == "0")
            {
                this.dzkind.Text = "抵 押 物 详 细 信 息";
            }
            else
            {
                this.dzkind.Text = "质 押 物 详 细 信 息";
            }
            if (Context.Items["zcid"] != null)
            {
                ViewState["zcid"] = Context.Items["zcid"];
            }
            if (Context.Items["wpkind"] != null)
            {
                ViewState["wpkind"] = Context.Items["wpkind"];
            }
        }
    }
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["zcid"] = ViewState["zcid"].ToString();
        ht["wpkind"] = ViewState["wpkind"].ToString();
        ht["wplb"] = this.wplb.SelectedValue;
        ht["wpsl"] = this.wpsl.Text;
        ht["wpdw"] = this.wpdw.Text;
        if (this.wpjz.Text != "")
        {
            ht["wpjz"] = this.wpjz.Text;
        }
        U_ZCBU zc2 = new U_ZCBU();
        if (ViewState["id"] == null)
        {
            zc2.InsertDZYW(ht);
        }
        else
        {
            zc2.UpdateDZYWInfo(ViewState["id"].ToString(), ht);
        }
        zc2.Close();
        Response.Redirect("ZcDetail9.aspx?id=" + ViewState["zcid"].ToString(), true);
    }
}
