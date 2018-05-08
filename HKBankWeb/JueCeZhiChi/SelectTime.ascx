<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectTime.ascx.cs" Inherits="JueCeZhiChi_selectTime" %>
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="130" />
        <col bgcolor="white" align="left" />
        <col bgcolor="white" align="center" width="80" />
    </colgroup>
    <tr height="25">
        <td colspan="3" align="center" bgcolor="#5d7b9d">
            <strong><font color="#ffffff">请 选 择 统 计 的 方 式</font></strong>
        </td>
    </tr>
    <tr height="25">
        <td>
            按年统计：</td>
        <td>
            &nbsp;<asp:DropDownList ID="byear3" runat="server" Width="80px">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="butSt4" runat="server" Text="统计" ToolTip="按年度统计" OnClick="butSt4_Click" /></td>
    </tr>
    <tr height="25">
        <td style="height: 25px">
            按月统计：</td>
        <td style="height: 25px">
            &nbsp;<asp:DropDownList ID="byear1" runat="server" Width="80px">
            </asp:DropDownList>年<asp:DropDownList ID="bmonth1" runat="server" Width="40px">
            </asp:DropDownList>月</td>
        <td style="height: 25px">
            <asp:Button ID="butSt2" runat="server" Text="统计" ToolTip="按月统计" OnClick="butSt2_Click" /></td>
    </tr>
    <tr height="25">
        <td>
            按季度统计：</td>
        <td>
            &nbsp;<asp:DropDownList ID="byear2" runat="server" Width="80px">
            </asp:DropDownList>年<asp:DropDownList ID="jidu" runat="server" Width="40px">
            </asp:DropDownList>季度</td>
        <td>
            <asp:Button ID="butSt3" runat="server" Text="统计" ToolTip="按季度统计" OnClick="butSt3_Click" /></td>
    </tr>
    <tr height="25">
        <td>
            自定义时间段：</td>
        <td>
            &nbsp;<asp:TextBox ID="time1" runat="server" Width="100px"></asp:TextBox>
            ～<asp:TextBox ID="time2" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="butSt1" runat="server" Text="统计" ToolTip="按自定义的时间统计" OnClick="butSt1_Click" /></td>
    </tr>
</table>
