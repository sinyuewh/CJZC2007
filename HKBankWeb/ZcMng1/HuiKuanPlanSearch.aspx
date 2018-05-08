<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="HuiKuanPlanSearch.aspx.cs" Inherits="ZcMng1_HuiKuanPlanSearch" Title="回款计划" %>

<%@ Register Src="SearchHuiKuanPlan.ascx" TagName="SearchHuiKuanPlan" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
        
    </script>

    <div id="SearchTable" runat="server">
        <uc1:SearchHuiKuanPlan ID="SearchHuiKuanPlan1" runat="server" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;提示：为满足响应速度，最多只显示前500行满足条件的数据(公司领导、资产评审员可查询所有回款计划，部门领导可浏览自己和本部门所有人员回款计划，
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;其他人员只可浏览本人和本人协管的回款计划）
    </div>
    <div id="SearchInfo" runat="server" visible="false" align="center">
        <table width="98%" align="center" border="0" cellpadding="1" style="margin-top: 10px"
            cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="center" width="6%" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="right" />
                <col bgcolor="white" align="left" />
                <col bgcolor="white" align="center" />
            </colgroup>
            <tr height="25">
                <td>
                    次序
                </td>
                <td>
                    编号
                </td>
                <td>
                    责任人
                </td>
                <td>
                    名称
                </td>
                <td>
                    回款时间
                </td>
                <td>
                    回款金额&nbsp;
                </td>
                <td>
                    备注
                </td>
                <td>
                    类别
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr height="25">
                        <td>
                            <%#Container.ItemIndex+1%>
                        </td>
                        <td>
                            <%#Eval("num2") %>
                        </td>
                        <td>
                            <%#Eval("zeren") %>
                        </td>
                        <td>
                            <%#Eval("danwei") %>
                        </td>
                        <td>
                            <%#Eval("time0","{0:yyyy-MM-dd}") %>
                        </td>
                        <td>
                            <%#Eval("pbj", "{0:n}")%>&nbsp;
                        </td>
                        <td>
                            <%#Eval("remark") %>
                        </td>
                        <td>
                            <%#Eval("kind1") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
            <tr height="25">
                <td>
                    合计
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="heji" ForeColor="Red" runat="server" Text="0"></asp:Label>&nbsp;
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table>
            <tr height="3">
                <td style="width: 3px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
