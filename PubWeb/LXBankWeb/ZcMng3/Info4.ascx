<%@ control language="C#" autoeventwireup="true" inherits="ZcMng3_Info4, App_Web_-gbu33-0" %>
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" width="40%" />
        <col bgcolor="white" align="right" width="15%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="4" align="center" bgcolor="#5d7b9d">
            <strong><span style="color: #ffffff">6、决策委员会</span></strong></td>
    </tr>
    <tr height="25" id="Row1" runat="server">
        <td>
            会议时间：
        </td>
        <td>
            <asp:TextBox ID="hysj2" runat="server" onfocus="setday(this)"></asp:TextBox>
        </td>
        <td>
            会议地点：
        </td>
        <td>
            <asp:TextBox ID="hydd2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr height="25" id="Row2" runat="server">
        <td>
            到会委员情况：
        </td>
        <td>
            应到<asp:TextBox ID="yingdao2" runat="server" Width="30px"></asp:TextBox>人；实到
            <asp:TextBox ID="shidao2" runat="server" Width="30px"></asp:TextBox>人；缺席<asp:TextBox
                ID="quexi2" runat="server" Width="30px"></asp:TextBox>人</td>
        <td>
            主持人：
        </td>
        <td>
            <asp:TextBox ID="zcr2" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr height="25" id="Row3" runat="server">
        <td>
            会议时间：
        </td>
        <td>
            <asp:Label ID="hysj2_1" runat="server"></asp:Label>
        </td>
        <td>
            会议地点：
        </td>
        <td>
            <asp:Label ID="hydd2_1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr height="25" id="Row4" runat="server">
        <td>
            到会委员情况：
        </td>
        <td>
            应到<asp:Label ID="yingdao2_1" runat="server"></asp:Label>人；实到
            <asp:Label ID="shidao2_1" runat="server"></asp:Label>人；缺席<asp:Label
                ID="quexi2_1" runat="server"></asp:Label>人</td>
        <td>
            主持人：
        </td>
        <td>
            <asp:Label ID="TextBox6" runat="server"></asp:Label>
        </td>
    </tr>
    
    <tr height="25">
        <td>
            赞同委员：
        </td>
        <td colspan="3" height="50">
            <asp:Label ID="ztwy2" runat="server" Text=""></asp:Label></td>
    </tr>
    
    
    <tr height="25">
        <td>
            反对委员：
        </td>
        <td colspan="3" height="50">
            <asp:Label ID="fdwy2" runat="server" Text=""></asp:Label></td>
    </tr>
    
    <tr height="25">
        <td>
            未出席会议委员：
        </td>
        <td colspan="3" height="50">
            <asp:Label ID="wy3" runat="server" Text=""></asp:Label></td>
    </tr>
    
    
    <tr height="25">
        <td >
            决策意见：
        </td>
        <td colspan="3" valign="top">
            <table width="99%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="2%">
                    </td>
                    <td height="100" valign="top">
                        <asp:Label ID="shyj2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        决策委员会主任（签名）：<asp:Label ID="shren2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        <asp:Label ID="shsj2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
