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

public partial class Common_Controls_MainLeft : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // hide menu
            U_RolesBU role1 = new U_RolesBU();
            bool check1 = role1.isRole("系统管理员");
           

            //系统管理员权限部分
            if (check1 == false)
            {
                this.ZC_SYS1.Visible = false;
                this.ZC_SYS2.Visible = false;
                this.ZC_SYS3.Visible = false;
                this.ZC_SYS4.Visible = false;
                this.ZC_SYS5.Visible = false;
                this.ZC_SYS6.Visible = false;
                this.ZC_SYS7.Visible = false;
            }

            //公司领导权限部分
            check1 = role1.isRole(new String[]{"公司领导","综合管理"});
            if (check1 == false)
            {
                this.ZC_LEADER1.Visible = false;
                this.ZC_LEADER2.Visible = false;
                this.ZC_LEADER3.Visible = false;
            }

            //部门领导权限部分
            check1 = role1.isRole("资产部门领导");
            if (check1 == false)
            {
                this.ZC_Depart1.Visible = false;
                this.ZC_Depart2.Visible = false;
            }

            check1 = role1.isRole("资产清收人员");
            if (check1)
            {
                this.ZC_GR1.Visible = true;
                this.ZC_GR1_1.Visible = true;

                this.ZC_GR2.Visible = true;
                this.ZC_GR2_1.Visible = true;

                this.ZC_GR3.Visible = true;
                this.ZC_GR4.Visible = true;
                this.ZC_GR5.Visible = true;

                this.ZC_SP1.Visible = false;
                this.ZC_SP2.Visible = false;
                this.ZC_SP3.Visible = false;
                this.ZC_SP4.Visible = false;
            }
            else
            {
                this.ZC_GR1.Visible = false;
                this.ZC_GR1_1.Visible = false;
                this.ZC_GR2.Visible = false;
                this.ZC_GR2_1.Visible = false;

                this.ZC_GR3.Visible = false;
                this.ZC_GR4.Visible = false;
                this.ZC_GR5.Visible = false;

                //this.ZC_SP1.Visible = true;
                //this.ZC_SP2.Visible = true;
                //this.ZC_SP3.Visible = true;
                //this.ZC_SP4.Visible = true;
            }

            //增加法律顾问专栏
            check1 = role1.isRole("法律顾问");
            if (check1)
            {
                this.ZC_LAW1.Visible = true;
                this.ZC_LAW2.Visible = true;
            }
            else
            {
                this.ZC_LAW1.Visible = false;
                this.ZC_LAW2.Visible = false;
            }
            role1.Close();
        }
    }
}
