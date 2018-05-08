<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZcDetail9.aspx.cs" Inherits="ZcMng2_ZcDetail9" Title="资产担保情况" %>

<%-- 在此处添加内容控件 --%>
<%@ Register Src="~/ZcMng2/ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

    function Button2_onclick() 
    {
        url="Zcdbqkb.aspx?zcid=<%#Request["id"]%>";    
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
    }

// ]]>
    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="24%" />
            <col bgcolor="white" align="left" width="24%" />
            <col bgcolor="white" align="right" width="28%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 担 保 情 况</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td colspan="3">
                &nbsp;<asp:Label ID="danwei_1" runat="server" Text=""></asp:Label>
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                &nbsp;<asp:Label ID="depart_1" runat="server"></asp:Label>
                <asp:Label ID="depart" runat="server" Text=""></asp:Label>
            </td>
            <td>
                责任人：</td>
            <td>
                &nbsp;<asp:Label ID="zeren_1" runat="server" Text=""></asp:Label>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                债务人回收估值：
            </td>
            <td>
                &nbsp;<asp:Label ID="zwrhsgz_1" runat="server"></asp:Label>
                <asp:TextBox ID="zwrhsgz" runat="server"></asp:TextBox>
            </td>
            <td>
                保证人回收估值：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzrhsgz_1" runat="server"></asp:Label>
                <asp:TextBox ID="bzrhsgz" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                其他回收贡献值：
            </td>
            <td>
                &nbsp;<asp:Label ID="qthsgz_1" runat="server"></asp:Label>
                <asp:TextBox ID="qthsgz" runat="server"></asp:TextBox>
            </td>
            <td>
                预计回收时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="hssj_1" runat="server"></asp:Label>
                <asp:TextBox ID="hssj" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                <span style="line-height: 150%">与债务人或其他潜在的偿债方历史洽商情况:</span>
            </td>
            <td>
                &nbsp;<asp:Label ID="qsqk_1" runat="server"></asp:Label>
                <asp:TextBox ID="qsqk" runat="server"></asp:TextBox>
            </td>
            <td>
                备注：
            </td>
            <td>
                &nbsp;<asp:Label ID="remark_1" runat="server"></asp:Label>
                <asp:TextBox ID="remark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>保 证 单 位 (人)&nbsp; &nbsp;情 况</strong></td>
        </tr>
        <tr height="25">
            <td>
                保证(单位)人名称：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzrmc_1" runat="server"></asp:Label>
                <asp:TextBox ID="bzrmc" runat="server"></asp:TextBox>
            </td>
            <td>
                保证金额：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzje_1" runat="server"></asp:Label>
                <asp:TextBox ID="bzje" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                保证有效性：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzyx_1" runat="server"></asp:Label>
                <asp:DropDownList ID="bzyx" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                保证人的偿债能力：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzcznl_1" runat="server"></asp:Label>
                <asp:DropDownList ID="bzcznl" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                保证合同：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzhtong_1" runat="server"></asp:Label>
                <asp:TextBox ID="bzhtong" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        
        <tr height="25">
            <td>
                保证人的偿债意愿：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzczyy_1" runat="server"></asp:Label>
                <asp:DropDownList ID="bzczyy" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                保证无效说明：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzwxsm_1" runat="server"></asp:Label>
                <asp:TextBox ID="bzwxsm" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                保证补充说明：
            </td>
            <td colspan="3">
                &nbsp;<asp:Label ID="Remark1_1" runat="server"></asp:Label>
                <asp:TextBox ID="Remark1" runat="server" Width="87%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="24%" />
            <col bgcolor="white" align="left" width="24%" />
            <col bgcolor="white" align="right" width="28%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>抵 押 物 情 况</strong>&nbsp;&nbsp;
                <asp:LinkButton ID="Adddyw" runat="server" OnClick="Button2_Click" CssClass="blue2">添加抵押物>></asp:LinkButton>
            </td>
        </tr>
        
        <!--增加的6个字段-->
        <tr height="25">
            <td>
                抵押物：
            </td>
            <td>
                &nbsp;<asp:Label ID="dyw_1" runat="server"></asp:Label>
                <asp:TextBox ID="dyw" runat="server"></asp:TextBox>
            </td>
            <td>
                是否有抵押合同：
            </td>
            <td>
                &nbsp;<asp:Label ID="sfydyht_1" runat="server"></asp:Label>
                <asp:TextBox ID="sfydyht" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                对应抵押金额：
            </td>
            <td>
                &nbsp;<asp:Label ID="dyje_1" runat="server"></asp:Label>
                <asp:TextBox ID="dyje" runat="server"></asp:TextBox>
            </td>
            <td>
                抵押是否有效：
            </td>
            <td>
                &nbsp;<asp:Label ID="dysfyx_1" runat="server"></asp:Label>
                <asp:TextBox ID="dysfyx" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                抵押文件：
            </td>
            <td>
                &nbsp;<asp:Label ID="dywj_1" runat="server"></asp:Label>
                <asp:TextBox ID="dywj" runat="server"></asp:TextBox>
            </td>
            <td>
                抵押物评估报告：
            </td>
            <td>
                &nbsp;<asp:Label ID="dypgbg_1" runat="server"></asp:Label>
                <asp:TextBox ID="dypgbg" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <!--->
        <tr height="25">
            <td>
                抵押物取得是否存在障碍：
            </td>
            <td>
                &nbsp;<asp:Label ID="qdza1_1" runat="server"></asp:Label>
                <asp:DropDownList ID="qdza1" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                抵押物取得障碍原因：
            </td>
            <td>
                &nbsp;<asp:Label ID="qdzayy1_1" runat="server"></asp:Label>
                <asp:TextBox ID="qdzayy1" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                抵押物处置是否存在障碍：
            </td>
            <td>
                &nbsp;<asp:Label ID="czza1_1" runat="server"></asp:Label>
                <asp:DropDownList ID="czza1" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                抵押物处置障碍原因：
            </td>
            <td>
                &nbsp;<asp:Label ID="zzzayy1_1" runat="server"></asp:Label>
                <asp:TextBox ID="zzzayy1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                抵押物变现难易：
            </td>
            <td>
                &nbsp;<asp:Label ID="bxny1_1" runat="server"></asp:Label>
                <asp:DropDownList ID="bxny1" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                抵押物考虑安置费金额：
            </td>
            <td>
                &nbsp;<asp:Label ID="klazfy_1" runat="server"></asp:Label>
                <asp:TextBox ID="klazfy" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                抵押物法律意见：
            </td>
            <td>
                &nbsp;<asp:Label ID="flyj1_1" runat="server"></asp:Label>
                <asp:DropDownList ID="flyj1" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                抵押物回收估值：
            </td>
            <td>
                &nbsp;<asp:Label ID="dyhsgz1_1" runat="server"></asp:Label>
                <asp:TextBox ID="dyhsgz1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                抵押物补充说明：
            </td>
            <td colspan="3">
                &nbsp;<asp:Label ID="Remark2_1" runat="server"></asp:Label>
                <asp:TextBox ID="Remark2" runat="server" Width="87%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="10%" />
                </colgroup>
                <tr height="25" bgcolor="gainsboro">
                    <td colspan="6" align="Center">
                        <strong>抵 押 物 详 细 情 况</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序：
                    </td>
                    <td>
                        抵押物类别：
                    </td>
                    <td>
                        抵押物数量：
                    </td>
                    <td>
                        单位：
                    </td>
                    <td>
                        估值：
                    </td>
                    <td align="center">
                        操作：
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1 %>
                </td>
                <td>
                    <%#Eval("wplb")%>
                </td>
                <td>
                    <%#Eval("wpsl")%>
                </td>
                <td>
                    <%#Eval("wpdw")%>
                </td>
                <td>
                    <%#PubComm.GetNumberFormat(Eval("wpjz"))%>
                </td>
                <td>
                    <asp:Label ID="dzyw" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                    <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CommandArgument="0"
                        CssClass="blue1">修改</asp:LinkButton>
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
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="24%" />
            <col bgcolor="white" align="left" width="24%" />
            <col bgcolor="white" align="right" width="28%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>质 押 物 情 况</strong>&nbsp;&nbsp;
                <asp:LinkButton ID="Addzyw" runat="server" OnClick="Button3_Click" CssClass="blue2">添加质押物>></asp:LinkButton>
            </td>
        </tr>
        <tr height="25">
            <td>
                质押物取得是否存在障碍：
            </td>
            <td>
                &nbsp;<asp:Label ID="qdza2_1" runat="server"></asp:Label>
                <asp:DropDownList ID="qdza2" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                质押物取得障碍原因：
            </td>
            <td>
                &nbsp;<asp:Label ID="qdzayy2_1" runat="server"></asp:Label>
                <asp:TextBox ID="qdzayy2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                质押物处置是否存在障碍：
            </td>
            <td>
                &nbsp;<asp:Label ID="czza2_1" runat="server"></asp:Label>
                <asp:DropDownList ID="czza2" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                质押物处置障碍原因：
            </td>
            <td>
                &nbsp;<asp:Label ID="zzzayy2_1" runat="server"></asp:Label>
                <asp:TextBox ID="zzzayy2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                质押物变现难易：
            </td>
            <td>
                &nbsp;<asp:Label ID="bxny2_1" runat="server"></asp:Label>
                <asp:DropDownList ID="bxny2" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                质押物法律意见：
            </td>
            <td>
                &nbsp;<asp:Label ID="flyj2_1" runat="server"></asp:Label>
                <asp:DropDownList ID="flyj2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                质押物回收估值：
            </td>
            <td>
                &nbsp;<asp:Label ID="dyhsgz2_1" runat="server"></asp:Label>
                <asp:TextBox ID="dyhsgz2" runat="server"></asp:TextBox>
            </td>
            <td>
                质押物补充说明：
            </td>
            <td>
                &nbsp;<asp:Label ID="Remark3_1" runat="server"></asp:Label>
                <asp:TextBox ID="Remark3" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="20%" />
                    <col bgcolor="white" align="center" width="10%" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="Center" bgcolor="gainsboro">
                        <strong>2．质 押 物 详 细 情 况</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序：
                    </td>
                    <td>
                        质押物类别：
                    </td>
                    <td>
                        质押物数量：
                    </td>
                    <td>
                        单位：
                    </td>
                    <td>
                        估值：
                    </td>
                    <td align="center">
                        操作：
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1 %>
                </td>
                <td>
                    <%#Eval("wplb")%>
                </td>
                <td>
                    <%#Eval("wpsl")%>
                </td>
                <td>
                    <%#Eval("wpdw")%>
                </td>
                <td>
                    <%#PubComm.GetNumberFormat(Eval("wpjz"))%>
                </td>
                <td>
                    <asp:Label ID="dzyw" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                    <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CommandArgument="1"
                        CssClass="blue1">修改</asp:LinkButton>
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
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
        <tr height="30">
            <td align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button2" runat="server" type="button" value="打印资产担保情况" class="but" onclick="return Button2_onclick()" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
