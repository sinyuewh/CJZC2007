<%@ control language="C#" autoeventwireup="true" inherits="ZcMng1_SearchControl, App_Web_-yo2hwel" %>
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" width="32%" />
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="4" align="center" bgcolor="#5d7b9d">
            <strong><font color="#ffffff">
                <asp:Label ID="SearchCaption" runat="server"></asp:Label></font> </strong>
        </td>
    </tr>
    <!---查询条件-->
    <tr height="25" id="ZcRow0" runat="server">
        <td>
            单位名称：
        </td>
        <td>
            <asp:TextBox ID="danwei" runat="server" Width="150"></asp:TextBox>
        </td>
        <td>
            档案编号：
        </td>
        <td>
            <asp:TextBox ID="num2" runat="server" Width="150" />
        </td>
    </tr>
    <tr height="25" id="ZcbRow0" runat="server">
        <td>
            资产包名称：
        </td>
        <td>
            <asp:TextBox ID="bname" runat="server" Width="150"></asp:TextBox>
        </td>
        <td>
            接收方：
        </td>
        <td>
            <asp:TextBox ID="bjsf" runat="server" Width="150" />
        </td>
    </tr>
    
    <tr height="25" id="noRawData" runat ="server">
        <td>
            责任部门：
        </td>
        <td valign="top">
            <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                AutoPostBack="true" OnSelectedIndexChanged="depart_SelectedIndexChanged">
            </asp:RadioButtonList>
        </td>
        <td>
            责 任 人：
        </td>
        <td>
            <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            </asp:RadioButtonList>
        </td>
    </tr>
    
    <!--用于法律顾问-->
     <tr height="25" id="RawData" runat ="server">   
        <td>
            责 任 人：
        </td>
        <td colspan="3">
            <asp:CheckBoxList ID="zerenlaw" runat ="server" RepeatDirection="Horizontal" RepeatColumns="9">
            </asp:CheckBoxList>
            
        </td>
    </tr>
    
    <!--用于部门责任人-->
    <tr height="25" id="DepartRowData" runat ="server">   
        <td>
            部门责任人：
        </td>
        <td colspan="3">
            <asp:CheckBoxList ID="zerenForDepart" runat ="server" RepeatDirection="Horizontal" RepeatColumns="5">
            </asp:CheckBoxList>
            <asp:Label ID="alldepartuser" runat ="server" Visible ="false"></asp:Label>
        </td>
    </tr>
    
    
    <tr height="25">
        <td>
            <span style="color: Blue">审批状态：</span>
        </td>
        <td>
            <asp:CheckBoxList runat="server" ID="spstatus" Width="100%" RepeatDirection="Horizontal">
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
    <tr height="25">
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
    <tr height="25" id="ZcRow1" runat="server">
        <td>
            政策包类别：
        </td>
        <td>
            <asp:DropDownList ID="zcbao" runat="server" Width="120">
            </asp:DropDownList>
        </td>
        <td>
            管辖：
        </td>
        <td>
            <asp:DropDownList ID="guangxia" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr height="25" id="ZcRow2" runat="server">
        <td>
            行业分类：
        </td>
        <td>
            <asp:DropDownList ID="hangye" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            行政区域：
        </td>
        <td>
            <asp:DropDownList ID="quyu" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr height="25" id="ZcRow3" runat="server">
        <td>
            用户自定义分类：
        </td>
        <td colspan="3">
            <asp:CheckBoxList ID="userkind" runat="server" RepeatDirection="Vertical" RepeatColumns="3"
                Width="100%">
            </asp:CheckBoxList>
        </td>
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
            <asp:Button ID="Button1" runat="server" Text="查询资产" OnClick="Button1_Click" />
        </td>
    </tr>
</table>
