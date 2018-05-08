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

public partial class XtGL_AddDepart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Add data
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        string[] Arr1 = new string[] { "num", "depart", "remark" };
        for (int i = 0; i < Arr1.Length; i++)
        {
            ht.Add(Arr1[i], Util.GetControlValue(this.num.Parent.FindControl(Arr1[i])));
        }

        if (ht["num"].ToString().Trim() == "" || ht["depart"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示：部门编号和部门名称不能为空！");
        }
        else
        {
            U_DepartBU depart1 = new U_DepartBU();
            bool result=depart1.InsertData(ht);
            depart1.Close();
            if (result)
            {
                Response.Redirect("XtGlIndex.aspx", true);
            }
            else
            {
                Util.alert(this.Page, "错误提示：部门名称【"+ht["depart"].ToString()+"】已经存在！");
            }
        }
    }

    //return 
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("XtGlIndex.aspx",true);
    }
}
