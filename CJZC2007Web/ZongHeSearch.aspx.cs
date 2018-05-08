using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.CJZC.Business;
using WebFrame.Data;
using WebFrame;
using System.Data;

public partial class ZongHeSearch : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.depart.SelectedIndexChanged += new EventHandler(depart_SelectedIndexChanged);
        this.GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
        this.Button1.Click += new EventHandler(Button1_Click);
        base.OnInit(e);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        String temp = null;
        ZcspBU bu1 = new ZcspBU();
        DataRowView dv = e.Row.DataItem as DataRowView;
        String hankouRoot = System.Configuration.ConfigurationManager.AppSettings["hkbankurl"];

        String lxRoot = System.Configuration.ConfigurationManager.AppSettings["lxbankurl"];

        if (dv != null)
        {
            DataRow dr = dv.Row;
            HyperLink link1 = e.Row.FindControl("link1") as HyperLink;
            if (link1 != null)
            {
                link1.Target = "_blank";
                link1.Text = JSJ.SysFrame.Util.GetMaxLenth(dr["danwei"].ToString().Trim(), 18);
                if (dr["id"].ToString().Trim() != String.Empty)
                {
                    if (dr["tablekind"].ToString() == "0")
                    {
                        link1.NavigateUrl = "~/ZcMng2/ZcDetail1.aspx?id=" + dr["id"].ToString();
                        link1.ToolTip = "浏览资产的详细情况";
                    }
                    else if (dr["tablekind"].ToString() == "1")
                    {
                        link1.Text = link1.Text + "（汉）";
                        link1.NavigateUrl = hankouRoot + Page.User.Identity.Name + "&ReturnUrl=" + Server.UrlEncode("/ZcMng2/ZcDetail1.aspx?id=" + dr["id"].ToString());
                        link1.ToolTip = "浏览资产的详细情况";
                    }
                    else
                    {
                        link1.Text = link1.Text + "（联）";
                        link1.NavigateUrl = lxRoot + Page.User.Identity.Name + "&ReturnUrl=" + Server.UrlEncode("/ZcMng2/ZcDetail1.aspx?id=" + dr["id"].ToString());
                        link1.ToolTip = "浏览资产的详细情况";
                    }
                    //link1.Target = "_blank";
                }
            }

            //计算本金
            double benjin = 0;
            Label lab1 = e.Row.FindControl("benjin") as Label;
            if (lab1 != null)
            {
                temp = dr["bj"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp))
                {
                    temp = "0";
                }
                benjin = double.Parse(temp);
                lab1.Text = benjin.ToString("n");
            }

            //计算利息
            double lixi = 0;
            lab1 = e.Row.FindControl("lixi") as Label;
            if (lab1 != null)
            {
                temp = dr["lx"].ToString().Replace(",", "");
                if (String.IsNullOrEmpty(temp)) temp = "0";
                lixi = double.Parse(temp);
                lab1.Text = lixi.ToString("n");
            }


            //计算总额
            lab1 = e.Row.FindControl("zqce") as Label;
            if (lab1 != null)
            {
                lab1.Text = (benjin + lixi).ToString("n");
            }

            DataRow info1 = dr;

            //DataRow info1 = bu1.GetShenPiInfo("spstatus,spresult,status1,status2 ", dr["id"].ToString(), "1");

            //审批状态
            lab1 = e.Row.FindControl("spstatus") as Label;
            if (lab1 != null && dr["id"].ToString().Trim() != String.Empty)
            {
                String s1 = String.Empty;
                if (info1 != null)
                {
                    s1 = info1["spstatus"].ToString().Trim();
                }
                if (s1 == String.Empty) s1 = "-1";
                int status1 = int.Parse(s1);
                if (status1 == -1)
                {
                    lab1.Text = "<span title='未启动审批'>□</span>";
                }
                if (status1 == 0)
                {
                    lab1.Text = "<span title='审批中'><font color='blue'>○</font></span>";
                }
                if (status1 == 1)
                {
                    lab1.Text = "<span title='审核委员会批'><font color='Red'>☆</font></span>";
                }
                if (status1 == 2)
                {
                    lab1.Text = "<span title='决策委员会批'><font color='Red'>☆☆</font></span>";
                }

            }

            //执行结果
            lab1 = e.Row.FindControl("spresult") as Label;
            if (lab1 != null && dr["id"].ToString().Trim() != String.Empty)
            {
                if (info1 != null)
                {
                    lab1.Text = info1["spresult"].ToString().Trim();
                }
            }

            //执行状态
            lab1 = e.Row.FindControl("zxzt") as Label;
            if (lab1 != null && dr["id"].ToString().Trim() != String.Empty)
            {
                if (info1 != null)
                {
                    if (info1["status1"].ToString().Trim() != String.Empty)
                    {
                        temp = info1["status1"].ToString() + "-" + info1["status2"].ToString();
                    }
                    else
                    {
                        temp = "&nbsp;";
                    }
                    lab1.Text = temp;
                }
            }

            /*
            if (this.SearchControl1.SearchType == SearchDataType.单条资产)
            {
                lab1 = e.Row.FindControl("zcid") as Label;
                if (lab1 != null)
                {
                    lab1.Text = dr["id"].ToString().Trim();
                }
            }
            else
            {
                lab1 = e.Row.FindControl("zcbid") as Label;
                if (lab1 != null)
                {
                    lab1.Text = dr["id"].ToString().Trim();
                }
            }*/
        }
    }

    //查询资产
    void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds1 = this.GetCommZc(true);

        if (ds1 != null)
        {
            ds1.Tables[0].PrimaryKey = null;
            ds1.Tables[0].Columns.Add("TableKind");
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                dr1["TableKind"] = "0";
            }

            //汉口银行数据库
            DataSet ds2 = this.GetHankZc(true);
            ds2.Tables[0].PrimaryKey = null;
            ds2.Tables[0].Columns.Add("TableKind");
            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                dr2["TableKind"] = "1";
            }

            //联想数据库
            DataSet ds3 = this.GetZcForDb("LXConnstring", true);
            ds3.Tables[0].PrimaryKey = null;
            ds3.Tables[0].Columns.Add("TableKind");
            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                dr3["TableKind"] = "2";
            }


            //将数据库合并
            ds1.Merge(ds2);
            ds1.Merge(ds3);

            //绑定数据库
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();
        }
        else
        {
            JSJ.SysFrame.Util.alert(this.Page, "错误：请至少选择或输入一个条件！");
        }

    }

    //调整部门的值
    void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetDepartAndPerson();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetMyData();
            this.SetDepartAndPerson();
        }
    }


    /// <summary>
    /// 设置部门和人员
    /// </summary>
    private void SetDepartAndPerson()
    {
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "所有责任人");
        this.zeren.SelectedValue = "";

        //判断是否为公司领导
        U_RolesBU role1 = new U_RolesBU();
        bool isLeader = role1.isRole(new String[] { "公司领导", "综合管理", "评审部角色" });
        role1.Close();

        if (isLeader == false)
        {
            this.depart.Visible = false;

            this.zeren.Items.Clear();
            ListItem list1 = new ListItem(Page.User.Identity.Name, Page.User.Identity.Name);
            this.zeren.Items.Add(list1);
            this.zeren.SelectedIndex = 0;
        }
    }


    
    /// <summary>
    /// 初始化代码
    /// </summary>
    private void SetMyData()
    {
        Comm.SetDepart(this.depart, "所有部门");
        this.depart.SelectedValue = "";
    }


    /// <summary>
    /// 得到一般政策库的资产
    /// </summary>
    /// <param name="AllZc"></param>
    /// <returns></returns>
    private DataSet GetCommZc(bool AllZc)
    {
        ZcBu bu1 = new ZcBu();
        DataSet ds1 = null;
        List<JSJ.SysFrame.DB.SearchField> condition = new List<JSJ.SysFrame.DB.SearchField>();

        //1－单位名称
        if (this.danwei.Text.Trim() != "")
        {
            condition.Add(new JSJ.SysFrame.DB.SearchField("u_zc.danwei", this.danwei.Text.Trim(), JSJ.SysFrame.SearchOperator.包含));
        }

        //2－档案编号
        if (this.num2.Text.Trim() != "")
        {
            condition.Add(new JSJ.SysFrame.DB.SearchField("num2", this.num2.Text.Trim()));
        }

        if (this.depart.SelectedValue != String.Empty || this.zeren.SelectedValue != String.Empty)
        {
            //4－责任人
            if (this.zeren.SelectedValue != "")
            {
                condition.Add(new JSJ.SysFrame.DB.SearchField("zeren", this.zeren.SelectedValue));
            }
            else
            {
                //3－责任部门
                if (this.depart.SelectedValue != "")
                {
                    condition.Add(new JSJ.SysFrame.DB.SearchField("depart", this.depart.SelectedValue));
                }
            }
        }

        if (condition.Count > 0)
        {
            ds1 = bu1.GetZcList(condition, AllZc);
            return ds1;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 得到汉口银行的资产
    /// </summary>
    /// <returns></returns>
    private DataSet GetHankZc(bool AllZc)
    {
        DataSet ds1 = this.GetZcForDb("HKConnstring",AllZc);

        /*
        List<SearchField> condition = new List<SearchField>();
        WebFrame.Data.JConnect conn1 = WebFrame.Data.JConnect.GetConnect("HKConnstring");

        //1－单位名称
        if (this.danwei.Text.Trim() != "")
        {
            condition.Add(new SearchField("u_zc.danwei", this.danwei.Text.Trim(), SearchOperator.Contains));
        }

        //2－档案编号
        if (this.num2.Text.Trim() != "")
        {
            condition.Add(new SearchField("num2", this.num2.Text.Trim()));
        }
                
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

        if (condition.Count > 0)
        {
            JCommand comm1 = new JCommand(conn1);
            String sql = null;
            if (AllZc == false)
            {
                sql = @"select distinct u_zc.id,num2,u_zc.danwei,bj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx ,zeren,zeren1,U_ZC2SearchView2.spstatus,
                            U_ZC2SearchView2.status1,U_ZC2SearchView2.status2,U_ZC2SearchView2.spresult,U_ZC2SearchView2.spdotime,
                            bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx 
                            from u_zc left outer join U_ZC2SearchView2 on U_ZC.id=U_ZC2SearchView2.zcid where not exists (select * from u_zcbaoinfo where zcid=u_zc.id) ";
            }
            else
            {
                sql = @"select distinct u_zc.id,num2,u_zc.danwei,bj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx ,zeren,zeren1,U_ZC2SearchView2.spstatus,
                            U_ZC2SearchView2.status1,U_ZC2SearchView2.status2,U_ZC2SearchView2.spresult,U_ZC2SearchView2.spdotime,
                            bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx 
                            from u_zc left outer join U_ZC2SearchView2 on U_ZC.id=U_ZC2SearchView2.zcid where 1=1  ";
            }


            if (condition != null && condition.Count > 0)
            {
                String conditionStr = SearchField.GetSearchCondition(condition);
                if (String.IsNullOrEmpty(conditionStr) == false)
                {
                    sql = sql + " and " + conditionStr;
                }
            }
            sql = sql + " order by num2 ";
            comm1.CommandText = sql;
            ds1 = comm1.SearchData(-1);
            comm1.Close();
            WebFrame.Data.JConnect.CloseConnect();
        }*/
        return ds1;
    }


    /// <summary>
    /// 得到银行的资产
    /// </summary>
    /// <returns></returns>
    private DataSet GetZcForDb(String DbName,bool AllZc)
    {
        DataSet ds1 = null;
        List<SearchField> condition = new List<SearchField>();
        WebFrame.Data.JConnect conn1 = WebFrame.Data.JConnect.GetConnect(DbName);

        //1－单位名称
        if (this.danwei.Text.Trim() != "")
        {
            condition.Add(new SearchField("u_zc.danwei", this.danwei.Text.Trim(), SearchOperator.Contains));
        }

        //2－档案编号
        if (this.num2.Text.Trim() != "")
        {
            condition.Add(new SearchField("num2", this.num2.Text.Trim()));
        }

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

        if (condition.Count > 0)
        {
            JCommand comm1 = new JCommand(conn1);
            String sql = null;
            if (AllZc == false)
            {
                sql = @"select distinct u_zc.id,num2,u_zc.danwei,bj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx ,zeren,zeren1,U_ZC2SearchView2.spstatus,
                            U_ZC2SearchView2.status1,U_ZC2SearchView2.status2,U_ZC2SearchView2.spresult,U_ZC2SearchView2.spdotime,
                            bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx 
                            from u_zc left outer join U_ZC2SearchView2 on U_ZC.id=U_ZC2SearchView2.zcid where not exists (select * from u_zcbaoinfo where zcid=u_zc.id) ";
            }
            else
            {
                sql = @"select distinct u_zc.id,num2,u_zc.danwei,bj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx ,zeren,zeren1,U_ZC2SearchView2.spstatus,
                            U_ZC2SearchView2.status1,U_ZC2SearchView2.status2,U_ZC2SearchView2.spresult,U_ZC2SearchView2.spdotime,
                            bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx 
                            from u_zc left outer join U_ZC2SearchView2 on U_ZC.id=U_ZC2SearchView2.zcid where 1=1  ";
            }


            if (condition != null && condition.Count > 0)
            {
                String conditionStr = SearchField.GetSearchCondition(condition);
                if (String.IsNullOrEmpty(conditionStr) == false)
                {
                    sql = sql + " and " + conditionStr;
                }
            }
            sql = sql + " order by num2 ";
            comm1.CommandText = sql;
            ds1 = comm1.SearchData(-1);
            comm1.Close();
            WebFrame.Data.JConnect.CloseConnect();
        }
        return ds1;
    }
}
