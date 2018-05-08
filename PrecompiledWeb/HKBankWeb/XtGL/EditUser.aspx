<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_EditUser, App_Web_rhavpchx" title="修改用户资料" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
    function WinOpen()
    {
        str1=document.forms[0].<%#this.leader.ClientID %>.value;
        var url="../DangAn/UserList.aspx";
        
        str1=window.showModalDialog(url,str1,"dialogLeft:100pt;dialogTop:100pt;dialogWidth:480pt;dialogHeight:320pt");
        if(str1!=undefined)
        {
            document.forms[0].<%#this.leader.ClientID %>.value=str1;
        }
    }
    
     function WinOpen1()
    {
        str1=document.forms[0].<%#this.leader1.ClientID %>.value;
        var url="../DangAn/UserList.aspx";
        
        str1=window.showModalDialog(url,str1,"dialogLeft:100pt;dialogTop:100pt;dialogWidth:480pt;dialogHeight:320pt");
        if(str1!=undefined)
        {
            document.forms[0].<%#this.leader1.ClientID %>.value=str1;
        }
    }
    </script>
    
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">修改用户资料</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                工 号：</td>
            <td>
                <asp:TextBox ID="num" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                姓 名：</td>
            <td>
                <asp:TextBox ID="sname" runat="server" Width="90%"></asp:TextBox>
                <asp:Label ID="sname1" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                所在部门：</td>
            <td>
                <asp:DropDownList ID="depart" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                职 务：</td>
            <td>
                <asp:TextBox ID="job" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                直接主管：</td>
            <td>
                <asp:TextBox ID="leader" runat="server" Width="75%"></asp:TextBox>
                &nbsp;<a class="blue2" href="javaScript:WinOpen();">选 择>></a>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                其他授权用户：</td>
            <td>
                <asp:TextBox ID="leader1" TextMode="MultiLine" Height ="40"  runat="server" Width="75%"></asp:TextBox>
                &nbsp;<a class="blue2" href="javaScript:WinOpen1();">选 择>></a>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                手机(小灵通)：</td>
            <td>
                <asp:TextBox ID="cell" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                座机：
            </td>
            <td>
                <asp:TextBox ID="phone" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                电子邮件：</td>
            <td>
                <asp:TextBox ID="email" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />
        &nbsp; &nbsp; &nbsp;<asp:Button ID="Button3" runat="server" Text="重置密码" OnClick="Button3_Click" />
        &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" /></div>
</asp:Content>
