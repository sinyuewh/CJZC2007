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


public partial class CaiWu_ZcBaoBillSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.time1.Attributes["onfocus"] = "setday(this)";
            this.time2.Attributes["onfocus"] = "setday(this)";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<SearchField> list1 = new List<SearchField>();
        ////////////////////////////////////////////////
        //资产包名称
        if (this.bname.Text.Trim() != "")
        {
            list1.Add(new SearchField("bname", this.bname.Text.Trim(), SearchOperator.包含));
        }

        //单据编号
        if (this.billnum.Text.Trim() != "")
        {
            list1.Add(new SearchField("bill", this.billnum.Text.Trim()));
        }

        //责任人5
        if (this.bzeren.Text != "")
        {
            list1.Add(new SearchField("bzeren", this.bzeren.Text.Trim(), SearchOperator.包含));
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
        Server.Transfer("ZcBaoBillSearchResult.aspx", false);
    }
}
