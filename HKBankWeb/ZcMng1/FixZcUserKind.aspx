<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="FixZcUserKind.aspx.cs" Inherits="ZcMng1_FixZcUserKind" Title="调整资产自定义" %>

<%@ Register Src="AdvanceSearch.ascx" TagName="AdvanceSearch" TagPrefix="uc1" %>
<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function SetUserKind(skind)
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
            alert("错误：请选择要调整自定义的资产!");
         }
         else
         {
            if(skind==31)
            {
                if(confirm("警告：您确定要清除选择数据的【用户自定义分类】吗？")==false)
                {
                    return ;
                }
            }
            top.location.href="SelUserKind.aspx?kind="+skind+"&id="+selzc;
         }
    }
    </script>

    <table width="100%">
        <tr>
            <td height="30" align="right">
                单位名称：<asp:TextBox ID="danwei" runat="server"></asp:TextBox>&nbsp;&nbsp;
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
                    SkinID="gridviewSkin" EnableViewState="false">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="选">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <input id="Seldoc" name="Seldoc" type="checkbox" value='<%# Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="num2" HeaderText="档案号">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="单位名称">
                            <HeaderStyle Width="33%" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("danwei") %>">
                                    <%# Eval("danwei1") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="userkind" HeaderText="自定义分类">
                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="调整">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="18%" />
                            <ItemTemplate>
                                <a href="JavaScript:SetUserKind(11);" class="blue1" target="_self">替换</a> | <a href="JavaScript:SetUserKind(21);"
                                    class="blue1" target="_self">追加</a> | <a href="JavaScript:SetUserKind(31);" class="blue1"
                                        target="_self">清除</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr visible="false" runat="server" id="Row1">
            <td height="40" align="center">
                <cc1:PageNavigator ID="PageNavigator1" runat="server" OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                    PageSize="50" PageNavType="数字式" />
            </td>
        </tr>
    </table>
</asp:Content>
