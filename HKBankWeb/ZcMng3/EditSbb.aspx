<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true"
    CodeFile="EditSbb.aspx.cs" Inherits="ZcMng3_AddSbb" Title="项目处置方案申报表详细信息" %>

<%@ Register Src="info5.ascx" TagName="info5" TagPrefix="uc6" %>
<%@ Register Src="info6.ascx" TagName="info6" TagPrefix="uc7" %>
<%@ Register Src="Info4.ascx" TagName="Info4" TagPrefix="uc5" %>
<%@ Register Src="Info3.ascx" TagName="Info3" TagPrefix="uc4" %>
<%@ Register Src="Info2.ascx" TagName="Info2" TagPrefix="uc3" %>
<%@ Register Src="Info1.ascx" TagName="Info1" TagPrefix="uc2" %>
<%@ Register Src="MenuKind.ascx" TagName="MenuKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript"  type="text/javascript">
        function print1()
        {
            var url1="PrintShenBaoBiao.aspx?id=<%=Request["id"]%>&Rnd=<%=DateTime.Now.ToString()%>";
            var hid1=window.screen.availHeight-10;
	        var wid1=window.screen.availWidth-10;
	        window.open(url1,"","location=no,Status=no,Menubar=yes,Scrollbars=yes,resizable=yes,left=5,top=5,width="+wid1+",height="+hid1);
        }
    </script>
    <uc1:MenuKind ID="MenuKind1" runat="server"></uc1:MenuKind>
    <br />
    <uc2:Info1 ID="Info1" runat="server" />
    <uc3:Info2 ID="Info2" runat="server" Visible="false" />
    <uc6:info5 ID="Info5" runat="server" Visible="false" />
    <uc7:info6 ID="Info6" runat="server" Visible="false" />
    <uc4:Info3 ID="Info3" runat="server" Visible="false" />
    <uc5:Info4 ID="Info4" runat="server" Visible="false" />
    
    <table width="100%" align="center">
        <tr>
            <td align="center" height="40" valign="middle">
                <span id="span1" runat="server"><asp:Button ID="Button1" runat="server" Text="保存数据" OnClick="Button1_Click" /></span>
                <span id="span2" runat="server"><asp:Button ID="Button2" CommandArgument="11" runat="server" Text="提交审批" OnClick="Button2_Click" /></span>
                <span id="span3" runat="server"><input id="Button3" type="button" value="打印项目处置方案申报表(word)" class="but" style="width: 200px" runat="server" onclick="javascript:print1();" /></span>
                <span id="span4" runat="server"><input id="Button4" type="button" runat="server" value="打印审批意见列表" class="but" style="width: 130px"/></span>
                <span id="span5" runat="server"><asp:Button ID="Button5" runat="server" Text="重置审批流程" OnClick="Button5_Click" OnClientClick="javaScript:return confirm('警告：将删除所有的审批数据！');" /></span>
            </td>
        </tr>
    </table>
</asp:Content>
