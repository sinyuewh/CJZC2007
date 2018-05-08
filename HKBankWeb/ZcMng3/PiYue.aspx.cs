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
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;

public partial class ZcMng3_PiYue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
            this.dotime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    //提交批阅意见
    protected void Button1_Click(object sender, EventArgs e)
    {
        String kind = ViewState["kind"].ToString();
        String id = Request["id"];
        if (kind != null)
        {
            switch (kind)
            {
                case "11":
                    this.SehenPiForBumen(id,this.dotime.Text);
                    break;
                case "12":
                    this.SehenPiForBanGongShiZhuRen(id,this.dotime.Text);
                    break;
                case "13":
                    this.SehenPiForShenHeWeiYuanHui(id, this.dotime.Text);
                    break;
                case "15":
                    this.SehenPiForJueCeWeiYuanHui(id, this.dotime.Text);
                    break;
                case "17":
                    this.SehenPiForPingShenYuan(id, this.dotime.Text);
                    break;
            }
        }
    }


    #region 私有方法
    //设置绑定意见
    private void BindData()
    {
        String id = Request["id"];      //得到审批的ID
        //根据ID得到审批的类别Kind
        //审批的类别有四种类型
        // kind=11  部门审批
        // kind=12  办公室立项
        // kind=13  审核委员会审批
        // kind=15  决策委员会审批
        // kind=17  评审员审批

        String kind = "";
        ViewState["czid"] = "";
        bool zx = false;

        CommTable com1 = new CommTable();
        com1.TabName = "U_ZCSP";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", id));
        DataSet ds = com1.SearchData("kind,czid,zx", condition);
        com1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            kind = ds.Tables[0].Rows[0]["kind"].ToString();
            ViewState["czid"] = ds.Tables[0].Rows[0]["czid"].ToString();
            if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["zx"].ToString().Trim()) == false)
            {
                zx = true;
            }
        }

        //根据kind不同设置不同的外观
        ViewState["kind"] = kind;
        if (kind == "11")
        {
            this.lab1.Text = "提 交 部 门 审 批 意 见";
            this.Row1.Visible = false;
            this.Row3.Visible = false;
            if (this.piyue1.Items.Count == 3)
            {
                this.piyue1.Items.RemoveAt(2);
            }
        }
        else if (kind == "12")
        {
            this.lab1.Text = "办公室立项编号";
            this.Row2.Visible = false;
            this.Row3.Visible = false;

            if (this.piyue1.Items.Count == 3)
            {
                this.piyue1.Items.RemoveAt(2);
            }
        }
        else if (kind == "13")
        {
            this.lab1.Text = "提交审核委员会审批意见";
            this.Row1.Visible = false;
            this.Row2.Visible = false;

            if (this.piyue2.Items.Count == 4 && zx)
            {
                this.piyue2.Items.RemoveAt(3);
            }
        }
        else if (kind == "15")
        {
            this.lab1.Text = "提交决策委员会审批意见";
            this.Row1.Visible = false;
            this.Row3.Visible = false;

            if (this.piyue1.Items.Count == 3 && zx )
            {
                this.piyue1.Items.RemoveAt(2);
            }
        }
        else if (kind == "17")
        {
            this.lab1.Text = "提交评审员审批意见";
            this.Row1.Visible = true;
            this.Row3.Visible = false;
            if (this.piyue1.Items.Count == 3)
            {
                this.piyue1.Items.RemoveAt(2);
            }

        }
        else
        {
            ;
        }
    }


    /// <summary>
    /// 提交部门审批
    /// </summary>
    /// <param name="id"></param>
    private void SehenPiForBumen(String id,String dotime1)
    {
        if (this.piyue1.SelectedValue == String.Empty)
        {
            Util.alert(this.Page, "错误：请选择一个审批意见！");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht["remark"] = this.remark.Text.Trim();
            ht["zeren"] = User.Identity.Name;
            if (String.IsNullOrEmpty(dotime1))
            {
                ht["time1"] = DateTime.Now.ToString();
            }
            else
            {
                ht["time1"] = dotime1;
            }
            ht["ps"] = this.piyue1.SelectedValue;

            U_ZCSPBU sp1 = new U_ZCSPBU();
            String czid = "";
            string info1 = sp1.PiYueZcForOffice(id, ht,out czid);
            sp1.Close();
            PubComm.ShowInfo(info1, Application["root"] + "/ZcMng3/EditSbb.aspx?id="+czid+"&menuIndex=5");
        }
    }


    /// <summary>
    /// 审核委员会成员审核
    /// </summary>
    /// <param name="id"></param>
    private void SehenPiForShenHeWeiYuanHui(String id,String dotime1)
    {
        if (this.piyue2.SelectedValue == String.Empty)
        {
            Util.alert(this.Page, "错误：请选择一个审批意见！");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht["remark"] = this.remark.Text.Trim();
            ht["zeren"] = User.Identity.Name;
            if (String.IsNullOrEmpty(dotime1))
            {
                ht["time1"] = DateTime.Now.ToString();
            }
            else
            {
                ht["time1"] = dotime1;
            }
            ht["ps"] = this.piyue2.SelectedValue;

            String domen1 = this.CheckShenHeWeiYuanZhuXi(id);
            if (domen1 == String.Empty)
            {
                U_ZCSPBU sp1 = new U_ZCSPBU();
                String czid = ViewState["czid"].ToString(); ;
                string info1 = sp1.PiYueZcForSH1(id, ht);
                sp1.Close();
                PubComm.ShowInfo(info1, Application["root"] + "/ZcMng3/EditSbb.aspx?id=" + czid + "&menuIndex=5");
            }
            else
            {
                Util.alert(this.Page, "错误：请等待其他成员【"+domen1+"】的审批处理后，您才能处理！");
            }
        }
    }


    /// <summary>
    /// 决策委员会成员审核
    /// </summary>
    /// <param name="id"></param>
    private void SehenPiForJueCeWeiYuanHui(String id,String dotime1)
    {
        if (this.piyue1.SelectedValue == String.Empty)
        {
            Util.alert(this.Page, "错误：请选择一个审批意见！");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht["remark"] = this.remark.Text.Trim();
            ht["zeren"] = User.Identity.Name;
            if (String.IsNullOrEmpty(dotime1))
            {
                ht["time1"] = DateTime.Now.ToString();
            }
            else
            {
                ht["time1"] = dotime1;
            }
            ht["ps"] = this.piyue1.SelectedValue;

            String domen1 = this.CheckShenHeWeiYuanZhuXi(id);
            if (domen1 == String.Empty)
            {
                U_ZCSPBU sp1 = new U_ZCSPBU();
                String czid = ViewState["czid"].ToString(); ;
                string info1 = sp1.PiYueZcForSH2(id, ht);
                sp1.Close();
                PubComm.ShowInfo(info1, Application["root"] + "/ZcMng3/EditSbb.aspx?id=" + czid + "&menuIndex=5");
            }
            else
            {
                Util.alert(this.Page, "错误：请等待其他成员【" + domen1 + "】的审批处理后，您才能处理！");
            }
        }
    }


    /// <summary>
    /// 检查是否是审核委员会主席，如果是，则判断其他用户是否已审批
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private String CheckShenHeWeiYuanZhuXi(String id)
    {
        String domen="";
        CommTable comm1 = new CommTable();
        comm1.TabName = "U_ZCSP";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id",id));
        DataSet dt0 = comm1.SearchData("czid,zx,kind,zeren", condition);
        if (dt0.Tables[0].Rows.Count > 0)
        {
            DataRow dr0 = dt0.Tables[0].Rows[0];
            if (dr0["zx"].ToString().Trim() != String.Empty)
            {
                String czid = dr0["czid"].ToString();
                String zeren1 = dr0["zeren"].ToString();
                if (dr0["kind"].ToString() == "13" || 
                    dr0["kind"].ToString() == "15")
                {
                    condition.Clear();
                    condition.Add(new SearchField("czid", czid));
                    condition.Add(new SearchField("zeren", zeren1, 
                        SearchOperator.不等于));
                    condition.Add(new SearchField("time1 is null", "",
                        SearchOperator.用户定义));

                    //查询数据
                    DataSet ds0 = comm1.SearchData("zeren", condition);
                    foreach (DataRow dr in ds0.Tables[0].Rows)
                    {
                        if (domen == String.Empty)
                        {
                            domen = dr["zeren"].ToString();
                        }
                        else
                        {
                            domen = domen + ";" + dr["zeren"].ToString();
                        }
                    }
                }
            }
        }
        comm1.Close();
        return domen;
    }

    /// <summary>
    /// 提交评审员的审批
    /// </summary>
    /// <param name="id"></param>
    private void SehenPiForPingShenYuan(String id,String dotime1)
    {
        if (this.piyue1.SelectedValue == String.Empty)
        {
            Util.alert(this.Page, "错误：请选择一个审批意见！");
        }
        else
        {
            if (this.piyue1.SelectedValue=="同意" && this.xmsbh.Text.Trim() == String.Empty)
            {
                Util.alert(this.Page, "错误：请输入项目申报号！");
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht["remark"] = this.remark.Text.Trim();
                ht["zeren"] = User.Identity.Name;
                ht["xmsbh"] = this.xmsbh.Text.Trim();
                ht["czid"] = Request["czid"];

                if (String.IsNullOrEmpty(dotime1))
                {
                    ht["time1"] = DateTime.Now.ToString();
                }
                else
                {
                    ht["time1"] = dotime1;
                }
                ht["ps"] = this.piyue1.SelectedValue;

                U_ZCSPBU sp1 = new U_ZCSPBU();
                String czid = "";
                string info1 = sp1.PiYueZcForPingShenYuan(id, ht, out czid);
                sp1.Close();
                PubComm.ShowInfo(info1, Application["root"] + "/ZcMng3/EditSbb.aspx?id=" + czid + "&menuIndex=5");
            }
        }
    }


    /// <summary>
    /// 办公室编号
    /// </summary>
    /// <param name="id"></param>
    private void SehenPiForBanGongShiZhuRen(String id,String dotime1)
    {
        if (this.xmsbh.Text == String.Empty)
        {
            Util.alert(this.Page, "错误：请输入项目申报号！");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht["remark"] = this.remark.Text.Trim();
            ht["zeren"] = User.Identity.Name;
            if (String.IsNullOrEmpty(dotime1))
            {
                ht["time1"] = DateTime.Now.ToString();
            }
            else
            {
                ht["time1"] = dotime1;
            }
            ht["ps"] = "同意";
            ht["xmsbh"] = this.xmsbh.Text;                  //项目申报号
            ht["czid"] = ViewState["czid"].ToString();      //项目的ID

            U_ZCSPBU sp1 = new U_ZCSPBU();
            String czid = ViewState["czid"].ToString();
            string info1 = sp1.PiYueZcForSHWeiYuan(id, ht);
            sp1.Close();
            PubComm.ShowInfo(info1, Application["root"] + "/ZcMng3/EditSbb.aspx?id=" + czid + "&menuIndex=5");
        }
    }
    #endregion


    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/ZcMng3/EditSbb.aspx?id=" + ViewState["czid"].ToString() + "&menuIndex=5", true);
    }
}
