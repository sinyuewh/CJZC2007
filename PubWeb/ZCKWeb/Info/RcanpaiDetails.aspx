<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_RcanpaiDetails, App_Web_6dm0odi6" title="阅读日程安排" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table>
        <tr>
            <td height="5">
            </td>
        </tr>
    </table>
    
    <table cellspacing="1" cellpadding="1" width="95%" 
    align="center" border="0" bgcolor="#c5c5c5">
        <colgroup>
            <col align="right" width="25%"/>
            <col align="left" />
        </colgroup>
        <tbody>
            <tr height="30" bgcolor="#5d7b9d">
                <td colspan="2" height="28" align="center">
                    <strong><font color="#ffffff">日 程 安 排 信 息</font></strong>
                </td>
            </tr>
            <tr bgcolor="white" height="23" runat="server" id="Row1">
                <td>
                    日程时间
                </td>
                <td>
                    <asp:TextBox ID="plantime" runat="server" Width="375px" ReadOnly="true" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr bgcolor="white" height="23">
                <td>
                    安排摘要
                </td>
                <td>
                    <asp:HiddenField ID="id" runat="server" />
                    <asp:TextBox ID="subject" runat="server" Width="375px" MaxLength="45" Height="60px" TextMode="MultiLine"></asp:TextBox>（请勿超过50个汉字）</td>
            </tr>
            <tr bgcolor="white" height="23">
                <td>
                    详细安排
                </td>
                <td>
                    <asp:TextBox ID="remark" runat="server" Width="375px"
                     TextMode="MultiLine" Height="250"></asp:TextBox></td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
        <tr>
            <td align="center" style="height: 15px">
                <hr />
                <asp:Button ID="btn1" runat="server" Text="提交数据" OnClick="btn1_Click" />
                &nbsp; &nbsp; <asp:Button ID="Button2" runat="server" Text="删除日程" OnClick="Button2_Click" OnClientClick="javaScript:return confirm('警告：确定要删除当前的日程安排吗？');" />
                &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="返回当月日程" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
