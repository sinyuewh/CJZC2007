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

public partial class ZcMng3_SPListView : System.Web.UI.UserControl
{
     /// <summary>
    /// 设置列表的类型
    /// 分别用1、2、3 表示 我的、部门、公司
    /// </summary>
   public int ListFlag
    {
        set
        {
            ViewState["ListFlag"] = value;
        }
        private get
        {
            if (ViewState["ListFlag"] == null)
            {
                ViewState["ListFlag"] = 1;
            }
            return (int)ViewState["ListFlag"];
        }
    }

   public int MenuIndex
    {
        get
        {
            if (ViewState["MenuIndex"] == null)
            {
                ViewState["MenuIndex"] = 1;
            }
            return (int)ViewState["MenuIndex"];
        }
        set
        {
            ViewState["MenuIndex"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String url1 = Request.RawUrl.ToLower();
            if (url1.IndexOf("zcmng3/fangan1.aspx") < 0 )
            {
                this.GridView1.Columns[this.GridView1.Columns.Count-1].Visible = false;
            }
        }
    }


    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        U_FASPBU bu1 = new U_FASPBU();
        if (this.ListFlag == 1)
        {
            this.GridView1.DataSource = bu1.GetShenPiList1();
        }
        else if (this.ListFlag == 2)
        {
            this.GridView1.DataSource = bu1.GetShenPiList2();
        }
        else if (this.ListFlag == 3)
        {
            this.GridView1.DataSource = bu1.GetShenPiList3();
        }
        else if (this.ListFlag == 4)
        {
            this.GridView1.DataSource = bu1.GetShenPiList4();
        }
        else if (this.ListFlag == 5)
        {
            this.GridView1.DataSource = bu1.GetShenPiList5();
        }
        else if (this.ListFlag == 6)
        {
            this.GridView1.DataSource = bu1.GetShenPiList6();
        }
        else
        {
            ;
        }
        this.GridView1.DataBind();
    }


    /// <summary>
    /// 根据查询条件绑定数据
    /// </summary>
    /// <param name="xmmc"></param>
    /// <param name="num1"></param>
    /// <param name="danwei"></param>
    /// <param name="status"></param>
    /// <param name="time0"></param>
    /// <param name="time1"></param>
    public void BindData(String xmmc,String num1,String danwei,
        String status,String time0,String time1,String status1,String Status2)
    {
        U_FASPBU bu1 = new U_FASPBU();
        this.GridView1.DataSource = bu1.GetShenPiListBySearchCondition(xmmc,
            num1, danwei, status, time0, time1,status1,Status2);
        this.GridView1.DataBind();
    }


    //调整数据的变化
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dv = e.Row.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            String czid = dr["id"].ToString();

            //设置资产（或资产包）的类别
            int col1 = 8;   //表示状态
            String spkind=dr["zcbid"].ToString().Trim();
            if (spkind == String.Empty)
            {
                e.Row.Cells[col1].Text = "资产";
            }
            else
            {
                e.Row.Cells[col1].Text = "资产包";
            }

            ZcspBU spbu1 = new ZcspBU();       //设置资产审批BU类
            int status1 = spbu1.GetShenPiStatus(czid);
            //设置资产处置的审批状态
            Label labsp = e.Row.FindControl("spstatus") as Label;
            if (labsp != null)
            {
                if (status1 == -1)
                {
                    labsp.Text = "<span title='未启动审批'>□</span>";
                }
                if (status1 == 0)
                {
                    labsp.Text = "<span title='审批中'><font color='blue'>○</font></span>";
                }
                if (status1 == 1)
                {
                    labsp.Text = "<span title='审核委员会批'><font color='Red'>☆</font></span>";
                }
                if (status1 == 2)
                {
                    labsp.Text = "<span title='决策委员会批'><font color='Red'>☆☆</font></span>";
                }
            }
            

            //计算会议时间
            Label lab1 = e.Row.FindControl("hysj") as Label;
            if (lab1 != null)
            {
                if (status1 == 1)
                {
                    lab1.Text = dr["hysj1"].ToString();
                }

                if (status1 == 2)
                {
                    lab1.Text = dr["hysj2"].ToString();
                }
            }
            
            //设置资产的执行状态
            Label lab2 = e.Row.FindControl("zxzt") as Label;
            if (lab2 != null)
            {
                if (dr["status1"].ToString().Trim() != String.Empty)
                {
                    lab2.Text = dr["status1"].ToString().Trim() + "-" + dr["status2"].ToString().Trim();
                }
            }

            //设置资产处置链接的地址
            HyperLink link1 = e.Row.FindControl("Link1") as HyperLink;
            if (link1 != null)
            {
                if (dr["id"].ToString().Trim() != String.Empty)
                {
                    link1.NavigateUrl = "EditSbb.aspx?id=" + dr["id"].ToString();
                }


                if (ViewState["MenuIndex"] != null)
                {
                    link1.NavigateUrl += "&menuIndex=" + ViewState["MenuIndex"].ToString();
                }
                link1.Text = dr["xmmc"].ToString();
            }


            //设置资产信息处置链接的地址
            HyperLink link2 = e.Row.FindControl("Link2") as HyperLink;
            if (link1 != null)
            {
                if (dr["zcid"].ToString().Trim() != String.Empty)
                {
                    link2.NavigateUrl = "~/ZcMng2/ZcDetail1.aspx?id=" + dr["zcid"].ToString();
                    link2.ToolTip = "浏览资产的详细情况";
                }

                if (dr["zcbid"].ToString().Trim() != String.Empty)
                {
                    link2.NavigateUrl = "~/ZcMng2/ZcBaoDetail1.aspx?id=" + dr["zcbid"].ToString();
                    link2.ToolTip = "浏览资产包的详细情况";
                }
                link2.Target = "_blank";

                String num = dr["num2"].ToString().Trim();
                if (num == String.Empty) num = "无编号";
                link2.Text = num;
            }


            //设置删除的操作是否可用
            LinkButton button1 = e.Row.FindControl("button1") as LinkButton;
            if (button1 != null)
            {
                bool spFlag = this.GetSpCount(dr["id"].ToString());
                if (spFlag)
                {
                    button1.Visible = false;
                }
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteData")
        {
            String id = e.CommandArgument.ToString();
            this.DeleteSpData(id);
            this.BindData();
        }
    }


    #region Private Function
    /// <summary>
    /// 得到资产处置表的审批情况
    /// </summary>
    /// <param name="spid"></param>
    /// <returns></returns>
    private bool GetSpCount(String spid)
    {
        bool result = false;
        CommTable com1 = new CommTable();
        com1.TabName = "U_ZCSP";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("czid", spid, SearchFieldType.数值型));
        DataSet ds1 = com1.SearchData("id", condition);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            result = true;
        }
        com1.Close();
        return result;
    }


    /// <summary>
    /// 删除资产处置表的数据
    /// </summary>
    /// <param name="spid"></param>
    private void DeleteSpData(String spid)
    {
        CommTable com1 = new CommTable();
        com1.TabName = "U_ZC2";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", spid, SearchFieldType.数值型));
        com1.DeleteData(condition);
        com1.Close();
    }
    #endregion
}
