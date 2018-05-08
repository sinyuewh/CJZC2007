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

public partial class CaiWu_CaiWuIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Page.IsPostBack)
            {
                PubComm.SetZCB(this.zcbao, "所有政策包");
                PubComm.SetDepart(this.depart, "所有部门");

                /////////////////////////////////////
                this.zcbao.SelectedValue = "";
                this.depart.SelectedValue = "";
                depart_SelectedIndexChanged(this.depart, e);
                this.time1.Attributes["onfocus"] = "setday(this)";
                this.time2.Attributes["onfocus"] = "setday(this)";
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        List<SearchField> list1 = new List<SearchField>();
        ////////////////////////////////////////////////
        //单位名称1
        if (this.danwei.Text.Trim() != "")
        {
            list1.Add(new SearchField("danwei", this.danwei.Text.Trim(), SearchOperator.包含));
        }

        //单据编号
        if (this.billnum.Text.Trim() != "")
        {
            list1.Add(new SearchField("bill", this.billnum.Text.Trim()));
        }

        //政策包3
        if (this.zcbao.SelectedValue != "")
        {
            list1.Add(new SearchField("zcbao", this.zcbao.SelectedValue));
        }
        //责任部门4
        if (this.depart.SelectedValue != "")
        {
            list1.Add(new SearchField("depart", this.depart.SelectedValue));
        }

        //责任人5
        if (this.zeren.SelectedValue != "")
        {
            list1.Add(new SearchField("zeren", this.zeren.SelectedValue));
        }

        //时间1
        if (this.time1.Text.Trim() != "")
        {
            list1.Add(new SearchField("billtime", this.time1.Text.Trim(), SearchOperator.大于等于, SearchFieldType.字符型));
        }

        //时间1
        if (this.time2.Text.Trim() != "")
        {
            list1.Add(new SearchField("billtime", this.time2.Text.Trim(), SearchOperator.小于等于, SearchFieldType.字符型));
        }


        HttpContext.Current.Items["SearchCondition"] = list1;
        HttpContext.Current.Items["SearchKind"] = this.billkind.SelectedValue;
        Server.Transfer("BillSearchResult.aspx", false);
    }


    //选择修改部门
    protected void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depart1 = this.depart.SelectedValue;
        PubComm.SetZeRen(this.zeren, depart1, "所有责任人");
        this.zeren.SelectedValue = "";
    }    
}
