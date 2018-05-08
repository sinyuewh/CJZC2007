<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_PiYue, App_Web_-gbu33-0" title="批阅项目审批表" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="75%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    <asp:Label ID="lab1" runat="server"></asp:Label>
                </font></strong>
            </td>
        </tr>
        <tr height="25" id="Row1" runat="server">
            <td>
                项目申报号：</td>
            <td colspan="3">
                <asp:TextBox ID="xmsbh" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                批阅时间：</td>
            <td colspan="3">
                <asp:TextBox ID="dotime" runat="server" onfocus = "setday(this);"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25" id="Row2" runat="server">
            <td>
                意见选项：</td>
            <td colspan="3">
                <asp:RadioButtonList ID="piyue1" runat="server" RepeatDirection="Vertical">
                    <asp:ListItem>同意</asp:ListItem>
                    <asp:ListItem>不同意</asp:ListItem>
                    <asp:ListItem>未参加会议</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25" id="Row3" runat="server">
            <td>
                意见选项：</td>
            <td>
                <asp:RadioButtonList ID="piyue2" runat="server" RepeatDirection="Vertical">
                    <asp:ListItem>同意</asp:ListItem>
                    <asp:ListItem>不同意</asp:ListItem>
                    <asp:ListItem>送决策委员会</asp:ListItem>
                    <asp:ListItem>未参加会议</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 84px">
                批阅意见：</td>
            <td colspan="3">
                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Height="74px" Width="94%"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button2" runat="server" Text="提交意见" OnClick="Button1_Click" />
                &nbsp;
                <asp:Button ID="Button1" runat="server" Text="放弃返回" OnClick="Button1_Click1" /></td>
        </tr>
    </table>
</asp:Content>
