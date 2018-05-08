<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_restoreMail, App_Web_r4t0yj0h" title="回复邮件" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                <asp:TextBox ID="to1" runat="server" Width="85%" ReadOnly="true"></asp:TextBox>
                &nbsp;
            </td>
            <tr height="25">
                <td width="5%">
                    主题：

                    
                </td>
                <td>
                    <asp:TextBox ID="title" runat="server" Width="85%"></asp:TextBox>
                </td>
            </tr>
            <tr height="245">
                <td width="5%">
                    正文：

                </td>
                <td >
                    <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Width="90%" Height="245" ></asp:TextBox>
                </td>
            </tr>
        </tr>
        
    </table>
    <br />
    <div align="center">
        <asp:Button ID="btn1" runat="server" Text="发送" OnClick="btn1_Click"   />
        &nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="取消" OnClick="btn2_Click"  />
    </div>
</asp:Content>

