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

using JSJ.SysFrame.DB;
using System.Collections.Generic;


public partial class Common_Master_Info : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            U_RolesBU role1 = new U_RolesBU();
            bool check1 = role1.isRole("系统管理员");
            role1.Close();
            if (check1 == false)
            {
                this.ZX_menu1.Visible = false;
                this.ZX_menu0.Visible = false;
            }

            //判断是否只为法律顾问角色
            if (this.isOnlyLaw())
            {
                this.ZX_menu2.Visible = false;
            }
            else
            {
                this.ZX_menu2.Visible = true;
            }
        }
    }


    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }


    //判断当前用户是否只有法律顾问
    private bool isOnlyLaw()
    {
        bool result = false;
        CommTable tab1 = new CommTable("U_RoleUsers");
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("sname", Page.User.Identity.Name));
        DataSet ds1 = tab1.SearchData("role", list1);
        string temp1 = String.Empty;
        bool first = true;
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            if (dr1[0].ToString().Trim() != String.Empty)
            {
                if (first)
                {
                    temp1 = dr1[0].ToString().Trim();
                    first = false;
                }
                else
                {
                    temp1 = temp1 + "," + dr1[0].ToString().Trim();
                }
            }
        }
        tab1.Close();

        if (temp1 == "法律顾问")
        {
            result = true;
        }
        return result;
    }
}
