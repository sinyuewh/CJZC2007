<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AnJuanDetailEdit, App_Web_d1onhsud" title="案卷信息维护" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function ShowFileInfo(id)
    {
        url="ShowFileInfo.aspx?id="+id;
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
                <strong><font color="#ffffff">案 卷 详 细 数 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：</td>
            <td>
                <asp:TextBox ID="ajnum" runat="server" Width="185px"></asp:TextBox>
            </td>
            <td>
                案卷名称：</td>
            <td>
                <asp:TextBox ID="ajname" runat="server" Width="185px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                案卷分类：</td>
            <td>
                <asp:DropDownList ID="ajkind" runat="server" Width="190px">
                </asp:DropDownList></td>
            <td>
                当前状态：</td>
            <td>
                <asp:Label ID="ajstatus" runat="server" ForeColor="red"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:TextBox ID="depart" runat="server" Width="185px"></asp:TextBox>
            <td>
                责任人：</td>
            <td>
                <asp:TextBox ID="zeren" runat="server" Width="185px"></asp:TextBox>
        </tr>
        <tr height="25" style="display: none">
            <td>
                立案时间：</td>
            <td>
                <asp:TextBox ID="time0" runat="server" Width="185px"></asp:TextBox></td>
            <td>
                立 案 人：</td>
            <td>
                <asp:TextBox ID="ljren" runat="server" Width="185px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                备 &nbsp; &nbsp;&nbsp; &nbsp; 注：</td>
            <td colspan="3">
                <asp:TextBox ID="remark" runat="server" Width="185px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <b>案 卷 移 交 情 况</b>
            </td>
        </tr>
        <tr height="25">
            <td>
                移交单位：</td>
            <td>
                <asp:Label ID="yjdanwei" runat="server"></asp:Label>&nbsp
            </td>
            <td>
                经 手 人：</td>
            <td>
                <asp:Label ID="jsren" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                移交时间：</td>
            <td>
                <asp:Label ID="yjtime" runat="server"></asp:Label></td>
            <td>
                移交说明：</td>
            <td>
                <asp:Label ID="remark1" runat="server"></asp:Label></td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="移交案卷" OnClick="Button2_Click1" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="返 回" OnClick="Button3_Click" /></td>
        </tr>
    </table>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="8%" />
                    <col bgcolor="white" align="center" width="34%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" width="10%" />
                    <col bgcolor="white" align="center" />
                </colgroup>
                <tr height="25">
                    <td colspan="7" align="center" bgcolor="gainsboro">
                        <strong>卷 内 文 件</strong>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Button2_Click" CssClass="blue2">新增卷内文件>></asp:LinkButton>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        序号
                    </td>
                    <td width="30%">
                        文件名称
                    </td>
                    <td>
                        文件份数
                    </td>
                    <td>
                        文件页数
                    </td>
                    <td>
                        借阅人
                    </td>
                    <td>
                        借出时间
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
                    <%--<a href="javaScript:ShowFileInfo('<%#Eval("id") %>');" class="blue1">
                        <%# Eval("Remark") %>
                    </a>--%>
                    <%# Eval("title")%>
                </td>
                <td>
                    <%#Eval("filefs") %>
                </td>
                <td>
                    <%#Eval("filecount") %>
                </td>
                <td>
                    <asp:Label ID="jyue" runat="server" Text='<%#Eval("jyue") %>'></asp:Label>
                </td>
                <td>
                    <%#Eval("jyuetime") %>
                </td>
                <td>
                    <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="LinkbutEdit" runat="server" CommandName="edit" CssClass="blue"><a href="EditFile.aspx?fileID=<%#Eval("id")%>" class="blue">修改</a></asp:LinkButton>
                    <asp:LinkButton ID="LinkbutDel" runat="server" CommandName="delete" CssClass="blue"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
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
</asp:Content>
