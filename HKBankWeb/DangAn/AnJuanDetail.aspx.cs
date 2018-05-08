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

public partial class DangAn_AnJuanDetail : System.Web.UI.Page
{
    string[] arr0 = new string[] { "ajnum", "ajname",  "ljren","ajkind", "ajstatus",  "yjdanwei","jsren", "remark","depart","zeren" };
    string[] arr1 = new string[] { "id", "ajnum", "ajname", "time0", "ljren",
                                   "ajkind", "remark", "ajstatus", "yjtime", "yjdanwei", "jsren" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.SetControlData();
            this.BindFiles(null);
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

                if (ds.Tables[0].Rows[0]["time0"] != DBNull.Value)
                {
                    this.time0.Text = DateTime.Parse(ds.Tables[0].Rows[0]["time0"].ToString()).ToString("yyyy-MM-dd");
                }

                if (ds.Tables[0].Rows[0]["yjtime"]!=DBNull.Value)
                {
                  this.yjtime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["yjtime"].ToString()).ToString("yyyy-MM-dd");
                }

                if (ds.Tables[0].Rows[0]["ajstatus"].ToString() == "2")
                {
                    this.ajstatus.Text = "已移交";
                }
                else
                {
                    this.ajstatus.Text = "";
                }
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
        //this.depart.Text = ds1.Tables[0].Rows[0]["depart"].ToString();
        //this.zeren.Text = ds1.Tables[0].Rows[0]["zeren"].ToString();
        if (flag)
        {
            file.Close();
        }
    }


    //删除Repeater里面一条数据
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = ((Label)e.Item.FindControl("seldoc")).Text;
           
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
                Server.Transfer("AnJuanDetail.aspx?id=" + id, false);
            }
      } 
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("LinkbutDel") != null)
        {
            LinkButton but1 = e.Item.FindControl("LinkbutEdit") as LinkButton;
            LinkButton but2=e.Item.FindControl("LinkbutDel") as LinkButton;
        }
    }
    
    
}
