<%@ page title="档案查询结果" language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_DangAnSearchResult, App_Web_d1onhsud" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
        </colgroup>
        <tr height="25" bgcolor="gainsboro">
            <td colspan="5" align="Center">
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
            <td>
                操作
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
                        <%#Eval("ajfile")%>
                    </td>
                    <td>
                        <asp:HyperLink ID="hyper1" CssClass="blue" runat="server" NavigateUrl="seePDF.aspx"
                            Target="_blank" Text="浏览"></asp:HyperLink>
                        <asp:HyperLink ID="hyper2" CssClass="blue" runat="server" NavigateUrl="borrow.aspx"
                            Text="申请借阅"></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
</asp:Content>
