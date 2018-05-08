<%@ page language="C#" masterpagefile="~/Common/Master/MyPage.master" autoeventwireup="true" inherits="Error, App_Web_k7qlrvw3" title="发生错误了" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" width="90%" border="0">
        <tr>
            <td style="text-align: center">
                <asp:Image ImageUrl="~/Common/image/085.gif" Width="240" runat="server" ID="image1" />
            </td>
        </tr>
        
        <tr>
            <td height="40" style="text-align: center; line-height:150%">
                <strong>抱歉，发生错误了，可能的原因是【操作错误】！</strong>
                <br /><br />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="blue" Text="返回主页" NavigateUrl="~/Default.aspx"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td height="200">
            </td>
        </tr>
    </table>
</asp:Content>
