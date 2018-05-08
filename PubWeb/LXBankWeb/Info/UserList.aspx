<%@ page language="C#" autoeventwireup="true" inherits="Info_UserList, App_Web_lh9kwmkt" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收件人列表</title>
    <base target="_self">
    </base>
</head>
<body onload="javascript:IfChecked();" style="background: #ffffff">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
        function IfChecked()
        {
            var str1=window.dialogArguments;
            if(str1!=null && str1!="")
            {
                var arr1=str1.split(",");  
                for(var j=0;j<arr1.length;j++)
                {
                    for(var i=0;i<document.form1.elements.length;i++)
                    {
                        var item1=document.form1.elements[i];                  
                        if(item1.type=="checkbox" && Trim(item1.value)==Trim(arr1[j]) )
                        {
                           item1.checked=true;
                           break;
                        }
                    }
                }
            }
        }
        
        
        function Trim(str)
        {
            return str.replace(/(^\s*)|(\s*$)/g, "");
        }

        function ReturnUser()
        {
            var user1="";
            var first=true;
            for(var i=0;i<document.form1.elements.length;i++)
            {
                var item1=document.form1.elements[i];
                if(item1.type=="checkbox")
                {
                    if(item1.checked==true)
                    {
                        if(first)
                        {
                            user1=item1.value;
                            first=false;
                        }
                        else
                        {
                            user1=user1+","+item1.value;
                        }
                    }
                }
            }
            
            //alert(user1);
            if(user1=="")
            {
                window.returnValue="";
            }
            else
            {
                window.returnValue=user1;
            }
            window.close();
        }
        
    </script>

    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <table width="94%" align="center">
                <tr>
                    <td align="left">
                        <asp:Label ID="Label0" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList0" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label2" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList2" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label3" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList3" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList4" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label5" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList5" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label6" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList6" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label7" runat="server" Text=''></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="DataList7" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input id="Checkbox2" type="checkbox" value="<%#Eval("sName")%>" />
                                <%#Eval("sName")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <input id="Button1" type="button" value="确定返回" onclick="javascirpt:ReturnUser();"
                            class="but" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
