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

public partial class DangAn_EditPrintInfo : System.Web.UI.Page
{
    string[] arr0 = new string[] { "bill", "billtime", "billmen", "zeren", "remark" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetControlData();
            this.BindFiles(null);
        }
    }
    private void SetControlData()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"];
            DA_CopyBU print1 = new DA_CopyBU();
            DataSet ds = print1.GetDetailByID(id);
            print1.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < arr0.Length; i++)
                {
                    Util.SetControlValue(this.bill.Parent.FindControl(arr0[i]), ds.Tables[0].Rows[0][arr0[i]]);
                }

                this.billtime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["billtime"].ToString()).ToString("yyyy-MM-dd");
            }
            ds.Dispose();
        }
    }
    private void BindFiles(DA_CopyBU print)
    {
        bool flag = false;
        if (print == null)
        {
            print = new DA_CopyBU();
            flag = true;
        }
        DA_CopyBU print1 = new DA_CopyBU();
        DataSet ds1 = print1.GetFileList(this.bill.Text.ToString());
        Repeater1.DataSource = ds1;
        Repeater1.DataBind();
        if (flag)
        {
            print1.Close();
        }
    }
    //确定--更新复印单信息
    protected void Button2_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        foreach (string item in arr0)
        {
            ht[item] = Util.GetControlValue(this.bill.Parent.FindControl(item));
        }
        ht.Remove("bill");
        ht.Remove("billtime");
        ht.Remove("billmen");
        ht.Remove("zeren");
        bool check = true;
        if (check)
        {
            try
            {
                DA_CopyBU print3 = new DA_CopyBU();
                print3.UpdateCopyData(Request["id"], ht);
                Util.alert(this.Page, "操作提示:更新资料成功!");
            }
            catch
            {
                Util.alert(this.Page, "错误提示：更新资产数据失败!");
            }
        }
    }
    //返回复印单列表页面
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Print.aspx");
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("seldoc") != null)
        {
            string id = ((Label)e.Item.FindControl("seldoc")).Text;
            if (e.CommandName == "delete")
            {
                try
                {
                    DA_CopyBU copy1 = new DA_CopyBU();
                    copy1.DeleteFile(id);
                    this.BindFiles(copy1);
                    copy1.Close();
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
    //添加复印文件
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCopyFile.aspx?bill="+this.bill.Text.ToString());
    }
}
