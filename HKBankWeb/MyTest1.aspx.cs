using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class MyTest1 : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Button1.Click += new EventHandler(Button1_Click);
        base.OnInit(e);
    }

    void Button1_Click(object sender, EventArgs e)
    {
        JSJ.CJZC.Business.ZcspBU bu1=new JSJ.CJZC.Business.ZcspBU();
        DataRow dr1=bu1.GetShenPiInfo("spstatus,spresult,status1,status2 ", "417", "1");

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
