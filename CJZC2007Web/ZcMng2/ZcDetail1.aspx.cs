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

public partial class ZiChan_ZcDetail1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["id"].Trim() == "")
        {
            Response.Redirect("~/Error.aspx", true);
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.SetPageControlIni();       //设置页面控件初始化 
                this.SetPageData();             //设置页面控件的值
                this.BindOldZCInfo();           //显示资产修改日志
                this.BindZcFpLog();             //显示资产分配日志
                this.SetFocus();
            }
        }
    }

    //更新资产数据
    protected void SaveDataClick(object sender, EventArgs e)
    {
        //设置更新字段
        String[] arr1 = new string[] {  "danwei","zhwd","num1","num2","huobei","huilv","bj","lx1","lx2","lx3",
                                        "sshy","quyu","guangxia","zcbao","bank","htnum","time0",
                                        "zzjg","jysfzc","clsj","zczb","dqjj","qygm","dwdz","dwfzr",
                                        "qyjjxz","yxzzzk","xdri","dkffrq1","jklsh","dkye","dkffrq2","htdqr",
                                        "zjycszje","zydbfs","dbrwmc","yyldxt","xcyqrq","jrblsj","fenlei","remark"};

        Hashtable ht = new Hashtable();
        for (int i = 0; i < arr1.Length; i++)
        {
            if (this.zcbao.Parent.FindControl(arr1[i]) != null)
            {
                ht.Add(arr1[i], Util.GetControlValue(this.zcbao.Parent.FindControl(arr1[i])));
            }
        }

        try
        {
            U_ZCBU zc1 = new U_ZCBU();
            zc1.UpdateInfo(Request["id"], ht);
            zc1.Close();

            //向直接领导发送邮件操作
            string title = String.Format("用户{0}已修改了档案号为{1}的资产档案", User.Identity.Name, this.num2.Text);
            string remark = title+"<br><br><b><font color='#ff0000'>此邮件要求提交审阅意见</font></b>";

            //Comm.SendMailToLeader(title, remark,Request.RawUrl);

            Comm.ShowInfo("操作提示：更新资料成功！", Request.RawUrl);

        }
        catch
        {
            Util.alert(this.Page, "错误提示：更新资产数据失败，可能的原因是数据类型有错误，请检查【转入时间】日期，【本金利息】等为数值型后重新输入！");
        }
    }


    #region 资产基本资料修改日志
    //删除数据
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = (e.Item.FindControl("seldoc") as Label).Text.Trim();

            if (e.CommandName == "delete")
            {
                U_ZCBU zc1 = new U_ZCBU();
                zc1.DelOldZC(id);
                this.BindOldZCInfo();
                zc1.Close();
            }
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("butDel") != null)
        {
            LinkButton link1 = e.Item.FindControl("butDel") as LinkButton;
            if (Comm.IsRole(User.Identity.Name, "系统管理员"))
            {
                link1.Visible = true;
            }
            else
            {
                link1.Visible = false;
            }
        }
    }
    #endregion

    #region 资产分配日志处理
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = (e.Item.FindControl("seldoc") as Label).Text.Trim();

            if (e.CommandName == "delete")
            {
                U_ZcFPLogBU fp1 = new U_ZcFPLogBU();
                fp1.DeleteData(id);
                fp1.Close();
                this.BindZcFpLog();
            }
        }
    }


    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("butDel") != null)
        {
            LinkButton link1 = e.Item.FindControl("butDel") as LinkButton;
            if (Comm.IsRole(User.Identity.Name, "系统管理员"))
            {
                link1.Visible = true;
            }
            else
            {
                link1.Visible = false;
            }
        }
    }
    #endregion

    #region 私有方法

    //页面控件初始化
    private void SetPageControlIni()
    {
        //设置数据字典的条码
        U_ItemBU item1 = new U_ItemBU();
        item1.ItemName = "总行委贷";
        item1.SetLiteralControl(this.zhwd, "请选择...");

        item1.ItemName = "行业分类";
        item1.SetLiteralControl(this.sshy, "请选择...");

        item1.ItemName = "行政区域";
        item1.SetLiteralControl(this.quyu, "请选择...");

        item1.ItemName = "银行定义";
        item1.SetLiteralControl(this.bank, "请选择...");

        item1.ItemName = "资产性质分类";
        item1.SetLiteralControl(this.fenlei, "请选择...");

        item1.ItemName = "企业经营状况";
        item1.SetLiteralControl(this.jysfzc, "请选择...");

        item1.ItemName = "地区经济与信用状况";
        item1.SetLiteralControl(this.dqjj, "请选择...");

        item1.ItemName = "企业规模";
        item1.SetLiteralControl(this.qygm, "请选择...");

        item1.ItemName = "企业经济性质";
        item1.SetLiteralControl(this.qyjjxz, "请选择...");

        item1.ItemName = "债务人有效资产状况";
        item1.SetLiteralControl(this.yxzzzk, "请选择...");

        item1.ItemName = "管辖";
        item1.SetLiteralControl(this.guangxia, "请选择...");

        item1.ItemName = "政策包";
        item1.SetLiteralControl(this.zcbao, "请选择...");
        item1.Close();

        //设置时间控件
        this.time0.Attributes["onfocus"] = "setday(this)";
        this.clsj.Attributes["onfocus"] = "setday(this)";
        this.xdri.Attributes["onfocus"] = "setday(this)";
        this.dkffrq1.Attributes["onfocus"] = "setday(this)";
        this.dkffrq2.Attributes["onfocus"] = "setday(this)";
        this.htdqr.Attributes["onfocus"] = "setday(this)";
        this.xcyqrq.Attributes["onfocus"] = "setday(this)";
        this.jrblsj.Attributes["onfocus"] = "setday(this)";
    }

    //设置页面控制的值及显示格式等
    private void SetPageData()
    {
        string id = Request["id"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetDetailByID(id);
        zc1.Close();

        //设置控件的值
        bool owner = false;
        string user1 = "";
        if (ds.Tables[0].Rows[0]["zeren"] != DBNull.Value)
        {
            user1 = ds.Tables[0].Rows[0]["zeren"].ToString();
        }

        if (user1 == User.Identity.Name || (user1.Trim() == "" && Comm.IsRole("系统管理员")))
        {
            owner = true;
        }
        else
        {
            this.but0.Visible = false;
        }

        if (Comm.IsRole("系统管理员"))
        {
            this.Button1.Visible = true;
            this.Button2.Visible = true;
            this.Button3.Visible = true;
        }
        else
        {
            this.Button1.Visible = false;
            this.Button2.Visible = false;
            this.Button3.Visible = false;
        }
        //设置控件数据的显示
        for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
        {
            string colName = ds.Tables[0].Columns[i].ColumnName.ToLower();
            if (owner)
            {
                if (this.zcbao.Parent.FindControl(colName) != null)
                {
                    Util.SetControlValue(this.zcbao.Parent.FindControl(colName), ds.Tables[0].Rows[0][colName]);
                }
                if (this.zcbao.Parent.FindControl(colName + "_1") != null)
                {
                    this.zcbao.Parent.FindControl(colName + "_1").Visible = false; ;
                }
            }
            else
            {
                if (this.zcbao.Parent.FindControl(colName + "_1") != null)
                {
                    Util.SetControlValue(this.zcbao.Parent.FindControl(colName + "_1"), ds.Tables[0].Rows[0][colName]);
                }
                if (this.zcbao.Parent.FindControl(colName) != null)
                {
                    this.zcbao.Parent.FindControl(colName).Visible = false; ;
                }
            }

            this.status.Text = ds.Tables[0].Rows[0]["statustext"].ToString();
            this.status_1.Text = ds.Tables[0].Rows[0]["statustext"].ToString();

            if (ds.Tables[0].Rows[0]["time0"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["time0"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("time0"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("time0_1"), dt);
            }

            if (ds.Tables[0].Rows[0]["status"] != DBNull.Value)
            {
                string st = ds.Tables[0].Rows[0]["statusText"].ToString();
                Util.SetControlValue(this.zcbao.Parent.FindControl("status"), st);
                Util.SetControlValue(this.zcbao.Parent.FindControl("status_1"), st);
            }

            if (ds.Tables[0].Rows[0]["clsj"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["clsj"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("clsj"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("clsj_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["xdri"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["xdri"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("xdri"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("xdri_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["dkffrq1"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["dkffrq1"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("dkffrq1"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("dkffrq1_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["xcyqrq"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["xcyqrq"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("xcyqrq"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("xcyqrq_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["jrblsj"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["jrblsj"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("jrblsj"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("jrblsj_1"), dt);
            }
        }


        //设置转入价的显示
        if (Comm.IsRole("公司领导") || Comm.IsRole("评审部角色"))
        {
            this.zcbao.Parent.FindControl("zhuang_1").Visible = true;
        }
        else
        {
            this.zcbao.Parent.FindControl("zhuang_1").Visible = false;
        }

        //设置数字金额的显示
        string[] num1 = new string[] { "bj", "lx1", "lx2", "lx3", "zczb", "dkye", "zjycszje" };
        for (int i = 0; i < num1.Length; i++)
        {
            TextBox t1 = this.bj.Parent.FindControl(num1[i]) as TextBox;
            Label l1 = this.bj.Parent.FindControl(num1[i] + "_1") as Label;
            if (t1 != null)
            {
                t1.Text = Comm.GetNumberFormat(t1.Text);
            }
            if (l1 != null)
            {
                l1.Text = Comm.GetNumberFormat(l1.Text);
            }
        }

        
    }

    //资产修改日志
    private void BindOldZCInfo()
    {
        string zcid = Request["id"].ToString();
        U_ZCBU zc2 = new U_ZCBU();
        DataSet ds1 = zc2.GetOldZCInfo(zcid);
        zc2.Close();
        this.Repeater1.DataSource = ds1;
        this.Repeater1.DataBind();
    }

    //资产分配日志
    private void BindZcFpLog()
    {
        string zcid = Request["id"].ToString();
        U_ZcFPLogBU fp1 = new U_ZcFPLogBU();
        DataSet ds1 = fp1.GetZcFpLogList(Request["id"]);
        this.Repeater2.DataSource = ds1;
        this.Repeater2.DataBind();
        fp1.Close();
        ds1.Dispose();
        
    }

    protected override void OnPreRenderComplete(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //设置档案文件
            //this.Repeater2.Visible = false;
            String ajnum = this.num2.Text;
            if (String.IsNullOrEmpty(ajnum))
            {
                ajnum = this.num2_1.Text;
            }

            if (String.IsNullOrEmpty(ajnum) == false)
            {
                CommTable com1 = new CommTable("DA_AJDZFile");
                List<SearchField> condition = new List<SearchField>();
                condition.Add(new SearchField("ajnum", ajnum));
                DataSet ds1 = com1.SearchData("*", condition);
                this.Repeater3.DataSource = ds1;
                this.Repeater3.DataBind();
                com1.Close();
            }
        }
        base.OnPreRenderComplete(e);
    }
    //设置回车效果
    private void SetFocus()
    {
        this.danwei.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.zhwd.ClientID + ".focus(); return false; } ");
        this.zhwd.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.num1.ClientID + ".focus(); return false; } ");
        this.num1.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.num2.ClientID + ".focus(); return false; } ");
        this.num2.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.huobi.ClientID + ".focus(); return false; } ");
        this.huobi.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.huilv.ClientID + ".focus(); return false; } ");
        this.huilv.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.bj.ClientID + ".focus(); return false; } ");
        this.bj.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.lx1.ClientID + ".focus(); return false; } ");
        this.lx1.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.lx2.ClientID + ".focus(); return false; } ");
        this.lx2.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.lx3.ClientID + ".focus(); return false; } ");
        this.lx3.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.sshy.ClientID + ".focus(); return false; } ");
        this.sshy.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.quyu.ClientID + ".focus(); return false; } ");
        this.quyu.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.guangxia.ClientID + ".focus(); return false; } ");
        this.guangxia.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.zcbao.ClientID + ".focus(); return false; } ");
        this.zcbao.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.bank.ClientID + ".focus(); return false; } ");
        this.bank.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.htnum.ClientID + ".focus(); return false; } ");
        this.htnum.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.time0.ClientID + ".focus(); return false; } ");
        this.time0.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.zzjg.ClientID + ".focus(); return false; } ");
        this.zzjg.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.jysfzc.ClientID + ".focus(); return false; } ");
        this.jysfzc.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.clsj.ClientID + ".focus(); return false; } ");
        this.clsj.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.zczb.ClientID + ".focus(); return false; } ");
        this.zczb.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dqjj.ClientID + ".focus(); return false; } ");
        this.dqjj.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.qygm.ClientID + ".focus(); return false; } ");
        this.qygm.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dwdz.ClientID + ".focus(); return false; } ");
        this.dwdz.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dwfzr.ClientID + ".focus(); return false; } ");
        this.dwfzr.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.qyjjxz.ClientID + ".focus(); return false; } ");
        this.qyjjxz.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.yxzzzk.ClientID + ".focus(); return false; } ");
        this.yxzzzk.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.xdri.ClientID + ".focus(); return false; } ");
        this.xdri.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dkffrq1.ClientID + ".focus(); return false; } ");
        this.dkffrq1.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.jklsh.ClientID + ".focus(); return false; } ");
        this.jklsh.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dkye.ClientID + ".focus(); return false; } ");
        this.dkye.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dkffrq2.ClientID + ".focus(); return false; } ");
        this.dkffrq2.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.htdqr.ClientID + ".focus(); return false; } ");
        this.htdqr.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.zjycszje.ClientID + ".focus(); return false; } ");
        this.zjycszje.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.zydbfs.ClientID + ".focus(); return false; } ");
        this.zydbfs.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.dbrwmc.ClientID + ".focus(); return false; } ");
        this.dbrwmc.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.yyldxt.ClientID + ".focus(); return false; } ");
        this.yyldxt.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.xcyqrq.ClientID + ".focus(); return false; } ");
        this.xcyqrq.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.jrblsj.ClientID + ".focus(); return false; } ");
        this.jrblsj.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.fenlei.ClientID + ".focus(); return false; } ");
        this.fenlei.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.remark.ClientID + ".focus(); return false; } ");
    }

    #endregion


    #region 备用参考
    //设置页面控件的值
    private void SetPageData1()
    {
        string id = Request["id"];
        U_ZCBU zc1 = new U_ZCBU();
        DataSet ds = zc1.GetDetailByID(id);
        zc1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            //设置管理员字段
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    Util.SetControlValue(this.zcbao.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
            //    if (this.zcbao.Parent.FindControl(arr1[i] + "_1") != null)
            //    {
            //        //设置对应的标签提示信息
            //        Util.SetControlValue(this.zcbao.Parent.FindControl(arr1[i] + "_1"), ds.Tables[0].Rows[0][arr1[i]]);
            //    }
            //}


            if (ds.Tables[0].Rows[0]["time0"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["time0"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("time0"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("time0_1"), dt);
            }

            if (ds.Tables[0].Rows[0]["status"] != DBNull.Value)
            {
                string st = ds.Tables[0].Rows[0]["statusText"].ToString();
                Util.SetControlValue(this.zcbao.Parent.FindControl("status"), st);
                Util.SetControlValue(this.zcbao.Parent.FindControl("status_1"), st);
            }

            if (ds.Tables[0].Rows[0]["clsj"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["clsj"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("clsj"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("clsj_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["xdri"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["xdri"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("xdri"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("xdri_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["dkffrq1"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["dkffrq1"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("dkffrq1"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("dkffrq1_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["xcyqrq"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["xcyqrq"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("xcyqrq"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("xcyqrq_1"), dt);
            }
            if (ds.Tables[0].Rows[0]["jrblsj"] != DBNull.Value)
            {
                string dt = DateTime.Parse(ds.Tables[0].Rows[0]["jrblsj"].ToString()).ToString("yyyy-MM-dd");
                Util.SetControlValue(this.zcbao.Parent.FindControl("jrblsj"), dt);
                Util.SetControlValue(this.zcbao.Parent.FindControl("jrblsj_1"), dt);
            }
        }
        ds.Dispose();
        this.bj.Text = Comm.GetNumberFormat(this.bj.Text);

        //设置按钮的权限
        string user1 = this.zeren.Text;
        if (user1 == User.Identity.Name || (user1.Trim() == "" && Comm.IsRole("系统管理员")))
        {
            this.but0.Visible = true;
        }
        else
        {
            this.but0.Visible = false;
        }

        //设置控件数据的显示
        if (user1 == User.Identity.Name || (user1.Trim() == "" && Comm.IsRole("系统管理员")))
        {
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    if (this.zcbao.Parent.FindControl(arr1[i] + "_1") != null)
            //    {
            //        //设置对应的标签提示信息
            //        this.zcbao.Parent.FindControl(arr1[i] + "_1").Visible = false;
            //    }
            //}

            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    if (this.zcbao.Parent.FindControl(arr2[i] + "_1") != null)
            //    {
            //        //设置对应的标签提示信息
            //        this.zcbao.Parent.FindControl(arr2[i] + "_1").Visible = false;
            //    }
            //}
        }
        else
        {
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    if (this.zcbao.Parent.FindControl(arr1[i]) != null)
            //    {
            //        //设置对应的标签提示信息
            //        this.zcbao.Parent.FindControl(arr1[i]).Visible = false;
            //    }
            //}

            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    if (this.zcbao.Parent.FindControl(arr2[i]) != null)
            //    {
            //        //设置对应的标签提示信息
            //        this.zcbao.Parent.FindControl(arr2[i]).Visible = false;
            //    }
            //}
        }



        if (Comm.IsRole("公司领导") || Comm.IsRole("评审部角色"))
        {
            this.zcbao.Parent.FindControl("zhuang_1").Visible = true;
        }
        else
        {
            this.zcbao.Parent.FindControl("zhuang_1").Visible = false;
        }
    }

    //保存数据
    private void SaveData1()
    {
        if (Request["id"] != null)
        {
            U_ZCBU zc3 = new U_ZCBU();
            DataSet ds2 = zc3.GetDetailByID(Request["id"].ToString());
            Hashtable ht1 = new Hashtable();
            //foreach (string item in arr1)
            //{
            //    ht1[item] = ds2.Tables[0].Rows[0][item].ToString();
            //}
            //foreach (string item in arr2)
            //{
            //    ht1[item] = ds2.Tables[0].Rows[0][item].ToString();
            //}
            ht1["zcid"] = Request["id"].ToString();
            ht1["xgr"] = User.Identity.Name;
            ht1["xgsj"] = DateTime.Now.ToString();
            zc3.InsertOldZC(ht1);
        }
        Hashtable ht = new Hashtable();
        //foreach (string item in arr1)
        //{
        //    ht[item] = Util.GetControlValue(this.zcbao.Parent.FindControl(item));
        //}
        //foreach (string item in arr2)
        //{
        //    ht[item] = Util.GetControlValue(this.zcbao.Parent.FindControl(item));
        //}
        ht.Remove("status");
        ht.Remove("zhuang");
        //提交数据保存
        try
        {
            U_ZCBU zc1 = new U_ZCBU();
            zc1.UpdateInfo(Request["id"], ht);
            zc1.Close();
            this.BindOldZCInfo();
            this.SetPageData();
            Util.alert(this.Page, "操作提示：更新资料成功！");
        }
        catch (Exception err1)
        {
            Util.alert(this.Page, "错误提示：更新资产数据失败，可能的原因是数据类型有错误，请检查【转入时间】日期，【本金利息】等为数值型后重新输入！");
        }

    }

    
    #endregion
}
