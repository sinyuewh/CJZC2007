<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_ZcDetail2, App_Web_kckafmby" title="尽职调查" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
        function EditFileAttach(id)
        {
           url="ZcTcAttach.aspx?id="+id+"&zcid=<%#Request["id"]%>&bkind=0";
           winOpenOfen(url,600,400);
        }
        
        function ShowAttach()
        {
            url="TcDoc.aspx?zcid=<%#Request["id"]%>";
           winOpenOfen(url,600,400);
        }
        function Button5_onclick() 
        {
            url="Zcjzdcb.aspx?zcid=<%#Request["id"]%>";    
            window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
        }
        function SeeZcTcInfo(infoid)
        {
            var url="ZcTcDetail.aspx?id="+infoid;
            winOpenOfen(url,600,400);
        }
    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" width="30%" />
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">尽 职 调 查</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td colspan="3">
                <asp:Label ID="danwei" runat="server"></asp:Label>
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
        <tr>
            <td colspan="4" align="center" height="30">
                <span id="but01" runat="server" visible="false">
                    <asp:Button ID="Button01" runat="server" CommandArgument="01" Text="阅 卷" OnCommand="Button01_Command" />&nbsp;&nbsp;
                </span><span id="but02" runat="server" visible="false">
                    <asp:Button ID="Button02" runat="server" CommandArgument="02" Text="下 户" OnCommand="Button01_Command" />&nbsp;&nbsp;
                </span><span id="but03" runat="server" visible="false">
                    <asp:Button ID="Button03" runat="server" CommandArgument="03" Text="取 证" OnCommand="Button01_Command" />&nbsp;&nbsp;
                </span><span id="but04" runat="server" visible="false">
                    <asp:Button ID="Button04" runat="server" CommandArgument="04" Text="报 告" OnCommand="Button01_Command" />
                </span>
               &nbsp;<input id="Button5" type="button" runat="server" value="打印尽职调查数据" class="but" onclick="return Button5_onclick()" style="width: 125px" /> 
            </td>
        </tr>
        
    </table>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater_DataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="23%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="Center" bgcolor="gainsboro">
                        <strong>1．阅 卷 记 录</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        登记时间
                    </td>
                    <td>
                        登记人
                    </td>
                    <td>
                        主要内容</td>
                    <td>
                        地点</td>
                    <td align="center">
                        结果
                    </td>
                    <td>
                        状态
                    </td>
                    <td align="center">
                        相关附件
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
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td align="left">
                    <a href="javaScript:SeeZcTcInfo('<%#Eval("id") %>')" class="blue1"><%#Eval("remark1") %></a>
                </td>
                <td>
                    <%#Eval("didian") %>
                </td>
                <td align="center">
                    <%#Eval("jieguo") %>
                </td>
                <td>
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
                <td align="center">
                    <a href="javaScript:EditFileAttach('<%#Eval("id") %>')" class="blue1">附件（<%#Eval("fcount") %>）</a>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                    <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定需要作废吗？');">作废</asp:LinkButton>
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
    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater_DataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="23%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="Center" bgcolor="gainsboro">
                        <strong>2．下 户 记 录</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        登记时间
                    </td>
                    <td>
                        登记人
                    </td>
                    <td>
                        主要内容</td>
                    <td>
                        地点</td>
                    <td align="center">
                        结果
                    </td>
                    <td>
                        状态
                    </td>
                    <td align="center">
                        相关附件
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
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td align="left">
                    <a href="javaScript:SeeZcTcInfo('<%#Eval("id") %>')" class="blue1"><%#Eval("remark1") %></a>
                </td>
                <td>
                    <%#Eval("didian") %>
                </td>
                <td align="center">
                    <%#Eval("jieguo") %>
                </td>
                <td>
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
                <td align="center">
                    <a href="javaScript:EditFileAttach('<%#Eval("id") %>')" class="blue1">附件（<%#Eval("fcount") %>）</a>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                    <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定需要作废吗？');">作废</asp:LinkButton>
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
    <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater_DataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="gainsboro">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="23%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="Center" bgcolor="gainsboro">
                        <strong>3．取 证 记 录</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        登记时间
                    </td>
                    <td>
                        登记人
                    </td>
                    <td>
                        主要内容</td>
                    <td>
                        地点</td>
                    <td align="center">
                        结果
                    </td>
                    <td>
                        状态
                    </td>
                    <td align="center">
                        相关附件
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
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td align="left">
                    <a href="javaScript:SeeZcTcInfo('<%#Eval("id") %>')" class="blue1"><%#Eval("remark1") %></a>
                </td>
                <td>
                    <%#Eval("didian") %>
                </td>
                <td align="center">
                    <%#Eval("jieguo") %>
                </td>
                <td>
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
                <td align="center">
                    <a href="javaScript:EditFileAttach('<%#Eval("id") %>')" class="blue1">附件（<%#Eval("fcount") %>）</a>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                    <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定需要作废吗？');">作废</asp:LinkButton>
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
    <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater_DataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="gainsboro">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="23%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="Center" bgcolor="gainsboro">
                        <strong>4．报 告 记 录</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        登记时间
                    </td>
                    <td>
                        登记人
                    </td>
                    <td>
                        主要内容</td>
                    <td>
                        地点</td>
                    <td align="center">
                        结果
                    </td>
                    <td>
                        状态
                    </td>
                    <td align="center">
                        相关附件
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
                    <%#Eval("time0","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td align="left">
                    <a href="javaScript:SeeZcTcInfo('<%#Eval("id") %>')" class="blue1"><%#Eval("remark1") %></a>
                </td>
                <td>
                    <%#Eval("didian") %>
                </td>
                <td align="center">
                    <%#Eval("jieguo") %>
                </td>
                <td>
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                </td>
                <td align="center">
                    <a href="javaScript:EditFileAttach('<%#Eval("id") %>')" class="blue1">附件（<%#Eval("fcount") %>）</a>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                    <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定需要作废吗？');">作废</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
