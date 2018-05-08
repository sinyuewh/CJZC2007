<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="FixZeren.aspx.cs" Inherits="ZcMng1_FixZeren" Title="调整资产责任人" %>

<%@ Register Src="AdvanceSearch.ascx" TagName="AdvanceSearch" TagPrefix="uc1" %>


<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function SetZc(renkind)
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
            //alert(selzc);
            top.location.href="SelZeRen.aspx?renkind="+renkind+"&id="+selzc+"&ReturnUrl=<%#Request.RawUrl%>";
         }
    }
    
    function setDocFlag(check1,docName)
        {
            var item1=document.getElementsByName(docName);
            for(var i=0;i<item1.length;i++)
            {
                item1[i].checked=check1;
            }
        }
    </script>

    <table width="100%">
        <tr>
            <td height="30" align="right">
                责任人：<asp:TextBox ID="zeren" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />
                &nbsp; &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue2" OnClick="LinkButton1_Click">显示高级查询>></asp:LinkButton>
                &nbsp;&nbsp;
            </td>
        </tr>
        
        <tr id="AdvanceRow" runat="server" visible="false">
            <td align="center">
                <uc1:AdvanceSearch id="AdvanceSearch1" runat="server">
                </uc1:AdvanceSearch></td>
        </tr>
        
        
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="档案号">
                            <ItemTemplate>
                                <%# Eval("num2") %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="单位名称">
                            <HeaderStyle Width="20%" />
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
                        <asp:BoundField DataField="zeren" HeaderText="责任人">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="zeren1" HeaderText="协管员">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="zeren2" HeaderText="协管员2">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                <input type="checkbox" id="selAllDoc" name="selAllDoc" onclick="javascript:setDocFlag(this.checked,'Seldoc');" />                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="Seldoc" name="Seldoc" type="checkbox" value='<%# Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分配">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="JavaScript:SetZc(0);" class="blue1" target="_self">责任人</a>&nbsp;
                                <a href="JavaScript:SetZc(1);" class="blue1" target="_self">协管员</a>&nbsp;
                                <a href="JavaScript:SetZc(2);" class="blue1" target="_self">协管员2</a>&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />提示：如果成批操作，请控制在200条数据以内（否则可能由于浏览器传参的限制导致失败）。
            </td>
        </tr>
    </table>
</asp:Content>
