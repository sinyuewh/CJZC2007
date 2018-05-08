using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;

public partial class ZiChan_ZcDetail5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindList();
            if (Comm.IsRole("系统管理员"))
            {
                this.Button2.Visible = true;
            }
            else
            {
                this.Button2.Visible = false;
            }
        }
    }

     private void BindList()
    {
        string id = Request.QueryString["id"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetDetailByID(id, "danwei,depart,zeren");
        this.danwei.Text = ds.Tables[0].Rows[0]["danwei"].ToString();
        this.depart.Text = ds.Tables[0].Rows[0]["depart"].ToString();
        this.zeren.Text = ds.Tables[0].Rows[0]["zeren"].ToString();
        zc1.Close();
         
        CW_StockBillBU stock1 = new CW_StockBillBU();
        this.Repeater1.DataSource=stock1.GetStockListByZcID1(id);
        this.Repeater1.DataBind();
        stock1.Close();
        
         ////////////////////////////////////////
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        List<SearchField> list1=new List<SearchField>();
        list1.Add(new SearchField("zcid",Request.QueryString["id"],SearchFieldType.数值型));
        this.Repeater2.DataSource = shoukuan1.GetBillList("2", list1, true);
        this.Repeater2.DataBind();

        ////////////////////////////////////////////////////////////
        list1.Clear();
        list1.Add(new SearchField("zcid", Request.QueryString["id"], SearchFieldType.数值型));
        this.Repeater3.DataSource = shoukuan1.GetBillList("3", list1, true);
        this.Repeater3.DataBind();

        shoukuan1.Close();
    }

}
