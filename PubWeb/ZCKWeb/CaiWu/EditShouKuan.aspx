<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_EditShouKuan, App_Web_ttkr2a5z" title="收款单据" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">收 款 票 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="bill" runat="server"></asp:TextBox></td>
            <td>
                开票时间：</td>
            <td>
                <asp:Label ID="billtime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td>
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                归还本金：</td>
            <td>
                <asp:Label ID="pbj" runat="server" Text=""></asp:Label>
            </td>
            <td>
                归还利息：</td>
            <td>
                <asp:Label ID="plx" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                开票员：</td>
            <td>
                <asp:Label ID="billmen" runat="server" Text=""></asp:Label>
            </td>
            <td>
                备注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" Height="80px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="审核单据" OnClick="SaveDataClick" OnClientClick="javaScript:return confirm('警告：确定票据通过审核吗？');" />&nbsp;
                <asp:Button ID="Button3" runat="server" Text="更新票据" OnClick="Button3_Click" />&nbsp;
                <input id="Button2" type="button" value="退出返回" runat="server" class="but" />
            </td>
        </tr>
    </table>
</asp:Content>
