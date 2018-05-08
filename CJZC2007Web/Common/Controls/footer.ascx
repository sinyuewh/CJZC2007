<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Common_Controls_footer" %>

<script language="javascript">
    function ModifyPwd()
    {
       var url="<%#Application["root"]%>/XtGL/ModifyPass.aspx";
        window.open(url,"","top=250,left=350,width=400,height=150");
    }
    
    function ShowLoginRemainder()
    {
        top.location.href="<%#Application["root"]%>/default.aspx";
        //winOpenOfen("<%#Application["root"]%>/StartReminder.aspx",300,200)
    }
</script>

<table width="100%" height="25" border="0" cellpadding="2" cellspacing="0" bgcolor="#000000"
    align="center">
    <tr>
        <td width="40%" align="left" style="height: 19px">
            <font color="#ffffff">&nbsp;长江资产公司不良资产管理平台—政策性不良资产包 </font>
        </td>
        <td align="right" style="height: 19px">
            <font color="#ffffff">
                <img id="Img1" src="<%#Application["root"] %>/Common/Image/corp/i.gif" width="15"
                    height="15" hspace="2" align="absMiddle"><a href="javascript:ShowLoginRemainder();"
                        class="white" target="_self"><font color="#ffffff">登录提示</font></a>&nbsp;&nbsp;
                <img id="Img6" src="<%#Application["root"] %>/Common/Image/corp/i.gif" width="15"
                    height="15" hspace="2" align="absMiddle"><a href="javascript:ModifyPwd();" class="white"
                        target="_self"><font color="#ffffff">修改密码</font></a>&nbsp;&nbsp;
                <img id="Img7" src="<%#Application["root"] %>/Common/Image/corp/i.gif" width="15"
                    height="15" hspace="2" align="absMiddle"><asp:LinkButton ID="budRelogin" runat="server"
                        CssClass="white" CausesValidation="false" OnClick="budRelogin_Click"><font color="#ffffff">重新登陆</font></asp:LinkButton>&nbsp;&nbsp;
            </font>
            <iframe src="<%#Application["root"] %>/AutoFresh.aspx" width="0" height="0"></iframe>
            <iframe src="<%#Application["root"] %>/AutoMessage.aspx" width="0" height="0"></iframe>
        </td>
    </tr>
</table>
