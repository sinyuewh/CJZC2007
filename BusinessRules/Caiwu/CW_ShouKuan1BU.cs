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
    public class CW_ShouKuan1BU : IDisposable
    {
        #region 属性定义
        private const string TabName = "CW_ShouKuan1";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public CW_ShouKuan1BU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CW_ShouKuan1BU()
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
        public bool InsertData(Hashtable ht)
        {
            this.tabCommand.InsertData(ht);
            return true;
        }

        //得到没有审核的单据DataSet（不限于收款）
        public DataSet GetBillList(string kind, List<SearchField> list1, bool check)
        {
            string billkind = null;
            string EditASP = null;
            string viewName = null;
            switch (kind)
            {
                case "0":
                    billkind = "收";
                    EditASP = "EditShouKuan1.aspx";
                    viewName = "CW_ShouKuan1View";
                    break;
                case "1":
                    billkind = "付";
                    EditASP = "EditPay1.aspx";
                    viewName = "CW_Pay1View";
                    break;
                default:
                    billkind = "收";
                    EditASP = "EditShouKuan1.aspx";
                    viewName = "CW_ShouKuan1View";
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
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id ");
            this.tabCommand.TabName = TabName;

            System.Type StringType;
            StringType = System.Type.GetType("System.String");

            ds1.Tables[0].Columns.Add("billkind", StringType, "'" + billkind + "'");
            ds1.Tables[0].Columns.Add("EditASP", StringType, "'" + EditASP + "'");

            return ds1;
        }


        public void DelShoukuanDJ(string id)
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


                    //更新资产包的相关数据
                    string bid = ds.Tables[0].Rows[0]["bid"].ToString();
                    list1.Clear();
                    list1.Add(new SearchField("id", bid, SearchFieldType.数值型));
                    this.tabCommand.TabName = "U_ZCBAO";
                    DataSet ds1 = this.tabCommand.SearchData("*", list1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        double bljsk = 0;
                        if (ds1.Tables[0].Rows[0]["bljsk"] != DBNull.Value)
                        {
                            bljsk = double.Parse(ds1.Tables[0].Rows[0]["bljsk"].ToString());
                        }

                        bljsk = bljsk + pbj + plx;

                        ds1.Tables[0].Rows[0]["bljsk"] = bljsk;
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
