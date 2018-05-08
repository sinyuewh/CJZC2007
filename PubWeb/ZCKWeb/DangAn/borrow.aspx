<%@ page title="档案借阅登记" language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_borrow, App_Web_gn-rd1mt" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">档 案 借 阅 申 请 单</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum" runat="server" Width="400px" ReadOnly ="true" ></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                申请时间：
            </td>
            <td>
                <asp:TextBox ID="time0" runat="server" Width="400px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                申请人：
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="borrow" runat="server" Width="400px" ReadOnly ="true" ></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                备注：
            </td>
            <td>
                <asp:TextBox ID="remark" runat="server" Width="400px" TextMode="MultiLine"  Height="60"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="确定"  />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="返回" 
                 OnClientClick="javascript:history.back();return false;" />
            </td>
        </tr>
    </table>
</asp:Content>
