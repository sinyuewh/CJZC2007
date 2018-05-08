<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_DangAn, App_Web_aj5ajsvo" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <span style="font-size: 12pt; font-weight: bold; letter-spacing: 2pt">档案管理</span>
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
                        <a href="<%#Application["root"]%>/DangAn/DangAnSearch.aspx">档案查询</a></td>
                </tr>
                
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/BorrowList.aspx">档案查阅申请单</a></td>
                </tr>
                
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/DangAnSearchLogList.aspx">档案查阅日志</a></td>
                </tr>
                
                
                <tr height="26" runat="server" id="DAG1">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/UploadDangAnFile.aspx">档案电子稿上传</a></td>
                </tr>
                
                <tr height="26" runat="server" id="DAG2">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/DangAnDepartManageList.aspx">部门档案管理员</a></td>
                </tr>
                
                
                <tr height="26" runat="server" id="AJM1" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/AddAnJuanInfo.aspx">新增资产案卷</a></td>
                </tr>
                
                <tr height="26" runat="server" id="AJM2" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/AnJuanWeiHu.aspx">资产案卷维护</a></td>
                </tr>
                
                <tr height="26" runat="server" id="AJM3" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/AddJieYue.aspx">文件借阅登记</a></td>
                </tr>
                
                <tr height="26" runat="server" id="AJM4" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/FileJieyue.aspx">借阅单维护</a></td>
                </tr>
                
                <tr height="26" runat="server" id="AJM5" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/AddPrint.aspx">文件复印登记</a></td>
                </tr>
                
                <tr height="26" runat="server" id="AJM6" visible="false">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/DangAn/Print.aspx">复印单维护</a></td>
                </tr>
                
            </table>
        </td>
    </tr>
</table>
