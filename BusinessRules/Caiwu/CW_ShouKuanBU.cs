using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Data.SqlClient;
using System.Web;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// 用户业务处理类
    /// </summary>
    public partial class CW_ShouKuanBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "CW_ShouKuan";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public CW_ShouKuanBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CW_ShouKuanBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        //得到合适的单据编号
        public string GetBillNum()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            //list1.Add( new SearchField("year(billtime)", DateTime.Now.Year.ToString()+"",SearchFieldType.数值型));
            //list1.Add( new SearchField("month(billtime)", DateTime.Now.Month.ToString()+"",SearchFieldType.数值型));
            list1.Add(new SearchField("Left(bill,6)", DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2,'0') + "", SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData(" top 1 Right(bill,2) as bill", list1, "id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int num1 =Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                num1++;
                result = DateTime.Now.ToString("yyyyMM")+num1.ToString().PadLeft(2,'0');
            }
            else
            {
                result = DateTime.Now.ToString("yyyyMM01");
            }
            return result;
        }

        public Hashtable GetObjectByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            return this.tabCommand.SearchData(list1);
        }

        public bool CheckBill(string id,string UserName)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                DataSet ds = this.tabCommand.SearchData("*", list1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0]["checkmen"] = UserName;
                    ds.Tables[0].Rows[0]["checktime"] = DateTime.Now.ToString();
                    this.tabCommand.Update(ds);
                    double pbj = 0;
                    double plx = 0;
                    if (ds.Tables[0].Rows[0]["pbj"] != DBNull.Value)
                    {
                        pbj = double.Parse(ds.Tables[0].Rows[0]["pbj"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["plx"] != DBNull.Value)
                    {
                        plx = double.Parse(ds.Tables[0].Rows[0]["plx"].ToString());
                    }


                    //更新资产的相关数据
                    string zcid = ds.Tables[0].Rows[0]["zcid"].ToString();
                    list1.Clear();
                    list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                    this.tabCommand.TabName = "U_ZC3";
                    DataSet ds1 = this.tabCommand.SearchData("*", list1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        double pbj1 = 0;
                        double plx1 = 0;
                        if (ds1.Tables[0].Rows[0]["pbj"] != DBNull.Value)
                        {
                            pbj1 = double.Parse(ds1.Tables[0].Rows[0]["pbj"].ToString());
                        }
                        if (ds1.Tables[0].Rows[0]["plx"] != DBNull.Value)
                        {
                            plx1 = double.Parse(ds1.Tables[0].Rows[0]["plx"].ToString());
                        }

                        pbj = pbj + pbj1;
                        plx = plx + plx1;

                        ds1.Tables[0].Rows[0]["pbj"] = pbj;
                        ds1.Tables[0].Rows[0]["plx"] = plx;
                    }
                    else
                    {
                        DataRow dr = ds1.Tables[0].NewRow();
                        dr["id"] = zcid;
                        dr["pbj"] = pbj;
                        dr["plx"] = plx;
                        for (int i = 1; i <= 20; i++)
                        {
                            dr["fee" + i] = 0;
                        }
                        ds1.Tables[0].Rows.Add(dr);
                    }

                    this.tabCommand.Update(ds1);
                    
                    this.tabCommand.TabName = TabName;

                }
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch(Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                throw err1;
                //return false;
            }
        }

        public bool InsertData(Hashtable ht)
        {
            this.tabCommand.InsertData(ht);
            return true;
        }

        //得到没有审核的单据DataSet（不限于收款）
        public DataSet GetBillList(string kind,List<SearchField> list1,bool check)
        {
            string billkind = null;
            string EditASP = null;
            string viewName = null;
            switch (kind)
            {
                case "0":
                    billkind = "收";
                    EditASP = "EditShouKuan.aspx";
                    viewName = "CW_ShouKuanView";
                    break;
                case "1":
                    billkind = "付";
                    EditASP = "EditPay.aspx";
                    viewName = "CW_PayView";
                    break;
                case "2":
                    billkind = "入";
                    EditASP = "EditInStock.aspx";
                    viewName = "CW_InStockView";
                    break;
                case "3":
                    billkind = "出";
                    EditASP = "EditOutStock.aspx";
                    viewName = "CW_OutStockView";
                    break;
                default:
                    billkind = "收";
                    EditASP = "EditShouKuan.aspx";
                    viewName = "CW_ShouKuanView";
                    break;
            }
            this.tabCommand.TabName = viewName;
            if (check == false)
            {
                list1.Add(new SearchField("checkmen", "null", SearchOperator.空值));
            }
            else
            {
                list1.Add(new SearchField("checkmen", "null", SearchOperator.非空值));
            }
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1", list1, "bill desc");
            this.tabCommand.TabName = TabName;
            
            System.Type StringType;
            StringType = System.Type.GetType("System.String");

            ds1.Tables[0].Columns.Add("billkind",StringType,"'"+billkind+"'");
            ds1.Tables[0].Columns.Add("EditASP",StringType,"'"+EditASP+"'");

            return ds1;
        }

        public DataSet GetBillByID(string kind,string ids)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (ids != "" && ids != null)
            {
                list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
            }
            string viewName = null;
            switch (kind)
            {
                case "0":
                    viewName = "CW_ShouKuanView";
                    break;
                case "1":
                    viewName = "CW_PayView";
                    break;
                case "2":
                    viewName = "CW_ShouKuan1View";
                    break;
                case "3":
                    viewName = "CW_Pay1View";
                    break;
                default:
                    viewName = "CW_ShouKuanView";
                    break;
            }
            this.tabCommand.TabName = viewName;
            DataSet ds1 = null;
            if (kind == "0" || kind == "1")
            {
                ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1", list1, "billtime desc");
            }
            else
            {
                ds1 = this.tabCommand.SearchData("*", list1, "billtime desc");
            }
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //删除票据
        public void DelShoukuanDJ(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id",id,SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
        }


        public DataSet Gethuikuan(string begintime, string endtime,string depart)
        {
            string sql1 = "select zeren from CW_ShouKuanView";
            if (depart != "" && depart != null)
            {
                sql1 = sql1 + " where depart='" + depart + "'";
            }
            sql1 = sql1 + " group by zeren";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string sql2 = "select bzeren from CW_ShouKuan1View";
            if (depart != "" && depart != null)
            {
                sql2 = sql2 + " where depart='" + depart + "'";
            }
            sql2 = sql2 + " group by bzeren";
            DataSet ds2 = this.tabCommand.TableComm.SearchData(sql2);
            DataRow dr = ds1.Tables[0].NewRow();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                bool first = false;
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j][0].ToString() == ds2.Tables[0].Rows[i][0].ToString())
                    {
                        first = true;
                    }
                }
                if (first == false)
                {
                    dr["zeren"] = ds2.Tables[0].Rows[i][0].ToString();
                    ds1.Tables[0].Rows.Add(dr);
                }
            }
            string sql3 = "select sum(isnull(pbj,0))+ sum(isnull(plx,0)) as hkje,zeren from CW_ShouKuanView where 1=1";
            if (depart != "" && depart != null)
            {
                sql3 = sql3 + " and depart = '" + depart + "'";
            }
            if (begintime != "" && begintime != null)
            {
                sql3 = sql3 + " and billtime >= '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql3 = sql3 + " and billtime <= '" + endtime + "'";
            }
            sql3 = sql3 + " group by zeren";
            DataSet ds3 = this.tabCommand.TableComm.SearchData(sql3);
            DataSet ds = new DataSet();
            DataTable tab1 = new DataTable();
            //tab1.Columns.Add("depart");
            tab1.Columns.Add("zeren");
            tab1.Columns.Add("hkje");
            tab1.Columns.Add("zcid");
            tab1.Columns.Add("bid");
            U_UserNameBU user1 = new U_UserNameBU();
            DataRow dr1 = null;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr1 = tab1.NewRow();

                dr1["zeren"] = ds1.Tables[0].Rows[i][0].ToString();
                Hashtable ht = this.GetZCIDAndBIDByZeren(ds1.Tables[0].Rows[i][0].ToString(),begintime,endtime);
                dr1["zcid"] = ht["zcid"].ToString();
                dr1["bid"] = ht["bid"].ToString();
                dr1["hkje"] = "0";
                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    if (ds3.Tables[0].Rows[j]["zeren"].ToString() == ds1.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds3.Tables[0].Rows[j]["hkje"].ToString() != "" && ds3.Tables[0].Rows[j]["hkje"] != null)
                        {
                            dr1["hkje"] = ds3.Tables[0].Rows[j]["hkje"].ToString();
                        }
                    }
                }
                //dr1["depart"] = user1.GetDepart1(ds1.Tables[0].Rows[i][0].ToString());
                tab1.Rows.Add(dr1);
            }

            string sql4 = "select sum(isnull(pbj,0))+ sum(isnull(plx,0)) as hkje,bzeren from CW_ShouKuan1View where 1=1";
            if (depart != "" && depart != null)
            {
                sql4 = sql4 + " and depart = '" + depart + "'";
            }
            if (begintime != "" && begintime != null)
            {
                sql4 = sql4 + " and billtime >= '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql4 = sql4 + " and billtime <= '" + endtime + "'";
            }
            sql4 = sql4 + " group by bzeren";
            DataSet ds4 = this.tabCommand.TableComm.SearchData(sql4);

            for (int i = 0; i < tab1.Rows.Count; i++)
            {
                for (int j = 0; j < ds4.Tables[0].Rows.Count; j++)
                {
                    if (ds4.Tables[0].Rows[j]["bzeren"].ToString() == tab1.Rows[i]["zeren"].ToString())
                    {
                        if (ds4.Tables[0].Rows[j]["hkje"].ToString() != "" && ds4.Tables[0].Rows[j]["hkje"] != null)
                        {
                            tab1.Rows[i]["hkje"] = double.Parse(tab1.Rows[i]["hkje"].ToString()) + double.Parse(ds4.Tables[0].Rows[j]["hkje"].ToString());
                        }
                    }
                }
            }
            ds.Tables.Add(tab1);
            return ds;
        }

        public DataSet GetHuiKuanByDepart(string begintime, string endtime)
        {
            string sql1 = "select depart,dnum from CW_ShouKuanView group by depart,dnum";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string sql2 = "select depart,dnum from CW_ShouKuan1View group by depart,dnum";
            DataSet ds2 = this.tabCommand.TableComm.SearchData(sql2);
            DataRow dr = ds1.Tables[0].NewRow();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                bool first = false;
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j][0].ToString() == ds2.Tables[0].Rows[i][0].ToString())
                    {
                        first = true;
                    }
                }
                if (first == false)
                {
                    dr["depart"] = ds2.Tables[0].Rows[i][0].ToString();
                    dr["dnum"] = ds2.Tables[0].Rows[i][1].ToString();
                    ds1.Tables[0].Rows.Add(dr);
                }
            }

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                for (int j = i+1; j < ds1.Tables[0].Rows.Count ; j++)
                {
                    if (int.Parse(ds1.Tables[0].Rows[i][1].ToString()) > int.Parse(ds1.Tables[0].Rows[j][1].ToString()))
                    {
                        string temp = ds1.Tables[0].Rows[j][0].ToString();
                        string temp1 = ds1.Tables[0].Rows[j][1].ToString();
                        ds1.Tables[0].Rows[j][0] = ds1.Tables[0].Rows[i][0].ToString();
                        ds1.Tables[0].Rows[j][1] = ds1.Tables[0].Rows[i][1].ToString();
                        ds1.Tables[0].Rows[i][0] = temp;
                        ds1.Tables[0].Rows[i][1] = temp1;
                    }
                }
            }

            string sql3 = "select sum(isnull(pbj,0))+ sum(isnull(plx,0)) as hkje,depart from CW_ShouKuanView where 1=1";
            if (begintime != "" && begintime != null)
            {
                sql3 = sql3 + " and billtime >= '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql3 = sql3 + " and billtime <= '" + endtime + "'";
            }
            sql3 = sql3 + " group by depart";
            DataSet ds3 = this.tabCommand.TableComm.SearchData(sql3);
            DataSet ds = new DataSet();
            DataTable tab1 = new DataTable();
            tab1.Columns.Add("depart");
            tab1.Columns.Add("hkje");
            DataRow dr1 = null;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr1 = tab1.NewRow();

                dr1["depart"] = ds1.Tables[0].Rows[i][0].ToString();
                dr1["hkje"] = "0";
                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    if (ds3.Tables[0].Rows[j]["depart"].ToString() == ds1.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds3.Tables[0].Rows[j]["hkje"].ToString() != "" && ds3.Tables[0].Rows[j]["hkje"] != null)
                        {
                            dr1["hkje"] = ds3.Tables[0].Rows[j]["hkje"].ToString();
                        }
                    }
                }
                tab1.Rows.Add(dr1);
            }

            string sql4 = "select sum(isnull(pbj,0))+ sum(isnull(plx,0)) as hkje,depart from CW_ShouKuan1View where 1=1";
            if (begintime != "" && begintime != null)
            {
                sql4 = sql4 + " and billtime >= '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql4 = sql4 + " and billtime <= '" + endtime + "'";
            }
            sql4 = sql4 + " group by depart";
            DataSet ds4 = this.tabCommand.TableComm.SearchData(sql4);

            for (int i = 0; i < tab1.Rows.Count; i++)
            {
                for (int j = 0; j < ds4.Tables[0].Rows.Count; j++)
                {
                    if (ds4.Tables[0].Rows[j]["depart"].ToString() == tab1.Rows[i]["depart"].ToString())
                    {
                        if (ds4.Tables[0].Rows[j]["hkje"].ToString() != "" && ds4.Tables[0].Rows[j]["hkje"] != null)
                        {
                            tab1.Rows[i]["hkje"] = double.Parse(tab1.Rows[i]["hkje"].ToString()) + double.Parse(ds4.Tables[0].Rows[j]["hkje"].ToString());
                        }
                    }
                }
            }
            ds.Tables.Add(tab1);
            return ds;
        }

        public Hashtable GetZCIDAndBIDByZeren(string zeren,string begintime,string endtime)
        {
            string sql1 = "select id from CW_ShouKuan where 1=1";
            if (zeren != "" && zeren != null)
            { 
                sql1 = sql1 + " and zeren ='" + zeren + "'";
            }
            if (begintime != "" && begintime != null)
            {
                sql1 = sql1 + " and billtime >= '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql1 = sql1 + " and billtime <= '" + endtime + "'";
            }
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string zcid = "";
            for(int i = 0;i<ds1.Tables[0].Rows.Count;i++)
            {
                if(zcid=="")
                {
                    zcid = ds1.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    zcid = zcid + "," + ds1.Tables[0].Rows[i][0].ToString();
                }
            }
            string sql2 = "select id from CW_SHouKuan1 where 1=1";
            if (zeren != "" && zeren != null)
            {
                sql2 = sql2 + " and bzeren ='" + zeren + "'";
            }
            if (begintime != "" && begintime != null)
            {
                sql2 = sql2 + " and billtime >= '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql2 = sql2 + " and billtime <= '" + endtime + "'";
            }
            DataSet ds2 = this.tabCommand.TableComm.SearchData(sql2);
            string bid = "";
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                if (bid == "")
                {
                    bid = ds2.Tables[0].Rows[j][0].ToString();
                }
                else
                {
                    bid = bid + "," + ds2.Tables[0].Rows[j][0].ToString();
                }
            }
            Hashtable ht = new Hashtable();
            ht["zcid"] = zcid;
            ht["bid"] = bid;
            return ht;
        }

        public DataSet GetGSHK(string begintime,string endtime)
        {
            Hashtable ht = this.GetZCIDAndBIDByZeren("", begintime, endtime);
            DataSet ds = new DataSet();
            DataTable tab1 = new DataTable();
            tab1.Columns.Add("gsname");
            tab1.Columns.Add("hkje");
            tab1.Columns.Add("zcid");
            tab1.Columns.Add("bid");
            DataRow dr = tab1.NewRow();
            dr["gsname"] = "长江资产管理公司";
            dr["hkje"] = "0";
            dr["zcid"] = ht["zcid"].ToString();
            dr["bid"] = ht["bid"].ToString();
            tab1.Rows.Add(dr);
            ds.Tables.Add(tab1);
            return ds;
        }
        #endregion

        #region 回款的统计
        //编码：金寿吉（2008年1月30日）
        /// <summary>
        /// 按年统计回款数据
        /// </summary>
        /// <param name="year">统计的年份</param>
        /// <returns></returns>
        public DataSet GetHuiKuanStaticDataByYear(int year)
        {
            string time0 = year + "-1-1";
            string time1 = year + "-12-31";
            return this.GetHuiKuanStaticDataByDefineTime(time0,time1);
        }

        /// <summary>
        /// 按年月统计回款数据
        /// </summary>
        /// <param name="year">统计的年份</param>
        /// <param name="month">统计的月份</param>
        /// <returns></returns>
        public DataSet GetHuiKuanStaticDataByYearAndMonth(int year,int month)
        {
            string time0 = year +"-"+month+"-1";

            //计算下一个月的时间后退1天就是当月的最大日子（避免处理小月和闰年）
            if (month == 12)
            {
                year++;
            }
            else
            {
                month++;
            }
            string time1 = DateTime.Parse(year + "-" + month + "-1").AddDays(-1).ToString("yyyy-MM-dd");
            return this.GetHuiKuanStaticDataByDefineTime(time0, time1);
        }

        /// <summary>
        /// 按年和季度统计回款数据
        /// </summary>
        /// <param name="year">统计的年份</param>
        /// <param name="quanty">统计的季度</param>
        /// <returns></returns>
        public DataSet GetHuiKuanStaticDataByYearAndQuarty(int year, int quanty)
        {
            int month1 = (quanty - 1) * 3+1;
            int month2 = month1 + 3;
            String time0 = year + "-" + month1 + "-1";

            if (month2 == 12)
            {
                year++;
            }
            else
            {
                month2++;
            }
            string time1 = DateTime.Parse(year + "-" + month2 + "-1").AddDays(-1).ToString("yyyy-MM-dd");
            return this.GetHuiKuanStaticDataByDefineTime(time0, time1);
        }


        /// <summary>
        /// 按用户自定义的时间段来统计
        /// </summary>
        /// <param name="time0">开始时间</param>
        /// <param name="time1">结束时间</param>
        /// <returns></returns>
        public DataSet GetHuiKuanStaticDataByDefineTime(String time0,String time1)
        {
            string sql = @"select  U_depart.num dnum,U_depart.depart depart,U_UserName.num snum,U_UserName.Sname as zeren,
                         isnull(sum(pbj),0) pbj,isNull(sum(plx),0) plx,isnull(sum(pbj),0)+isNull(sum(plx),0) sum1 from
                         (select  danwei,zeren,pbj,plx,billtime,checktime  from cw_shoukuan 
                          where  ( billtime is null or billtime>=@time0 )
                         and (billtime is null or  billtime<=@time1)
                           union
                         select  bname,bzeren,pbj,plx,billtime,checktime  from cw_shoukuan1
			            where  ( billtime is null or billtime>=@time0)
                         and (billtime is null or  billtime<=@time1)
                          ) 
                         as A  Right outer join U_UserName on A.zeren=U_UserName.sname
                         left join U_depart on U_UserName.depart=U_depart.depart 
                         where exists (select * from u_ZC where U_userName.sname=u_zc.zeren or A.zeren!=null)

                         group by U_depart.num, U_depart.depart,U_UserName.num ,U_UserName.Sname 
                         order by U_depart.num,U_UserName.num ";


            //设置查询差数
            SqlParameter[] para1 = new SqlParameter[2];
            if (time0 != null && time0.Trim() != "")
            {
                para1[0] = new SqlParameter("@time0", DateTime.Parse(time0).ToString("yyyy-MM-dd")+" 00:00:00");
            }
            else
            {
                sql = sql.Replace("billtime is null or billtime>=@time0", " 1=1 ");
            }

            if (time1 != null && time1.Trim() != "")
            {
                para1[1] = new SqlParameter("@time1", DateTime.Parse(time1).ToString("yyyy-MM-dd")+" 23:59:59");
            }
            else
            {
                sql = sql.Replace("billtime is null or  billtime<=@time1", " 1=1");
            }

            //设置统计的时间
            HttpContext.Current.Items["time0"] = time0;
            HttpContext.Current.Items["time1"] = time1;

            return this.tabCommand.TableComm.SearchData(sql, CommandType.Text, para1);
        }

        /// <summary>
        /// 根据条件得到收款单据情况
        /// </summary>
        /// <param name="dt1">单据的开始时间</param>
        /// <param name="dt2">单击的结束时间</param>
        /// <param name="depart">部门</param>
        /// <param name="zeren">责任人</param>
        /// <returns></returns>
        public DataSet GetShoukuanBillBySearchData(string dt1,string dt2,
            string depart,string zeren,int flag)
        {
            string sql1="";
            if (flag == 0)
            {
                //资产回款
                sql1 = @"select *,left(danwei,20) as danwei1 from CW_ShouKuanView 
                          where checktime is not null 
                          and billtime>=@time1
                          and billtime<=@time2
                          and depart=@depart
                          and zeren=@zeren
                          order by billtime desc";
            }
            else
            {
                //资产包回款
                sql1 = @"select * from CW_ShouKuan1View 
                          where checktime is not null 
                          and billtime>=@time1
                          and billtime<=@time2
                          and depart=@depart
                          and bzeren=@zeren
                          order by billtime desc";
            }

            SqlParameter[] para1 = new SqlParameter[4];
            if (dt1 != "" && dt1 != null)
            {
                string time1 = DateTime.Parse(dt1).ToString("yyyy-MM-dd") + " 00:00:00";
                para1[0] = new SqlParameter("@time1", time1);
            }
            else
            {
                sql1 = sql1.Replace("and billtime>=@time1", "");
            }

            if (dt2 != "" && dt2 != null)
            {
                string time2 = DateTime.Parse(dt2).ToString("yyyy-MM-dd") + " 23:59:59";
                para1[1] = new SqlParameter("@time2", time2);
            }
            else
            {
                sql1 = sql1.Replace("and billtime<=@time2", "");
            }

            if (depart != "" && depart != null)
            {
                para1[2] = new SqlParameter("@depart", depart);
            }
            else
            {
                sql1 = sql1.Replace("and depart=@depart", "");
            }

            if (zeren != "" && zeren != null)
            {
                para1[3] = new SqlParameter("@zeren", zeren);
            }
            else
            {
                sql1 = sql1.Replace("and zeren=@zeren", "");
                sql1 = sql1.Replace("and bzeren=@zeren", "");
            }


            DataSet ds1= this.tabCommand.TableComm.SearchData(sql1,CommandType.Text,para1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds1.Tables[0].NewRow();
                if (flag == 0)
                {
                    dr["danwei1"] = "合计";
                }
                else
                {
                    dr["bname"] = "合计";
                }

                dr["bxhj"] = "0";
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j]["bxhj"].ToString() != "" && ds1.Tables[0].Rows[j]["bxhj"] != null)
                    {
                        dr["bxhj"] = double.Parse(dr["bxhj"].ToString()) + double.Parse(ds1.Tables[0].Rows[j]["bxhj"].ToString());
                    }
                }
                ds1.Tables[0].Rows.Add(dr);
            }
            return ds1;
        }

        /// <summary>
        /// 根据查询条件得到支付单据的详细情况
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="depart"></param>
        /// <param name="zeren"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataSet GetZhiChuBillBySearchData(string dt1, string dt2,
                    string depart, string zeren, int flag)
        {
            string sql1 = "";
            if (flag == 0)
            {
                //资产支出
                sql1 = @"select *,left(danwei,20) as danwei1 from CW_PayView 
                          where checktime is not null 
                          and billtime>=@time1
                          and billtime<=@time2
                          and depart=@depart
                          and zeren=@zeren
                          order by billtime desc";
            }
            else
            {
                //资产包支出
                sql1 = @"select * from CW_Pay1View 
                          where checktime is not null 
                          and billtime>=@time1
                          and billtime<=@time2
                          and depart=@depart
                          and bzeren=@zeren
                          order by billtime desc";
            }

            SqlParameter[] para1 = new SqlParameter[4];
            if (dt1 != "" && dt1 != null)
            {
                string time1 = DateTime.Parse(dt1).ToString("yyyy-MM-dd") + " 00:00:00";
                para1[0] = new SqlParameter("@time1", time1);
            }
            else
            {
                sql1 = sql1.Replace("and billtime>=@time1", "");
            }

            if (dt2 != "" && dt2 != null)
            {
                string time2 = DateTime.Parse(dt2).ToString("yyyy-MM-dd") + " 23:59:59";
                para1[1] = new SqlParameter("@time2", time2);
            }
            else
            {
                sql1 = sql1.Replace("and billtime<=@time2", "");
            }

            if (depart != "" && depart != null)
            {
                para1[2] = new SqlParameter("@depart", depart);
            }
            else
            {
                sql1 = sql1.Replace("and depart=@depart", "");
            }

            if (zeren != "" && zeren != null)
            {
                para1[3] = new SqlParameter("@zeren", zeren);
            }
            else
            {
                sql1 = sql1.Replace("and zeren=@zeren", "");
                sql1 = sql1.Replace("and bzeren=@zeren", "");
            }


            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1, CommandType.Text, para1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                //增加合计行
                DataRow dr = ds1.Tables[0].NewRow();
                if (flag == 0)
                {
                    dr["danwei1"] = "总计";
                }
                else
                {
                    dr["bname"] = "总计";
                }

                dr["fyhj"] = "0";
                for (int k = 1; k <= 12; k++)
                {
                    dr["fee" + k] = 0;
                }
                ds1.Tables[0].Rows.Add(dr);
                ds1.AcceptChanges();

                //调整显示的数据
                for (int j = 0; j < ds1.Tables[0].Rows.Count-1; j++)
                {
                    for (int k = 1; k <= 12; k++)
                    {
                        if (ds1.Tables[0].Rows[j]["fee" + k] == DBNull.Value)
                        {
                            ds1.Tables[0].Rows[j]["fee" + k] = 0;
                        }

                        dr["fee" + k] = double.Parse(dr["fee" + k].ToString()) + double.Parse(ds1.Tables[0].Rows[j]["fee" + k].ToString());
                    }
                    dr["fyhj"] = double.Parse(dr["fyhj"].ToString()) + double.Parse(ds1.Tables[0].Rows[j]["fyhj"].ToString());
                 }
                ds1.AcceptChanges();
                
            }
            return ds1;
        }
        #endregion

        #region 私有方法
        #endregion

        #region IDisposable 成员
        public void Dispose()
        {
            this.Close();
        }

        public void Close()
        {
            if (this.tabCommand != null)
            {
                this.tabCommand.Close();
            }
        }
        #endregion
    }
}
