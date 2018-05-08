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

public partial class JueCeZhiChi_StatByStatus : System.Web.UI.Page
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
            U_ItemBU item1 = new U_ItemBU();;

            item1.ItemName = "行政区域";
            item1.SetLiteralControl(this.quyu, "全部...");

            item1.ItemName = "行业分类";
            item1.SetLiteralControl(this.hangye, "全部...");

            item1.SetStatus(this.jzdc,"尽职调查");

            item1.SetStatus(this.fasp,"方案审批");

            item1.SetStatus(this.fazx,"方案执行");

            item1.Close();

            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            zcb1.SetBstatus(this.Bstatus, "全部...");
            zcb1.Close();
            ////////////////////////////////////////////

            depart_SelectedIndexChanged(this.depart, e);

        }
    }
    protected void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "所有责任人");
        this.zeren.SelectedValue = "";
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
        if (this.Bstatus.SelectedValue != "")
        {
            list1.Add(new SearchField("Bstatus", this.Bstatus.SelectedValue));
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


        string status = "";
        //状态分类1
        string status1 = "";
        bool first1 = true;
        for (int i = 0; i < this.jzdc.Items.Count; i++)
        {
            ListItem list3 = this.jzdc.Items[i];
            if (list3.Selected)
            {
                if (first1)
                {
                    status1 = " charindex('" + list3.Value + "',status) >0 ";
                    first1 = false;
                }
                else
                {
                    status1 = status1 + " or  charindex('" + list3.Value + "',status) >0 ";
                }
            }
        }
        if (status1 != "")
        {
            status = status1;
        }
        //状态分类2
        string status2 = "";
        bool first2 = true;
        for (int j = 0; j < this.fasp.Items.Count; j++)
        {
            ListItem list5 = this.fasp.Items[j];
            if (list5.Selected)
            {
                if (first2)
                {
                    status2 = " charindex('" + list5.Value + "',status) >0 ";
                    first2 = false;
                }
                else
                {
                    status2 = status2 + " or  charindex('" + list5.Value + "',status) >0 ";
                }
            }
        }
        if (status2 != "" && status != "")
        {
            status = status + "or" + status2;
        }
        if (status2 != "" && status == "")
        {
            status = status2;
        }
        //状态分类3
        string status3 = "";
        int last3 = 0;
        bool first3 = true;
        for (int k = 0; k < this.fazx.Items.Count; k++)
        {
            ListItem list6 = this.fazx.Items[k];
            if (list6.Selected)
            {
                last3 = k;
            }
        }
        for (int k = 0; k < this.fazx.Items.Count; k++)
        {
            ListItem list7 = this.fazx.Items[k];
            if (list7.Selected)
            {
                if (first3)
                {
                    status3 = " charindex('" + list7.Value + "',status) >0 ";
                    first3 = false;
                }
                if (first3 == false && k < last3)
                {
                    status3 = status3 + " or  charindex('" + list7.Value + "',status) >0 ";
                }
                if (first3 == false && k == last3)
                {
                    status3 = status3 + " or  charindex('" + list7.Value + "',status) >0 ";
                }
                if (first3 == true && k == last3)
                {
                    status3 = " charindex('" + list7.Value + "',status) >0 ";
                }
            }
        }
        if (status3 != "" && status != "")
        {
            status = status + "or" + status3;
        }
        if(status3 != "" && status =="")
        {
            status = status3;
        }
        if (status != "")
        {
            list1.Add(new SearchField("", status, SearchOperator.用户定义));
        }
        HttpContext.Current.Items["SearchCondition"] = list1;
        HttpContext.Current.Items["SearchKind"] = "按状态统计";
        Server.Transfer("StatByStatusResult.aspx", false);
    }
}
