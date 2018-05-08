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

public partial class XtGL_ItemList : System.Web.UI.Page
{
    //load data
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    //bind data1
    private void BindData()
    {
        U_ItemBU item1 = new U_ItemBU();
        this.GridView1.DataSource = item1.GetAllItem();
        this.GridView1.DataBind();
        item1.Close();
    }
}
