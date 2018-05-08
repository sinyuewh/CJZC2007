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

                CW_OutStockBU out1 = new CW_OutStockBU();
                this.bill.Text = out1.GetBillNum();
                out1.Close();
            }
            this.BindData();
            this.billtime.Attributes["onfocus"] = "setday(this)";
        }
    }

    private void BindData()
    {
        CW_StockBillBU stock1 = new CW_StockBillBU();
        this.Repeater1.DataSource = stock1.GetStockListByZcID(Request.QueryString["zcid"]);
        this.Repeater1.DataBind();
        stock1.Close();
    }

    //审核出库单
    //暂时不考虑库存数量的输入错误等导致的错误（金寿吉）
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "bill", "billtime", "danwei", "zeren", "remark", "billmen" };
        for (int i = 0; i < arr1.Length; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.billmen.Parent.FindControl(arr1[i])));
        }
        ht.Add("zcid", Request.QueryString["zcid"]);

        //增加出库单明细
        DataSet ds = new DataSet();
        ds.Tables.Add("Tables0");
        ds.Tables[0].Columns.Add("bill",System.Type.GetType("System.String"),"'"+this.bill.Text+"'");
        ds.Tables[0].Columns.Add("price", System.Type.GetType("System.Int32"), "'0'");

        string[] arr2 = new string[] {"gkind", "gname", "ggxh", "num", "remark", "dw","stockid"};
        for (int i = 0; i < arr2.Length; i++)
        {
            ds.Tables[0].Columns.Add(arr2[i]);
        }
        

        for (int i = 0; i < this.Repeater1.Items.Count; i++)
        {
            DataRow dr = ds.Tables[0].NewRow();
            for (int j = 0; j < arr2.Length; j++)
            {
                dr[arr2[j]]=Util.GetControlValue(this.Repeater1.Items[i].FindControl(arr2[j]));
            }
            ds.Tables[0].Rows.Add(dr);
        }

        ///////////////////////////////////////////
        try
        {
            CW_OutStockBU stock1=new CW_OutStockBU();
            bool result = stock1.InsertData(ht,ds);
            stock1.Close();
            if (result)
            {
                PubComm.ShowInfo("【增加出库单据】操作成功!", Application["root"] + "/Caiwu/ZcSearch.aspx");
            }
        }
        catch
        {
            PubComm.ShowInfo("【增加出库单据】操作失败，可能的原因是单据编号重复，请重新输入!", Request.RawUrl);
        }
    }
}
