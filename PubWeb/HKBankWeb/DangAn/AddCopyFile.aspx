<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AddCopyFile, App_Web_dq1vueyh" title="增加复印文件" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">新 增 复 印 文 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                复印单编号：</td>
            <td>
                <asp:Label ID="bill" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                文件名称：</td>
            <td>
                <asp:TextBox ID="title" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                复印份数：</td>
            <td>
                <asp:TextBox ID="copycount" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server"
            Text="完成" OnClick="Button2_Click" />
        &nbsp; &nbsp;
    </div>
</asp:Content>
