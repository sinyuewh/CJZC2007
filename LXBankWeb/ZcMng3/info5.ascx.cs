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

public partial class ZcMng3_info51 : System.Web.UI.UserControl
{
    public String CzID
    {
        set { ViewState["czid"] = value; }
        get {  return ViewState["czid"] as string; }
    }
    public String ZcID
    {
        set { ViewState["zcid"] = value; }
        get { return ViewState["zcid"] as string; }
    }

    public String Xmsbh
    {
        set { ViewState["Xmsbh"] = value; }
        get { return ViewState["Xmsbh"] as string; }
    }


    public bool IsLeaderMiShu
    {
        set { ViewState["IsLeaderMiShu"] = value; }
        get {
                if (ViewState["IsLeaderMiShu"] == null)
                {
                    ViewState["IsLeaderMiShu"] = false;
                }
                
                return (bool)ViewState["IsLeaderMiShu"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
                
    }

    //批阅的处理
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lab1 = e.Item.FindControl("seldoc") as Label;
        if (lab1 != null)
        {
           // String kind1 = e.CommandArgument.ToString();
            Response.Redirect("PiYue.aspx?id="+lab1.Text+"&czid="+CzID, true);
        }
    }


    //绑定审批的数据
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        U_RolesBU role1 = new U_RolesBU();
        this.IsLeaderMiShu = role1.isRole("领导秘书");
        role1.Close();
        
        DataRowView dv = e.Item.DataItem as DataRowView;
        if (dv != null)
        {
            DataRow dr = dv.Row;
            String zeren1 = dr["zeren"].ToString().Trim();
            String time1 = dr["time1"].ToString().Trim();

            LinkButton link1 = e.Item.FindControl("budPy") as LinkButton;
            if (time1 != String.Empty)
            {
                link1.Visible = false;          //表示资产已经批阅过
            }
            else
            {
                if (zeren1 == Page.User.Identity.Name || this.IsLeaderMiShu)
                {
                    link1.Visible = true;          //当前批阅人和登陆用户不一致
                }
                else
                {
                    link1.Visible = false;
                }
            }

            if (dr["zx"].ToString().Trim() == "1")
            {
                Label lab1 = e.Item.FindControl("zeren") as Label;
                if (lab1 != null)
                {
                    lab1.Text = "<font color=red>★</font>" + dr["zeren"].ToString();
                }
            }
        }
    }

   

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        bool havedata = false;
        if (this.CzID != null && this.CzID != String.Empty)
        {
            U_ZCSPBU sp1 = new U_ZCSPBU();
            for (int i = 11; i <= 17; i++)
            {
                Repeater repeater1 = this.Repeater11.Parent.FindControl("Repeater" + i) as Repeater;
                if (repeater1 != null)
                {
                    DataSet ds1 = sp1.GetZcSPList(this.CzID, i + "");
                    if (havedata == false && ds1.Tables[0].Rows.Count > 0)
                    {
                        havedata = true;
                    }
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
                                dr["ps"] = this.Xmsbh;
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
            sp1.Close();

            if (havedata)
            {
                this.NoRowData.Visible = false;
            }
        }
    }

}
