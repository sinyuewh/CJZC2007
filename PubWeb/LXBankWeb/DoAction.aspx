<%@ page language="C#" masterpagefile="~/Common/Master/MyPage.master" autoeventwireup="true" inherits="DoAction, App_Web_ueve7moi" title="用户操作提示页" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" width="90%" border="0">
        <tr>
            <td style="text-align: center">
                <asp:Image ImageUrl="~/Common/image/085.gif" Width="240" runat="server" ID="image1" />
            </td>
        </tr>
        <tr>
            <td height="40" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="40" style="text-align: center">
                如果浏览器在5秒钟内没有自动转向，<asp:HyperLink ID="HyperLink1" runat="server" CssClass="blue"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td height="200">
            </td>
        </tr>
    </table>
</asp:Content>
