<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AnJuanDetail, App_Web_d1onhsud" title="案卷明细信息" stylesheettheme="CjzcWeb" %>

<%--<%@ Register Src="~/Common/Controls/footer.ascx" TagName="AnJuanFooter" TagPrefix="f1" %>--%>
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
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
            <col bgcolor="white" align="right" width="15%" />
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
                <asp:Label ID="ajnum" runat="server"></asp:Label></td>
            <td>
                案卷名称：</td>
            <td>
                <asp:Label ID="ajname" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                案卷分类：</td>
            <td>
                <asp:Label ID="ajkind" runat="server"></asp:Label></td>
            <td>
                当前状态：</td>
            <td>
                <asp:Label ID="ajstatus" runat="server" ForeColor="red"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:Label ID="depart" runat="server"></asp:Label></td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server"></asp:Label></td>
        </tr>
        <tr height="25" style="display: none">
            <td>
                立案时间：</td>
            <td>
                &nbsp;<asp:Label ID="time0" runat="server"></asp:Label></td>
            <td>
                立 案 人：</td>
            <td>
                <asp:Label ID="ljren" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                备 &nbsp; &nbsp;&nbsp; &nbsp; 注：</td>
            <td colspan="3">
                <asp:Label ID="remark" runat="server"></asp:Label></td>
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
                <asp:Button ID="Button1" runat="server" Text="返 回" OnClientClick="javascript:history.go(-1);return false;" /></td>
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
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="center" bgcolor="gainsboro">
                        <strong>卷 内 文 件</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        序号
                    </td>
                    <td width="30%">
                        文件名
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
                    <%# Eval("title") %>
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
