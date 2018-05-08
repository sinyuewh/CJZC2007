using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame.DB;
using System.Data;
using JSJ.CJZC.Business;


public partial class DangAn_DangAnSearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String ajnum = Request.QueryString["ajnum"];
            String danWei = Request.QueryString["danwei"];

            if (String.IsNullOrEmpty(ajnum) == false 
                || String.IsNullOrEmpty(danWei)==false)
            {
                String sql = "select DA_AJDZFile.* from DA_AJDZFile inner join u_zc ";
                sql=sql+" on DA_AJDZFile.ajnum=u_zc.num2 where 1=1 ";
                if (String.IsNullOrEmpty(ajnum) == false)
                {
                    ajnum = ajnum.Replace("'", "");
                    sql = sql + " and ajnum='" + ajnum + "'";
                }
                if (String.IsNullOrEmpty(danWei) == false)
                {
                    danWei = danWei.Replace("'", "");
                    sql = sql + " and danwei like '%" + danWei + "%'";
                }

                //Response.Write(sql);
                CommTable com1 = new CommTable();
                DataSet ds1=com1.TableComm.SearchData(sql);
                this.Repeater3.DataSource = ds1;
                this.Repeater3.DataBind();
                com1.Close();
                
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Repeater3.ItemDataBound += new RepeaterItemEventHandler(Repeater3_ItemDataBound);
        base.OnInit(e);
    }

    void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRow dr = (e.Item.DataItem as DataRowView).Row;
        HyperLink hyer1 = e.Item.FindControl("hyper1") as HyperLink;
        HyperLink hyer2 = e.Item.FindControl("hyper2") as HyperLink;

        if (dr != null)
        {
            String ajnum = dr["ajnum"].ToString();
            bool iscanSee = DangAnBU.isCanSeeFile(ajnum);
            if (iscanSee == false)
            {
                hyer1.Visible = false;
                hyer2.Visible = true;
                hyer2.NavigateUrl = "borrow.aspx?ajnum="+ajnum;
            }
            else
            {
                hyer1.Visible = true;
                hyer2.Visible = false;
                hyer1.NavigateUrl = "~/SeeDAFile.aspx?fileName="+dr["ajtruefile"].ToString();
                hyer1.Target = "_blank";
            }
        }
    }


    
}
