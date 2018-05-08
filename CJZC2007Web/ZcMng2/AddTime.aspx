﻿<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true" CodeFile="AddTime.aspx.cs" Inherits="ZcMng2_AddTime" Title="增加资产时效" %>
<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">增 加 资 产 时 效</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                时效名称：</td>
            <td>
                <asp:DropDownList ID="timename" runat="server" Width="80">
                </asp:DropDownList></td>
            <td>
                时效日期：</td>
            <td>
                <asp:TextBox ID="time0" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                提前警告：</td>
            <td>
                <asp:DropDownList ID="tellday" runat="server" Width="80">
                </asp:DropDownList></td>
            <td>
                备 注：</td>
            <td>
              <asp:TextBox ID="remark" runat="server"></asp:TextBox>
                </td>
        </tr>
       
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="提交数据" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <asp:CompareValidator
            ID="CompareValidator1" runat="server" ControlToValidate="time0" Display="None"
            ErrorMessage="提示：请输入一个正确的日期！" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator><asp:ValidationSummary
                ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="timename"
        Display="None" ErrorMessage="提示：时效名称不能为空！"></asp:RequiredFieldValidator>
</asp:Content>