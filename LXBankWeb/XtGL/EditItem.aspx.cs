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

public partial class XtGL_EditItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != null)
            {
                U_ItemBU item1 = new U_ItemBU();
                Hashtable ht = item1.GetDetailByID(Request["id"]);
                this.itemtext.Text = ht["itemtext"].ToString();
                this.itemvalue.Text = ht["itemvalue"].ToString();
                item1.Close();
            }
            else
            {
                Response.Redirect("~/Error.aspx", true);
            }
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.itemvalue.Text = this.itemvalue.Text.Replace("，", ",");
        Hashtable ht = new Hashtable();
        ht.Add("itemvalue", this.itemvalue.Text);
        U_ItemBU item1 = new U_ItemBU();
        item1.SaveObject(Request["id"], ht);
        item1.Close();

        Util.alert(this.Page, "提示：操作成功！");
    }

    //return 
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ItemList.aspx", true);
    }
}
