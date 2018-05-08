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


public partial class JueCeZhiChi_StatByGSZC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            CommTable comm1 = new CommTable();
            int hs,hs1,hs2;
            double bjlx1, bjlx2,bjlx,hbxh,fee,huilv;

            //统计资产的情况
            huilv=JueCheZhiChi.ZcSum1(comm1,out hs,out bjlx1,out bjlx2,
                out bjlx,out hbxh,out fee);
            this.hs.Text = hs + "";
            this.bxh1.Text = String.Format("{0:N2}", bjlx1);
            this.bxh2.Text = String.Format("{0:N2}", bjlx2);
            this.Label1.Text = String.Format("{0:N2}", bjlx);
            this.Label2.Text = huilv+"";
            this.hbxh1.Text = String.Format("{0:N2}", hbxh);
            this.fyhj.Text = String.Format("{0:N2}", fee);


            //统计资产包的情况
            huilv = JueCheZhiChi.ZcBaoSum(comm1, out hs1, out hs2, 
                out bjlx1, out bjlx2, out bjlx, out hbxh, out fee);
            this.bhs.Text = hs1 + "";
            this.Label3.Text = hs2 + "";
            this.bbxh1.Text = String.Format("{0:N2}", bjlx1);
            this.bbxh2.Text = String.Format("{0:N2}", bjlx2);
            this.Label4.Text = String.Format("{0:N2}", bjlx);
            this.Label5.Text = huilv + "";
            this.bhbxh1.Text = String.Format("{0:N2}", hbxh);
            this.bfyhj.Text = String.Format("{0:N2}", fee);
            comm1.Close();

            //统计总的情况
            double temp1=double.Parse(this.hbxh1.Text)+double.Parse(this.bhbxh1.Text);
            this.zhbxh1.Text = String.Format("{0:N2}", temp1);

            temp1 = double.Parse(this.fyhj.Text) + double.Parse(this.bfyhj.Text);
            this.zfyhj.Text = String.Format("{0:N2}", temp1);
        }
    }


    protected void hs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/JueCeZhiChi/ST_ZC_List.aspx?status=&depart=", true);
    }



    protected void bhs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/JueCeZhiChi/ST_ZCBao_List.aspx?status=&depart=", true);
    }

    #region 私有函数

    /// <summary>
    /// 统计户数
    /// </summary>
    /// <param name="comm1"></param>
    private void SumHuShi(CommTable comm1)
    {
        string sql1 = @"select count(*) from U_ZC 
                    where not exists 
                    ( select * from U_ZCBAOInfo where zcid=U_Zc.id) ";

        string sql2 = @"select count(*) from U_ZC 
                    where exists 
                    ( select * from U_ZCBAOInfo where zcid=U_Zc.id) ";
        
        DataSet ds1 = comm1.TableComm.SearchData(sql1);
        this.hs.Text = ds1.Tables[0].Rows[0][0].ToString();

        ds1 = comm1.TableComm.SearchData(sql2);
        this.bhs.Text = ds1.Tables[0].Rows[0][0].ToString();
        ds1.Dispose();
    }


    /// <summary>
    /// 计算本息合计
    /// </summary>
    /// <param name="comm1"></param>
    private void SumBxHeji(CommTable comm1)
    {
        //计算本息合计（分人民币和美元）
        string sql3 = @"select sum(bj)+sum(lx1)+sum(lx2)+sum(lx3) bxh1 from U_ZC 
                    where not exists 
                    ( select * from U_ZCBAOInfo where zcid=U_Zc.id) and huobi='人民币' ";
        DataSet ds1 = comm1.TableComm.SearchData(sql3);
        this.bxh1.Text = String.Format("{0:N2}", ds1.Tables[0].Rows[0][0]) + "（人民币）";

        string sql4 = @"select sum(bj)+sum(lx1)+sum(lx2)+sum(lx3) bxh1 from U_ZC 
                    where not exists 
                    ( select * from U_ZCBAOInfo where zcid=U_Zc.id) and huobi='美元' ";
        ds1 = comm1.TableComm.SearchData(sql4);
        this.bxh2.Text = String.Format("{0:N2}", ds1.Tables[0].Rows[0][0]) + "（美元）";
    }
    #endregion

    #region codeBack
    private void BindData()
    {

        /*
        U_ZCBU zc1 = new U_ZCBU();
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("", "isnull(pbj,0)+isnull(plx,0)>0", SearchOperator.用户定义));
        DataSet ds1 = zc1.GetDetailByID(list1, "*,isnull(pbj,0)+isnull(plx,0) as hbxh,isnull(bj,0)+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) as bxh,isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0)+isnull(fee13,0)+isnull(fee14,0)+isnull(fee15,0)+isnull(fee16,0)+isnull(fee17,0)+isnull(fee18,0)+isnull(fee19,0)+isnull(fee20,0) as fyhj");
        zc1.Close();
        

        this.hs.Text = ds1.Tables[0].Rows.Count.ToString();
        double bxh1 = 0;
        double bxh2 = 0;
        double hbxh1 = 0;
        double hbxh2 = 0;
        double fyhj = 0;
        string id = "";
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            if (ds1.Tables[0].Rows[i]["huobi"].ToString() == "人民币")
            {
                bxh1 = bxh1 + double.Parse(ds1.Tables[0].Rows[i]["bxh"].ToString());
                hbxh1 = hbxh1 + double.Parse(ds1.Tables[0].Rows[i]["hbxh"].ToString());
            }
            if (ds1.Tables[0].Rows[i]["huobi"].ToString() == "美元")
            {
                bxh2 = bxh2 + double.Parse(ds1.Tables[0].Rows[i]["bxh"].ToString());
                hbxh2 = hbxh2 + double.Parse(ds1.Tables[0].Rows[i]["hbxh"].ToString());
            }
            fyhj = fyhj + double.Parse(ds1.Tables[0].Rows[i]["fyhj"].ToString());
            if (i == 0)
            {
                id = ds1.Tables[0].Rows[i]["id"].ToString();
            }
            else
            {
                id = id + "," + ds1.Tables[0].Rows[i]["id"].ToString();
            }
        }
        this.bxh1.Text = Comm.GetNumberFormat(bxh1.ToString()) + "元";
        this.bxh2.Text = Comm.GetNumberFormat(bxh2.ToString()) + "美元";
        this.hbxh1.Text = Comm.GetNumberFormat(hbxh1.ToString()) + "元";
        this.hbxh2.Text = Comm.GetNumberFormat(hbxh2.ToString()) + "美元";
        this.fyhj.Text = Comm.GetNumberFormat(fyhj.ToString()) + "元";
        ViewState["id"] = id;

        U_ZCBAOBU zcb1 = new U_ZCBAOBU();
        DataSet ds2 = zcb1.GetDetail(null,"*,isnull(bljsk,0) as bhbxh,isnull(bljzc,0) as bfyhj");

        this.bhs.Text = ds2.Tables[0].Rows.Count.ToString();
        double bbxh1 = 0;
        double bbxh2 = 0;
        double bhbxh = 0;
        double bfyhj = 0;
        string bid = "";

        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            Hashtable ht = zcb1.GetZcBbjANDlx1(ds2.Tables[0].Rows[i]["id"].ToString());
            bbxh1 = bbxh1 + double.Parse(ht["bbxh1"].ToString());
            bbxh2 = bbxh2 + double.Parse(ht["bbxh2"].ToString());

            bhbxh = bhbxh + double.Parse(ds2.Tables[0].Rows[i]["bhbxh"].ToString());
            bfyhj = bfyhj + double.Parse(ds2.Tables[0].Rows[i]["bfyhj"].ToString());
            if (i == 0)
            {
                bid = ds2.Tables[0].Rows[i]["id"].ToString();
            }
            else
            {
                bid = bid + "," + ds2.Tables[0].Rows[i]["id"].ToString();
            }
        }

        this.bbxh1.Text = Comm.GetNumberFormat(bbxh1.ToString()) + "元";
        this.bbxh2.Text = Comm.GetNumberFormat(bbxh2.ToString()) + "美元";
        this.bhbxh1.Text = Comm.GetNumberFormat(bhbxh.ToString()) + "元";
        this.bhbxh2.Text = 0 + "美元";
        this.bfyhj.Text = Comm.GetNumberFormat(bfyhj.ToString()) + "元";
        ViewState["bid"] = bid;

        double zbxh1 = bxh1 + bbxh1;
        double zbxh2 = bxh2 + bbxh2;
        double zhbxh1 = hbxh1 + bhbxh;
        double zhbxh2 = hbxh2;
        double zfyhj = fyhj + bfyhj;

        this.zbxh1.Text = Comm.GetNumberFormat(zbxh1.ToString()) + "元";
        this.zbxh2.Text = Comm.GetNumberFormat(zbxh2.ToString()) + "美元";
        this.zhbxh1.Text = Comm.GetNumberFormat(zhbxh1.ToString()) + "元";
        this.zhbxh2.Text = Comm.GetNumberFormat(zhbxh2.ToString()) + "美元";
        this.zfyhj.Text = Comm.GetNumberFormat(zfyhj.ToString()) + "元";
         */

    }

    #endregion
}
