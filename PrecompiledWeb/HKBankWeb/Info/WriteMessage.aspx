<%@ page language="C#" autoeventwireup="true" inherits="Info_WriteMessage, App_Web_2t7cinkt" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发送短消息</title>
    <script language="javascript">
        function checkValue()
        {
            var remark1=document.getElementById("remark");
            if(remark1.value=="")
            {
                alert("请输入短消息的内容！");
                remark1.focus();
                return false;
            }
            
            if(remark1.value.length>50)
            {
                alert("短消息的内容请控制50个字以内！");
                remark1.focus();
                return false;
            }
            
            return true;
        }
    </script>
</head>
<body style="background-color:White">
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="95%" align="center" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5" border="0">
            <tr bgcolor="white" style="display:none;">
                <td width="30%" height="30" align="right"><b>收件人</b></td>
                <td>
                    <asp:TextBox ID="to1" runat="server"  Width="90%"></asp:TextBox></td>
            </tr>
            <tr bgcolor="white">
                <td height="30" align="right" width="30%"><b>短信息(50字内)</b></td>
                <td>
                    <asp:TextBox ID="remark" runat="server" TextMode="multiLine" Height="120px" Width="90%" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="white" align="center" height="30">
                    <asp:Button ID="Button1" runat="server" Text="发送消息" OnClick="Button1_Click" OnClientClick="javaScript:return checkValue();" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
