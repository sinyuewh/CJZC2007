<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_Juece, App_Web_g1yfc6zq" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <span style="font-size: 12pt; font-weight: bold; letter-spacing: 2pt">决策支持</span>
        </td>
    </tr>
    <tr>
        <td height="5" valign="bottom">
            <table align="center" width="99%" cellpadding="0" cellspacing="0">
                <tr>
                    <td bgcolor="gray" height="1">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="7" colspan="2">
                    </td>
                </tr>
                <colgroup>
                    <col align="center" width="17%" />
                    <col align="left" />
                </colgroup>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/st1.aspx">公司状态统计</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/st2.aspx">部门状态统计</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/StatByGSZC.aspx">公司资产统计</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/StatByStatus.aspx">高级资产统计</a></td>
                </tr>
                
                <tr>
                    <td colspan="2" bgcolor=DarkGray height="1">
                        
                    </td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <!--
                        <a href="<%#Application["root"]%>/JueCeZhiChi/TJ_FASP.aspx">方案审批统计</a>
                        -->
                        <a href="<%#Application["root"]%>/ZcMng3/TongJiFangAn.aspx">方案审批统计</a>
                        
                        </td>
                </tr>
                
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <!--
                        <a href="<%#Application["root"]%>/JueCeZhiChi/TJ_FAZX.aspx">方案执行统计</a>
                        -->
                        
                        <a href="<%#Application["root"]%>/ZcMng3/TongJiFangAn.aspx">方案审批统计</a>
                        </td>
                </tr>
                <tr height="26" id="ZC_Menu1" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/StatByUserkind.aspx">按自定义统计</a></td>
                </tr>
                <tr height="26" id="ZC_Menu2" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/StatBySX.aspx">按时效统计</a></td>
                </tr>
                <tr height="26" id="ZC_Menu3" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/StatByStatus.aspx">资产财务状态</a></td>
                </tr>
                
                
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/TJ_JZTC.aspx">尽职调查统计</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/TJ_HK.aspx">回款统计</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/TJ_ZhiChu.aspx">支出统计</a></td>
                </tr>
                
                 <tr>
                    <td colspan="2" bgcolor=DarkGray height="1">
                        
                    </td>
                </tr>
                 <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/JueCeZhiChi/TJ_ShiXiao.aspx">公司时效统计</a></td>
                </tr>
                
                
            </table>
        </td>
    </tr>
</table>
