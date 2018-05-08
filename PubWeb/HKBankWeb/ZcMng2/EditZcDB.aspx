<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_EditZcDB, App_Web_cjivnna6" title="资产担保信息" stylesheettheme="CjzcWeb" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="85%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="35%" />
            <col bgcolor="white" align="left" width="65%" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    <asp:Label ID="dzkind" runat="server" Text=""></asp:Label>
                </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                物品类别：
            </td>
            <td>
                <asp:DropDownList ID="wplb" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                物品数量：
            </td>
            <td>
                <asp:TextBox ID="wpsl" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位：
            </td>
            <td>
                <asp:TextBox ID="wpdw" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                估值：
            </td>
            <td>
                <asp:TextBox ID="wpjz" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
            </td>
        </tr>
    </table>
</asp:Content>
