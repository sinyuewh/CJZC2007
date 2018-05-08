﻿<%@ Page Language="C#" MasterPageFile="~/Common/Master/JueCe.master" AutoEventWireup="true" CodeFile="StatBySX.aspx.cs" Inherits="JueCeZhiChi_StatBySX" Title="按时效统计" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">选 择 您 所 关 心 的 时 效 检 索 条 件 </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：
            </td>
            <td>
                <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="horizontal" RepeatColumns="4"
                     AutoPostBack="true" OnSelectedIndexChanged="depart_SelectedIndexChanged"></asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                责 任 人：
            </td>
            <td>
                <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="horizontal" RepeatColumns="6"></asp:RadioButtonList>
            </td>
        </tr>
        <tr >
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="统计资产" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
