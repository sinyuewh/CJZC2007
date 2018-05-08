<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_ZcLogSearch, App_Web_z4gjhdph" title="资产日志综合查询" stylesheettheme="CjzcWeb" %>

<%@ Register Src="SearchZcLog.ascx" TagName="SearchZcLog" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
        function EditFileAttach(id)
        {
           url="../ZcMng2/ZcTcAttach.aspx?id="+id+"&zcid=<%#Request["id"]%>&bkind=0";
           winOpenOfen(url,600,400);
        }
        
        
        function SeeZcTcInfo(infoid)
        {
            var url="../ZcMng2/ZcTcDetail.aspx?id="+infoid;
            winOpenOfen(url,600,400);
        }
        
        
        function writeRemark(id1)
        {
            var url="leader_remarkEdit.aspx?id="+id1;
            winOpenOfen(url,600,250);
        }
    </script>

    <div id="SearchTable" runat="server">
        <uc1:SearchZcLog ID="SearchZcLog1" runat="server" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;提示：为满足响应速度，最多只显示前500行满足条件的数据(公司领导、资产评审员可查询所有日志，部门领导可浏览自己和本部门所有人员日志，
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;其他人员只可浏览本人和本人协管的资产日志）
    </div>
    <div id="SearchInfo" runat="server" visible="false" align="center">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table width="98%" align="center" border="0" cellpadding="1" style="margin-top: 10px"
                    cellspacing="1" bgcolor="#c5c5c5">
                    <colgroup>
                        <col bgcolor="white" align="center" width="6%" />
                        <col bgcolor="white" align="center" width="10%" />
                        <col bgcolor="white" align="center" width="8%" />
                        <col bgcolor="white" align="center" width="22%" />
                        <col bgcolor="white" align="center" width="23%" />
                        <col bgcolor="white" align="center" width="6%" />
                        <col bgcolor="white" align="left" width="6%" />
                        <col bgcolor="white" align="center" />
                    </colgroup>
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
                            项目名称
                        </td>
                        <td>
                            主要内容
                        </td>
                        <td>
                            地点
                        </td>
                        <td align="center">
                            结果
                        </td>
                        <td align="center">
                            类别
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
                        <a class="blue1" target="_blank" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("zcid") %>"
                            title="点击进入资产明细数据">
                            <%#Eval("danwei") %></a>
                    </td>
                    <td align="left">
                        <a href="javaScript:SeeZcTcInfo('<%#Eval("id") %>')" class="blue1">
                            <%#Eval("remark1") %></a>
                    </td>
                    <td>
                        <%#Eval("didian") %>
                    </td>
                    <td align="center">
                        <%#Eval("jieguo") %>
                    </td>
                    <td>
                        <asp:Label ID="kindCaption" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td colspan="7" style="text-align: left; padding-left: 10px; padding-right: 10px">
                        <%#Eval("leader_remark").ToString() == String.Empty ? "未评" : Eval("leader_remark").ToString() %>
                        <%#Eval("leader_name").ToString()!=String.Empty 
                          ? "("+Eval("leader_name").ToString()+"-"+Eval("leader_time").ToString()+")" : "" %>
                    </td>
                    <td>
                        <span id="info1" runat="server"><a title ="直接部门主管进行评阅" class="blue1" href="javascript:writeRemark(<%#Eval("id") %>);">
                            领导评阅</a> </span>
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
    </div>
</asp:Content>
