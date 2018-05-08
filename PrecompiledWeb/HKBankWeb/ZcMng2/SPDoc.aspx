<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_SpDoc, App_Web_0lscwnk0" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>长江资产公司不良贷款处置方案申报表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div align="center">
            <br />
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <tr height="30">
                    <td colspan="2" align="Center" bgcolor="#5d7b9d">
                        <strong><font color="#ffffff">不 良 贷 款 处 置 方 案 申 报 表</font></strong>
                    </td>
                </tr>
                <colgroup>
                    <col align="right" width="30%" />
                    <col align="left" />
                </colgroup>
                <tr height="30" bgcolor="white" id="Row1" runat="server">
                    <td>
                        <strong>下载模板：</strong></td>
                    <td>
                        <p style="line-height: 150%">
                            <a href="<%#Application["root"] %>/Common/Model/处置方案申报表.doc" target="_blank"
                                class="blue1">长江资产公司不良贷款处置方案申报表.doc</a>&nbsp; （提示：下载模板填写各栏信息保存到本地硬盘，然后将文件上传即可。）</p>
                    </td>
                </tr>
                <tr height="30" bgcolor="white" id="Row2" runat="server">
                    <td>
                        <strong>下载文件：</strong></td>
                    <td>
                        <a href="<%#Application["root"] %>/Common/AttachFiles/<%#AttachFileName%>" target="_blank"
                            class="blue1">长江资产公司不良贷款处置方案申报表.doc</a>
                    </td>
                </tr>
                <tr height="30" bgcolor="white" id="Row3" runat="server">
                    <td>
                        <strong>上传附件：</strong></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Height="22" Width="287px" CssClass="text" />&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="上传附件" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:HiddenField ID="OldFileName" runat="server" />
            <input id="Button2" type="button" value="关闭返回" class="but" onclick="window.close();" />
        </div>
    </form>
</body>
</html>
