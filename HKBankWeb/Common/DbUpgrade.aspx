<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Microsoft.SqlServer.Management.Smo" %>
<%@ Import Namespace="Microsoft.SqlServer.Management.Common" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script runat="server">
        private void ExecuteSqlFile(String SqlFile)
        {
            string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnstring"].ConnectionString;
            FileInfo file = new FileInfo(Server.MapPath(SqlFile));
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Microsoft.SqlServer.Management.Common.ServerConnection serverconnection = new ServerConnection(conn);
            Server server = new Server(serverconnection);
            server.ConnectionContext.ExecuteNonQuery(script);
            conn.Close();
            conn.Dispose();
        }
        
        
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JSJ.SysFrame.DB.CommTable comm1 = new JSJ.SysFrame.DB.CommTable();
                
                //增加lockflag 字段(2010年 12月14日调整 ）
                String sql1 = "if Not EXISTS (select *  from syscolumns where name='lockflag' and ";
                sql1 = sql1 + " id=(select id from sysobjects where name='U_UserName')) ";
                sql1 = sql1 + " begin alter table U_UserName add lockflag bit end";
                comm1.TableComm.ExecuteNoQuery(sql1);


                //增加协管人员 字段(2010年 12月15日调整 ）
                sql1 = "if Not EXISTS (select *  from syscolumns where name='zeren1' and ";
                sql1 = sql1 + " id=(select id from sysobjects where name='U_ZC')) ";
                sql1 = sql1 + " begin alter table U_ZC add zeren1 nvarchar(50) end";
                comm1.TableComm.ExecuteNoQuery(sql1);
                
                //关闭数据库资源
                comm1.Close();
                
                //执行SQL文件
                this.ExecuteSqlFile("czzc.sql");
            }
            base.OnLoad(e);
        }
    </script>
    
    <title>数据库升级</title>
</head>
<body style="background-color:White">
    <form id="form1" runat="server">
    <div style="text-align:center">
        <br /><h2>数据升级结束，请关闭页面！</h2>
    </div>
    </form>
</body>
</html>
