<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_WriteMail, App_Web_2t7cinkt" title="撰写新邮件" validaterequest="false" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    
    //弹出窗口
    function WinOpen()
    {
        str1=document.forms[0].<%#this.to1.ClientID %>.value;
        var url="UserList.aspx";
        
        str1=window.showModalDialog(url,str1,"dialogLeft:100pt;dialogTop:100pt;dialogWidth:540pt;dialogHeight:440pt;status:no");
        if(str1!=undefined)
        {
            document.forms[0].<%#this.to1.ClientID %>.value=str1;
        }
    }
    
    
    //快速选择所有的人
    function chkSelAllPersonClick(chkAll1)
    {
        var chk3=chkAll1.checked;
        for(var i=0;i<document.forms[0].elements.length;i++)
        {
            var item=document.forms[0].elements[i];
            if(item.name!=chkAll1.name && item.type=="checkbox")
            {
               item.checked=chk3;
            }
        }
        
        getSelectedPerson()
    }
    
    
    //选择或清除某个部门的人
    function AddDepartPerson(chkDepart1)
    {
        var chk2=chkDepart1.checked;
        var name1=chkDepart1.value;
        for(var i=0;i<document.forms[0].elements.length;i++)
        {
           var item1=document.forms[0].elements[i]; 
           if(item1.name.indexOf("chkPerson"+name1)>=0 && item1.type=="checkbox")
           {
                item1.checked=chk2;
           }
        }
        getSelectedPerson();
    }
  
    
    //得到选择的所有人
    function getSelectedPerson()
    {
        var temp="";
        for(var i=0;i<document.forms[0].elements.length;i++)
        {
            var item=document.forms[0].elements[i];
            if(item.name.indexOf("chkPerson")>=0 && item.type=="checkbox" && item.checked)
            {
                if(temp=="")
                {
                    temp=item.value;
                }
                else
                {
                    temp=temp+","+item.value;
                }
            }
        }
        document.forms[0].<%#this.to1.ClientID %>.value=temp;
    }
    </script>

    <table width="95%" align="center" border="0" cellspacing="1" cellpadding="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" />
            <col bgcolor="white" align="center" width="30%" />
        </colgroup>
        <tr height="28">
            <td colspan="3" align="center" bgcolor="#5d7b9d">
                <strong><font color="ffffff">撰 写 新 邮 件（请从右边的多选框中选择）</font></strong>
            </td>
        </tr>
        <tr height="28">
            <td width="5%">
                收件人：
            </td>
            <td>
                <asp:TextBox ID="to1" runat="server" Width="360px" Height="66px" TextMode="MultiLine"></asp:TextBox>
                <span style="display: none;">&nbsp;<a class="blue2" href="javaScript:WinOpen();">添 加>></a></span>
            </td>
            <td rowspan="9" valign="top" align="center">
                <div id="SelectUsers" style="overflow: auto; height: 650px; margin-top: 2pt; margin-bottom: 2pt;
                    vertical-align: top;">
                    <table width="90%" align="center">
                        <!--绑定部门和人员-->
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_DataBound">
                            <HeaderTemplate>
                                <tr>
                                    <td colspan="2" align="Left">
                                        <b>选择所有人</b>&nbsp;
                                        <input id="chkSelAllPerson" name="chkSelAllPerson" type="checkbox" onclick="javaScript:chkSelAllPersonClick(this);" />
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:Label ID="labDepart" runat="server" Text='<%#Eval("depart")%>' Font-Bold="true"></asp:Label>
                                        <input id="chkDepart" type="checkbox" value='<%#Eval("depart")%>' onclick="javaScript:AddDepartPerson(this);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table width="95%" align="right">
                                            <tr>
                                                <td>
                                                    <asp:DataList ID="DataListForPerson" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                                        Width="99%">
                                                        <ItemTemplate>
                                                            <input id='chkPerson<%#Eval("depart")%>' name='chkPerson<%#Eval("depart")%>' type="checkbox"
                                                                value='<%#Eval("sname")%>' onclick='javaScript:getSelectedPerson();' />
                                                            <%#Eval("sname")%>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <tr>
                                    <td align="left">
                                        <hr width="98%" size="2" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                                    </td>
                                </tr>
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </td>
        </tr>
        <tr height="28">
            <td width="5%">
                标题：
            </td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr height="28"  runat="server" id="transRow" visible="false">
            <td>
                转发附件：
            </td>
            <td>
                <div style="line-height: 150%; margin-left: 3pt">
                    <asp:Repeater ID="tranReapeater" runat="server">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkfile" runat="server" Checked="true" /> 
                            <asp:Label id ="labTransFile" runat="server" visible="false" Text='<%#Eval("FileName")%>'></asp:Label>
                            <a target="_blank"  href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("FileName")%>'><%#Eval("FileName1")%></a>
                            <br />
                        </ItemTemplate>
                        <FooterTemplate>
                            提示：转发的附件＋上传的附件 总数请勿超过5个！
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
        <tr height="28">
            <td>
                附件1：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件2：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件3：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件4：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr height="28">
            <td>
                附件5：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload5" runat="server" CssClass="text" Width="360px" />
            </td>
        </tr>
        <tr bgcolor="#ffffff">
            <td align="center" colspan="2">
                <FTB:FreeTextBox ID="remark" runat="server" ButtonPath="../common/image/ftb/officeXP/"
                    ToolbarType="OfficeXP" Width="99%" Height="250">
                </FTB:FreeTextBox>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="btn1" runat="server" Text="发送邮件" OnClick="btn1_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="取消" OnClick="btn2_Click" CausesValidation="false" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="to1"
            Display="None" ErrorMessage="错误：收件人不能为空！"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
            ErrorMessage="错误：邮件标题不能为空！" ControlToValidate="title"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </div>
</asp:Content>
