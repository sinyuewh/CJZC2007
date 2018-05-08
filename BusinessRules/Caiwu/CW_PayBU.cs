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
    public class CW_PayBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "CW_Pay";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public CW_PayBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CW_PayBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        public Hashtable GetObjectByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            return this.tabCommand.SearchData(list1);
        }

        public bool CheckBill(string id, string UserName)
        {
            string[] arr1 = new string[] { "fee1", "fee2","fee3","fee4","fee5","fee6",
                                           "fee7","fee8","fee9","fee10","fee11","fee12" };
            double[] fee = new double[arr1.Length];
            double[] fee1 = new double[arr1.Length];

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
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        if (ds.Tables[0].Rows[0][arr1[i]] != DBNull.Value)
                        {
                            fee[i] = double.Parse(ds.Tables[0].Rows[0][arr1[i]].ToString());
                        }
                    }

                    //更新资产的相关数据
                    string zcid = ds.Tables[0].Rows[0]["zcid"].ToString();
                    list1.Clear();
                    list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                    this.tabCommand.TabName = "U_ZC3";
                    DataSet ds1 = this.tabCommand.SearchData("*", list1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < arr1.Length; i++)
                        {
                            if (ds1.Tables[0].Rows[0][arr1[i]] != DBNull.Value)
                            {
                                fee1[i] = double.Parse(ds1.Tables[0].Rows[0][arr1[i]].ToString());
                            }
                        }

                        for (int i = 0; i < arr1.Length; i++)
                        {
                            if (fee[i] + fee1[i] != 0)
                            {
                                ds1.Tables[0].Rows[0][arr1[i]] = fee[i] + fee1[i];
                            }
                        }
                        
                    }
                    else
                    {
                        DataRow dr = ds1.Tables[0].NewRow();
                        dr["id"] = zcid;
                        for (int i = 0; i < arr1.Length; i++)
                        {
                            if (fee[i] != 0)
                            {
                                dr[arr1[i]] = fee[i];
                            }
                        }
                        dr["pbj"] = 0;
                        dr["plx"] = 0;
                        ds1.Tables[0].Rows.Add(dr);
                    }

                    this.tabCommand.Update(ds1);
                    this.tabCommand.TabName = TabName;

                }
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch (Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                throw err1;
                //return false;
            }
        }

        //得到合适的单据编号
        public string GetBillNum()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            //list1.Add(new SearchField("year(billtime)", DateTime.Now.Year.ToString() + "", SearchFieldType.数值型));
            //list1.Add(new SearchField("month(billtime)", DateTime.Now.Month.ToString() + "", SearchFieldType.数值型));
            list1.Add(new SearchField("Left(bill,6)", DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "", SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData(" top 1 Right(bill,2) as bill", list1, "id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int num1 = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                num1++;
                result = DateTime.Now.ToString("yyyyMM") + num1.ToString().PadLeft(2, '0');
            }
            else
            {
                result = DateTime.Now.ToString("yyyyMM01");
            }
            return result;
        }

        //同时增加支出单据和单据明细
        public bool InsertData(Hashtable ht)
        {
            this.tabCommand.InsertData(ht);
            return true;
        }

        public void DelPayDJ(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
        }


        public DataSet GetZhiChu(string begintime, string endtime, string depart)
        {
            string sql1 = "select zeren from CW_PayView";
            if (depart != "" && depart != null)
            {
                sql1 = sql1 + " where depart='" + depart + "'";
            }
            sql1 = sql1 + " group by zeren";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string sql2 = "select bzeren from CW_Pay1View";
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

            string sql3 = "select sum(isnull(fee1,0)) as Sumfee1,sum(isnull(fee2,0)) as Sumfee2,sum(isnull(fee3,0)) as Sumfee3,sum(isnull(fee4,0)) as Sumfee4,sum(isnull(fee5,0)) as Sumfee5,sum(isnull(fee6,0)) as Sumfee6,sum(isnull(fee7,0)) as Sumfee7,sum(isnull(fee8,0)) as Sumfee8,sum(isnull(fee9,0)) as Sumfee9,sum(isnull(fee10,0)) as Sumfee10,sum(isnull(fee11,0)) as Sumfee11,sum(isnull(fee12,0)) as Sumfee12,zeren from CW_PAY where 1=1";
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
            tab1.Columns.Add("zcid");
            tab1.Columns.Add("bid");
            tab1.Columns.Add("Sumfee1");
            tab1.Columns.Add("Sumfee2");
            tab1.Columns.Add("Sumfee3");
            tab1.Columns.Add("Sumfee4");
            tab1.Columns.Add("Sumfee5");
            tab1.Columns.Add("Sumfee6");
            tab1.Columns.Add("Sumfee7");
            tab1.Columns.Add("Sumfee8");
            tab1.Columns.Add("Sumfee9");
            tab1.Columns.Add("Sumfee10");
            tab1.Columns.Add("Sumfee11");
            tab1.Columns.Add("Sumfee12");
            tab1.Columns.Add("Sumfee");

            U_UserNameBU user1 = new U_UserNameBU();
            DataRow dr1 = null;

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr1 = tab1.NewRow();

                dr1["zeren"] = ds1.Tables[0].Rows[i][0].ToString();
                Hashtable ht = this.GetZCIDAndBIDByZeren(ds1.Tables[0].Rows[i][0].ToString(), begintime, endtime);
                dr1["zcid"] = ht["zcid"].ToString();
                dr1["bid"] = ht["bid"].ToString();
                dr1["Sumfee1"] = "0";
                dr1["Sumfee2"] = "0";
                dr1["Sumfee3"] = "0";
                dr1["Sumfee4"] = "0";
                dr1["Sumfee5"] = "0";
                dr1["Sumfee6"] = "0";
                dr1["Sumfee7"] = "0";
                dr1["Sumfee8"] = "0";
                dr1["Sumfee9"] = "0";
                dr1["Sumfee10"] = "0";
                dr1["Sumfee11"] = "0";
                dr1["Sumfee12"] = "0";
                dr1["Sumfee"] = "0";
                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    if (ds3.Tables[0].Rows[j]["zeren"].ToString() == ds1.Tables[0].Rows[i][0].ToString())
                    {
                        for (int k = 1; k < 13; k++)
                        {
                            if (ds3.Tables[0].Rows[j]["Sumfee"+k].ToString() != "" && ds3.Tables[0].Rows[j]["Sumfee"+k] != null)
                            {
                                dr1["Sumfee"+k] = ds3.Tables[0].Rows[j]["Sumfee"+k].ToString();
                            }
                            dr1["Sumfee"] = double.Parse(dr1["Sumfee"].ToString()) + double.Parse(dr1["Sumfee" + k].ToString());
                        }
                    }
                }
                //dr1["depart"] = user1.GetDepart1(ds1.Tables[0].Rows[i][0].ToString());
                tab1.Rows.Add(dr1);
            }

            string sql4 = "select sum(isnull(fee1,0)) as Sumfee1,sum(isnull(fee2,0)) as Sumfee2,sum(isnull(fee3,0)) as Sumfee3,sum(isnull(fee4,0)) as Sumfee4,sum(isnull(fee5,0)) as Sumfee5,sum(isnull(fee6,0)) as Sumfee6,sum(isnull(fee7,0)) as Sumfee7,sum(isnull(fee8,0)) as Sumfee8,sum(isnull(fee9,0)) as Sumfee9,sum(isnull(fee10,0)) as Sumfee10,sum(isnull(fee11,0)) as Sumfee11,sum(isnull(fee12,0)) as Sumfee12,bzeren from CW_PAY1 where 1=1";
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
                        for (int k = 1; k < 13; k++)
                        {
                            if (ds4.Tables[0].Rows[j]["Sumfee"+k].ToString() != "" && ds4.Tables[0].Rows[j]["Sumfee"+k] != null)
                            {
                                tab1.Rows[i]["Sumfee" + k] = double.Parse(tab1.Rows[i]["Sumfee"+k].ToString()) + double.Parse(ds4.Tables[0].Rows[j]["Sumfee" + k].ToString());
                            }
                            tab1.Rows[i]["Sumfee"] = double.Parse(tab1.Rows[i]["Sumfee"].ToString()) + double.Parse(ds4.Tables[0].Rows[j]["Sumfee" + k].ToString());
                        }

                    }
                }
            }

            ds.Tables.Add(tab1);
            return ds;
        }

        public DataSet GetZhiChuByDepart(string begintime, string endtime)
        {
            string sql1 = "select depart,dnum from CW_PayView group by depart,dnum";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string sql2 = "select depart,dnum from CW_Pay1View group by depart,dnum";
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
                    ds1.Tables[0].Rows.Add(dr);
                }
            }

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                for (int j = i + 1; j < ds1.Tables[0].Rows.Count; j++)
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

            string sql3 = "select sum(isnull(fee1,0)) + sum(isnull(fee2,0)) + sum(isnull(fee3,0)) + sum(isnull(fee4,0)) + sum(isnull(fee5,0)) + sum(isnull(fee6,0)) + sum(isnull(fee7,0)) + sum(isnull(fee8,0)) + sum(isnull(fee9,0)) + sum(isnull(fee10,0)) + sum(isnull(fee11,0)) + sum(isnull(fee12,0)) as Sumfee,depart from CW_PAYVIEW where 1=1";
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
            tab1.Columns.Add("Sumfee");

            DataRow dr1 = null;

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr1 = tab1.NewRow();

                dr1["depart"] = ds1.Tables[0].Rows[i][0].ToString();
                dr1["Sumfee"] = "0";
                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    if (ds3.Tables[0].Rows[j]["depart"].ToString() == ds1.Tables[0].Rows[i][0].ToString())
                    {
                        dr1["Sumfee"] = double.Parse(dr1["Sumfee"].ToString()) + double.Parse(ds3.Tables[0].Rows[j]["Sumfee"].ToString());
                    }
                }
                tab1.Rows.Add(dr1);
            }

            string sql4 = "select sum(isnull(fee1,0)) + sum(isnull(fee2,0)) + sum(isnull(fee3,0)) + sum(isnull(fee4,0)) + sum(isnull(fee5,0)) + sum(isnull(fee6,0)) + sum(isnull(fee7,0)) + sum(isnull(fee8,0)) + sum(isnull(fee9,0)) + sum(isnull(fee10,0)) + sum(isnull(fee11,0)) + sum(isnull(fee12,0)) as Sumfee,depart from CW_PAY1VIEW where 1=1";
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
                       tab1.Rows[i]["Sumfee"] = double.Parse(tab1.Rows[i]["Sumfee"].ToString()) + double.Parse(ds4.Tables[0].Rows[j]["Sumfee"].ToString());
                    }
                }
            }

            ds.Tables.Add(tab1);
            return ds;
        }

        public Hashtable GetZCIDAndBIDByZeren(string zeren, string begintime, string endtime)
        {
            string sql1 = "select id from CW_Pay where 1=1";
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
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (zcid == "")
                {
                    zcid = ds1.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    zcid = zcid + "," + ds1.Tables[0].Rows[i][0].ToString();
                }
            }
            string sql2 = "select id from CW_Pay1 where 1=1";
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

        public DataSet GetGSFYHJ(string begintime, string endtime)
        {
            Hashtable ht = this.GetZCIDAndBIDByZeren("", begintime, endtime);
            DataSet ds = new DataSet();
            DataTable tab1 = new DataTable();
            tab1.Columns.Add("gsname");
            tab1.Columns.Add("fyhj");
            tab1.Columns.Add("zcid");
            tab1.Columns.Add("bid");
            DataRow dr = tab1.NewRow();
            dr["gsname"] = "长江资产管理公司";
            dr["fyhj"] = "0";
            dr["zcid"] = ht["zcid"].ToString();
            dr["bid"] = ht["bid"].ToString();
            tab1.Rows.Add(dr);
            ds.Tables.Add(tab1);
            return ds;
        }
        #endregion

        #region 支出统计
        /// <summary>
        /// 根据时间段统计支出数据
        /// </summary>
        /// <param name="time0">开始时间</param>
        /// <param name="time1">结束时间</param>
        /// <returns></returns>
        public DataSet GetZhiChuStaticDataByDefineTime(String time0, String time1)
        {
            string sql = @"select A.zeren,U_depart.depart,
                    isnull(sum(fee1),0) fee1,isnull(sum(fee2),0) fee2,isNull(sum(fee3),0) fee3,isNull(sum(fee4),0) fee4,isNull(sum(fee5),0) fee5,
                    isnull(sum(fee6),0) fee6,isnull(sum(fee7),0) fee7,isNull(sum(fee8),0) fee8,isNull(sum(fee9),0) fee9,isNull(sum(fee10),0) fee10,
                    isnull(sum(fee11),0) fee11,isnull(sum(fee12),0) fee12,isNull(sum(fee13),0) fee13,isNull(sum(fee14),0) fee14,isNull(sum(fee15),0) fee15,
                    isnull(sum(fee16),0) fee16,isnull(sum(fee17),0) fee17,isNull(sum(fee18),0) fee18,isNull(sum(fee19),0) fee19,isNull(sum(fee20),0) fee20
                    from
                    (
                    select zeren,fee1,fee2,fee3,fee4,fee5,fee6,fee7,fee8,fee9,fee10,
                    fee11,fee12,fee13,fee14,fee15,fee16,fee17,fee18,fee19,fee20
                    from cw_pay where checktime is not null
                    and billtime>=@time0
                    and billtime<=@time1
                    union All
                    select bzeren,fee1,fee2,fee3,fee4,fee5,fee6,fee7,fee8,fee9,fee10,
                    fee11,fee12,fee13,fee14,fee15,fee16,fee17,fee18,fee19,fee20
                    from cw_pay1 where checktime is not null
                    and billtime>=@time0
                    and billtime<=@time1 ) A
                    inner join U_userName on A.zeren=U_userName.sname
                    inner join U_depart on U_userName.depart=U_depart.depart

                    group by U_depart.num, U_UserName.num,A.zeren,U_depart.depart
                    order by U_depart.num, U_UserName.num ";


            //设置查询差数
            SqlParameter[] para1 = new SqlParameter[2];
            if (time0 != null && time0.Trim() != "")
            {
                para1[0] = new SqlParameter("@time0", DateTime.Parse(time0).ToString("yyyy-MM-dd") + " 00:00:00");
            }
            else
            {
                sql = sql.Replace("billtime>=@time0", " 1=1 ");
            }

            if (time1 != null && time1.Trim() != "")
            {
                para1[1] = new SqlParameter("@time1", DateTime.Parse(time1).ToString("yyyy-MM-dd") + " 23:59:59");
            }
            else
            {
                sql = sql.Replace("billtime<=@time1", " 1=1");
            }

            //设置统计的时间
            HttpContext.Current.Items["time0"] = time0;
            HttpContext.Current.Items["time1"] = time1;

            return this.tabCommand.TableComm.SearchData(sql, CommandType.Text, para1);
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

