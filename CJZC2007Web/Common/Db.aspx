<%@ Page Language="C#" AutoEventWireup="true" StylesheetTheme="" %>
<script runat ="server">
    protected override void OnInit(EventArgs e)
    {
        this.but1.Click += new EventHandler(but1_Click);
        base.OnInit(e);
    }

    void but1_Click(object sender, EventArgs e)
    {
        String sql1 = this.txt1.Text;
        if (String.IsNullOrEmpty(sql1) == false)
        {
            String[] sqlArr = sql1.Split(';');
            bool succ = false;
            foreach (String m in sqlArr)
            {
                succ = ExecuteSql(m);
                if (succ == false)
                {
                    
                    this.errorLable.Text = "错误的SQL："+m;
                    break;
                }
            }

            if (succ)
            {
                this.errorLable.Text = "操作成功！";
            }
        }
    }


    private bool ExecuteSql(String sql)
    {
        bool succ = false;
        WebFrame.Data.JConnect conn = null;
        try
        {
            String conn0 = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnstring"].ConnectionString;
            String conn1 = System.Configuration.ConfigurationManager.ConnectionStrings["HKConnstring"].ConnectionString;

            if (this.dbkind.SelectedValue == "0")
            {
                conn = WebFrame.Data.JConnect.GetConnect(conn0, WebFrame.WebDbType.SqlServer);
            }
            else
            {
                conn = WebFrame.Data.JConnect.GetConnect(conn1, WebFrame.WebDbType.SqlServer);
            }

            WebFrame.Data.JCommand comm = new WebFrame.Data.JCommand(conn);
            if (String.IsNullOrEmpty(sql.Trim()) == false)
            {
                comm.CommandText = sql.Trim();
                comm.ExecuteNoQuery();
                comm.Close();
            }
            conn.Dispose();
            succ = true;
        }
        finally
        {
            if (conn != null) { conn.Dispose(); }
        }
        return succ;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请选择要升级的数据库：
        <asp:DropDownList ID="dbkind" runat ="server">
            <asp:ListItem Text ="政策库" Value ="0"></asp:ListItem>
            <asp:ListItem Text ="汉口银行库" Value ="1"></asp:ListItem>
        </asp:DropDownList>
        <br />
        升级的SQL语句：
        <asp:TextBox ID="txt1" runat ="server" TextMode="MultiLine" Height ="300" Width ="800">
        </asp:TextBox>
        <br />
        <asp:Button ID="but1" runat ="server" Text ="确定升级" />
        <br />
        <asp:Label id="errorLable" runat ="server"></asp:Label>
    </div>
    </form>
</body>
</html>
