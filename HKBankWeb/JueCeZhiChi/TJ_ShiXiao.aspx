<%@ Page Language="C#" MasterPageFile="~/Common/Master/JueCe.master" AutoEventWireup="true"
    CodeFile="TJ_ShiXiao.aspx.cs" Inherits="JueCeZhiChi_TJ_ShiXiao" Title="时效统计" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
            <col bgcolor="white" align="center" width="80" />
        </colgroup>
        <tr height="25">
            <td colspan="3" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">请 选 择 统 计 的 方 式</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                按年统计：</td>
            <td>
                &nbsp;<asp:DropDownList ID="byear3" runat="server" Width="80px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="butSt4" runat="server" Text="统计" ToolTip="按年度统计" OnClick="butSt4_Click" /></td>
        </tr>
        <tr height="25" style="display: none;">
            <td style="height: 25px">
                按月统计：</td>
            <td style="height: 25px">
                &nbsp;<asp:DropDownList ID="byear1" runat="server" Width="80px">
                </asp:DropDownList>年<asp:DropDownList ID="bmonth1" runat="server" Width="40px">
                </asp:DropDownList>月</td>
            <td style="height: 25px">
                <asp:Button ID="butSt2" runat="server" Text="统计" ToolTip="按月统计" /></td>
        </tr>
        <tr height="25" style="display: none;">
            <td>
                按季度统计：</td>
            <td>
                &nbsp;<asp:DropDownList ID="byear2" runat="server" Width="80px">
                </asp:DropDownList>年<asp:DropDownList ID="jidu" runat="server" Width="40px">
                </asp:DropDownList>季度</td>
            <td>
                <asp:Button ID="butSt3" runat="server" Text="统计" ToolTip="按季度统计" /></td>
        </tr>
        <tr height="25" style="display: none;">
            <td>
                自定义时间段：</td>
            <td>
                &nbsp;<asp:TextBox ID="time1" runat="server" Width="100px"></asp:TextBox>
                ～<asp:TextBox ID="time2" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="butSt1" runat="server" Text="统计" ToolTip="按自定义的时间统计" /></td>
        </tr>
    </table>
    <br />
    <asp:Table ID="Table1" runat="server" EnableViewState="false" Visible="false" Width="95%"
        HorizontalAlign="Center" CellPadding="1" CellSpacing="1" BackColor="#c5c5c5">
        <asp:TableRow BackColor="white" Height="20" HorizontalAlign="Center">
            <asp:TableHeaderCell ColumnSpan="5">
                
            </asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow BackColor="white" Height="22" HorizontalAlign="Center" Font-Bold="true">
            <asp:TableCell>月份</asp:TableCell>
            <asp:TableCell>执行时效</asp:TableCell>
            <asp:TableCell>保证时效</asp:TableCell>
            <asp:TableCell>诉讼时效</asp:TableCell>
            <asp:TableCell>抵押时效</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <div align="center" id="butPrint">
        <input id="Button1" type="button" value="打印时效统计表" style="width: 120px" class="but"
            onclick="javaScript:openPrintWindow();" />
    </div>
    <br />

    <script language="javascript">
        if(document.getElementById("<%#this.Table1.ClientID%>")==null)
        {
            document.getElementById("butPrint").style.display="none";
        }
        else
        {
            document.getElementById("butPrint").style.display="";
        }
        
        function openPrintWindow()
        {
            var t2=document.getElementById("<%#this.Table1.ClientID%>");
            var url="TablePrint.aspx?tab1="+t2.id+"&maxCol=5&width=600&tabRow="+t2.rows.length;
            window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
        }
    </script>

</asp:Content>
