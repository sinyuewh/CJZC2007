<%@ page language="C#" autoeventwireup="true" enabletheming="false" inherits="ZcMng1_PrintWord, App_Web_-yo2hwel" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打印不良资产项目处置方案申报表</title>
</head>
<body style ="background-color:White" onload="word_onload();" onunload="word_onunload();">
    <script language="javascript" src="../Common/Script/MyWord.js"></script>
    <form id="form1" runat="server">
        <div>
            <table cellSpacing="1" cellPadding="1" width="900" align="center" bgColor="#c5c5c5" border="0">
				<tr >
					<td align="center">
						<OBJECT id="WebOffice1" style="LEFT: 0px; TOP: 0px" codeBase="WebOffice.ocx#V5,0,0,4" height="800"
							width="98%" classid="clsid:E77E049B-23FC-4DB8-B756-60529A35FAD5">
							<PARAM NAME="_Version" VALUE="65536">
							<PARAM NAME="_ExtentX" VALUE="23204">
							<PARAM NAME="_ExtentY" VALUE="21167">
							<PARAM NAME="_StockProps" VALUE="0">
						</OBJECT>
					</td>
				</tr>
			</table>
     </div>
        <asp:HiddenField ID="wordurl" runat="server" />
        <asp:HiddenField ID="wordurl1" runat="server" />
        <asp:HiddenField ID="xmsbh" runat="server" />
        <asp:HiddenField ID="num2" runat="server" />
        <asp:HiddenField ID="danwei" runat="server" />
        <asp:HiddenField ID="xmbj" runat="server" />
        <asp:HiddenField ID="zclx" runat="server" />
        <asp:HiddenField ID="zcse" runat="server" />
        <asp:HiddenField ID="zqze" runat="server" />
        
        <asp:HiddenField ID="czfs1" runat="server" />
        <asp:HiddenField ID="czjg1" runat="server" />
        <asp:HiddenField ID="czss1" runat="server" />
        <asp:HiddenField ID="qcl1" runat="server" />
        <asp:HiddenField ID="yjfy1" runat="server" />
        
        <asp:HiddenField ID="czfs2" runat="server" />
        <asp:HiddenField ID="czjg2" runat="server" />
        <asp:HiddenField ID="czss2" runat="server" />
        <asp:HiddenField ID="qcl2" runat="server" />
        <asp:HiddenField ID="yjfy2" runat="server" />
        
        <asp:HiddenField ID="czfs3" runat="server" />
        <asp:HiddenField ID="czjg3" runat="server" />
        <asp:HiddenField ID="czss3" runat="server" />
        <asp:HiddenField ID="qcl3" runat="server" />
        <asp:HiddenField ID="yjfy3" runat="server" />
        
        <asp:HiddenField ID="czfs4" runat="server" />
        <asp:HiddenField ID="czjg4" runat="server" />
        <asp:HiddenField ID="czss4" runat="server" />
        <asp:HiddenField ID="qcl4" runat="server" />
        <asp:HiddenField ID="yjfy4" runat="server" />
        
        <asp:HiddenField ID="czfs5" runat="server" />
        <asp:HiddenField ID="czjg5" runat="server" />
        <asp:HiddenField ID="czss5" runat="server" />
        <asp:HiddenField ID="qcl5" runat="server" />
        <asp:HiddenField ID="yjfy5" runat="server" />
        
        <asp:HiddenField ID="fsxzly" runat="server" />
        <asp:HiddenField ID="djyj" runat="server" />
        <asp:HiddenField ID="bmremark" runat="server" />
        <asp:HiddenField ID="cbdepart" runat="server" />
        <asp:HiddenField ID="zeren1" runat="server" />
        <asp:HiddenField ID="time1" runat="server" />
        <asp:HiddenField ID="time2" runat="server" />
        
        <asp:HiddenField ID="yj1" runat="server" />
        <asp:HiddenField ID="yj2" runat="server" />
        <asp:HiddenField ID="yj3" runat="server" />
        <asp:HiddenField ID="yj4" runat="server" />
    </form>
</body>
</html>
