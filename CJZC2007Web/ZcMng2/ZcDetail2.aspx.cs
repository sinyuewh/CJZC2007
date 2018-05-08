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

public partial class ZiChan_ZcDetail2 : System.Web.UI.Page
{
    bool owner = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.owner = Comm.IsZcMng(Request["id"], User.Identity.Name);
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.BindData();
            this.BindTC(null);
        }
    }


    //增加资产调查数据
    protected void Button01_Command(object sender, CommandEventArgs e)
    {
        Context.Items["parentid"] = Request["id"];
        Context.Items["kind"] = e.CommandArgument.ToString();
        Context.Items["Bkind"] = "0";
        Server.Transfer("ZcTc.aspx", false);
    }


    //删除（作废）数据
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = ((Label)e.Item.FindControl("seldoc")).Text;
            U_ZCTCBU tc1 = new U_ZCTCBU();
            if (e.CommandName == "delete")
            {
                tc1.DelteTC(id);
                this.BindTC(tc1);
            }
            else
            {
                tc1.EditTcForstatus(id);
                this.BindTC(tc1); 
            }
            tc1.Close();
        }
    }

    //设置按钮链接的显示和隐藏
    protected void Repeater_DataBound(object sernder, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("butDel") != null)
        {
            LinkButton but1 = e.Item.FindControl("butDel") as LinkButton;
            LinkButton but2 = e.Item.FindControl("butEdit") as LinkButton;
            Label lab1 = e.Item.FindControl("status") as Label;
            if (this.owner == false)
            {
                but1.Visible = false;
                but2.Visible = false;
            }
            if (Comm.IsRole(User.Identity.Name, "系统管理员"))
            {
                but1.Visible = true;
            }
            else
            {
                but1.Visible = false;
            }

            string user1 = this.zeren.Text;
            if ((Comm.IsRole(User.Identity.Name, "系统管理员") || user1 == User.Identity.Name) && lab1.Text == "")
            {
                but2.Visible = true;
            }
            else
            {
                but2.Visible = false;
            }
        }
    }

    #region 私有方法
    //绑定资产调查数据
    private void BindData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetDetailByID(id, "depart,zeren,status,statusText,danwei");
            zc1.Close();

            this.danwei.Text = ds.Tables[0].Rows[0]["danwei"].ToString();
            this.depart.Text = ds.Tables[0].Rows[0]["depart"].ToString();
            this.zeren.Text = ds.Tables[0].Rows[0]["zeren"].ToString();
            this.status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            this.statusText.Text = ds.Tables[0].Rows[0]["statusText"].ToString();
            if (this.statusText.Text == "")
            {
                this.statusText.Text = "阅卷";
            }
            ds.Dispose();
            this.SetButton();

        }
    }

    //资产调查明细数据
    private void BindTC(U_ZCTCBU tc1)
    {
        bool flag = false;
        if (tc1 == null)
        {
            tc1 = new U_ZCTCBU();
            flag = true;
        }

        for (int i = 1; i <= 4; i++)
        {
            Repeater repeater1 = this.Repeater1.Parent.FindControl("Repeater" + i) as Repeater;
            if (repeater1 != null)
            {
                DataSet ds1 = tc1.GetTCList("0" + i, Request["id"]);
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
            tc1.Close();
        }
    }

    //设置按钮的显示权限
    private void SetButton()
    {
        if (owner)
        {
            string status = this.status.Text;
            if (status == "")
            {
                status = "00";
            }
            int Max1 = Int32.Parse(status) + 1;
            string[] arr1 = new string[] { "01", "02", "03", "04" };
            for (int i = 0; i < arr1.Length; i++)
            {
                HtmlGenericControl but1 = this.Button01.Parent.FindControl("but" + arr1[i]) as HtmlGenericControl;
                if (int.Parse(arr1[i]) <= Max1)
                {
                    but1.Visible = true;
                }
                else
                {
                    but1.Visible = false;
                }
            }
        }
        if (Comm.IsRole("系统管理员"))
        {
            this.Button5.Visible = true;
        }
        else
        {
            this.Button5.Visible = false;
        }
    }

    #endregion
}
