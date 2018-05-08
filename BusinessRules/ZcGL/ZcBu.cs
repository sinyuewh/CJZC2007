using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Web.UI.WebControls;
namespace JSJ.CJZC.Business
{
    public class ZcBu
    {
        public DataSet GetZcList(List<SearchField> condition)
        {
            return GetZcList(condition, false);
        }
        /// <summary>
       /// 根据条件，得到资产列表（排除掉资产包内的资产）
       /// </summary>
       /// <param name="condition"></param>
       /// <returns></returns>
        public DataSet GetZcList(List<SearchField> condition,bool AllZc)
        {
            String sql = null;
            if (AllZc == false)
            {
                sql = @"select distinct u_zc.id,num2,u_zc.danwei,bj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx ,zeren,zeren1,U_ZC2SearchView2.spstatus,
                            U_ZC2SearchView2.status1,U_ZC2SearchView2.status2,U_ZC2SearchView2.spresult,U_ZC2SearchView2.spdotime,
                            bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx 
                            from u_zc left outer join U_ZC2SearchView2 on U_ZC.id=U_ZC2SearchView2.zcid where not exists (select * from u_zcbaoinfo where zcid=u_zc.id) ";
            }
            else
            {
                sql = @"select distinct u_zc.id,num2,u_zc.danwei,bj,isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) lx ,zeren,zeren1,U_ZC2SearchView2.spstatus,
                            U_ZC2SearchView2.status1,U_ZC2SearchView2.status2,U_ZC2SearchView2.spresult,U_ZC2SearchView2.spdotime,
                            bj+isnull(lx1,0)+isnull(lx2,0)+isnull(lx3,0) bjlx 
                            from u_zc left outer join U_ZC2SearchView2 on U_ZC.id=U_ZC2SearchView2.zcid where 1=1  ";
            }


            DataSet ds1 = null;
            CommTable comm = new CommTable();
            if (condition != null && condition.Count > 0)
            {
                String conditionStr = SearchField.GetSearchCondition(condition);
                if (String.IsNullOrEmpty(conditionStr) == false)
                {
                    sql = sql + " and " + conditionStr;
                }
            }

           
            sql = sql + " order by num2 ";
            //Comm.Print(sql);

            ds1=comm.TableComm.SearchData(sql);
            comm.Close();
            return ds1;
        }

        /// <summary>
        /// 根据条件，得到资产包列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataSet GetZcBaoList(List<SearchField> condition)
        {

            String sql = @"select * from zcbaoView3 left outer join U_ZC2BaoSearchView2 on zcbaoView3.id=U_ZC2BaoSearchView2.zcbid";
;

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

            //Comm.Print(sql);

            ds1 = comm.TableComm.SearchData(sql);
            comm.Close();
            return ds1;
        }
    }
}
