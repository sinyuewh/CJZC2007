<%@ control language="C#" autoeventwireup="true" inherits="ZcMng3_info5, App_Web_ubawstme" %>

<script language="javascript">
    //修改相关的附件记录
    function EditFileAttach(id)
    {
       url="../ZcMng2/ZcTcAttach.aspx?id="+id+"&zcid=<%#this.ZcID%>&bkind=0";
       window.showModalDialog(url,"","dialogLeft=150px;dialogTop=100px;dialogWidth=600px;dialogHeight=400px;status=no");
       top.location.href=top.location.href;
    }
    
    //流利详细的记录内容
    function SeeZcTcInfo(infoid)
    {
        var url="../ZcMng2/ZcTcDetail.aspx?id="+infoid;
        winOpenOfen(url,600,400);
    }
</script>

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
            <span style="color: #ff0000">方案执行结果</span>：
        </td>
        <td colspan="3">
            <asp:Label ID="spresult" runat="server" ForeColor="blue"></asp:Label>
        </td>
    </tr>
    
    <tr height="25">
        <td>
            方案执行状态：
        </td>
        <td colspan="3">
            <asp:Label ID="status1" runat="server" ForeColor="blue"></asp:Label>－<asp:Label ID="status2"
                runat="server" ForeColor="blue"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" OnCommand="Button1_Command"
                Text="更改方案的执行状态>>" Width="150px" />&nbsp;
        </td>
    </tr>
    <tr height="25">
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
    </tr>
</table>

<asp:Repeater ID="Rep0" runat="server" OnItemDataBound="Rep0_ItemDataBound">
    <ItemTemplate>
        <br />
        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="center" width="6%" />
                <col bgcolor="white" align="center" width="12%" />
                <col bgcolor="white" align="center" width="10%" />
                <col bgcolor="white" align="center" width="10%" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="left" width="10%" />
                <col bgcolor="white" align="center" width="10%" />
                <col bgcolor="white" align="center" width="11%" />
            </colgroup>
            <tr height="25">
                <td colspan="8" align="Center" bgcolor="gainsboro">
                    <strong>
                        <%#Container.ItemIndex+1%>.<%#Container.DataItem%></strong>
                </td>
            </tr>
            <tr height="25">
                <td>
                    次序
                </td>
                <td>
                    登记时间
                </td>
                <td>
                    登记人
                </td>
                <td>
                    执行时间
                </td>
                <td>
                    主要内容
                </td>
                <td align="center">
                    类别
                </td>
                <td align="center">
                    相关附件
                </td>
                <td align="center">
                    操作
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                OnItemDataBound="Repeater_DataBound">
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
                        <td>
                            <%#Eval("dotime","{0:yyyy-M-d}") %>
                        </td>
                        <td align="left">
                            <a href="javaScript:SeeZcTcInfo('<%#Eval("id") %>')" class="blue1">
                                <%#Eval("remark1") %>
                            </a>
                        </td>
                        <td align="center">
                            <%#Eval("status2") %>
                        </td>
                        <td align="center">
                            <a href="javaScript:EditFileAttach('<%#Eval("id") %>')" class="blue1">附件（<asp:Label
                                ID="filecount" runat="server" Text="0"></asp:Label>）</a>
                        </td>
                        <td align="center">
                            <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="butDel" runat="server" CommandName="deleted" CssClass="blue1"
                                CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table>
            <tr height="3">
                <td style="width: 3px">
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>

