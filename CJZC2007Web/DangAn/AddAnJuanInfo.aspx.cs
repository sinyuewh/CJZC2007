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

public partial class DangAn_AddAnJuanInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_ItemBU item1 = new U_ItemBU();
            item1.ItemName = "案卷类别";
            item1.SetLiteralControl(this.ajkind, "--请选择--");
            this.ajkind.SelectedValue = "";
            this.time0.Attributes["onfocus"] = "setday(this)";
            this.time0.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.ljren.Text = User.Identity.Name;
        }
    }
    //新增案卷
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            object[] obj1 = new object[] { ajnum, ajname, ajkind, time0, ljren };
            string[] info = new string[] { "案卷编号", "案卷名称", "案卷类型", "立卷时间", "立卷人" };

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
                try
                {
                    Hashtable ht = new Hashtable();
                    Util.getPageData(obj1, ht);

                    DA_AnJuanBU anjuan2 = new DA_AnJuanBU();
                    anjuan2.TabCommand.InsertData(ht);

                    anjuan2.Close();
                    string url = Request.RawUrl;
                    Comm.ShowInfo("增加新案卷成功！", url, true);
                }
                catch
                {
                    Util.alert(this.Page, "错误提示：增加案卷数据失败，可能的原因是数据类型有错误，请检查后重新输入！");
                }
            }
        }
    }
    
}
