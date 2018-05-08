<%@ Application Language="C#" %>
<%@ Import Namespace="JSJ.CJZC.Business" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        Application.Lock();
        Application["root"] = System.Configuration.ConfigurationManager.AppSettings["root"];
        Application.UnLock();
        Application["OnLineUser"] = new Hashtable();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码
        Session.Timeout = 1;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
        Hashtable ht = (Hashtable)Application["OnLineUser"];
        ht.Remove(User.Identity.Name.Trim());

        //注销当前用户写入的日志
        string username = System.Web.HttpContext.Current.Session["currentusername"].ToString();
        XT_UserLogBU log1 = new XT_UserLogBU();
        log1.SignOutLogo(username);
        log1.Close();
        
    }
       
</script>
