<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatByUserkind, App_Web_dr3prqpf" title="按自定义统计" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../Common/Script/Common.js"></script>

    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 资 产 统 计 条 件</font></strong>
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
                <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="6">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                行政区域：</td>
            <td>
                <asp:DropDownList ID="quyu" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                行业分类：</td>
            <td>
                <asp:DropDownList ID="hangye" runat="server" CssClass="SELECT1">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                行业性质分类：</td>
            <td>
                <asp:DropDownList ID="fenlei" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                用户自定义：
            </td>
            <td>
                <asp:CheckBoxList ID="userkind" runat="server" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="统计资产" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

