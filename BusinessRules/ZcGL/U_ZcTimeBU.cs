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
    /// 时效管理
    /// </summary>
    public class U_ZCTimeBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZCTime";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
        public U_ZCTimeBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ZCTimeBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        //set my zctime
        public DataSet GetMyTimeList(string zeren, string danwei)
        {
            return this.GetMyTimeList(zeren, danwei, 0);
        }

        //得到我部门的所有时效警告数据
        public DataSet GetMyDepartTimeList(string leader, string danwei)
        {
            //得到管理的所有责任人
            string sql = "select *,left(danwei,20) as danwei1,DateAdd(day,-tellday,ZcTime) as ZcTime0 from ZCTimeView where 1=1 ";
            sql = sql + " and zeren in (select sname from U_UserName where leader like '%"+leader+"%') ";
            if (danwei != null && danwei.Trim() != "")
            {
                sql = sql + " and ( danwei like '%" + danwei + "%' )";
            }
            return this.tabCommand.TableComm.SearchData(sql);
        }

        //得到我部门的所有时效警告数据
        public DataSet GetMyDepartTimeListInfo(List<SearchField> list,string leader, string danwei)
        {
            //得到管理的所有责任人
            this.tabCommand.TabName = "ZCDepartTimeView";
            if (danwei.Trim() != null && danwei.Trim() != "")
            {
                list.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            list.Add(new SearchField("leader", leader, SearchOperator.包含));
            DataSet ds = this.tabCommand.SearchData("*", list);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //get Time List by ParentID
        public DataSet GetTimeListByParentID(string parentID)
        {
            this.tabCommand.TabName = "ZCTimeView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ZCID", parentID, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("TimeName,ZcTime,tellday,TimeRemark as remark,DateAdd(day,-tellday,ZcTime) as ZcTime0,TimeID", list1);
            this.tabCommand.TabName = TabName;

            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = (i + 1) + "";
            }
            return ds1;
        }

        //set my zctime1
        public DataSet GetMyTimeList(string zeren, string danwei, int kind)
        {
            this.tabCommand.TabName = "ZCTimeView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zeren", zeren));
            if (danwei != null && danwei.Trim() != "")
            {
                list1.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }

            if (kind == 1)
            {
                list1.Add(new SearchField(" DateAdd(day,-tellday,ZcTime) ", "<=getdate()", SearchOperator.用户定义));
            }
            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1,DateAdd(day,-tellday,ZcTime) as ZcTime0 ", list1, "zeren");
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //set my zctime1
        public DataSet GetMyTimeListInfo(List<SearchField> list,string zeren, string danwei)
        {
            this.tabCommand.TabName = "ZCTimeView";
            list.Add(new SearchField("zeren", zeren));
            if (danwei != null && danwei.Trim() != "")
            {
                list.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }

            DataSet ds1 = this.tabCommand.SearchData("*,left(danwei,20) as danwei1,DateAdd(day,-tellday,ZcTime) as ZcTime0 ", list, "zeren");
            this.tabCommand.TabName = TabName;
            return ds1;
        }


        //Delete a data
        public void DelTimeData(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
        }


        public Hashtable GetTimeDataByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            return this.tabCommand.SearchData(list1);
        }


        //修改时效管理
        public int EditTimeData(string id, Hashtable ht,out string remark)
        {
            remark = "<font size='4'>";
            string temp1 = "";

            int parentid = -1;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                parentid = (int)ds1.Tables[0].Rows[0]["ZCID"];
                foreach (DictionaryEntry item in ht)
                {
                    if (item.Key.ToString().ToLower() == "timename" 
                        && ds1.Tables[0].Rows[0][item.Key.ToString()].ToString()!=item.Value.ToString())
                    {
                        temp1 = temp1 + "<br>" + String.Format("原时效名称：{0}＝>>更改后的时效名称为：{1}", ds1.Tables[0].Rows[0][item.Key.ToString()], item.Value);
                    }

                    if (item.Key.ToString().ToLower() == "time0"
                       && DateTime.Parse(ds1.Tables[0].Rows[0][item.Key.ToString()].ToString()).ToString("yyyy-M-d") != item.Value.ToString() )
                    {
                        temp1 = temp1 + "<br>" + String.Format("原时效日期：{0}＝>>更改后的时效日期为：{1}", DateTime.Parse(ds1.Tables[0].Rows[0][item.Key.ToString()].ToString()).ToString("yyyy-M-d"), item.Value);
                    }

                    if (item.Key.ToString().ToLower() == "tellday"
                      && ds1.Tables[0].Rows[0][item.Key.ToString()].ToString() != item.Value.ToString())
                    {
                        temp1 = temp1 + "<br>" + String.Format("原时效提前警告：{0}＝>>更改后的时效提前警告为：{1}", ds1.Tables[0].Rows[0][item.Key.ToString()], item.Value);
                    }

                    if (item.Key.ToString().ToLower() == "remark"
                      && ds1.Tables[0].Rows[0][item.Key.ToString()].ToString() != item.Value.ToString())
                    {
                        string temp=ds1.Tables[0].Rows[0][item.Key.ToString()].ToString();
                        if(temp=="")
                        {
                            temp="无";
                        }
                        temp1 = temp1 + "<br>" + String.Format("原时效备注：{0}＝>>更改后的时效备注为：{1}", temp, item.Value);
                    }
                    

                    ds1.Tables[0].Rows[0][item.Key.ToString()] = item.Value;
                }

                //发送邮件提示
                if (temp1 != "")
                {
                    remark = remark + temp1 + "</font><br>";
                }
                else
                {
                    remark = "";
                }
                
            }
            this.tabCommand.Update(ds1);
            return parentid;
        }


        //add a TimeData
        public string InsertTimeData(Hashtable ht)
        {
            string error = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ZCID", ht["ZCID"].ToString(), SearchFieldType.数值型));
            list1.Add(new SearchField("timename", ht["timename"].ToString()));

            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                error = "错误：该资产的时效（" + ht["timename"].ToString() + "）已经存在！";
            }
            else
            {
                try
                {
                    DataRow dr = ds1.Tables[0].NewRow();
                    foreach (DictionaryEntry item in ht)
                    {
                        dr[item.Key.ToString()] = item.Value;
                    }
                    ds1.Tables[0].Rows.Add(dr);
                    this.tabCommand.Update(ds1);
                }
                catch
                {
                    error = "错误：增加数据失败，请检查数据的正确性！";
                }
            }
            return error;
        }

        public DataSet GetSXList1(List<SearchField> list1, string sx)
        {
            this.tabCommand.TabName = "ZCTimeView";
            list1.Add(new SearchField("TimeName",sx));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
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

