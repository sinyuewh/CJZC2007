<%@ Page Language="C#" MasterPageFile="~/Common/Master/JueCe.master" AutoEventWireup="true"
    CodeFile="StatHuiKuan.aspx.cs" Inherits="JueCeZhiChi_StatHuiKuan" Title="回款统计" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <script language="javascript" type="text/javascript">
 function WinOpen()
 {
    var btime = document.forms[0].<%#this.BeginTime.ClientID %>.value;
    var etime = document.forms[0].<%#this.EndTime.ClientID %>.value;
    var url="StatHuiKuanB.aspx?btime="+btime+"&etime="+etime;
      
    window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
 }
 
 </script>
    <table width="100%">
        <tr>
            <td height="30" align="right">
                时间段：<asp:TextBox ID="BeginTime" runat="server" Width="100"></asp:TextBox>——<asp:TextBox
                    ID="EndTime" runat="server" Width="100"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />
                &nbsp;&nbsp;
                <a class="blue2" href="javaScript:WinOpen();">打印回款统计</a>
            </td>
        </tr>
        <tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_DataBound">
                <HeaderTemplate>
                    <tr>
                        <td align="left" valign="top">
                            <table width="95%" align="right">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView10" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            SkinID="gridviewSkin" EnableViewState="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="" DataField="gsname">
                                                    <HeaderStyle HorizontalAlign="center" Width="30%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <HeaderStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <a class="blue1" href="StatHuiKuanInfo.aspx?zcid=<%#Eval("zcid") %>&&bid=<%#Eval("bid") %>"
                                                            title="<%#Eval("hkje") %>">
                                                            <%#Comm.GetNumberFormat(Eval("hkje")) %>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;<asp:Label ID="labDepart" runat="server" Text='<%#Eval("depart")%>' Font-Bold="true"></asp:Label>:
                            <asp:Label ID="DepartHK" runat="server" Text='<%#Eval("hkje")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table width="95%" align="right">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            SkinID="gridviewSkin" EnableViewState="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="责任人" DataField="zeren">
                                                    <HeaderStyle HorizontalAlign="center" Width="30%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="回收款额">
                                                    <HeaderStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <a class="blue1" href="StatHuiKuanInfo.aspx?zcid=<%#Eval("zcid") %>&&bid=<%#Eval("bid") %>"
                                                            title="<%#Eval("hkje") %>">
                                                            <%#Comm.GetNumberFormat(Eval("hkje")) %>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td align="left">
                            <hr width="98%" size="2" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                        </td>
                    </tr>
                </SeparatorTemplate>
            </asp:Repeater>
        </tr>
    </table>
</asp:Content>
