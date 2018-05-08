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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.IO;
using System.Collections.Generic;

public partial class OnLineUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            //this.GetNewMessage();
            //this.GetNewEmail();
        }
    }

    //绑定有人员的部门数据
    private void BindData()
    {
        U_DepartBU depart1 = new U_DepartBU();
        DataSet ds1 = depart1.GetAllDepart1();
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
        depart1.Close();

    }
    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lab1 = e.Item.FindControl("labDepart") as Label;
        if (lab1 != null)
        {
            U_UserNameBU user1 = new U_UserNameBU();
            string[] arr1 = user1.GetAllPerson(lab1.Text);
            DataList datalist1 = e.Item.FindControl("DataListForPerson") as DataList;
            if (datalist1 != null)
            {
                datalist1.ItemDataBound += new DataListItemEventHandler(datalist1_ItemDataBound);
                datalist1.DataSource = arr1;
                datalist1.DataBind();
            }
            datalist1.Dispose();
        }
    }

    void datalist1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Hashtable ht = (Hashtable)Application["OnLineUser"];
        string user1 = e.Item.DataItem.ToString();
        Image image1 = e.Item.FindControl("Image1") as Image;
        Label lab1 = e.Item.FindControl("Label1") as Label;

        if (image1 != null)
        {
            if (ht.Contains(user1))
            {
                image1.ImageUrl = "~/Common/Image/image2008/1.gif";
                image1.ToolTip = "在线";
                lab1.Enabled = true;
               // e.Item.FindControl("info1").Visible = true;
            }
            else
            {
                image1.ImageUrl = "~/Common/Image/image2008/2.gif";
                lab1.Enabled = false;
                image1.ToolTip = "离线";
               // e.Item.FindControl("info1").Visible = false;
            }
        }
    }


    protected void DataList_OnDataBinding(object sender, DataListItemEventArgs e)
    {
        
    }


    //得到最新消息的数量
    private void GetNewMessage()
    {
        int newMessage = 0;
        CommTable comm1 = new CommTable("ZX_QuickTalk");
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("tmen", User.Identity.Name));
        list1.Add(new SearchField("isRead", "0"));
        DataSet ds1 = comm1.SearchData("count(*) as count1", list1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            newMessage = Int32.Parse(ds1.Tables[0].Rows[0][0].ToString());
        }
        comm1.Close();
        this.NewMessageCount.Text = newMessage + "";
    }


    //得到最新的邮件ID信息
    private void GetNewEmail()
    {
        ZX_EmailBu email1 = new ZX_EmailBu();
        int mailid = email1.GetNewMailID();
        if (mailid != 0)
        {
            this.NewEmailID.Value = mailid + "";
        }
        else
        {
            this.NewEmailID.Value = "";
        }
        email1.Close();
    }

    
}
