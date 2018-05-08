<%@ page title="" language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_ZcTCHanK, App_Web_0lscwnk0" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table width="85%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    <asp:Label ID="dckind" runat="server" Text=""></asp:Label>
                </font></strong>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                尽职调查人员：</td>
            <td>
                <asp:TextBox ID="didian" runat="server" Width="165px"></asp:TextBox>
            </td>
            <td>
                尽职调查日期：</td>
            <td>
                <asp:TextBox ID="jieguo" runat="server" Width="169px"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td style="height: 84px">
                核查内容及核查情况：</td>
            <td colspan="3">
                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Height="74px" Width="94%"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td style="height: 84px">
                调查结论：</td>
            <td colspan="3">
                <asp:TextBox ID="remark1" runat="server" TextMode="MultiLine" Height="74px" Width="94%"></asp:TextBox>
            </td>
        </tr>
        
        
        
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button2" runat="server" Text="提交数据" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
   
</asp:Content>

