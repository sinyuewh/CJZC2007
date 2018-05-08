using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web;
using System.Data.SqlClient;

namespace JSJ.CJZC.Business
{
    public enum SP
    {
        开始审批 = 4, 部门审批 = 11,
        机要室编号 = 12, 审核委员会审批 = 13,
        审核委员会同意 = 14, 决策委员会审批 = 15,
        决策委员会同意 = 16, 评审员审批 = 17
    };

    /// <summary>
    /// 用户业务处理类
    /// </summary>
    public class U_ZCSPBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZCSP";
        private CommTable tabCommand = null;
        string CurrentUser = null;
        #endregion

        #region 构造函数
        public U_ZCSPBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public U_ZCSPBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法

        /// <summary>
        /// 得到以为的资产审批列表
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public DataSet GetHistoryZcSp(string zcid)
        {
            string st1=(int)SP.审核委员会同意+"";
            string st2=(int)SP.决策委员会同意+"";
            string sql = "select * from u_zc2 where zcid=" + zcid + " and (status='"+st1+"' or status='"+st2+"') order by id desc";
            return this.tabCommand.TableComm.SearchData(sql);
        }

        /// <summary>
        /// 责任责任人执行【送部门审批】功能
        /// </summary>
        /// <param name="czid">资产处置ID</param>
        /// <returns></returns>
        public string PiYueZcForDepart(string czid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string err1 = null;
                bool flag = this.GetNoEndSPByCZID(czid);
                if (flag == false)
                {
                    err1 = "错误提示：存在未处理的批阅环节，不能进行新的审批流程！";
                }
                else
                {
                    string leader=null;
                    String zeren = this.GetZeren(czid);
                    if (String.IsNullOrEmpty(zeren) == false)
                    {
                        U_UserNameBU user1 = new U_UserNameBU();
                        leader = user1.GetDirLeader(zeren);
                        user1.Close();
                    }
                    if (leader == null || leader.Trim() == "")
                    {
                        err1 = "错误信息：你所在的部门没有定义部门主管，无法批阅！";
                    }
                    else
                    {
                        err1 = this.SendSPPerson(leader, czid, SP.部门审批);
                    }
                }
                this.tabCommand.TableConnect.CommitTrans();
                return err1;
            }
            catch(Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
        }


        /// <summary>
        /// 得到某资产处置CZID的责任人
        /// </summary>
        /// <param name="czid"></param>
        /// <returns></returns>
        private String GetZeren(String czid)
        {
            String userid = null;
            CommTable com1 = new CommTable();
            com1.TabName = "U_ZC2";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", czid, SearchFieldType.数值型));
            DataSet ds1 = com1.SearchData("zeren", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds1.Tables[0].Rows[0];
                userid = dr["zeren"].ToString();
            }
            com1.Close();
            return userid;
        }

        //功能：设置批次信息
        public void SetPC(ListControl drop1, string czid)
        {
            string sql = "select pscount from U_ZCSP where czid=" + czid + "group by pscount";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = ds1.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    ListItem list0 = new ListItem(ds1.Tables[0].Rows[i][0].ToString(), ds1.Tables[0].Rows[i][0].ToString());
                    drop1.Items.Add(list0);
                }
            }
            ListItem list = new ListItem("全部", "");
            drop1.Items.Add(list);
        }


        #region 资产审批
        /// <summary>
        /// 部门审批资产
        /// </summary>
        /// <param name="spid">资产ID</param>
        /// <param name="ht">审批数据</param>
        /// <returns></returns>
        public string PiYueZcForOffice(string spid, Hashtable ht,out String czid)
        {
            czid = "";
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zeren = role1.GetRoleAllUsers("资产评审员");
                role1.Close();

                if (zeren.Trim() != "无")
                {
                    czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "同意")
                    {
                        string temp = this.SendSPPerson((zeren.Split(','))[0], czid, SP.评审员审批);
                        if (temp == null)
                        {
                            info1 = "提示：批阅资产完成，已转评审员审批！";
                        }
                        else
                        {
                            info1 = "提示：操作失败，请重新提交审批！";
                        }
                    }
                    else
                    {
                        info1 = " 提示：批阅资产完成，已退回责任人！";
                    }
                }
                else
                {
                    info1 = "提示：批阅资产失败，没有定义【评审员】的人选！";
                }
                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
        }


        /// <summary>
        /// 评审员批阅资产
        /// </summary>
        /// <param name="spid">资产ID</param>
        /// <param name="ht">审批数据</param>
        /// <returns></returns>
        public string PiYueZcForPingShenYuan(string spid, Hashtable ht, out String czid)
        {
            /*
            czid = "";
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zeren = role1.GetRoleAllUsers("机要室登记人员");
                role1.Close();

                if (zeren.Trim() != "无")
                {
                    czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "同意")
                    {
                        string temp = this.SendSPPerson((zeren.Split(','))[0], czid, SP.机要室编号);
                        if (temp == null)
                        {
                            info1 = "提示：批阅资产完成，已转办公室编号处理！";
                        }
                        else
                        {
                            info1 = "提示：操作失败，请重新提交审批！";
                        }
                    }
                    else
                    {
                        info1 = " 提示：批阅资产完成，已退回责任人！";
                    }
                }
                else
                {
                    info1 = "提示：批阅资产失败，没有定义【机要室登记人员】的人选！";
                }
                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }*/

            czid = ht["czid"].ToString();
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //修改资产审批表中的“项目申报号”
                string xmsbh = ht["xmsbh"].ToString();    //项目申报号；
                string czid1 = ht["czid"].ToString();   //资产处置Id
                this.tabCommand.TabName = "U_Zc2";
                List<SearchField> list0 = new List<SearchField>();
                list0.Add(new SearchField("id", czid1, SearchFieldType.数值型));
                Hashtable ht0 = new Hashtable();
                ht0["xmsbh"] = xmsbh;
                this.tabCommand.EditQuickData(list0, ht0);
                this.tabCommand.TabName = TabName;

                ht.Remove("xmsbh");
                ht.Remove("czid");
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string sname1 = role1.GetRoleAllUsers("资产审核委员会");
                string sname2 = role1.GetRoleAllUsers("审核委员会主席");
                role1.Close();

                if (sname1.Trim() == "无" || sname2.Trim() == "无")
                {
                    info1 = "提示：批阅资产失败，没有定义【资产审核委员会】和【审核委员会主席】的人选！";
                }
                else
                {
                    string zeren = sname1 + "," + sname2;
                    czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "同意")
                    {
                        string temp = this.SendSPPerson(zeren, czid, SP.审核委员会审批);
                        if (temp == null)
                        {
                            info1 = "提示：批阅资产完成，已转审核委员会审批！";
                        }
                        else
                        {
                            info1 = "提示：操作失败，请重新提交审批！";
                        }
                    }
                    else
                    {
                        info1 = " 提示：批阅资产完成，已退回责任人！";
                    }

                }

                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
        }

        /// <summary>
        /// 批阅资产（办公室主任执行批阅）
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public string PiYueZcForSHWeiYuan(string spid, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //修改资产审批表中的“项目申报号”
                string xmsbh=ht["xmsbh"].ToString();    //项目申报号；
                string czid1 = ht["czid"].ToString();   //资产处置Id
                this.tabCommand.TabName = "U_Zc2";
                List<SearchField> list0 = new List<SearchField>();
                list0.Add(new SearchField("id", czid1, SearchFieldType.数值型));
                Hashtable ht0=new Hashtable();
                ht0["xmsbh"]=xmsbh;
                this.tabCommand.EditQuickData(list0, ht0);
                this.tabCommand.TabName = TabName;

                ht.Remove("xmsbh");
                ht.Remove("czid");
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string sname1 = role1.GetRoleAllUsers("资产审核委员会");
                string sname2 = role1.GetRoleAllUsers("审核委员会主席");
                role1.Close();

                if (sname1.Trim() == "无" || sname2.Trim() == "无")
                {
                    info1 = "提示：批阅资产失败，没有定义【资产审核委员会】和【审核委员会主席】的人选！";
                }
                else
                {
                    string zeren = sname1 + "," + sname2;
                    string czid = this.PiYue(spid, ht);
                    if (ht["ps"].ToString() == "同意")
                    {
                        string temp = this.SendSPPerson(zeren, czid, SP.审核委员会审批);
                        if (temp == null)
                        {
                            info1 = "提示：批阅资产完成，已转审核委员会审批！";
                        }
                        else
                        {
                            info1 = "提示：操作失败，请重新提交审批！";
                        }
                    }
                    else
                    {
                        info1 = " 提示：批阅资产完成，已退回责任人！";
                    }
                    
                }

                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch(Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
        }

        /// <summary>
        /// （审核委员会和审核委员会主席执行批阅）
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public string PiYueZcForSH1(string spid, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string sname1 = role1.GetRoleAllUsers("公司决策委员会");
                string sname2 = role1.GetRoleAllUsers("决策委员会主席");

                string zx1 = role1.GetRoleAllUsers("审核委员会主席");
                role1.Close();

                if (sname1.Trim() == "无" || sname2.Trim() == "无")
                {
                    info1 = "提示：批阅资产失败，没有定义【公司决策委员会】和【决策委员会主席】的人选！";
                }
                else
                {
                    string zeren = sname1 + "," + sname2;
                    string czid = this.PiYue(spid, ht);

                    if (ht["zeren"].ToString() == zx1)
                    {
                        if (ht["ps"].ToString() == "送决策委员会")
                        {
                            string temp = this.SendSPPerson(zeren, czid, SP.决策委员会审批);
                            if (temp == null)
                            {
                                info1 = "提示：批阅资产完成，已转决策委员会审批！";
                            }
                            else
                            {
                                info1 = "提示：操作失败，请重新提交审批！";
                            }
                        }
                        else if (ht["ps"].ToString() == "同意")
                        {
                            //设置资产的状态为1

                            info1 = " 提示：批阅资产已完成！";
                        }
                        else
                        {
                            info1 = " 提示：批阅资产完成，已退回责任人！";
                        }
                    }
                    else
                    {
                        info1 = "提示：批阅资产完成，等待【审核委员会主席】裁决！";
                    }
                }

                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
        }
        #endregion

        

        //批阅资产（决策委员会和决策委员会主席执行批阅）
        public string PiYueZcForSH2(string spid, Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zx1 = role1.GetRoleAllUsers("决策委员会主席");
                role1.Close();
  
                string czid = this.PiYue(spid, ht);
                if (ht["zeren"].ToString() == zx1)
                {
                    if (ht["ps"].ToString() == "同意")
                    {
                        info1 = " 提示：批阅资产已完成！";
                    }
                    else
                    {
                        info1 = " 提示：批阅资产完成，已退回责任人！";
                    }
                }
                else
                {
                    info1 = "提示：批阅资产完成，等待【决策委员会主席】裁决！";
                }
                
                this.tabCommand.TableConnect.CommitTrans();
                return info1;
            }
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
        }

        //得到多数人的审批意见
        public string GetManyYJ(string czid, string kind)
        {
            string yj = "";
            string sql = "select Ps from " + TabName + " where czid=" + czid + " and kind='" + kind + "' group by PS order by count(*) desc ";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                yj = ds1.Tables[0].Rows[0][0].ToString();
            }
            ds1.Dispose();
            return yj;
        }

        public bool GetNoEndSP(string zcid)
        {
            bool result = true;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField(" time1", "null", SearchOperator.空值));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = false;
            }
            return result;
        }

        public bool GetNoEndSPByCZID(string czid)
        {
            bool result = true;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            list1.Add(new SearchField(" time1", "null", SearchOperator.空值));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 得到当前没有批阅完成的审批个数
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public int GetNoEndSPCount(string zcid)
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField(" time1", "null", SearchOperator.空值));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows.Count;
            }
            return result;
        }

        /// <summary>
        /// 得到当前没有批阅完成的审批个数
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public int GetNoEndBSPCount(string zcid)
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            this.tabCommand.TabName = "U_ZCBSP";
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField(" time1", "null", SearchOperator.空值));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows.Count;
            }
            this.tabCommand.TabName = TabName;
            return result;
        }

        //删除审批
        public void DelSp(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
        }


        //得到资产审批列表
        public DataSet GetZcSPList(string czid, string kind)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", kind));
            list1.Add(new SearchField("pscount", "0", SearchOperator.大于));

            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = i + 1;
            }
            //Util.Print(ds1.Tables[0].Rows.Count.ToString()+"czid="+czid+"kind="+kind);

            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //得到资产审批列表
        public DataSet GetZcBSPList(string czid, string kind)
        {
            this.tabCommand.TabName = "ZCSP1View";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", kind));
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = i + 1;
            }
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        //得到资产审批列表
        public DataSet GetZcSPListByPC(string czid, string PC)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            if (PC != "")
            {
                list1.Add(new SearchField("pscount", PC));
            }
            DataSet ds1 = this.tabCommand.SearchData("*", list1, "id");
            ds1.Tables[0].Columns.Add("num");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ds1.Tables[0].Rows[i]["num"] = i + 1;
            }
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //判断会员是否审批
        public bool GetSPInfo(string zcid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("time1", "null", SearchOperator.空值));
            list1.Add(new SearchField("zx", "null", SearchOperator.空值));
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //得到审批意见1
        public DataSet GetZcSPRemark(string czid, SP sp1)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", czid, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", (int)sp1 + ""));
            DataSet ds1 = this.tabCommand.SearchData("id,remark,time1,time0,zeren,ps", list1, "id desc");
            this.tabCommand.TabName = TabName;
            return ds1;
        }

        //得到审批意见2
        public DataSet GetZcSPRemark1(string zcid, SP sp1)
        {
            this.tabCommand.TabName = "ZCSPView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.数值型));
            list1.Add(new SearchField("kind", (int)sp1 + ""));
            DataSet ds1 = this.tabCommand.SearchData("id,remark,time1,time0", list1, "id");
            this.tabCommand.TabName = TabName;
            return ds1;
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 核心方法1－批阅资产（调用时，必须起用事务）
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        private string PiYue(string spid, Hashtable ht)
        {
            string czid = "";
            List<SearchField> list1 = new List<SearchField>();

            //修改批阅数据中的相关信息
            list1.Add(new SearchField("id", spid, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            czid = ds1.Tables[0].Rows[0]["czid"].ToString();    //得到资产审批单中的ID数据
            String zeren1 = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DictionaryEntry item in ht)
                {
                    if (item.Key.ToString().ToLower() != "zeren")
                    {
                        if (ds1.Tables[0].Columns.Contains(item.Key.ToString().ToLower()))
                        {
                            ds1.Tables[0].Rows[0][item.Key.ToString()] = item.Value;
                        }
                    }
                    else
                    {
                        zeren1 = ds1.Tables[0].Rows[0]["zeren"].ToString();
                    }
                }
                ht["zeren"] = zeren1;
                this.tabCommand.Update(ds1);
            }


            //修改资产中相关的数据
            if(ds1.Tables[0].Rows.Count>0)
            {
                //审批状态
                String status = ds1.Tables[0].Rows[0]["kind"].ToString();
                
                //审批标志
                int flag = 0;
                if (ds1.Tables[0].Rows[0]["ps"].ToString().Trim() == "同意")
                {
                    flag = 0;
                }
                else if (ds1.Tables[0].Rows[0]["ps"].ToString().Trim() == "不同意")
                {
                    flag = 1;
                }
                else
                {
                    flag = 2;
                }

                //审批主席标志
                bool ZhuXi = false;
                if (ds1.Tables[0].Rows[0]["zx"].ToString().Trim() == "1")
                {
                    ZhuXi = true;
                }

                String spstatus = "0";
                if (ZhuXi && ds1.Tables[0].Rows[0]["ps"].ToString().Trim() == "同意")
                {
                    if (ds1.Tables[0].Rows[0]["kind"].ToString().Trim() == "13")
                    {
                        spstatus = "1";
                    }

                    if (ds1.Tables[0].Rows[0]["kind"].ToString().Trim() == "15")
                    {
                        spstatus = "2";
                    }
                }

                String newStatus = this.GetShenPiStatus(status, flag, ZhuXi);
                if (newStatus != null)
                {
                    //更改资产的状态 (2010年调整）
                    list1.Clear();
                    string zcid = ds1.Tables[0].Rows[0]["zcID"].ToString();
                    if (String.IsNullOrEmpty(zcid) == false)
                    {
                        this.tabCommand.TabName = "U_ZC";
                        list1.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                        DataSet ds2 = this.tabCommand.SearchData("id,status", list1);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {

                            ds2.Tables[0].Rows[0]["status"] = newStatus;

                            this.tabCommand.Update(ds2);
                        }
                    }

                    //更改资产包的状态 (2010年新增）
                    string zcbid = ds1.Tables[0].Rows[0]["zcbID"].ToString();
                    if (String.IsNullOrEmpty(zcbid) == false)
                    {
                        this.tabCommand.TabName = "U_ZCBao";
                        list1.Add(new SearchField("id", zcbid, SearchFieldType.数值型));
                        DataSet ds2 = this.tabCommand.SearchData("id,bstatus", list1);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {

                            ds2.Tables[0].Rows[0]["bstatus"] = newStatus;

                            this.tabCommand.Update(ds2);
                        }
                    }


                    //修改资产审批的状态
                    list1.Clear();
                    if (String.IsNullOrEmpty(zcid)==false || String.IsNullOrEmpty(zcbid)==false )
                    {
                        this.tabCommand.TabName = "U_ZC2";
                        list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
                        Hashtable ht0 = new Hashtable();
                        ht0["status"] = newStatus;
                        if (spstatus != "0")
                        {
                            ht0["spstatus"] = spstatus;
                        }
                        this.tabCommand.EditQuickData(list1, ht0);
                        
                    }
                    this.tabCommand.TabName = TabName;
                }
            }
            return czid;
        }


        /// <summary>
        /// 根据审批的ID和意见标志，确定审批后的状态
        /// flag中0表示同意 1表示不同意 2转决策委员会
        /// </summary>
        /// <param name="status"></param>
        /// <param name="flag"></param>
        /// <param name="ZhuXi"></param>
        /// <returns></returns>
        private String GetShenPiStatus(String status,int flag,bool ZhuXi)
        {
            String result = null;
            switch (status)
            {
                case "11":
                    if (flag == 0)
                    {
                        result = "17";      //同意转评审员审批
                    }
                    else
                    {
                        result = "04";      //不同意重新提交
                    }
                    break;
                case "12":
                    result = "13";          //转审核委员会审批
                    break;
                case "13":
                    if (ZhuXi)              //只判断主席的意见
                    {
                        if (flag == 0)
                        {
                            result = "14";
                        }
                        else if (flag == 1)
                        {
                            result = "04";
                        }
                        else
                        {
                            result = "15";
                        }
                    }
                    break;
                case "15":
                    if (ZhuXi)              //只判断主席的意见
                    {
                        if (flag == 0)
                        {
                            result = "16";
                        }
                        else 
                        {
                            result = "04";
                        }
                    }
                    break;
                case "17":
                    if (flag == 0)
                    {
                        result = "12";
                    }
                    else
                    {
                        result = "04";
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 核心方法2－资产批阅方法
        /// </summary>
        /// <param name="zeren">责任人</param>
        /// <param name="czid">资产处置申报Id</param>
        /// <param name="sp1">处置流程</param>
        /// <returns></returns>
        private string SendSPPerson(string zeren, string czid, SP sp1)
        {
            string[] Person1 = zeren.Split(',');
            string zcid = null;     //资产的ID
            String zcbid = null;    //资产包的ID

            //1)根据资产处置ID得到资产ID
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZC2";
            DataSet ds0 = this.tabCommand.SearchData("id,zcid,zcbid,status,spstatus", list1);
            if (ds0.Tables[0].Rows.Count > 0)
            {
                zcid = ds0.Tables[0].Rows[0]["zcid"].ToString().Trim();
                zcbid = ds0.Tables[0].Rows[0]["zcbid"].ToString().Trim();
                ds0.Tables[0].Rows[0]["status"] = ((int)sp1).ToString().PadLeft(2, '0');
                if (sp1 == SP.部门审批)
                {
                    ds0.Tables[0].Rows[0]["spstatus"] = "0";
                }
                this.tabCommand.Update(ds0);        //更新U_ZC2中的状态数据
            }

            //2)同步更新资产U_ZC中的数据
            /*--------这里修改为资产和资产包的不同处理情况----------*/
            /*--------2010-1-3   金寿吉                  ----------*/
            if (String.IsNullOrEmpty(zcid) == false)
            {
                this.tabCommand.TabName = "U_ZC";
                list1.Clear();
                list1.Add(new SearchField("id", zcid));
                Hashtable ht0 = new Hashtable();
                ht0.Add("status", ((int)sp1).ToString().PadLeft(2, '0'));
                this.tabCommand.EditQuickData(list1, ht0);
            }

            if (String.IsNullOrEmpty(zcbid) == false)
            {
                this.tabCommand.TabName = "U_ZCBao";
                list1.Clear();
                list1.Add(new SearchField("id", zcbid));
                Hashtable ht0 = new Hashtable();
                ht0.Add("bstatus", ((int)sp1).ToString().PadLeft(2, '0'));
                this.tabCommand.EditQuickData(list1, ht0);
            }

            
            //3)在审批表中插入数据
            this.tabCommand.TabName = TabName;
            list1.Clear();
            list1.Add(new SearchField("czid", czid));
            list1.Add(new SearchField("pscount", "0"));
            string result = null;
            try
            {
                //删除为0的审批记录
                //this.tabCommand.DeleteData(list1);

                //增加新的审批记录
                Hashtable ht1 = new Hashtable();
                ht1["czid"] = czid;     //资产处置ID
                if (String.IsNullOrEmpty(zcid) == false)
                {
                    ht1["zcid"] = zcid;     //资产ID
                }
                if (String.IsNullOrEmpty(zcbid) == false)
                {
                    ht1["zcbid"] = zcbid;   //资产包ID
                }
                //ht1["bid"] = zcbid;
                ht1["zeren"] = Person1;
                ht1["kind"] = ((int)sp1).ToString().PadLeft(2, '0');

                //保存审批数据
                U_ZCSPBU zcsp = new U_ZCSPBU();
                zcsp.SaveSP(ht1);
                zcsp.Close();
                
                ////发送电子邮件
                //ZX_Email1BU em1 = new ZX_Email1BU();
                //for (int i = 0; i < Person1.Length; i++)
                //{
                //    em1.SendToZcGL(Person1[i], "有需要你审批的资产，请注意及时审批！");
                //}
                //em1.Close();
            }
            catch(Exception err)
            {
                result = "提示：操作失败，请重新提交审批！";
            }
            return result;

        }

        /// <summary>
        /// 核心方法2－保存审批数据（调用时，必须起用事务）
        /// </summary>
        /// <param name="ht"></param>
        private void SaveSP(Hashtable ht)
        {
            //string zcid = ht["zcid"].ToString();
            string[] zeren = (string[])ht["zeren"];
            string kind = ht["kind"].ToString();
            SP SP1 = (SP)Int32.Parse(kind);
            
            //审核委员会主席和决策委员会主席只允许有一个人（否则会有问题）
            U_RolesBU role1 = new U_RolesBU();
            List<String> sname1 = role1.GetRoleAllUsersList1("决策委员会主席");
            List<String> sname2 = role1.GetRoleAllUsersList1("审核委员会主席");
            role1.Close();

            /*得到当前审批的“批次”
              审批的“批次”按当前“部门审批”的“批次”为准
              第一次部门审批时的批次为1 */

            this.tabCommand.TabName = TabName;
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("czid", ht["czid"].ToString(), SearchFieldType.数值型));
            string temp1 = (int)SP.部门审批 + "";
            list2.Add(new SearchField("kind", temp1.PadLeft(2, '0')));
            DataSet dstemp = this.tabCommand.SearchData("pscount", list2, "id desc");
            int pscount = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["pscount"] != DBNull.Value)
                {
                    pscount = (int)dstemp.Tables[0].Rows[0]["pscount"];
                }
            }
            if (kind == temp1)
            {
                pscount++;  //当前的批阅次数；
            }

            //增加审批的数据
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("czid", ht["czid"].ToString(), SearchFieldType.数值型));
            list1.Add(new SearchField("time1", "null", SearchOperator.空值));
            list1.Add(new SearchField("kind", kind));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            Hashtable ht1 = new Hashtable();

            for (int i = 0; i < zeren.Length; i++)
            {
                if (ht1.ContainsKey(zeren[i]) == false)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["czid"] = ht["czid"];
                    if (ht.ContainsKey("zcid"))
                    {
                        dr["zcid"] = ht["zcid"].ToString();
                    }
                    if (ht.ContainsKey("zcbid"))
                    {
                        dr["zcbid"] = ht["zcbid"].ToString();
                    }

                    dr["time0"] = DateTime.Now.ToString();
                    dr["kind"] = kind;
                    dr["zeren"] = zeren[i];
                    dr["pscount"] = pscount;


                    if ((sname1.Contains(zeren[i]) && SP1 == SP.决策委员会审批) 
                        || sname2.Contains(zeren[i]) && SP1 == SP.审核委员会审批)
                    {
                        dr["zx"] = "1";  //设置主席的标识
                    }

                    ds.Tables[0].Rows.Add(dr);
                    ht1.Add(zeren[i], zeren[i]);    //去掉重复的人选
                }
            }

            this.tabCommand.Update(ds);
            ds.AcceptChanges();
        }


        #endregion

        #region 决策支持(金寿吉)
        /// <summary>
        /// 得到资产审批的统计数据
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        /// <returns></returns>
        public DataSet GetZcSpStatic(DateTime dt1,DateTime dt2)
        {
            SqlParameter[] para1 = new SqlParameter[2];
            string sql = @"select distinct u_zc.zeren,U_Username.depart,
                            u_zcsp.kind,u_zcsp.zcid,
                            u_depart.num dnum, U_userName.num snum
                            from u_zcsp inner join u_zc
                            on u_zcsp.zcid=u_zc.id
                            inner join u_username on U_zc.zeren=u_UserName.sname
                            inner join u_depart on U_username.depart=u_depart.depart
                            where u_zcsp.time0>=@time0 and u_zcsp.time0<=@time1
                            
                            order by u_depart.num,U_userName.num";


            string t1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
            string t2 = dt2.ToString("yyyy-MM-dd") + " 23:59:59";

            if (dt1 != default(DateTime))
            {
                para1[0] = new SqlParameter("@time0", t1);
            }
            else
            {
                para1[0] = new SqlParameter("@time0", "2000-01-01");
            }
            if (dt2 != default(DateTime))
            {
                para1[1] = new SqlParameter("@time1", t2);
            }
            else
            {
                para1[1] = new SqlParameter("@time1", DateTime.Now.AddYears(1).ToString());
            }

            HttpContext.Current.Items["time0"] = dt1;
            HttpContext.Current.Items["time1"] = dt2;
            return this.tabCommand.TableComm.SearchData(sql,CommandType.Text,para1);
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

