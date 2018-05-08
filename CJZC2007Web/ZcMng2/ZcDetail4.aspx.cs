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

public partial class ZiChan_ZcDetail4 : System.Web.UI.Page
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
            this.BindSSQK();
        }
    }
    
    //增加资产执行情况资料
    protected void Button01_Command(object sender, CommandEventArgs e)
    {
        Context.Items["parentid"] = Request["id"];
        Context.Items["kind"] = e.CommandArgument.ToString();
        Context.Items["Bkind"] = "0";
        Server.Transfer("ZcTc.aspx", false);
    }

    //保存律师事务所资料
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht["lssws"] = this.lssws.Text;
        ht["frdb"] = this.frdb.Text;
        ht["wtls"] = this.wtls.Text;
        ht["lxdh"] = this.lxdh.Text;
        ht["dwdz"] = this.dwdz.Text;
        ht["dzyj"] = this.dzyj.Text;
        U_ZCBU zc1 = new U_ZCBU();
        zc1.UpDateZCDBInfo(Request["id"], ht);
        zc1.Close();
        Comm.ShowInfo("【操作提示】：更新资料成功！", Request.RawUrl);
    }


    #region Repeater Events
    //删除（作废）执行情况文档
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = ((Label)e.Item.FindControl("seldoc")).Text;
            if (e.CommandName == "delete")
            {
                try
                {
                    U_ZCTCBU tc1 = new U_ZCTCBU();
                    tc1.DelteTC(id);
                    this.BindTC(tc1);
                    tc1.Close();
                }
                catch (Exception err1)
                {
                    Util.alert(this.Page, err1.Message);
                }
            }
            else
            {
                try
                {
                    U_ZCTCBU tc2 = new U_ZCTCBU();
                    tc2.EditTcForstatus(id);
                    this.BindTC(tc2);
                    tc2.Close();
                }
                catch (Exception err1)
                {
                    Util.alert(this.Page, err1.Message);
                }
            }
        }
    }

    //控制链接的显示
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
    #endregion 

    #region 私有方法
    //绑定资产基本资料
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

    //绑定律师及事务所的基本情况
    private void BindSSQK()
    {
        if (Request["id"] != null)
        {
            U_ZCBU zc2 = new U_ZCBU();
            DataSet ds = zc2.GetZCDBInfoByID(Request["id"].ToString());
            string[] arr1 ={ "lssws", "frdb", "wtls", "lxdh", "dwdz", "dzyj" };
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (owner)
                    {
                        Util.SetControlValue(this.frdb.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
                        this.frdb.Parent.FindControl(arr1[i] + "_1").Visible = false;
                    }
                    else
                    {
                        Util.SetControlValue(this.frdb.Parent.FindControl(arr1[i] + "_1"), ds.Tables[0].Rows[0][arr1[i]]);
                        this.frdb.Parent.FindControl(arr1[i]).Visible = false;
                    }
                }
                ds.Dispose();
            }
            zc2.Close();
        }
    }

    //搬动资产的执行情况
    private void BindTC(U_ZCTCBU tc1)
    {
        bool flag = false;
        if (tc1 == null)
        {
            tc1 = new U_ZCTCBU();
            flag = true;
        }

        for (int i = 1; i <= 7; i++)
        {
            Repeater repeater1 = this.Repeater1.Parent.FindControl("Repeater" + i) as Repeater;
            if (repeater1 != null)
            {
                DataSet ds1 = tc1.GetTCList("2" + i, Request["id"]);
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


    //设置按钮的权限控制
    private void SetButton()
    {
        string status = this.status.Text;
        if (status != "")
        {
            int status1 = Int32.Parse(status);
            //if (owner && (status1 >= 16 || status1 == 14))
            //{
            //    this.MyButtonGroup.Visible = true;
            //}
            //else
            //{
            //    this.MyButtonGroup.Visible = false;
            //}

            if (owner || Comm.IsRole("系统管理员"))
            {
                this.MyButtonGroup.Visible = true;
            }
            else
            {
                this.MyButtonGroup.Visible = false;
            }
        }


        if (owner)
        {
            this.Button1.Visible = true;
        }
        else
        {
            this.Button1.Visible = false;
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
    protected void Button21_Click(object sender, EventArgs e)
    {

    }
}
