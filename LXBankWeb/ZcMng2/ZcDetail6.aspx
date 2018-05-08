<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZcDetail6.aspx.cs" Inherits="ZcMng2_ZcDetail6" Title="资产时效管理" %>

<%-- 在此处添加内容控件 --%>
<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() 
{
    url="Zcsxxxb.aspx?zcid=<%#Request["id"]%>";    
    window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
}

// ]]>
    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="center" width="8%" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
        </colgroup>
        <tr height="25">
            <td colspan="7" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 的 时 效 管 理</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td colspan="2">
                单位名称
            </td>
            <td colspan="5" align="left">
                <asp:Label ID="depart" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                序号
            </td>
            <td>
                时效名称
            </td>
            <td>
                时效日期
            </td>
            <td>
                备注
            </td>
            <td>
                编辑
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_DataBound"
            OnItemCommand="Repeater1_Command">
            <ItemTemplate>
                <tr height="25">
                    <td>
                        <%#Eval("num")%>
                    </td>
                    <td>
                        <%#Eval("TimeName")%>
                    </td>
                    <td>
                        <%#Eval("ZcTime","{0:yyyy-MM-dd}") %>
                    </td>
                    
                    <td>
                        <%#Eval("remark")%>
                    </td>
                    <td>
                        <asp:Literal ID="infoid" runat="server" Text='<%#Eval("TimeID")%>' Visible="false"></asp:Literal>
                        <asp:LinkButton ID="butEdit" runat="server" CssClass="blue1" CommandName="update">更新</asp:LinkButton>
                        <asp:LinkButton ID="butDel" runat="server" CssClass="blue1" CommandName="delete"
                            OnClientClick="javascript:return confirm('警告：确定执行删除操作吗？');">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr height="30">
            <td colspan="7" align="center">
                <asp:Button ID="butAdd" runat="server" Text="增加时效" OnClick="butAdd_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button2" runat="server" type="button" value="打印资产时效数据" class="but" onclick="return Button2_onclick()"
                    style="width: 125px" />
            </td>
        </tr>
    </table>
</asp:Content>
