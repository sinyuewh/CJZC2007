<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_ZCDirectoryInfo, App_Web_o8vl6oai" title="资产明细下载页面" stylesheettheme="CjzcWeb" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

    function Button2_onclick() 
    {

    }
    </script>

    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" OnItemCreated="Repeater1_ItemCreated">
        <HeaderTemplate>
            <table width="90%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <tr height="25">
                    <td align="Center" bgcolor="gainsboro" colspan="3">
                        <p style="font-weight: normal; font-size: 11pt;">
                            <strong>资 产 系 列 文 件 下 载 表</strong></p>
                    </td>
                </tr>
                <colgroup>
                    <col width="60%" />
                    <col width="25%" />
                    <col />
                </colgroup>
                <tr height="25" width="100%" bgcolor="White">
                    <td align="center">
                        文 件 名
                    </td>
                    <td align="center">
                        上传时间
                    </td>
                    <td align="center">
                        <asp:Label ID="labDelete" runat="server" Text="删除"></asp:Label>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25" width="100%" bgcolor="White">
                <td>
                    &nbsp;&nbsp;<a href='<%#Application["root"]%>/Common/Downloads/<%#Eval("fileName") %> ' target="_blank">
                        <asp:Label ID="labFile" runat="server" Text='<%#Eval("fileName") %>'></asp:Label>
                    </a>
                </td>
                <td align=center>
                    <%#Eval("fileTime") %>
                </td>
                <td align=center>
                    &nbsp;<asp:LinkButton ID="butDel" runat="server"  OnClientClick="javascript:return confirm('警告：你确定要删除该文件吗？');">删除</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td style="width: 3px">
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    
    
    <table width="90%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5" id="Tab1" runat="server">
        <tr height="25" bgcolor="white">
            <td align="center" width="30%">
                上传附件</td>
            <td align="left">
                <asp:FileUpload ID="FileUpload1" runat="server" Height="22" Width="287px" CssClass="text" />&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="上传附件" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>
