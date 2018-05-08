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

public partial class Common_Controls_Header : System.Web.UI.UserControl
{
    public bool IsShowTitle
    {
        get
        {
            bool temp = true;
            if (ViewState["IsShowTitle"] != null)
            {
                temp = (bool)ViewState["IsShowTitle"];
            }
            return temp;
        }
        set
        {
            ViewState["IsShowTitle"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            this.SetMenu();

            if (this.IsShowTitle == false)
            {
                this.info1.Visible = false;
            }
        }
    }
    
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
    //调整系统菜单
    private void SetMenu()
    {
        string currentuser = Page.User.Identity.Name;
        U_RolesBU role1 = new U_RolesBU();
        if (!role1.isRole("系统管理员"))
        {
            this.SYS_Menu1.Visible = false;
            this.SYS_Menu2.Visible = false;
        }
        if (role1.isRole("公司领导") == false 
            && role1.isRole("财务数据浏览") == false 
            && role1.isRole("会计") == false 
            && role1.isRole("出纳") == false)
        {
            this.CWZX1.Visible = false;
            this.CWZX2.Visible = false;
        }
        if (role1.isRole("公司领导") == false)
        {
            this.JCZC1.Visible = false;
            this.JCZC2.Visible = false;
        }
        role1.Close();


        //设置法律顾问的权限
        if (this.isOnlyLaw())
        {
            this.tabInfo1.Visible = false;
            this.tabInfo2.Visible = true;
        }
        else
        {
            this.tabInfo1.Visible = true;
            this.tabInfo2.Visible = false ;
        }
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
