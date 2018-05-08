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

public partial class DoAction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string info1 = "操作提示：操作成功！";
            if (Context.Items["actioninfo"] != null)
            {
                info1 = Context.Items["actioninfo"].ToString();
            }
            this.Label1.Text = info1;


            string url = "~/default.aspx";
            if (Context.Items["defaulturl"] != null)
            {
                url = Context.Items["defaulturl"].ToString();
            }
            this.HyperLink1.NavigateUrl = url;
            this.HyperLink1.Text = "[请点这里转向]";


            //是否需要自动转向
            if (Context.Items["autotrans"] !=null)
            {
                if ((bool)Context.Items["autotrans"])
                {
                    Response.AppendHeader("Refresh", "5; URL=" + url);
                }
            }
        }
    }
    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
