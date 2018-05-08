<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_ZcDetail3, App_Web_kckafmby" title="方案审核" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
               
        function ShowAttach()
        {
            url="TcDoc.aspx?zcid=<%#Request["id"]%>";
           winOpenOfen(url,600,400);
        }
        
        function ShowAttach1()
        {
            url="SpDoc.aspx?zcid=<%#Request["id"]%>";
            winOpenOfen(url,600,400);
        }
        function Button3_onclick() 
        {
            /*
            var zcid1=<%#this.zcczid.ClientID%>.innerText;
            if(zcid1!="")
            {
                //url="Zcczsbb.aspx?czid=<%#Request["id"]%>&czczid="+<%#this.zcczid.ClientID%>.innerText;  
                
                url="../zcMng1/printword.aspx?czid=<%#Request["id"]%>&czczid="+<%#this.zcczid.ClientID%>.innerText;      
                window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
            }
            else
            {
                alert("错误提示：当前没有定义资产审批数据！");
            }*/
        }

    function Button1_onclick() 
        {
           /*
            var zcid1=<%#this.zcczid.ClientID%>.innerText;
            if(zcid1 !="")
            {
                url="Zcspldyjb.aspx?czid="+<%#this.zcczid.ClientID%>.innerText+"&pc="+document.forms[0].<%#this.pc1.ClientID%>.value;    
                window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=600,height=400,Scrollbars=yes,resizable=yes");
            }
            else
            {
                alert("错误提示：当前没有领导意见！");
            }*/
        }
    function WinOpen(str1)
    {
        var url="Zcywczsbb.aspx?id="+str1;
        window.open(url,"","left=10,top=10,width=800,height=600,location=yes,Status=yes,Menubar=yes,Scrollbars=yes,resizable=yes");
    }

    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">当 前 方 案 审 批</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td colspan="3">
                <asp:Label ID="labdanwei" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任人：</td>
            <td>
                &nbsp;<asp:Label ID="zeren" runat="server"></asp:Label>
                （<asp:Label ID="depart" runat="server"></asp:Label>）
            </td>
            <td>
                当前状态：</td>
            <td>
                &nbsp;<asp:Label ID="statusText" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="status" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>1、项 目 基 本 情 况</strong></td>
        </tr>
        
        <tr height="25">
            <td>
                项目申报号：
            </td>
            <td>
                <asp:Label ID="zcczid" runat="server" Text=""></asp:Label>
                <asp:Label ID="xmsbh" runat="server" Text=""></asp:Label>
            </td>
            <td>
                项目档案号：
            </td>
            <td>
                <asp:Label ID="num2" runat="server"></asp:Label>
            </td>
        </tr>
         <tr height="25">
            <td>
                项目名称：
            </td>
            <td colspan="3">
                <asp:TextBox ID="xmmc" runat="server" Width="270px"></asp:TextBox>
                </td>
        </tr>
        <tr height="25">
            <td>
                债务单位：
            </td>
            <td>
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
            <td>
                担保单位：
            </td>
            <td>
                <asp:TextBox ID="bzrmc" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                债务人主管部门或所属：
            </td>
            <td>
                <asp:TextBox ID="zwzg" runat="server" Text=""></asp:TextBox>
            </td>
            <td>
                债权时效：
            </td>
            <td>
                <asp:TextBox ID="zqsx" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
                
        <tr height="25">
            <td>
                资产类型：
            </td>
            <td>
                <asp:TextBox ID="zclx" runat="server"></asp:TextBox>
            </td>
            <td>
                资产数额：
            </td>
            <td>
                <asp:TextBox ID="zcse" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                资产价值：
            </td>
            <td>
                <asp:TextBox ID="jiazhi" runat="server" Width="120px"></asp:TextBox>(万元)
            </td>
            <td>
                债权总额：
            </td>
            <td>
                <asp:TextBox ID="zqce" runat="server" Width="108px"></asp:TextBox>
                (万元)</td>
        </tr>
        
         <tr height="25">
            <td>
                本金：
            </td>
            <td>
                <asp:Label ID="benjin" runat="server"></asp:Label>
            </td>
            <td>
                利息：
            </td>
            <td>
                <asp:Label ID="lixi" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                项目背景：
            </td>
            <td colspan="3">
                <asp:TextBox ID="xmbj" runat="server" TextMode="MultiLine" Width="87%" Height="259px"></asp:TextBox>
            </td>
        </tr>
        
        
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>2、项目处置方案</strong></td>
        </tr>
        <tr height="25">
            <td>
                方案一：
            </td>
            <td colspan="3">
               <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                    <colgroup>
                        <col width="25%" align="right" bgcolor="white" />
                        <col align="left"  bgcolor="white" />
                    </colgroup>
                    <tr>
                        <td>
                            处置方式：
                        </td>
                        <td>
                            <asp:TextBox ID="czfs1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            具体办法：
                        </td>
                        <td>
                            <asp:TextBox ID="jtfa1" runat="server" TextMode="multiLine" Height="65px" Width="254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            处置价格：</td>
                        <td>
                            <asp:TextBox ID="czjg1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            清偿率：</td>
                        <td>
                            <asp:TextBox ID="qcl1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
               </table>
            </td>
        </tr>
         <tr height="25">
            <td>
                方案二：
            </td>
            <td colspan="3">
                <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                    <colgroup>
                        <col width="25%" align="right" bgcolor="white" />
                        <col align="left"  bgcolor="white" />
                    </colgroup>
                    <tr>
                        <td>
                            处置方式：
                        </td>
                        <td>
                            <asp:TextBox ID="czfs2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            具体办法：
                        </td>
                        <td>
                            <asp:TextBox ID="jtfa2" runat="server" TextMode="multiLine" Height="65px" Width="253px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            处置价格：</td>
                        <td>
                            <asp:TextBox ID="czjg2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            清偿率：</td>
                        <td>
                            <asp:TextBox ID="qcl2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
               </table>
            </td>
        </tr>
        <tr height="25">
            <td>
                相关事项说明：
            </td>
            <td colspan="3">
                <asp:TextBox ID="xgsx" runat="server" TextMode="MultiLine" Width="85%" Height="65px"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>3、评审委员会</strong></td>
        </tr>
        <tr height="25">
            <td>
                会议时间：
            </td>
            <td>
                <asp:TextBox ID="hysj1" runat="server"></asp:TextBox>
            </td>
            <td>
                会议地点：
            </td>
            <td>
                <asp:TextBox ID="hydd1" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                到会委员情况：
            </td>
            <td>
                <asp:TextBox ID="dhwy1" runat="server"></asp:TextBox>
            </td>
            <td>
                主持人：
            </td>
            <td>
                <asp:TextBox ID="zcr1" runat="server"></asp:TextBox>
            </td>
        </tr>
        
               
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>4、决策委员会</strong></td>
        </tr>
        <tr height="25" style="display: none;">
            <td>
                会议时间：
            </td>
            <td>
                <asp:Label ID="Label29" runat="server"></asp:Label>
                <asp:Label ID="Label30" runat="server"></asp:Label>
            </td>
            <td>
                会议地点：
            </td>
            <td>
                <asp:Label ID="Label31" runat="server"></asp:Label>
                <asp:Label ID="Label32" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr height="25" style="display: none;">
            <td>
                到会委员情况：
            </td>
            <td>
                <asp:Label ID="Label33" runat="server"></asp:Label>
                <asp:Label ID="Label34" runat="server"></asp:Label>
            </td>
            <td>
                出持人：
            </td>
            <td>
                <asp:Label ID="Label35" runat="server"></asp:Label>
                <asp:Label ID="Label36" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr height="25" style="display: none;">
            <td>
                赞同委员：
            </td>
            <td>
                <asp:Label ID="Label37" runat="server"></asp:Label>
                <asp:Label ID="Label38" runat="server"></asp:Label>
            </td>
            <td>
                反对委员：
            </td>
            <td>
                <asp:Label ID="Label39" runat="server"></asp:Label>
                <asp:Label ID="Label40" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                项目申报号：
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
            </td>
            <td>
                项目档案号：
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
            </td>
        </tr>

    </table>
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="butSaveData" runat="server" Text="更新资料" OnClick="SaveDataClick" />&nbsp;&nbsp;
                <asp:Button ID="butNewData" runat="server" Text="新建处置方案审批表" OnClick="butNewData_Click"
                    Width="123px" />&nbsp;&nbsp;
                <asp:Button ID="butSendToDepartLeader" CommandArgument="11" runat="server" Text="送部门审批"
                    OnClick="butSendToDepartLeader_Click" />&nbsp;&nbsp;
                <input id="Button3" type="button" runat="server" value="打印资产处置方案审批表" class="but" onclick="return Button3_onclick()" style="width: 149px" />&nbsp;
               <input id="Button1" type="button" runat="server" value="打印领导意见" class="but" onclick="return Button1_onclick()" style="width: 91px" />
                &nbsp;&nbsp;选择意见批次：<asp:DropDownList ID="pc1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater6_ItemCommand"
                    OnItemDataBound="Repeater6_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="10%" />
                                <col bgcolor="white" align="center" width="20%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="10%" />
                            </colgroup>
                            <tr height="25" bgcolor="gainsboro">
                                <td colspan="7" align="Center">
                                    <strong>资 产 处 置 方 式</strong>&nbsp;&nbsp;
                                    <asp:LinkButton ID="AddZcczfs" runat="server" OnClick="Button2_Click" CssClass="blue2">添加资产处置方式>></asp:LinkButton>
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
                                <td>
                                    操作
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
                                <%#Eval("czjg")%>
                            </td>
                            <td>
                                <%#Eval("czss")%>
                            </td>
                            <td>
                                <%#Eval("qcl")%>
                            </td>
                            <td>
                                <%#Eval("yjfy")%>
                            </td>
                            <td>
                                <asp:Label ID="zccz" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                                    OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                                <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CssClass="blue1">修改</asp:LinkButton>
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
    
    
    <asp:Repeater ID="Repeater11" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
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
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
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
                    <td align="center">
                        操作
                    </td>
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
                    <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("time1","{0:yyyy-MM-dd HH:mm:ss}") %>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
                </td>
                <td>
                    <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
    <asp:Repeater ID="Repeater12" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
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
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>2．办 公 室 立 项 编 号</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        部门
                    </td>
                    <td>
                        经办人
                    </td>
                    <td>
                        批次
                    </td>
                    <td>
                        时间
                    </td>
                    <td>
                        内容
                    </td>
                    <td align="center">
                        具体意见</td>
                    <td align="center">
                        操作
                    </td>
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
                    <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
                </td>
                <td>
                    <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">操作</asp:LinkButton>
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
    <asp:Repeater ID="Repeater13" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
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
                    <col bgcolor="white" align="center" width="11%" />
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
                    <td align="center">
                        操作
                    </td>
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
                    <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
                </td>
                <td>
                    <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
    <asp:Repeater ID="Repeater15" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
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
                    <col bgcolor="white" align="center" width="11%" />
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
                    <td align="center">
                        操作
                    </td>
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
                    <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
                    <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                </td>
                <td>
                    <%#Eval("ps") %>
                </td>
                <td>
                    <%#Eval("remark") %>
                </td>
                <td>
                    <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
    
    
    <asp:Repeater ID="Repeater0" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="#5d7b9d">
                        <strong><font color="#ffffff">以 往 资 产 处 置 申 报 表</font></strong></td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        项目编号
                    </td>
                    <td>
                        资产类型
                    </td>
                    <td>
                        资产数额
                    </td>
                    <td>
                        项目背景
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                    <td>
                        <%#Container.ItemIndex+1%></td>
                    <td>
                    <a class="blue1" href="javaScript:WinOpen(<%#Eval("id") %>);" title="<%# Eval("xmsbh") %>">
                        <%#Eval("xmsbh")%>
                    </a>
                    </td>
                    <td>
                        <%#Eval("zclx")%>
                    </td>
                    <td>
                        <%#Eval("zcse")%>
                    </td>
                    <td>
                        <%#Eval("xmbj")%>
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
</asp:Content>
