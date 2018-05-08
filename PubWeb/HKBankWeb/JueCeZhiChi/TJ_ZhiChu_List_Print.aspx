<%@ page language="C#" autoeventwireup="true" inherits="JueCeZhiChi_StatZhiChuInfoB, App_Web_7icq5msn" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印支出统计详细信息表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            EnableViewState="False" Width="1200px">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单位名称">
                    <HeaderStyle Width="19%" />
                    <ItemTemplate>
                        <%# Eval("danwei1") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                    HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="8%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请费" DataField="fee1" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="律师费" DataField="fee2" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="诉讼费" DataField="fee3" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="执行费" DataField="fee4" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="受理费" DataField="fee5" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="仲裁费" DataField="fee6" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="评估费" DataField="fee7" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center"  Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="物业费" DataField="fee8" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="过路费" DataField="fee9" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center"  Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="fee10" HeaderText="招待费" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="信息费" DataField="fee11" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center"  Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="其它费" DataField="fee12" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center"  Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="合计" DataField="fyhj" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
             EnableViewState="False" Width="1200px">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# this.GridView2.PageIndex * this.GridView2.PageSize 
                                         +this.GridView2.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="资产包名称">
                    <HeaderStyle Width="19%" />
                    <ItemTemplate>
                        <%# Eval("bname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                    HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="8%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请费" DataField="fee1" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="律师费" DataField="fee2" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="诉讼费" DataField="fee3" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="执行费" DataField="fee4" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="受理费" DataField="fee5" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="仲裁费" DataField="fee6" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="评估费" DataField="fee7" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="物业费" DataField="fee8" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="过路费" DataField="fee9" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="fee10" HeaderText="招待费" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="信息费" DataField="fee11" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="其它费" DataField="fee12" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="合计" DataField="fyhj" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
