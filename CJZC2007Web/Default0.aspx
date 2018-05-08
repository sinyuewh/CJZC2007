<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default0.aspx.cs" Title="长江资产管理公司不良资产管理平台"
    Inherits="Default1" StylesheetTheme="" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0 0 0 0;
            overflow: hidden;
        }
        img
        {
            margin: 0 0 0 0;
            border: }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 700px; background-image: url(images/top1.jpg); height: 95">
                            </td>
                            <td style="background: url(images/top2.jpg); text-align: right; padding-right: 30px;
                                vertical-align: top; padding-top: 50px;">
                                <a href="login.aspx?loginout=1">
                                    <img src="images/exit.jpg" /></a> &nbsp; <a href="login.aspx">
                                        <img src="images/signout.jpg" /></a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background: url(images/middle.jpg); height: 470px; text-align: center;">
                    <table style="width: 500px" border="0">
                        <tr>
                            <td style="text-align: center">
                                <a target="_blank" href='default.aspx'>
                                    <img src="images/img1.jpg" /></a>
                            </td>
                            <td style="text-align: center">
                                <a target="_blank" href='<%=HankBankUrl %>'>
                                    <img src="images/img2.jpg" /></a>
                            </td>
                            <td style="text-align: center">
                                <a target="_blank" href='<%=LxBankUrl %>'>
                                    <img src="images/img21.jpg" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table align="center">
                                    <tr>
                                        <td style="text-align: center">
                                            <a target="_blank" href='ZongHeSearch.aspx'>
                                                <img src="images/img3.jpg" /></a>
                                        </td>
                                        <td style="text-align: center">
                                            <a target="_blank" href='Info/InfoBrowse.aspx'>
                                                <img src="images/img4.jpg" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 100%; background: url(images/middle3.jpg);">
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 69px; background: url(images/bottom.jpg); text-align: center;
                    padding-top: 50px">
                    <img src="images/copyright.jpg" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
