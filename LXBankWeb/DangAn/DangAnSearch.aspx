<%@ Page Language="C#" MasterPageFile="~/Common/Master/DangAn.master" AutoEventWireup="true"
    CodeFile="DangAnSearch.aspx.cs" Inherits="DangAn_DangAnSearch" Title="案卷检索" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="60%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 档 案 检 索 条 件</font></strong>
            </td>
        </tr>
        <tr height="25" id="row1" runat="server" visible="false">
            <td style="height: 25px">
                案卷分类：
            </td>
            <td style="height: 25px">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="211px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25" id="row2" runat="server" visible="false">
            <td>
                案卷名称：
            </td>
            <td>
                <asp:TextBox ID="ajname" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25" style="display: none" id="row3" runat="server" visible="false">
            <td>
                立卷时间：
            </td>
            <td>
                <asp:TextBox ID="time1" runat="server" Width="92"></asp:TextBox>至<asp:TextBox ID="time2"
                    runat="server" Width="97px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25" style="display: none" id="row4" runat="server" visible="false">
            <td>
                文 号：
            </td>
            <td>
                <asp:TextBox ID="fileno" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25" id="row5" runat="server" visible="false">
            <td>
                文件名称：
            </td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：
            </td>
            <td>
                <asp:TextBox ID="danwei" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检 索" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
