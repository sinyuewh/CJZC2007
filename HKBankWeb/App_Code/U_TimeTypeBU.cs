using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections;

/// <summary>
///U_TimeTypeBU 的摘要说明
/// </summary>
public class U_TimeTypeBU
{
    /// <summary>
    /// 设置下拉框
    /// </summary>
    /// <param name="timename"></param>
    /// <param name="blankValue"></param>
    public static void SetLiteralControl(ListControl timename, String blankValue)
    {
        CommTable comm1 = new CommTable("U_TimeType");
        List<SearchField> condition = new List<SearchField>();
        DataSet ds1 = comm1.SearchData("*", condition,"num");
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            ListItem list1 = new ListItem(dr1["TimeTypeName"].ToString(),
                dr1["TimeTypeCode"].ToString());
            timename.Items.Add(list1);
        }
        if (String.IsNullOrEmpty(blankValue) == false)
        {
            ListItem list0 = new ListItem(blankValue,"");
            timename.Items.Insert(0,list0);
        }
        comm1.Close();
    }


    /// <summary>
    /// 得到时效的名称
    /// </summary>
    /// <param name="TimeCode"></param>
    /// <returns></returns>
    public static String GetTimeNameByCode(String TimeCode)
    {
        String result = String.Empty;
        CommTable comm1 = new CommTable("U_TimeType");
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("TimeTypeCode", TimeCode));
        DataSet ds1 = comm1.SearchData("timeTypeName", condition, "num");
        if (ds1 != null)
        {
            DataRow dr1 = ds1.Tables[0].Rows[0];
            result = dr1[0].ToString();
        }
        comm1.Close();
        return result;
    }


    /// <summary>
    /// 得到个人的时效提醒报告
    /// </summary>
    /// <param name="UserName"></param>
    /// <returns></returns>
    public static DataTable GetPersonTimeList(String UserName)
    {
        DataTable dt1 = null;
        String sql1 = @"select U_ZcTime.*,U_zc.danwei,TimeTypeName from U_ZcTime inner join U_ZC on U_ZCTime.zcid=U_ZC.id
        inner join U_TimeType on U_ZCtime.timeName=U_TimeType.TimeTypeCode
        where exists (select 1 from u_zc where id=u_zctime.zcid and zeren='" + UserName + "')";
        CommTable comm1 = new CommTable("u_zctime");
        dt1=comm1.TableComm.SearchData(sql1).Tables[0];
        DataTable timeTable = GetTimeTypeData();
        bool change = false;
        for(int i=dt1.Rows.Count-1;i>=0;i--) 
        {
            DataRow dr1 = dt1.Rows[i];
            bool show = false;

            //得到时效的类别和时间
            String timeName = dr1["timeName"].ToString();
            DateTime time1 =DateTime.Parse(dr1["time0"].ToString());
            DataRow[] drs = timeTable.Select("TimeTypeCode='"+timeName+"'");
            String timeid = dr1["id"].ToString();

            if (drs != null && drs.Length > 0)
            {
                foreach (DataRow dr0 in drs)
                {
                    String timeTypeKind = dr0["TimeTypekind"].ToString();
                    int day1 = int.Parse(dr0["day1"].ToString());
                    int day2 = int.Parse(dr0["day2"].ToString());
                    DateTime d0 = time1.AddDays(-1 * day1);
                    DateTime d1 = time1.AddDays(-1 * day2);
                    if (DateTime.Today >= d0 && DateTime.Today <= d1)
                    {
                        bool haslog = HasLog(timeid, timeTypeKind, UserName);
                        if (haslog == false)
                        {
                            show = true;
                            break;
                        }
                    }
                }
            }

            if (show == false)
            {
                dr1.Delete();
                change = true;
            }
        }

        comm1.Close();
        if (change)
        {
            dt1.AcceptChanges();
        }
        return dt1;
    }

    /// <summary>
    /// 得到他人的时效提醒报告
    /// </summary>
    /// <param name="OtherNames"></param>
    /// <returns></returns>
    public static DataTable GetOtherPersonTimeList(String OtherNames, String UserName)
    {
         //temp1 = OtherNames.Replace(UserName, "-1");
        String temp1 = OtherNames.Replace(",", "','");

        DataTable dt1 = null;
        String sql1 = @"select U_ZcTime.*,U_zc.danwei,TimeTypeName from U_ZcTime inner join U_ZC on U_ZCTime.zcid=U_ZC.id
        inner join U_TimeType on U_ZCtime.timeName=U_TimeType.TimeTypeCode
        where exists (select 1 from u_zc where id=u_zctime.zcid and zeren in ('" + temp1 + "') and zeren<>'"+UserName+"' )";
        CommTable comm1 = new CommTable("u_zctime");
        dt1 = comm1.TableComm.SearchData(sql1).Tables[0];
        DataTable timeTable = GetTimeTypeData();
        bool change = false;
        for (int i = dt1.Rows.Count - 1; i >= 0; i--)
        {
            DataRow dr1 = dt1.Rows[i];
            bool show = false;

            //得到时效的类别和时间
            String timeName = dr1["timeName"].ToString();
            DateTime time1 = DateTime.Parse(dr1["time0"].ToString());
            DataRow[] drs = timeTable.Select("TimeTypeCode='" + timeName + "'");
            String timeid = dr1["id"].ToString();

            if (drs != null && drs.Length > 0)
            {
                foreach (DataRow dr0 in drs)
                {
                    String timeTypeKind = dr0["TimeTypekind"].ToString();
                    int day1 = int.Parse(dr0["day1"].ToString());
                    int day2 = int.Parse(dr0["day2"].ToString());
                    DateTime d0 = time1.AddDays(-1 * day1);
                    DateTime d1 = time1.AddDays(-1 * day2);
                    if (DateTime.Today >= d0 && DateTime.Today <= d1)
                    {
                        bool haslog = HasLog(timeid, timeTypeKind, UserName);
                        if (haslog == false)
                        {
                            show = true;
                            break;
                        }
                    }
                }
            }

            if (show == false)
            {
                dr1.Delete();
                change = true;
            }
        }

        comm1.Close();
        if (change)
        {
            dt1.AcceptChanges();
        }
        return dt1;
    }


    //得到时效类别的数据
    private static DataTable GetTimeTypeData()
    {
        String sql1 = "select * from U_TimeTypeDetail";
        CommTable comm1 = new CommTable("u_zctime");
        DataTable dt1 = comm1.TableComm.SearchData(sql1).Tables[0];
        comm1.Close();
        return dt1;
    }

    /// <summary>
    /// 写入时效提醒日志
    /// </summary>
    /// <param name="timeid"></param>
    public static void WriteLog(String timeid,String UserName)
    {
        CommTable comm1 = new CommTable("U_TimeLog");
        Hashtable ht1 = new Hashtable();
        ht1["timeid"] = timeid;
        ht1["logtime"] = DateTime.Now.ToString();
        ht1["loguser"] = UserName;
        comm1.InsertData(ht1);
        comm1.Close();
    }

    /// <summary>
    /// 得到时效浏览日志
    /// </summary>
    /// <param name="timeid"></param>
    /// <returns></returns>
    public static DataTable GetLogoTable(String timeid)
    {
        DataTable dt1 = null;
        String sql1 = @"select U_TimeLog.*,U_zc.danwei,TimeTypeName from U_TimeLog inner join U_ZCTime 
        on U_TimeLog.timeid=U_ZcTime.id inner join U_ZC on U_ZcTime.Zcid=U_Zc.id
        inner join U_TimeType on U_ZCtime.timeName=U_TimeType.TimeTypeCode 
        where U_timeLog.timeid="+ timeid+ "order by u_TimeLog.id desc";
        CommTable comm1 = new CommTable("u_zctime");
        dt1 = comm1.TableComm.SearchData(sql1).Tables[0];
        comm1.Close();
        return dt1;
    }

    /// <summary>
    /// 判断时效是否建立了日志
    /// </summary>
    /// <param name="TimeID"></param>
    /// <param name="TimeKind"></param>
    /// <returns></returns>
    private static bool HasLog(String TimeID,String TimeKind,String UserName)
    {
        bool has = false;
        CommTable comm1 = new CommTable("U_TimeLog");
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("TimeID", TimeID, SearchFieldType.数值型));
        condition.Add(new SearchField("LogUser", UserName));
        if (TimeKind == "0")   //月显示
        {
            condition.Add(new SearchField("year(logtime)", DateTime.Today.Year + "", SearchFieldType.数值型));
            condition.Add(new SearchField("month(logtime)", DateTime.Today.Month+"",SearchFieldType.数值型));
        }
        else if (TimeKind == "1")  //周显示
        {
        }
        else   //日显示
        {
            condition.Add(new SearchField("year(logtime)", DateTime.Today.Year + "", SearchFieldType.数值型));
            condition.Add(new SearchField("month(logtime)", DateTime.Today.Month + "", SearchFieldType.数值型));
            condition.Add(new SearchField("day(logtime)", DateTime.Today.Day + "", SearchFieldType.数值型));
        }
        DataSet ds1 = comm1.SearchData("*", condition);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            has = true;
        }
        comm1.Close();
        return has;
    }


}
