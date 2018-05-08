<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_ZcDetail5, App_Web_dbor6yme" title="资产的抵债物资" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() 
{
    url="Zcdzwzb.aspx?zcid=<%#Request["id"]%>";    
    window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
}

// ]]>
    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 的 抵 债 物 资</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td align="right">
                单位名称：</td>
            <td colspan="3" align="left">
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:Label ID="depart" runat="server" Text=""></asp:Label>&nbsp;</td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>&nbsp;</td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <input id="Button2" runat="server" type="button" value="打印资产财务数据" class="but" onclick="return Button2_onclick()" />
            </td>
        </tr>
    </table>
    <table>
        <tr height="3">
            <td style="width: 3px">
            </td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                </colgroup>
                <tr height="25">
                    <td colspan="7" align="Center" bgcolor="gainsboro">
                        <strong>1．抵 债 物 资</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        物品类别
                    </td>
                    <td>
                        物品名称
                    </td>
                    <td>
                        规格型号</td>
                    <td>
                        库存数量
                    </td>
                    <td>
                        单位</td>
                    <td>
                        备注</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <%#Eval("gkind") %>
                </td>
                <td>
                    <%#Eval("gname") %>
                </td>
                <td>
                    <%#Eval("ggxh") %>
                </td>
                <td>
                    <%#Eval("num") %>
                </td>
                <td>
                    <%#Eval("dw") %>
                </td>
                <td>
                    <%#Eval("remark") %>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater2" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="right" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="Center" bgcolor="gainsboro">
                        <strong>2．入 库 单 据</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        单据编号
                    </td>
                    <td>
                        开票时间</td>
                    <td>
                        部门
                    </td>
                    <td>
                        责任人</td>
                    <td>
                        开票员</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <a href="<%#Application["root"] %>/Caiwu/<%# Eval("EditASP") %>?id=<%# Eval("id") %>"
                        class="blue1" target="_blank">[入]<%#Eval("bill") %></a>
                </td>
                <td>
                    <%#Eval("billtime","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td>
                    <%#Eval("billmen")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td style="width: 3px">
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater3" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="right" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="Center" bgcolor="gainsboro">
                        <strong>3．出 库 单 据</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        单据编号
                    </td>
                    <td>
                        开票时间</td>
                    <td>
                        部门
                    </td>
                    <td>
                        责任人</td>
                    <td>
                        开票员</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <a href="<%#Application["root"] %>/Caiwu/<%# Eval("EditASP") %>?id=<%# Eval("id") %>"
                        class="blue1" target="_blank">[出]<%#Eval("bill") %></a>
                </td>
                <td>
                    <%#Eval("billtime","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td>
                    <%#Eval("billmen")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td style="width: 3px">
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
