<%@ Page Language="C#" MasterPageFile="~/Common/Master/Info.master" AutoEventWireup="true" CodeFile="againSendMail.aspx.cs" Inherits="Info_againSendMail" Title="转发邮件" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function WinOpen()
    {
        str1=document.forms[0].<%#this.to1.ClientID %>.value;
        var url="UserList.aspx";
        
        str1=window.showModalDialog(url,str1,"dialogLeft:100pt;dialogTop:100pt;dialogWidth:450pt;dialogHeight:300pt");
        document.forms[0].<%#this.to1.ClientID %>.value=str1;
    }
</script>

<table width="100%" align="center" border="0" cellspacing="1" cellpadding="1" bgcolor="#c5c5c5">

        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d" >
                <strong><font color="ffffff">写邮件</font></strong>
            </td>
            
        </tr>
        <tr height="25">
            <td width="5%">
                收件人：
            </td>
            <td>
                <asp:TextBox ID="to1" runat="server" Width="85%"></asp:TextBox>
                &nbsp;<a class="blue2" href="javaScript:WinOpen();">添 加>></a>
            </td>
            <tr height="25">
                <td width="5%">
                    主题：                </td>
                <td>
                    <asp:TextBox ID="title" runat="server" Width="85%"></asp:TextBox>
                </td>
            </tr>
            <tr height="245">
                <td width="5%">
                    正文：

                </td>
                <td >
                    <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Width="90%" Height="245"></asp:TextBox>
                </td>
            </tr>
        </tr>
        
    </table>
    <br />
    <div align="center">
        <asp:Button ID="btn1" runat="server" Text="发 送" OnClick="btn1_Click"  />
        &nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="取 消"  OnClick="btn2_Click"  />
    </div>
</asp:Content>

