using System;
using System.Collections.Generic;
using System.Web;

using System.Data;
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections;

/// <summary>
///LawBU 的摘要说明
/// </summary>
public class LawBU
{
    /// <summary>
    /// 得到法律顾问的资产责任人选项
    /// </summary>
    /// <returns></returns>
    public static List<string> GetZerenForZc()
    {
        int total1 = 0;
        List<string> list1 = new List<string>();
        //得到资产的所有责任人
        CommTable comm1 = new CommTable("U_ZC");
        
        DataSet ds1 = comm1.SearchData("distinct zeren", null, "zeren", -1, -1, out total1);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            String temp = dr1[0].ToString().Trim();
            if (temp != String.Empty)
            {
                if (list1.Contains(temp) == false)
                {
                    list1.Add(temp);
                }
            }
        }
        comm1.Close();

        list1.Sort();
        return list1;
    }


    /// <summary>
    /// 得到法律顾问的资产包责任人选项
    /// </summary>
    /// <returns></returns>
    public static List<string> GetZerenForZcBao()
    {
        int total1 = 0;
        List<string> list1 = new List<string>();
        
        //得到资产包的所有责任人
        CommTable comm2 = new CommTable("U_ZCBAO");
        DataSet ds2 = comm2.SearchData("distinct bzeren", null, "bzeren", -1, -1, out total1);
        foreach (DataRow dr1 in ds2.Tables[0].Rows)
        {
            String temp = dr1[0].ToString().Trim();
            if (temp != String.Empty)
            {
                if (list1.Contains(temp) == false)
                {
                    list1.Add(temp);
                }
            }
        }
        comm2.Close();
        list1.Sort();
        return list1;
    }

    /// <summary>
    /// 得到法律顾问的资产和资产包责任人选项
    /// </summary>
    /// <returns></returns>
    public static List<string> GetZerenForZcAndZcBao()
    {
        int total1 = 0;
        List<string> list1 = new List<string>();
        //得到资产的所有责任人
        CommTable comm1 = new CommTable("U_ZC");

        DataSet ds1 = comm1.SearchData("distinct zeren", null, "zeren", -1, -1, out total1);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            String temp = dr1[0].ToString().Trim();
            if (temp != String.Empty)
            {
                if (list1.Contains(temp) == false)
                {
                    list1.Add(temp);
                }
            }
        }
        comm1.Close();

        //得到资产包的所有责任人
        CommTable comm2 = new CommTable("U_ZCBAO");
        DataSet ds2 = comm2.SearchData("distinct bzeren", null, "bzeren", -1, -1, out total1);
        foreach (DataRow dr1 in ds2.Tables[0].Rows)
        {
            String temp = dr1[0].ToString().Trim();
            if (temp != String.Empty)
            {
                if (list1.Contains(temp) == false)
                {
                    list1.Add(temp);
                }
            }
        }
        comm2.Close();
        list1.Sort();
        return list1;
    }


    /// <summary>
    /// 得到法律顾问的资产责任人选项
    /// </summary>
    /// <param name="kind">kind=0 资产 kind=1 资产包</param>
    /// <returns></returns>
    public static List<string> GetZerenForScan(int kind)
    {
        int total1 = 0;
        List<string> list1 = new List<string>();
        //得到资产的所有责任人
        CommTable comm1 = new CommTable("U_LawZC");
        List<SearchField> condition = new List<SearchField>();
        if (kind == 0)
        {
            condition.Add(new SearchField("kind", "资产,资产和资产包", SearchOperator.集合));
        }

        if (kind == 1)
        {
            condition.Add(new SearchField("kind", "资产包,资产和资产包", SearchOperator.集合));
        }

        DataSet ds1 = comm1.SearchData("distinct sname", condition, "sname", -1, -1, out total1);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            String temp = dr1[0].ToString().Trim();
            if (temp != String.Empty)
            {
                if (list1.Contains(temp) == false)
                {
                    list1.Add(temp);
                }
            }
        }
        comm1.Close();

        list1.Sort();
        return list1;
    }


    //判断当前用户是否只有法律顾问
    public static bool isOnlyLaw()
    {
        bool result = false;
        CommTable tab1 = new CommTable("U_RoleUsers");
        List<SearchField> list1 = new List<SearchField>();
        list1.Add(new SearchField("sname",Util.getCookieValue("currentuser")));
        DataSet ds1 = tab1.SearchData("role", list1);
        string temp1 = String.Empty;
        bool first = true;
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            if (dr1[0].ToString().Trim() != String.Empty)
            {
                if (first)
                {
                    temp1 = dr1[0].ToString().Trim();
                    first = false;
                }
                else
                {
                    temp1 = temp1 + "," + dr1[0].ToString().Trim();
                }
            }
        }
        tab1.Close();

        if (temp1 == "法律顾问")
        {
            result = true;
        }
        return result;
    }
}
