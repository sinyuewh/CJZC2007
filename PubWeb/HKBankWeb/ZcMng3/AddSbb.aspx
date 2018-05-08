<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_AddSbb, App_Web_fdkrliok" title="新增项目处置方案申报表" stylesheettheme="CjzcWeb" %>
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

