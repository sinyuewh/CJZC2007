using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.SysFrame.DB;
using JSJ.CJZC.Business;
using System.Text;

/// <summary>
/// JueCheZhiChi 的摘要说明
/// </summary>
public class JueCheZhiChi
{
    //统计资产
    public static DataTable ZcTj(CommTable com1, string depart)
    {
        U_ItemBU item1 = new U_ItemBU();
        double huilv = item1.getHuilv();
        item1.Close();

        double[] sum = new double[12];
        for (int i = 0; i < sum.Length; i++)
        {
            sum[i] = 0;
        }

        //有疑问（资产收钱和资产包收费问题）（不合并包资产情况）
        StringBuilder sql1 = new StringBuilder(@"select isNull(b.statustext,'初始状态') statustext,
                    count(*) hs,sum(bj) bj,sum(lx) lx,
                    sum(bj+lx) bjlx,huobi,sum(pbj) pbj,sum(fee) fee,isNull(status,'00') status
                    from (
                    select u_zc.id,depart,bj,status,huobi,
                    isnull(lx1,0)+isnull(lx2,0)+isNull(lx3,0) lx,
                    isnull(pbj,0)+isnull(plx,0) pbj,
                    isnull(fee1,0)+isnull(fee2,0)+isNull(fee3,0)+isNull(fee4,0)+isNull(fee5,0)+
                    isnull(fee6,0)+isnull(fee7,0)+isNull(fee8,0)+isNull(fee9,0)+isNull(fee10,0)+
                    isnull(fee11,0)+isnull(fee12,0)+isNull(fee13,0)+isNull(fee14,0)+isNull(fee15,0)+
                    isnull(fee16,0)+isnull(fee17,0)+isNull(fee18,0)+isNull(fee19,0)+isNull(fee20,0) fee
                    from u_zc left outer join  u_zc3 on u_zc.id=u_zc3.id  ) a
                    left outer join u_zcstatus b on a.status=b.statusValue where not exists
                    (select * from U_ZCBaoInfo where zcid=a.id ) ");

        //合并包资产的情况
        StringBuilder sql = new StringBuilder(@"select isNull(b.statustext,'初始状态') statustext,
                    count(*) hs,sum(bj) bj,sum(lx) lx,
                    sum(bj+lx) bjlx,huobi,sum(pbj) pbj,sum(fee) fee,isNull(status,'00') status
                    from (
                    select u_zc.id,depart,bj,status,huobi,
                    isnull(lx1,0)+isnull(lx2,0)+isNull(lx3,0) lx,
                    isnull(pbj,0)+isnull(plx,0) pbj,
                    isnull(fee1,0)+isnull(fee2,0)+isNull(fee3,0)+isNull(fee4,0)+isNull(fee5,0)+
                    isnull(fee6,0)+isnull(fee7,0)+isNull(fee8,0)+isNull(fee9,0)+isNull(fee10,0)+
                    isnull(fee11,0)+isnull(fee12,0)+isNull(fee13,0)+isNull(fee14,0)+isNull(fee15,0)+
                    isnull(fee16,0)+isnull(fee17,0)+isNull(fee18,0)+isNull(fee19,0)+isNull(fee20,0) fee
                    from u_zc left outer join  u_zc3 on u_zc.id=u_zc3.id  ) a
                    left outer join u_zcstatus b on a.status=b.statusValue  ");

        if (String.IsNullOrEmpty(depart) == false)
        {
            sql.Append(" where depart='" + depart + "'");
        }
        sql.Append(" group by a.status,b.statustext,huobi ");
        DataSet ds1 = com1.TableComm.SearchData(sql.ToString());

        //调整数据
        DataTable dt = new DataTable();
        dt.Columns.Add("status");                           //资产状态
        dt.Columns.Add("statusText");                       //资产

        dt.Columns.Add("hs", typeof(Int32));                //户数

        dt.Columns.Add("bj1", typeof(double));              //人民币本金合计
        dt.Columns.Add("lx1", typeof(double));              //人民币利息合计
        dt.Columns.Add("bjlx1", typeof(double));            //人民币本利合计

        dt.Columns.Add("bj2", typeof(double));              //美元本金合计
        dt.Columns.Add("lx2", typeof(double));              //美元利息合计
        dt.Columns.Add("bjlx2", typeof(double));            //人民币本利合计

        dt.Columns.Add("bj3", typeof(double));              //折合人民币本金合计
        dt.Columns.Add("lx3", typeof(double));              //折合人民币利息合计
        dt.Columns.Add("bjlx3", typeof(double));            //折合人民币利息合计

        dt.Columns.Add("pbj", typeof(double));              //归还本金
        dt.Columns.Add("fee", typeof(double));              //费用
        dt.Columns.Add("huilv", typeof(double));             //汇率
        dt.PrimaryKey = new DataColumn[] { dt.Columns["status"] };

        //统计数据
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            DataRow dr1 = ds1.Tables[0].Rows[i];
            string status1 = dr1["status"].ToString();
            DataRow newdr = dt.Rows.Find(status1);
            if (newdr == null)
            {
                newdr = dt.NewRow();
                newdr["status"] = dr1["status"];
                newdr["statustext"] = dr1["statustext"];
                newdr["huilv"] = huilv;

                newdr["bj1"] = 0;
                newdr["lx1"] = 0;
                newdr["bjlx1"] = 0;

                newdr["bj2"] = 0;
                newdr["lx2"] = 0;
                newdr["bjlx2"] = 0;

                newdr["bj3"] = 0;
                newdr["lx3"] = 0;
                newdr["bjlx3"] = 0;

                newdr["pbj"] = 0;
                newdr["fee"] = 0;
                newdr["hs"] = 0;
               
                dt.Rows.Add(newdr);
            }

            //计算本金和利息合计
            if (dr1["huobi"].ToString() == "美元")
            {
                newdr["bj2"] = double.Parse(newdr["bj2"].ToString()) + double.Parse(dr1["bj"].ToString());
                newdr["lx2"] = double.Parse(newdr["lx2"].ToString()) + double.Parse(dr1["lx"].ToString());
                newdr["bjlx2"] = double.Parse(newdr["bjlx2"].ToString()) + double.Parse(dr1["lx"].ToString()) + double.Parse(dr1["bj"].ToString());

                newdr["bj3"] = double.Parse(newdr["bj3"].ToString()) + double.Parse(dr1["bj"].ToString())*huilv;
                newdr["lx3"] = double.Parse(newdr["lx3"].ToString()) + double.Parse(dr1["lx"].ToString())*huilv;
                newdr["bjlx3"] = double.Parse(newdr["bjlx3"].ToString()) + (double.Parse(dr1["lx"].ToString()) + double.Parse(dr1["bj"].ToString()))*huilv;

                sum[1] += double.Parse(dr1["bj"].ToString())*huilv;
                sum[2] += double.Parse(dr1["lx"].ToString())*huilv;
                sum[3] += (double.Parse(dr1["bj"].ToString()) + double.Parse(dr1["lx"].ToString()))*huilv;

                sum[7] += double.Parse(dr1["bj"].ToString());
                sum[8] += double.Parse(dr1["lx"].ToString());
                sum[9] += double.Parse(dr1["bj"].ToString()) + double.Parse(dr1["lx"].ToString()); 
                
            }
            else
            {
                newdr["bj1"] = double.Parse(newdr["bj1"].ToString()) + double.Parse(dr1["bj"].ToString());
                newdr["lx1"] = double.Parse(newdr["lx1"].ToString()) + double.Parse(dr1["lx"].ToString());
                newdr["bjlx1"] = double.Parse(newdr["bjlx1"].ToString()) + double.Parse(dr1["lx"].ToString()) + double.Parse(dr1["bj"].ToString());

                newdr["bj3"] = double.Parse(newdr["bj3"].ToString()) + double.Parse(dr1["bj"].ToString()) ;
                newdr["lx3"] = double.Parse(newdr["lx3"].ToString()) + double.Parse(dr1["lx"].ToString()) ;
                newdr["bjlx3"] = double.Parse(newdr["bjlx3"].ToString()) + (double.Parse(dr1["lx"].ToString()) + double.Parse(dr1["bj"].ToString())) ;

                sum[1] += double.Parse(dr1["bj"].ToString());
                sum[2] += double.Parse(dr1["lx"].ToString());
                sum[3] += double.Parse(dr1["bj"].ToString())+double.Parse(dr1["lx"].ToString());

                sum[4] += double.Parse(dr1["bj"].ToString());
                sum[5] += double.Parse(dr1["lx"].ToString());
                sum[6] += double.Parse(dr1["bj"].ToString()) + double.Parse(dr1["lx"].ToString());            
            }

            newdr["pbj"] = double.Parse(newdr["pbj"].ToString()) + double.Parse(dr1["pbj"].ToString());
            newdr["fee"] = double.Parse(newdr["fee"].ToString()) + double.Parse(dr1["fee"].ToString());
            newdr["hs"] = double.Parse(newdr["hs"].ToString()) + double.Parse(dr1["hs"].ToString());
            
            //统计合计数据
            sum[0] += double.Parse(dr1["hs"].ToString());
            sum[10] += double.Parse(dr1["pbj"].ToString());
            sum[11] += double.Parse(dr1["fee"].ToString());
        }
        ds1.Clear();
        ds1.Dispose();

        //增加合计数据
        DataRow newdr1 = dt.NewRow();
        newdr1["status"] = "";
        newdr1["statustext"] = "<font color='#ff0000'>资产合计</font>";
        newdr1["huilv"] = huilv;

        newdr1["bj1"] = sum[4];
        newdr1["lx1"] = sum[5];
        newdr1["bjlx1"] = sum[6];

        newdr1["bj2"] = sum[7];
        newdr1["lx2"] = sum[8];
        newdr1["bjlx2"] = sum[9];

        newdr1["bj3"] = sum[1];
        newdr1["lx3"] = sum[2];
        newdr1["bjlx3"] = sum[3];

        newdr1["pbj"] = sum[10];
        newdr1["fee"] = sum[11];
        newdr1["hs"] = sum[0];

        dt.Rows.Add(newdr1);
        return dt;
    }

    //统计资产包
    public static DataTable ZcBaoTj(CommTable com1, string depart)
    {
        U_ItemBU item1 = new U_ItemBU();
        double huilv = item1.getHuilv();
        item1.Close();

        double[] sum = new double[13];
        for (int i = 0; i < sum.Length; i++)
        {
            sum[i] = 0;
        }
        StringBuilder sql = new StringBuilder(@"select * from
                ( select U_zcbao.id,depart,isnull(bstatus,'00') status,
                isNull(statustext,'初始状态') statustext,
                isnull(bljsk,0) pbj, isnull(bljzc,0) fee
                from u_zcbao left outer join U_UserName on U_zcbao.bzeren=U_UserName.sname
                left outer join u_zcstatus on U_zcbao.bstatus=u_zcstatus.statusvalue
                ) a  inner join
                ( select bid,count(*) hs
                from u_zc inner join u_zcbaoinfo on u_zc.id=u_zcbaoinfo.zcid
                group by u_zcbaoinfo.bid ) b
                on a.id=b.bid ");

        if (String.IsNullOrEmpty(depart) == false)
        {
            sql.Append(" where depart='" + depart + "'");
        }
        sql.Append(" order by status ");
        DataSet ds1 = com1.TableComm.SearchData(sql.ToString());

        //调整数据
        DataTable dt = new DataTable();
        dt.Columns.Add("status");                           //资产状态
        dt.Columns.Add("statusText");                       //资产

        dt.Columns.Add("hs", typeof(Int32));                //包内资产数
        dt.Columns.Add("hs1", typeof(Int32));                //资产包数

        dt.Columns.Add("bj1", typeof(double));              //人民币本金合计
        dt.Columns.Add("lx1", typeof(double));              //人民币利息合计
        dt.Columns.Add("bjlx1", typeof(double));            //人民币本利合计

        dt.Columns.Add("bj2", typeof(double));              //美元本金合计
        dt.Columns.Add("lx2", typeof(double));              //美元利息合计
        dt.Columns.Add("bjlx2", typeof(double));            //人民币本利合计

        dt.Columns.Add("bj3", typeof(double));              //折合人民币本金合计
        dt.Columns.Add("lx3", typeof(double));              //折合人民币利息合计
        dt.Columns.Add("bjlx3", typeof(double));            //折合人民币利息合计

        dt.Columns.Add("pbj", typeof(double));              //归还本金
        dt.Columns.Add("fee", typeof(double));              //费用
        dt.Columns.Add("huilv", typeof(double));             //汇率
        dt.PrimaryKey = new DataColumn[] { dt.Columns["status"] };

        //统计数据
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            DataRow dr1 = ds1.Tables[0].Rows[i];
            string status1 = dr1["status"].ToString();
            DataRow newdr = dt.Rows.Find(status1);
            if (newdr == null)
            {
                newdr = dt.NewRow();
                newdr["status"] = dr1["status"];
                newdr["statustext"] = dr1["statustext"];
                newdr["huilv"] = huilv;

                newdr["bj1"] = 0;
                newdr["lx1"] = 0;
                newdr["bjlx1"] = 0;

                newdr["bj2"] = 0;
                newdr["lx2"] = 0;
                newdr["bjlx2"] = 0;

                newdr["bj3"] = 0;
                newdr["lx3"] = 0;
                newdr["bjlx3"] = 0;

                newdr["pbj"] = 0;
                newdr["fee"] = 0;
                newdr["hs"] = 0;
                newdr["hs1"] = GetZcBaoCount(com1,dr1["status"].ToString()) ;
                sum[12] += double.Parse(newdr["hs1"].ToString());
                dt.Rows.Add(newdr);
            }

            //根据包的ID计算其中的本金合计和利息合计（分美元和人民币）
            Double bj1, lx1, bj2, lx2;
            int hs1;
            CalBj(com1,dr1["bid"].ToString(), out bj1, out lx1, out bj2, out lx2,out hs1);

            //设置数据
            newdr["bj1"] = double.Parse(newdr["bj1"].ToString()) + bj1;
            newdr["lx1"] = double.Parse(newdr["lx1"].ToString()) + lx1;
            newdr["bjlx1"] = double.Parse(newdr["bjlx1"].ToString()) + bj1+lx1;
            newdr["bj2"] = double.Parse(newdr["bj2"].ToString()) + bj2;
            newdr["lx2"] = double.Parse(newdr["lx2"].ToString()) + lx2;
            newdr["bjlx2"] = double.Parse(newdr["bjlx2"].ToString()) + bj2+lx2 ;
            newdr["bj3"] = double.Parse(newdr["bj3"].ToString()) + bj1+bj2*huilv;
            newdr["lx3"] = double.Parse(newdr["lx3"].ToString()) + lx1+lx2*huilv;
            newdr["bjlx3"] = double.Parse(newdr["bjlx3"].ToString()) +bj1+lx1+(bj2+lx2)*huilv;

            //计算统计数据
            sum[1] += bj1+bj2*huilv;
            sum[2] += lx1+lx2*huilv;
            sum[3] += bj1+lx1+(bj2+lx2)*huilv;

            sum[4] += bj1;
            sum[5] += lx1;
            sum[6] += bj1+lx1;

            sum[7] += bj2;
            sum[8] += lx2;
            sum[9] += bj2+lx2;

            newdr["pbj"] = double.Parse(newdr["pbj"].ToString()) + double.Parse(dr1["pbj"].ToString());
            newdr["fee"] = double.Parse(newdr["fee"].ToString()) + double.Parse(dr1["fee"].ToString());
            newdr["hs"] = double.Parse(newdr["hs"].ToString()) + double.Parse(dr1["hs"].ToString());
            //newdr["hs1"] = double.Parse(newdr["hs1"].ToString()) + 1;

            //统计合计数据
            sum[0] += double.Parse(dr1["hs"].ToString());
            sum[10] += double.Parse(dr1["pbj"].ToString());
            sum[11] += double.Parse(dr1["fee"].ToString());
            
        }
        ds1.Clear();
        ds1.Dispose();

        //增加合计数据
        DataRow newdr1 = dt.NewRow();
        newdr1["status"] = "";
        newdr1["statustext"] = "<font color='#ff0000'>包合计</font>";
        newdr1["huilv"] = huilv;

        newdr1["bj1"] = sum[4];
        newdr1["lx1"] = sum[5];
        newdr1["bjlx1"] = sum[6];

        newdr1["bj2"] = sum[7];
        newdr1["lx2"] = sum[8];
        newdr1["bjlx2"] = sum[9];

        newdr1["bj3"] = sum[1];
        newdr1["lx3"] = sum[2];
        newdr1["bjlx3"] = sum[3];

        newdr1["pbj"] = sum[10];
        newdr1["fee"] = sum[11];
        newdr1["hs"] = sum[0];
        newdr1["hs1"] = sum[12];

        dt.Rows.Add(newdr1);
        return dt;
    }


    //统计公司的总资产情况
    public static double  ZcSum1(CommTable com1,
        out int hs,out double bjlx1,out double bjlx2,
        out double bjlx,
        out double hbxh,out double fee
        )
    {
        hs = 0;             //总户数
        bjlx1 = 0;          //本金利息和（人民币）
        bjlx2 = 0;          //本金和利息（美元）
        bjlx = 0;           //折合人民币后的总和

        hbxh = 0;           //总收回本金和利息
        fee = 0;            //总费用

        double temp = 0;

        U_ItemBU item1 = new U_ItemBU();
        double huilv = item1.getHuilv();
        item1.Close();

        string sql1 = @"select count(*) as hs,sum(isnull(bj,0)+ isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0)) bjlx,
                        huobi from u_zc group by huobi";
        DataSet ds1 = com1.TableComm.SearchData(sql1);
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            hs+=int.Parse(dr["hs"].ToString());
            temp = double.Parse(dr["bjlx"].ToString());
            if (dr["huobi"].ToString() == "美元")
            {
                bjlx2 =bjlx2+temp;
            }
            else
            {
                bjlx1 =bjlx1+temp;
            }
        }
        temp = bjlx2;
        bjlx = bjlx1 + temp * huilv;

        //统计收回的本金利息
        sql1 = "select sum(isnull(pbj,0)+isnull(plx,0)) hbxh from CW_ShouKuan where checktime is not null";
        ds1.Clear();
        ds1 = com1.TableComm.SearchData(sql1);
        hbxh = double.Parse(ds1.Tables[0].Rows[0][0].ToString());

        //统计发生的费用
        sql1 = @"select sum(
                isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)
                +isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)
                +isnull(fee9,0)+isnull(fee10,0)+
                isnull(fee11,0)+isnull(fee12,0)+isnull(fee13,0)+isnull(fee14,0)
                +isnull(fee15,0)+isnull(fee16,0)+isnull(fee17,0)+isnull(fee18,0)
                +isnull(fee19,0)+isnull(fee20,0)
                 ) 
                 from CW_Pay where checktime is not null";
        ds1 = com1.TableComm.SearchData(sql1);
        fee = double.Parse(ds1.Tables[0].Rows[0][0].ToString());
        return huilv;
                
    }

   //统计资产包的情况
    public static double ZcBaoSum(CommTable com1,
        out int hs1, out int hs2,out double bjlx1, 
        out double bjlx2,out double bjlx,
        out double hbxh, out double fee
        )
    {
        hs1 = 0;             //资产包数量
        hs2 = 0;             //资产包内资产的数量
        bjlx1 = 0;          //本金利息和（人民币）
        bjlx2 = 0;          //本金和利息（美元）
        bjlx = 0;           //折合人民币后的总和

        hbxh = 0;           //总收回本金和利息
        fee = 0;            //总费用

        double temp = 0;
        U_ItemBU item1 = new U_ItemBU();
        double huilv = item1.getHuilv();
        item1.Close();

        string sql = "select * from u_zcbao";
        DataSet ds1 = com1.TableComm.SearchData(sql);
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            hs1++;
            double bj1,lx1,bj2,lx2;
            int hs21;
            string bid = dr["id"].ToString();
            CalBj(com1, bid, out bj1, out lx1,out  bj2, out lx2,out hs21);
            bjlx1 += (bj1 + lx1);
            bjlx2 += (bj2 + lx2);
            hs2 += hs21;
        }
        bjlx = bjlx1 + bjlx2 * huilv;

        //统计收回的本金利息
        sql = "select sum(isnull(pbj,0)+isnull(plx,0)) hbxh from CW_ShouKuan1 where checktime is not null";
        ds1.Clear();
        ds1 = com1.TableComm.SearchData(sql);
        hbxh = double.Parse(ds1.Tables[0].Rows[0][0].ToString());

        //统计发生的费用
        sql = @"select sum(
                isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)
                +isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)
                +isnull(fee9,0)+isnull(fee10,0)+
                isnull(fee11,0)+isnull(fee12,0)+isnull(fee13,0)+isnull(fee14,0)
                +isnull(fee15,0)+isnull(fee16,0)+isnull(fee17,0)+isnull(fee18,0)
                +isnull(fee19,0)+isnull(fee20,0)
                 ) 
                 from CW_Pay1 where checktime is not null";
        ds1 = com1.TableComm.SearchData(sql);
        fee = double.Parse(ds1.Tables[0].Rows[0][0].ToString());
        return huilv;

    }

    #region 私有方法
    private static void CalBj(CommTable com1,string bid, out double bj1, 
        out double lx1, out double bj2, out double lx2,out int hs)
    {
        bj1 = 0;    //人民币本金
        lx1 = 0;    //人民币利息
        bj2 = 0;    //美元本金
        lx2 = 0;    //美元利息
        hs = 0;     //资产包内资产的数量

        string sql = @"select huobi,count(*) as hs, sum(bj) bj,
                        sum(isnull(lx1,0))+sum(isnull(lx2,0))+sum(isNull(lx3,0)) lx
                        from u_zc where exists
                        (select * from u_zcbaoinfo where zcid=U_zc.id and bid=@bid)
                        group by huobi ";
        sql = sql.Replace("@bid", bid);
        DataSet ds1 = com1.TableComm.SearchData(sql);
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            if (dr["huobi"].ToString() == "美元")
            {
                bj2 += Double.Parse(dr["bj"].ToString());
                lx2 += Double.Parse(dr["lx"].ToString());
            }
            else
            {
                bj1 += Double.Parse(dr["bj"].ToString());
                lx1 += Double.Parse(dr["lx"].ToString());
            }
            hs+=int.Parse(dr["hs"].ToString());
        }
    }

    private static int GetZcBaoCount(CommTable com1,string status)
    {
        StringBuilder str1 = new StringBuilder(null);
        if (status == "00")
        {
            str1.Append("select count(*) from u_zcbao where bstatus is null");
        }
        else
        {
            str1.Append("select count(*) from u_zcbao where bstatus='" + status + "'");
        }
        DataSet ds1=com1.TableComm.SearchData(str1.ToString());
        return Int32.Parse(ds1.Tables[0].Rows[0][0].ToString());

    }
    #endregion
}
