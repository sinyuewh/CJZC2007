<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartReminder.aspx.cs" Inherits="StartReminder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录提示</title>
<script language="javascript" src="<%#Application["root"] %>/Common/Script/calendar.js">
</script>
 <script language="javascript" src="<%#Application["root"] %>/Common/Script/Common.js"></script>
    <script language="javascript" type="text/javascript">
 function WinOpenZCTime()
 {
    var url="./ZcMng1/MyZcTime0.aspx";
      
    window.open(url);
 }
 function WinOpenReceiveMai()
 {
    var url="./Info/ReceiveMail.aspx";
      
    window.open(url);
 }
 function WinOpenInfoBrowse()
 {
    var url="./Info/InfoBrowse.aspx";
      
    window.open(url);
 }
    </script>

</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <br />
            <br />
            <span style="font-size: 12pt">您有<a class="blue2" href="javaScript:WinOpenZCTime();"><asp:Label
                ID="MyTime" runat="server" ForeColor="Red" Text="0"></asp:Label></a>个时效警告数据，请查阅！<br />
            </span>
            <br />
            <span style="font-size: 12pt">你有<a class="blue2" href="javaScript:WinOpenReceiveMai();"><asp:Label ID="newmail" runat="server" Text="0" ForeColor="Red"></asp:Label></a>封新邮件，请查阅！
            </span>
            <br />
            <br />
            <span style="font-size: 12pt">今天有<a class="blue2" href="javaScript:WinOpenInfoBrowse();"><asp:Label ID="newinfo" runat="server" Text="0"
                ForeColor="Red"></asp:Label></a>个最新信息，请查阅！ </span>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="我已知道谢谢！" OnClick="Button1_Click" /><%--&nbsp;&nbsp;<asp:CheckBox
                ID="CheckBox1" runat="server" />今天不要再提示--%>
        </div>
    </form>
</body>
</html>
