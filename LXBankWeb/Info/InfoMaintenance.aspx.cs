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
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;

public partial class Info_InfoMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlOrderBy order1 = new SqlOrderBy("ZX_Info.time0", SqlOrderType.DESC);
            ViewState["orderby"] = order1;
            this.BindData();
          
        }
    }
    //bind data1
    private void BindData()
    {
       
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
        ZX_InfoBU info1 = new ZX_InfoBU();
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

        if (totalRow == 0) this.PageNavigator1.Visible = false;

        info1.Close();
    }
    //
    private void BindData(ZX_InfoBU info1)
    {
        this.GridView1.DataSource = info1.GetInfo("", "");
        this.GridView1.DataBind();
    }
    //delete data
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        ZX_InfoBU info1 = new ZX_InfoBU();
        ZX_InfoReadBU info2=new ZX_InfoReadBU();
        info1.DeleteData(id);
        this.BindData(info1);
        info2.DelDataByID(id);
        info1.Close();
        info2.Close();
    }
    //edit data
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        this.BindData();
    }
    //cancel edit
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.GridView1.EditIndex = -1;
        this.BindData();
    }
    //update data

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        Hashtable ht = new Hashtable();
        string[] arr1 = new string[] { "title", "time0", "kind" };
        for (int i = 0; i < arr1.Length-1; i++)
        {
            
            ht.Add(arr1[i], Util.GetControlValue(this.GridView1.Rows[e.RowIndex].Cells[i].Controls[0]));
        }

        ht.Add(arr1[2], ((DropDownList)this.GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1")).SelectedValue);
        if (ht["title"].ToString().Trim() == "")
        {
            Util.alert(this.Page, "错误提示：标题不能为空");
        }
        else
        {
            ZX_InfoBU info1 = new ZX_InfoBU();
            bool result = info1.UpdateData(id, ht);
            info1.Close();
            if (result)
            {
                this.GridView1.EditIndex = -1;
                this.BindData(info1);
                Util.alert(this.Page, "修改成功！");
            }
            else
            {
                Util.alert(this.Page, "修改失败！");
            }

        }
    }
    

    //翻页处理
    protected void PageNavigator1_onPageChangeEvent(object sender, JSJ.SysFrame.Controls.MyPageChangeEventArgs e)
    {
        ViewState["curpage"] = e.CurrentPage;
        this.BindData();

    }
    //查询数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindData();
        
    }
}
