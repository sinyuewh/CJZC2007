using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// 用户业务处理类
    /// </summary>
    public class CW_Pay1BU : IDisposable
    {
        #region 属性定义
        private const string TabName = "CW_Pay1";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public CW_Pay1BU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CW_Pay1BU()
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

                    //更新资产包的相关数据
                    string bid = ds.Tables[0].Rows[0]["bid"].ToString();
                    list1.Clear();
                    list1.Add(new SearchField("id", bid, SearchFieldType.数值型));
                    this.tabCommand.TabName = "U_ZCBAO";
                    DataSet ds1 = this.tabCommand.SearchData("*", list1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        double bljzc = 0;
                        double bljzc1 = 0;
                        if (ds1.Tables[0].Rows[0]["bljzc"] != DBNull.Value)
                        {
                            bljzc = double.Parse(ds1.Tables[0].Rows[0]["bljzc"].ToString());
                        }

                        for (int i = 0; i < arr1.Length; i++)
                        {
                            bljzc1 = bljzc1 + fee[i];
                        }
                        ds1.Tables[0].Rows[0]["bljzc"] = bljzc + bljzc1;

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

