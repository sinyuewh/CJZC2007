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
    /// <summary>
    /// 定义查询的数据结构
    /// </summary>
    public class SearchStruct
    {
        public String xmmc;         //项目名称
        public String xmsbh;        //项目申报号
        public String num2;         //档案号 
        public String danwei;       //单位名称
        public String spstatus;     //项目审批状态
        public String spresult;     //方案执行结果
        public String status1;      //方案执行状态1
        public String status2;      //方案执行状态2
        public String zckind;       //资产类别
        public String time1;        //会议时间1
        public String time2;        //会议时间2
    }

    public class ShenPi
    {
        public String YiJian;
        public String Ren;
        public String ShiJian;
    }
    /// <summary>
    /// 方案审批业务处理类
    /// </summary>
    public class U_FASPBU
    {
        #region 得到处理意见
        /// <summary>
        /// 得到部门审批得处理意见
        /// </summary>
        /// <param name="czid"></param>
        /// <returns></returns>
        public ShenPi GetBuMenYiJian(String czid)
        {
            return this.GetYiJian(czid,"11");
        }


        //得到评审员意见
        public ShenPi GetPSYYiJian(String czid)
        {
            return this.GetYiJian(czid, "17");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="czid"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        private ShenPi GetYiJian(String czid,String kind)
        {
            ShenPi info1 = null;
            CommTable comm1 = new CommTable();
            comm1.TabName = "U_ZCSP";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("czid", czid));
            condition.Add(new SearchField("kind", kind));
            condition.Add(new SearchField("pscount", "0", SearchOperator.大于));
            condition.Add(new SearchField("time1 is not null", "", SearchOperator.用户定义));
            DataSet ds = comm1.SearchData("top 1 zeren,PS,remark,time1", condition, "id desc");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                info1 = new ShenPi();
                info1.Ren = ds.Tables[0].Rows[0]["zeren"].ToString();
                info1.ShiJian = ds.Tables[0].Rows[0]["time1"].ToString();
                String temp1 = ds.Tables[0].Rows[0]["PS"].ToString().Trim();
                String temp2 = ds.Tables[0].Rows[0]["remark"].ToString().Trim();
                if (temp2 != String.Empty && kind!="11" && kind!="17")
                {
                    info1.YiJian = temp1 + "(" + temp2 + ")";
                }
                else
                {
                    info1.YiJian = temp1;
                }
            }
            comm1.Close();
            return info1;
        }
        #endregion

        /// <summary>
        /// 根据查询条件，得到查询结果
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiListBySearchCondition(
            String xmmc, String num1, String danwei,
            String status, String time0, String time1,String status1,String status2)
        {
            List<SearchField> condition = new List<SearchField>();
            if (xmmc != String.Empty)
            {
                condition.Add(new SearchField("xmmc", xmmc, SearchOperator.包含));
            }
            if (num1 != String.Empty)
            {
                condition.Add(new SearchField("num2", num1));
            }
            if (danwei != String.Empty)
            {
                condition.Add(new SearchField("danwei", danwei, SearchOperator.包含));
            }
            if (status != String.Empty)
            {
                condition.Add(new SearchField("spstatus", status));
            }

            if (time0 != String.Empty)
            {
                condition.Add(new SearchField("shijian1", time0, SearchOperator.大于等于));
            }

            if (time1 != String.Empty)
            {
                condition.Add(new SearchField("shijian1", time1, SearchOperator.小于等于));
            }

            if (status1 != String.Empty)
            {
                condition.Add(new SearchField("status1", status1));
            }

            if (status2 != String.Empty)
            {
                condition.Add(new SearchField("status2", status1));
            }

            //设置查询范围
            U_RolesBU role1 = new U_RolesBU();
            bool isAllCanSee = role1.isRole(new string[] { "公司领导", "评审部角色", "综合管理", "会计", "出纳", "领导秘书" });
            role1.Close();
            //1)公司领导、会计、出纳、领导秘书 可查询所有的项目
            if (isAllCanSee==false)
            {
                //普通的用户只能查询自己负责（或下属负责的项目）
                List<SearchField> condition1 = new List<SearchField>();
                U_UserNameBU user1 = new U_UserNameBU();
                String userName1 = user1.GetSelfAndXiaShu(Comm.CurUser);
                user1.Close();
                if (userName1 != String.Empty)
                {
                    condition.Add(new SearchField("zeren", userName1, SearchOperator.集合));
                }     
            }
           
            return this.GetShenPiList(condition);
        }

        public DataSet GetShenPiListBySearchCondition(SearchStruct searchinfo)
        {
            DataSet ds1 = null;
           
            List<SearchField> condition = new List<SearchField>();

            //去掉没有审批记录的数据
            //2010-3-22日调整
            SearchField search0 = new SearchField(" exists (select * from u_zcsp where u_zcsp.czid=u_zc2.id ) ", "", SearchOperator.用户定义);
            condition.Add(search0);

            //项目名称
            if(String.IsNullOrEmpty(searchinfo.xmmc)==false)
            {
                condition.Add(new SearchField("xmmc", searchinfo.xmmc, SearchOperator.包含));
            }

            //项目申报号
            if (String.IsNullOrEmpty(searchinfo.xmsbh) == false)
            {
                condition.Add(new SearchField("xmsbh", searchinfo.xmsbh));
            }

            //项目档案号
            if (String.IsNullOrEmpty(searchinfo.num2) == false)
            {
                condition.Add(new SearchField("num2", searchinfo.num2));
            }

            //单位名称
            if (String.IsNullOrEmpty(searchinfo.danwei) == false)
            {
                condition.Add(new SearchField("danwei", searchinfo.danwei, SearchOperator.包含));
            }

            //项目审批状态
            if (String.IsNullOrEmpty(searchinfo.spstatus) == false)
            {
                condition.Add(new SearchField("spstatus", searchinfo.spstatus));
            }


            //项目执行结果
            if (String.IsNullOrEmpty(searchinfo.spresult) == false)
            {
                condition.Add(new SearchField("spresult", searchinfo.spresult));
            }

            //项目执行状态1
            if (String.IsNullOrEmpty(searchinfo.status1) == false)
            {
                condition.Add(new SearchField("status1", searchinfo.status1));
            }

            //项目执行状态2
            if (String.IsNullOrEmpty(searchinfo.status2) == false)
            {
                condition.Add(new SearchField("status2", searchinfo.status2));
            }

            //资产类别
            if (String.IsNullOrEmpty(searchinfo.zckind) == false)
            {
                if (searchinfo.zckind == "0")   //单条资产
                {
                    condition.Add(new SearchField("zcbid is null", "",SearchOperator.用户定义));
                }
                else
                {
                    condition.Add(new SearchField("zcbid is not null", "", SearchOperator.用户定义));
                }
            }

            //会议时间1
            if (String.IsNullOrEmpty(searchinfo.time1) == false)
            {
                condition.Add(new SearchField("cast(isnull(hysj2,hysj1) as datetime)", 
                    searchinfo.time1, SearchOperator.大于等于));
            }


            //会议时间2
            if (String.IsNullOrEmpty(searchinfo.time2) == false)
            {
                condition.Add(new SearchField("cast(isnull(hysj2,hysj1) as datetime)", 
                    searchinfo.time2, SearchOperator.小于等于));
            }

            //查询方案审批表
            //string sql = SearchField.GetSearchCondition(condition);
            //System.Web.HttpContext.Current.Response.Write(sql);

            CommTable com2 = new CommTable();
            com2.TabName = "U_ZC2";
            ds1 = com2.SearchData(@"*,cast(isnull(hysj2,hysj1) as datetime) hysj",condition,"num2");
            com2.Close();            

            return ds1;
        }

        /// <summary>
        /// 得到个人负责的资产处置表
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList1()
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zeren", Comm.CurUser));      
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// 得到我和我下属的资产列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList2()
        {
            List<SearchField> condition = new List<SearchField>();
            U_UserNameBU user1 = new U_UserNameBU();
            String userName1 = user1.GetSelfAndXiaShu(Comm.CurUser);
            user1.Close();
            if (userName1 != String.Empty)
            {
                condition.Add(new SearchField("zeren", userName1, SearchOperator.集合));
                condition.Add(new SearchField("exists(select * from u_zcsp where czid=u_zc2.id)","",SearchOperator.用户定义));

            }     
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// 得到公司的项目列表
        /// "公司领导", "会计", "会计"
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList3()
        {
            U_RolesBU role1 = new U_RolesBU();
            bool isAllCanSee = role1.isRole(new string[] { "公司领导", "综合管理", "评审部角色", "会计", "出纳", "领导秘书" });
            role1.Close();
            List<SearchField> condition = new List<SearchField>();
            if (isAllCanSee)
            {
                condition.Add(new SearchField("id>1","",SearchOperator.用户定义));     
            }
            else
            {
                condition.Add(new SearchField("id", "-1"));
            }

            //增加了方案提交审批的要求（11年7月5日调整）
            condition.Add(new SearchField("exists(select * from u_zcsp where czid=u_zc2.id)", "", SearchOperator.用户定义));
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// 得到需要我审批的项目列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList4()
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id and  time1 is null and zeren='"+Comm.CurUser+"' )", "",SearchOperator.用户定义));     
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// 得到我审批过的项目列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList5()
        {
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id and  time1 is not null and zeren='" + Comm.CurUser + "' )", "", SearchOperator.用户定义));
            return this.GetShenPiList(condition);
        }


        /// <summary>
        /// 得到领导秘书的办公栏目
        /// </summary>
        /// <returns></returns>
        public DataSet GetShenPiList6()
        {              
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("not exists ( select * from U_ZCSP where CZID=U_ZC2.id and ps='同意' and zx is not null and (kind='13' or kind='15' ) )", "", SearchOperator.用户定义));
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id )", "", SearchOperator.用户定义));
            return this.GetShenPiList(condition);
            
        }

        
        /// <summary>
        /// 得到特定条件的资产审批数据
        /// </summary>
        /// <param name="condition">特定的查询条件</param>
        /// <returns></returns>
        public DataSet GetShenPiList(List<SearchField> condition)
        {
            CommTable comm1 = new CommTable("U_ZC2");
            List<SearchField> condition1 = new List<SearchField>();
            if (condition != null)
            {
                foreach (SearchField search1 in condition)
                {
                    condition1.Add(search1);
                }
            }

            DataSet ds1 = comm1.SearchData("*,isNull(num2,'未编号') num3 ", condition1,"num2");
            comm1.Close();
            return ds1;
        }
        
        /// <summary>
        /// 根据条件，得到选择的资产
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataSet GetSelectZcList(List<SearchField> condition)
        {
            CommTable com1 = new CommTable();
            com1.TabName = "ZCView";
            List<SearchField> condition1 = new List<SearchField>();
            if (condition != null)
            {
                foreach (SearchField search1 in condition)
                {
                    condition1.Add(search1);
                }
            }
            condition1.Add(new SearchField("zeren", Comm.CurUser));

            /* 
             * 增加不在资产包的条件(2010年1月2日修改 */
            SearchField search2=new SearchField("not exists (select * from u_zcbaoinfo where zcid=zcView.id)","",SearchOperator.用户定义);
            condition1.Add(search2);

            DataSet ds = com1.SearchData("*,left(danwei,20) as danwei1", condition1, "num2");
            com1.Close();
            return ds;
        }


        /// <summary>
        /// 得到资产审批表的默认信息1
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public Hashtable GetInfo1(String zcid)
        {
            Hashtable ht = new Hashtable();
            CommTable com1 = new CommTable();
            String sql = @"select zcview.num2,zcview.depart,zcview.zeren,zcview.danwei,
                            bxhj lixi,bj benjin,hjbx zqce,
                            bzrmc from ZcView left outer
                            join U_zc1 on zcview.id=u_zc1.id where zcview.id="
                            + zcid + " and zcview.zeren='" + Comm.CurUser + "'";
            //JSJ.SysFrame.Util.Print(sql);
            DataSet ds1 = com1.TableComm.SearchData(sql);
            //得到保证单位
            com1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for(int i=0;i<ds1.Tables[0].Columns.Count;i++)
                {
                    String key1 = ds1.Tables[0].Columns[i].ColumnName.ToLower();
                    object value1 = ds1.Tables[0].Rows[0][key1];
                    ht.Add(key1, value1.ToString().Trim());
                }
                
            }
            return ht;
        }


        /// <summary>
        /// 得到资产审批表的信息1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hashtable GetInfo2(String id)
        {
            Hashtable ht = new Hashtable();
            CommTable com1 = new CommTable();
            String sql = @"select * from U_Zc2 where id="+id;
            DataSet ds1 = com1.TableComm.SearchData(sql);
            //得到保证单位
            com1.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Columns.Count; i++)
                {
                    String key1 = ds1.Tables[0].Columns[i].ColumnName.ToLower();
                    object value1 = ds1.Tables[0].Rows[0][key1];
                    ht.Add(key1, value1);
                }
            }
            return ht;
        }

        /// <summary>
        /// 增加新的资产审批表数据
        /// </summary>
        /// <param name="data"></param>
        public int InsertData(Hashtable data)
        {
            int zcid = 0;
            CommTable com1 = new CommTable("U_ZC2");
            
            com1.TableConnect.BeginTrans();
            try
            {
                com1.InsertData(data);
                String sql = "select @@identity as zcid";
                DataSet ds=com1.TableComm.SearchData(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    zcid=int.Parse(ds.Tables[0].Rows[0]["zcid"].ToString());
                }
                com1.TableConnect.CommitTrans();
            }
            catch (Exception err)
            {
                com1.TableConnect.RollBackTrans();
            }
            com1.Close();
            return zcid;
        }


        /// <summary>
        /// 修改审批表数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public void  EditData(Hashtable data,String id)
        {
            CommTable com1 = new CommTable("U_ZC2");
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id));
            com1.EditQuickData(condition, data);
            com1.Close();
        }
    }
}
