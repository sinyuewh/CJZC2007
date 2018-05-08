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
using System.IO;

public partial class Info_InsertInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //insert data
    protected void btn1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "title", "remark", "kind", "time0" };
        for (int i = 0; i < arr1.Length - 1; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.title.Parent.FindControl(arr1[i])));
        }
        ht.Add(arr1[3], DateTime.Now.ToString());
        ht["remark"] = this.remark.Text;
        
        if (ht["title"].ToString().Trim() == "" || ht["remark"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示：请输入标题或正文");
        }
        else
        {
            for (int i = 1; i <= 5; i++)
            {
                FileUpload f = this.title.Parent.FindControl("file" + i) as FileUpload;
                if (f != null && f.FileName != null && f.FileName != String.Empty)
                {
                    String fname = Path.GetFileNameWithoutExtension(f.FileName);
                    String Rnd = JSJ.CJZC.Business.Comm.GetMD5String(Util.GetRandomString(10));
                    String exd = Path.GetExtension(f.FileName);
                    ht["file" + i] = fname + Rnd + exd;
                    f.SaveAs(Server.MapPath(Application["root"] + "/Common/MailFiles/" + ht["file" + i].ToString()));
                }
            }
            
            ZX_InfoBU info1 = new ZX_InfoBU();
            bool result = info1.InsertData(ht);
            info1.Close();
            if (result)
            {
                Response.Redirect("InfoMaintenance.aspx", true);
            }
            else
            {
                Util.alert(this.Page, "错误提示：新信息插入失败");
            }
        }
    }
    //return
    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoMaintenance.aspx", true);
    }
}
