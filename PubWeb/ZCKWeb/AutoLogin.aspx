﻿<%@ Page Language="C#" %>
<script runat ="server">
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String userName = Request.QueryString["userName"];
            FormsAuthentication.SetAuthCookie(userName, false);

            
            
            String returnUrl = Request.QueryString["ReturnUrl"];
            if (String.IsNullOrEmpty(returnUrl) == false)
            {
                returnUrl = Server.UrlEncode(returnUrl);
                Response.Redirect(returnUrl, true);
            }
            else
            {
                Response.Redirect("default.aspx", true);
            }
        }
        base.OnLoad(e);
    }
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
