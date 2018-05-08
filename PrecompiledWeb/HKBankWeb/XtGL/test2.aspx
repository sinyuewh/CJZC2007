<%@ page language="C#" autoeventwireup="true" inherits="XtGL_test2, App_Web_rhavpchx" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllDepart"
            TypeName="JSJ.CJZC.Business.U_DepartBU" UpdateMethod="UpdataData">
            <UpdateParameters>
                <asp:Parameter Name="id" Type="String" />
                <asp:Parameter Name="ht" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            DataSourceID="ObjectDataSource1" OnRowUpdating="GridView1_RowUpdating" Width="95%">
            <Columns>
                <asp:BoundField DataField="num" HeaderText="编号" />
                <asp:BoundField DataField="depart" HeaderText="名称" />
                <asp:BoundField DataField="remark" FooterText="备注" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
