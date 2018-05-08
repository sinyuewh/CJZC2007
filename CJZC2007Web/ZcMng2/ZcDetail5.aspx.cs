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

public partial class ZiChan_ZcDetail5 : System.Web.UI.Page
{
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
        Response.Redirect("ZcDetail5.aspx?id=" + Request["id"], true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            this.BindList();
            this.BindHuiKuan();

            this.IsZeren = GetZcZeren(Request["id"]);
            this.link2.Visible = this.IsZeren;
        }
    }

    private void BindData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            U_ZCBU zc1 = new U_ZCBU();
            string fs = "danwei,depart,zeren,bj,lx,pbj,plx,fee1,fee2,fee3,fee4,fee5,fee6,fee7,fee8,fee9,fee10,fee11,fee12,bjye,lxye,hbxh,bxhjye,fyhj";
            DataSet ds = zc1.GetDetailByID(id, "danwei,depart,zeren,bj,pbj,plx,fee1,fee2,fee3,fee4,fee5,fee6,fee7,fee8,fee9,fee10,fee11,fee12,isnull(bj,0)-isnull(pbj,0) as bjye ,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0)-plx as lxye,isnull(pbj,0)+isnull(plx,0) as hbxh,isnull(bj,0)+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0)-isnull(pbj,0)-isnull(plx,0) as bxhjye,isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0)+isnull(fee13,0)+isnull(fee14,0)+isnull(fee15,0)+isnull(fee16,0)+isnull(fee17,0)+isnull(fee18,0)+isnull(fee19,0)+isnull(fee20,0) as fyhj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) as lx");
            zc1.Close();
            string[] AF = fs.Split(',');
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < AF.Length; i++)
                {
                    Util.SetControlValue(this.pbj.Parent.FindControl(AF[i]),ds.Tables[0].Rows[0][AF[i]]);
                }
            }
            //设置数字金额的显示
            string[] num1 = new string[] { "pbj","plx","fee1","fee2","fee3","fee4","fee5","fee6","fee7","fee8","fee9","fee10","fee11","fee12","bjye","lxye","hbxh","bxhjye","fyhj" };
            for (int i = 0; i < num1.Length; i++)
            {
                Label l1 = this.pbj.Parent.FindControl(num1[i]) as Label;
                if (l1 != null)
                {
                    l1.Text = Comm.GetNumberFormat(l1.Text);
                }
            }

            ds.Dispose();
            if (Comm.IsRole("系统管理员"))
            {
                this.Button2.Visible = true;
            }
            else
            {
                this.Button2.Visible = false;
            }
        }
    }

    private void BindList()
    {
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        List<SearchField> list1=new List<SearchField>();
        list1.Add(new SearchField("zcid",Request.QueryString["id"],SearchFieldType.数值型));
        this.Repeater1.DataSource = shoukuan1.GetBillList("0", list1, true);
        this.Repeater1.DataBind();

        ////////////////////////////////////////////////////////////
        list1.Clear();
        list1.Add(new SearchField("zcid", Request.QueryString["id"], SearchFieldType.数值型));
        this.Repeater2.DataSource = shoukuan1.GetBillList("1", list1, true);
        this.Repeater2.DataBind();

        shoukuan1.Close();
    }

    //绑定回款计划数据
    private void BindHuiKuan()
    {
        if (Request["id"] != null)
        {
            CommTable com1 = new CommTable();
            com1.TabName = "CW_ShouKuanPlan";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zcid", Request["id"], SearchFieldType.数值型));
            condition.Add(new SearchField("kind", "0"));
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
        com1.TabName = "U_ZC";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id",Request["id"], SearchFieldType.数值型));
        DataSet ds1 = com1.SearchData("Zeren", condition);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds1.Tables[0].Rows[0];
            String temp1 = dr["Zeren"].ToString().Trim();
            if (temp1 == User.Identity.Name)
            {
                result = true;
            }
        }
        com1.Close();
        return result;
    }
}
