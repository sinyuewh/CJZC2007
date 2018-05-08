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

public enum SearchDataType { 单条资产, 资产包 };

public partial class ZcMng1_SearchControl : System.Web.UI.UserControl
{
    public event EventHandler SearchEvent;

    public bool AllZC
    {
        get
        {
            if (this.SearchKind.SelectedValue == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    //设置法律顾问的查询选项
    private bool isRwaSearch = false;
    public bool IsRawSearch
    {
        get { return this.isRwaSearch; }
        set { this.isRwaSearch = value; }
    }


    //设置个人搜索选项
    private bool isPersonSearch = false;
    public bool IsPersonSearch
    {
        get { return this.isPersonSearch; }
        set { this.isPersonSearch=value; }
    }

    //设置部门搜索选项
    private bool isDepartSearch = false;
    public bool IsDepartSearch
    {
        get { return this.isDepartSearch;}
        set { this.isDepartSearch = value; }
    }

    public List<SearchField> SearchConditionList
    {
        get
        {
            return ViewState["SearchConditionList"] as List<SearchField>;
        }
    }

    //设置查询数据的类型
    public SearchDataType SearchType
    {
        set { ViewState["SearchType"] = value; }
        get
        {
            if (ViewState["SearchType"] == null)
            {
                return SearchDataType.单条资产;
            }
            else
            {
                return (SearchDataType)ViewState["SearchType"];
            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetMyData();
            if (this.SearchType == SearchDataType.单条资产)
            {
                this.SearchCaption.Text = "查 询 单 条 资 产";
                this.ZcbRow0.Visible = false;
            }
            else
            {
                this.SearchCaption.Text = "查 询 资 产 包";
                this.ZcRow0.Visible = false;
                this.ZcRow1.Visible = false;
                this.ZcRow2.Visible = false;
                this.ZcRow3.Visible = false;
                this.ZcRow4.Visible = false;
                this.num2.Enabled = false;
                this.Button1.Text = "查询资产包";
            }


            //增加法律顾问的查询选项
            if (this.IsRawSearch == false)
            {
                this.noRawData.Visible = true;
                this.RawData.Visible = false;
                //this.ZcRow4.Visible = true;
            }
            else
            {
                this.noRawData.Visible = false;
                this.RawData.Visible = true;
                this.ZcRow4.Visible = false;
            }

            //设置法律顾问资产责任人查询选项目
            this.zerenlaw.DataSource = LawBU.GetZerenForScan(0);
            this.zerenlaw.DataBind();

            //设置个人查询的选项目
            if (this.isPersonSearch)
            {
                this.noRawData.Visible = false;
            }

            //设置部门资产查询选项(2013年9月16日）
            if (this.isDepartSearch == false)
            {
                this.DepartRowData.Visible = false;
            }
            else
            {
                this.DepartRowData.Visible = true;
                this.noRawData.Visible = false;

                //设置部门责任人
                U_UserNameBU user1 = new U_UserNameBU();
                String myuser1=user1.GetSelfAndXiaShu(Page.User.Identity.Name);
                this.alldepartuser.Text = myuser1;
                String[] arr1 = myuser1.Split(',');
                this.zerenForDepart.DataSource = arr1;
                this.zerenForDepart.DataBind();

                //WebFrame.Util.JControl.SetControlValue(this.zerenForDepart, myuser1);

            }
        }
    }


    protected override void OnInit(EventArgs e)
    {
        this.time1.Attributes["onfocus"] = "setday(this)";
        this.time2.Attributes["onfocus"] = "setday(this)";
        base.OnInit(e);
    }

    //选择修改部门
    protected void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "所有责任人");
        this.zeren.SelectedValue = "";
    }


    /*
    protected void spresult_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.status1.Items.Clear();
        Comm.SetProfile(this.spresult.SelectedValue, this.status1, "全部...");

        this.status2.Items.Clear();
        this.status2.Items.Add(new ListItem("全部...", ""));
    }*/


    protected void status1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.status2.Items.Clear();
        Comm.SetProfile(this.status1.SelectedValue, this.status2, "全部...");
    }


    /// <summary>
    /// 初始化代码
    /// </summary>
    private void SetMyData()
    {
        Comm.SetDepart(this.depart, "所有部门");        
        this.depart.SelectedValue = "";
        this.zcbao.SelectedValue = "";

        ///////////////////////////////////////
        U_ItemBU item1 = new U_ItemBU();
        item1.ItemName = "政策包";
        item1.SetLiteralControl(this.zcbao, "全部...");
        this.zcbao.SelectedValue = "";
        
        //调整行政区域
        item1.ItemName = "行政区域";
        item1.SetLiteralControl(this.quyu, "全部...");
        this.quyu.Items.Add(new ListItem("未分类", "null"));

        //调整行业分类
        item1.ItemName = "行业分类";
        item1.SetLiteralControl(this.hangye, "全部...");
        this.hangye.Items.Add(new ListItem("未分类", "null"));

        //调整管辖的处置
        item1.ItemName = "管辖";
        item1.SetLiteralControl(this.guangxia,"全部...");
        this.guangxia.Items.Add(new ListItem("未分类", "null"));

        //调整执行状态的选择
        Comm.SetProfile("方案执行结果", this.spresult, "");
        Comm.SetProfile("方案执行状态大类", this.status1, "全部...");

        //this.status1.Items.Add(new ListItem("全部...", ""));
        this.status2.Items.Add(new ListItem("全部...", ""));


       // Comm.SetProfile("方案执行状态大类", this.status1, "全部...");
       // Comm.SetProfile(this.status1.SelectedValue, this.status2, "全部...");

        item1.Close();

        ////////////////////////////////////////////

        U_ItemBU item = new U_ItemBU();
        item.Setuserkind(this.userkind);
        item.Close();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        this.GetSearchCondition();
        if (SearchEvent != null)
        {
            SearchEvent(this, new EventArgs());
        }
    }

    public List<SearchField> GetSearchCondition()
    {
        #region 构建查询条件
        List<SearchField> condition = new List<SearchField>();
        ////////////////////////////////////////////////
        //1－单位名称
        if (this.danwei.Text.Trim() != "")
        {
            condition.Add(new SearchField("u_zc.danwei", this.danwei.Text.Trim(), SearchOperator.包含));
        }

        //2－档案编号
        if (this.num2.Text.Trim() != "")
        {
            condition.Add(new SearchField("num2", this.num2.Text.Trim()));
        }


        //资产包名称
        if (this.bname.Text.Trim() != "")
        {
            condition.Add(new SearchField("bname", this.bname.Text.Trim()));
        }

        //资产包接收方
        if (this.bjsf.Text.Trim() != "")
        {
            condition.Add(new SearchField("bjsf", this.bjsf.Text.Trim()));
        }

        #region 设置责任人
        //if (this.depart.SelectedValue != String.Empty || this.zeren.SelectedValue != String.Empty)
        //{
        //    //4－责任人
        //    if (this.zeren.SelectedValue != "")
        //    {
        //        condition.Add(new SearchField("zeren", this.zeren.SelectedValue));
        //    }
        //    else
        //    {
        //        //3－责任部门
        //        if (this.depart.SelectedValue != "")
        //        {
        //            condition.Add(new SearchField("depart", this.depart.SelectedValue));
        //        }
        //    }
        //}

        if (this.isRwaSearch == false)   //非法律顾问的浏览选项
        {
            if (this.isDepartSearch == false)
            {
                if (this.depart.SelectedValue != String.Empty || this.zeren.SelectedValue != String.Empty)
                {
                    //4－责任人
                    if (this.zeren.SelectedValue != "")
                    {
                        condition.Add(new SearchField("zeren", this.zeren.SelectedValue));
                    }
                    else
                    {
                        //3－责任部门
                        if (this.depart.SelectedValue != "")
                        {
                            condition.Add(new SearchField("depart", this.depart.SelectedValue));
                        }
                    }
                }
            }
            else
            {
                //部门资产浏览选项
                String str1 = WebFrame.Util.JControl.GetControlValue(this.zerenForDepart).ToString();
                if (str1 == String.Empty)
                {
                    str1 = this.alldepartuser.Text;     //表示所有的人员
                }

                condition.Add(new SearchField("zeren", str1, SearchOperator.集合));
            }
        }
        else   //法律顾问的浏览选项
        {
            String temp = string.Empty;
            bool first = true;
            //表示没有选中一个用户选项目
            if (this.zerenlaw.SelectedIndex == -1)
            {
                foreach (ListItem item1 in this.zerenlaw.Items)
                {
                    if (first)
                    {
                        temp = item1.Value;
                        first = false;
                    }
                    else
                    {
                        temp = temp + "," + item1.Value;
                    }
                }
            }
            else
            {
                foreach (ListItem item1 in this.zerenlaw.Items)
                {
                    if (item1.Selected)
                    {
                        if (first)
                        {
                            temp = item1.Value;
                            first = false;
                        }
                        else
                        {
                            temp = temp + "," + item1.Value;
                        }
                    }
                }
            }

            if (temp == String.Empty)
            {
                temp = "无";
            }

            condition.Add(new SearchField("zeren", temp, SearchOperator.集合));
        }
        #endregion

        #region Code1
        String sql1 = "( 1=1 ";
        String sql0 = sql1;
        String ViewName = "U_ZC2SearchView2";
        if (SearchType != SearchDataType.单条资产)
        {
            ViewName = "U_ZC2BaoSearchView2";
        }

        //5－审批状态
        String sp1 = JSJ.SysFrame.Util.getListControlValue(this.spstatus);
        if (String.IsNullOrEmpty(sp1) == false)
        {
            sql1 = sql1 + " and TB.spstatus in(" + sp1 + ")";
        }

        //6－执行结果（处理没有审批表的情况）
        sp1 = JSJ.SysFrame.Util.getListControlValue(this.spresult);
        if (String.IsNullOrEmpty(sp1) == false)
        {
            sp1 = sp1.Replace(",", "','");
            sql1 = sql1 + " and ( TB.spresult in('" + sp1 + "')";

            //处理其他的选项
            if (sp1.IndexOf("其他") >= 0)
            {
                sql1 = sql1 + " or ( TB.spresult is null or TB.spresult='' )";
            }
            sql1 = sql1 + " ) ";
        }


        //7－执行状态1
        if (String.IsNullOrEmpty(this.status1.SelectedValue) == false)
        {
            sql1 = sql1 + " and TB.status1='" + this.status1.SelectedValue + "'";
        }

        //8－执行状态2
        if (String.IsNullOrEmpty(this.status2.SelectedValue) == false)
        {
            sql1 = sql1 + " and TB.status2='" + this.status2.SelectedValue + "'";
        }

        //9－执行时间1
        if (String.IsNullOrEmpty(this.time1.Text.Trim()) == false)
        {
            sql1 = sql1 + " and TB.spdotime>='" + this.time1.Text.Trim() + "'";
        }

        //执行时间2
        if (String.IsNullOrEmpty(this.time2.Text.Trim()) == false)
        {
            String t2 = DateTime.Parse(this.time2.Text.Trim()).ToString("yyyy-MM-dd") + " 23:59:59";
            sql1 = sql1 + " and TB.spdotime<='" + t2 + "'";
        }
        sql1 = sql1 + " ) ";
        sql0 = sql0 + " ) ";
        sql1 = sql1.Replace("TB.", ViewName + ".");



        if (sql1 != sql0)
        {
            condition.Add(new SearchField(sql1, "", SearchOperator.用户定义));
        }
        #endregion

        //9－政策包类别
        if (this.zcbao.SelectedValue != "")
        {
            condition.Add(new SearchField("zcbao", this.zcbao.SelectedValue));
        }

        //10－管辖
        if (this.guangxia.SelectedValue != "")
        {
            if (this.guangxia.SelectedValue != "null")
            {
                condition.Add(new SearchField("guangxia", this.guangxia.SelectedValue));
            }
            else
            {
                condition.Add(new SearchField("guangxia is null ", "", SearchOperator.用户定义));
            }
        }

        //9－行业分类
        if (this.hangye.SelectedValue != "")
        {
            if (this.hangye.SelectedValue != "null")
            {
                condition.Add(new SearchField("sshy", this.hangye.SelectedValue));
            }
            else
            {
                condition.Add(new SearchField("sshy is null", "", SearchOperator.用户定义));
            }
        }

        //10－行政区域
        if (this.quyu.SelectedValue != "")
        {
            if (this.quyu.SelectedValue != "null")
            {
                condition.Add(new SearchField("quyu", this.quyu.SelectedValue));
            }
            else
            {
                condition.Add(new SearchField("quyu is null", "", SearchOperator.用户定义));
            }
        }

        //11－用户自定义分类
        string userkind = "";
        foreach (ListItem m in this.userkind.Items)
        {
            if (m.Selected)
            {
                if (userkind == String.Empty)
                {
                    userkind = "( CHARINDEX('" + m.Value + "', userkind) > 0 ";
                }
                else
                {
                    userkind = userkind + " or CHARINDEX('" + m.Value + "', userkind) > 0 ";
                }
            }
        }
        if (userkind != "")
        {
            userkind = userkind + " ) ";
            condition.Add(new SearchField("", userkind, SearchOperator.用户定义));
        }

        //String sql = SearchField.GetSearchCondition(condition);
        //Response.Write(sql);
        ViewState["SearchConditionList"] = condition;
        #endregion
        return condition;
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (this.spresult.SelectedValue == "未启动" || this.spresult.SelectedValue == "其他")
        {
            this.span1.Visible = false;
        }
        else
        {
            this.span1.Visible = true;
        }
        base.OnPreRender(e);
    }
}
