<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_AddZC, App_Web_jdf3giep" title="增加新资产" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 资 产 的 基 本 资 料</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td>
                <asp:TextBox ID="danwei" runat="server"></asp:TextBox></td>
            <td>
                是否总行委贷：
            </td>
            <td>
                <asp:DropDownList ID="zhwd" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                编号：
            </td>
            <td>
                <asp:TextBox ID="num1" runat="server"></asp:TextBox>
            </td>
            <td>
                用户自定义分类：</td>
            <td>
                <asp:CheckBoxList ID="userkind" runat="server" >
                </asp:CheckBoxList></td>
        </tr>
        <tr height="25">
            <td>
                货币：
            </td>
            <td>
                <asp:DropDownList ID="huobi" runat="server">
                    <asp:ListItem>人民币</asp:ListItem>
                    <asp:ListItem>美元</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                汇率：
            </td>
            <td>
                <asp:TextBox ID="huilv" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                初始本金：</td>
            <td>
                <asp:TextBox ID="bj" runat="server"></asp:TextBox></td>
            <td>
                初始表内息：</td>
            <td>
                <asp:TextBox ID="lx1" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                初始表外息：</td>
            <td>
                <asp:TextBox ID="lx2" runat="server"></asp:TextBox></td>
            <td>
                初始孳生利息：</td>
            <td>
                <asp:TextBox ID="lx3" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                所属行业：
            </td>
            <td>
                <asp:DropDownList ID="sshy" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                行政区域：</td>
            <td>
                <asp:DropDownList ID="quyu" runat="server" Width="80">
                </asp:DropDownList></td>
        </tr>
        <tr height="25">
            <td>
                管 辖：
            </td>
            <td>
                <asp:DropDownList ID="guangxia" runat="server">
                </asp:DropDownList>
            </td>
            <td style="height: 25px">
                政策包类别：</td>
            <td style="height: 25px">
                <asp:DropDownList ID="zcbao" runat="server" Width="80">
                </asp:DropDownList></td>
        </tr>
        <tr height="25">
            <td>
                行 号：</td>
            <td>
                <asp:DropDownList ID="bank" runat="server" Width="120">
                </asp:DropDownList></td>
            <td>
                转让价：
            </td>
            <td>
                <asp:TextBox ID="zhuang" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                合同编号：</td>
            <td style="height: 25px">
                <asp:TextBox ID="htnum" runat="server"></asp:TextBox></td>
            <td>
                转入时间：</td>
            <td>
                <asp:TextBox ID="time0" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                五级分类：
            </td>
            <td>
                <asp:DropDownList ID="fenlei" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                备 注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" Width="85%"></asp:TextBox></td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="增加资产" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
