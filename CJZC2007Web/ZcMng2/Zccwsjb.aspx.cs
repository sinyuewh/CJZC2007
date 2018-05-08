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

public partial class ZcMng2_Zccwsjb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            this.BindList();
        }
    }

    private void BindData()
    {
        if (Request["zcid"] != null)
        {
            string id = Request["zcid"];
            U_ZCBU zc1 = new U_ZCBU();
            string fs = "danwei,depart,zeren,bj,lx,pbj,plx,fee1,fee2,fee3,fee4,fee5,fee6,fee7,fee8,fee9,fee10,fee11,fee12,bjye,lxye,hbxh,bxhjye,fyhj";
            DataSet ds = zc1.GetDetailByID(id, "danwei,depart,zeren,bj,pbj,plx,fee1,fee2,fee3,fee4,fee5,fee6,fee7,fee8,fee9,fee10,fee11,fee12,isnull(bj,0)-isnull(pbj,0) as bjye ,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0)-plx as lxye,isnull(pbj,0)+isnull(plx,0) as hbxh,isnull(bj,0)+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0)-isnull(pbj,0)-isnull(plx,0) as bxhjye,isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0)+isnull(fee13,0)+isnull(fee14,0)+isnull(fee15,0)+isnull(fee16,0)+isnull(fee17,0)+isnull(fee18,0)+isnull(fee19,0)+isnull(fee20,0) as fyhj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) as lx");
            zc1.Close();
            string[] AF = fs.Split(',');
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < AF.Length; i++)
                {
                    Util.SetControlValue(this.pbj.Parent.FindControl(AF[i]), ds.Tables[0].Rows[0][AF[i]]);
                }
            }
            //设置数字金额的显示
            string[] num1 = new string[] { "pbj", "plx", "fee1", "fee2", "fee3", "fee4", "fee5", "fee6", "fee7", "fee8", "fee9", "fee10", "fee11", "fee12", "bjye", "lxye", "hbxh", "bxhjye", "fyhj" };
            for (int i = 0; i < num1.Length; i++)
            {
                Label l1 = this.pbj.Parent.FindControl(num1[i]) as Label;
                if (l1 != null)
                {
                    l1.Text = Comm.GetNumberFormat(l1.Text);
                }
            }

            ds.Dispose();
        }
    }

    private void BindList()
    {
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("zcid", Request.QueryString["zcid"], SearchFieldType.数值型));
        DataSet ds1 = shoukuan1.GetBillList("0", list1, true);
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
        if (ds1.Tables[0].Rows.Count <= 0)
        {
            this.Repeater1.Visible = false;
        }
        ds1.Dispose();
        ////////////////////////////////////////////////////////////
        list1.Clear();
        list1.Add(new SearchField("zcid", Request.QueryString["zcid"], SearchFieldType.数值型));
        DataSet ds2 = shoukuan1.GetBillList("1", list1, true);
        this.Repeater2.DataSource = ds2;
        this.Repeater2.DataBind();
        if (ds2.Tables[0].Rows.Count <= 0)
        {
            this.Repeater2.Visible = false;
        }
        ds2.Dispose();
        shoukuan1.Close();
    }
}
