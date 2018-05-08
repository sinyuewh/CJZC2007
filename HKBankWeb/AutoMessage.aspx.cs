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
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class AutoMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetNewMessage();
            Page.DataBind();
        }
    }


    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }


    private void GetNewMessage()
    {
        int newMessage = 0;
        CommTable comm1 = new CommTable("ZX_QuickTalk");
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("tmen", User.Identity.Name));
        list1.Add(new SearchField("isRead","0"));
        DataSet ds1 = comm1.SearchData("count(*) as count1", list1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            newMessage =Int32.Parse(ds1.Tables[0].Rows[0][0].ToString());
        }
        comm1.Close();
        this.TextBox1.Text = newMessage + "";
    }
}
