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
    /// �û�ҵ������
    /// </summary>
    public class CW_OutStockBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "CW_OutStock";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
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

        #region ҵ�񷽷�
        //�õ����ⵥ��ϸ
        public Hashtable GetObjectByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            return this.tabCommand.SearchData(list1);
        }

        //�õ���ⵥ��ϸ
        public DataSet GetOutStockBill(string bill)
        {
            this.tabCommand.TabName = "CW_OutStockBill";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill));
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //��˳��ⵥ��
        public bool CheckBill(string id, string UserName)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                DataSet ds = this.tabCommand.SearchData("*", list1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0]["checkmen"] = UserName;
                    ds.Tables[0].Rows[0]["checktime"] = DateTime.Now.ToString();
                    this.tabCommand.Update(ds);

                    //�޸��ʲ��еĿ������
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
                        list1.Add(new SearchField("id", stockid,SearchOperator.����, SearchFieldType.��ֵ��));
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

       //�õ����ʵĵ��ݱ��
        public string GetBillNum()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("year(billtime)", DateTime.Now.Year.ToString() + "", SearchFieldType.��ֵ��));
            list1.Add(new SearchField("month(billtime)", DateTime.Now.Month.ToString() + "", SearchFieldType.��ֵ��));
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

        //ͬʱ���ӳ��ⵥ�ݺ͵�����ϸ
        public bool InsertData(Hashtable ht, DataSet ChildDs)
        {
            string[] arr1 = new string[] { "bill","gkind","gname", "ggxh", "num", "price","remark", "dw", "stockid" };
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //���ӵ���
                this.tabCommand.InsertData(ht);

                //���ӵ�����ϸ
                this.tabCommand.TabName = "CW_OutStockBill";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", "-1", SearchFieldType.��ֵ��));
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
                list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string id = ds.Tables[0].Rows[i]["id"].ToString();
                        List<SearchField> list2 = new List<SearchField>();
                        list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
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

        #region ˽�з���
        #endregion

        #region IDisposable ��Ա
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

