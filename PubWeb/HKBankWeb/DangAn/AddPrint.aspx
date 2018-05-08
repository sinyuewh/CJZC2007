<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AddPrint, App_Web_dq1vueyh" title="新增借阅单" stylesheettheme="CjzcWeb" %>
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
                <strong><font color="#ffffff">输 入 复 印 单 基 本 信 息</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="bill" runat="server" Width="210px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="billtime" runat="server" Width="210px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                开票员：</td>
            <td style="height: 25px">
                <asp:TextBox ID="billmen" runat="server" Width="210px"></asp:TextBox>
            </td>
        </tr>

        <tr height="25">
            <td>
                复印人：</td>
            <td>
                <asp:TextBox ID="zeren" runat="server" Width="210px"></asp:TextBox>
                 <a class="blue2" href="javaScript:WinOpen();">选择>></a>
        </tr>
        <tr height="25">
            <td>
               备注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" Width="210px" ></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td colspan="2" align="center">
               <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>

