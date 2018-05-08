<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatZhiChu, App_Web_-gdt2rsq" title="支出统计" stylesheettheme="CjzcWeb" %>

<%@ Register Src="selectTime.ascx" TagName="selectTime" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" align="center">
        <tr>
            <td height="30" align="center">
                <uc1:selectTime ID="SelectTime1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="SelectUsers" style="overflow:auto; width=960; margin-bottom: 2pt;
                    margin-top: 2pt; vertical-align: top;">
                    <br />
                    <asp:Table ID="Table1" runat="server" EnableViewState="false" HorizontalAlign="Center"
                        BorderWidth="1" CellPadding="1" CellSpacing="1" BackColor="#c5c5c5" Width="1200pt"
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
                             <asp:TableCell ID="TableCell15" runat="server" HorizontalAlign="right">费用合计</asp:TableCell>
                             
                            <asp:TableCell ID="TableCell3" runat="server" HorizontalAlign="right">申请费</asp:TableCell>
                            <asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="right">律师费</asp:TableCell>
                            <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="right">诉讼费</asp:TableCell>
                            <asp:TableCell ID="TableCell6" runat="server" HorizontalAlign="right">执行费</asp:TableCell>
                            <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="right">受理费</asp:TableCell>
                            <asp:TableCell ID="TableCell8" runat="server" HorizontalAlign="right">仲裁费</asp:TableCell>
                            <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="right">评估费</asp:TableCell>
                            <asp:TableCell ID="TableCell10" runat="server" HorizontalAlign="right">物业费</asp:TableCell>
                            <asp:TableCell ID="TableCell11" runat="server" HorizontalAlign="right">过路费</asp:TableCell>
                            <asp:TableCell ID="TableCell12" runat="server" HorizontalAlign="right">招待费</asp:TableCell>
                            <asp:TableCell ID="TableCell13" runat="server" HorizontalAlign="right">信息费</asp:TableCell>
                            <asp:TableCell ID="TableCell14" runat="server" HorizontalAlign="right">其它费</asp:TableCell>
                           
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <br />
                </div>
                <br />
                <div align="center" id="butPrint">
                    <input id="Button1" type="button" value="打印支出统计表" style="width: 141px" class="but"
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
                        var url="TablePrint.aspx?tab1="+t2.id+"&maxCol=15&width=1200&tabRow="+t2.rows.length;
                        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
                    }
                </script>

            </td>
        </tr>
    </table>
    <br />
</asp:Content>
