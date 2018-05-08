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

public partial class ZcMng2_ZcDetail9 : System.Web.UI.Page
{

    string[] arr1 = new string[] { "zwrhsgz", "bzrhsgz", "qthsgz", "hssj", "qsqk", "remark",
                                   "bzrmc","bzje","bzyx","bzcznl","bzczyy","bzwxsm","Remark1",
                                   "qdza1","qdzayy1","czza1","zzzayy1","bxny1","klazfy","flyj1",
                                   "dyhsgz1","Remark2","qdza2","qdzayy2","czza2","zzzayy2","bxny2",
                                   "flyj2","dyhsgz2","Remark3","zeren","depart","danwei" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_ItemBU item1 = new U_ItemBU();

            item1.ItemName = "保证有效性";
            item1.SetLiteralControl(this.bzyx, "请选择...");

            item1.ItemName = "保证人的偿债能力";
            item1.SetLiteralControl(this.bzcznl, "请选择...");

            item1.ItemName = "保证人的偿债意愿";
            item1.SetLiteralControl(this.bzczyy, "请选择...");

            item1.ItemName = "抵押物取得是否存在障碍";
            item1.SetLiteralControl(this.qdza1, "请选择...");

            item1.ItemName = "抵押物处置是否存在障碍";
            item1.SetLiteralControl(this.czza1, "请选择...");

            item1.ItemName = "抵押物变现难易";
            item1.SetLiteralControl(this.bxny1, "请选择...");

            item1.ItemName = "抵押物法律意见";
            item1.SetLiteralControl(this.flyj1, "请选择...");

            item1.ItemName = "质押物取得是否存在障碍";
            item1.SetLiteralControl(this.qdza2, "请选择...");

            item1.ItemName = "质押物处置是否存在障碍";
            item1.SetLiteralControl(this.czza2, "请选择...");

            item1.ItemName = "质押物变现难易";
            item1.SetLiteralControl(this.bxny2, "请选择...");

            item1.ItemName = "质押物法律意见";
            item1.SetLiteralControl(this.flyj2, "请选择...");

            item1.Close();

            this.hssj.Attributes["onfocus"] = "setday(this)";
            ////////////////////////////////////////////////
            this.BindData();
            this.BindDZYW();
        }

    }


    //更新资产担保资料
    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        foreach (string item in arr1)
        {
            ht[item] = Util.GetControlValue(this.bzyx.Parent.FindControl(item));
        }

        try
        {
            U_ZCBU zc1 = new U_ZCBU();
            ht["id"] = Request["id"];
            ht.Remove("zeren");
            ht.Remove("danwei");
            ht.Remove("depart");
            zc1.UpDateZCDBInfo(Request["id"], ht);
            zc1.Close();
            Util.alert(this.Page, "操作提示：更新资料成功！");
        }
        catch (Exception err1)
        {
            Util.alert(this.Page, "错误提示：更新资产数据失败，可能的原因是数据类型有错误，请检查重新输入！");
        }
    }

    #region 绑定资产担保情况的内容
    private void BindData()
    {
        if (Request["id"] != null)
        {
            string zcid = Request["id"].ToString();
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetZCDBInfoByID(zcid);
            string user1 = zc1.GetZerenByZCID(zcid);
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Util.SetControlValue(this.bzyx.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
                    Util.SetControlValue(this.bzyx.Parent.FindControl(arr1[i]+"_1"), ds.Tables[0].Rows[0][arr1[i]]);
                }
                if (ds.Tables[0].Rows[0]["hssj"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["hssj"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.bzyx.Parent.FindControl("hssj"), dt);
                    Util.SetControlValue(this.bzyx.Parent.FindControl("hssj_1"), dt);
                }
            }
            ds.Dispose();


            //设置按钮的权限            
            if (user1 == User.Identity.Name || (user1.Trim() == "" && Comm.IsRole("系统管理员")))
            {
                this.Button1.Visible = true;
                this.Adddyw.Visible = true;
                this.Addzyw.Visible = true;

                for (int i = 0; i < arr1.Length; i++)
                {
                    if (this.bzyx.Parent.FindControl(arr1[i] + "_1") != null)
                    {
                        this.bzyx.Parent.FindControl(arr1[i] + "_1").Visible = false;
                    }
                }
            }
            else
            {
                this.Button1.Visible = false;
                this.Adddyw.Visible = false;
                this.Addzyw.Visible = false;

                for (int i = 0; i < arr1.Length; i++)
                {
                    if (this.bzyx.Parent.FindControl(arr1[i]) != null)
                    {
                        this.bzyx.Parent.FindControl(arr1[i]).Visible = false;
                    }
                }
            }

            if (Comm.IsRole("系统管理员"))
            {
                this.Button2.Visible = true;
            }
            else
            {
                this.Button2.Visible = false;
            }

            //设置数字金额的显示
            string[] num1 = new string[] { "zwrhsgz", "bzrhsgz", "qthsgz", "bzje", "klazfy", "dyhsgz1", "dyhsgz2" };
            for (int i = 0; i < num1.Length; i++)
            {
                TextBox t1 = this.zwrhsgz.Parent.FindControl(num1[i]) as TextBox;
                Label l1 = this.zwrhsgz.Parent.FindControl(num1[i] + "_1") as Label;
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
    }
    private void BindDZYW()
    {
        if(Request["id"] != null)
        {
            string zcid = Request["id"].ToString();
            U_ZCBU zc2 = new U_ZCBU();
            for (int i = 1; i < 3; i++)
            {
                Repeater repeater1 = this.Repeater1.Parent.FindControl("Repeater" + i) as Repeater;
                if (repeater1 != null)
                {
                    int wpkind = i - 1; 
                    DataSet ds = zc2.GetDZYWInfo(zcid, wpkind.ToString());
                    repeater1.DataSource = ds;
                    repeater1.DataBind();

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        repeater1.Visible = false;
                    }
                }
            }
            zc2.Close();
        }
    }

    #endregion

    #region Repeater Events

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("dzyw") != null)
        {
            string id = ((Label)e.Item.FindControl("dzyw")).Text;
            if (e.CommandName == "delete")
            {
                try
                {
                    U_ZCBU zc3 = new U_ZCBU();
                    zc3.DelDZYWInfo(id);
                    this.BindDZYW();
                    zc3.Close();
                }
                catch (Exception err1)
                {
                    Util.alert(this.Page, err1.Message);
                }
            }
            else
            {
                Context.Items["id"] = id;
                if (Request["id"] != null)
                {
                    Context.Items["zcid"] = Request["id"].ToString();
                }
                Context.Items["wpkind"] = e.CommandArgument.ToString();
                Server.Transfer("EditZcDB.aspx", false);
            }
        }
    }


    //控制【抵押物】和【质押物】的编辑和修改
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("butDel") != null)
        {
            if (Request["id"] != null)
            {
                string zcid = Request["id"].ToString();
                U_ZCBU zc1 = new U_ZCBU();
                string user1 = zc1.GetZerenByZCID(zcid);
                LinkButton but1 = e.Item.FindControl("butDel") as LinkButton;
                LinkButton but2 = e.Item.FindControl("butEdit") as LinkButton;
                if (user1!=User.Identity.Name )
                {
                    but1.Visible = false;
                    but2.Visible = false;
                }
            }
        }
    }

    #endregion
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Context.Items["zcid"] = Request["id"].ToString();
        }
        Context.Items["wpkind"] = "0";
        Server.Transfer("EditZcDB.aspx", false);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Context.Items["zcid"] = Request["id"].ToString();
        }
        Context.Items["wpkind"] = "1";
        Server.Transfer("EditZcDB.aspx", false);
    }
}
