<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_ZcDetail1, App_Web_6zxo-qvc" title="基本资料" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />

    <script language="javascript" type="text/javascript">
    function WinOpen(str1)
    {
        var url="ZcDetail10.aspx?id="+str1;
        window.showModalDialog(url,str1,"dialogLeft:100pt;dialogTop:100pt;dialogWidth:640pt;dialogHeight:400pt");
    }
function Button3_onclick() 
    {
        url="Zcjbzlb.aspx?zcid=<%#Request["id"]%>";    
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }

function Button1_onclick() 
    {
        url="Zcjbzlb1.aspx?zcid=<%#Request["id"]%>";    
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }

function Button2_onclick() 
    {
        url="Zcjbzlb2.aspx?zcid=<%#Request["id"]%>";    
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }

    </script>

    <div style="display: none">
        <asp:DropDownList ID="zhwd" runat="server">
        </asp:DropDownList>
        <asp:Label ID="zhwd_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="num1" runat="server"></asp:TextBox>
        <asp:Label ID="num1_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="huilv" runat="server"></asp:TextBox>
        <asp:Label ID="huilv_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="lx1" runat="server"></asp:TextBox>
        <asp:Label ID="lx1_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="lx2" runat="server"></asp:TextBox>
        <asp:Label ID="lx2_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="lx3" runat="server"></asp:TextBox>
        <asp:Label ID="lx3_1" runat="server" Text=""></asp:Label>
        <asp:DropDownList ID="zcbao" runat="server" Width="80">
        </asp:DropDownList>
        <asp:Label ID="zcbao_1" runat="server" Text=""></asp:Label>
        <asp:DropDownList ID="bank" runat="server" Width="120">
        </asp:DropDownList>
        <asp:Label ID="bank_1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="zhuang" runat="server"></asp:TextBox>--%>
        <asp:Label ID="zhuang_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="htnum" runat="server"></asp:TextBox>
        <asp:Label ID="htnum_1" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="time0" runat="server"></asp:TextBox>
        <asp:Label ID="time0_1" runat="server" Text=""></asp:Label>&nbsp;<asp:TextBox ID="zzjg"
            runat="server"></asp:TextBox>
        <asp:Label ID="zzjg_1" runat="server"></asp:Label>
        &nbsp;<asp:TextBox ID="clsj" runat="server"></asp:TextBox>
        <asp:Label ID="clsj_1" runat="server"></asp:Label>&nbsp;<asp:DropDownList ID="dqjj"
            runat="server">
        </asp:DropDownList>
        <asp:Label ID="dqjj_1" runat="server"></asp:Label>
        &nbsp;<asp:DropDownList ID="qygm" runat="server">
        </asp:DropDownList>
        <asp:Label ID="qygm_1" runat="server"></asp:Label>&nbsp;<asp:DropDownList ID="yxzzzk"
            runat="server">
        </asp:DropDownList>
        <asp:Label ID="yxzzzk_1" runat="server"></asp:Label>
        &nbsp;<asp:TextBox ID="xdri" runat="server"></asp:TextBox>
        <asp:Label ID="xdri_1" runat="server"></asp:Label>&nbsp;<asp:TextBox ID="dkffrq1"
            runat="server"></asp:TextBox>
        <asp:Label ID="dkffrq1_1" runat="server"></asp:Label>&nbsp;<asp:TextBox ID="jklsh"
            runat="server"></asp:TextBox>
        <asp:Label ID="jklsh_1" runat="server"></asp:Label>
        &nbsp;<asp:TextBox ID="dkye" runat="server"></asp:TextBox>
        <asp:Label ID="dkye_1" runat="server"></asp:Label>&nbsp;<asp:TextBox ID="zjycszje"
            runat="server"></asp:TextBox>
        <asp:Label ID="zjycszje_1" runat="server"></asp:Label>&nbsp;<asp:TextBox ID="yyldxt"
            runat="server"></asp:TextBox>
        <asp:Label ID="yyldxt_1" runat="server"></asp:Label>&nbsp;<asp:TextBox ID="xcyqrq"
            runat="server"></asp:TextBox>
        <asp:Label ID="xcyqrq_1" runat="server"></asp:Label>&nbsp;<asp:TextBox ID="jrblsj"
            runat="server"></asp:TextBox>
        <asp:Label ID="jrblsj_1" runat="server"></asp:Label>&nbsp;<asp:DropDownList ID="fenlei"
            runat="server">
        </asp:DropDownList>
        <asp:Label ID="fenlei_1" runat="server"></asp:Label>
    </div>
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" width="30%" />
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 的 基 本 资 料</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：
            </td>
            <td>
                &nbsp;<asp:Label ID="depart" runat="server"></asp:Label>
                <asp:Label ID="depart_1" runat="server"></asp:Label>
            </td>
            <td>
                责任人：
            </td>
            <td>
                &nbsp;<asp:Label ID="zeren" runat="server" Text=""></asp:Label>
                <asp:Label ID="zeren_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="danwei" runat="server"></asp:TextBox>
                <asp:Label ID="danwei_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                档案号：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="num2" runat="server"></asp:TextBox>
                <asp:Label ID="num2_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                货币：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="huobi" runat="server">
                    <asp:ListItem>人民币</asp:ListItem>
                    <asp:ListItem>美元</asp:ListItem>
                    <asp:ListItem>美元折人民币</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="huobi_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                转入金额:
            </td>
            <td>
                &nbsp;<asp:TextBox ID="bj" runat="server"></asp:TextBox>
                <asp:Label ID="bj_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                所属行业：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="sshy" runat="server">
                </asp:DropDownList>
                <asp:Label ID="sshy_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                行政区域：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="quyu" runat="server" Width="80">
                </asp:DropDownList>
                <asp:Label ID="quyu_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                管 辖：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="guangxia" runat="server">
                </asp:DropDownList>
                <asp:Label ID="guangxia_1" runat="server" Text=""></asp:Label>
            </td>
            <td style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr height="25">
            <td>
                资产状态：
            </td>
            <td>
                &nbsp;<asp:Label ID="status" runat="server" Text=""></asp:Label>
                <asp:Label ID="status_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                用户自定义分类：
            </td>
            <td>
                &nbsp;<asp:Label ID="userkind" runat="server" Text=""></asp:Label>
                <asp:Label ID="userkind_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>业 务 基 本 情 况</strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                企业经营状况：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="jysfzc" runat="server">
                </asp:DropDownList>
                <asp:Label ID="jysfzc_1" runat="server"></asp:Label>
            </td>
            <td>
                注册资本：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="zczb" runat="server"></asp:TextBox>
                <asp:Label ID="zczb_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位地址：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="dwdz" runat="server"></asp:TextBox>
                <asp:Label ID="dwdz_1" runat="server"></asp:Label>
            </td>
            <td>
                负责人：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="dwfzr" runat="server"></asp:TextBox>
                <asp:Label ID="dwfzr_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                企业经济性质：
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="qyjjxz" runat="server">
                </asp:DropDownList>
                <asp:Label ID="qyjjxz_1" runat="server"></asp:Label>
            </td>
            <td>
                贷款发放日期：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="dkffrq2" runat="server"></asp:TextBox>
                <asp:Label ID="dkffrq2_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                合同到期日：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="htdqr" runat="server"></asp:TextBox>
                <asp:Label ID="htdqr_1" runat="server"></asp:Label>
            </td>
            <td>
                主要担保方式：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="zydbfs" runat="server"></asp:TextBox>
                <asp:Label ID="zydbfs_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                担保人(物)名称：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="dbrwmc" runat="server"></asp:TextBox>
                <asp:Label ID="dbrwmc_1" runat="server"></asp:Label>
            </td>
            <td>
                备 注：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="remark" runat="server"></asp:TextBox>
                <asp:Label ID="remark_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="but0" runat="server" Text="更新资料" OnClick="SaveDataClick" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button3" type="button" runat="server" value="打印基本资料及业务情况" class="but"
                    onclick="return Button3_onclick()" style="width: 164px" />
                &nbsp;&nbsp
                <input id="Button1" type="button" runat="server" value="打印资产基本资料" class="but" onclick="return Button1_onclick()"
                    style="width: 121px" />
                &nbsp;&nbsp
                <input id="Button2" type="button" runat="server" value="打印资产业务情况" class="but" onclick="return Button2_onclick()"
                    style="width: 130px" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="15%" />
                    <col bgcolor="white" align="center" width="25%" />
                    <col bgcolor="white" align="center" width="10%" />
                </colgroup>
                <tr height="25">
                    <td colspan="5" align="center" bgcolor="gainsboro">
                        <strong>资产基本资料修改日志</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序
                    </td>
                    <td>
                        单位名称
                    </td>
                    <td>
                        修改人
                    </td>
                    <td>
                        修改时间
                    </td>
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
                    <a class="blue1" href="javaScript:WinOpen(<%#Eval("id") %>);" title="<%# Eval("danwei") %>">
                        <%#Eval("danwei") %>
                    </a>
                </td>
                <td>
                    <%#Eval("xgr") %>
                </td>
                <td>
                    <%#Eval("xgsj", "{0:yyyy-MM-dd hh:mm:ms}")%>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
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
    <br />
    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand"
        OnItemDataBound="Repeater2_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="18%" />
                    <col bgcolor="white" align="center" width="25%" />
                    <col bgcolor="white" align="center" width="18%" />
                    <col bgcolor="white" align="center" width="18%" />
                    <col bgcolor="white" align="center" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="center" bgcolor="gainsboro">
                        <strong>资产分配日志</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序
                    </td>
                    <td>
                        分配人
                    </td>
                    <td>
                        分配时间
                    </td>
                    <td>
                        原责任人
                    </td>
                    <td>
                        新责任人
                    </td>
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
                    <%#Eval("domen") %>
                </td>
                <td>
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
                </td>
                <td>
                    <%#Eval("zeren1") %>
                </td>
                <td>
                    <%#Eval("zeren2") %>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
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
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
        </colgroup>
        <tr height="25" bgcolor="gainsboro">
            <td colspan="4" align="Center">
                <strong>资 产 档 案 文 件</strong>&nbsp;&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                序号
            </td>
            <td>
                上传时间
            </td>
            <td>
                上传人
            </td>
            <td>
                电子档案
            </td>
        </tr>
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                <tr height="25">
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("time0")%>
                    </td>
                    <td>
                        <%#Eval("ljren")%>
                    </td>
                    <td>
                        <a class="blue" target="_blank" href='<%=Application["root"]%>/SeeDAFile.aspx?fileName=<%#Eval("ajTrueFile")%>'>
                            <%#Eval("ajfile")%></a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
