<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_Caiwu, App_Web_pnvmybnf" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <span style="font-size: 12pt; font-weight: bold; letter-spacing: 2pt">财务中心</span>
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
                <tr height="26" id="ZCCWKP" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/ZcSearch.aspx">资产财务开票</a></td>
                </tr>
                <tr height="26" id="ZCBCWKP" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/ZcBaoSearch.aspx">资产包财务开票</a></td>
                </tr>
                <tr height="26" id="DJSH" runat="server">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/CheckAllBill.aspx">单据审核</a></td>
                </tr>
                <tr height="26"  style="display:none;">
                    <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/treeOpen.GIF"
                            OnClick="ImageButton1_Click" />
                    </td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/BillSearch1.aspx" title="包括资产和资产包">单据浏览</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/BillSearch.aspx">资产单据浏览</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/ZcBaoBillSearch.aspx">资产包单据浏览</a></td>
                </tr>
                <tr height="26">
                    <td>
                        <img src="<%#Application["root"]%>/Common/image/Corp/Arrow.GIF" width="14" height="17"></td>
                    <td>
                        <a href="<%#Application["root"]%>/Caiwu/StockSearch.aspx">库存浏览</a></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
