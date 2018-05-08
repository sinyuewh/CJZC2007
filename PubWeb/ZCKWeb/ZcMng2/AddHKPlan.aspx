<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_AddHKPlan, App_Web_zpfhjo5e" title="增加还款计划" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <strong><font color="#ffffff">增 加 还 款 计 划</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                还款日期：
            </td>
            <td>
                <asp:TextBox ID="time0" runat="server" onfocus="setday(this)" ></asp:TextBox>
            </td>
            <td>
                还款金额：
            </td>
            <td>
                <asp:TextBox ID="pbj" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                备注：
            </td>
            <td colspan="3">
                <asp:TextBox ID="remark" runat="server" Width="81%"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="提交数据" 
                OnClientClick="javascript:return confirm('提示：确定要提交数据吗？');" />
            </td>
        </tr>
    </table>
</asp:Content>
