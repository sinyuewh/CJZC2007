<%@ Page Language="C#" MasterPageFile="~/Common/Master/JueCe.master" AutoEventWireup="true"
    CodeFile="st2.aspx.cs" Inherits="JueCeZhiChi_st2" Title="按部门统计资产" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">请 选 择 一 个 部 门</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="统计资产" OnClick="Button1_Click" />
            </td>
        </tr>
        
    </table>
</asp:Content>
