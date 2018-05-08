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
using System.Drawing;
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class ZcMng2_Zcspldyjb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Bind();
        }
    }
    private void Bind()
    {
        if (Request["czid"] != null&&Request["pc"]!=null)
        {
            string czid = Request["czid"].ToString();
            string pc = Request["pc"].ToString();
            U_ZCSPBU sp1 = new U_ZCSPBU();
            DataSet ds1 = sp1.GetZcSPListByPC(czid, pc);
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();
            sp1.Close();

            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds2 = zc1.GetShenBaoInfo(Request["czid"]);
            zc1.Close();


            this.lab1.Text = ds2.Tables[0].Rows[0]["xmsbh"].ToString();
            this.lab2.Text = ds2.Tables[0].Rows[0]["num2"].ToString();
            this.lab3.Text = ds2.Tables[0].Rows[0]["danwei"].ToString();
        }
    }
}
