<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AddFile, App_Web_dq1vueyh" title="新增卷内文件" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">填 写 文 件 信 息</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：</td>
            <td>
                &nbsp;<asp:Label ID="ajnum" runat="server" Text="Label"></asp:Label></td>
                <td>
                文件名称：</td>
            <td>
                <asp:TextBox ID="title" runat="server"></asp:TextBox></td>
           
        </tr>
        <%--<tr height="25">
            
            <td>
                文件内容：
            </td>    
            <td>
                <asp:TextBox ID="remark" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <%--<tr height="25" style="display: none">
            <td>
                责任部门：</td>
            <td>
                <asp:TextBox ID="depart" runat="server"></asp:TextBox></td>
            <td>
                责 任 人：</td>
            <td>
                <asp:TextBox ID="zeren" runat="server"></asp:TextBox></td>
        </tr>--%>
        <tr height="25">
            <%--<td>
                卷内顺序：</td>
            <td>
                <asp:TextBox ID="filenum" runat="server"></asp:TextBox></td>--%>
            <td>
                文件份数：
            </td>
            <td>
                <asp:TextBox ID="filefs" runat="server"></asp:TextBox>
            </td>
            <td>
                文件页数：</td>
            <td>
                <asp:TextBox ID="filecount" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="Button2"
                    runat="server" Text="返 回" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
