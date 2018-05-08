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

public partial class CaiWu_StockSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_ItemBU item1 = new U_ItemBU();
            item1.SetLiteralControl(gkind, "抵债物资类别", "全部");
            this.BindData(null, null,null, false);
        }
    }

    private void BindData(string danwei, string gname,string gkind, bool flag)
    {
        CW_StockBillBU stock1 = new CW_StockBillBU();
        this.GridView1.DataSource = stock1.GetStockList1(danwei, gname,gkind, flag);
        this.GridView1.DataBind();
        stock1.Close();
    }


    protected void butSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.danwei.Text, this.gname.Text,this.gkind.SelectedValue, this.CheckBox1.Checked);
    }
}
