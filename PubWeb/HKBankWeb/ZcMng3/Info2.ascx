<%@ control language="C#" autoeventwireup="true" inherits="ZcMng3_Info2, App_Web_pyuhrx5l" %>
<div id="tab1" runat="server">
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="2" align="center" bgcolor="#5d7b9d">
            <strong><span style="color: #ffffff">2、处 置 方 案</span></strong></td>
    </tr>
    <tr height="25">
        <td>
            方案一：
        </td>
        <td align="left">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#c5c5c5">
                <colgroup>
                    <col width="18%" align="right" bgcolor="white" />
                    <col align="left" bgcolor="white" />
                </colgroup>
                <tr >
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置方式：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        <asp:TextBox ID="czfs1" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        具体办法：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        <asp:TextBox ID="jtfa1" runat="server" TextMode="multiLine" Height="65px" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置价格：</td>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        <asp:TextBox ID="czjg1" runat="server" Width="400px"></asp:TextBox>
                        （万元）</td>
                </tr>
                <tr>
                    <td>
                        清偿率：</td>
                    <td>
                        <asp:TextBox ID="qcl1" runat="server" Width="400px"></asp:TextBox>
                        （％）</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="25">
        <td>
            方案二：
        </td>
        <td align="left">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#c5c5c5">
                <colgroup>
                    <col width="18%" align="right" bgcolor="white" />
                    <col align="left" bgcolor="white" />
                </colgroup>
                <tr>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置方式：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        <asp:TextBox ID="czfs2" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        具体办法：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        <asp:TextBox ID="jtfa2" runat="server" TextMode="multiLine" Height="65px" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置价格：</td>
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        <asp:TextBox ID="czjg2" runat="server" Width="400px"></asp:TextBox>
                        （万元）</td>
                </tr>
                <tr>
                    <td>
                        清偿率：</td>
                    <td>
                        <asp:TextBox ID="qcl2" runat="server" Width="400px"></asp:TextBox>
                        （％）</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="25">
        <td>
            定价依据：
        </td>
        <td>
            <asp:TextBox ID="djyj" runat="server" TextMode="MultiLine" Width="86%" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr height="25">
        <td>
            方式选择理由：
        </td>
        <td>
            <asp:TextBox ID="fsxzly" runat="server" TextMode="MultiLine" Width="86%" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr height="25">
        <td>
            相关事项说明：
        </td>
        <td>
            <asp:TextBox ID="xgsx" runat="server" TextMode="MultiLine" Width="86%" Height="60px"></asp:TextBox>
        </td>
    </tr>
     <tr height="25" id="Row1" runat="server">
        <td >
            部门负责人意见：
        </td>
        <td valign="top">
            <table width="99%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="2%">
                    </td>
                    <td height="40" valign="top">
                        <asp:Label ID="yj1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        部门负责人（签名）：<asp:Label ID="ren1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        <asp:Label ID="time1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="25" id="Row2" runat="server">
        <td >
            评审员意见：
        </td>
        <td valign="top">
            <table width="99%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="2%">
                    </td>
                    <td height="40" valign="top">
                        <asp:Label ID="yj2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        评审员（签名）：<asp:Label ID="ren2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        <asp:Label ID="time2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                        <asp:HiddenField ID="czid" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>

<div id="tab2" runat="server">
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="2" align="center" bgcolor="#5d7b9d">
            <strong><span style="color: #ffffff">2、处 置 方 案</span></strong></td>
    </tr>
    <tr height="25">
        <td>
            方案一：
        </td>
        <td align="left">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#c5c5c5">
                <colgroup>
                    <col width="18%" align="right" bgcolor="white" />
                    <col align="left" bgcolor="white" />
                </colgroup>
                <tr height="25">
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置方式：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5;border-Left: solid 1pt #c5c5c5" >
                        &nbsp;<asp:Label ID="czfs1_1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        具体办法：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5;border-Left: solid 1pt #c5c5c5">
                        &nbsp;<asp:Label ID="jtfa1_1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置价格：</td>
                    <td style="border-bottom: solid 1pt #c5c5c5;border-Left: solid 1pt #c5c5c5">
                        &nbsp;<asp:Label ID="czjg1_1" runat="server"></asp:Label>
                        （万元）</td>
                </tr>
                <tr height="25">
                    <td>
                        清偿率：</td>
                    <td style="border-Left: solid 1pt #c5c5c5">
                        <asp:Label ID="qcl1_1" runat="server"></asp:Label>
                        （％）</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="25">
        <td>
            方案二：
        </td>
        <td align="left">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#c5c5c5">
                <colgroup>
                    <col width="18%" align="right" bgcolor="white" />
                    <col align="left" bgcolor="white" />
                </colgroup>
                <tr height="25">
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置方式：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5;border-Left: solid 1pt #c5c5c5">
                        <asp:Label ID="czfs2_1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        具体办法：
                    </td>
                    <td style="border-bottom: solid 1pt #c5c5c5;border-Left: solid 1pt #c5c5c5">
                        <asp:Label ID="jtfa2_1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td style="border-bottom: solid 1pt #c5c5c5">
                        处置价格：</td>
                    <td style="border-bottom: solid 1pt #c5c5c5;border-Left: solid 1pt #c5c5c5">
                        <asp:Label ID="czjg2_1" runat="server"></asp:Label>
                        （万元）</td>
                </tr>
                <tr height="25">
                    <td>
                        清偿率：</td>
                    <td style="border-Left: solid 1pt #c5c5c5">
                        <asp:Label ID="qcl2_1" runat="server"></asp:Label>
                        （％）</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="25">
        <td>
            定价依据：
        </td>
        <td>
            <asp:Label ID="djyj_1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr height="25">
        <td>
            方式选择理由：
        </td>
        <td>
            <asp:Label ID="fsxzly_1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr height="25">
        <td>
            相关事项说明：
        </td>
        <td>
            <asp:Label ID="xgsx_1" runat="server"></asp:Label>
        </td>
    </tr>
     <tr height="25" id="Tr1" runat="server">
        <td >
            部门负责人意见：
        </td>
        <td valign="top">
            <table width="99%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="2%">
                    </td>
                    <td height="40" valign="top">
                        <asp:Label ID="yj1_1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        部门负责人（签名）：<asp:Label ID="ren1_1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        <asp:Label ID="time1_1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="25" id="Tr2" runat="server">
        <td >
            评审员意见：
        </td>
        <td valign="top">
            <table width="99%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="2%">
                    </td>
                    <td height="40" valign="top">
                        <asp:Label ID="yj2_1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        评审员（签名）：<asp:Label ID="ren2_1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" height="30" style="text-align: right">
                        <asp:Label ID="time2_1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>
