using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections;

public partial class ZcMng1_FixLawGwEdit : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Button1.Click += new EventHandler(Button1_Click);
        this.Button2.Click += new EventHandler(Button2_Click);
        base.OnInit(e);
    }

    //返回数据处理
    void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("FixLawGwList.aspx", true);
    }

    //提交数据处理
    void Button1_Click(object sender, EventArgs e)
    {
        String sname1 = this.sname.SelectedValue;
        String kind1 = this.kind.SelectedValue;
        string id1 = Request.QueryString["id"];
        CommTable comm1 = new CommTable("U_LawZC");

        Hashtable ht1 = new Hashtable();
        ht1["sname"] = sname1;
        ht1["kind"] = kind1;
        ht1["dotime"] = DateTime.Now.ToString();
        ht1["checkmen"] = Page.User.Identity.Name;
        if (String.IsNullOrEmpty(id1) == false)
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id1, SearchFieldType.数值型));
            comm1.EditQuickData(condition, ht1);
        }
        else
        {
            comm1.InsertData(ht1);
        }
        comm1.Close();
        Response.Redirect("FixLawGwList.aspx", true);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.sname.DataSource = GetZeren();
            this.sname.DataBind();

            this.SetData();
        }
    }

    //得到资产和资产包的所有责任人
    private List<string> GetZeren()
    {
        return LawBU.GetZerenForZcAndZcBao();
    }

    private void SetData()
    {
        CommTable comm1 = new CommTable("U_LawZC");
        string id1 = Request.QueryString["id"];
        if (String.IsNullOrEmpty(id1) == false)
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id1, SearchFieldType.数值型));
            DataSet ds1= comm1.SearchData("*",condition);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                if (this.sname.Items.FindByValue(dr1["sname"].ToString().Trim()) != null)
                {
                    this.sname.SelectedValue = dr1["sname"].ToString().Trim();
                }

                if (this.kind.Items.FindByValue(dr1["kind"].ToString().Trim()) != null)
                {
                    this.kind.SelectedValue = dr1["kind"].ToString().Trim();
                }
            }
        }
        
        comm1.Close();
    }
}
