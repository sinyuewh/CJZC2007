<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_Info, App_Web_pnvmybnf" %>

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <span style="font-size: 12pt; font-weight: bold; letter-spacing: 2pt">咨询平台</span>
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
                        <a href="<%#Application["root"]%>/Info/InfoBrowse.aspx">信息浏览查询</a></td>
                </tr>
                
                <tr height="26" id="ZX_menu0" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Info/InsertInfo.aspx">发布新信息</a></td>
                </tr>
                
                
                <tr height="26" id="ZX_menu1" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Info/InfoMaintenance.aspx">信息维护管理</a></td>
                </tr>
                
                
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Info/WriteMail.aspx">撰写新邮件</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Info/ReceiveMail.aspx">我的收件箱</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Info/SendMail.aspx">我的发件箱</a></td>
                </tr>
                 
            </table>
        </td>
    </tr>
</table>
