﻿using System;
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
using System.Drawing;
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class ZiChan_ZcDetail3 : System.Web.UI.Page
{
    bool owner = false; //资产责任人
    protected void Page_Load(object sender, EventArgs e)
    {
        this.owner = Comm.IsZcMng(Request["id"], User.Identity.Name);
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            //this.BindSP(null);
            //this.BindHistoryZcSp();
           // U_ZCSPBU sp1 = new U_ZCSPBU(); 
           // sp1.SetPC(this.pc1, this.zcczid.Text);
           // sp1.Close();
        }
    }

    #region 处置资产申报信息处理
    //增加新的资产方案审批表
    protected void butNewData_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht["zcid"] = Request["id"].ToString();
            ht["status"] = "04";
            U_ZCBU zc3 = new U_ZCBU();
            zc3.InsertZcsbb(ht);
            zc3.Close();
            Response.Redirect(Request.RawUrl, true);
        }
        catch
        {
            Comm.ShowInfo("【系统错误】：数据库事务操作错误！", Request.RawUrl);
        }
    }


    //添加资产处置方式
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Context.Items["zcid"] = Request["id"].ToString();
        }
        //Context.Items["czid"] = this.zcczid.Text;
        Server.Transfer("AddZcCzfs.aspx", false);
    }


    //处理资产处置
    protected void Repeater6_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("zccz") != null)
        {
            string id = ((Label)e.Item.FindControl("zccz")).Text;
            //删除资产处置方式
            if (e.CommandName == "delete")
            {
                U_ZCBU zc3 = new U_ZCBU();
                zc3.DelZCFS(id);
                this.BindZCCZDetail(zc3);
                zc3.Close();
            }
            else
            {
                Context.Items["id"] = id;
                if (Request["id"] != null)
                {
                    Context.Items["zcid"] = Request["id"].ToString();
                }
               // Context.Items["czid"] = this.zcczid.Text;
                Server.Transfer("EditZcCzfs.aspx", false);
            }
        }
    }


    //控制－资产处置中按钮的权限
    protected void Repeater6_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int status1 = 0;
        if (this.status.Text != "")
        {
            status1 = Int32.Parse(this.status.Text);
        }
        bool zcstatus = false;
        if (status1 == (int)SP.开始审批)
        {
            zcstatus = true;
        }
        string[] ArrCon = new string[] { "AddZcczfs", "butDel", "butEdit" };
        for (int i = 0; i < ArrCon.Length; i++)
        {
            if (e.Item.FindControl(ArrCon[i]) != null)
            {
                e.Item.FindControl(ArrCon[i]).Visible= (this.owner && zcstatus );
            }
        }
        if (Comm.IsRole("系统管理员"))
        {
            for (int i = 0; i < ArrCon.Length; i++)
            {
                if (e.Item.FindControl(ArrCon[i]) != null)
                {
                    e.Item.FindControl(ArrCon[i]).Visible = true;
                }
            }
        }
    }

    //保存资产处置
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["xmbj"] = this.xmbj.Text;
        ht["zclx"] = this.zclx.Text;
        ht["zcse"] = this.zcse.Text;
       // ht["fsxzly"] = this.fsxzly.Text;
       // ht["djyj"] = this.djyj.Text;

        U_ZCBU zc3 = new U_ZCBU();
        /*
        //if (this.zcczid.Text != "")
        //{
            //zc3.UpdateZcCzsbbByCZID(this.zcczid.Text, ht);
        //}
        else
        {
            if (Request["id"] != null)
            {
                ht["zcid"] = Request["id"].ToString();
            }
            ht["status"] = "04";
            zc3.InsertZcsbb(ht);
        }
        zc3.Close();

        Response.Redirect(Request.RawUrl, true);
         */
    }
    #endregion

    #region 资产批阅处理环节
    //送部门审批
    protected void butSendToDepartLeader_Click(object sender, EventArgs e)
    {
        U_ZCSPBU sp1 = new U_ZCSPBU();
        string err1 = sp1.PiYueZcForDepart(this.zcczid.Text);
        sp1.Close();
        if (err1 != null)
        {
            Util.alert(this.Page, err1);
        }
        else
        {
            Comm.ShowInfo("已成功转交部门审批！", Application["root"] + "/ZcMng2/ZcDetail3.aspx?id=" + Request["id"].ToString());
        }
    }

    //资产审批的删除和批阅
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = (e.Item.FindControl("seldoc") as Label).Text.Trim();
            if (e.CommandName == "delete")
            {
                U_ZCSPBU sp1 = new U_ZCSPBU();
                sp1.DelSp(id);
                this.BindSP(sp1);
                sp1.Close();
            }
            else
            {
                Context.Items["zcid"] = Request.QueryString["id"];
                Context.Items["id"] = id;
                Context.Items["kind"] = (e.Item.FindControl("kind") as Label).Text.Trim();
                Context.Items["czid"] = this.zcczid.Text;

                //检测【审核委员会主席】和【决策委员会主席】能否审批
                U_ZCSPBU sp2 = new U_ZCSPBU();
                int nospcount = sp2.GetNoEndSPCount(Request.QueryString["id"]);
                sp2.Close();

                bool check1 = false;
                string rolename = "";
                if (this.status.Text == (int)SP.审核委员会审批 + "")
                {
                    rolename = "审核委员会主席";
                }
                if (this.status.Text == (int)SP.决策委员会审批 + "")
                {
                    rolename = "决策委员会主席";
                }
                if (rolename != "")
                {
                    check1 = Comm.IsRole(rolename);
                }

                if (check1 && nospcount > 1)
                {
                    Util.alert(this.Page,"抱歉，您是【" + rolename + "】，请等其他委员审批结束后，才能审批");
                }
                else
                {
                    if (check1)
                    {
                        Context.Items["zhuxi"] = "1";
                    }
                   Server.Transfer("PiYue" + (e.Item.FindControl("kind") as Label).Text.Trim() + ".aspx?bkind=0", false);
                }
            }
        }
    }

    //资产批阅的权限控制
    protected void Repeater1_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        LinkButton link2 = e.Item.FindControl("budPy") as LinkButton;
        if (link2 != null)
        {
            Label time1 = e.Item.FindControl("time1") as Label;
            Label zeren1 = e.Item.FindControl("zeren") as Label;
            Label zx1 = e.Item.FindControl("zx") as Label;
            if (time1.Text.Trim() != "" || User.Identity.Name != zeren1.Text.Trim())
            {
                link2.Visible = false;
            }
            //if (zx1!=null && zx1.Text.Trim() != "")
            //{
            //    zeren1.ForeColor = Color.Red;
            //}
        }
        Label lab1 = e.Item.FindControl("pscount") as Label;
        if (lab1 != null)
        {
            if (lab1.Text == "0")
            {
                lab1.Text = "包";
            }
        }
    }
    #endregion

    #region 私有方法
    //绑定当前资产－处置申报情况（包括处置方式）
    private void BindData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            U_ZCBU zc1 = new U_ZCBU();

            //////////////////////////////////////////
            Hashtable ht = zc1.GetCurrentZcCZbyID(id);
            if (ht.Count > 0)
            {
                this.danwei.Text = ht["danwei"].ToString();
                if (ht["depart"] != null)
                {
                    this.depart.Text = ht["depart"].ToString();
                }
                if (ht["zeren"] != null)
                {
                    this.zeren.Text = ht["zeren"].ToString();
                }
                if (ht["zcstatus"] != null)
                {
                    this.status.Text = ht["zcstatus"].ToString();
                }
                if (ht["statustext"] != null)
                {
                    this.statusText.Text = ht["statustext"].ToString();
                }
                if (this.statusText.Text == "")
                {
                    this.statusText.Text = "阅卷";
                }
                if (ht["xmsbh"] != null)
                {
                    this.xmsbh.Text = ht["xmsbh"].ToString();
                }

                //根据权限显示信息
                int status1 = 0;
                if (this.status.Text != "")
                {
                    status1 = Int32.Parse(this.status.Text);
                }

                string[] arr1 = new string[] { "zclx", "zcse", "xmbj", "fsxzly", "djyj", "zcczid" };
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (ht[arr1[i]] != null)
                    {
                        Util.SetControlValue(this.zclx.Parent.FindControl(arr1[i]), ht[arr1[i]].ToString());
                        Util.SetControlValue(this.zclx.Parent.FindControl(arr1[i] + "_1"), Util.ChangeToShow(ht[arr1[i]].ToString()));
                    }
                    if (this.owner && status1 == (int)SP.开始审批 )
                    {
                        this.zclx.Parent.FindControl(arr1[i] + "_1").Visible = false;
                    }
                    else
                    {
                        this.zclx.Parent.FindControl(arr1[i]).Visible = false;
                    }
                    if (Comm.IsRole("系统管理员"))
                    {
                        this.zclx.Parent.FindControl(arr1[i]).Visible = true;
                        this.zclx.Parent.FindControl(arr1[i] + "_1").Visible = false;
                    }
                }
                ////////////////////////////////////////////

                this.zclx.Parent.FindControl("zcczid").Visible = true;
                this.BindZCCZDetail(zc1);
            }

            zc1.Close();
            this.SetButton();   //设置按钮的权限
        }
    }

    //绑定【资产审批情况】明细
    private void BindSP(U_ZCSPBU sp1)
    {
        if (this.zcczid.Text != "")
        {
            bool flag = false;
            if (sp1 == null)
            {
                sp1 = new U_ZCSPBU();
                flag = true;
            }

            for (int i = 11; i <= 15; i++)
            {
                Repeater repeater1 = this.Repeater11.Parent.FindControl("Repeater" + i) as Repeater;
                if (repeater1 != null)
                {
                    DataSet ds1 = sp1.GetZcSPList(this.zcczid.Text, i + "");
                    if (i == 12)
                    {
                        foreach (DataRow dr in ds1.Tables[0].Rows)
                        {
                            if (dr["time1"].ToString().Trim() == String.Empty)
                            {
                                dr["ps"] = "未编号";
                            }
                            else
                            {
                                dr["ps"] = "已编号";
                            }
                        }
                    }

                    repeater1.DataSource = ds1;
                    repeater1.DataBind();

                    if (ds1.Tables[0].Rows.Count == 0)
                    {
                        repeater1.Visible = false;
                    }
                }
            }
            if (flag)
            {
                sp1.Close();
            }
        }
    }

    //绑定资产处置方式明细
    private void BindZCCZDetail(U_ZCBU zc1)
    {
        if (this.zcczid.Text != "")
        {
            DataSet ds2 = zc1.GetCZFSByCZID(this.zcczid.Text);
            this.Repeater6.DataSource = ds2;
            this.Repeater6.DataBind();
            ds2.Dispose();
        }
    }

    //绑定以往的资产审批表
    private void BindHistoryZcSp()
    {
        U_ZCSPBU sp1 = new U_ZCSPBU();
        this.Repeater0.DataSource = sp1.GetHistoryZcSp(Request.QueryString["id"]);
        this.Repeater0.DataBind();
        sp1.Close();
    }

    //设置按钮的权限 
    private void SetButton()
    {
        //设置送部门审批的按钮权限
        int status1 = 0;
        if (this.status.Text != "")
        {
            status1 = Int32.Parse(this.status.Text);
        }

        if (status1 == (int)(SP.开始审批) && this.owner)
        {
            this.butSendToDepartLeader.Visible = true;
            this.butSaveData.Visible = true;      //保存按钮的权限控制

        }
        else
        {
            this.butSendToDepartLeader.Visible = false;
            this.butSaveData.Visible = false;      //保存按钮的权限控制

        }

        if ((status1 == (int)(SP.决策委员会同意) || status1 == (int)(SP.审核委员会同意))
            && this.owner)
        {
            this.butNewData.Visible = true;
        }
        else
        {
            this.butNewData.Visible = false;
        }

        if (Comm.IsRole("系统管理员") || User.Identity.Name == this.zeren.Text)
        {
            this.Button1.Visible = true;
            this.Button3.Visible = true;
            this.butSaveData.Visible = true;
        }
        else
        {
            this.Button1.Visible = false;
            this.Button3.Visible = false;
        }
    }
    #endregion 
}