<%@ control language="C#" autoeventwireup="true" inherits="ZcMng3_Info1, App_Web_ubawstme" %>
<%@ Import Namespace="System" %>
<style type="text/css">
    .style1
    {
        color: #0000FF;
    }
</style>
<script language="javascript" type="text/javascript">
    function deleteFile()
    {
        var sel=false;;
        var v1=document.getElementsByName("selFile");
        for(var i=0;i<v1.length;i++)
        {
            if(v1[i].checked==true)
            {
                sel=true ;
            }
        }
        if(sel)
        {
            return confirm("警告：确定要删除选中的文件吗？");
        }
        else
        {
            alert("提示：没有选中要删除的文件！");
        }
        return false;
    }
</script>
<div id="tab1" runat="server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="22%" />
            <col bgcolor="white" align="left" width="28%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><span style="color: #ffffff">1、项 目 情 况</span></strong></td>
        </tr>
        <tr height="25">
            <td>
                承办部门：
            </td>
            <td>
                <asp:Label ID="depart" runat="server"></asp:Label></td>
            <td>
                经 办 人：
            </td>
            <td>
                <asp:Label ID="zeren" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                立项时间：
            </td>
            <td>
                <asp:TextBox ID="shijian1" runat="server"></asp:TextBox></td>
            <td>
                项目状态：
            </td>
            <td>
                <asp:Label ID="status" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="statusText" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                <font color='#ff0000'>项目批准时间：</font>
            </td>
            <td colspan="3">
                <asp:TextBox ID="shijian2" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                项目申报号：
            </td>
            <td>
                <asp:TextBox ID="xmsbh" runat="server" Text=""></asp:TextBox>（号）</td>
            <td>
                项目档案号：
            </td>
            <td>
                <asp:TextBox ID="num2" runat="server" Text=""></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                项目名称：
            </td>
            <td colspan="3" width="82%">
                <asp:TextBox ID="xmmc" runat="server" Width="483px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                债务单位：
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="danwei" runat="server" Text="" Height="40px" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
            <td style="height: 25px">
                担保单位：
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="bzrmc" runat="server" Text="" Height="40px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td style="height: 24px">
                债务人主管部门或所属：
            </td>
            <td style="height: 24px">
                <asp:TextBox ID="zwzg" runat="server" Text=""></asp:TextBox>
            </td>
            <td style="height: 24px">
                债权时效：
            </td>
            <td style="height: 24px">
                <asp:TextBox ID="zqsx" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产类型：
            </td>
            <td>
                <asp:TextBox ID="zclx" runat="server"></asp:TextBox>
            </td>
            <td>
                资产数额：
            </td>
            <td>
                <asp:TextBox ID="zcse" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                价值：
            </td>
            <td>
                <asp:TextBox ID="jiazhi" runat="server" Width="120px"></asp:TextBox>（元）
            </td>
            <td>
                债权总额：
            </td>
            <td>
                <asp:TextBox ID="zqce" runat="server" Text=""></asp:TextBox>
                （元）</td>
        </tr>
        <tr height="25">
            <td>
                其中本金：
            </td>
            <td>
                <asp:TextBox ID="benjin" runat="server" Text="" Width="120px"></asp:TextBox>
                （元）
            </td>
            <td>
                利息：
            </td>
            <td>
                <asp:TextBox ID="lixi" runat="server" Text=""></asp:TextBox>（元）
            </td>
        </tr>
        
        <tr height="25" id="RowFile1" runat="server" visible="false">
            <td>
                <span class="style1">项目审批表（Word文件）：</span>
            </td>
            <td colspan="3">
                <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="text" Height="19px" />&nbsp;
                <asp:Button ID="Button1" runat="server" Text="上传" onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="删除" onclick="Button2_Click"  OnClientClick="javaScript:if(deleteFile()==false) return false;" />
                <div >
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <input id="selFile" name="selFile" type="checkbox" value='<%#Eval("id")%>' title="选中可删除" />
                            <a href='OpenFile.aspx?id=<%#Eval("id")%>' target="_blank" title="浏览文件">
                                [<%#Eval("trueName")%>]</a>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            |
                        </SeparatorTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
        
        <tr height="25">
            <td>
                项目背景：
            </td>
            <td colspan="3">
                <asp:TextBox ID="xmbj" runat="server" TextMode="MultiLine" Width="87%" Height="150px"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<div id="tab2" runat="server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="22%" />
            <col bgcolor="white" align="left" width="28%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><span style="color: #ffffff">1、项 目 情 况</span></strong></td>
        </tr>
        <tr height="25">
            <td>
                承办部门：
            </td>
            <td>
                <asp:Label ID="depart_1" runat="server"></asp:Label></td>
            <td>
                经 办 人：
            </td>
            <td>
                <asp:Label ID="zeren_1" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                立项时间：
            </td>
            <td>
                <asp:Label ID="shijian1_1" runat="server"></asp:Label></td>
            <td>
                项目状态：
            </td>
            <td>
                <asp:Label ID="statusText_1" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                <font color='#ff0000'>项目批准时间：</font>
            </td>
            <td colspan="3">
                <asp:Label ID="shijian2_1" runat="server"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                项目申报号：
            </td>
            <td>
                <asp:Label ID="xmsbh_1" runat="server"></asp:Label>（号）</td>
            <td>
                项目档案号：
            </td>
            <td>
                <asp:Label ID="num2_1" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                项目名称：
            </td>
            <td colspan="3" width="82%">
                <asp:Label ID="xmmc_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                债务单位：
            </td>
            <td style="height: 25px">
                <asp:Label ID="danwei_1" runat="server" Text=""></asp:Label></td>
            <td style="height: 25px">
                担保单位：
            </td>
            <td style="height: 25px">
                <asp:Label ID="bzrmc_1" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                债务人主管部门或所属：
            </td>
            <td>
                <asp:Label ID="zwzg_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                债权时效：
            </td>
            <td>
                <asp:Label ID="zqsx_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产类型：
            </td>
            <td>
                <asp:Label ID="zclx_1" runat="server"></asp:Label>
            </td>
            <td>
                资产数额：
            </td>
            <td>
                <asp:Label ID="zcse_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                价值：
            </td>
            <td>
                <asp:Label ID="jiazhi_1" runat="server"></asp:Label>（元）
            </td>
            <td>
                债权总额：
            </td>
            <td>
                <asp:Label ID="zqce_1" runat="server" Font-Bold="True"></asp:Label>
                （元）</td>
        </tr>
        <tr height="25">
            <td>
                其中本金：
            </td>
            <td>
                <asp:Label ID="benjin_1" runat="server" Font-Bold="True"></asp:Label>（元）
            </td>
            <td>
                利息：
            </td>
            <td>
                <asp:Label ID="lixi_1" runat="server" Font-Bold="True"></asp:Label>（元）
            </td>
        </tr>
        <tr height="25">
            <td>
                <span class="style1">项目审批表（Word文件）：</span>
            </td>
            <td colspan="3">
                <div style="padding: 10 10 10 10; margin:10 10 10 10">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <a href='OpenFile.aspx?id=<%#Eval("id")%>' target="_blank" title="浏览文件">
                                [<%#Eval("trueName")%>]</a>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            |
                        </SeparatorTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
        <tr height="25">
            <td>
                项目背景：
            </td>
            <td colspan="3">
                <asp:Label ID="xmbj_1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
