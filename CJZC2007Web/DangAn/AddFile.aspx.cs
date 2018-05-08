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

public partial class DangAn_AddFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string ajid = Request.QueryString["ajid"];
            DA_AnJuanBU anjuan1 = new DA_AnJuanBU();
            DataSet ds = anjuan1.GetDetailByID1(ajid);
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr["ajnum"] != DBNull.Value)
            {
                this.ajnum.Text = dr["ajnum"].ToString();
            }
            anjuan1.Close();
        }
    }

    //添加案卷文件
    protected void Button1_Click(object sender, EventArgs e)
    { 
        object[] obj0 = new object[] { title,filecount,filefs };
        object[] obj1 = new object[] { title};
        string[] info = new string[] { "文件名称"};
        bool check = true;
        for (int i = 0; i < info.Length; i++)
        {
            if (Util.GetControlValue((Control)obj1[i]) == null || Util.GetControlValue((Control)obj1[i]) == "")
            {
                check = false;
                Util.alert(this.Page, "错误提示：【" + info[i] + "】栏目不能为空！");
                break;
            }
        }

        if (check)
        {
            Hashtable ht = new Hashtable();
            Util.getPageData(obj0, ht);
            ht.Add("ajnum", this.ajnum.Text);
            if (ht["filecount"].ToString()=="")
            {
                ht.Remove("filecount");
            }
            if (ht["filefs"].ToString() == "")
            {
                ht.Remove("filefs");
            }
            DA_FilesBU file1 = new DA_FilesBU();
            bool result = file1.InsertFileData(ht);

            file1.Close();
            if (result)
            {
                string url = Application["root"] + "/DangAn/AddFile.aspx?ajid=" + Request.QueryString["ajid"];
                Comm.ShowInfo("提示：添加文件成功!", url);
            }
            else
            {
                Util.alert(this.Page, "错误提示：增加数据失败，请检查数据类型！");
            }
        }
    }



    //返回到案卷
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AnJuanDetailEdit.aspx?id=" + Request.QueryString["ajid"],true);
    }
}
