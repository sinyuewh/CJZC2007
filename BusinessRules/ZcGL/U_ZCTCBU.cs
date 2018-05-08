using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
using System.Web;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// 调查记录
    /// </summary>
    public class U_ZCTCBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZCTC";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public U_ZCTCBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ZCTCBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法

        public DataSet GetZXList(string kind, string ParentID)
        {
            this.tabCommand.TabName = "U_ZCTC";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", ParentID, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", kind));
            DataSet ds = this.tabCommand.SearchData("*,left(remark,200) as remark1", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //插入新数据
        public void InsertData(Hashtable ht)
        {
            SinConnect myconn = this.tabCommand.TableConnect;
            myconn.BeginTrans();
            try
            {
                this.tabCommand.InsertData(ht);
                ///////////////////////////////////////////
                if (ht["bkind"].ToString() == "0")
                {
                    this.tabCommand.TabName = "U_ZC";
                    List<SearchField> list1 = new List<SearchField>();
                    list1.Add(new SearchField("id", ht["zcid"].ToString(), SearchFieldType.数值型));
                    DataSet ds1 = this.tabCommand.SearchData("status,id", list1);
                    string status1 = "00";
                    if (ds1.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        status1 = ds1.Tables[0].Rows[0][0].ToString();
                    }

                    string status2 = ht["kind"].ToString();
                    if (status2.CompareTo(status1) > 0 || Int32.Parse(status2) > 20)
                    {
                        ds1.Tables[0].Rows[0]["status"] = status2;
                        this.tabCommand.Update(ds1);
                    }
                    this.tabCommand.TabName = TabName;
                }
                else
                {
                    this.tabCommand.TabName = "U_ZCBAO";
                    List<SearchField> list1 = new List<SearchField>();
                    list1.Add(new SearchField("id", ht["zcid"].ToString(), SearchFieldType.数值型));
                    DataSet ds1 = this.tabCommand.SearchData("Bstatus,id", list1);
                    string status1 = "00";
                    if (ds1.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        status1 = ds1.Tables[0].Rows[0][0].ToString();
                    }

                    string status2 = ht["kind"].ToString();
                    if (status2.CompareTo(status1) > 0 || Int32.Parse(status2) > 20)
                    {
                        ds1.Tables[0].Rows[0]["Bstatus"] = status2;
                        this.tabCommand.Update(ds1);
                    }
                    this.tabCommand.TabName = TabName;
                }
                /////////////////////////////////////////
                myconn.CommitTrans();
            }
            catch (Exception err1)
            {
                myconn.RollBackTrans();
                throw err1;
            }
        }
        
        //得到数据列表
        public DataSet GetTCList(string kind, string ParentID)
        {
            this.tabCommand.TabName = "U_ZCTCBUView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", ParentID, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", kind));
            list1.Add(new SearchField("Bkind", "0",SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("*,left(remark,200) as remark1", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        public DataSet GetHankTCList(string kind, string ParentID)
        {
            this.tabCommand.TabName = "U_ZCTCBUView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", ParentID, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", kind));
            list1.Add(new SearchField("Bkind", "0", SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("*,left(remark,200) as remark01,left(remark2,200) as remark02", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //得到数据列表
        public DataSet GetTCList1(string kind, string ParentID)
        {
            this.tabCommand.TabName = "U_ZCTCBUView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", ParentID, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", kind));
            list1.Add(new SearchField("Bkind", "1", SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("*,left(remark,200) as remark1", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        // 删除调查记录（不允许删除包含的附件）
        public void DelteTC(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZCFiles";
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                ////////////////////////////////////////////////
                this.tabCommand.TabName = TabName;
                list1.Clear();
                list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("*", list1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    Util.DelDataSetData(ds1);
                    this.tabCommand.Update(ds1);
                }
                //////////////////////////////////////////////////////
            }
            else
            {
                throw new Exception("错误：不能直接删除含有附件的数据，请先删除附件！");
            }
        }

        // 删除调查记录（不允许删除包含的附件）
        public void DelteTC1(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("tcid", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZCFiles";
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                ////////////////////////////////////////////////
                this.tabCommand.TabName = TabName;
                list1.Clear();
                list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("*", list1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    Util.DelDataSetData(ds1);
                    this.tabCommand.Update(ds1);
                }
                //////////////////////////////////////////////////////
            }
            else
            {
                throw new Exception("错误：不能直接删除含有附件的数据，请先删除附件！");
            }
        }

        //得到数据详细
        public DataSet GetDetailByID(string id)
        {
            SearchField search1 = new SearchField("id", id, SearchFieldType.数值型);
            DataSet ds = this.tabCommand.SearchData("*", new SearchField[] { search1 });
            return ds;
        }

        //更新数据
        public void EditTc(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);            
            foreach (DictionaryEntry item in ht)
            {
                ds1.Tables[0].Rows[0][item.Key.ToString()]=item.Value;
            }
            this.tabCommand.Update(ds1);
        }

        //更新状态
        public void EditTcForstatus(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            ds1.Tables[0].Rows[0]["status"] = "作废";
            this.tabCommand.Update(ds1);
        }

        //得到状态
        public string GetStatusByID(string id)
        {
            SearchField search1 = new SearchField("id", id, SearchFieldType.数值型);
            DataSet ds = this.tabCommand.SearchData("id,status", new SearchField[] { search1 });
            string status = "";
            if (ds.Tables[0].Rows[0]["status"] != null)
            {
                status = ds.Tables[0].Rows[0]["status"].ToString();
            }
            return status;
        }

        //将信息复制到所有的资产
        public bool CopyZcTctoZc(string bid,string id,string wz)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("bid",bid,SearchFieldType.数值型));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                string ids = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            ids = ds.Tables[0].Rows[i]["zcid"].ToString();
                        }
                        else
                        {
                            ids = ids + "," + ds.Tables[0].Rows[i]["zcid"].ToString();
                        }
                    }
                }
                this.tabCommand.TabName = TabName;
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("id", id, SearchFieldType.数值型));
                Hashtable ht = this.tabCommand.SearchData(list2);
                ht.Remove("id");
                if (ids != "")
                {
                    string[] str = ids.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        U_ZCBU zc1 = new U_ZCBU();
                        ht["zeren"] = zc1.GetZerenByZCID(str[i]);
                        ht["zcid"] = str[i];
                        ht["bkind"] = "0";
                        this.tabCommand.InsertData(ht);
                    }
                }



                U_ZCBAOBU zcb1 = new U_ZCBAOBU();
                zcb1.UpdateZcstatus(bid, ht["kind"].ToString(), wz);
                zcb1.Close();

                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch(Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        public DataSet GetJZDCFromZCTC(string begintime,string endtime,string depart)
        {
            string sql1 = "select zeren from U_ZCTCBUView";
            if (depart != "" && depart != null)
            {
                sql1 = sql1 + " where depart='" + depart + "'";
            }
            sql1 = sql1 + " group by zeren";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string sql2 = "select max(id) as mid,zcid,zeren,kind from U_ZCTCBUView where bkind = '0'";
            if (depart != "" && depart != null)
            {
                sql2 = sql2 + " and depart='" + depart + "'";
            }
            if (begintime != "" && begintime != null)
            {
                sql2 = sql2 + " and time0 > '" + begintime +"'";
            }
            if (endtime != "" && endtime != null)
            {
                sql2 = sql2 + " and time0 < '" + endtime + "'";
            }
            sql2 = sql2 + " group by zeren,kind,zcid";
            DataSet ds2 = this.tabCommand.TableComm.SearchData(sql2);
            DataSet ds = new DataSet();
            DataTable tab1 = new DataTable();
            tab1.Columns.Add("zeren");
            tab1.Columns.Add("depart");
            tab1.Columns.Add("count1");
            tab1.Columns.Add("count2");
            tab1.Columns.Add("count3");
            tab1.Columns.Add("count4");
            tab1.Columns.Add("count5");
            tab1.Columns.Add("count6");
            tab1.Columns.Add("count7");
            tab1.Columns.Add("count8");
            tab1.Columns.Add("count9");
            tab1.Columns.Add("count10");
            tab1.Columns.Add("count11");
            tab1.Columns.Add("count12");
            tab1.Columns.Add("count13");
            U_UserNameBU user1 = new U_UserNameBU();
            DataRow dr=null;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr = tab1.NewRow();
                
                dr["zeren"] =ds1.Tables[0].Rows[i][0].ToString();
                dr["count1"] = "0";
                dr["count2"] = "0";
                dr["count3"] = "0";
                dr["count4"] = "0";
                dr["count6"] = "0";
                dr["count7"] = "0";
                dr["count8"] = "0";
                dr["count9"] = "0";
                dr["count10"] = "0";
                dr["count11"] = "0";
                dr["count12"] = "0";
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    if (ds2.Tables[0].Rows[j]["zeren"].ToString() == ds1.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "01")
                        {
                            dr["count1"] = Int32.Parse(dr["count1"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "02")
                        {
                            dr["count2"] = Int32.Parse(dr["count2"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "03")
                        {
                            dr["count3"] = Int32.Parse(dr["count3"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "04")
                        {
                            dr["count4"] = Int32.Parse(dr["count4"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "21")
                        {
                            dr["count6"] = Int32.Parse(dr["count6"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "22")
                        {
                            dr["count7"] = Int32.Parse(dr["count7"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "23")
                        {
                            dr["count8"] = Int32.Parse(dr["count8"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "24")
                        {
                            dr["count9"] = Int32.Parse(dr["count9"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "25")
                        {
                            dr["count10"] = Int32.Parse(dr["count10"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "26")
                        {
                            dr["count11"] = Int32.Parse(dr["count11"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "27")
                        {
                            dr["count12"] = Int32.Parse(dr["count12"].ToString()) + 1;
                        }
                    }
                }
                dr["count5"] = Int32.Parse(dr["count1"].ToString()) + Int32.Parse(dr["count2"].ToString()) + Int32.Parse(dr["count3"].ToString()) + Int32.Parse(dr["count4"].ToString());
                dr["count13"] = Int32.Parse(dr["count6"].ToString()) + Int32.Parse(dr["count7"].ToString()) + Int32.Parse(dr["count8"].ToString()) + Int32.Parse(dr["count9"].ToString()) + Int32.Parse(dr["count10"].ToString()) + Int32.Parse(dr["count11"].ToString()) + Int32.Parse(dr["count12"].ToString());
                dr["depart"] = user1.GetDepart1(ds1.Tables[0].Rows[i][0].ToString());
                tab1.Rows.Add(dr);
            }
            user1.Close();
            ds.Tables.Add(tab1);
            return ds;
        }

        public DataSet GetJZDCByDepart()
        {
            string sql1 = "select depart from U_ZCTCBUView group by depart,dnum order by dnum";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            return ds1;
        }

        public DataSet GetFASP(string begintime, string endtime, string depart)
        {
            string sql1 = "select ZCzeren from ZCSPStatView";
            if (depart != "" && depart != null)
            {
                sql1 = sql1 + " where depart='" + depart + "'";
            }
            sql1 = sql1 + " group by ZCzeren";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            string sql2 = "select max(id) as mid,zcid,ZCzeren,kind from ZCSPStatView where 1=1";
            if (depart != "" && depart != null)
            {
                sql2 = sql2 + " and depart='" + depart + "'";
            }
            if (begintime != "" && begintime != null)
            {
                sql2 = sql2 + " and time0 > '" + begintime + "'";
            }
            if (endtime != "" && endtime != null)
            {
                sql2 = sql2 + " and time0 < '" + endtime + "'";
            }
            sql2 = sql2 + " group by ZCzeren,kind,zcid";
            DataSet ds2 = this.tabCommand.TableComm.SearchData(sql2);
            DataSet ds = new DataSet();
            DataTable tab1 = new DataTable();
            tab1.Columns.Add("zeren");
            tab1.Columns.Add("depart");
            tab1.Columns.Add("count1");
            tab1.Columns.Add("count2");
            tab1.Columns.Add("count3");
            tab1.Columns.Add("count4");
            tab1.Columns.Add("count5");
            tab1.Columns.Add("count6");
            tab1.Columns.Add("count7");
            U_UserNameBU user1 = new U_UserNameBU();
            DataRow dr = null;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr = tab1.NewRow();

                dr["zeren"] = ds1.Tables[0].Rows[i][0].ToString();
                dr["count1"] = "0";
                dr["count2"] = "0";
                dr["count3"] = "0";
                dr["count4"] = "0";
                dr["count5"] = "0";
                dr["count6"] = "0";
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    if (ds2.Tables[0].Rows[j]["ZCzeren"].ToString() == ds1.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "11")
                        {
                            dr["count1"] = Int32.Parse(dr["count1"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "12")
                        {
                            dr["count2"] = Int32.Parse(dr["count2"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "13")
                        {
                            dr["count3"] = Int32.Parse(dr["count3"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "14")
                        {
                            dr["count4"] = Int32.Parse(dr["count4"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "15")
                        {
                            dr["count5"] = Int32.Parse(dr["count5"].ToString()) + 1;
                        }
                        if (ds2.Tables[0].Rows[j]["kind"].ToString() == "16")
                        {
                            dr["count6"] = Int32.Parse(dr["count6"].ToString()) + 1;
                        }
                    }
                }
                dr["count7"] = Int32.Parse(dr["count1"].ToString()) + Int32.Parse(dr["count2"].ToString()) + Int32.Parse(dr["count3"].ToString()) + Int32.Parse(dr["count4"].ToString()) + Int32.Parse(dr["count5"].ToString()) + Int32.Parse(dr["count6"].ToString());
                dr["depart"] = user1.GetDepart1(ds1.Tables[0].Rows[i][0].ToString());
                tab1.Rows.Add(dr);
            }
            user1.Close();
            ds.Tables.Add(tab1);
            return ds;
        }

        public DataSet GetFASPByDepart()
        {
            string sql1 = "select depart from ZCSPStatView group by depart,dnum order by dnum";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            return ds1;
        }
        #endregion

        #region 尽职调查统计（编码：金寿吉）
        //按年统计
        public DataSet GetZcTJData(int byear,bool check1)
        {
            DateTime dt1 = DateTime.Parse(byear + "-1-1");
            DateTime dt2 = DateTime.Parse(byear + "-12-31");
            return this.GetZcTJData(dt1, dt2,check1);
        }

        //按月统计
        public DataSet GetZcTJData(int byear, int month, bool check1)
        {
            DateTime dt1 = DateTime.Parse(byear + "-"+month+"-1");
            if (month == 12)
            {
                byear = byear + 1;
                month = 1;
            }
            else
            {
                month++;
            }
            DateTime dt2 = DateTime.Parse((DateTime.Parse(byear + "-"+month+"-1").AddDays(-1).ToString("yyyy-MM-dd")));
            return this.GetZcTJData(dt1, dt2,check1);
        }

        //按季度统计
        public DataSet GetZcTJData(int byear, int month1, int month2, bool check1)
        {
            DateTime dt1 = DateTime.Parse(byear + "-" + month1 + "-1");
            if (month2 == 12)
            {
                byear = byear + 1;
                month2 = 1;
            }
            else
            {
                month2++;
            }
            DateTime dt2 = DateTime.Parse((DateTime.Parse(byear + "-"+month2+"-1").AddDays(-1).ToString("yyyy-MM-dd")));
            return this.GetZcTJData(dt1, dt2,check1);
        }

        //按时间段统计
        public DataSet GetZcTJData(DateTime dt1, DateTime dt2, bool check1)
        {
            string t1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
            string t2 = dt2.ToString("yyyy-MM-dd")+" 23:59:59";
            string sql = @"select distinct u_username.num as znum,zeren,u_username.depart,zcid,
                         kind,u_depart.num as dnum
                         from U_ZCTC inner join
                         U_UserName on U_zctc.zeren=u_username.sname
                         inner join u_depart on u_username.depart=u_depart.depart
                         where ( status is null or status <>'作废') and bkind='0' and U_ZCTC.kind<'05' ";

            if (check1 == false)
            {
                sql = sql.Replace("distinct", "");
            }

            if (dt1 != default(DateTime))
            {
                sql = sql + " and time0>='" + t1+"'";
            }
            if (dt2 != default(DateTime))
            {
                sql = sql + "and time0<='"+t2+"'";
            }

            sql = sql + " order by dnum,znum,kind ";
            HttpContext.Current.Items["time0"] = dt1;
            HttpContext.Current.Items["time1"] = dt2;
            return this.tabCommand.TableComm.SearchData(sql);
        }

        //按时间段统计
        public DataSet GetZcTJData(DateTime dt1, DateTime dt2)
        {
            string t1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
            string t2 = dt2.ToString("yyyy-MM-dd") + " 23:59:59";
            string sql = @"select distinct u_username.num as znum,zeren,u_username.depart,zcid,
                         kind,u_depart.num as dnum
                         from U_ZCTC inner join
                         U_UserName on U_zctc.zeren=u_username.sname
                         inner join u_depart on u_username.depart=u_depart.depart
                         where ( status is null or status <>'作废') and bkind='0' and U_ZCTC.kind>'20' ";

            
            if (dt1 != default(DateTime))
            {
                sql = sql + " and time0>='" + t1 + "'";
            }
            if (dt2 != default(DateTime))
            {
                sql = sql + "and time0<='" + t2 + "'";
            }

            sql = sql + " order by dnum,znum,kind ";
            HttpContext.Current.Items["time0"] = dt1;
            HttpContext.Current.Items["time1"] = dt2;
            return this.tabCommand.TableComm.SearchData(sql);
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

