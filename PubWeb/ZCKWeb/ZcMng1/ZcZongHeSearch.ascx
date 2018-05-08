<%@ control language="C#" autoeventwireup="true" inherits="ZcMng1_ZcZongHeSearch, App_Web_-yo2hwel" %>
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" width="32%" />
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="4" align="center" bgcolor="#5d7b9d">
            <strong><font color="#ffffff">资产综合查询</font> </strong>
        </td>
    </tr>
    <!---查询条件-->
    <tr height="25" id="ZcRow0" runat="server">
        <td>
            单位名称：
        </td>
        <td>
            <asp:TextBox ID="danwei" runat="server" Width="150"></asp:TextBox>
        </td>
        <td>
            档案编号：
        </td>
        <td>
            <asp:TextBox ID="num2" runat="server" Width="150" />
        </td>
    </tr>
    <tr height="25" id="noRawData" runat="server">
        <td>
            责任部门：
        </td>
        <td valign="top">
            <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            </asp:RadioButtonList>
        </td>
        <td>
            责 任 人：
        </td>
        <td>
            <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr height="30">
        <td colspan="4" align="center">
            <asp:Button ID="Button1" runat="server" Text="查询资产" />
        </td>
    </tr>
</table>
