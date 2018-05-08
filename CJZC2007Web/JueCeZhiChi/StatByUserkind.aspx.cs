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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class JueCeZhiChi_StatByUserkind : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Comm.SetDepart(this.depart, "所有部门");

            /////////////////////////////////////
            ;
            this.depart.SelectedValue = "";
            ///////////////////////////////////////
            U_ItemBU item1 = new U_ItemBU(); ;

            item1.ItemName = "行政区域";
            item1.SetLiteralControl(this.quyu, "全部...");

            item1.ItemName = "行业分类";
            item1.SetLiteralControl(this.hangye, "全部...");

            item1.ItemName = "资产性质分类";
            item1.SetLiteralControl(this.fenlei, "全部...");

            item1.Setuserkind(this.userkind);
            item1.Close();
            ////////////////////////////////////////////

            depart_SelectedIndexChanged(this.depart, e);

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<SearchField> list1 = new List<SearchField>();
        ////////////////////////////////////////////////
        //行业
        if (this.hangye.SelectedValue != "")
        {
            list1.Add(new SearchField("sshy", this.hangye.SelectedValue));
        }

        //区域
        if (this.quyu.SelectedValue != "")
        {
            list1.Add(new SearchField("quyu", this.quyu.SelectedValue));
        }

        //资产类别
        if (this.fenlei.SelectedValue != "")
        {
            list1.Add(new SearchField("fenlei", this.fenlei.SelectedValue));
        }

        //责任部门4
        if (this.depart.SelectedValue != "")
        {
            list1.Add(new SearchField("U_depart", this.depart.SelectedValue));
        }
        //责任人5
        if (this.zeren.SelectedValue != "")
        {
            list1.Add(new SearchField("zeren", this.zeren.SelectedValue));
        }

        //用户自定义分类
        string userkind = "";
        int last = 0;
        bool first = true;
        for (int i = 0; i < this.userkind.Items.Count; i++)
        {
            ListItem list2 = this.userkind.Items[i];
            if (list2.Selected)
            {
                last = i;
            }
        }
        for (int i = 0; i < this.userkind.Items.Count; i++)
        {
            ListItem list3 = this.userkind.Items[i];
            if (list3.Selected)
            {
                if (first)
                {
                    userkind = " ( charindex('" + list3.Value + "',userkind) >0 ";
                    first = false;
                }
                if (first == false && i < last)
                {
                    userkind = userkind + " or  charindex('" + list3.Value + "',userkind) >0 ";
                }
                if (first == false && i == last)
                {
                    userkind = userkind + " or  charindex('" + list3.Value + "',userkind) >0 )";
                }
                if (first == true && i == last)
                {
                    userkind = " charindex('" + list3.Value + "',userkind) >0 ";
                }
            }
        }
        if (userkind != "")
        {
            list1.Add(new SearchField("", userkind, SearchOperator.用户定义));
        }

        HttpContext.Current.Items["SearchCondition"] = list1;
        HttpContext.Current.Items["SearchKind"] = "按状态统计";
        Server.Transfer("~/JueCeZhiChi/StatByStatusResult.aspx", false);
    }

    protected void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "所有责任人");
        this.zeren.SelectedValue = "";
    }
}
