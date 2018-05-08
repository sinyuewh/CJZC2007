using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.IO;

public partial class Info_ReceiveMail : System.Web.UI.Page
{
    private bool needBind = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlOrderBy order1 = new SqlOrderBy("ZX_Email.time0", SqlOrderType.DESC);
            ViewState["orderby"] = order1;
            this.BindData();

            needBind = false;
        }
    }
    //bind data
    private void BindData()
    {
        ZX_EmailBu email1 = new ZX_EmailBu();

        int totalRow = 0;
        int curpage = 1;
        if (ViewState["curpage"] != null)
        {
            curpage = (int)ViewState["curpage"];
        }
        string orderby = null;
        if (ViewState["orderby"] != null)
        {
            orderby = ((SqlOrderBy)(ViewState["orderby"])).OrderExpression;
        }

        DataSet ds1 = email1.GetUserMail(curpage, this.PageNavigator1.PageSize, orderby, out totalRow);
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();

        this.PageNavigator1.TotalRows = totalRow;
        this.PageNavigator1.CurrentPage = curpage;

        if (ds1.Tables[0].Rows.Count == 0 && curpage > 1)
        {
            ViewState["curpage"] = curpage - 1;
            this.BindData();
        }

        //隐藏删除等控件
        if (totalRow > 0)
        {
            this.info2.Visible = true;
        }
        else
        {
            this.info2.Visible = false;
        }
        
        email1.Close();
    }
   
    //del mail
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        ZX_EmailBu emal1 = new ZX_EmailBu();
        DataSet ds1 = emal1.GetUserMail(id);
        string file1 = ds1.Tables[0].Rows[0]["file1"].ToString();
        if (file1 != "" && file1 != null)
        {
            ZX_Email1BU email1 = new ZX_Email1BU();
            bool Cunzai = email1.IfCzFile(file1, "1");
            if (Cunzai == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file1));
            }
            email1.Dispose();
        }
        string file2 = ds1.Tables[0].Rows[0]["file2"].ToString();
        if (file2 != "" && file2 != null)
        {
            ZX_Email1BU email2 = new ZX_Email1BU();
            bool Cunzai2 = email2.IfCzFile(file2, "2");
            if (Cunzai2 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file2));
            }
            email2.Dispose();
        }
        string file3 = ds1.Tables[0].Rows[0]["file3"].ToString();
        if (file3 != "" && file3 != null)
        {
            ZX_Email1BU email3 = new ZX_Email1BU();
            bool Cunzai3 = email3.IfCzFile(file3, "3");
            if (Cunzai3 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file3));
            }
            email3.Dispose();
        }
        string file4 = ds1.Tables[0].Rows[0]["file4"].ToString();
        if (file4 != "" && file4 != null)
        {
            ZX_Email1BU email4 = new ZX_Email1BU();
            bool Cunzai4 = email4.IfCzFile(file4, "4");
            if (Cunzai4 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file4));
            }
            email4.Dispose();
        }
        string file5 = ds1.Tables[0].Rows[0]["file5"].ToString();
        if (file5 != "" && file5 != null)
        {
            ZX_Email1BU email5 = new ZX_Email1BU();
            bool Cunzai5 = email5.IfCzFile(file5, "5");
            if (Cunzai5 == false)
            {
                File.Delete(Server.MapPath(Application["root"] + "/Common/MailFiles/" + file5));
            }
            email5.Dispose();
        }
        emal1.DelMail(id);
        this.BindData();
        emal1.Close();
    }
    protected void PageNavigator1_onPageChangeEvent(object sender, JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData();
        needBind = false;
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (needBind)
        {
            this.BindData();
        }
        base.Render(writer);
    }
    //sort
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        SqlOrderBy neworder = new SqlOrderBy(e.SortExpression, SqlOrderType.ASC);
        if (ViewState["orderby"] != null)
        {
            SqlOrderBy oldorder = (SqlOrderBy)ViewState["orderby"];
            neworder.GetRevertOrder(oldorder);
        }
        ViewState["orderby"] = neworder;
        this.BindData();
        needBind = false;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ZX_EmailBu email1 = new ZX_EmailBu();
        if (e.Row.DataItem != null)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            if (email1.IfRead(dr["id"].ToString()))
            {
                ((Image)e.Row.FindControl("img1")).Visible = false;
            }
            else
            {
                ((Image)e.Row.FindControl("img1")).ImageUrl = "~/Common/Image/mail_open.gif";
                
            }
        }
    }
}
