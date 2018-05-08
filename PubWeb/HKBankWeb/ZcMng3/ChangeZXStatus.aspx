<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_ChangeZXStatus, App_Web_pyuhrx5l" title="更改方案的当前状态" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function CheckData1() {
            var result = true;
            if (document.getElementById("<%= this.spresult.ClientID%>").value == "") {
                alert("错误：请选择一个[方案执行结果]！");
                return false;
            }

            if (document.getElementById("<%= this.spresult.ClientID%>").value != "未启动"
                && document.getElementById("<%= this.spresult.ClientID%>").value != "其他") {
                if (document.getElementById("<%= this.status1.ClientID%>").value == "") {
                    alert("错误：请选择一个[方案执行状态]大类！");
                    return false;
                }

                if (document.getElementById("<%= this.status2.ClientID%>").value == "") {
                    alert("错误：请选择一个[方案执行状态]小类！");
                    return false;
                }

                if (document.getElementById("<%= this.dotime.ClientID%>").value == "") {
                    alert("错误：请输入[执行时间]（注不是登记时间）！");
                    return false;
                }

                if (document.getElementById("<%= this.remark.ClientID%>").value == "") {
                    alert("错误：请输入[相关说明]！");
                    return false;
                }
            }
            else {
                if (document.getElementById("<%= this.status1.ClientID%>").value == "") {
                    alert("错误：请选择一个[方案执行状态]大类！");
                    return false;
                }
            }

            return result;
        }
    </script>

    <table width="85%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="20%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    <asp:Label ID="dckind" runat="server" Text="更改方案的执行结果和状态"></asp:Label>
                </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                方案执行结果：
            </td>
            <td>
                <asp:DropDownList ID="spresult" runat="server" AutoPostBack="True" OnSelectedIndexChanged="spresult_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                方案执行状态：
            </td>
            <td>
                <asp:DropDownList ID="status1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="status1_SelectedIndexChanged">
                </asp:DropDownList>
                <span id="span1" runat="server">－
                    <asp:DropDownList ID="status2" runat="server">
                    </asp:DropDownList>
                </span>
            </td>
        </tr>
        <tr height="25">
            <td>
                执行时间：
            </td>
            <td>
                <asp:TextBox ID="dotime" runat="server" onfocus="setday(this);"></asp:TextBox>（注：不是当前登记的时间）
            </td>
        </tr>
        <tr height="25">
            <td style="height: 84px">
                相关说明：
            </td>
            <td>
                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Height="74px" Width="94%"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button2" runat="server" Text="提交数据" OnClientClick="javascript:return CheckData1();"
                    OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
