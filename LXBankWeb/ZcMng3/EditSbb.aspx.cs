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

public partial class ZcMng3_AddSbb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != null && Request["id"].Trim() != String.Empty)
            {
                U_FASPBU bu1 = new U_FASPBU();

                ///////////////////////////////////////////////////
                Hashtable ht = bu1.GetInfo2(Request["id"]);
               
                //////////////////////////////////////////////////

                this.Info1.SetControlData(ht);

                this.Info2.SetControlData(ht);
                this.Info2.SetYiJian(ht["id"].ToString());

                this.Info3.SetControlData(ht);
                this.Info4.SetControlData(ht);

                this.Info5.CzID = ht["id"].ToString();
                this.Info5.ZcID = ht["zcid"].ToString();

                this.Info6.CzID = ht["id"].ToString();
                this.Info6.ZcID = ht["zcid"].ToString();

                this.Info5.Xmsbh = ht["xmsbh"].ToString();
                this.Info5.BindData();

                this.Info6.SetControlData(ht);

                //设置资产和资产包的情况
                if (ht["zcid"].ToString().Trim() != String.Empty)
                {
                    this.MenuKind1.ZcID = ht["zcid"].ToString();
                }

                if (ht["zcbid"].ToString().Trim() != String.Empty)
                {
                    this.MenuKind1.ZcbID = ht["zcbid"].ToString();
                    
                }

                ////////////////////////////////////////////
                ViewState["zeren"] = ht["zeren"].ToString();
                ViewState["status"] = ht["status"].ToString();
                int index1 = 1;
                if (Request["menuIndex"] != null)
                {
                    index1 = int.Parse(Request["menuIndex"]);
                }
                this.SelectControl(index1, ViewState["status"].ToString());
                this.MenuKind1.SetMenu(index1);
            }
        }
    }
    
    protected override void OnInit(EventArgs e)
    {
        this.MenuKind1.MenuChange += new EventHandler(MenuKind1_MenuChange);
        base.OnInit(e);
    }

    void MenuKind1_MenuChange(object sender, EventArgs e)
    {
        Response.Redirect("EditSbb.aspx?menuIndex=" + this.MenuKind1.MenuIndex + "&id=" + Request["id"], true);
    }

    //保存数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable data = new Hashtable();
        this.Info1.GetControlData(data);
        this.Info2.GetControlData(data);
        this.Info3.GetControlData(data);
        this.Info4.GetControlData(data);
        this.Info6.GetControlData(data);
        String[] arr1 ={ "zqce", "benjin", "lixi","spstatus" };
        foreach (String m in arr1)
        {
            if (data.ContainsKey(m))
            {
                data.Remove(m);
            }
        }

        U_FASPBU bu1 = new U_FASPBU();
        bu1.EditData(data, Request["id"]);
        Response.Redirect("EditSbb.aspx?id=" + Request["id"].ToString() + "&menuIndex=" + this.MenuKind1.MenuIndex, true);
    }


    #region 私有方法
    /// <summary>
    /// 设置按钮的出现或隐藏
    /// </summary>
    /// <param name="index1"></param>
    private void SelectControl(int index1, String status1)
    {
       for (int i = 1; i <= 6; i++)
        {
            Control con1 = this.MenuKind1.Parent.FindControl("info" + i) as Control;
            if (con1 != null)
            {
                if (i != index1)
                {
                    con1.Visible = false;
                }
                else
                {
                    con1.Visible = true;
                }
            }
        }

       /////////////////////////////////////////////////////////////
       U_RolesBU bu1 = new U_RolesBU();
       bool check1 = bu1.isRole("领导秘书");
       bu1.Close();

       bool check0 = false;
       if (User.Identity.Name == ViewState["zeren"].ToString())
       {
           check0 = true;
       }

        //根据条件设置不同的按钮出现
        switch (index1)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 6:
                if (check0 || (check1 && (index1 == 3 || index1 == 4)))
                {
                    this.span1.Visible = true;
                    this.span3.Visible = true;
                }
                else
                {
                    this.span1.Visible = false;
                    this.span3.Visible = false;
                }
                
                this.span2.Visible = false;
                this.span4.Visible = false;
                this.span5.Visible = false;
                break;
            case 5:
                this.span1.Visible = false;
                this.span3.Visible = false;
                this.span4.Visible = false;

                if (check0 || check1)
                {
                    if (status1 == "04")
                    {
                        this.span2.Visible = true;
                        this.span5.Visible = false;
                    }
                    else
                    {
                        if (check1)
                        {
                            this.span5.Visible = true;
                        }
                        else
                        {
                            this.span5.Visible = false;
                        }
                        this.span2.Visible = false;
                    }
                }
                else
                {
                    this.span2.Visible = false;
                    this.span5.Visible = false;
                }
                break;
        }


        //调整提交的按钮功能（金寿吉 2015年1月27日）
        if (status1 == "14" || status1 == "16")
        {
            this.span1.Visible = false;
        }
    }
    #endregion

    //提交资产审批处理
    protected void Button2_Click(object sender, EventArgs e)
    {
        U_ZCSPBU sp1 = new U_ZCSPBU();
        string err1 = sp1.PiYueZcForDepart(Request["id"]);
        sp1.Close();
        if (err1 != null)
        {
            Util.alert(this.Page, err1);
        }
        else
        {
            PubComm.ShowInfo("已成功转交部门审批！", Application["root"] + "/ZcMng3/EditSbb.aspx?id=" + Request["id"].ToString() + "&menuIndex=5");
        }
    }


    //重新设置审批流程
    protected void Button5_Click(object sender, EventArgs e)
    {
        CommTable comm1 = new CommTable();

        ////////////////////////////////////////////////////////////////
        comm1.TabName = "U_ZC2";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", Request["id"], SearchFieldType.数值型));
        Hashtable ht = new Hashtable();
        ht["status"] = "04";
        comm1.EditQuickData(condition, ht);


        ////////////////////////////////////////////////////////////////
        comm1.TabName = "U_ZCSP";
        condition.Clear();
        condition.Add(new SearchField("CZID", Request["id"], SearchFieldType.数值型));
        comm1.DeleteData(condition);
        comm1.Close();

        Response.Redirect(Request.PathInfo, true);
    }
}
