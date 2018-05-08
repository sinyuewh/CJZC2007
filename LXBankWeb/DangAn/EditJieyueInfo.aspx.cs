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

public partial class DangAn_EditJieyueInfo : System.Web.UI.Page
{
    string[] arr0 = new string[] { "bill", "billtime", "billmen", "zeren", "paytime", "paytime1", "remark" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetControlData();
            this.BindFiles(null);
            this.paytime.Attributes["onfocus"] = "setday(this)";
            this.paytime1.Attributes["onfocus"] = "setday(this)";
        }
    }
    private void SetControlData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            DA_JieYuanBU jyue1 = new DA_JieYuanBU();
            DataSet ds = jyue1.GetDetailByID(id);
            jyue1.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < arr0.Length; i++)
                {
                    Util.SetControlValue(this.bill.Parent.FindControl(arr0[i]), ds.Tables[0].Rows[0][arr0[i]]);
                }

                if (ds.Tables[0].Rows[0]["paytime1"].ToString() == "")
                {
                    //this.paytime.Text = "";
                    this.paytime1.Text = "";
                }
                else
                {
                    this.paytime1.Text = DateTime.Parse(ds.Tables[0].Rows[0]["paytime1"].ToString()).ToString("yyyy-MM-dd");
                }
                this.paytime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["paytime"].ToString()).ToString("yyyy-MM-dd");
                this.billtime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["billtime"].ToString()).ToString("yyyy-MM-dd");
            }
            ds.Dispose();
        }
    }
    private void BindFiles(DA_JieYuanBU jyue)
    {
        bool flag = false;
        if (jyue == null)
        {
            jyue = new DA_JieYuanBU();
            flag = true;
        }
        DA_JieYuanBU jyue2 = new DA_JieYuanBU();
        DataSet ds1 = jyue2.GetFileList(this.bill.Text.ToString());
        Repeater1.DataSource = ds1;
        Repeater1.DataBind();
        if (flag)
        {
            jyue2.Close();
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("FileJieyue.aspx");
    }
    //删除Repeater里面的一条数据

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = ((Label)e.Item.FindControl("seldoc")).Text;
            if (e.CommandName == "delete")
            {
                try
                {
                    DA_JieYuanBU jyue3 = new DA_JieYuanBU();
                    jyue3.DeleteFile(id);
                    this.BindFiles(jyue3);
                    jyue3.Close();
                }
                catch (Exception err1)
                {
                    Util.alert(this.Page, err1.Message);
                }
            }
        }

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("LinkbutDel") != null)
        {
            LinkButton but1 = e.Item.FindControl("LinkbutDel") as LinkButton;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddJieyueFile.aspx?bill=" + this.bill.Text);
    }
    //
    protected void Button4_Click(object sender, EventArgs e)
    {
        Hashtable ht=new Hashtable();
        ht.Add("status","1");
        DA_JieYuanBU jyue4 = new DA_JieYuanBU();
        //修改借阅单的状态

        bool result = jyue4.ShengChengJieYuanBill(Request.QueryString["id"], ht);
        if (result)
        {
            Util.alert(this.Page, "借阅单已产生！");
            //修改案卷中文件的借阅人、借阅时间，登记人、登记时间

            DA_JieYuanBU jyue1 = new DA_JieYuanBU();
            string[] allId = jyue1.GetAllIdBybill(this.bill.Text);
            Hashtable ht1 = new Hashtable();
            ht1.Add("djtime", this.billtime.Text.Trim());
            ht1.Add("dtmen", this.billmen.Text.ToString());
            ht1.Add("jyue", this.zeren.Text.ToString());
            ht1.Add("jyuetime", this.billtime.Text.Trim());
            for (int i = 0; i < allId.Length; i++)
            {
                DA_FilesBU file1 = new DA_FilesBU();
                file1.UpdateJieyueInfo(allId[i].ToString(), ht1);
            }
            Response.Redirect("FileJieyue.aspx");
        }
    }
}
