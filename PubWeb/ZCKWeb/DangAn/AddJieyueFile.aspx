<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AddJieyueFile, App_Web_gn-rd1mt" title="新增借阅文件" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" />
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">新 增 借 阅 文 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                借阅单编号：</td>
            <td colspan="3">
                <asp:Label ID="bill" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum1" runat="server"></asp:TextBox></td>
            <td>
                文件1名称：</td>
            <td>
                <asp:TextBox ID="title1" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum2" runat="server"></asp:TextBox></td>
            <td>
                文件2名称：</td>
            <td>
                <asp:TextBox ID="title2" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum3" runat="server"></asp:TextBox></td>
            <td>
                文件3名称：</td>
            <td>
                <asp:TextBox ID="title3" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum4" runat="server"></asp:TextBox></td>
            <td>
                文件4名称：</td>
            <td>
                <asp:TextBox ID="title4" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum5" runat="server"></asp:TextBox></td>
            <td>
                文件5名称：</td>
            <td>
                <asp:TextBox ID="title5" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                档案编号：
            </td>
            <td>
                <asp:TextBox ID="ajnum6" runat="server"></asp:TextBox></td>
            <td>
                文件6名称：</td>
            <td>
                <asp:TextBox ID="title6" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="添加文件" OnClick="Button1_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回到借阅单" OnClick="Button2_Click" /></div>
</asp:Content>
