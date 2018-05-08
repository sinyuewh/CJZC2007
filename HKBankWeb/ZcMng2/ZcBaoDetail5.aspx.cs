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
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;

public partial class ZcMng2_ZcBaoDetail5 : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Repeater3.ItemCommand += new RepeaterCommandEventHandler(Repeater3_ItemCommand);
        this.Repeater3.ItemDataBound += new RepeaterItemEventHandler(Repeater3_ItemDataBound);
        base.OnInit(e);
    }

    void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton link1 = e.Item.FindControl("link1") as LinkButton;
        if (link1 != null)
        {
            link1.Visible = this.IsZeren;
        }
    }

    //删除相关的数据
    void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String id1 = e.CommandArgument.ToString();
        this.DeleteHuiKuan(id1);
        Response.Redirect("ZcBaoDetail5.aspx?id=" + Request["id"], true);
    }

    
    //设置资产的责任人与否
    public bool IsZeren
    {
        get
        {
            if (ViewState["IsZeren"] == null)
            {
                return false;
            }
            else
            {
                return (bool)ViewState["IsZeren"];
            }
        }
        set
        {
            ViewState["IsZeren"] = value;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
            this.BindList();
            this.BindHuiKuan();

            ////////////////////////
            this.IsZeren = GetZcZeren(Request["id"]);
            this.link2.Visible = this.IsZeren;
        }
    }


    private void BindData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            DataSet ds = zcb1.GetDetailByID(id, "id,depart,bzeren,bstatus,statusText,bname,bljsk,bljzc");

            this.Bname.Text = ds.Tables[0].Rows[0]["bname"].ToString();
            this.Bid.Text = ds.Tables[0].Rows[0]["id"].ToString();
            this.depart.Text = ds.Tables[0].Rows[0]["depart"].ToString();
            this.bzeren.Text = ds.Tables[0].Rows[0]["bzeren"].ToString();
            this.status.Text = ds.Tables[0].Rows[0]["bstatus"].ToString();
            this.statusText.Text = ds.Tables[0].Rows[0]["statusText"].ToString();
            this.ljsk.Text = ds.Tables[0].Rows[0]["bljsk"].ToString();
            this.ljzc.Text = ds.Tables[0].Rows[0]["bljzc"].ToString();

            if (this.statusText.Text == "")
            {
                this.statusText.Text = "阅卷";
            }
            ds.Dispose();

            Hashtable ht = zcb1.GetZcBbjANDlx(this.Bid.Text);
            this.bbjhj.Text = ht["bbjhj"].ToString();
            this.blxhj.Text = ht["blxhj"].ToString();
            zcb1.Close();
            //设置数字金额的显示
            string[] num1 = new string[] { "bbjhj", "blxhj", "ljzc", "ljsk"};
            for (int i = 0; i < num1.Length; i++)
            {
                Label l1 = this.bbjhj.Parent.FindControl(num1[i]) as Label;
                if (l1 != null)
                {
                    l1.Text = PubComm.GetNumberFormat(l1.Text);
                }
            }

            ds.Dispose();
        }
    }


    private void BindList()
    {
        CW_ShouKuan1BU shoukuan1 = new CW_ShouKuan1BU();
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("bid", Request.QueryString["id"], SearchFieldType.数值型));
        this.Repeater1.DataSource = shoukuan1.GetBillList("0", list1, true);
        this.Repeater1.DataBind();

        //针对资产包内单户资产的收款情况
        DataTable dt1 = this.GetShouKuanListForZc(Request.QueryString["id"]);
        this.Repeater11.DataSource = dt1;
        this.Repeater11.DataBind();

        ////////////////////////////////////////////////////////////
        list1.Clear();
        list1.Add(new SearchField("bid", Request.QueryString["id"], SearchFieldType.数值型));
        this.Repeater2.DataSource = shoukuan1.GetBillList("1", list1, true);
        this.Repeater2.DataBind();

        shoukuan1.Close();

        //针对资产包内单户资产的支出情况
        DataTable dt2 = this.GetZhiChuListForZc(Request.QueryString["id"]);
        this.Repeater21.DataSource = dt2;
        this.Repeater21.DataBind();
    }


    //得到资产包内资产的收款情况
    private DataTable GetShouKuanListForZc(String Bid)
    {
        DataTable dt1 = null;
        CommTable com1 = new CommTable();
        String sql = "select *,pbj+plx bxhj from CW_ShouKuan where zcid in"
            +" (select zcid from u_zcbaoinfo where bid=" + Bid + ")";
        dt1=com1.TableComm.SearchData(sql).Tables[0];
        return dt1;
    }

    //得到资产包内资产的支出情况
    private DataTable GetZhiChuListForZc(String Bid)
    {
        DataTable dt1 = null;
        CommTable com1 = new CommTable();
        String sql = "select *,ISNULL(fee1, 0) + ISNULL(fee2, 0) + ISNULL(fee3, 0) +isnull(fee4,0)+isnull(fee5,0) ";
               sql=sql+"+ISNULL(fee6, 0) + ISNULL(fee7, 0) + ISNULL(fee8, 0) +isnull(fee4,9)+isnull(fee5,10) ";
               sql=sql+"+ISNULL(fee11, 0) + ISNULL(fee12, 0) + ISNULL(fee13, 0) +isnull(fee14,0)+isnull(fee15,0)";
               sql=sql+"+ISNULL(fee16, 0) + ISNULL(fee17, 0) + ISNULL(fee18, 0) +isnull(fee4,19)+isnull(fee5,20) as zchj";
               sql = sql + " from CW_Pay where zcid in";
               sql=sql + " (select zcid from u_zcbaoinfo where bid=" + Bid + ")";
        dt1 = com1.TableComm.SearchData(sql).Tables[0];
        return dt1;
    }


    ////////////////////////////////////////////////////////////////////////////////////
    //绑定回款计划数据
    private void BindHuiKuan()
    {
        if (Request["id"] != null)
        {
            CommTable com1 = new CommTable();
            com1.TabName = "CW_ShouKuanPlan";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zcid", Request["id"], SearchFieldType.数值型));
            condition.Add(new SearchField("kind", "1"));
            DataSet ds1 = com1.SearchData("*", condition);
            this.Repeater3.DataSource = ds1;
            this.Repeater3.DataBind();
            com1.Close();
        }
    }

    //删除回款计划数据
    private void DeleteHuiKuan(String id)
    {
        CommTable com1 = new CommTable();
        com1.TabName = "CW_ShouKuanPlan";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", id, SearchFieldType.数值型));
        com1.DeleteData(condition);
        com1.Close();
    }

    //得到资产的责任人
    private bool GetZcZeren(String aid)
    {
        bool result = false;
        CommTable com1 = new CommTable();
        com1.TabName = "U_ZCBAO";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", Request["id"], SearchFieldType.数值型));
        DataSet ds1 = com1.SearchData("BZeren", condition);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds1.Tables[0].Rows[0];
            String temp1 = dr["BZeren"].ToString().Trim();
            if (temp1 == User.Identity.Name)
            {
                result = true;
            }
        }
        com1.Close();
        return result;
    }
}
