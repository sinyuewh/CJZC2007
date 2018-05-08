<%@ page language="C#" autoeventwireup="true" inherits="AutoMessage, App_Web_k7qlrvw3" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>短消息刷页面刷新功能</title>
     <meta http-equiv="refresh" content="180;url=AutoMessage.aspx">
     <script language="javascript">
        function checkNewMessage()
        {
            var item1=document.getElementById("TextBox1");
            if(parseInt(item1.value)!=0)
            {
                 var str1="<%#Application["root"] %>/ShowMessage.aspx";
                 window.open(str1,"","left=200,top=150,width=600,height=400");
            }
        }
     </script>
</head>
<body onload="javaScript:checkNewMessage();">
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Text="0"></asp:TextBox>
    </div>
    </form>
</body>
</html>
