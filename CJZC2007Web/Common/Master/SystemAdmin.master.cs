﻿using System;
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

public partial class Common_Master_SystemAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
