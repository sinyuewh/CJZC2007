<%@ page language="C#" autoeventwireup="true" inherits="ReadData, App_Web_ueve7moi" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align=center>
        <br />
       <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="读取数据" />
        &nbsp; &nbsp;<input id="Button2" class="but" type="button" value="启动Excel打印" />&nbsp;
    </div>
    </form>
</body>
</html>
