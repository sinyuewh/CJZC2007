<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvanceSearch.ascx.cs"
    Inherits="ZcMng1_AdvanceSearch" %>
<table width="99%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" width="25%" />
        <col bgcolor="white" align="right" width="20%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr>
        <td colspan="4" align="center"  height="25" bgcolor="gainsboro">
            <strong>资 产 高 级 查 询 条 件</strong>
        </td>
    </tr>
    
    <tr height="25">
        <td>
            单位名称：</td>
        <td>
            <asp:TextBox ID="danwei" runat="server" Width="200" /></td>
        <td>
            政策包类别：</td>
        <td>
            <asp:DropDownList ID="zcbao" runat="server" Width="120">
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr height="25">
        <td>
            资产编号：</td>
        <td>
            <asp:TextBox ID="num1" runat="server" Width="118px" /></td>
        <td>
            档案编号：</td>
        <td>
            <asp:TextBox ID="num2" runat="server" Width="116px" />
        </td>
    </tr>
    
    
    
    <tr height="25" id="DepartRow" runat="server">
        <td>
            责任部门：</td>
        <td>
            <asp:DropDownList ID="depart" runat="server" Width="120" AutoPostBack="true" OnSelectedIndexChanged="depart_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td>
            责 任 人：</td>
        <td>
            <asp:DropDownList ID="zeren" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr height="25" id="row1" runat ="server" visible ="false">
        <td>
            <span style="color: Blue">审批状态：</span>
        </td>
        <td>
            <asp:CheckBoxList runat="server" ID="spstatus" Width="100%" >
                <asp:ListItem Text="审批中" Value="0"></asp:ListItem>
                <asp:ListItem Text="审核委员会批" Value="1"></asp:ListItem>
                <asp:ListItem Text="决策委员会批" Value="2"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
        <td>
            <span style="color: Blue">执行结果：</span>
        </td>
        <td>
            <asp:CheckBoxList ID="spresult" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" >
            </asp:CheckBoxList>
        </td>
    </tr>
    
    <tr height="25" id="row2" runat ="server" visible ="false">
        <td>
            <span style="color: Blue">执行状态：</span>
        </td>
        <td>
            <asp:DropDownList ID="status1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="status1_SelectedIndexChanged">
            </asp:DropDownList>
            <span id="span1" runat="server">－
                <asp:DropDownList ID="status2" runat="server">
                </asp:DropDownList>
            </span>
        </td>
        <td>
            <span style="color: Blue">执行时间：</span>
        </td>
        <td>
            <asp:TextBox ID="time1" runat="server" Width="90px" />
            至
            <asp:TextBox ID="time2" runat="server" Width="90px" />
        </td>
    </tr>
    
    <tr height="25">
        <td>
            行政区域：</td>
        <td>
            <asp:DropDownList ID="quyu" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            打包分类：
        </td>
        <td>
            <asp:DropDownList ID="Bstatus" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr height="25">
        <td>
            行业分类：</td>
        <td>
            <asp:DropDownList ID="hangye" runat="server" CssClass="SELECT1">
            </asp:DropDownList>
        </td>
        <td>
            资产五级分类：</td>
        <td>
            <asp:DropDownList ID="fenlei" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr height="25">
        
        <td>
            用户自定义分类：</td>
        <td colspan="3">
            <asp:CheckBoxList ID="userkind" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            </asp:CheckBoxList></td>
    </tr>
    
    <tr height="25" id="ZcRow4" runat="server">
        <td>
            查询选项：
        </td>
        <td colspan="3">
            <asp:RadioButtonList ID="SearchKind" runat="server" RepeatDirection="Vertical">
                <asp:ListItem Text="不包括资产包中的资产" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="包括资产包中的资产" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    
    <tr height="30">
        <td colspan="4" align="center">
            <asp:Button ID="Button1" runat="server" Text="查询资产" OnClick="Button1_Click" /></td>
    </tr>
</table>

<asp:DropDownList ID="status" runat="server" Visible="false">
            </asp:DropDownList>
