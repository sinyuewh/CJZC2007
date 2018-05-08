<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="XtGL_UserLogo, App_Web_6dm0odi6" title="用户日志" stylesheettheme="CjzcWeb" %>

<%@ Register Src="~/JueCeZhiChi/selectTime.ascx" TagName="selectTime" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left">
        <tr>
            <td height="30" align="right">
                <uc1:selectTime ID="SelectTime1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Table ID="Table1" runat="server" EnableViewState="false" HorizontalAlign="Center"
                    BorderWidth="1" CellPadding="1" CellSpacing="1" BackColor="#c5c5c5" Width="95%"
                    Visible="false">
                    <asp:TableRow ID="TableRow1" BackColor="White" Height="20px" HorizontalAlign="Center"
                        runat="server">
                        <asp:TableHeaderCell ID="TableHeaderCell1" ColumnSpan="15" runat="server">
                        
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" Height="22px" HorizontalAlign="Center" Font-Bold="True"
                        BackColor="White" runat="server">
                        <asp:TableCell ID="TableCell1" runat="server">部门</asp:TableCell>
                        <asp:TableCell ID="TableCell2" runat="server">姓名</asp:TableCell>
                        <asp:TableCell ID="TableCell9" runat="server">上线时间(分)</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <br />
                
                <div align="center" id="butPrint">
                    <input id="Button1" type="button" value="打印用户日志" style="width: 141px" class="but"
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
                        var url="../JueCeZhiChi/TablePrint.aspx?tab1="+t2.id+"&maxCol=3&width=650&tabRow="+t2.rows.length;
                        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
                    }
                </script>

            </td>
        </tr>
    </table>
    <br />
</asp:Content>
