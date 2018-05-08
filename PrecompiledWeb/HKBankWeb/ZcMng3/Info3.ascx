<%@ control language="C#" autoeventwireup="true" inherits="ZcMng3_Info3, App_Web_ubawstme" %>
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" width="40%" />
        <col bgcolor="white" align="right" width="15%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="4" align="center" bgcolor="#5d7b9d">
            <strong><span style="color: #ffffff">5、审核委员会</span></strong></td>
    </tr>
    <tr height="25" id="row1" runat="server">
        <td>
            会议时间：
        </td>
        <td>
            <asp:TextBox ID="hysj1" runat="server" onfocus="setday(this)"></asp:TextBox>
        </td>
        <td>
            会议地点：
        </td>
        <td>
            <asp:TextBox ID="hydd1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr height="25" id="row1_1" runat="server">
        <td>
            会议时间：
        </td>
        <td>
            <asp:Label ID="hysj1_1" runat="server"></asp:Label>
        </td>
        <td>
            会议地点：
        </td>
        <td>
            <asp:Label ID="hydd1_1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr height="25" id="row2" runat="server">
        <td>
            到会委员情况：
        </td>
        <td>
            应到<asp:TextBox ID="yingdao1" runat="server" Width="30px"></asp:TextBox>人；实到
            <asp:TextBox ID="shidao1" runat="server" Width="30px"></asp:TextBox>人；缺席<asp:TextBox
                ID="quexi1" runat="server" Width="30px"></asp:TextBox>人</td>
        <td>
            主持人：
        </td>
        <td>
            <asp:TextBox ID="zcr1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr height="25" id="row2_1" runat="server">
        <td>
            到会委员情况：
        </td>
        <td>
            应到<asp:Label ID="yingdao1_1" runat="server"></asp:Label>人；实到
            <asp:Label ID="shidao1_1" runat="server"></asp:Label>人；缺席<asp:Label ID="quexi1_1"
                runat="server"></asp:Label>人</td>
        <td>
            主持人：
        </td>
        <td>
            <asp:Label ID="zcr1_1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr height="25">
        <td>
            赞同委员：
        </td>
        <td colspan="3" height="50">
            <asp:Label ID="ztwy1" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr height="25">
        <td>
            反对委员：
        </td>
        <td colspan="3" height="50">
            <asp:Label ID="fdwy1" runat="server" Text=""></asp:Label></td>
    </tr>
    
    <tr height="25">
        <td>
            未出席会议委员：
        </td>
        <td colspan="3" height="50">
            <asp:Label ID="wy3" runat="server" Text=""></asp:Label></td>
    </tr>
    
    <tr height="25">
        <td>
            审核意见：
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
                        <asp:Label ID="shyj1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        审核委员会主任（签名）：<asp:Label ID="shren1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        <asp:Label ID="shsj1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
