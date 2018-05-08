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

using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;

public partial class DangAn_AnJuanWeiHu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.BindData(null);
            U_ItemBU item1 = new U_ItemBU();
            item1.ItemName = "案卷类别";
            item1.SetLiteralControl(this.DropDownList1, "全部...");
            this.DropDownList1.SelectedValue = "";
            this.time1.Attributes["onfocus"] = "setday(this)";
            this.time2.Attributes["onfocus"] = "setday(this)";
        }
    }


    //建立案卷维护页面——查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<SearchField> list1 = new List<SearchField>();
        if (this.fileno.Text != "" || this.title.Text != "")
        {
            //案卷分类
            if (this.DropDownList1.SelectedValue != "")
            {
                list1.Add(new SearchField("ajkind", this.DropDownList1.SelectedValue));
            }
            //案卷名称
            if (this.ajname.Text != "")
            {
                list1.Add(new SearchField("ajname", this.ajname.Text, SearchOperator.包含));
            }
            //案卷编号
            if (this.ajnum.Text != "")
            {
                list1.Add(new SearchField("ajnum", this.ajnum.Text, SearchOperator.包含));
            }
            //立卷时间1
            if (this.time1.Text != "")
            {
                list1.Add(new SearchField("time0", this.time1.Text, SearchOperator.大于等于));
            }
            //立卷时间2
            if (this.time2.Text != "")
            {
                list1.Add(new SearchField("time0", this.time2.Text, SearchOperator.小于等于));
            }
            //状态

            //if (this.ajstatus.SelectedValue != "")
            //{
                if (this.ajstatus.SelectedValue =="2")
                {
                    list1.Add(new SearchField("ajstatus", this.ajstatus.SelectedValue, SearchOperator.等于));
                }
                if (this.ajstatus.SelectedValue == "")
                {
                    list1.Add(new SearchField("ajstatus", "", SearchOperator.等于));
                }
            //}
            //文号
            if (this.fileno.Text != "")
            {
                list1.Add(new SearchField("fileno", this.fileno.Text));
            }
            //文件名称
            if (this.title.Text != "")
            {
                list1.Add(new SearchField("title", this.title.Text, SearchOperator.包含));
            }

            HttpContext.Current.Items["SearchCondition2"] = list1;
            HttpContext.Current.Items["SearchKind"] = "案卷检索";
            Server.Transfer("~/DangAn/AnJuanWeiHuList.aspx", false);
        }
        else
        {
            //案卷分类
            if (this.DropDownList1.SelectedValue != "")
            {
                list1.Add(new SearchField("ajkind", this.DropDownList1.SelectedValue));
            }
            //案卷名称
            if (this.ajname.Text != "")
            {
                list1.Add(new SearchField("ajname", this.ajname.Text, SearchOperator.包含));
            }
            //案卷编号
            if (this.ajnum.Text != "")
            {
                list1.Add(new SearchField("ajnum", this.ajnum.Text, SearchOperator.包含));
            }
            //立卷时间1
            if (this.time1.Text != "")
            {
                list1.Add(new SearchField("time0", this.time1.Text, SearchOperator.大于等于));
            }
            //立卷时间2
            if (this.time2.Text != "")
            {
                list1.Add(new SearchField("time0", this.time2.Text, SearchOperator.小于等于));
            }
            //状态

            if (this.ajstatus.SelectedValue == "2")//已移交

            {
                list1.Add(new SearchField("ajstatus", this.ajstatus.SelectedValue, SearchOperator.等于));
            }
            else if (this.ajstatus.SelectedValue == "1")//未移交

            {
                list1.Add(new SearchField("ajstatus", this.ajstatus.SelectedValue, SearchOperator.等于));
            }
            HttpContext.Current.Items["SearchCondition1"] = list1;
            HttpContext.Current.Items["SearchKind"] = "案卷检索";
            Server.Transfer("~/DangAn/AnJuanWeiHuList.aspx", false);
        }
    }
}
