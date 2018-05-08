<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZcBaoDetail4.aspx.cs" Inherits="ZcMng2_ZcBaoDetail4" Title="资产包方案执行" %>

<%@ Register Src="ZcBaoDetailKind.ascx" TagName="ZcBaoDetailKind" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
        function EditFileAttach(id)
        {
           url="ZcTcAttach.aspx?id="+id+"&zcid=<%#Request["id"]%>&bkind=1";
           winOpenOfen(url,600,400);
        }
        function Button5_onclick() 
        {
            url="Zcfazxb.aspx?zcid=<%#Request["id"]%>";    
            window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
        }
        function SeeZcTcInfo(infoid)
        {
            var url="ZcTcDetail.aspx?id="+infoid;
            winOpenOfen(url,600,400);
        }
        
    </script>
    <uc1:ZcBaoDetailKind ID="ZcBaoDetailKind1" runat="server" />
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
                <strong><font color="#ffffff">方 案 执 行</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：</td>
            <td colspan="3">
                <asp:Label ID="Bname" runat="server"></asp:Label>
                <asp:Label ID="Bid" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任人：</td>
            <td>
                &nbsp;<asp:Label ID="bzeren" runat="server"></asp:Label>
                （<asp:Label ID="depart" runat="server"></asp:Label>）
            </td>
            <td>
                当前状态：</td>
            <td>
                &nbsp;<asp:Label ID="statusText" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="status" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
       <%-- <tr height="25">
            <td>
                律师事务所：
            </td>
            <td>
                <asp:TextBox ID="lssws" runat="server"></asp:TextBox>
                <asp:Label ID="lssws_1" runat="server"></asp:Label>
            </td>
            <td>
                负责人：
            </td>
            <td>
                <asp:TextBox ID="frdb" runat="server"></asp:TextBox>
                <asp:Label ID="frdb_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                委托律师：
            </td>
            <td>
                <asp:TextBox ID="wtls" runat="server"></asp:TextBox>
                <asp:Label ID="wtls_1" runat="server"></asp:Label>
            </td>
            <td>
                联系电话：
            </td>
            <td>
                <asp:TextBox ID="lxdh" runat="server"></asp:TextBox>
                <asp:Label ID="lxdh_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位地址：
            </td>
            <td>
                <asp:TextBox ID="dwdz" runat="server"></asp:TextBox>
                <asp:Label ID="dwdz_1" runat="server"></asp:Label>
            </td>
            <td>
                电子邮件：
            </td>
            <td>
                <asp:TextBox ID="dzyj" runat="server"></asp:TextBox>
                <asp:Label ID="dzyj_1" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <%--<asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
                &nbsp;&nbsp; &nbsp;&nbsp; --%><span id="MyButtonGroup" runat="server" visible="false">
                    <asp:Button ID="Button21" runat="server" CommandArgument="21" Text="协商谈判" OnCommand="Button01_Command" />
                    <asp:Button ID="Button22" runat="server" CommandArgument="22" Text="诉 讼" OnCommand="Button01_Command" />
                    <asp:Button ID="Button23" runat="server" CommandArgument="23" Text="申请执行" OnCommand="Button01_Command" />
                    <asp:Button ID="Button24" runat="server" CommandArgument="24" Text="强制执行" OnCommand="Button01_Command" />
                    <asp:Button ID="Button25" runat="server" CommandArgument="25" Text="中止执行" OnCommand="Button01_Command" />
                    <asp:Button ID="Button26" runat="server" CommandArgument="26" Text="终止执行" OnCommand="Button01_Command" />
                    <asp:Button ID="Button27" runat="server" CommandArgument="27" Text="办结" OnCommand="Button01_Command" />
                </span>
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
                        <strong>1．协 商 谈 判</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
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
                        <strong>2．诉 讼 记 录</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
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
                        <strong>3．申 请 执 行</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
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
                        <strong>4．强 制 执 行</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater1_ItemCommand"
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
                        <strong>5．中 止 执 行</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater1_ItemCommand"
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
                        <strong>6．终 止 执 行</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater7" runat="server" OnItemCommand="Repeater1_ItemCommand"
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
                        <strong>7．资 产 办 结</strong>
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
                        <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
