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

public partial class Common_Controls_ZcSP : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //判断用户是否有部门资产
            if (JSJ.CJZC.Business.Comm.HaveBuZC() == false)
            {
                this.AddRow.Visible = false;
                this.SPList1.Visible = false;
                this.SPList2.Visible = false;

                if (Request.RawUrl.ToLower().IndexOf("fangan1.aspx") > 0 || Request.RawUrl.ToLower().IndexOf("fangan2.aspx") > 0)
                {
                    Response.Redirect("fangan3.aspx", true);
                }
            }
            else
            {
                //表示用户没有直接负责的资产
                if (JSJ.CJZC.Business.Comm.HaveZC() == false)
                {
                    this.AddRow.Visible = false;
                    this.SPList1.Visible = false;

                    if (Request.RawUrl.ToLower().IndexOf("fangan1.aspx") > 0)
                    {
                        Response.Redirect("fangan2.aspx", true);
                    }
                }
            }


            U_RolesBU role1 = new U_RolesBU();
            bool isAllCanSee = role1.isRole(new string[] { "公司领导", "综合管理", "会计", "出纳", "领导秘书" });
            if (isAllCanSee == false)
            {
                this.SPList3.Visible = false;
                this.Tr3.Visible = false;
                this.Tr5.Visible = false;
            }

            bool isLeaderMiShu = role1.isRole("领导秘书");
            if(isLeaderMiShu==false)
            {
                this.LeaderMiShu.Visible = false;
            }

            if (this.SPList1.Visible == false && this.SPList2.Visible == false && this.SPList3.Visible == false)
            {
                this.HR1.Visible = false;
                if (Request.RawUrl.ToLower().IndexOf("fangan3.aspx") > 0)
                {
                    Response.Redirect("fangan4.aspx", true);
                }

            }

            role1.Close();

            //增加法律顾问的权限设置
            if (LawBU.isOnlyLaw())
            {
                this.tabNavigator.Visible = false;
            }
        }
    }

}
