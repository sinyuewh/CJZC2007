using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;


public partial class Info_InfoBrowse : System.Web.UI.Page
{

    private bool needBind = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlOrderBy order1 = new SqlOrderBy("ZX_Info.time0", SqlOrderType.DESC);
            ViewState["orderby"] = order1;
            this.BindData();
            
            //Util.Print(this.DropDownList1.SelectedValue);
            //Util.Print(DateTime.Now.ToString());
            needBind = false;

            
        }   
    }
  
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    this.BindData(this.DropDownList1.SelectedValue.Trim().ToString());
    //}
    //查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindData();
        //if (this.GridView1.Rows.Count == 0)
        //{
        //    this.PageNavigator1.Visible = true;
        //}
        needBind = false;
       
    }
    //绑定数据
    private void BindData()
    {
       
        ZX_InfoBU info1 = new ZX_InfoBU();
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
        DataSet ds1 = new DataSet();
        if (this.DropDownList1.SelectedValue == "全部")
        {
            ds1 = info1.GetInfo("", this.titleTxt.Text, curpage, this.PageNavigator1.PageSize, orderby, out totalRow);
        }
        else
        {
            ds1 = info1.GetInfo(this.DropDownList1.SelectedValue.Trim().ToString(), this.titleTxt.Text, curpage, this.PageNavigator1.PageSize, orderby, out totalRow);
        }
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();

        this.PageNavigator1.TotalRows = totalRow;
        this.PageNavigator1.CurrentPage = curpage;

        if (ds1.Tables[0].Rows.Count == 0 && curpage > 1)
        {
            ViewState["curpage"] = curpage - 1;
            this.BindData();
        }

        if (totalRow == 0)
        {
            this.PageNavigator1.Visible = false;
        }

        info1.Close();
    }
    protected override void Render(HtmlTextWriter writer)
    {
        if (needBind)
        {
            this.BindData();
        }
        base.Render(writer);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ////被注释的这段代码是用来判断用户是否有未读信息
        //ZX_InfoBU info1 = new ZX_InfoBU();
       
        
        //if (e.Row.DataItem != null)
        //{
            
        //    DataRow dr = ((DataRowView)e.Row.DataItem).Row;
        //    if (info1.IfRead(dr["ID"].ToString()))
        //    {
        //        ((Image)e.Row.FindControl("noRead")).Visible = false;
        //    }
        //    else
        //    {
        //        ((Image)e.Row.FindControl("noRead")).ImageUrl = "~/Common/Image/new_product_1_03.gif";
                
        //    }
        //}
        if (e.Row.DataItem != null)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            DateTime dt = (DateTime)dr["time0"];
            //先格式化以下字符串，在判断时间是否为今天
            string dt1 = String.Format("CurrentTime={0:yyyy-MM-dd}", dt);
            string dt2 = String.Format("CurrentTime={0:yyyy-MM-dd}", DateTime.Now);
            if (dt1.CompareTo(dt2)==0)
            {
                ((Image)e.Row.FindControl("noRead")).ImageUrl = "~/Common/Image/new.gif";
            }
            else
            {
                ((Image)e.Row.FindControl("noRead")).Visible = false;
            }
        }
    }
    //翻页处理
    protected void PageNavigator1_onPageChangeEvent(object sender, JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData();
        needBind = false;
    }
    //排序
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
}
