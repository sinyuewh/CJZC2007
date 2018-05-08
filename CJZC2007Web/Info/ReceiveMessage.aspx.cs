using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;

public partial class Info_ReceiveMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        int totalRow = 0;
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_QuickTalk";
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("tmen", User.Identity.Name));
        DataSet ds1 = comm1.SearchData("*", list1, "id desc",1,-1, out totalRow);

        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();

        //隐藏删除等控件
        if (totalRow > 0)
        {
            this.info2.Visible = true;
        }
        else
        {
            this.info2.Visible = false;
        }

        //将所有的短消息设置为已读
        list1.Add(new SearchField("isRead", "0"));
        Hashtable ht=new Hashtable();
        ht["isRead"]="1";
        comm1.EditQuickData(list1, ht);
        comm1.Close();
     }

    //删除所中的数据
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.Form["Seldoc"]) == false)
        {
            CommTable comm1 = new CommTable();
            comm1.TabName = "ZX_QuickTalk";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("tmen", User.Identity.Name));
            list1.Add(new SearchField("id", Request.Form["Seldoc"], SearchOperator.集合, SearchFieldType.数值型));
            comm1.DeleteData(list1);
            comm1.Close();
            this.BindData();
        }
    }
}
