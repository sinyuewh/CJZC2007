<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZcDetail11.aspx.cs" Inherits="ZcMng2_ZcDetail11" %>

<%-- 在此处添加内容控件 --%>
<%@ Register Src="~/ZcMng2/ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

    function Button2_onclick() 
    {
        url="Zcdbqkb.aspx?zcid=<%#Request["id"]%>";    
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }

// ]]>
    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" width="30%" />
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" width="30%" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 诉 讼 情 况</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                诉讼状态：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="sszt" runat="server">
                    <asp:ListItem Text="未诉讼" Value="未诉讼"></asp:ListItem>
                    <asp:ListItem Text="一审中" Value="一审中"></asp:ListItem>
                    <asp:ListItem Text="一审终结" Value="一审终结"></asp:ListItem>
                    <asp:ListItem Text="一审撤诉" Value="一审撤诉"></asp:ListItem>
                    <asp:ListItem Text="二审中" Value="二审中"></asp:ListItem>
                    <asp:ListItem Text="二审终结" Value="二审终结"></asp:ListItem>
                    <asp:ListItem Text="二审撤诉" Value="二审撤诉"></asp:ListItem>
                    <asp:ListItem Text="败诉" Value="败诉"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="sszt_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                执行状态：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="zxzt" runat="server">
                    <asp:ListItem Text="未执行" Value="未执行"></asp:ListItem>
                    <asp:ListItem Text="执行中" Value="执行中"></asp:ListItem>
                    <asp:ListItem Text="执行中止" Value="执行中止"></asp:ListItem>
                    <asp:ListItem Text="执行终结" Value="执行终结"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="zxzt_1" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                诉讼资料：
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="sszl" TextMode="MultiLine" Height="60" runat="server" Width ="90%"></asp:TextBox>
                <asp:Label ID="sszl_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <!--Other Info -->
        <tr height="25">
            <td>
                最后中断诉讼时效时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="最后中断诉讼时效时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="最后中断诉讼时效时间" runat="server"></asp:TextBox>
            </td>
            <td>
                诉讼时效到期日：
            </td>
            <td>
                &nbsp;<asp:Label ID="诉讼时效到期日_1" runat="server"></asp:Label>
                <asp:TextBox ID="诉讼时效到期日" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                最后中断保证时效时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="最后中断保证时效时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="最后中断保证时效时间" runat="server"></asp:TextBox>
            </td>
            <td>
                保证时效到期日：
            </td>
            <td>
                &nbsp;<asp:Label ID="保证时效到期日_1" runat="server"></asp:Label>
                <asp:TextBox ID="保证时效到期日" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                时效中断方式：
            </td>
            <td>
                &nbsp;<asp:Label ID="时效中断方式_1" runat="server"></asp:Label>
                <asp:TextBox ID="时效中断方式" runat="server"></asp:TextBox>
            </td>
            <td>
                执行时效到期日：
            </td>
            <td>
                &nbsp;<asp:Label ID="执行时效到期日_1" runat="server"></asp:Label>
                <asp:TextBox ID="执行时效到期日" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                查封时效到期日：
            </td>
            <td>
                &nbsp;<asp:Label ID="查封时效到期日_1" runat="server"></asp:Label>
                <asp:TextBox ID="查封时效到期日" runat="server"></asp:TextBox>
            </td>
            <td>
                查封文字描述：
            </td>
            <td>
                &nbsp;<asp:Label ID="查封文字描述_1" runat="server"></asp:Label>
                <asp:TextBox ID="查封文字描述" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                是否破产：
            </td>
            <td>
                &nbsp;<asp:Label ID="是否破产_1" runat="server"></asp:Label>
                <asp:TextBox ID="是否破产" runat="server"></asp:TextBox>
            </td>
            <td>
                宣告破产裁定书文号：
            </td>
            <td>
                &nbsp;<asp:Label ID="宣告破产裁定书文号_1" runat="server"></asp:Label>
                <asp:TextBox ID="宣告破产裁定书文号" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                破产审理法院：
            </td>
            <td>
                &nbsp;<asp:Label ID="破产审理法院_1" runat="server"></asp:Label>
                <asp:TextBox ID="破产审理法院" runat="server"></asp:TextBox>
            </td>
            <td>
                破产审理法官：
            </td>
            <td>
                &nbsp;<asp:Label ID="破产审理法官_1" runat="server"></asp:Label>
                <asp:TextBox ID="破产审理法官" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                破产债权申报时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="破产债权申报时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="破产债权申报时间" runat="server"></asp:TextBox>
            </td>
            <td>
                破产申报债权金额：
            </td>
            <td>
                &nbsp;<asp:Label ID="破产申报债权金额_1" runat="server"></asp:Label>
                <asp:TextBox ID="破产申报债权金额" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                破产终结日：
            </td>
            <td>
                &nbsp;<asp:Label ID="破产终结日_1" runat="server"></asp:Label>
                <asp:TextBox ID="破产终结日" runat="server"></asp:TextBox>
            </td>
            <td>
                终结破产裁定文书号：
            </td>
            <td>
                &nbsp;<asp:Label ID="终结破产裁定文书号_1" runat="server"></asp:Label>
                <asp:TextBox ID="终结破产裁定文书号" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                分配财产金额：
            </td>
            <td colspan="3">
                &nbsp;<asp:Label ID="分配财产金额_1" runat="server"></asp:Label>
                <asp:TextBox ID="分配财产金额" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                起诉时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="起诉时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="起诉时间" runat="server"></asp:TextBox>
            </td>
            <td>
                上诉时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="上诉时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="上诉时间" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                申请执行时间：
            </td>
            <td colspan="3">
                &nbsp;<asp:Label ID="申请执行时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="申请执行时间" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                一审法院：
            </td>
            <td>
                &nbsp;<asp:Label ID="一审法院_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审法院" runat="server"></asp:TextBox>
            </td>
            <td>
                一审代理人：
            </td>
            <td>
                &nbsp;<asp:Label ID="一审代理人_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审代理人" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                一审主审法官：
            </td>
            <td>
                &nbsp;<asp:Label ID="一审主审法官_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审主审法官" runat="server"></asp:TextBox>
            </td>
            <td>
                联系方式：
            </td>
            <td>
                &nbsp;<asp:Label ID="联系方式1_1" runat="server"></asp:Label>
                <asp:TextBox ID="联系方式1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                一审代理律师：
            </td>
            <td>
                &nbsp;<asp:Label ID="一审代理律师_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审代理律师" runat="server"></asp:TextBox>
            </td>
            <td>
                联系方式：
            </td>
            <td>
                &nbsp;<asp:Label ID="联系方式2_1" runat="server"></asp:Label>
                <asp:TextBox ID="联系方式2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                一审判决书文号：
            </td>
            <td>
                &nbsp;<asp:Label ID="一审判决书文号_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审判决书文号" runat="server"></asp:TextBox>
            </td>
            <td>
                一审判决时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="一审判决时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审判决时间" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                一审判决金额：
            </td>
            <td colspan="3">
                &nbsp;<asp:Label ID="一审判决金额_1" runat="server"></asp:Label>
                <asp:TextBox ID="一审判决金额" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                二审法院：
            </td>
            <td>
                &nbsp;<asp:Label ID="二审法院_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审法院" runat="server"></asp:TextBox>
            </td>
            <td>
                二审代理人：
            </td>
            <td>
                &nbsp;<asp:Label ID="二审代理人_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审代理人" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                二审主审法官：
            </td>
            <td>
                &nbsp;<asp:Label ID="二审主审法官_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审主审法官" runat="server"></asp:TextBox>
            </td>
            <td>
                联系方式：
            </td>
            <td>
                &nbsp;<asp:Label ID="联系方式3_1" runat="server"></asp:Label>
                <asp:TextBox ID="联系方式3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                二审代理律师：
            </td>
            <td>
                &nbsp;<asp:Label ID="二审代理律师_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审代理律师" runat="server"></asp:TextBox>
            </td>
            <td>
                联系方式：
            </td>
            <td>
                &nbsp;<asp:Label ID="联系方式4_1" runat="server"></asp:Label>
                <asp:TextBox ID="联系方式4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                二审判决书文号：
            </td>
            <td>
                &nbsp;<asp:Label ID="二审判决书文号_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审判决书文号" runat="server"></asp:TextBox>
            </td>
            <td>
                二审判决时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="二审判决时间_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审判决时间" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                二审判决金额：
            </td>
            <td colspan="3">
                &nbsp;<asp:Label ID="二审判决金额_1" runat="server"></asp:Label>
                <asp:TextBox ID="二审判决金额" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                执行法院：
            </td>
            <td>
                &nbsp;<asp:Label ID="执行法院_1" runat="server"></asp:Label>
                <asp:TextBox ID="执行法院" runat="server"></asp:TextBox>
            </td>
            <td>
                执行法官：
            </td>
            <td>
                &nbsp;<asp:Label ID="执行法官_1" runat="server"></asp:Label>
                <asp:TextBox ID="执行法官" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                联系方式：
            </td>
            <td>
                &nbsp;<asp:Label ID="联系方式5_1" runat="server"></asp:Label>
                <asp:TextBox ID="联系方式5" runat="server"></asp:TextBox>
            </td>
            <td>
                备注：
            </td>
            <td>
                &nbsp;<asp:Label ID="备注_1" runat="server"></asp:Label>
                <asp:TextBox ID="备注" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
        <tr height="30">
            <td align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
               <%-- &nbsp;&nbsp;&nbsp;&nbsp;--%>
                <input id="Button2" runat="server" type="button" value="打印资产担保情况" class="but" onclick="return Button2_onclick()" visible ="false" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
