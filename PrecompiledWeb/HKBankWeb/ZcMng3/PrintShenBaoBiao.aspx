<%@ page language="C#" autoeventwireup="true" inherits="ZcMng3_PrintShenBaoBiao, App_Web_ubawstme" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印项目申报表</title>
    <script language="javascript" src="../Common/Script/MyWord.js"></script>
</head>
<body style ="background-color:White" onload="word_onload();" onunload="word_onunload();">
    <form id="form1" runat="server">
        <div>
            <table cellspacing="1" cellpadding="1" width="98%" align="center" bgcolor="#c5c5c5"
                border="0">
                <tr>
                    <td align="center">
                        <object id="WebOffice1" style="left: 0px; top: 0px" codebase="WebOffice.ocx#V5,0,0,4"
                            height="700" width="98%" classid="clsid:E77E049B-23FC-4DB8-B756-60529A35FAD5">
                            <param name="_Version" value="65536">
                            <param name="_ExtentX" value="23204">
                            <param name="_ExtentY" value="21167">
                            <param name="_StockProps" value="0">
                        </object>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="wordUrl" runat="server" />
            <!--数据1-->
            <asp:HiddenField ID="xmsbh" runat="server" />
            <asp:HiddenField ID="num2" runat="server" />
            <asp:HiddenField ID="xmmc" runat="server" />
            <asp:HiddenField ID="zwdw" runat="server" />
            <asp:HiddenField ID="dbdw" runat="server" />
            <asp:HiddenField ID="zwzgbm" runat="server" />
            <asp:HiddenField ID="zqxx" runat="server" />
            <asp:HiddenField ID="zclx" runat="server" />
            <asp:HiddenField ID="zcse" runat="server" />
            <asp:HiddenField ID="jiazhi" runat="server" />
            <asp:HiddenField ID="zqze" runat="server" />
            <asp:HiddenField ID="benjin" runat="server" />
            <asp:HiddenField ID="lixi" runat="server" />
            <asp:HiddenField ID="xmbj" runat="server" />
            <!--数据2-->
            <asp:HiddenField ID="czfs1" runat="server" />
            <asp:HiddenField ID="czba1" runat="server" />
            <asp:HiddenField ID="czjg1" runat="server" />
            <asp:HiddenField ID="qcl1" runat="server" />
            <asp:HiddenField ID="czfs2" runat="server" />
            <asp:HiddenField ID="czba2" runat="server" />
            <asp:HiddenField ID="czjg2" runat="server" />
            <asp:HiddenField ID="qcl2" runat="server" />
            <asp:HiddenField ID="xgsxsm" runat="server" />
            <asp:HiddenField ID="bmyj" runat="server" />
            <asp:HiddenField ID="bmren" runat="server" />
            <asp:HiddenField ID="bmsj" runat="server" />
            <asp:HiddenField ID="cbbm" runat="server" />
            <asp:HiddenField ID="jbr" runat="server" />
            <asp:HiddenField ID="jbsj" runat="server" />
            <asp:HiddenField ID="psyyj" runat="server" />
            <asp:HiddenField ID="psyren" runat="server" />
            
            <asp:HiddenField ID="psysj" runat="server" />
            <!--审核委员会议-->
            <asp:HiddenField ID="hysj1" runat="server" />
            <asp:HiddenField ID="hydd1" runat="server" />
            <asp:HiddenField ID="yingdao1" runat="server" />
            <asp:HiddenField ID="shidao1" runat="server" />
            <asp:HiddenField ID="quexi1" runat="server" />
            <asp:HiddenField ID="zcr1" runat="server" />
            <asp:HiddenField ID="ztwy1" runat="server" />
            <asp:HiddenField ID="fdwy1" runat="server" />
            <asp:HiddenField ID="shyj1" runat="server" />
            <asp:HiddenField ID="shren1" runat="server" />
            <asp:HiddenField ID="shsj1" runat="server" />
                        
             <!--决策委员会议-->
            <asp:HiddenField ID="hysj2" runat="server" />
            <asp:HiddenField ID="hydd2" runat="server" />
            <asp:HiddenField ID="yingdao2" runat="server" />
            <asp:HiddenField ID="shidao2" runat="server" />
            <asp:HiddenField ID="quexi2" runat="server" />
            <asp:HiddenField ID="zcr2" runat="server" />
            <asp:HiddenField ID="ztwy2" runat="server" />
            <asp:HiddenField ID="fdwy2" runat="server" />
            <asp:HiddenField ID="shyj2" runat="server" />
            <asp:HiddenField ID="shren2" runat="server" />
            <asp:HiddenField ID="shsj2" runat="server" />
            
        </div>
    </form>
</body>
</html>
