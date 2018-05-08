<%@ page language="C#" autoeventwireup="true" inherits="OnLineUser, App_Web_ueve7moi" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线用户列表</title>
    <base target="_self">
    </base>

    <script language="javascript">
        //发送邮件
        function SendMail(sname1)
        {
            var str1="<%#Application["root"] %>/Info/WriteMail.aspx?tousers="+escape(sname1);
            window.opener.location.href=str1;
            //window.close();
        }
        
        //发送短消息
        function SendMessage(sname1)
        {
            var str1="<%#Application["root"] %>/Info/WriteMessage.aspx?tousers="+escape(sname1);
            window.open(str1,"","top=100,left=100,width=500,height=200");
        }
        
        
        //检查信息
        function CheckInfo()
        {           
            //检查最新的信息
            /*
            var item1=document.getElementById("NewMessageCount");
            if(parseInt(item1.value)!=0)
            {
                 var str1="<%#Application["root"] %>/ShowMessage.aspx";
                 window.open(str1,"","left=200,top=150,width=600,height=400");
            }
            
            //检查最新的邮件
            var email1=document.forms[0].NewEmailID.value;
            if(email1!="" )
            {
                window.showModalDialog('<%#Application["root"] %>/NewEmail.aspx?EmailID='+email1,"","dialogWidth:400px;dialogHeight:300px;center:yes;status:no");
            }*/
        }
    </script>

</head>
<body style="background: #ffffff" onload="javaScript:CheckInfo();">
    <form id="form1" runat="server">
        <table>
            <tr>
                <td height="5">
                </td>
            </tr>
        </table>
        <!--绑定部门和人员-->
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_DataBound">
            <ItemTemplate>
                <table width="90%" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="labDepart" runat="server" Text='<%#Eval("depart")%>' Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table width="95%" align="right" border="0" cellpadding="0" cellspacing="0">
                                <asp:DataList ID="DataListForPerson" runat="server" RepeatColumns="1" RepeatDirection="vertical"
                                    Width="99%">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Common/Image/image2008/1.gif" />
                                                <asp:Label ID="Label1" runat="server"><%#Container.DataItem %></asp:Label>
                                                <span id="info1" runat="server"><a href="javascript:SendMessage('<%#Container.DataItem %>');">
                                                    短消息</a> </span><a href="javascript:SendMail('<%#Container.DataItem %>');">邮件</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:DataList>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <table>
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
            </SeparatorTemplate>
        </asp:Repeater>
        <!--检查邮件和短消息的提醒功能-->
        <div style="display: none;">
            <asp:TextBox ID="NewMessageCount" runat="server" Text="0"></asp:TextBox>
            <input id="NewEmailID" type="hidden" runat="server" />
        </div>
        <iframe src="<%#Application["root"] %>/AutoFresh.aspx" width="0" height="0"></iframe>
        <iframe src="<%#Application["root"] %>/AutoMessage.aspx" width="0" height="0"></iframe>
    </form>
</body>
</html>
