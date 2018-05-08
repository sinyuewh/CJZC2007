<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_ReceiveMessage, App_Web_2t7cinkt" title="短消息" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function DelInfo()
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
         
         //进行判断
         if(id=="")
         {
            alert("错误：请选择要删除的数据!");
            return false;
         }
         else
         {
            if(confirm("警告：您确定要删除选定的数据吗？")==false)
            {
                return false;
            }
            else
            {
               return true;
            }
            
         }
    }

    //发送短消息
    function SendMessage(sname1)
    {
        var str1="<%#Application["root"] %>/Info/WriteMessage.aspx?tousers="+escape(sname1);
        window.open(str1,"","top=100,left=100,width=500,height=200");
    }
    </script>

    <table width="100%">
        <tr>
            <td align="center" width="95%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    SkinID="gridviewSkin" AllowSorting="True" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="选">
                            <ItemTemplate>
                                <input id="Seldoc" name="Seldoc" type="checkbox" value='<%# Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发件人">
                            <ItemTemplate>
                                <a href="javaScript:SendMessage('<%#Eval("fmen") %>')" style="color:Blue"><u><%#Eval("fmen") %></u></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="12%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="消息">
                            <ItemTemplate>
                                <%#Eval("remark") %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="53%" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="发出时间" DataField="time0">
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="回复">
                            <ItemTemplate>
                            <a href="javascript:SendMessage('<%#Eval("fmen")%>');">回复</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr id="info1" runat="server">
            <td height="5">
            </td>
        </tr>
        <tr id="info2" runat="server">
            <td>
                <asp:Button ID="Button2" CssClass="but" runat="server" Text="删除" OnClientClick="javaScript:return DelInfo();" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
