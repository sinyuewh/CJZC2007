<%@ Page Language="C#" MasterPageFile="~/Common/Master/Info.master" AutoEventWireup="true"
    CodeFile="InsertInfo.aspx.cs" Inherits="Info_InsertInfo" Title="添加新信息" validateRequest="false" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="90%" align="center" border="0" cellspacing="1" cellpadding="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="ffffff">发布新信息</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td width="5%" >
                类别：
            </td>
            <td>
                <asp:RadioButtonList ID="kind" runat="server" RepeatDirection="Horizontal" Width="200">
                    <asp:ListItem Text="内部公告" Value="内部公告" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="领导指示" Value="领导指示"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td width="5%">
                标题：
            </td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" bgcolor="white">
                <FTB:FreeTextBox ID="remark" runat="server" ButtonPath="../common/image/ftb/officeXP/"
                    ToolbarType="OfficeXP" Width="98%">
                </FTB:FreeTextBox>
            </td>
        </tr>
        
        <tr height="28">
            <td>
                附件1：
            </td>
            <td>
                <asp:FileUpload ID="file1" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件2：
            </td>
            <td>
                <asp:FileUpload ID="file2" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件3：
            </td>
            <td>
                <asp:FileUpload ID="file3" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件4：
            </td>
            <td>
                <asp:FileUpload ID="file4" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件5：
            </td>
            <td>
                <asp:FileUpload ID="file5" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="btn1" runat="server" Text="提交" OnClick="btn1_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="返回" OnClick="btn2_Click" />
    </div>
</asp:Content>
