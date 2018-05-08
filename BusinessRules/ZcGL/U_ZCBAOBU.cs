using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Web.UI.WebControls;

namespace JSJ.CJZC.Business
{
    public class U_ZCBAOBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZCBAO";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public U_ZCBAOBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ZCBAOBU()
            : this(Util.GetDefaultConnect())
        {

        }
        public CommTable TabCommand
        {
            get
            {
                return this.tabCommand;
            }
        }
        #endregion

        #region 业务方法
        //得到资产包的查询结果
        public DataSet GetZCBAOInfo(string Bname)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (Bname != null && Bname != "")
            {
                list1.Add(new SearchField("Bname", Bname, SearchOperator.包含, SearchFieldType.字符型));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        public DataSet GetZCBAOInfoByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (id != null && id != "")
            {
                list1.Add(new SearchField("ID", id, SearchOperator.等于, SearchFieldType.数值型));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        //通过包ID获取包内资产ID
        public string GetZCIDByBID(string BID)
        {
            this.tabCommand.TabName = "U_ZCBAOInfo";
            List<SearchField> list1 = new List<SearchField>();
            if (BID != null && BID != "")
            {
                list1.Add(new SearchField("BID", BID, SearchOperator.等于, SearchFieldType.数值型));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            string ids = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        ids = ds1.Tables[0].Rows[i]["ZCID"].ToString().Trim();
                    }
                    else
                    {
                        ids = ids + "," + ds1.Tables[0].Rows[i]["ZCID"].ToString().Trim();
                    }
                }
            }
            this.tabCommand.TabName = TabName;
            return ids;
        }


        //改变资产包内资产状态
        public void UpdateZcstatus(string bid,string kind,string wz)
        {
            string ids = this.GetZCIDByBID(bid);
            string[] str = ids.Split(',');
            this.tabCommand.TabName = "U_ZC";
            for (int i = 0; i < str.Length; i++)
            {
                //更改资产的最新状态
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", str[i], SearchFieldType.数值型));
                DataSet ds = this.tabCommand.SearchData("id,status", list1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string status1 = ds.Tables[0].Rows[0]["status"].ToString();
                    if (wz == "0")
                    {
                        if (kind.CompareTo(status1) > 0)
                        {
                            ds.Tables[0].Rows[0]["status"] = kind;
                        }
                    }
                    else
                    {
                        ds.Tables[0].Rows[0]["status"] = kind;
                    }
                    this.tabCommand.Update(ds);
                }
                
            }
            this.tabCommand.TabName = TabName;
        }

        public void InsertData(Hashtable ht)
        {
            this.tabCommand.InsertData(ht);
        }

        //更新资产包信息
        public bool UpdateZcBaoInfo(string id, Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                this.TabCommand.EditQuickData(list1, ht);


                //同时更新资产处置表的的
                if (ht["Bzeren"] != null)
                {
                    String zeren = ht["Bzeren"].ToString();
                    U_UserNameBU un1 = new U_UserNameBU();
                    string Depart = un1.GetDepartInfo(zeren);

                    if (String.IsNullOrEmpty(zeren) == false && String.IsNullOrEmpty(Depart) == false)
                    {
                        String sql1 = "update u_zc2 set depart='" + Depart + "' ,zeren='" + zeren + "' where zcbid in (" + id + ")";
                        this.tabCommand.TableComm.ExecuteNoQuery(sql1);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        ////更新资产包内的资产信息
        //public bool UpdateZcInfofromZcbao(Hashtable ht,string bid)
        //{
        //    string ids = this.GetZCIDByBID(bid);
        //    string[] str = ids.Split(',');
        //    this.tabCommand.TabName = "";
        //    for (int i = 0; i < str.Length; i++)
        //    { 
                
        //    }
        //}
        //更新资产包信息
        public bool UpdateZcBaoInfoTrans(string id, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                this.TabCommand.EditQuickData(list1, ht);
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("BID", id, SearchFieldType.数值型));
                DataSet ds2 = this.tabCommand.SearchData("*", list2);
                string ids = "";
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            ids = ds2.Tables[0].Rows[i]["ZCID"].ToString();
                        }
                        else
                        {
                            ids = ids + "," + ds2.Tables[0].Rows[i]["ZCID"].ToString();
                        }
                    }
                }
                this.tabCommand.TabName = "U_ZC";
                List<SearchField> list3 = new List<SearchField>();
                list3.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
                DataSet ds3 = this.TabCommand.SearchData("id,bstatus", list3);
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    ds3.Tables[0].Rows[i]["bstatus"] = ht["Bname"].ToString();
                }
                this.tabCommand.Update(ds3);
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

        //将资产打入新包
        public bool SetNewZcBao(string ids, Hashtable ht)
        {
            this.TabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.InsertData(ht);
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("Bname", ht["Bname"].ToString(), SearchFieldType.字符型));
                Hashtable ht1 = this.tabCommand.SearchData(list1);
                this.tabCommand.TabName = "U_ZC";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
                DataSet ds1 = this.TabCommand.SearchData("id,bstatus", list2);
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    ds1.Tables[0].Rows[i]["bstatus"] = ht1["Bname"].ToString();
                }
                this.tabCommand.Update(ds1);
                this.tabCommand.TabName = "U_ZCBAOInfo";
                Hashtable ht2 = new Hashtable();
                ht2["BID"] = ht1["ID"];
                string[] str = ids.Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    ht2.Add("ZCID", str[i]);
                    this.tabCommand.InsertData(ht2);
                }
                this.tabCommand.TabName = TabName;
                this.TabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }

        }

        //功能：获得资产包的信息
        public void SetBstatus(ListControl chk1, string blankValue)
        {
            DataSet ds1 = this.tabCommand.SearchData("Bname");
            string temp = "";

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {
                    temp = ds1.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    temp = temp + "," + ds1.Tables[0].Rows[i][0].ToString();
                }
            }

            if (temp != null)
            {
                string[] arr = temp.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    ListItem list0 = new ListItem(arr[i], arr[i]);
                    chk1.Items.Add(list0);
                }
            }

            if (blankValue != null && blankValue != "")
            {
                ListItem list0 = new ListItem(blankValue, "");
                chk1.Items.Insert(0, list0);
            }
        }

        //剥离资产
        public void DelZCFromZcBao(string zcid)
        {
            this.TabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "U_ZC";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id",zcid,SearchFieldType.数值型));
                DataSet ds = this.tabCommand.SearchData("id,bstatus", list1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0]["bstatus"] = DBNull.Value;
                }
                this.tabCommand.Update(ds);
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("zcid",zcid,SearchFieldType.数值型));
                this.tabCommand.DeleteData(list2);
                this.TabCommand.TableConnect.CommitTrans();
            }
            catch
            {
                this.TabCommand.TableConnect.RollBackTrans();
            }
        }

        //得到资产包的查询结果
        public DataSet GetSearchResult(string Bname)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (Bname != "" && Bname != null)
            {
                list1.Add(new SearchField("Bname", Bname, SearchOperator.包含, SearchFieldType.字符型));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }
        //得到资产包的查询结果
        public DataSet GetSearchResult1(string Bname,string Bzeren)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (Bname != "" && Bname != null)
            {
                list1.Add(new SearchField("Bname", Bname, SearchOperator.包含, SearchFieldType.字符型));
            }
            if (Bzeren != "" && Bzeren != null)
            {
                list1.Add(new SearchField("Bzeren", Bzeren, SearchOperator.包含, SearchFieldType.字符型));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }


        //得到我负责资产包的查询结果
        public DataSet GetSearchResult2(string Bname,string bzeren)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (Bname != "" && Bname != null)
            {
                list1.Add(new SearchField("Bname", Bname, SearchOperator.包含, SearchFieldType.字符型));
            }
            list1.Add(new SearchField("Bzeren",bzeren,SearchFieldType.字符型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }

        //得到我负责资产包的查询结果（协办）
        public DataSet GetZcBaoSearchResult1(string Bname, string bzeren)
        {
            List<SearchField> condition = new List<SearchField>();
            if (Bname != "" && Bname != null)
            {
                condition.Add(new SearchField("Bname", Bname, SearchOperator.包含, SearchFieldType.字符型));
            }
            condition.Add(new SearchField(String.Format("(zeren1='{0}' or zeren2='{0}')", bzeren),"", SearchOperator.用户定义));


            String sql = "select * from ZcBaoView3";
            DataSet ds1 = null;
            CommTable comm = new CommTable();
            if (condition != null && condition.Count > 0)
            {
                String conditionStr = SearchField.GetSearchCondition(condition);
                if (String.IsNullOrEmpty(conditionStr) == false)
                {
                    sql = sql + " where  " + conditionStr;
                }
            }

            ds1 = comm.TableComm.SearchData(sql);
            comm.Close();
            return ds1;
        }

        //得到我负责资产包的查询结果
        public DataSet GetZcBaoSearchResult2(string Bname, string bzeren)
        {
            List<SearchField> condition = new List<SearchField>();
            if (Bname != "" && Bname != null)
            {
                condition.Add(new SearchField("Bname", Bname, SearchOperator.包含, SearchFieldType.字符型));
            }
            condition.Add(new SearchField("zeren", bzeren, SearchOperator.集合,SearchFieldType.字符型));


            String sql = "select * from ZcBaoView3";
            DataSet ds1 = null;
            CommTable comm = new CommTable();
            if (condition != null && condition.Count > 0)
            {
                String conditionStr = SearchField.GetSearchCondition(condition);
                if (String.IsNullOrEmpty(conditionStr) == false)
                {
                    sql = sql + " where  " + conditionStr;
                }
            }

            ds1 = comm.TableComm.SearchData(sql);
            comm.Close();
            return ds1;
        }


        //得到资产包的详细信息
        public DataSet GetDetailByID(string id, string fields)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "ZCBAOView";
            DataSet ds = this.TabCommand.SearchData(fields, list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //得到我待审批（kind=0) 或审批过的资产（kind=1)
        public DataSet GetMyShenPiZcB(string zeren, string bname, int kind)
        {
            string sql = "";
            if (kind == 0)
            {
                sql = "select *,ZcBNoShenPI.time0 as SPTime from ZCBAOView ,ZcBNoShenPI where ZCBAOView.id = ZcBNoShenPI.BID  and  ZcBNoShenPI.zeren='" + zeren + "' ";
            }
            else
            {
                sql = "select *,ZcBShenPI.time1 as SPTime from ZCBAOView ,ZcBShenPI where ZCBAOView.id = ZcBShenPI.BID  and  ZcBShenPI.zeren='" + zeren + "'";
            }

            if (bname != null && bname.Trim() != "")
            {
                bname = bname.Replace("'", "");
                sql = sql + " and Bname like '%" + bname + "%' ";
            }

            return this.tabCommand.TableComm.SearchData(sql);
        }
        
        //得到包内资产的本金合计
        public Hashtable GetZcBbjANDlx(string bid)
        {
            string ids = this.GetZCIDByBID(bid);
            string[] str = ids.Split(',');
            double bbjhj = 0;
            double blxhj = 0;
            U_ZCBU zc1 = new U_ZCBU();
            for (int i = 0; i < str.Length; i++)
            {
                DataSet ds = zc1.GetDetailByID(str[i]);
                if (ds.Tables[0].Rows[0]["bj"] != null && ds.Tables[0].Rows[0]["bj"].ToString() != "")
                {
                    string m = ds.Tables[0].Rows[0]["bj"].ToString();
                    bbjhj = bbjhj + Convert.ToDouble(m.Trim());
                }
                if (ds.Tables[0].Rows[0]["bxhj"] != null && ds.Tables[0].Rows[0]["bxhj"].ToString() != "")
                {
                    string n = ds.Tables[0].Rows[0]["bxhj"].ToString();
                    blxhj = blxhj + Convert.ToDouble(n.Trim());
                }
                ds.Dispose();
            }
            Hashtable ht = new Hashtable();
            ht["bbjhj"] = bbjhj.ToString();
            ht["blxhj"] = blxhj.ToString();
            return ht;
        }

        //得到包内资产的本金合计
        public Hashtable GetZcBbjANDlx1(string bid)
        {
            string ids = this.GetZCIDByBID(bid);
            string[] str = ids.Split(',');
            double bbjhj = 0;
            double blxhj = 0;
            double bbjhj1 = 0;
            double blxhj1 = 0;
            U_ZCBU zc1 = new U_ZCBU();
            for (int i = 0; i < str.Length; i++)
            {
                DataSet ds = zc1.GetDetailByID(str[i]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["huobi"].ToString() == "人民币")
                    {
                        if (ds.Tables[0].Rows[0]["bj"] != null && ds.Tables[0].Rows[0]["bj"].ToString() != "")
                        {
                            string m = ds.Tables[0].Rows[0]["bj"].ToString();
                            bbjhj = bbjhj + Convert.ToDouble(m.Trim());
                        }
                        if (ds.Tables[0].Rows[0]["bxhj"] != null && ds.Tables[0].Rows[0]["bxhj"].ToString() != "")
                        {
                            string n = ds.Tables[0].Rows[0]["bxhj"].ToString();
                            blxhj = blxhj + Convert.ToDouble(n.Trim());
                        }
                    }
                    if (ds.Tables[0].Rows[0]["huobi"].ToString() == "美元")
                    {
                        if (ds.Tables[0].Rows[0]["bj"] != null && ds.Tables[0].Rows[0]["bj"].ToString() != "")
                        {
                            string m = ds.Tables[0].Rows[0]["bj"].ToString();
                            bbjhj1 = bbjhj1 + Convert.ToDouble(m.Trim());
                        }
                        if (ds.Tables[0].Rows[0]["bxhj"] != null && ds.Tables[0].Rows[0]["bxhj"].ToString() != "")
                        {
                            string n = ds.Tables[0].Rows[0]["bxhj"].ToString();
                            blxhj1 = blxhj1 + Convert.ToDouble(n.Trim());
                        }
                    }
                }
                ds.Dispose();
            }
            Hashtable ht = new Hashtable();
            ht["bbxh1"] = double.Parse(bbjhj.ToString()) + double.Parse(blxhj.ToString());
            ht["bbxh2"] = double.Parse(bbjhj1.ToString()) + double.Parse(blxhj1.ToString());
            return ht;
        }
        //得到资产的详细资料3
        public DataSet GetDetail(List<SearchField> list1, string fields)
        {
            this.tabCommand.TabName = "ZCBAOView";
            DataSet ds = this.TabCommand.SearchData(fields, list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

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
