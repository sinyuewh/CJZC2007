<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_EditInfo, App_Web_lh9kwmkt" title="修改信息" validaterequest="false" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="center" border="0" cellspacing="1" cellpadding="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d" >
                <strong><font color="ffffff">修改信息</font></strong>
            </td>
            
        </tr>
        <tr height="25">
            <td width="5%">
                标题：
            </td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="90%"></asp:TextBox>
            </td>
            <tr height="25">
                <td width="5%">
                    类别：
                </td>
                <td>
                    <asp:DropDownList ID="kind" runat="server">
                        <asp:ListItem Text="内部公告" Value="内部公告" ></asp:ListItem>
                        <asp:ListItem Text="领导指示" Value="领导指示" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr height="25">
                <td width="5%">
                    正文：
                </td>
                <td >
                    <FTB:FreeTextBox ID="remark" runat="server" ButtonPath="../common/image/ftb/officeXP/"
                        ToolbarType="OfficeXP" Width="98%">
                         
                    </FTB:FreeTextBox>
                </td>
            </tr>
        </tr>
        
    </table>
    <br />
    <div align="center">
        <asp:Button ID="btn1" runat="server" Text="提交" OnClick="btn1_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="返回" OnClick="btn2_Click" />
    </div>
</asp:Content>

