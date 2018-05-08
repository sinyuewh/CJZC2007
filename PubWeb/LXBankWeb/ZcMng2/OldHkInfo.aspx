<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_OldHkInfo, App_Web_lvcarkdp" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="95%" align="center" border="0" cellpadding="1" style ="display:none" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="right" />
            </colgroup>
            <tr height="25">
                <td>
                    借款流水号：<asp:Repeater ID="repeater1" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="link1" CssClass="blue"  runat="server" Text='<%#Eval("借款流水号") %>' 
                              CommandArgument ='<%#Eval("借款流水号") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            &nbsp;|&nbsp;
                        </SeparatorTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        
        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" width="32%" />
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" width="32%" />
            </colgroup>
            <tr height="25">
                <td colspan="4" align="center" bgcolor="#5d7b9d">
                    <strong><font color="#ffffff">汉 口 银 行 资 产 包 老 档 案</font></strong>
                </td>
            </tr>
            <tr height="25">
                <td style="text-align: right; width:18%">
                    <b>五级分类：</b>
                </td>
                <td colspan="3">
                    &nbsp;<asp:TextBox ID="五级分类" TextMode="MultiLine" Height="800" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <!--Other Info -->
            <tr height="25" style="display: none">
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
        </table>
    </div>
    </form>
</body>
</html>
