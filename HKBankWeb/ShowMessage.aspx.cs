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
using System.Collections.Generic;
using JSJ.SysFrame;

public partial class ShowMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
        }
    }

    private void BindData()
    {
        CommTable comm1 = new CommTable("ZX_QuickTalk");
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("tmen", User.Identity.Name));
        list1.Add(new SearchField("isRead", "0"));
        DataSet ds1 = comm1.SearchData("*", list1,"id desc");

        //修改信息为已读
        Hashtable ht = new Hashtable();
        ht["isread"] = "1";
        comm1.EditQuickData(list1, ht);
        comm1.Close();
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
    }


    //删除数据
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        HiddenField hid1 = e.Item.FindControl("HiddenField1") as HiddenField;
        if (hid1 != null)
        {
            string id = hid1.Value;
            CommTable comm1 = new CommTable("ZX_QuickTalk");
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            comm1.DeleteData(list1);
            comm1.Close();

        }
    }
}
