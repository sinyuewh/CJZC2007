<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_TJ_FAZX, App_Web_ddpenrkz" title="方案执行统计" stylesheettheme="CjzcWeb" %>

<%@ Register Src="selectTime.ascx" TagName="selectTime" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left">
        <tr>
            <td height="30" align="right">
                <uc1:selectTime ID="SelectTime1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="SelectUsers" style="overflow-x: auto; width: 582pt; margin-bottom: 2pt;
                    margin-top: 2pt; vertical-align: top;">
                    <br />
                    <asp:Table ID="Table1" runat="server" EnableViewState="false" HorizontalAlign="Center"
                        BorderWidth="1" CellPadding="1" CellSpacing="1" BackColor="#c5c5c5" Width="650pt"
                        Visible="false">
                        <asp:TableRow ID="TableRow1" BackColor="White" Height="20px" HorizontalAlign="Center"
                            runat="server">
                            <asp:TableHeaderCell ID="TableHeaderCell1" ColumnSpan="15" runat="server">
                        
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow2" Height="22px" HorizontalAlign="Center" Font-Bold="True"
                            BackColor="White" runat="server">
                            <asp:TableCell ID="TableCell1" runat="server">部门</asp:TableCell>
                            <asp:TableCell ID="TableCell2" runat="server">责任人</asp:TableCell>
                            <asp:TableCell ID="TableCell9" runat="server">执行合计</asp:TableCell>
                            <asp:TableCell ID="TableCell3" runat="server">协商谈判</asp:TableCell>
                            <asp:TableCell ID="TableCell4" runat="server">诉讼</asp:TableCell>
                            <asp:TableCell ID="TableCell5" runat="server">申请执行</asp:TableCell>
                            <asp:TableCell ID="TableCell6" runat="server">强制执行</asp:TableCell>
                            <asp:TableCell ID="TableCell7" runat="server">中止执行</asp:TableCell>
                            <asp:TableCell ID="TableCell8" runat="server">终止执行</asp:TableCell>
                            <asp:TableCell ID="TableCell10" runat="server">办结</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <br />
                </div>
                <br />
                <div align="center" id="butPrint">
                    <input id="Button1" type="button" value="打印方案执行统计表" style="width: 141px" class="but"
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
                        var url="TablePrint.aspx?tab1="+t2.id+"&maxCol=10&width=860&tabRow="+t2.rows.length;
                        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
                    }
                </script>

            </td>
        </tr>
    </table>
    <br />
</asp:Content>
