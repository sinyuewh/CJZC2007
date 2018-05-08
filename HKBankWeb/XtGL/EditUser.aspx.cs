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

public partial class XtGL_EditUser : System.Web.UI.Page
{
    string[] arr1 = new string[] { "num", "sname", "depart", "job", "cell","phone", "email","leader" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.leader.Attributes["ReadOnly"] = "";
            if (Request["id"] != null)
            {
                U_DepartBU depart1 = new U_DepartBU();
                depart1.SetDepartList(this.depart, null);
                U_UserNameBU user1 = new U_UserNameBU();
                Hashtable ht = user1.GetDetailByID(Request["id"]);
                user1.Close();
                if (ht!=null && ht.Count > 0)
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        if (ht[arr1[i]] == null)
                        {
                            ht[arr1[i]] = "";
                        }
                        Util.SetControlValue(this.sname.Parent.FindControl(arr1[i]),ht[arr1[i]]);
                    }
                }
                else
                {
                    Response.Redirect("~/Error.aspx?info=错误信息：此用户不存在！", true);
                }
            }
            else
            {
                Response.Redirect("~/Error.aspx", true);
            }


            if (this.sname.Text != String.Empty)
            {
                U_UserNameBU user1 = new U_UserNameBU();
                this.leader1.Text = user1.GetOtherReader(this.sname.Text.Trim());
            }
        }
    }

    //return
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserMng.aspx", true);
    }

    //submit data
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        for (int i = 0; i < arr1.Length; i++)
        {
            ht.Add(arr1[i], Util.GetControlValue(this.depart.Parent.FindControl(arr1[i])));
        }

        U_UserNameBU user1 = new U_UserNameBU();
        bool result=user1.EditUserData(Request["id"], ht);
        user1.Close();

        //更新其他读者的数据
        user1.SetOthersReaders(this.sname.Text, this.leader1.Text);
        if (result)
        {
            Response.Redirect("UserMng.aspx", true);
        }
        else
        {
            Util.alert(this.Page, "错误提示：修改数据错误！");
        }
    }

    //reset password
    protected void Button3_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("password", "1234");
        U_UserNameBU user1 = new U_UserNameBU();
        bool result = user1.EditUserData(Request["id"], ht);
        user1.Close();
        if (result)
        {
            Comm.ShowInfo("提示：成功地重新设置登录密码为1234", Request.RawUrl);
        }
        else
        {
            Util.alert(this.Page, "提示：重新设置登录密码失败！");
        }
    }
}
