<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_CaiWuIndex, App_Web_c4_lfzql" title="资产单据浏览" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 单 据 的 检 索 条 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据的类别：</td>
            <td>
                <asp:RadioButtonList ID="billkind" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                    <asp:ListItem Selected="True" Value="0">收款单据</asp:ListItem>
                    <asp:ListItem Value="1">支出单据</asp:ListItem>
                    <asp:ListItem Value="2">入库单据</asp:ListItem>
                    <asp:ListItem Value="3">出库单据</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td>
                <asp:TextBox ID="danwei" runat="server" Width="244px" /></td>
        </tr>
        <tr height="25">
            <td>
                政策包类别：</td>
            <td>
                <asp:RadioButtonList ID="zcbao" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                    AutoPostBack="true" OnSelectedIndexChanged="depart_SelectedIndexChanged">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                责 任 人：</td>
            <td>
                <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="billnum" runat="server" Width="244px" /></td>
        </tr>
        <tr height="25">
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="time1" runat="server" Width="109px" />
                至
                <asp:TextBox ID="time2" runat="server" Width="108px" /></td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="查询单据" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
