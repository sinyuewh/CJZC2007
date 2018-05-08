<%@ Page Language="C#" MasterPageFile="~/Common/Master/DangAn.master" AutoEventWireup="true" CodeFile="AddJieYue.aspx.cs" Inherits="DangAn_AddJieYue" Title="新增借阅单" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function WinOpen()
    {
        var url="UserList.aspx";
        str1=window.showModalDialog(url,"","dialogLeft:100pt;dialogTop:100pt;dialogWidth:540pt;dialogHeight:440pt;status:no");
        if(str1!="" && str1!=undefined)
        {
            document.forms[0].<%#this.zeren.ClientID %>.value=str1;
        }
    }
</script>
<table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 借 阅 单 基 本 参 数</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="bill" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="billtime" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                开票员：</td>
            <td style="height: 25px">
                <asp:TextBox ID="billmen" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>

        <tr height="25">
            <td>
                借阅人：</td>
            <td>
                <asp:TextBox ID="zeren" runat="server" Width="206px"></asp:TextBox>
                <a class="blue2" href="javaScript:WinOpen();">选择>></a>
        </tr>
        <tr height="25">
            <td>
               归还时间： </td>
            <td>
                <asp:TextBox ID="paytime" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                备 注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td colspan="2" align="center">
               <asp:Button ID="Button1" runat="server" Text="确 定" OnClick="Button1_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>

