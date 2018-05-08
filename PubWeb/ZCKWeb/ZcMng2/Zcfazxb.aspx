<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zcfazxb, App_Web_zpfhjo5e" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产方案执行表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0" >
            <colgroup>
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" width="32%" />
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" />
            </colgroup>
            <tr height="40">
                <td align="center" colspan="4">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产方案执行表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    单位名称：</td>
                <td colspan="3" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="danwei" runat="server"></asp:Label>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    责任人：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    &nbsp;<asp:Label ID="zeren" runat="server"></asp:Label>
                    （<asp:Label ID="depart" runat="server"></asp:Label>）
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    当前状态：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    &nbsp;<asp:Label ID="statusText" runat="server"></asp:Label>
                    <asp:Label ID="status" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr height="35">
                <td colspan="4" align="center" style="border-bottom: solid 1pt #000000; height: 30px;">
                    <strong>诉 讼 情 况</strong>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    律师事务所：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="lssws" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    法人代表：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="frdb" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    委托律师：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="wtls" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    联系电话：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="lxdh" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    单位地址：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="dwdz" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    电子邮件：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="dzyj" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
        </table>
        
        <br />
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>1．协 商 谈 判</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
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
    <asp:Repeater ID="Repeater2" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>2．诉 讼 记 录</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td>
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater3" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>3．申 请 执 行</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td>
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater4" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>4．强 制 执 行</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater5" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>5．中 止 执 行</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;"> 
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    
    <asp:Repeater ID="Repeater6" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>6．终 止 执 行</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    
    <asp:Repeater ID="Repeater7" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" >
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>7．资 产 办 结</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
