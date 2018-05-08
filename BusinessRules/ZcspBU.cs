using System;
using System.Data;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace JSJ.CJZC.Business
{
    public enum ZCKind { 单条资产=0,资产包=1}

    public class ZcspBU
    {
       /// <summary>
       /// 得到资产已处置的数量
       /// </summary>
       /// <param name="zcid">资产ID或资产包ID</param>
       /// <param name="kind">类别</param>
       /// <returns></returns>
       public int GetZcCount(int zcid, ZCKind kind)
       {
           int result = 0;
           CommTable com1 = new CommTable();
           com1.TabName = "U_Zc2";
           List<SearchField> condition = new List<SearchField>();
           if (kind == ZCKind.单条资产)
           {
               condition.Add(new SearchField("zcid",zcid+"",SearchFieldType.数值型));
           }
           else
           {
               condition.Add(new SearchField("zcbid",zcid+"",SearchFieldType.数值型));
           }
           DataSet ds1 = com1.SearchData("id", condition);
           if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
           {
               result = ds1.Tables[0].Rows.Count;
           }
           com1.Close();
           return result;
       }


       /// <summary>
       /// 得到资产的审批庄
       /// </summary>
       /// <param name="KeyID">ID</param>
       /// <param name="kind">
       /// 类别 kind＝0表示是处置方案的ID，
       /// kind＝1表示是资产ID，
       /// kind＝2表示是资产包</param>
       /// <returns></returns>
       public DataRow GetShenPiInfo(String fields,String Keyid, String kind)
       {
           DataRow dr1 = null;
           if (String.IsNullOrEmpty(Keyid) == false)
           {
               CommTable com1 = new CommTable();
               com1.TabName = "U_ZC2";
               List<SearchField> condition = new List<SearchField>();
               if (kind == "0")
               {
                   condition.Add(new SearchField("id", Keyid, SearchFieldType.数值型));
               }
               else if (kind == "1")
               {
                   //增加了审批条件
                   condition.Add(new SearchField("zcid", Keyid, SearchFieldType.数值型));
                   //condition.Add(new SearchField("exists  (select * from u_zcsp where czid=u_zc2.id)  ", "", SearchOperator.用户定义));
               }
               else if (kind == "2")
               {
                   condition.Add(new SearchField("zcbid", Keyid, SearchFieldType.数值型));
                   //condition.Add(new SearchField("exists  (select * from u_zcsp where czid=u_zc2.id) ", "", SearchOperator.用户定义));
               }
               else
               {
                   condition.Add(new SearchField("id", Keyid, SearchFieldType.数值型));
               }


               //String sql1=com1
               //这里调整了（2010年11月21日）
              // DataSet ds1 = null;
               DataSet ds1 = com1.SearchData(fields, condition, "id desc");


               if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
               {
                   dr1 = ds1.Tables[0].Rows[0];
               }
               com1.Close();
           }
           return dr1;
       }


       private String GetXmsbhCode(String xmsbh)
       {
           return "";
       }

       /// <summary>
       /// 根据审批情况，设置其审批状态
       /// </summary>
       /// <param name="czid"></param>
       public int GetShenPiStatus(String czid)
       {
           int result = -1;                 //表示没有开始审批
           DataRow dr = this.GetShenPiInfo("spstatus", czid, "0");
           if (dr != null && dr["spstatus"].ToString().Trim()!=String.Empty)
           {
               result = int.Parse(dr["spstatus"].ToString().Trim());
           }
           return result;
       }


        /// <summary>
        /// 计算资产处置的累计回款
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public double GetHuiKuan(String id,ZCKind kind1)
       {
           double sum1 = 0;
           CommTable com1 = new CommTable();
           List<SearchField> condition = new List<SearchField>();
           if (kind1 == ZCKind.单条资产)
           {
               com1.TabName = "CW_ShouKuan";
               condition.Add(new SearchField("zcid", id, SearchFieldType.数值型));
           }
           else
           {
               com1.TabName = "CW_ShouKuan1";
               condition.Add(new SearchField("bid", id, SearchFieldType.数值型));
           }
           condition.Add(new SearchField("checktime is not null", "", SearchOperator.用户定义));
           DataSet ds1 = com1.SearchData("isnull(pbj,0)+isnull(plx,0) as sum0", condition);
           foreach (DataRow dr in ds1.Tables[0].Rows)
           {
               sum1 = sum1 + double.Parse(dr["sum0"].ToString());
           }
           com1.Close();
           return sum1;
       }

        /// <summary>
        /// 计算资产处置的累计支持
        /// </summary>
        /// <param name="czid"></param>
        /// <returns></returns>
       public double GetZhiChu(String id, ZCKind kind1)
       {
           double sum1 = 0;
           CommTable com1 = new CommTable();
           List<SearchField> condition = new List<SearchField>();
           if (kind1 == ZCKind.单条资产)
           {
               com1.TabName = "CW_Pay";
               condition.Add(new SearchField("zcid", id, SearchFieldType.数值型));
           }
           else
           {
               com1.TabName = "CW_Pay1";
               condition.Add(new SearchField("bid", id, SearchFieldType.数值型));
           }
           condition.Add(new SearchField("checktime is not null", "", SearchOperator.用户定义));
           String fields = @"isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)
                            +isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)
                            +isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0) 
                            +isnull(fee13,0)+isnull(fee14,0)+isnull(fee15,0)+isnull(fee16,0)
                            +isnull(fee17,0)+isnull(fee18,0)+isnull(fee19,0)+isnull(fee20,0) as sum0";

           DataSet ds1 = com1.SearchData(fields, condition);
           foreach (DataRow dr in ds1.Tables[0].Rows)
           {
               sum1 = sum1 + double.Parse(dr["sum0"].ToString());
           }
           com1.Close();
           return sum1;
       }
    }
}
