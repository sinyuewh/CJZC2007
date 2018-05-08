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
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class ZcMng3_info5 : System.Web.UI.UserControl
{
    public String CzID
    {
        set { ViewState["czid"] = value; }
        get { return ViewState["czid"] as string; }
    }
    public String ZcID
    {
        set { ViewState["zcid"] = value; }
        get { return ViewState["zcid"] as string; }
    }
    
    String[] contrArrName ={ "lssws", "frdb", "wtls", "lxdh", 
        "dwdz","dzyj","spresult"};


    /// <summary>
    /// 设置页面上控件的值
    /// </summary>
    /// <param name="ht"></param>
    public void SetControlData(Hashtable ht)
    {
        bool isCuruser = true;
        if (ht["zeren"].ToString() != Page.User.Identity.Name)
        {
            //this.Row1.Visible = false;
            isCuruser = false;                  //表示不是当前用户
            this.Button1.Visible = false;       
        }

        this.status1.Text = ht["status1"].ToString();
        this.status2.Text = ht["status2"].ToString();

        foreach (String m in this.contrArrName)
        {
            if (ht.ContainsKey(m))
            {
                Control con1 = this.FindControl(m) as Control;
                if (con1 != null)
                {
                    Util.SetControlValue(con1, ht[m]);      //设置控件的值
                }

                Control con2 = this.FindControl(m + "_1") as Control;
                if (con2 != null)
                {
                    Util.SetControlValue(con2, ht[m]);      //设置控件的值
                }

                if (isCuruser)
                {
                    if(con2!=null) con2.Visible = false;
                }
                else
                {
                    if(con1!=null) con1.Visible = false;
                }
            }
        }
    }


    /// <summary>
    /// 得到页面控件的值
    /// </summary>
    /// <param name="ht"></param>
    public void GetControlData(Hashtable ht)
    {
        if (ht == null)
        {
            ht = new Hashtable();
        }

        foreach (String m in this.contrArrName)
        {
            if (ht.ContainsKey(m) == false)
            {
                Control con1 = this.FindControl(m) as Control;
                if (con1 != null)
                {
                    ht.Add(m, Util.GetControlValue(con1));
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindTC();
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deleted")
        {
            String id = e.CommandArgument.ToString();
            try
            {
                U_ZCTCBU bu1 = new U_ZCTCBU();
                bu1.DelteTC1(id);
                bu1.Close();

                Response.Redirect("EditSbb.aspx?menuIndex=6&id=" + Request["id"], true);
            }
            catch (Exception err)
            {
                Util.alert(this.Page, err.Message);
            }
        }
    }


    protected void Repeater_DataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = e.Item.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            U_ZCFilesBU bu1 = new U_ZCFilesBU();
            int count1=bu1.GetAttachFileCount(dr["id"].ToString());
            bu1.Close();

            Label lab1 = e.Item.FindControl("filecount") as Label;
            if (lab1 != null)
            {
                lab1.Text = count1 + "";
            }

            LinkButton link1 = e.Item.FindControl("butDel") as LinkButton;
            if (link1 != null)
            {
                if (dr["zeren"].ToString() != Page.User.Identity.Name)
                {
                    link1.Visible = false;
                }
            }
        }
    }


    //处理各种执行情况
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        String kind = e.CommandArgument.ToString();
        String czid = this.CzID;
        String zcid = this.ZcID;
        Response.Redirect(String.Format("ChangeZXStatus.aspx?czid={0}&zcid={1}&kind={2}&menuIndex=6", czid, zcid, kind), true);
    }

    //绑定外面的Repeater控件
    protected void Rep0_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        String key1=e.Item.DataItem.ToString();
        if (String.IsNullOrEmpty(key1) == false)
        {
            Repeater repeater1 = e.Item.FindControl("Repeater1") as Repeater;
            if (repeater1 != null)
            {
                CommTable comm1 = new CommTable();
                DataSet ds1 = this.GetZXListData(comm1, key1);
                repeater1.DataSource = ds1;
                repeater1.DataBind();
                comm1.Close();
            }
        }
    }

    #region Private Function
    //绑定资产列表
    private DataSet GetZXListData(CommTable com1, string status1)
    {
        com1.TabName = "U_ZCTC";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("status1", status1));
        condition.Add(new SearchField("czid", this.CzID, SearchFieldType.数值型));
        DataSet ds1 = com1.SearchData("*,left(remark,50) remark1", condition, "time0 ");
        return ds1;
    }

    //资产的执行情况
    private void BindTC()
    {
        //设置大类的分类
        String str0 = ConfigurationManager.AppSettings["方案执行状态大类"];
        String[] str1 = str0.Split(',');
        this.Rep0.DataSource = str1;
        this.Rep0.DataBind();
    }

    #endregion
}
