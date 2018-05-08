﻿<%@ control language="C#" autoeventwireup="true" inherits="ZcMng1_SearchZcLog, App_Web_o8vl6oai" %>
<table width="95%" align="center" border="0" cellpadding="1" 
 cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="15%" />
        <col bgcolor="white" align="left" width="35%" />
        <col bgcolor="white" align="right" width="15%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="4" align="center" bgcolor="#5d7b9d">
            <strong><font color="#ffffff">
            <asp:Label ID="SearchCaption" runat="server" Text="资产日志查询"></asp:Label></font>
            </strong>
        </td>
    </tr>
        
    <tr height="25" id="Row1" runat="server">
        <td  width="15%">
            责任部门：
        </td>
        <td valign="top">
            <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                AutoPostBack="true">
            </asp:RadioButtonList>
        </td>
        <td>
            责 任 人：
        </td>
        <td>
            <asp:CheckBoxList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
            </asp:CheckBoxList>
        </td>
    </tr>
    
    <tr height="25" id="Row2" runat="server">
        <td>
            责 任 人：
        </td>
        <td>
            <asp:CheckBoxList ID="zeren1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            </asp:CheckBoxList>
        </td>
    </tr>
    
    <tr height="25">
        <td  width="15%">
            填写日期：
        </td>
        <td valign="top" colspan="3">
            &nbsp;<asp:TextBox ID="time1" runat="server" Width="150px"></asp:TextBox>
                ～<asp:TextBox ID="time2" runat="server" Width="150px"></asp:TextBox>
        &nbsp;
            <asp:DropDownList ID="quickSelect" runat="server" AutoPostBack="true">
                <asp:ListItem Text="快速选择时间段" Value=""></asp:ListItem>
                <asp:ListItem Text="今天" Value="0"></asp:ListItem>
                <asp:ListItem Text="最近三天" Value="1"></asp:ListItem>
                <asp:ListItem Text="本周" Value="2"></asp:ListItem>
                <asp:ListItem Text="本月" Value="3"></asp:ListItem>
                <asp:ListItem Text="本年" Value="4"></asp:ListItem>
            </asp:DropDownList>
        </td>
        
    </tr>
       
    <tr height="30">
        <td colspan="4" align="center">
            <asp:Button ID="Button1" runat="server" Text="查询资产日志"  />
        </td>
    </tr>
</table>

