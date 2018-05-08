<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatByGSZC, App_Web_dr3prqpf" title="公司资产统计" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" width="30%" />
            <col bgcolor="white" />
        </colgroup>
        <tr height="25">
            <td colspan="3" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 统 计 结 果</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                资产户数：</td>
            <td colspan="2">
                <asp:LinkButton ID="hs" CssClass="blue2" runat="server" OnClick="hs_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                本息合计：</td>
            <td>
                <asp:Label ID="bxh1" runat="server"></asp:Label>（￥）</td>
            <td>
                <asp:Label ID="bxh2" runat="server"></asp:Label>（$）</td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                折合人民币合计：</td>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server"></asp:Label>（￥） &nbsp; 其中汇率按
                <asp:Label ID="Label2" runat="server"></asp:Label>计算（含资产包内资产情况）</td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                还本息合：
            </td>
            <td colspan="2">
                <asp:Label ID="hbxh1" runat="server"></asp:Label>
                &nbsp;（￥）</td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                费用合计：</td>
            <td colspan="2">
                <asp:Label ID="fyhj" runat="server"></asp:Label>
                （$）</td>
        </tr>
    </table>
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" width="30%" />
            <col bgcolor="white" />
        </colgroup>
        <tr height="25">
            <td colspan="3" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 包 统 计 结 果</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                资产包数量：</td>
            <td colspan="2">
                <asp:LinkButton ID="bhs" CssClass="blue2" runat="server" OnClick="bhs_Click"></asp:LinkButton></td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                包内资产户数：</td>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                本息合计：</td>
            <td>
                <asp:Label ID="bbxh1" runat="server"></asp:Label>（￥）</td>
            <td>
                <asp:Label ID="bbxh2" runat="server"></asp:Label>（$）</td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                折合人民币合计：</td>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server"></asp:Label>（￥） &nbsp; 其中汇率按
                <asp:Label ID="Label5" runat="server"></asp:Label>计算</td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                还本息合：
            </td>
            <td colspan="2">
                <asp:Label ID="bhbxh1" runat="server"></asp:Label>（￥）</td>
        </tr>
        <tr height="25">
            <td style="width: 145px">
                费用合计：</td>
            <td colspan="2">
                <asp:Label ID="bfyhj" runat="server"></asp:Label>（￥）</td>
        </tr>
    </table>
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="145"/>
            <col bgcolor="white" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">总 资 产 统 计 结 果</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                总还本息合：
            </td>
            <td >
                <asp:Label ID="zhbxh1" runat="server"></asp:Label>（￥）</td>
        </tr>
        <tr height="25">
            <td>
                总费用合计：</td>
            <td >
                <asp:Label ID="zfyhj" runat="server"></asp:Label>（￥）</td>
        </tr>
    </table>
</asp:Content>
