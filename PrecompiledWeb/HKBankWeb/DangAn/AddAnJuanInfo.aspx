<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AddAnJuanInfo, App_Web_widkftde" title="新增案卷信息" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="60%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 案 卷 基 本 参 数</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：</td>
            <td>
                <asp:TextBox ID="ajnum" runat="server" Width="240"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷名称：</td>
            <td>
                <asp:TextBox ID="ajname" runat="server" Width="240"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷分类：</td>
            <td>
                <asp:DropDownList ID="ajkind" runat="server" Width="242">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25" style="display:none">
            <td>
                立案时间：</td>
            <td>
                <asp:TextBox ID="time0" runat="server" Width="240"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                立 案 人：
            </td>
            <td>
                <asp:TextBox ID="ljren" runat="server" Width="240"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                备 &nbsp; &nbsp; &nbsp; &nbsp;注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" Width="240"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />&nbsp;<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="ajnum" Display="None"
            ErrorMessage="错误：案卷编号不能为空！"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ajname"
            Display="None" ErrorMessage="错误：案卷名称不能为空！"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ajkind"
            Display="None" ErrorMessage="错误：案卷分类不能为空！"></asp:RequiredFieldValidator>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="time0"
            Display="None" ErrorMessage="错误：立案时间不能为空！"></asp:RequiredFieldValidator>--%>
        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="time0"
            Display="None" ErrorMessage="错误：立案时间格式不正确！" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>--%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </div>
</asp:Content>
