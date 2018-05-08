<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zcywczsbb, App_Web_0lscwnk0" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>资 产 处 置 申 报 情 况</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button3_onclick() 
    {
        var czid=document.getElementById("id").innerText;
        if(czid!="")
        {
            url="Zcczsbb.aspx?czczid="+czid;    
            window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
        }
        else
        {
            alert("错误提示：当前没有定义资产审批数据！");
        }
    }

function Button2_onclick() 
{
        var czid=document.getElementById("id").innerText;
        var pc = document.getElementById("pc1").value;
        if(czid !="")
        {
            url="Zcspldyjb.aspx?czid="+czid+"&pc="+pc;   
            window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=600,height=400,Scrollbars=yes,resizable=yes");
        }
        else
        {
            alert("错误提示：当前没有领导意见！");
        }
}

// ]]>
</script>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 处 置 申 报 情 况</font></strong>
            </td>
        </tr>
        <tr height="25" style="display: none;">
            <td>
                资产处置ID：
            </td>
            <td colspan="3">
                <asp:Label ID="id" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产类型：
            </td>
            <td>
                <asp:Label ID="zclx" runat="server"></asp:Label>
            </td>
            <td>
                资产数额：
            </td>
            <td>
                <asp:Label ID="zcse" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                项目背景：
            </td>
            <td colspan="3">
                <asp:Label ID="xmbj" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                方式选择理由：
            </td>
            <td colspan="3">
                <asp:Label ID="fsxzly" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                定价依据：
            </td>
            <td colspan="3">
                <asp:Label ID="djyj" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                &nbsp;&nbsp;
                <input id="Button3" type="button" value="打印资产处置单" class="but" onclick="return Button3_onclick()" />
                &nbsp;&nbsp;<input id="Button2" type="button" value="打印领导意见" class="but" onclick="return Button2_onclick()" />
                &nbsp;&nbsp;
                选择打印的批次：<asp:DropDownList ID="pc1" runat="server" >
                </asp:DropDownList>   
            </td>
        </tr>
        <tr height="30" style="display: none;">
            <td colspan="4">
                <asp:Label ID="PC" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Repeater ID="Repeater6" runat="server">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="12%" />
                                <col bgcolor="white" align="center" width="20%" />
                                <col bgcolor="white" align="center" width="17%" />
                                <col bgcolor="white" align="center" width="17%" />
                                <col bgcolor="white" align="center" width="17%" />
                                <col bgcolor="white" align="center" width="17%" />
                            </colgroup>
                            <tr height="25" bgcolor="gainsboro">
                                <td colspan="7" align="Center">
                                    <strong>资 产 处 置 方 式</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    处置方式
                                </td>
                                <td>
                                    处置价格
                                </td>
                                <td>
                                    处置损失
                                </td>
                                <td>
                                    清偿率(%)
                                </td>
                                <td>
                                    预计费用
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr height="25">
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <%#Eval("czfs")%>
                            </td>
                            <td>
                                <%#PubComm.GetNumberFormat(Eval("czjg"))%>
                            </td>
                            <td>
                                <%#PubComm.GetNumberFormat(Eval("czss"))%>
                            </td>
                            <td>
                                <%#Eval("qcl")%>
                            </td>
                            <td>
                                <%#PubComm.GetNumberFormat(Eval("yjfy"))%>
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
            </td>
        </tr>
    </table>
    <br />
    <asp:Repeater ID="Repeater11" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25">
                    <td colspan="8" align="center" bgcolor="gainsboro">
                        <strong>1．部 门 审 批</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        部门
                    </td>
                    <td>
                        批阅人
                    </td>
                    <td>
                        批次
                    </td>
                    <td>
                        批阅时间
                    </td>
                    <td>
                        批阅
                    </td>
                    <td align="center">
                        具体意见</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("pscount") %>
                </td>
                <td>
                    <%#Eval("time1","{0:yyyy-MM-dd hh:mm:ms}") %>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
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
    <asp:Repeater ID="Repeater12" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>2．办 公 室 批 阅</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        部门
                    </td>
                    <td>
                        批阅人
                    </td>
                    <td>
                        批次
                    </td>
                    <td>
                        批阅时间
                    </td>
                    <td>
                        批阅
                    </td>
                    <td align="center">
                        具体意见</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("pscount") %>
                </td>
                <td>
                    <%#Eval("time1","{0:yyyy-MM-dd hh:mm:ms}") %>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
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
    <asp:Repeater ID="Repeater13" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>3．审 核 委 员 会 审 批</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        部门
                    </td>
                    <td>
                        批阅人
                    </td>
                    <td>
                        批次
                    </td>
                    <td>
                        批阅时间
                    </td>
                    <td>
                        批阅
                    </td>
                    <td align="center">
                        具体意见</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <asp:Label ID="zx" runat="server" Text='<%#Eval("zx") %>' Visible="false"></asp:Label>
                    <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("pscount") %>
                </td>
                <td>
                    <%#Eval("time1","{0:yyyy-MM-dd hh:mm:ms}") %>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
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
    <asp:Repeater ID="Repeater15" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>4．决 策 委 员 会 审 批</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        部门
                    </td>
                    <td>
                        批阅人
                    </td>
                    <td>
                        批次
                    </td>
                    <td>
                        批阅时间
                    </td>
                    <td>
                        批阅
                    </td>
                    <td align="center">
                        具体意见</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <asp:Label ID="zx" runat="server" Text='<%#Eval("zx") %>' Visible="false"></asp:Label>
                    <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("pscount") %>
                </td>
                <td>
                    <%#Eval("time1","{0:yyyy-MM-dd hh:mm:ms}") %>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
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
    </form>
</body>
</html>
