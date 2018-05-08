<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatZcInfo, App_Web_uajp-wst" title="资产信息" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        SkinID="gridviewSkin" EnableViewState="False">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单位名称">
                <HeaderStyle Width="38%" />
                <ItemTemplate>
                    <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                        title="<%# Eval("danwei") %>">
                        <%# Eval("danwei1") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="bj" HeaderText="初始本金"　DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx" HeaderText="利息"　DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
             <asp:BoundField DataField="huobi" HeaderText="货币">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="depart" HeaderText="责任部门">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="zeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           
        </Columns>
        
    </asp:GridView>
    
    <script language="javascript">
        function Heji()
        {
            var tab1=document.getElementById("<%#this.GridView1.ClientID%>");
            row1=tab1.insertRow(tab1.rows.length);  
            row1.height="25pt";  
            for(var i=0;i<tab1.rows[0].cells.length;i++)
            { 
                col1=row1.insertCell(i);
                if(i==1)
                {
                    col1.innerHTML="<b>合计</b>";   
                }
                if(i==2)
                {
                    col1.innerHTML="<%#String.Format("{0:N2}",this.d1)%>";
                    col1.align="right";
                }
                if(i==3)
                {
                    col1.innerHTML="<%#String.Format("{0:N2}",this.d2)%>";
                    col1.align="right";
                }
            }
        }
    </script>
</asp:Content>
