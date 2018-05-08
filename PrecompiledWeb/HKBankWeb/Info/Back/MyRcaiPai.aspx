<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_MyRcaiPai, App_Web_1mvigtgc" title="日程安排" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">
        //快速选择时间
        function selectTime(selkind)
        {
            var t1=document.getElementById("<%#this.begtime.ClientID%>");
            var t2=document.getElementById("<%#this.endtime.ClientID%>");
            if(selkind=="")
            {
                t1.value="";t2.value="";
            }
            if(selkind=="0")
            {
                t1.value="<%#this.zt1%>";
                t2.value="<%#this.zt2%>"
            }
            
            if(selkind=="1")
            {
                t1.value="<%#this.mt1%>";
                t2.value="<%#this.mt2%>"
            }
            
            if(selkind=="2")
            {
                t1.value="<%#this.yt1%>";
                t2.value="<%#this.yt2%>"
            }
        }
    </script>
    <table width="98%" align="center">
        <tr>
            <td align="right">
                查看时间段：<asp:TextBox ID="begtime" runat="server" Width="105px"></asp:TextBox>
                <asp:TextBox ID="endtime" runat="server" Width="105px"></asp:TextBox>
                <asp:DropDownList ID="seltime" runat="server">
                    <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                    <asp:ListItem Value="0">本周日程</asp:ListItem>
                    <asp:ListItem Value="1">本月日程</asp:ListItem>
                    <asp:ListItem Value="2">本年日程</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="过 滤" OnClick="Button1_Click" />&nbsp;
                <asp:Button ID="Button2" runat="server" Text="增 加" OnClick="Button2_Click" />&nbsp;
                <asp:Button ID="Button3" runat="server" Text="删 除" OnClick="Button3_Click" OnClientClick="return confirm('警告:确定删除选中的数据吗?');" />
                </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input id="Checkbox1" type="checkbox" name="seldoc" value='<%#Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="序号">
                            <HeaderStyle Width="10%" />
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                                     +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日程安排" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Width="70%" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/Info/RcanpaiDetails.aspx?id=<%# Eval("ID") %>">
                                    <%#Eval("subject") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="plantime" HeaderText="日程时间" DataFormatString="{0:yy-MM-dd dddd}"
                            HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
