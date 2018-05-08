<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZiChangFengPei.aspx.cs" Inherits="ZiChan_ZiChangFengPei" Title="资产责任到人" %>

<%@ Register Src="AdvanceSearch.ascx" TagName="AdvanceSearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function SetZc()
    {
        var selzc="";
        if(document.forms[0].Seldoc.length!=undefined)
        {
            for(var i=0;i<document.forms[0].Seldoc.length;i++)
            {
                if(document.forms[0].Seldoc[i].checked)
                {
                    if(selzc!="")
                    {
                        selzc=selzc+",";
                    }
                    selzc=selzc+document.forms[0].Seldoc[i].value;
                }
            }
        }
        else
        {
            if(document.forms[0].Seldoc.checked)
            {
                selzc=document.forms[0].Seldoc.value;
            }
         }
         
         if(selzc=="")
         {
            alert("错误：请选择要分配的资产!");
         }
         else
         {
            top.location.href="SelZeRen.aspx?id="+selzc;
         }
    }
    
    function WinOpen()
    {
        var url="ZcNoFenPeib.aspx";
        
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }
    </script>

    <table width="100%">
        <tr>
            <td height="30" align="right">
                单位名称：<asp:TextBox ID="danwei" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />
                &nbsp; &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue2" OnClick="LinkButton1_Click">显示高级查询>></asp:LinkButton>
                &nbsp;&nbsp; <a class="blue2" href="javaScript:WinOpen();">打印未分配资产>></a> &nbsp;&nbsp;
            </td>
        </tr>
        <tr id="AdvanceRow" runat="server" visible="false">
            <td align="center">
                <uc1:AdvanceSearch ID="AdvanceSearch1" runat="server"></uc1:AdvanceSearch>
            </td>
        </tr>
        <tr>
            <td>
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
                        <asp:BoundField DataField="num2" HeaderText="档案号">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="单位名称">
                            <HeaderStyle Width="38%" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("danwei") %>">
                                    <%# Eval("danwei1") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="time0" HeaderText="转入时间" DataFormatString="{0:yyyy-MM-dd}"
                            HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bj" HeaderText="初始本金" DataFormatString="{0:N2}" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bxhj" HeaderText="利息" DataFormatString="{0:N2}" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="选中">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <input id="Seldoc" name="Seldoc" type="checkbox" value='<%# Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分配">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="JavaScript:SetZc();" class="blue1" target="_self">分配</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
