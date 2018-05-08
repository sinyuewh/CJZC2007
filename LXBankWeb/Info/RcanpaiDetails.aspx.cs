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
public partial class Info_RcanpaiDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.plantime.Text = Request.QueryString["time0"];
            if (String.IsNullOrEmpty(Request.QueryString["time0"]) == false)
            {
                this.SetPageInfo(DateTime.Parse(Request.QueryString["time0"]));
            }
        }
        this.plantime.Attributes["onfocus"] = "javaScript:setday(this);";
    }


    private void SetPageInfo(DateTime time0)
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_RCAP";
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("sname", User.Identity.Name));
        list1.Add(new SearchField("year(plantime)", time0.Year+"", SearchFieldType.数值型));
        list1.Add(new SearchField("month(plantime)", time0.Month + "", SearchFieldType.数值型));
        list1.Add(new SearchField("day(plantime)", time0.Day + "", SearchFieldType.数值型));
        Hashtable ht=comm1.SearchData(list1);
        if (ht != null && ht.Count > 0)
        {
            this.subject.Text = ht["subject"].ToString();
            this.remark.Text = ht["remark"].ToString();
            this.id.Value = ht["id"].ToString();
        }
        else
        {
            this.Button2.Visible = false;
        }
        comm1.Close();
    }


    //将数据保存
    protected void btn1_Click(object sender, EventArgs e)
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_RCAP";

        //保存老的数据
        if (this.id.Value=="")
        {
            Hashtable ht = new Hashtable();
            ht["time0"] = DateTime.Now.ToString();
            ht["sname"] = User.Identity.Name;
            U_UserNameBU user1 = new U_UserNameBU();
            ht["depart"] = user1.GetDepart1(User.Identity.Name);
            user1.Close();

            ht["plantime"] = this.plantime.Text;
            ht["subject"] = Util.GetMaxLenth(this.subject.Text,90);
            ht["remark"] = this.remark.Text;
            comm1.InsertData(ht);
        }
        else
        {
            string infoid = this.id.Value;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", infoid, SearchFieldType.数值型));
            list1.Add(new SearchField("sname", User.Identity.Name));

            Hashtable ht = new Hashtable();
            ht["plantime"] = this.plantime.Text;
            ht["subject"] = Util.GetMaxLenth(this.subject.Text, 90);
            ht["remark"] = this.remark.Text;
            comm1.EditQuickData(list1, ht);
        }
        comm1.Close();
        Response.Redirect("MyRcaiPai.aspx", true);
    }

    //关闭返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyRcaiPai.aspx", true);
    }


    //删除一个已存在的日程安排
    protected void Button2_Click(object sender, EventArgs e)
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "ZX_RCAP";
        string infoid = this.id.Value;
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("id", infoid, SearchFieldType.数值型));
        list1.Add(new SearchField("sname", User.Identity.Name));
        comm1.DeleteData(list1);
        comm1.Close();
        Response.Redirect("MyRcaiPai.aspx", true);
    }
}
