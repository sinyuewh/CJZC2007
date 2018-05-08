<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_FileDetail, App_Web_dq1vueyh" title="Untitled Page" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">文 件 详 细 信 息</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：</td>
            <td>
                <asp:Label ID="ajnum" runat="server"></asp:Label></td>
            <td>
               文 号：</td>
            <td>
                <asp:Label ID="fileno" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
              标 题：</td>
            <td>
                <asp:Label ID="title" runat="server"></asp:Label></td>
            <td>
                单 位：</td>
            <td>
                <asp:Label ID="danwei" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:Label ID="depart" runat="server"></asp:Label></td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                顺序：</td>
            <td>
                <asp:Label ID="filenum" runat="server"></asp:Label></td>
            <td>
                文件页数：</td>
            <td>
                <asp:Label ID="filecount" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                起始页：</td>
            <td>
                <asp:Label ID="beginPage" runat="server"></asp:Label></td>
            <td>
                结束页：</td>
            <td>
                <asp:Label ID="endPage" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                借阅人：</td>
            <td>
                <asp:Label ID="jyue" runat="server"></asp:Label></td>
            <td>
                借出时间：</td>
            <td>
                <asp:Label ID="jyuetime" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                登记时间：</td>
            <td>
                <asp:Label ID="djtime" runat="server"></asp:Label></td>
            <td>
                登记人：</td>
            <td>
                <asp:Label ID="dtmen" runat="server"></asp:Label></td>
        </tr>
        
        <tr height="30">
            <td colspan="4" align="center">
                
            </td>
        </tr>
    </table>
</asp:Content>

