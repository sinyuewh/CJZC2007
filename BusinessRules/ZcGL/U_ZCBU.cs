using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Web;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// 资产业务处理类
    /// </summary>
    public class U_ZCBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZC";
        private CommTable tabCommand = null;
        private string zcid = null;
        #endregion

        #region 构造函数
        public U_ZCBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ZCBU()
            : this(Util.GetDefaultConnect())
        {

        }

        public U_ZCBU(string zcid)
            : this(Util.GetDefaultConnect())
        {
            this.zcid = zcid;
        }


        public CommTable TabCommand
        {
            get
            {
                return this.tabCommand;
            }
        }


        public string ZcID
        {
            get
            {
                return this.zcid;
            }
            set
            {
                this.zcid = value;
            }
        }

        /// <summary>
        /// 设置资产的状态
        /// </summary>
        public string ZcStatus
        {
            get
            {
                string status = null;
                if (this.zcid != null)
                {
                    List<SearchField> list1 = new List<SearchField>();
                    list1.Add(new SearchField("id", this.zcid, SearchOperator.等于, SearchFieldType.数值型));
                    DataSet ds = this.tabCommand.SearchData("status", list1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        status = ds.Tables[0].Rows[0][0] as string;
                    }

                }
                return status;
            }
            set
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", this.zcid, SearchOperator.等于, SearchFieldType.数值型));
                Hashtable ht = new Hashtable();
                ht["status"] = value;
                this.tabCommand.EditQuickData(list1, ht);
            }
        }


        #endregion

        #region 业务方法

        #region  资产处置申报表的处理
        //得到当前的资产处置申报表
        public Hashtable GetCurrentZcCZbyID(string zcid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "ZCView";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("id,danwei,depart,zeren,status as zcstatus ,statusText", list1);
                Hashtable ht = new Hashtable();
                for (int i = 0; i < ds1.Tables[0].Columns.Count; i++)
                {
                    if (ds1.Tables[0].Rows[0][i] != DBNull.Value && ds1.Tables[0].Rows[0][i].ToString().Trim() != "")
                    {
                        ht[ds1.Tables[0].Columns[i].ColumnName] = ds1.Tables[0].Rows[0][i].ToString();
                    }
                    else
                    {
                        ht[ds1.Tables[0].Columns[i]] = "";
                    }
                }
                ds1.Dispose();


                list1.Clear();
                this.tabCommand.TabName = "U_Zc2";
                list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));

                DataSet ds2 = this.tabCommand.SearchData("*,id as zcczid", list1, "ID desc");
                if (ds2.Tables[0].Rows.Count <= 0)
                {
                    DataRow dr = ds2.Tables[0].NewRow();
                    dr["status"] = ((int)SP.开始审批).ToString().PadLeft(2, '0');
                    dr["zcid"] = zcid;
                    ds2.Tables[0].Rows.Add(dr);
                    this.tabCommand.Update(ds2);    //没有则增加一条数据
                    ds2.AcceptChanges();

                    ds2 = this.tabCommand.SearchData("*,id as zcczid", list1, "ID desc");
                }

                for (int i = 0; i < ds2.Tables[0].Columns.Count; i++)
                {
                    if (ds2.Tables[0].Rows[0][i] != DBNull.Value)
                    {
                        ht[ds2.Tables[0].Columns[i].ColumnName] = ds2.Tables[0].Rows[0][i].ToString();
                    }
                    else
                    {
                        ht[ds2.Tables[0].Columns[i].ColumnName] = "";
                    }
                }
                ds2.Dispose();
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
                return ht;
            }
            catch
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return null;
            }
        }

        //得到当前的资产处置申报表
        public Hashtable GetCurrentZcCZbyID1(string zcid)
        {
            try
            {
                this.tabCommand.TabName = "ZCView";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("id,danwei,depart,zeren,status as zcstatus ,statusText", list1);
                Hashtable ht = new Hashtable();
                for (int i = 0; i < ds1.Tables[0].Columns.Count; i++)
                {
                    if (ds1.Tables[0].Rows[0][i] != DBNull.Value && ds1.Tables[0].Rows[0][i].ToString().Trim() != "")
                    {
                        ht[ds1.Tables[0].Columns[i].ColumnName] = ds1.Tables[0].Rows[0][i].ToString();
                    }
                    else
                    {
                        ht[ds1.Tables[0].Columns[i]] = "";
                    }
                }
                ds1.Dispose();


                list1.Clear();
                this.tabCommand.TabName = "U_Zc2";
                list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));

                DataSet ds2 = this.tabCommand.SearchData("*,id as zcczid", list1, "ID desc");
                if (ds2.Tables[0].Rows.Count <= 0)
                {
                    DataRow dr = ds2.Tables[0].NewRow();
                    dr["status"] = ((int)SP.开始审批).ToString().PadLeft(2, '0');
                    dr["zcid"] = zcid;
                    ds2.Tables[0].Rows.Add(dr);
                    this.tabCommand.Update(ds2);    //没有则增加一条数据
                    ds2.AcceptChanges();

                    ds2 = this.tabCommand.SearchData("*,id as zcczid", list1, "ID desc");
                }

                for (int i = 0; i < ds2.Tables[0].Columns.Count; i++)
                {
                    if (ds2.Tables[0].Rows[0][i] != DBNull.Value)
                    {
                        ht[ds2.Tables[0].Columns[i].ColumnName] = ds2.Tables[0].Rows[0][i].ToString();
                    }
                    else
                    {
                        ht[ds2.Tables[0].Columns[i].ColumnName] = "";
                    }
                }
                ds2.Dispose();
                this.tabCommand.TabName = TabName;
                return ht;
            }
            catch
            {
                return null;
            }
        }

        //得到当前的资产处置申报表
        public Hashtable GetCurrentZcBCZbyID(string zcid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "ZCBAOView";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("id,bname,depart,bzeren,bstatus as zcstatus ,statusText", list1);
                Hashtable ht = new Hashtable();
                for (int i = 0; i < ds1.Tables[0].Columns.Count; i++)
                {
                    if (ds1.Tables[0].Rows[0][i] != DBNull.Value && ds1.Tables[0].Rows[0][i].ToString().Trim() != "")
                    {
                        ht[ds1.Tables[0].Columns[i].ColumnName] = ds1.Tables[0].Rows[0][i].ToString();
                    }
                    else
                    {
                        ht[ds1.Tables[0].Columns[i]] = "";
                    }
                }
                ds1.Dispose();


                list1.Clear();
                this.tabCommand.TabName = "U_ZCB2";
                list1.Add(new SearchField("bid", zcid, SearchFieldType.数值型));

                DataSet ds2 = this.tabCommand.SearchData("*,id as zcczid", list1, "ID desc");
                if (ds2.Tables[0].Rows.Count <= 0)
                {
                    DataRow dr = ds2.Tables[0].NewRow();
                    dr["status"] = ((int)SP.开始审批).ToString().PadLeft(2, '0');
                    dr["bid"] = zcid;
                    ds2.Tables[0].Rows.Add(dr);
                    this.tabCommand.Update(ds2);    //没有则增加一条数据
                    ds2.AcceptChanges();

                    ds2 = this.tabCommand.SearchData("*,id as zcczid", list1, "ID desc");
                }

                for (int i = 0; i < ds2.Tables[0].Columns.Count; i++)
                {
                    if (ds2.Tables[0].Rows[0][i] != DBNull.Value)
                    {
                        ht[ds2.Tables[0].Columns[i].ColumnName] = ds2.Tables[0].Rows[0][i].ToString();
                    }
                    else
                    {
                        ht[ds2.Tables[0].Columns[i].ColumnName] = "";
                    }
                }
                ds2.Dispose();
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
                return ht;
            }
            catch
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return null;
            }
        }

        //得到历史的资产处置申报表（已经通过审批的）
        public DataSet GetHistoryZcCZbyID(string zcid)
        {
            this.tabCommand.TabName = "U_ZC2";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField("", " ( status='14' or status='16' )", SearchOperator.用户定义));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        #endregion

        /// <summary>
        /// 设置用户自定义分类
        /// </summary>
        /// <param name="ids">设置的资产ID</param>
        /// <param name="skind">设置的类别 0－表示替换 1－表示追加 2－表示清除</param>
        /// <param name="userkindvalue">设置的用户自定义分类的值</param>
        public void SetUserKind(string ids, string skind, string userkindvalue)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
            DataSet ds1 = this.TabCommand.SearchData("id,userkind", list1);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (skind == "31" || skind == "32")    //清除数据的值
                {
                    ds1.Tables[0].Rows[i]["userkind"] = DBNull.Value;
                }

                if (skind == "11" || skind == "12")    //表示替换
                {
                    ds1.Tables[0].Rows[i]["userkind"] = userkindvalue;
                }

                if (skind == "21" || skind == "22")     //表示追加
                {
                    string temp = "";
                    if (ds1.Tables[0].Rows[i]["userkind"] != DBNull.Value)
                    {
                        temp = ds1.Tables[0].Rows[i]["userkind"].ToString(); //原来的值
                    }

                    if (temp != "")
                    {
                        string[] Atemp = temp.Split(',');
                        bool find1 = false;
                        for (int k = 0; k < Atemp.Length; k++)
                        {
                            if (Atemp[k].Trim() == userkindvalue)
                            {
                                find1 = true;
                                break;
                            }
                        }

                        if (find1 == false)
                        {
                            temp = temp + "," + userkindvalue;
                        }
                    }
                    else
                    {
                        temp = userkindvalue;
                    }
                    ds1.Tables[0].Rows[i]["userkind"] = temp;
                }
            }
            this.TabCommand.Update(ds1);
        }


        /// <summary>
        /// 设置资产包分类
        /// </summary>
        /// <param name="ids">设置的资产ID</param>
        /// <param name="userkindvalue">设置的资产包的值</param>
        public void SetBstatus(string ids, string Bstatusvalue)
        {
            this.TabCommand.TableConnect.BeginTrans();
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
                DataSet ds1 = this.TabCommand.SearchData("id,Bstatus", list1);
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    ds1.Tables[0].Rows[i]["Bstatus"] = Bstatusvalue;
                }
                this.TabCommand.Update(ds1);

                this.tabCommand.TabName = "U_ZCBAO";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("Bname", Bstatusvalue, SearchFieldType.字符型));
                Hashtable ht1 = this.tabCommand.SearchData(list2);

                this.tabCommand.TabName = "U_ZCBAOInfo";
                Hashtable ht2 = new Hashtable();
                ht2["bid"] = ht1["id"];
                ht2["zcid"] = null;
                string[] arr = ids.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    ht2["zcid"] = arr[i];
                    this.tabCommand.InsertData(ht2);
                }
                this.tabCommand.TabName = TabName;
                this.TabCommand.TableConnect.CommitTrans();
            }
            catch
            {
                this.TabCommand.TableConnect.RollBackTrans();
            }
        }


        //得到资产用户自定义分类列表
        public DataSet GetZcUserkingList(List<SearchField> list1, int curpage, int PageSize, out int totalRow)
        {
            DataSet ds1 = this.TabCommand.SearchData("id,num2,danwei,userkind,left(danwei,20) as danwei1", list1, "isnull(num2,'zzzzzz')", curpage, PageSize, out totalRow);
            return ds1;
        }

        //得到资产包分类列表
        public DataSet GetZcBaoList(List<SearchField> list1, int curpage, int PageSize, out int totalRow)
        {
            DataSet ds1 = this.TabCommand.SearchData("id,num2,danwei,bstatus,zeren,left(danwei,20) as danwei1", list1, null, curpage, PageSize, out totalRow);
            return ds1;
        }

        //设置资产责任人
        public bool SetZeren(string zcid, string zeren,String kind)
        {
            this.TabCommand.TableConnect.BeginTrans();
            try
            {
                //自动形成资产分配日志
                U_ZcFPLogBU fp = new U_ZcFPLogBU();
                if (kind == "0")
                {
                    fp.InsertData(zcid, zeren);
                }
                else
                {
                    fp.InsertXieGuanlLogData(zcid, zeren);
                }
                fp.Close();

                //修改资产责任人数据
                U_UserNameBU un1 = new U_UserNameBU();
                string Depart = un1.GetDepartInfo(zeren);
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", zcid, SearchOperator.集合));
                Hashtable ht = new Hashtable();
                if (kind == "0")
                {
                    ht["zeren"] = zeren;
                    ht["Depart"] = Depart;
                }
                else if(kind=="1")
                {
                    ht["zeren1"] = zeren;
                }
                else if (kind == "2")
                {
                    ht["zeren2"] = zeren;
                }
                this.tabCommand.EditQuickData(list1, ht);
               
                
                //修改其他的信息
                //1----修改资产审批表数据
                String sql1 = "update u_zc2 set depart='"+Depart+"' ,zeren='"+zeren+"' where ZcID in ("+zcid+")";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                this.TabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        //得到所有没有责任人的资产
        public DataSet GetNoZerenZc(string danwei)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zeren", "null", SearchOperator.空值));
            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            return this.GetSearchResult(list1);
        }

        //得到有责任人的资产
        public DataSet GetHaveZerenZc(string zeren)
        {
            this.tabCommand.TabName = "ZCView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zeren", "null", SearchOperator.非空值));
            if (zeren != null && zeren.Trim() != "")
            {
                list1.Add(new SearchField("zeren", zeren, SearchOperator.包含));
            }
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1 ", list1, "zeren");
            this.AddDataToSession(ds1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //得到我协办的资产
        public DataSet GetMyZc11(string zeren, string danwei)
        {
            this.tabCommand.TabName = "U_ZC";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField(String.Format("(zeren1='{0}' or zeren2='{0}')", zeren), "", SearchOperator.用户定义));
            list1.Add(new SearchField("", "Bstatus is null", SearchOperator.用户定义));
            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx,bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx ", list1, "Bstatus,num2");
            this.AddDataToSession(ds1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        
        //得到我负责的资产
        public DataSet GetMyZc1(string zeren, string danwei)
        {
            this.tabCommand.TabName = "U_ZC";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField(String.Format("(zeren='{0}')",zeren), "",SearchOperator.用户定义));
            list1.Add(new SearchField("", "Bstatus is null", SearchOperator.用户定义));
            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx,bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx ", list1, "Bstatus,num2");
            this.AddDataToSession(ds1);
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //得到我负责资产所在的包
        public DataSet GetMyZcInZcB(string zeren)
        {
            string sql = "select Bstatus from U_ZC where zeren='"+zeren+"' and Bstatus is not null group by Bstatus";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            string Bname = "";
            for (int i = 0; i < ds1.Tables[0].Rows.Count;i++ )
            {
                if (Bname == "")
                {
                    Bname = ds1.Tables[0].Rows[i]["bstatus"].ToString();
                }
                else
                {
                    Bname = Bname + "," + ds1.Tables[0].Rows[i]["bstatus"].ToString();
                }
            }
            if (Bname != "")
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("Bname", Bname, SearchOperator.集合, SearchFieldType.字符型));
                this.tabCommand.TabName = "ZCBAOView";
                DataSet ds = this.tabCommand.SearchData("*", list1);
                this.tabCommand.TabName = TabName;
                //string[] bstatus = Bname.Split(',');
                DataColumn dc = new DataColumn("bxhj",typeof(Double));
                ds.Tables[0].Columns.Add(dc);
                U_ZCBAOBU zcb1 = new U_ZCBAOBU();
                Hashtable ht = new Hashtable();

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ht = zcb1.GetZcBbjANDlx(ds.Tables[0].Rows[j]["id"].ToString());
                    ds.Tables[0].Rows[j]["bljsk"] = ht["bbjhj"].ToString();
                    ds.Tables[0].Rows[j]["bljzc"] = ht["blxhj"].ToString();
                    ds.Tables[0].Rows[j]["bxhj"] = double.Parse(ht["bbjhj"].ToString()) + double.Parse(ht["blxhj"].ToString());
                }
                zcb1.Close();
                return ds;
            }
            else
            {
                return null;
            }
        }

        //得到我负责的资产2
        public DataSet GetMyZcInfo(List<SearchField> list1)
        {
            this.tabCommand.TabName = "U_ZC";
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1,,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx,bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx  ", list1, "id");
            this.tabCommand.TabName = TabName;
            this.AddDataToSession(ds1);
            return ds1;
        }


        //得到我待审批（kind=0) 或审批过的资产（kind=1)
        public DataSet GetMyShenPiZc(string zeren, string danwei, int kind)
        {
            string sql = "";
            if (kind == 0)
            {
                sql = "select *,left(danwei,20) as danwei1,ZcNoShengPI.time0 as SPTime from ZCView ,ZcNoShengPI where ZcView.id = ZcNoShengPI.ZCID  and  ZcNoShengPI.zeren='" + zeren + "' ";
            }
            else
            {
                sql = "select *,left(danwei,20) as danwei1,ZcShengPI.time1 as SPTime from ZCView ,ZcShengPI where ZcView.id = ZcShengPI.ZCID  and  ZcShengPI.zeren='" + zeren + "'";
            }

            if (danwei != null && danwei.Trim() != "")
            {
                danwei = danwei.Replace("'", "");
                sql = sql + " and danwei like '%" + danwei + "%' ";
            }

            DataSet ds1= this.tabCommand.TableComm.SearchData(sql);
            this.AddDataToSession(ds1);
            return ds1;
        }

        //得到我待审批（kind=0) 或审批过的资产（kind=1)
        public DataSet GetMyShenPiZcInfo(List<SearchField> list, string zeren, string danwei, int kind)
        {
            DataSet ds = null;
            if (danwei != null && danwei != "")
            {
                list.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            list.Add(new SearchField("Nzeren", zeren, SearchFieldType.字符型));
            if (kind == 0)
            {
                this.tabCommand.TabName = "ZcNoShenPIINFO";
                ds = this.tabCommand.SearchData("*", list);
            }
            else
            {
                this.tabCommand.TabName = "ZcShenPIINFO";
                ds = this.tabCommand.SearchData("*", list);
            }

            this.AddDataToSession(ds);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //得到当前责任人管理人的所有资产
        public DataSet GetDepartZc(string zeren, string danwei, string zeren1)
        {
            string sql = "select *,left(danwei,20) as danwei1 from zcView2010 where 1=1 ";
            sql = sql + " and zeren in ( select sname  from U_UserName where leader like '%" + zeren + "%')";
            if (danwei != null && danwei != "")
            {
                sql = sql + " and ( danwei like '%" + danwei.Trim() + "%' )";
            }

            if (zeren1 != null && zeren1 != "")
            {
                sql = sql + " and ( zeren like '%" + zeren.Trim() + "%' )";
            }
           DataSet ds1= this.tabCommand.TableComm.SearchData(sql);
           this.AddDataToSession(ds1);
           return ds1;
        }

        //得到当前责任人管理人员的所有资产
        public DataSet GetDepartZcInfo(List<SearchField> list, string zeren, string danwei, string zeren1)
        {
            this.tabCommand.TabName = "ZCMyDepartZc";
            
            if (danwei != null && danwei != "")
            {
                list.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            if (zeren1 != null && zeren1 != "")
            {
                list.Add(new SearchField("zeren", zeren1, SearchOperator.包含));
            }
            list.Add(new SearchField("leader", zeren, SearchFieldType.字符型));

            //String sql1 = SearchField.GetSearchCondition(list);
            //WebFrame.Util.JDebug.Print(sql1);

            //list.Clear();

            DataSet ds = this.tabCommand.SearchData("*",list);

            this.tabCommand.TabName = TabName;
            this.AddDataToSession(ds);
            return ds;
        }

        //得到资产的综合查询结果
        public DataSet GetSearchResult(List<SearchField> list1)
        {
            this.tabCommand.TabName = "ZCView";
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1,isNull(lx1,0)+isNull(lx2,0)+isNull(lx3,0) as lx ", list1,"Bstatus,num2");
            this.tabCommand.TabName = TabName;
            this.AddDataToSession(ds1);
            return ds1;
        }


        /// <summary>
        /// 把查询结果的IDS发入Session
        /// </summary>
        /// <param name="ds1"></param>
        private void AddDataToSession(DataSet ds1)
        {
            if (ds1.Tables[0].Columns.Contains("id"))
            {
                List<String> IDS = new List<string>();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    IDS.Add(dr["id"].ToString());
                    //JSJ.SysFrame.Util.Print(dr["id"].ToString() + "<br>");
                }
                System.Web.HttpContext.Current.Session["ZCIDS"] = IDS;
            }
        }


        /// <summary>
        /// 根据当前ID，得到上一个ID和下一个ID
        /// </summary>
        /// <param name="curid"></param>
        /// <param name="nextid"></param>
        /// <param name="previd"></param>
        public void GetNextAndPrevID(string curid, out String nextid, out String previd)
        {
            nextid = "";
            previd = "";

            List<String> IDS = HttpContext.Current.Session["ZCIDS"] as List<String>;
            if (IDS != null)
            {
                String[] arr1 = new String[IDS.Count];
                IDS.CopyTo(arr1);
                int i = 0;
                foreach (String m in IDS)
                {
                    if (m == curid)
                    {
                        break;
                    }
                    i++;
                }

                if (i > 0)
                {
                    previd = arr1[i - 1];
                }
                if (i < arr1.Length - 1)
                {
                    nextid = arr1[i + 1];
                }
            }
        }

        //得到资产的综合查询结果
        public DataSet GetSearchResultByID(string str, List<SearchField> list1)
        {
            this.tabCommand.TabName = "ZCView";
            DataSet ds1 = this.tabCommand.SearchData(str, list1);
            this.tabCommand.TabName = TabName;
            this.AddDataToSession(ds1);
            return ds1;
        }
        //得到资产的综合查询结果
        public DataSet GetSearchResultByID1(string str, List<SearchField> list1)
        {
            this.tabCommand.TabName = "ZCView";
            DataSet ds1 = this.tabCommand.SearchData(str, list1, "isnull(num2,'zzzzzz'),Bstatus");
            this.tabCommand.TabName = TabName;
            this.AddDataToSession(ds1);
            return ds1;
        }
        //得到资产的详细资料1
        public DataSet GetDetailByID(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                id = "-1";
            }
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "ZCView";
            DataSet ds = this.TabCommand.SearchData(" * ", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //得到资产的详细资料2
        public DataSet GetDetailByID(string id, string fields)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "ZCView";
            DataSet ds = this.TabCommand.SearchData(fields, list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //得到资产的详细资料2
        public DataSet GetZCInfoByID(string ids)
        {
            List<SearchField> list1 = new List<SearchField>();
            if (ids != "" && ids != null)
            {
                list1.Add(new SearchField("id", ids, SearchOperator.集合, SearchFieldType.数值型));
            }
            else
            {
                list1.Add(new SearchField("id", ""));
            }
            DataSet ds = this.TabCommand.SearchData("id,num2,danwei,left(danwei,20) as danwei1,bj,ISNULL(dbo.U_ZC.lx1, 0) + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 0) AS lxhj,depart,zeren", list1);
            return ds;
        }
        //得到资产的详细资料3
        public DataSet GetDetailByID(List<SearchField> list1, string fields)
        {
            this.tabCommand.TabName = "ZCView";
            DataSet ds = this.TabCommand.SearchData(fields, list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        public DataSet GetDepartAndZeren(string danwei)
        {
            this.tabCommand.TabName = "ZCView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("danwei", danwei, SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("depart,zeren", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //更新资产的基本资料
        public void UpdateInfo(string id, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
              
                //1)建立资产基本资料的更新日志文件
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", id, SearchFieldType.数值型));
                Hashtable ht1 = this.tabCommand.SearchData(list1);
                ht1.Remove("id");
                ht1.Remove("gx");
                ht1.Remove("bstatus");

                ht1["zcid"] = id;
                ht1["xgr"] = System.Web.HttpContext.Current.User.Identity.Name;
                ht1["xgsj"] = DateTime.Now.ToString();
                this.tabCommand.TabName = "U_OLDZC";
                this.tabCommand.InsertData(ht1);
            
                //修改资产资料
                string[] arr1 = new string[] { "bj", "lx1", "lx2", "lx3", "zczb", "dkye", "zjycszje" };
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (ht[arr1[i]] != null && ht[arr1[i]].ToString().Trim() != "")
                    {
                        ht[arr1[i]] = ht[arr1[i]].ToString().Replace(",", "");
                    }
                }
                this.tabCommand.TabName = TabName;
                this.TabCommand.EditQuickData(list1, ht);
                this.TabCommand.TableConnect.CommitTrans();
            }
            catch (Exception err1)
            {
                this.TabCommand.TableConnect.RollBackTrans();
                throw err1;
            }
        }

        //Insert a new Zc
        public string InsertZcData(Hashtable ht)
        {
            return null;
        }

        //得到资产的诉讼信息
        public DataSet GetZCSSInfo(String id)
        {
            string sql = "select * from U_ZCSS  where id=" + id;
            DataSet ds = this.tabCommand.TableComm.SearchData(sql);
            return ds;
        }

        //通过资产ID获取资产担保的详细情况
        public DataSet GetZCDBInfoByID(string id)
        {
            string sql = "select U_ZC1.*,U_zc.zeren,U_ZC.depart,U_ZC.danwei from U_ZC left outer join U_ZC1 on U_zc.id =u_zc1.id  where U_zc.id=" + id;
            DataSet ds = this.tabCommand.TableComm.SearchData(sql);
            return ds;

            /*
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZC1";
            DataSet ds = this.TabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
             * */
        }


        //通过ID更新资产担保的详细情况
        public void UpDateZCDBInfo(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZC1";
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                ht.Remove("id");
                string[] arr1 = new string[] { "zwrhsgz", "bzrhsgz", "qthsgz", "bzje", "klazfy", "dyhsgz1", "dyhsgz2" };
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (ht[arr1[i]] != null && ht[arr1[i]].ToString().Trim() != "")
                    {
                        ht[arr1[i]] = ht[arr1[i]].ToString().Replace(",", "");
                    }
                    else
                    {
                        ht.Remove(arr1[i]);
                    }
                }
                this.TabCommand.EditQuickData(list1, ht);
            }
            else
            {
                this.tabCommand.InsertData(ht);
            }
            this.tabCommand.TabName = TabName;
        }


        //通过ID更新资产诉讼的情况
        public void UpDateZCSSInfo(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZCSS";
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                ht.Remove("id");
                this.TabCommand.EditQuickData(list1, ht);
            }
            else
            {
                this.tabCommand.InsertData(ht);
            }
            this.tabCommand.TabName = TabName;
        }



        //获取抵(质)押物的情况
        public DataSet GetDZYWInfo(string zcid, string wpkind)
        {
            this.tabCommand.TabName = "U_ZC11";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField("wpkind", wpkind));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //删除抵(质)押物的信息
        public void DelDZYWInfo(string id)
        {
            this.tabCommand.TabName = "U_ZC11";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
            this.tabCommand.TabName = TabName;
            //this.tabCommand.DeleteData(
        }

        //通过抵押物ID获得抵(质)押物详细信息
        public DataSet GetDZYWInfoByID(string id)
        {
            this.tabCommand.TabName = "U_ZC11";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //更新抵押物信息
        public void UpdateDZYWInfo(string id, Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZC11";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.TabCommand.EditQuickData(list1, ht);
            this.tabCommand.TabName = TabName;
        }
        //增加抵押物
        public void InsertDZYW(Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZC11";
            this.TabCommand.InsertData(ht);
            this.tabCommand.TabName = TabName;
        }

        //通过资产ID和状态获取资产处置申报表信息
        public DataSet GetZCCZByZCIDANDSTATUS(string zcid, string status)
        {
            this.tabCommand.TabName = "U_ZC2";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField("status", status, SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }


        //通过处置申报表ID获得处置方式信息
        public DataSet GetCZFSByCZID(string czid)
        {
            this.tabCommand.TabName = "U_ZC21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //通过处置申报表ID获得处置方式信息
        public DataSet GetBCZFSByCZID(string czid)
        {
            this.tabCommand.TabName = "U_ZCB21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        #endregion

        #region 业务方法2
        //删除处置方式
        public void DelZCFS(string id)
        {
            this.tabCommand.TabName = "U_ZC21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
            this.tabCommand.TabName = TabName;
        }

        //删除处置方式
        public void DelZCBFS(string id)
        {
            this.tabCommand.TabName = "U_ZCB21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
            this.tabCommand.TabName = TabName;
        }
        //通过处置方式ID获得处置方式详细信息
        public DataSet GetCZFSInfoByID(string id)
        {
            this.tabCommand.TabName = "U_ZC21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //通过处置方式ID获得处置方式详细信息
        public DataSet GetBCZFSInfoByID(string id)
        {
            this.tabCommand.TabName = "U_ZCB21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //增加处置方式
        public void InsertCZFS(Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZC21";
            this.TabCommand.InsertData(ht);
            this.tabCommand.TabName = TabName;
        }

        //增加资产包处置方式
        public void InsertBCZFS(Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZCB21";
            this.TabCommand.InsertData(ht);
            this.tabCommand.TabName = TabName;
        }
        //更新处置方式
        public void UpdateCZFSInfo(string id, Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZC21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.TabCommand.EditQuickData(list1, ht);
            this.tabCommand.TabName = TabName;
        }

        //更新处置方式
        public void UpdateBCZFSInfo(string id, Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZCB21";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.TabCommand.EditQuickData(list1, ht);
            this.tabCommand.TabName = TabName;
        }
        //通过资产ID得到资产责任人
        public string GetZerenByZCID(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
            DataSet ds = this.TabCommand.SearchData("zeren", list1);
            string zeren = ds.Tables[0].Rows[0]["zeren"].ToString();
            return zeren;
        }


        //更新资产处置申报表
        public void UpdateZcCzsbbByCZID(string czid, Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZC2";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
            this.TabCommand.EditQuickData(list1, ht);
            this.tabCommand.TabName = TabName;
        }
        //更新资产处置申报表
        public void UpdateZcBCzsbbByCZID(string czid, Hashtable ht)
        {
            this.tabCommand.TabName = "U_ZCB2";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
            this.TabCommand.EditQuickData(list1, ht);
            this.tabCommand.TabName = TabName;
        }

        //通过ID获得资产处置申报表的信息
        public DataSet GetZcsbbInfoByID(string czid)
        {
            this.tabCommand.TabName = "U_ZC2";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1, null);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //增加资产处置申报表
        public void InsertZcsbb(Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //增加资产处置表
                this.tabCommand.TabName = "U_ZC2";
                this.TabCommand.InsertData(ht);
                this.tabCommand.TabName = TabName;

                //更新资产的状态尽职调查
                this.tabCommand.TabName = "U_ZC";
                Hashtable ht1 = new Hashtable();
                ht1.Add("status", "04");
                string zcid = ht["zcid"].ToString();
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                this.tabCommand.EditQuickData(list1, ht1);
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
            }
            catch (Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                throw err1;
            }

        }


        //增加资产处置申报表
        public void InsertZcBsbb(Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //增加资产处置表
                this.tabCommand.TabName = "U_ZCB2";
                this.TabCommand.InsertData(ht);
                this.tabCommand.TabName = TabName;

                //更新资产的状态尽职调查
                this.tabCommand.TabName = "U_ZCBAO";
                Hashtable ht1 = new Hashtable();
                ht1.Add("status", "04");
                string zcid = ht["zcid"].ToString();
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                this.tabCommand.EditQuickData(list1, ht1);
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
            }
            catch (Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                throw err1;
            }

        }
        public DataSet GetShenBaoInfo(string czid)
        {
            this.tabCommand.TabName = "ZCShenBaoView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //删除资产基本资料修改日志
        public void DelOldZC(string id)
        {
            this.tabCommand.TabName = "U_OLDZC";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
            this.tabCommand.TabName = TabName;
        }
        //获取修改日志信息
        public DataSet GetOldZCInfo(string zcid)
        {
            this.tabCommand.TabName = "U_OLDZC";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1, "id desc");
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //增加修改日志信息
        public void InsertOldZC(Hashtable ht)
        {
            this.tabCommand.TabName = "U_OLDZC";
            this.TabCommand.InsertData(ht);
            this.tabCommand.TabName = TabName;
        }

        //得到修改日志的信息
        public DataSet GetOldZCInfoByID(string id)
        {
            this.tabCommand.TabName = "U_OLDZC";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds = this.TabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        #endregion

        #region 业务方法3

        /// <summary>
        /// 得到尽职调查统计后的资产列表显示
        /// 编码：金寿吉
        /// 时间：2008年1月22日
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="kind"></param>
        /// <param name="zeren"></param>
        /// <param name="depart"></param>
        /// <param name="searchtype">查询的类别</param>
        /// <returns></returns>
        public DataSet GetDCZclist(DateTime dt1,DateTime dt2,int kind,string zeren,string depart,string searchtype)
        {
            string temp = "";
            if (searchtype == "" || searchtype==null)
            {
                temp = this.GetDcZcIDS(dt1, dt2, kind, zeren, depart);
            }
            else if (searchtype == "1")
            {
                temp = this.GetDcZcIDSByFASP(dt1, dt2, kind, zeren, depart);
            }
            else
            {
                //temp = this.getdczcidsby.GetDcZcIDSByFASP(dt1, dt2, kind, zeren, depart);
            }

            //设置返回的资产结果
            if (temp != "")
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", temp, SearchOperator.集合, SearchFieldType.数值型));
                return this.GetSearchResult(list1);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据尽职调查的条件得到满足条件的资产数据
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="kind"></param>
        /// <param name="zeren"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        private string GetDcZcIDS(DateTime dt1, DateTime dt2, int kind, string zeren,string depart)
        {
            string t1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
            string t2 = dt2.ToString("yyyy-MM-dd") + " 23:59:59";

            string sql = @"select distinct zcid from U_zctc inner join U_username 
                         on U_zctc.zeren=U_username.sname
                         where ( status is null or status <>'作废') and bkind='0' ";

            if (dt1 != default(DateTime))
            {
                sql = sql + " and time0>='" + t1 + "'";
            }

            if (dt2 != default(DateTime))
            {
                sql = sql + "and time0<='" + t2 + "'";
            }

            if (zeren != "")
            {
                sql = sql + " and zeren='" + zeren + "'";
            }

            if (depart != "")
            {
                sql = sql + " and U_username.depart='" + depart + "'";
            }

            if (kind == 5)
            {
                sql = sql + " and kind<='05'";
            }
            else
            {
                sql = sql + " and kind='0"+kind+"'";
            }

            //Util.Print(sql);
            string temp = "";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (temp == "")
                {
                    temp = ds1.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    temp = temp + "," + ds1.Tables[0].Rows[i][0].ToString();
                }
            }
            return temp;

        }


        /// <summary>
        /// 根据方案审批得到满足条件的资产数据
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="kind"></param>
        /// <param name="zeren"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        private string GetDcZcIDSByFASP(DateTime dt1, DateTime dt2, int kind, string zeren, string depart)
        {
            string t1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
            string t2 = dt2.ToString("yyyy-MM-dd") + " 23:59:59";
            string sql = @"select distinct u_zcsp.zcid
                            from u_zcsp inner join u_zc
                            on u_zcsp.zcid=u_zc.id
                            inner join u_username on U_zc.zeren=u_UserName.sname
                            inner join u_depart on U_username.depart=u_depart.depart
                            where 1=1";

            if (dt1 != default(DateTime))
            {
                sql = sql + " and u_zcsp.time0>='" + t1 + "'";
            }

            if (dt2 != default(DateTime))
            {
                sql = sql + "and u_zcsp.time0<='" + t2 + "'";
            }

            if (zeren != "")
            {
                sql = sql + " and u_zc.zeren='" + zeren + "'";
            }

            if (depart != "")
            {
                sql = sql + " and u_username.depart='" + depart + "'";
            }
            sql = sql + " and u_zcsp.kind='" + kind + "'";
            

           //Util.Print(sql);
            string temp = "";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (temp == "")
                {
                    temp = ds1.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    temp = temp + "," + ds1.Tables[0].Rows[i][0].ToString();
                }
            }
            return temp;

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
