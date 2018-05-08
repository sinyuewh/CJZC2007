<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_ReceiveMail, App_Web_r4t0yj0h" title="收件箱" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function DelEmail(EmailKind)
    {
        var id="";
        if(document.forms[0].Seldoc.length!=undefined)
        {
            for(var i=0;i<document.forms[0].Seldoc.length;i++)
            {
                if(document.forms[0].Seldoc[i].checked)
                {
                    if(id!="")
                    {
                        id=id+",";
                    }
                    id=id+document.forms[0].Seldoc[i].value;
                }
            }
        }
        else
        {
            if(document.forms[0].Seldoc.checked)
            {
                id=document.forms[0].Seldoc.value;
            }
         }
         
         if(id=="")
         {
            alert("错误：请选择要删除的邮件!");
         }
         else
         {
            if(confirm("警告：您确定要删除选定的邮件吗？")==false)
            {
                return ;
            }
            top.location.href="DelEmail.aspx?kind="+EmailKind+"&id="+id;
         }
    }

    </script>

    <table width="100%">
        <tr>
            <td align="center" width="95%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    SkinID="gridviewSkin" AllowSorting="True" DataKeyNames="ID" OnSorting="GridView1_Sorting"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="选">
                            <ItemTemplate>
                                <input id="Seldoc" name="Seldoc" type="checkbox" value='<%# Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发件人">
                            <ItemTemplate>
                                <%#Eval("from1") %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="主题">
                            <ItemTemplate>
                                <a class="blue2" href="<%#Application["root"] %>/Info/ReadMail.aspx?id=<%#Eval("ID") %>">
                                    <%#Eval("title") %>
                                </a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="发出时间" DataField="time0">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        
        <tr>
            <td height="5"></td>
        </tr>
        <tr id="info2" runat="server">
            <td>
                <input id="Button1" type="button" value="删除" class="but" onclick="return DelEmail(1)" />
            </td>
        </tr>
        <tr>
            <td>
                <cc1:PageNavigator ID="PageNavigator1" runat="server" OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                    PageSize="13" />
            </td>
        </tr>
    </table>
</asp:Content>
