<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AnJuanMove, App_Web_gn-rd1mt" title="移交案卷" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" bgcolor="#5d7b9d" align="center">
                <strong><font color="#ffffff">移 交 资 产 案 卷</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：</td>
            <td>
                <asp:Label ID="ajnum" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                案卷名称：</td>
            <td>
                <asp:Label ID="ajname" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                移交时间：</td>
            <td>
                <asp:TextBox ID="yjtime" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                移交单位：</td>
            <td>
                <asp:TextBox ID="yjdanwei" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                经 手 人：</td>
            <td>
                <asp:TextBox ID="jsren" runat="server" Width="200px"></asp:TextBox>
                <asp:TextBox ID="ajstatus" runat="server" ReadOnly="True" Visible="False" Width="199px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                移交说明：</td>
            <td>
                <asp:TextBox ID="remark1" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="确定移交" OnClientClick="javascript:confirm('提示：确定进行案卷移交操作吗？');"
            OnClick="Button1_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" CausesValidation="False" /><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="yjtime" Display="None"
            ErrorMessage="错误：移交时间不能为空！"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="yjdanwei" Display="None"
                ErrorMessage="错误：移交单位不能为空！"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                    runat="server" ControlToValidate="yjtime" Display="None" ErrorMessage="错误：移交时间格式不正确！"
                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator><asp:ValidationSummary
                        ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </div>
</asp:Content>
