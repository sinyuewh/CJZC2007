<%@ page title="编辑法律顾问权限" language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_FixLawGwEdit, App_Web_o8vl6oai" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    
    </script>

    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">编辑法律顾问权限</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任人：
            </td>
            <td>
                <asp:DropDownList ID="sname" runat ="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                类别：
            </td>
            <td>
                <asp:DropDownList ID="kind" runat ="server">
                    <asp:ListItem Text ="仅资产" Value ="资产"></asp:ListItem>
                    <asp:ListItem Text ="仅资产包" Value ="资产包"></asp:ListItem>
                    <asp:ListItem Text ="资产和资产包" Value ="资产和资产包"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" />
        &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" /></div>
</asp:Content>
