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
            Comm.SetZCB(this.zcbao, "所有政策包");
            Comm.SetDepart(this.depart, "所有部门");
           
            /////////////////////////////////////
            this.zcbao.SelectedValue = "";
            this.depart.SelectedValue = "";
            depart_SelectedIndexChanged(this.depart, e);
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
        //合同编号2
        if (this.num2.Text.Trim() != "")
        {
            string num2 = this.num2.Text.Trim();
            string num2Search = "";
            string[] str = num2.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    num2Search = "charindex('" + str[i].Trim() + "',num2) > 0";
                }
                else
                {
                    num2Search = num2Search + " or charindex('" + str[i].Trim() + "',num2) > 0";
                }
            }
            if (num2Search != "")
            {
                list1.Add(new SearchField("", num2Search, SearchOperator.用户定义));
            }
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
        
        HttpContext.Current.Items["SearchCondition"] = list1;
        HttpContext.Current.Items["SearchKind"] = "财务查询结果";
        Server.Transfer("ZcSearchResult.aspx", false);
    }

    //选择修改部门
    protected void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren,depart1,"所有责任人");
        this.zeren.SelectedValue = "";
    }
}
