<%@ page language="C#" autoeventwireup="true" inherits="AutoFresh, App_Web_wg1zrq8e" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="refresh" content="900;url=AutoFresh.aspx"> 
    <script language="javascript">
        //新邮件提醒功能
        function ShowEmailReminder()
        {
            var url1=top.location.href;
            url1=url1.toLowerCase();
            var pos1=url1.indexOf("<%#Application["root"]%>/zcmng1/myzc.aspx");
            var email1=document.forms[0].NewEmailID.value;
            if(email1!="" && pos1<0 )
            {
                window.showModalDialog("NewEmail.aspx?EmailID="+email1,"","dialogWidth:400px;dialogHeight:300px;center:yes;status:no");
            }
            
        }
    </script>
</head>
<body onload="javascript:ShowEmailReminder();">
    <form id="form1" runat="server">
    <div>
        <input id="NewEmailID" type="hidden" runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" Text="0"></asp:TextBox>
    </div>
    </form>
</body>
</html>
