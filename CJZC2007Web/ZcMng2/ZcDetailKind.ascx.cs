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
using System.Drawing;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;


public partial class ZiChan_ZcDetailKind : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string url = Request.RawUrl.ToLower();
            if (url.IndexOf("zcdetail1.aspx") > 0)
            {
                LinkButton1.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail1.aspx") > 0)
            {
                LinkButton1.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail2.aspx") > 0)
            {
                LinkButton2.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail3.aspx") > 0)
            {
               // LinkButton3.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail4.aspx") > 0)
            {
              // LinkButton4.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail5.aspx") > 0)
            {
                LinkButton5.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail6.aspx") > 0)
            {
                LinkButton6.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail7.aspx") > 0)
            {
                LinkButton7.ForeColor = Color.Red;
            }

            if (url.IndexOf("zcdetail8.aspx") > 0)
            {
                LinkButton8.ForeColor = Color.Red;
            }
            if (url.IndexOf("zcdetail9.aspx") > 0)
            {
                LinkButton9.ForeColor = Color.Red;
            }


            #region 计算资产的上一个和下一个
            //得到上一个ID和下一个ID
            if (Request["id"] != null && Request["id"].ToString().Trim() != "")
            {
                String nextid,previd;
                U_ZCBU zc1 = new U_ZCBU();
                String url1 = Request.Url.AbsoluteUri;
                

                zc1.GetNextAndPrevID(Request["id"], out nextid, out previd);
                if (previd != String.Empty)
                {
                    this.prevUrl.NavigateUrl = url1.Replace(Request["id"], previd);
                }

                if (nextid != String.Empty)
                {
                    this.nextUrl.NavigateUrl = url1.Replace(Request["id"], nextid);
                }

                //Response.Write(previd);
            }
            #endregion

            #region 计算资产的相关链接
            String czid = null;
            if (Request["id"] != null && Request["id"].ToString().Trim() != "")
            {
                czid = this.GetZcCzid(Request["id"]); 
            }
            if (String.IsNullOrEmpty(czid) == false)
            {
                this.HyperLink1.Visible = true;
                this.HyperLink1.NavigateUrl = "~/ZcMng3/EditSbb.aspx?id="+czid;
            }
            else
            {
                this.HyperLink1.Visible = false;
            }
            #endregion
        }
    }


    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("ZcDetail" + e.CommandArgument.ToString() + ".aspx?id="+Request["id"], true);
    }

    /// <summary>
    /// 根据资产ID得到最近的资产处置ID
    /// 2010年3月22日
    /// </summary>
    /// <param name="zicid"></param>
    /// <returns></returns>
    private String GetZcCzid(String zcid)
    {
        String czid = null;
        CommTable comm1 = new CommTable();
        comm1.TabName = "U_ZC2";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("ZCID", zcid));
        condition.Add(new SearchField("ZCBID is null ", "",SearchOperator.用户定义));
        condition.Add(new SearchField(" exists (select * from u_zcsp where u_zcsp.czid=u_zc2.id) ", "", SearchOperator.用户定义));

        DataSet ds1 = comm1.SearchData("id", condition, "id desc");
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            czid = ds1.Tables[0].Rows[0]["id"].ToString();
        }
        comm1.Close();
        return czid;
    }
}
