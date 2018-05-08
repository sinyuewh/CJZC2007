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

public partial class DangAn_AddCopyFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string bill = Request.QueryString["bill"];
        this.bill.Text = bill.ToString();
    }
    //添加复印文件
    protected void Button1_Click(object sender, EventArgs e)
    {
        object[] obj0 = new object[] { title, copycount };
        string[] info = new string[] { "文件名称", "复印份数" };
        bool check = true;
        for (int i = 0; i < info.Length; i++)
        {
            if (Util.GetControlValue((Control)obj0[i]) == null || Util.GetControlValue((Control)obj0[i]) == "")
            {
                check = false;
                Util.alert(this.Page, "错误提示：【" + info[i] + "】栏目不能为空！");
                break;
            }
        }
        if (check)
        {
            Hashtable ht = new Hashtable();
            ht.Add("bill", this.bill.Text);//加入复印单编号

            DA_CopyBU copy1 = new DA_CopyBU();
            DA_JieYuanBU jyue1 = new DA_JieYuanBU();
            
            //通过文号获取文件ID
            string fileId = copy1.GetFileIdByTitle(this.title.Text.ToString().Trim());
            if (fileId == null)
            {
                Util.alert(this.Page, "文件【" + this.title.Text.ToString() + "】不存在！");
            }
            else
            {
                //判断文件是否已经被借阅
                DA_FilesBU file1 = new DA_FilesBU();
                bool jyuestatus = file1.IsOrNotJieYue(fileId);
                if (jyuestatus)//
                {
                    ht.Add("fileid", fileId);
                    ht.Add("copycount", this.copycount.Text.ToString());
                    bool result = copy1.AddCopyFileData(ht);
                    string id = copy1.GetIdBybill(this.bill.Text.ToString());
                    copy1.Close();
                    if (result)
                    {
                        Util.alert(this.Page, "新增文件成功！");
                        Response.Redirect("AddCopyFile.aspx?bill=" + this.bill.Text.Trim());
                    }
                    else
                    {
                        Util.alert(this.Page, "错误提示：本复印单已存在此文件！");
                    }
                }
                else
                {
                    Util.alert(this.Page, "错误提示：此文件被借阅,不能复印!");
                }
            }
            
        }
    }
    //完成
    protected void Button2_Click(object sender, EventArgs e)
    {
        DA_CopyBU copy2=new DA_CopyBU();
        string id=copy2.GetIdBybill(this.bill.Text.ToString());
        Response.Redirect("EditPrintInfo.aspx?id=" + id);
    }
}
