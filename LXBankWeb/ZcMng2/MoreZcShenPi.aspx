<%@ Page Language="C#" AutoEventWireup="true" Title="显示更多的资产项目审批表" CodeFile="MoreZcShenPi.aspx.cs"
    StylesheetTheme="" Inherits="ZcMng2_MoreZcShenPi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        a.blue:link
        {
            color: #0000ff;
            text-decoration: underline;
        }
        a.blue:active
        {
            color: #0000ff;
            text-decoration: none;
        }
        a.blue:visited
        {
            color: #0000ff;
            text-decoration: none;
        }
        a.blue:hover
        {
            color: #ff0000;
            text-decoration: underline;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="95%" align="center">
            <asp:Repeater ID="repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a target="_blank" class="blue" href='<%#Application["root"]%>/ZcMng3/EditSbb.aspx?id=<%#Eval("id")%>'>
                                <%#Container.ItemIndex+1 %>.<%#Eval("xmmc")%>（<%#Eval("xmsbh")%>）</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
