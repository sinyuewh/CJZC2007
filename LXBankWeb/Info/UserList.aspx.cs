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

public partial class Info_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            this.BindData();            
        }

    }
    public void BindData()
    {

        U_UserNameBU user1 = new U_UserNameBU();

        U_DepartBU depart1 = new U_DepartBU();
        DataSet ds1 = depart1.GetAllDepart();
        for (int i = 0; i <= 7; i++)
        {
            Label lab1 = this.DataList0.Parent.FindControl("Label" + i) as Label;
            if (lab1 != null && ds1.Tables[0].Rows[i]["depart"] != null && ds1.Tables[0].Rows[i]["depart"].ToString() != "")
            {
                lab1.Text = ds1.Tables[0].Rows[i]["depart"].ToString();
                DataList datalist1 = this.DataList0.Parent.FindControl("DataList" + i) as DataList;
                if (datalist1 != null)
                {
                    DataSet ds2 = user1.GetUserByDepart(lab1.Text);
                    datalist1.DataSource = ds2;
                    datalist1.DataBind();

                    if (ds1.Tables[0].Rows.Count == 0)
                    {
                        datalist1.Visible = false;
                    }
                }
            }
        }
        depart1.Close();
        user1.Close();
    }
}
