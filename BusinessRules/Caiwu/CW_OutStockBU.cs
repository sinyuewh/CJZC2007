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
    public class CW_OutStockBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "CW_OutStock";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public CW_OutStockBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CW_OutStockBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        //得到出库单详细
        public Hashtable GetObjectByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            return this.tabCommand.SearchData(list1);
        }

        //得到入库单明细
        public DataSet GetOutStockBill(string bill)
        {
            this.tabCommand.TabName = "CW_OutStockBill";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill));
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //审核出库单据
        public bool CheckBill(string id, string UserName)
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

                    //修改资产中的库存数据
                    list1.Clear();
                    list1.Add(new SearchField("bill", ds.Tables[0].Rows[0]["bill"].ToString()));
                    this.tabCommand.TabName = "CW_OutStockBill";
                    DataSet ds1 = this.tabCommand.SearchData("*", list1);
                    ds1.Tables[0].PrimaryKey =new DataColumn[]{ds1.Tables[0].Columns["stockid"]};
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        string stockid = "";
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            if (stockid == "")
                            {
                                stockid = ds1.Tables[0].Rows[j]["stockid"].ToString();
                            }
                            else
                            {
                                stockid = stockid + "," + ds1.Tables[0].Rows[j]["stockid"].ToString();
                            }
                        }

                        list1.Clear();
                        list1.Add(new SearchField("id", stockid,SearchOperator.集合, SearchFieldType.数值型));
                        this.tabCommand.TabName = "CW_StockBill";
                        DataSet StockDS = this.tabCommand.SearchData("*", list1);
                        for (int j = 0; j < StockDS.Tables[0].Rows.Count; j++)
                        {
                            stockid = StockDS.Tables[0].Rows[j]["id"].ToString();
                            DataRow dr1 = ds1.Tables[0].Rows.Find(stockid);
                            DataRow dr = StockDS.Tables[0].Rows[j];
                            dr["num"] = double.Parse(dr["num"].ToString()) - double.Parse(dr1["num"].ToString());

                        }
                        this.tabCommand.Update(StockDS);
                    }
                    this.tabCommand.TabName = TabName;

                }
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch (Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                throw err1;
            }
        }

       //得到合适的单据编号
        public string GetBillNum()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("year(billtime)", DateTime.Now.Year.ToString() + "", SearchFieldType.数值型));
            list1.Add(new SearchField("month(billtime)", DateTime.Now.Month.ToString() + "", SearchFieldType.数值型));
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

        //同时增加出库单据和单据明细
        public bool InsertData(Hashtable ht, DataSet ChildDs)
        {
            string[] arr1 = new string[] { "bill","gkind","gname", "ggxh", "num", "price","remark", "dw", "stockid" };
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //增加单据
                this.tabCommand.InsertData(ht);

                //增加单据明细
                this.tabCommand.TabName = "CW_OutStockBill";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", "-1", SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("*", list1);
                for (int i = 0; i < ChildDs.Tables[0].Rows.Count; i++)
                {
                    if (ChildDs.Tables[0].Rows[i]["num"] != null && ChildDs.Tables[0].Rows[i]["num"].ToString().Trim() != "" && double.Parse(ChildDs.Tables[0].Rows[i]["num"].ToString().Trim())>0)
                    {
                        DataRow dr = ds1.Tables[0].NewRow();
                        for (int j = 0; j < arr1.Length; j++)
                        {
                            dr[arr1[j]] = ChildDs.Tables[0].Rows[i][arr1[j]];
                        }
                        ds1.Tables[0].Rows.Add(dr);
                    }
                }
                this.tabCommand.Update(ds1);
                this.tabCommand.TabName = TabName;

                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        public void DelOutStockDJ(string bill)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "CW_OutStockBill";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string id = ds.Tables[0].Rows[i]["id"].ToString();
                        List<SearchField> list2 = new List<SearchField>();
                        list2.Add(new SearchField("id", id, SearchFieldType.数值型));
                        this.tabCommand.DeleteData(list1);
                    }
                }
                this.tabCommand.TabName = TabName;
                this.tabCommand.DeleteData(list1);
                this.tabCommand.TableConnect.CommitTrans();
            }
            catch
            {
                this.tabCommand.TableConnect.RollBackTrans();
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

