<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatByJZDC1, App_Web_ul5m5l4v" title="尽职调查统计" stylesheettheme="CjzcWeb" %>

<%@ Register Src="selectTime.ascx" TagName="selectTime" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:selectTime ID="SelectTime1" runat="server" />
    <br />
    <asp:Table ID="Table1" runat="server" EnableViewState="false" Visible="false" Width="95%"
        HorizontalAlign="Center" CellPadding="1" CellSpacing="1" BackColor="#c5c5c5">
        <asp:TableRow BackColor="white" Height="20" HorizontalAlign="Center">
            <asp:TableHeaderCell ColumnSpan="7">
                
            </asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow BackColor="white" Height="22" HorizontalAlign="Center" Font-Bold="true">
            <asp:TableCell>部门</asp:TableCell>
            <asp:TableCell>责任人</asp:TableCell>
            <asp:TableCell>阅卷</asp:TableCell>
            <asp:TableCell>下户</asp:TableCell>
            <asp:TableCell>取证</asp:TableCell>
            <asp:TableCell>报告</asp:TableCell>
            <asp:TableCell>合计</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <div align="center" id="butPrint">
        <input id="Button1" type="button" value="打印尽职调查统计表" style="width: 141px" 
        class="but" onclick="javaScript:openPrintWindow();" />
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
            var url="TablePrint.aspx?tab1="+t2.id+"&width=700&maxCol=7&tabRow="+t2.rows.length;
            window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
        }
    </script>
</asp:Content>
