<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_AddPay1, App_Web_e5meitto" title="资产包支出单据" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">支 出 票 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="bill" runat="server"></asp:TextBox></td>
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="billtime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：</td>
            <td>
                <asp:Label ID="bname" runat="server" Text=""></asp:Label>
            </td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="bzeren" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                申请费：</td>
            <td>
                <asp:TextBox ID="fee1" runat="server"></asp:TextBox>
            </td>
            <td>
                律师费：</td>
            <td>
                <asp:TextBox ID="fee2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                诉讼费：</td>
            <td>
                <asp:TextBox ID="fee3" runat="server"></asp:TextBox>
            </td>
            <td>
                执行费：</td>
            <td>
                <asp:TextBox ID="fee4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                受理费及保全费：</td>
            <td>
                <asp:TextBox ID="fee5" runat="server"></asp:TextBox>
            </td>
            <td>
                仲裁费：</td>
            <td>
                <asp:TextBox ID="fee6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                评估费：</td>
            <td>
                <asp:TextBox ID="fee7" runat="server"></asp:TextBox>
            </td>
            <td>
                物业费：</td>
            <td>
                <asp:TextBox ID="fee8" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                过路费：</td>
            <td>
                <asp:TextBox ID="fee9" runat="server"></asp:TextBox>
            </td>
            <td>
                招待费：</td>
            <td>
                <asp:TextBox ID="fee10" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                信息咨询费：</td>
            <td>
                <asp:TextBox ID="fee11" runat="server"></asp:TextBox>
            </td>
            <td>
                其他费用：</td>
            <td>
                <asp:TextBox ID="fee12" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                开票员：</td>
            <td>
                <asp:Label ID="billmen" runat="server" Text=""></asp:Label>
            </td>
            <td>
                备注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="提交数据" OnClick="SaveDataClick" OnClientClick="javaScript:return confirm('警告：确定提交数据吗？');" />
            </td>
        </tr>
    </table>
</asp:Content>

