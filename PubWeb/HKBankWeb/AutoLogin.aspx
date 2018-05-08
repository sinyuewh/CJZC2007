<%@ Page Language="C#" %>
<script runat ="server">
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String userName = Request.QueryString["userName"];          
            //FormsAuthentication.SetAuthCookie(userName, false);

            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, userName,
               DateTime.Now, DateTime.Today.AddDays(1), true, userName, "/");

            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串
            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);
            Response.Cookies.Add(UserCookie); //输出Cookie
            

            String returnUrl = Request.QueryString["ReturnUrl"];
            if (String.IsNullOrEmpty(returnUrl) == false)
            {
                String root1 = System.Configuration.ConfigurationManager.AppSettings["root"];
                Response.Redirect(root1+returnUrl, true);
            }
            else
            {
                Response.Redirect("default1.aspx", true);
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
