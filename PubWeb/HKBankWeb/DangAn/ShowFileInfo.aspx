<%@ page language="C#" autoeventwireup="true" inherits="DangAn_ShowFileInfo, App_Web_dq1vueyh" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="right" width="18%" />
                    <col bgcolor="white" align="left" width="32%" />
                    <col bgcolor="white" align="right" width="18%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25">
                    <td colspan="4" align="center" bgcolor="#5d7b9d">
                        <strong><font color="#ffffff">文 件 详 细 信 息</font></strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        案卷编号：</td>
                    <td>
                        <asp:Label ID="ajnum" runat="server"></asp:Label></td>
                    <%--<td>
                        文&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
                    <td>
                        <asp:Label ID="fileno" runat="server"></asp:Label></td>--%>
                    <td>
                        文件名称：
                    </td>
                    <td>
                        <asp:Label ID="title" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        文件内容：</td>
                    <td>
                        <asp:Label ID="remark" runat="server"></asp:Label></td>
                    <td>
                        单位名称：</td>
                    <td>
                        <asp:Label ID="danwei" runat="server"></asp:Label></td>
                </tr>
                <tr height="25" style="display:none">
                    <td>
                        责任部门：</td>
                    <td>
                        <asp:Label ID="depart" runat="server"></asp:Label></td>
                    <td>
                        责 任 人：</td>
                    <td>
                        <asp:Label ID="zeren" runat="server"></asp:Label></td>
                </tr>
                <tr height="25">
                    <%--<td>
                        卷内顺序：</td>
                    <td>
                        <asp:Label ID="filenum" runat="server"></asp:Label></td>--%>
                    <td>
                        文件页数：</td>
                    <td>
                        <asp:Label ID="filecount" runat="server"></asp:Label></td>
                    <td>
                        文件份数：
                    </td>
                    <td>
                        <asp:Label ID="filefs" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25" align="center" bgcolor="gainsboro">
                    <td colspan="4" width="100%" style="text-align: center">
                        <b>借 阅 信 息</b></td>
                </tr>
                <tr height="25">
                    <td>
                        借 阅 人：</td>
                    <td>
                        <asp:Label ID="jyue" runat="server"></asp:Label></td>
                    <td>
                        借出时间：</td>
                    <td>
                        <asp:Label ID="jyuetime" runat="server"></asp:Label></td>
                </tr>
                <tr height="25">
                    <td>
                        登记时间：</td>
                    <td>
                        <asp:Label ID="djtime" runat="server"></asp:Label></td>
                    <td>
                        登 记 人：</td>
                    <td>
                        <asp:Label ID="dtmen" runat="server"></asp:Label></td>
                </tr>
                <tr height="30">
                    <td colspan="4" align="center">
                        <input id="Button1" type="button" value="关闭返回" class="but" onclick="window.close();" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
