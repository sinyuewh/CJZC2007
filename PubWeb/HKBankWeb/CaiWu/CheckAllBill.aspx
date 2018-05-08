<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_CaiWuIndex, App_Web_mm-bb4su" title="选择要审核的单据" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <tr height="25">
            <td colspan="1" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">请 选 择 要 审 核 的 单 据 类 别</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td bgcolor="#ffffff" align="center">
                <br />
                <a href="CheckShouKuanList.aspx" class="blue1">1．资产收款单据 </a>
                <br /><br />
                <a href="CheckPayList.aspx" class="blue1">2．资产支出单据</a>
                <br /><br />
                <a href="CheckInStockList.aspx" class="blue1">3．资产入库单据</a>
                <br /><br />
                <a href="CheckOutStockList.aspx" class="blue1">4．资产出库单据</a>  
                <br />
                <br />
                <a href="CheckShouKuanList1.aspx" class="blue1">5．资产包收款单据</a>  
                <br />
                <br />
                <a href="CheckPayList1.aspx" class="blue1">6．资产包支出单据</a>  
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
