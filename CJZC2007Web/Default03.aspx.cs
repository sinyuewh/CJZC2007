using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Default0 : System.Web.UI.Page
{
    public String HankBankUrl
    {
        get
        {
            String url1 = ConfigurationManager.AppSettings["hkbankurl"];
            url1 = url1 + Server.UrlEncode(Page.User.Identity.Name);
            return url1;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
