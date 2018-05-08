using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebFrame.Data;
using WebFrame.Util;
using WebFrame.Comm;
using WebFrame;
using System.Configuration;

public partial class ZcMng2_OldHkInfo : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.repeater1.ItemCommand += new RepeaterCommandEventHandler(repeater1_ItemCommand);
        base.OnInit(e);
    }

    void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String lsh = e.CommandArgument.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindList();
        }
    }

    protected override void OnUnload(EventArgs e)
    {
        WebFrame.Data.JConnect.CloseConnect();
        base.OnUnload(e);
    }

    private void BindList()
    {
        String num2 = Request.QueryString["num2"];
        if (String.IsNullOrEmpty(num2) == false)
        {
            String connectString = ConfigurationManager.ConnectionStrings["DefaultConnstring"].ConnectionString;
            JConnect conn1 = JConnect.GetConnectForWinForm(connectString  ,WebDbType.SqlServer);
            JTable tab1 = new JTable(conn1,"my1");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("盒号", num2));
            DataSet ds1 = tab1.SearchData(condition, -1, "*");
            this.repeater1.DataSource = ds1;
            this.repeater1.DataBind();

            //设置默认的第一条信息
            if (ds1.Tables[0].Rows.Count > 0)
            {
                this.五级分类.Text = ds1.Tables[0].Rows[0]["五级分类"].ToString();
            }
            tab1.Close(true);
        }
    }

    /// <summary>
    /// 设置不同的流水号资料
    /// </summary>
    /// <param name="danganhao"></param>
    private void SetPageInfo(string danganhao)
    {
    }
}
