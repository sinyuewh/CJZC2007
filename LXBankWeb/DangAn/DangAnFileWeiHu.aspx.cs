using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame.DB;
using System.Data;

public partial class DangAn_Default : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Repeater3.ItemCommand += new RepeaterCommandEventHandler(Repeater3_ItemCommand);
        base.OnInit(e);
    }

    void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String id = e.CommandArgument.ToString();
        if (String.IsNullOrEmpty(id) == false)
        {
            CommTable com1 = new CommTable("DA_AJDZFile");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id,JSJ.SysFrame.SearchFieldType.数值型));
            DataSet ds1 = com1.SearchData("*", condition);
            if(ds1!=null && ds1.Tables[0].Rows.Count>0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                String fileName = dr1["ajTrueFile"].ToString();
                if (String.IsNullOrEmpty(fileName) == false)
                {
                    fileName = Server.MapPath("../Common/AttachFiles/" + fileName);
                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Delete(fileName);
                    }
                }
                dr1.Delete();
                com1.Update(ds1);
            }
            com1.Close();
            this.BindData();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        //设置档案文件
        //this.Repeater2.Visible = false;
        String ajnum = Request.QueryString["num2"];

        if (String.IsNullOrEmpty(ajnum) == false)
        {
            CommTable com1 = new CommTable("DA_AJDZFile");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("ajnum", ajnum));
            DataSet ds1 = com1.SearchData("*", condition);
            this.Repeater3.DataSource = ds1;
            this.Repeater3.DataBind();
            com1.Close();
        }
    }
}
