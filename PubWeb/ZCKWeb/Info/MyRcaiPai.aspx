<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_MyRcaiPai, App_Web_6dm0odi6" title="日程安排" stylesheettheme="CjzcWeb" %>
<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">
    function sumRcap()
    {
        url="SumRcap.aspx?time0="+document.getElementById("<%=this.time1.ClientID %>").value+"&time1="+document.getElementById("<%=this.time2.ClientID %>").value;    
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }
    </script>
    <table width="98%" align="center">
        <tr>
            <td align="right">
                选择年月：
                <asp:DropDownList ID="selyear" runat="server">
                </asp:DropDownList>年
                <asp:DropDownList ID="selMonth" runat="server">
                </asp:DropDownList>月
                <asp:Button ID="Button1" runat="server" Text="查 询" OnClick="Button1_Click" />
                &nbsp;<asp:TextBox ID="time1" runat="server" Width="80"></asp:TextBox>～<asp:TextBox ID="time2" runat="server" Width="80"></asp:TextBox>
                &nbsp;<input id="Button2" type="button" value="汇总" onclick="javaScript:sumRcap();" />&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="99%" border="0" cellpadding="2" cellspacing="2" align="center">
                    <tr height="20" bgcolor="#c5c5c5">
                        <td>
                            <span style="color: #ff0000;">周日</span>
                        </td>
                        <td>
                            周一
                        </td>
                        <td>
                            周二
                        </td>
                        <td>
                            周三
                        </td>
                        <td>
                            周四
                        </td>
                        <td>
                            周五
                        </td>
                        <td>
                            <span style="color: #ff0000">周六 </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <table width="100%" border="0" cellpadding="1" cellspacing="1" align="center" bgcolor="#c5c5c5"
                                runat="server" id="tab1" enableviewstate="false">
                                <tr height="73" bgcolor="white">
                                    <td width="14%" align="center">
                                    </td>
                                    <td width="14%">
                                    </td>
                                    <td width="14%">
                                    </td>
                                    <td width="14%">
                                    </td>
                                    <td style="width: 90px">
                                    </td>
                                    <td width="14%">
                                    </td>
                                    <td width="14%">
                                    </td>
                                </tr>
                                <tr height="73" bgcolor="white">
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 90px">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr height="73" bgcolor="white">
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 90px">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr height="73" bgcolor="white">
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 90px">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr height="73" bgcolor="white">
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 90px">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr height="73" bgcolor="white">
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 90px">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
</asp:Content>
