<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_MainLeft, App_Web_g1yfc6zq" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <span style="font-size: 12pt; font-weight: bold; letter-spacing: 2pt">资产现状</span>
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
                
                <!--公司领导权限-->
                <tr height="26" id="ZC_LEADER1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ZongHeSearch.aspx">资产综合查询</a></td>
                </tr>
                <tr height="26" id="ZC_LEADER3" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ZcBaoZongHeSearch.aspx">资产包综合查询</a></td>
                </tr>
                <!--公司领导权限-->
                
                
                <!--系统管理员权限-->
                <tr height="26" id="ZC_SYS4" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/FixZcUserKind.aspx">调整资产用户自定义分类</a></td>
                </tr>
                
                <!--新增的法律顾问资产浏览权限-->
                 <tr height="26" id="ZC_SYS7" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/FixLawGwList.aspx">分配法律顾问权限</a></td>
                </tr>
                
                <tr height="26" id="ZC_LAW1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/LawGwList.aspx">法律顾问浏览资产</a></td>
                </tr>
                
                <tr height="26" id="ZC_LAW2" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/LawGwBaoList.aspx">法律顾问浏览资产包</a></td>
                </tr>
                
                <tr height="26" id="ZC_SYS1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/AddZC.aspx">新增资产数据</a></td>
                </tr>
                <tr height="26" id="ZC_SYS5" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ZcBaoGL.aspx">资产包管理</a></td>
                </tr>
                <tr height="26" id="ZC_SYS6" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/FixZcBao.aspx">资产打包</a></td>
                </tr>
                <tr height="26" id="ZC_SYS2" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ZiChangFengPei.aspx">将资产落实到责任人</a></td>
                </tr>
                <tr height="26" id="ZC_SYS3" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/FixZeren.aspx">调整资产责任人</a></td>
                </tr>
                <!--系统管理员权限-->
                
                <!--个人权限-->
                <tr height="26" id="ZC_GR1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyZc.aspx">我负责的资产</a></td>
                </tr>
                
                <tr height="26" id="ZC_GR1_1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyZc1.aspx">我协办的资产</a></td>
                </tr>
                
                <tr height="26" id="ZC_GR2" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyZcBao.aspx">我负责的资产包</a></td>
                </tr>
                
                <tr height="26" id="ZC_GR2_1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyZcBaoList1.aspx">我协办的资产包</a></td>
                </tr>
                
                <tr height="26" id="ZC_GR3" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyFixZcUserKind.aspx">调整我负责资产自定义分类</a></td>
                </tr>
                <tr height="26" id="ZC_SP1" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ShenPiZcIng.aspx">需要我审批的资产</a></td>
                </tr>
                <tr height="26" id="ZC_SP2" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ShenPiZcBIng.aspx">需要我审批的资产包</a></td>
                </tr>
                <tr height="26" id="ZC_SP3" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ShenPiZcDone.aspx">我审批过的资产</a></td>
                </tr>
                <tr height="26" id="ZC_SP4" runat="server" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ShenPiZcBDone.aspx">我审批过的资产包</a></td>
                </tr>
                <tr height="26" id="ZC_GR4" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyZcTime0.aspx">我的资产时效警告</a></td>
                </tr>
                <tr height="26" id="ZC_GR5" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/TJ_ShiXiao.aspx">我的资产时效统计</a></td>
                </tr>
                <!--个人权限-->
                
                
                <!--部门领导权限-->
                <tr height="26" id="ZC_Depart1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyDepartZc.aspx">我部门负责的资产</a></td>
                </tr>
                
                 <tr height="26" id="ZC_Depart3" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyDepartZcBao.aspx">我部门负责的资产包</a></td>
                </tr>
                
                <tr height="26" id="ZC_Depart2" runat="server" >
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/MyDepartZcTime0.aspx">我部门的资产时效警告</a></td>
                </tr>
                <!--部门领导权限-->
                
                
                <!--公司领导权限-->
                <tr height="26" id="ZC_LEADER2" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/ZcMng1/ZCDirectoryInfo.aspx">下载资产系列文件</a></td>
                </tr>
                 <!--公司领导权限-->
            </table>
        </td>
    </tr>
</table>
