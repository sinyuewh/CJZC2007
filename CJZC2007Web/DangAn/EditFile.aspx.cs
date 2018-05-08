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

public partial class DangAn_EditFile : System.Web.UI.Page
{
    String[] arr1 = new string[] { "ajnum", "fileno", "title","filefs", "filecount" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.SetControlData();
        }
    }


    //设置页面控件的值
    private void SetControlData()
    {
        if (Request.QueryString["fileID"] != null)
        {
            string id = Request["fileID"];
            DA_FilesBU file1 = new DA_FilesBU();
            DataSet ds1 = file1.GetFileDetailByID(id);
            file1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                { 
                    Util.SetControlValue(this.ajnum.Parent.FindControl(arr1[i]),ds1.Tables[0].Rows[0][arr1[i]]);
                }
            }
            ds1.Dispose();
        }
    }

    //更新文件资料
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        foreach (string item in arr1)
        {
            ht[item] = Util.GetControlValue(this.ajnum.Parent.FindControl(item));
        }
        ht.Remove("ajnum");
        DA_FilesBU file2 = new DA_FilesBU();
        file2.UpdateFileData(Request["fileID"], ht);
        file2.Close();

        DA_AnJuanBU anjuan1 = new DA_AnJuanBU();
        string id = anjuan1.GetIdByAjnum(this.ajnum.Text);
        anjuan1.Close();

        string url = Application["root"] + "/DangAn/AnJuanDetailEdit.aspx?id=" + id;
        Comm.ShowInfo("操作提示:更新文件成功!", url);
    }


    //返回案卷信息
    protected void Button2_Click(object sender, EventArgs e)
    {
        DA_AnJuanBU anjuan1 = new DA_AnJuanBU();
        string id = anjuan1.GetIdByAjnum(this.ajnum.Text);
        Response.Redirect("AnJuanDetailEdit.aspx?id=" + id);
        anjuan1.Close();
    }
}
