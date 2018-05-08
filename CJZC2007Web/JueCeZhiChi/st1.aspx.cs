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
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using JSJ.SysFrame.DB;
using System.Text;

public partial class JueCeZhiChi_st1 : System.Web.UI.Page
{
    public string curDepart = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items["seldepart"] != null)
            {
                curDepart = Server.UrlEncode(Context.Items["seldepart"].ToString());
                this.Title = "【"+Server.UrlDecode(curDepart) +"】"+ this.Title.Replace("公司","");
            }
            
            CommTable comm1 = new CommTable();

            this.GridView1.DataSource = JueCheZhiChi.ZcTj(comm1, Server.UrlDecode(curDepart));
            this.GridView3.DataSource = JueCheZhiChi.ZcBaoTj(comm1, Server.UrlDecode(curDepart));
            comm1.Close();
        }
    }

    /*
    private void BindData()
    {
        CommTable comm1 = new CommTable();
        string sql = @"select status,isnull(statusText,'初始状态') as statusText,
            count(*) as hs,sum(bj) as bj,sum(isNull(lx1,0)+isNull(lx2,0)+isNull(lx3,0)) 
            as lx,sum(bj) + sum(isNull(lx1,0)+isNull(lx2,0)+isNull(lx3,0))
            as bxhj,isNull(sum(pbj),0) as pbj,isNull(sum(plx),0) as plx,isNull(sum(fyhj),0) 
            as fyhj from  ZCStateView1 ";
        //string sql = "select status,isnull(statusText,'初始状态') as statusText,count(*) as hs,sum(bj) as bj,sum(isNull(lx1,0)+isNull(lx2,0)+isNull(lx3,0)) as lx,isNull(sum(pbj),0) as pbj,isNull(sum(plx),0) as plx,0 as fyhj from  ZCStateView1 ";
        if (Context.Items["seldepart"] != null)
        {
            sql = sql + " where depart='" + Context.Items["seldepart"] + "' ";
        }

        sql = sql + " group by status,statusText order by status ";
        DataSet ds1 = comm1.TableComm.SearchData(sql);
        DataRow dr = ds1.Tables[0].NewRow();
        dr["statusText"] = "合计";
        dr["hs"] = 0;
        dr["bj"] = 0;
        dr["lx"] = 0;
        dr["bxhj"] = 0;
        dr["pbj"] = 0;
        dr["fyhj"] = 0;
        dr["status"] = "-1";
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            if(ds1.Tables[0].Rows[i]["hs"].ToString() !=""&&ds1.Tables[0].Rows[i]["hs"] != null)
            {
                dr["hs"] = int.Parse(dr["hs"].ToString()) + int.Parse(ds1.Tables[0].Rows[i]["hs"].ToString());
            }
            if (ds1.Tables[0].Rows[i]["bj"].ToString() != "" && ds1.Tables[0].Rows[i]["bj"] != null)
            {
                dr["bj"] = double.Parse(dr["bj"].ToString()) + double.Parse(ds1.Tables[0].Rows[i]["bj"].ToString());
            }
            if (ds1.Tables[0].Rows[i]["lx"].ToString() != "" && ds1.Tables[0].Rows[i]["lx"] != null)
            {
                dr["lx"] = double.Parse(dr["lx"].ToString()) + double.Parse(ds1.Tables[0].Rows[i]["lx"].ToString());
            }
            if (ds1.Tables[0].Rows[i]["bxhj"].ToString() != "" && ds1.Tables[0].Rows[i]["bxhj"] != null)
            {
                dr["bxhj"] = double.Parse(dr["bxhj"].ToString()) + double.Parse(ds1.Tables[0].Rows[i]["bxhj"].ToString());
            }
            if (ds1.Tables[0].Rows[i]["pbj"].ToString() != "" && ds1.Tables[0].Rows[i]["pbj"] != null)
            {
                dr["pbj"] = double.Parse(dr["pbj"].ToString()) + double.Parse(ds1.Tables[0].Rows[i]["pbj"].ToString());
            }
            if (ds1.Tables[0].Rows[i]["fyhj"].ToString() != "" && ds1.Tables[0].Rows[i]["fyhj"] != null)
            {
                dr["fyhj"] = double.Parse(dr["fyhj"].ToString()) + double.Parse(ds1.Tables[0].Rows[i]["fyhj"].ToString());
            }
        }

        ds1.Tables[0].Rows.Add(dr);

        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        ds1.Dispose();

        string sql1 = "select bstatus,isnull(statusText,'初始状态') as statusText,count(*) as hs,isNull(sum(bljsk),0) as pbj,isNull(sum(bljzc),0) as fyhj from  ZCBStateView ";
        if (Context.Items["seldepart"] != null)
        {
            sql1 = sql1 + " where depart='" + Context.Items["seldepart"] + "' ";
        }

        sql1 = sql1 + " group by bstatus,statusText order by bstatus ";
        DataSet ds2 = comm1.TableComm.SearchData(sql1);
        ds2.Tables[0].Columns.Add("bj");
        ds2.Tables[0].Columns.Add("lx");
        ds2.Tables[0].Columns.Add("bxhj");

        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        List<SearchField> list1 = new List<SearchField>();
        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            double bj = 0.00;
            double lx = 0.00;
            list1.Clear();
            list1.Add(new SearchField("bstatus",ds2.Tables[0].Rows[i]["bstatus"].ToString(),SearchFieldType.字符型));
            DataSet ds3 = zcb1.GetDetail(list1,"id");
            for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
            {
                Hashtable ht = zcb1.GetZcBbjANDlx(ds3.Tables[0].Rows[j][0].ToString());
                bj = bj + double.Parse(ht["bbjhj"].ToString());
                lx = lx + double.Parse(ht["blxhj"].ToString());
            }

            ds2.Tables[0].Rows[i]["bj"] = Comm.GetNumberFormat(bj);
            ds2.Tables[0].Rows[i]["lx"] = Comm.GetNumberFormat(lx);
            ds2.Tables[0].Rows[i]["bxhj"] = Comm.GetNumberFormat(bj+lx);
        }

        DataRow dr1 = ds2.Tables[0].NewRow();
        dr1["statusText"] = "合计";
        dr1["hs"] = 0;
        dr1["bj"] = 0;
        dr1["lx"] = 0;
        dr1["bxhj"] = 0;
        dr1["pbj"] = 0;
        dr1["fyhj"] = 0;
        dr1["bstatus"] = "-1";
        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            if (ds2.Tables[0].Rows[i]["hs"].ToString() != "" && ds2.Tables[0].Rows[i]["hs"] != null)
            {
                dr1["hs"] = int.Parse(dr1["hs"].ToString()) + int.Parse(ds2.Tables[0].Rows[i]["hs"].ToString());
            }
            if (ds2.Tables[0].Rows[i]["bj"].ToString() != "" && ds2.Tables[0].Rows[i]["bj"] != null)
            {
                dr1["bj"] = double.Parse(dr1["bj"].ToString()) + double.Parse(ds2.Tables[0].Rows[i]["bj"].ToString());
            }
            if (ds2.Tables[0].Rows[i]["lx"].ToString() != "" && ds2.Tables[0].Rows[i]["lx"] != null)
            {
                dr1["lx"] = double.Parse(dr1["lx"].ToString()) + double.Parse(ds2.Tables[0].Rows[i]["lx"].ToString());
            }
            if (ds2.Tables[0].Rows[i]["bxhj"].ToString() != "" && ds2.Tables[0].Rows[i]["bxhj"] != null)
            {
                dr1["bxhj"] = double.Parse(dr1["bxhj"].ToString()) + double.Parse(ds2.Tables[0].Rows[i]["bxhj"].ToString());
            }
            if (ds2.Tables[0].Rows[i]["pbj"].ToString() != "" && ds2.Tables[0].Rows[i]["pbj"] != null)
            {
                dr1["pbj"] = double.Parse(dr1["pbj"].ToString()) + double.Parse(ds2.Tables[0].Rows[i]["pbj"].ToString());
            }
            if (ds2.Tables[0].Rows[i]["fyhj"].ToString() != "" && ds2.Tables[0].Rows[i]["fyhj"] != null)
            {
                dr1["fyhj"] = double.Parse(dr1["fyhj"].ToString()) + double.Parse(ds2.Tables[0].Rows[i]["fyhj"].ToString());
            }
        }

        dr1["bj"] = Comm.GetNumberFormat(dr1["bj"].ToString());
        dr1["lx"] = Comm.GetNumberFormat(dr1["lx"].ToString());
        dr1["bxhj"] = Comm.GetNumberFormat(dr1["bxhj"].ToString());

        ds2.Tables[0].Rows.Add(dr1);

        this.GridView2.DataSource = ds2;
        this.GridView2.DataBind();

        comm1.Close();

    }
     */
}
