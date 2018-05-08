<%@ Page Language="C#" StylesheetTheme="" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            System.Data.DataTable dt = new DataTable();
            dt.Columns.Add("Sname");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Age");
            for (int i = 1; i < 3; i++)
            {
                DataRow dr1 = dt.NewRow();
                dr1["Sname"] = "Sname" + i;
                dr1["Sex"] = "Sex" + i;
                dr1["Age"] = "Age" + i;

                dt.Rows.Add(dr1);
            }

            this.repeater1.DataSource = dt;
            this.repeater1.DataBind();
        }
        base.OnLoad(e);
    }
</script>

<html>
<head runat="server">
    <title>无标题页</title>

    <script language="javascript" type="text/javascript">
       function getTestData()
       {
           /*
           var t1=tab1;          
           for(var i=0;i<t1.rows.length;i++)
           {
                for(var j=0;j<t1.rows[i].cells.length;j++)
                {
                    var value1=t1.rows[i].cells[j].innerText;
                    alert(value1.trim());
                }
           }*/
           
           window.open("MyTest2012.aspx");
       }
       
       String.prototype.trim = function()
       {
            var reExtraSpace = /^\s*(.*?)\s+$/;
            return this.replace(reExtraSpace,"$1");
       }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <input id="Button1" type="button" value="测试数据" onclick="javascript:getTestData();" />
    <br />
    <div>
        <table style="width: 90%" border="1" id="tab1">
            <tr>
                <td>
                    姓名
                </td>
                <td>
                    性别
                </td>
                <td>
                    年龄
                </td>
            </tr>
            <asp:Repeater ID="repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Sname") %>
                        </td>
                        <td>
                            <%#Eval("Sex") %>
                        </td>
                        <td>
                            <%#Eval("Age") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
