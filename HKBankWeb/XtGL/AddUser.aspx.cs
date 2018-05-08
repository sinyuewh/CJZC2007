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

public partial class XtGL_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_DepartBU depart1 = new U_DepartBU();
            depart1.SetDepartList(this.depart, "请选择...");
            depart1.Close();
        }
    }

    //提交数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] {"num","sname","depart","job","cell","email","leader" };
        for (int i = 0; i < arr1.Length; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.depart.Parent.FindControl(arr1[i])));
        }
        ht.Add("password", "1234");
        ht.Add("login", DateTime.Now.ToString());

        if(ht["sname"].ToString().Trim()=="" || ht["depart"].ToString().Trim()=="")
        {
            Util.alert(this.Page, "错误提示：【用户姓名】和【所在部门】栏目不能为空！");
        }
        else
        {
            U_UserNameBU user1 = new U_UserNameBU();
            bool result=user1.InsertData(ht);
            user1.Close();
            if (result)
            {
                Response.Redirect("UserMng.aspx", true);
            }
            else
            {
                Util.alert(this.Page,"错误提示：插入数据失败，可能的原因是【"+ht["sname"].ToString()+"】已经存在！");
            }
        }
    }

    //返回到用户列表
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserMng.aspx", true);
    }
}
