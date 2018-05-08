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

public partial class CaiWu_AddShouKuan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.billtime.Text = DateTime.Now.ToString("yyyy-M-d");
            this.billmen.Text = User.Identity.Name;
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetDetailByID(Request.QueryString["zcid"], "danwei,zeren");
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Util.SetControlValue(danwei, ds.Tables[0].Rows[0]["danwei"]);
                Util.SetControlValue(zeren, ds.Tables[0].Rows[0]["zeren"]);

                CW_InStockBU stock1 = new CW_InStockBU();
                this.bill.Text = stock1.GetBillNum();
                stock1.Close();
            }
            this.BindData();
            this.billtime.Attributes["onfocus"] = "setday(this)";
        }
    }


    //保存支出单据
    protected void SaveDataClick(object sender, EventArgs e)
    {
        this.SetDataSource();
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "bill", "billtime", "danwei", "zeren", "remark", "billmen" };
        for (int i = 0; i < arr1.Length; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.billmen.Parent.FindControl(arr1[i])));
        }
        ht.Add("zcid", Request.QueryString["zcid"]);

        DataSet ds = (DataSet)ViewState["DataSource"];
        try
        {
            CW_InStockBU stock1 = new CW_InStockBU();
            bool result = stock1.InsertData(ht, ds);
            stock1.Close();
            if (result)
            {
                Comm.ShowInfo("【增加入库单据】操作成功!", Application["root"] + "/Caiwu/ZcSearch.aspx");
            }
        }
        catch
        {
            Comm.ShowInfo("【增加入库单据】操作失败，可能的原因是单据编号重复，请重新输入!", Request.RawUrl);
        }
    }

    //增加单据明细
    protected void AddPayBill(object sender, EventArgs e)
    {
        DataSet ds = null;
        if (ViewState["DataSource"] != null)
        {
            ds = (DataSet)ViewState["DataSource"];
            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);
        }
        this.SetDataSource();
        this.BindData();
    }

    //绑定数据
    private void BindData()
    {
        DataSet ds = null;
        if (ViewState["DataSource"] == null)
        {
            ds = new DataSet();
            ds.Tables.Add("InStock");
            ds.Tables[0].Columns.Add("gkind");
            ds.Tables[0].Columns.Add("gname");
            ds.Tables[0].Columns.Add("ggxh");
            ds.Tables[0].Columns.Add("num");
            ds.Tables[0].Columns.Add("price");
            ds.Tables[0].Columns.Add("dw");
            ds.Tables[0].Columns.Add("remark");

            for (int i = 0; i < 3; i++)
            {
                DataRow dr = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(dr);
            }
            ViewState["DataSource"] = ds;
        }
        else
        {
            ds = (DataSet)ViewState["DataSource"];
        }

        this.Repeater1.DataSource = ds;
        this.Repeater1.DataBind();
    }
    #region Repeater Events
    //删除单据明细
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        this.SetDataSource();
        if (e.Item.FindControl("seldoc") != null)
        {
            int num1 = Int32.Parse((e.Item.FindControl("seldoc") as Label).Text);
            DataSet ds = null;
            if (ViewState["DataSource"] != null)
            {
                ds = (DataSet)ViewState["DataSource"];
                ds.Tables[0].Rows.RemoveAt(num1);
            }
            this.BindData();
        }
    }
    #endregion

    //保存DataSet中的数据
    private void SetDataSource()
    {
        DataSet ds = null;
        if (ViewState["DataSource"] != null)
        {
            ds = (DataSet)ViewState["DataSource"];
        }

        string[] arr1 = new string[] { "gkind","gname", "ggxh", "num","price","dw","remark" };
        for (int i = 0; i < this.Repeater1.Items.Count; i++)
        {
            for (int j = 0; j < arr1.Length; j++)
            {
                ds.Tables[0].Rows[i][j] = Util.GetControlValue(this.Repeater1.Items[i].FindControl(arr1[j]));
            }
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.FindControl("gkind")!=null)
        {
            DropDownList list1 = (DropDownList)e.Item.FindControl("gkind");
            U_ItemBU item1 = new U_ItemBU();
            item1.SetLiteralControl(list1, "抵债物资类别", "请选择...");
            item1.Close();
        }
    }
}
