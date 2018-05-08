<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="XtGL_UserLogList, App_Web_lh9kwmkt" title="用户使用日志明细浏览" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        EnableViewState="False" SkinID="gridviewSkin">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:BoundField DataField="depart" HeaderText="部门">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="zeren" HeaderText="姓名">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
            <asp:BoundField DataField="beginlogin" HeaderText="上线">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
            <asp:BoundField DataField="endlogin" HeaderText="下线">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
            <asp:BoundField DataField="time1" HeaderText="上线时间(分）">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>

