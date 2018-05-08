<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true" CodeFile="AddSbb.aspx.cs" Inherits="ZcMng3_AddSbb" Title="新增项目处置方案申报表" %>
<%@ Register Src="Info2.ascx" TagName="Info2" TagPrefix="uc3" %>
<%@ Register Src="Info1.ascx" TagName="Info1" TagPrefix="uc2" %>
<%@ Register Src="MenuKind.ascx" TagName="MenuKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MenuKind id="MenuKind1" runat="server">
    </uc1:MenuKind>
 <br />
    <uc2:Info1 ID="Info1" runat="server" />
    <uc3:Info2 ID="Info2" runat="server" Visible="false" />
        
    <table width="100%" align="center">
        <tr>
            <td align="center" height="40" valign="middle">
                <asp:Button ID="Button1" runat="server" Text="保存数据" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>

