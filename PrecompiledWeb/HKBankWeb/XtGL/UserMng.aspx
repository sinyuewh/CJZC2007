<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_UserMng, App_Web_rhavpchx" title="用户管理" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>

<script runat="server">
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/jscript">
        function setDocFlag(check1,docName)
        {
            var item1=document.getElementsByName(docName);
            for(var i=0;i<item1.length;i++)
            {
                item1[i].checked=check1;
            }
        }
        
        function ChangeLeader()
        {
            var url="../DangAn/UserList.aspx";
            var str1=window.showModalDialog(url,str1,"dialogLeft:100pt;dialogTop:100pt;dialogWidth:480pt;dialogHeight:320pt");
            if(str1!=undefined)
            {
                document.getElementById("leader").value=str1;
                return true;
            }
            return false;
        }
    </script>

    <table width="100%">
        <tr>
            <td width="98%" valign="top">
                <div style=" padding-bottom:5px; margin-bottom:5px">
                状态过滤：<asp:DropDownList ID="status1" runat="server">
                    <asp:ListItem Text="正常" Value="0"></asp:ListItem>
                    <asp:ListItem Text="停用" Value="1"></asp:ListItem>
                    <asp:ListItem Text="所有" Value=""></asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:Button ID="button11" runat="server" Text="过滤" 
                        onclick="button11_Click" />
                </div>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                <input type="checkbox" id="selAllDoc" name="selAllDoc" onclick="javascript:setDocFlag(this.checked,'selDoc');" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="selDoc" name="selDoc" value='<%# Eval("sname")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="num" HeaderText="工号">
                            <HeaderStyle Width="6%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sname" HeaderText="姓名">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="depart" HeaderText="部门">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="job" HeaderText="职务">
                            <HeaderStyle Width="12%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="leader" HeaderText="主管">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cell" HeaderText="手机">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="电子邮件">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="18%" />
                            <ItemTemplate>
                                <a href="mailto:<%# Eval("email") %>" class="blue" target="_blank">
                                    <%# Eval("email")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lab1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemTemplate>
                                <a href="EditUser.aspx?id=<%#Eval("id")%>" class="blue">编辑</a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
                                    CssClass="blue" Text="删除" OnClientClick="javaScript:return confirm('警告：确定要删除数据吗？');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top" align="center">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="width:100%">
                    <tr>
                        <td>
                            <cc1:PageNavigator ID="PageNavigator1" runat="server" MaxNum="10" OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                                PageNavType="数字式" PageSize="13" />
                        </td>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="增 加" />
                            &nbsp;
                            <asp:Button ID="Button2" runat="server" Text="停用" ToolTip="停用用户" OnClientClick="return confirm('提示：确定执行操作吗？');" />
                            &nbsp;
                            <asp:Button ID="Button3" runat="server" Text="启用" ToolTip="启用用户" OnClientClick="return confirm('提示：确定执行操作吗？');" />
                            &nbsp;
                            <asp:Button ID="Button5" runat="server" Text="调整直接主管" OnClientClick="javascript:return ChangeLeader();" />
                            &nbsp;
                            <asp:DropDownList ID="depart" runat="server">
                            </asp:DropDownList>
                            <asp:Button ID="Button4" runat="server" Text="更换部门" OnClientClick="return confirm('提示：确定执行操作吗？');" />
                            <input id="leader" name="leader" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
