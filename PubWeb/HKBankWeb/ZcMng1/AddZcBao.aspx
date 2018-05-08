<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_AddZcBao, App_Web_o8vl6oai" title="新增资产包" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="85%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="35%" />
            <col bgcolor="white" align="left" width="65%" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    资 产 包 信 息
                </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：
            </td>
            <td>
                <asp:TextBox ID="Bname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                接收方：
            </td>
            <td>
                <asp:TextBox ID="Bjsf" runat="server"></asp:TextBox>
            </td>
        </tr>
<%--        <tr height="25">
            <td>
                累计收款：
            </td>
            <td>
                <asp:TextBox ID="Bljsk" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                累计支出：
            </td>
            <td>
                <asp:TextBox ID="Bljzc" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr height="25">
            <td>
                责任人：
            </td>
            <td>
                <asp:TextBox ID="Bzeren" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                备注：
            </td>
            <td>
                <asp:TextBox ID="Bremark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="提交数据" OnClick="SaveDataClick" />
            </td>
        </tr>
    </table>
</asp:Content>

