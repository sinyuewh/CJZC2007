<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_SXSearchResult, App_Web_7icq5msn" title="Untitled Page" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" width="30%"/>
            <col bgcolor="white" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 时 效 查 询 结 果</font></strong>
            </td>
        </tr>
        <tr>
            <td style="width: 119px">
                资产时效
            </td>
            <td>
                户数
            </td>
            <td>
                进入警戒期时效
            </td>
            <td>
                过期时效
            </td>
        </tr>
        <tr>
            <td style="width: 119px">
                <asp:Table ID="Table1" runat="server">
                <asp:TableRow runat="server" ID="row1">
                    <asp:TableCell ></asp:TableCell>
                  <asp:TableCell >
                      <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink></asp:TableCell>
                   <asp:TableCell >
                      <asp:HyperLink ID="HyperLink2" runat="server"></asp:HyperLink></asp:TableCell>
                   <asp:TableCell >
                      <asp:HyperLink ID="HyperLink3" runat="server"></asp:HyperLink></asp:TableCell>
                </asp:TableRow>
                </asp:Table>
            </td>
        </tr>
        </table>
</asp:Content>

