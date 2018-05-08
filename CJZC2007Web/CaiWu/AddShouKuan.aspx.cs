﻿using System;
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
            DataSet ds=zc1.GetDetailByID(Request.QueryString["zcid"],"danwei,zeren");
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Util.SetControlValue(danwei,ds.Tables[0].Rows[0]["danwei"]);
                Util.SetControlValue(zeren, ds.Tables[0].Rows[0]["zeren"]);

                CW_ShouKuanBU sk1 = new CW_ShouKuanBU();
                this.bill.Text = sk1.GetBillNum();
                sk1.Close();
            }
            this.billtime.Attributes["onfocus"] = "setday(this)";
        }
    }

    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "bill","billtime","danwei","zeren","pbj","plx","remark","billmen"};
        for (int i = 0; i < arr1.Length; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.billmen.Parent.FindControl(arr1[i])));
        }
        ht.Add("zcid", Request.QueryString["zcid"]);
        try
        {
            CW_ShouKuanBU sk1 = new CW_ShouKuanBU();
            sk1.InsertData(ht);
            sk1.Close();

            Comm.ShowInfo("【增加收款单据】操作成功!", Application["root"] + "/Caiwu/ZcSearch.aspx");
        }
        catch
        {
            Comm.ShowInfo("【增加收款单据】操作失败，可能的原因是单据编号重复，请重新输入!", Request.RawUrl);
        }
    }
}