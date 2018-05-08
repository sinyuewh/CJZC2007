<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_EditItem, App_Web_u3wuv1nz" title="修改系统配置" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="25%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">修 改 系 统 配 置</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                配置名称：</td>
            <td>
                <asp:Label ID="itemtext" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                配置的值：</td>
            <td>
                <asp:TextBox ID="itemvalue" runat="server" Width="90%" TextMode="MultiLine" Height="150"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td colspan="2" align="left">
                <span style="line-height: 150%; margin-left:10pt; margin-right:10pt;">说明：系统配置的多个值用逗号分隔（可用中文或英文逗号），对于数值型的值（例如美元汇率），系统并不检查值的正确性，请确保录入正确。</span>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" /></div>
</asp:Content>
