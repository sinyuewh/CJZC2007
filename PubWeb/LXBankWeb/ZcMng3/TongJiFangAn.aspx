<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_TongJiFangAn, App_Web_-gbu33-0" title="方案审批表的统计" stylesheettheme="CjzcWeb" %>

<%@ Register Src="../JueCeZhiChi/SelectTime.ascx" TagName="SelectTime" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="SearchTable" runat="server" style="text-align:center">
        <uc1:SelectTime ID="SelectTime1" runat="server" />
        <br />
        注：统计的时间是按会议时间进行的（<asp:Label ID="tjkind" runat="server"></asp:Label>）。
    </div>
    <div id="SearchInfo" runat="server" visible="false" style="text-align: center">
        <table width="99%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="center" width="80"  />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
            </colgroup>
            <tr height="25">
                <td colspan="13" align="center" bgcolor="#5d7b9d">
                    <strong><font color="#ffffff">资产处置方案统计结果[<asp:Literal ID="lt1" runat="server"></asp:Literal>～<asp:Literal ID="lt2" runat="server"></asp:Literal>]</font></strong></td>
            </tr>
            <tr height="25" >
                <td rowspan="2">
                    部门
                </td>
                <td rowspan="2">
                    审批中
                </td>
                <td colspan="3">
                    已批准
                </td>
                <td colspan="8">
                    执行中
                </td>
            </tr>
            <tr height="25">
                <td>
                    审核项目
                </td>
                <td>
                    决策项目
                </td>
                <td>
                    小计
                </td>
                <td>
                    协商谈判
                </td>
                <td>
                    诉讼
                </td>
                <td>
                    申请执行
                </td>
                <td>
                    强制执行
                </td>
                <td>
                    中止执行
                </td>
                <td>
                    终止执行
                </td>
                <td>
                    办结
                </td>
                <td>
                    小计
                </td>
            </tr>
            <asp:Repeater ID="repeater1" runat="server">
                <ItemTemplate>
                    <tr height="25">
                        <td>
                            <%#Eval("depart") %>
                        </td>
                        <td>
                            <%#Eval("num1") %>
                        </td>
                        <td>
                            <%#Eval("num2") %>
                        </td>
                        <td>
                            <%#Eval("num3") %>
                        </td>
                        <td>
                            <%#Eval("num4") %>
                        </td>
                        <td>
                            <%#Eval("num5") %>
                        </td>
                         <td>
                            <%#Eval("num6") %>
                        </td>
                        <td>
                            <%#Eval("num7") %>
                        </td>
                        <td>
                            <%#Eval("num8") %>
                        </td>
                        <td>
                            <%#Eval("num9") %>
                        </td>
                        <td>
                            <%#Eval("num10") %>
                        </td>
                        <td>
                            <%#Eval("num11") %>
                        </td>
                        <td>
                            <%#Eval("num12") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <asp:Button ID="but1" runat="server" Text="重新统计" OnClick="but1_Click" />
    </div>
</asp:Content>
