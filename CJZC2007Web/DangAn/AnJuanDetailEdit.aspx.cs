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

public partial class DangAn_AnJuanDetailEdit : System.Web.UI.Page
{
    string[] arr0 = new string[] { "ajnum", "ajname", "time0", "ljren", "ajkind", "ajstatus",  "yjdanwei", "jsren", "remark","remark1","depart","zeren" };
    string[] arr1 = new string[] { "id", "ajnum", "ajname", "time0", "ljren",
                                   "ajkind", "remark", "ajstatus", "yjtime", "yjdanwei", "jsren","remark1" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            U_ItemBU item1 = new U_ItemBU();
            item1.ItemName = "案卷类别";
            item1.SetLiteralControl(this.ajkind, "--请选择--");
            item1.Close();

            this.SetControlData();
            this.BindFiles(null);

            this.time0.Attributes["onfocus"] = "setday(this)";
            
        }
    }
   
    private void SetControlData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];

            DA_AnJuanBU aj2 = new DA_AnJuanBU();
            DataSet ds = aj2.GetDetailByID1(id);
            aj2.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr0.Length; i++)
                {
                    Util.SetControlValue(this.ajnum.Parent.FindControl(arr0[i]), ds.Tables[0].Rows[0][arr0[i]]);
                }

                if (ds.Tables[0].Rows[0]["yjtime"]!=DBNull.Value)
                {
                   this.yjtime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["yjtime"].ToString()).ToString("yyyy-MM-dd");
                }

                if( ds.Tables[0].Rows[0]["time0"]!=DBNull.Value) 
                {
                    this.time0.Text = DateTime.Parse(ds.Tables[0].Rows[0]["time0"].ToString()).ToString("yyyy-MM-dd");
                }

                if (ds.Tables[0].Rows[0]["yjdanwei"] != DBNull.Value && ds.Tables[0].Rows[0]["yjdanwei"].ToString().Trim()!="")
                {
                    this.ajstatus.Text = "已移交";
                    this.Button2.Visible = false;
                }
                else
                {
                    this.ajstatus.Text = "";
                }

                U_ZCBU zc1 = new U_ZCBU();
                DataSet ds1 = zc1.GetDepartAndZeren(this.ajname.Text);
                zc1.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    this.depart.Text = ds1.Tables[0].Rows[0]["depart"].ToString();
                    this.zeren.Text = ds1.Tables[0].Rows[0]["zeren"].ToString();
                }
                ds1.Dispose();
            }

            ds.Dispose();
          
        }
    }
    private void BindFiles(DA_FilesBU file)
    {
        bool flag = false;
        if (file == null)
        {
            file = new DA_FilesBU();
            flag = true;
        }
        DA_FilesBU file1 = new DA_FilesBU();
        DataSet ds1 = file1.GetFileList(this.ajnum.Text.ToString());
        Repeater1.DataSource = ds1;
        Repeater1.DataBind();
        if (flag)
        {
            file.Close();
        }
    }




    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = ((Label)e.Item.FindControl("seldoc")).Text;
            //string id=Request.QueryString[""]
            if (e.CommandName == "delete")
            {
                try
                {
                    DA_FilesBU file2 = new DA_FilesBU();
                    file2.DelteFile(id);
                    this.BindFiles(file2);
                    file2.Close();
                }
                catch (Exception err1)
                {
                    Util.alert(this.Page, err1.Message);
                }
            }
            else
            {
                Context.Items["id"] = id;
                Server.Transfer("AnJuanDetailEdit.aspx?id=" + id, false);
            }
        }
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("LinkbutDel") != null)
        {
            LinkButton but1 = e.Item.FindControl("LinkbutEdit") as LinkButton;
            LinkButton but2 = e.Item.FindControl("LinkbutDel") as LinkButton;
        }
    }


    //更新案卷信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        foreach (string item in arr0)
        {
            ht[item] = Util.GetControlValue(this.ajnum.Parent.FindControl(item));
        }

        bool check = true;
        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////
        if (check)
        {
            try
            {
                DA_AnJuanBU anjuan1 = new DA_AnJuanBU();
                anjuan1.UpdateAnJuanData(Request["id"], ht);
                anjuan1.Close();
                string url1=Application["root"] + "/DangAn/AnJuanWeiHu.aspx";
                Comm.ShowInfo("操作提示:更新资料成功!",Request.RawUrl);
            }
            catch
            {
                Util.alert(this.Page, "错误提示：更新案卷数据失败，可能的原因是数据类型有错误!");
            }
        }
    }


    //增加案卷文件
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddFile.aspx?ajid="+Request.QueryString["id"]);
    }


    //返回案卷维护查询
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("AnJuanWeiHu.aspx", true);
    }


    //移交案卷
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("AnJuanMove.aspx?id=" + Request.QueryString["id"], true);
    }
}
