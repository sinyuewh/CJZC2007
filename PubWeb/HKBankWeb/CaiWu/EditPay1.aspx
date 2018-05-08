<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_EditPay1, App_Web_lhudhjkd" title="资产包支出单据" stylesheettheme="CjzcWeb" %>
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
                <asp:Label ID="bill" runat="server" Text=""></asp:Label></td>
            <td>
                开票时间：</td>
            <td>
                <asp:Label ID="billtime" runat="server" Text=""></asp:Label>
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
                <asp:Label ID="fee1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                律师费：</td>
            <td>
                <asp:Label ID="fee2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                诉讼费：</td>
            <td>
                <asp:Label ID="fee3" runat="server" Text=""></asp:Label>
            </td>
            <td>
                执行费：</td>
            <td>
                <asp:Label ID="fee4" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                受理费及保全费：</td>
            <td>
                <asp:Label ID="fee5" runat="server" Text=""></asp:Label>
            </td>
            <td>
                仲裁费：</td>
            <td>
                <asp:Label ID="fee6" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                评估费：</td>
            <td>
                <asp:Label ID="fee7" runat="server" Text=""></asp:Label>
            </td>
            <td>
                物业费：</td>
            <td>
                <asp:Label ID="fee8" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                过路费：</td>
            <td>
                <asp:Label ID="fee9" runat="server" Text=""></asp:Label>
            </td>
            <td>
                招待费：</td>
            <td>
                <asp:Label ID="fee10" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                信息咨询费：</td>
            <td>
                <asp:Label ID="fee11" runat="server" Text=""></asp:Label>
            </td>
            <td>
                其他费用：</td>
            <td>
                <asp:Label ID="fee12" runat="server" Text=""></asp:Label>
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
                <asp:Label ID="remark" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="审核单据" OnClick="SaveDataClick"  OnClientClick="javaScript:return confirm('警告：确定票据通过审核吗？');"  />&nbsp;
                <input id="Button2" type="button" value="退出返回"  runat="server" class="but" /></td>
        </tr>
    </table>
</asp:Content>

