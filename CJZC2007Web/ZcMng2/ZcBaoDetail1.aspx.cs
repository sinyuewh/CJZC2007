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
using System.Collections.Generic;

public partial class ZcMng2_ZcBaoDetail1 : System.Web.UI.Page
{
    double sum1 = 0, sum2 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetPageData();
            this.BindZcInfo();
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    private void SetPageData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            DataSet ds = zcb1.GetZCBAOInfoByID(id);
            zcb1.Close();

            //设置控件的值
            bool owner = false;
            string user1 = "";
            if (ds.Tables[0].Rows[0]["bzeren"] != DBNull.Value)
            {
                user1 = ds.Tables[0].Rows[0]["bzeren"].ToString();
            }

            if (user1 == User.Identity.Name || (user1.Trim() == "" && Comm.IsRole("系统管理员")))
            {
                owner = true;
            }
            else
            {
                this.Button1.Visible = false;
            }

            //设置控件数据的显示
            for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
            {
                string colName = ds.Tables[0].Columns[i].ColumnName.ToLower();
                if (owner)
                {
                    if (this.Bname.Parent.FindControl(colName) != null)
                    {
                        Util.SetControlValue(this.Bname.Parent.FindControl(colName), ds.Tables[0].Rows[0][colName]);
                    }
                    if (this.Bname.Parent.FindControl(colName + "_1") != null)
                    {
                        this.Bname.Parent.FindControl(colName + "_1").Visible = false; ;
                    }
                }
                else
                {
                    if (this.Bname.Parent.FindControl(colName + "_1") != null)
                    {
                        Util.SetControlValue(this.Bname.Parent.FindControl(colName + "_1"), ds.Tables[0].Rows[0][colName]);
                    }
                    if (this.Bname.Parent.FindControl(colName) != null)
                    {
                        this.Bname.Parent.FindControl(colName).Visible = false; ;
                    }
                }
            }

            //设置数字金额的显示
            string[] num1 = new string[] { "Bljsk", "Bljzc" };
            for (int i = 0; i < num1.Length; i++)
            {
                TextBox t1 = this.Bljsk.Parent.FindControl(num1[i]) as TextBox;
                Label l1 = this.Bljsk.Parent.FindControl(num1[i] + "_1") as Label;
                if (t1 != null)
                {
                    t1.Text = Comm.GetNumberFormat(t1.Text);
                }
                if (l1 != null)
                {
                    l1.Text = Comm.GetNumberFormat(l1.Text);
                }
            }
        }
    }

    //资产包详细信息
    private void BindZcInfo()
    {
        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        string ids = zcb1.GetZCIDByBID(Request["ID"].ToString());
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds1 = zc1.GetZCInfoByID(ids);
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
        zcb1.Close();

        //统计总和
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            DataRow dr = ds1.Tables[0].Rows[i];
            if (dr["bj"] != DBNull.Value)
            {
                this.sum1 = this.sum1 + double.Parse(dr["bj"].ToString());
            }
            if (dr["lxhj"] != DBNull.Value)
            {
                this.sum2 = this.sum2 + double.Parse(dr["lxhj"].ToString());
            }
        }
    }

    protected void SaveDataClick(object sender, EventArgs e)
    {

    }


    protected override void Render(HtmlTextWriter writer)
    {
        //设置统计信息
        foreach (Control item in this.Repeater1.Controls)
        {
            RepeaterItem item1 = (RepeaterItem)item;
            if (item1.ItemType == ListItemType.Footer)
            {
                if (item.FindControl("labSum1") != null)
                {
                    Label lab1 = item.FindControl("labSum1") as Label;
                    Label lab2 = item.FindControl("labSum2") as Label;

                    lab1.Text = Comm.GetNumberFormat(sum1);
                    lab2.Text = Comm.GetNumberFormat(sum2);
                    break;
                }
            }
        }
        base.Render(writer);
    }
}
