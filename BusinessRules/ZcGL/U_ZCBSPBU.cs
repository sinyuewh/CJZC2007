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

namespace JSJ.CJZC.Business
{
    //public enum SP
    //{
    //    开始审批 = 4, 部门审批 = 11,
    //    机要室编号 = 12, 审核委员会审批 = 13,
    //    审核委员会同意 = 14, 决策委员会审批 = 15,
    //    决策委员会同意 = 16
    //};

    /// <summary>
    /// 用户业务处理类
    /// </summary>
    public class U_ZCBSPBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_ZCBSP";
        private CommTable tabCommand = null;
        string CurrentUser = null;
        #endregion

        #region 构造函数
        public U_ZCBSPBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public U_ZCBSPBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法
        /// <summary>
        /// 责任人执行【送部门审批】功能
        /// </summary>
        /// <param name="czid">资产包处置ID</param>
        /// <returns></returns>
        public string PiYueZcBForDepart(string czid)
        {
            string err1 = null;
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                bool flag = this.GetNoEndSPByCZID(czid);
                if (flag == false)
                {
                    err1 = "错误提示：存在未处理的批阅环节，不能进行新的审批流程！";
                }
                else
                {
                    U_UserNameBU user1 = new U_UserNameBU();
                    string leader = user1.GetDirLeader();
                    user1.Close();
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
            catch (Exception errTrans)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return "【系统错误】：数据库事务处理发生错误，请重新提交！";
            }
            
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
        /// 核心方法2－资产批阅方法
        /// </summary>
        /// <param name="zeren">责任人</param>
        /// <param name="czid">资产处置申报Id</param>
        /// <param name="sp1">处置流程</param>
        /// <returns></returns>
        private string SendSPPerson(string zeren, string czid, SP sp1)
        {
            string[] Person1 = zeren.Split(',');
            string bid = null;     //资产的ID

            //根据资产处置ID得到资产ID
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZCB2";
            Hashtable ht0 = this.tabCommand.SearchData(list1);
            bid = ht0["bid"].ToString();

            U_ZCBAOBU zc1 = new U_ZCBAOBU();
            zc1.UpdateZcstatus(bid, ((int)sp1).ToString().PadLeft(2, '0'),"0");
            zc1.Close();

            this.tabCommand.TabName = TabName;
            string result = null;
            try
            {
                Hashtable ht1 = new Hashtable();
                ht1["bid"] = bid;
                ht1["czid"] = czid;
                ht1["zeren"] = Person1;
                ht1["kind"] = ((int)sp1).ToString().PadLeft(2, '0');
                this.SaveSP(ht1);
                
                ////发送电子邮件
                //ZX_Email1BU em1 = new ZX_Email1BU();
                //for (int i = 0; i < Person1.Length; i++)
                //{
                //    em1.SendToZcGL(Person1[i], "有需要你审批的资产包，请注意及时审批！");
                //}
                //em1.Close();
            }
            catch
            {
                result = "提示：操作失败，请重新提交审批！";
            }
            return result;

        }

        private void SaveSP(Hashtable ht)
        {
            string bid = ht["bid"].ToString();
            string[] zeren = (string[])ht["zeren"];
            string kind = ht["kind"].ToString();
            SP SP1 = (SP)Int32.Parse(kind);

            //更改资产的最新状态
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", bid, SearchFieldType.数值型));
            this.tabCommand.TabName = "U_ZCBAO";
            DataSet ds = this.tabCommand.SearchData("id,bstatus", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string status1 = ds.Tables[0].Rows[0]["bstatus"].ToString();
                if (kind.CompareTo(status1) > 0)
                {
                    ds.Tables[0].Rows[0]["bstatus"] = kind;
                    this.tabCommand.Update(ds);
                }
            }

            //审核委员会主席和决策委员会主席只允许有一个人（否则会有问题）
            U_RolesBU role1 = new U_RolesBU();
            string sname1 = role1.GetRoleAllUsers("决策委员会主席");
            string sname2 = role1.GetRoleAllUsers("审核委员会主席");
            role1.Close();

            this.tabCommand.TabName = TabName;
            //增加审批的数据

            Hashtable ht0 = new Hashtable();
            for (int i = 0; i < zeren.Length; i++)
            {
                list1.Clear();
                ds.Clear();

                list1.Add(new SearchField("bid", bid, SearchFieldType.数值型));
                list1.Add(new SearchField("zeren", zeren[i]));
                list1.Add(new SearchField("time1", "null", SearchOperator.空值));
                list1.Add(new SearchField("kind", kind));
                ds = this.tabCommand.SearchData("*", list1);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["bid"] = bid;
                    dr["czid"] = ht["czid"];
                    dr["time0"] = DateTime.Now.ToString();
                    dr["kind"] = kind;
                    dr["zeren"] = zeren[i];
                    //dr["pscount"] = pscount;
                    if ((zeren[i] == sname1 && SP1 == SP.决策委员会审批) || zeren[i] == sname2 && SP1 == SP.审核委员会审批)
                    {
                        dr["zx"] = "1";
                    }
                    ds.Tables[0].Rows.Add(dr);

                    //ht0["czid"] = ht["czid"];
                    //ht0["bid"] = bid;
                    //ht0["time0"] = DateTime.Now.ToString();
                    //ht0["kind"] = kind;
                    //ht0["zeren"] = zeren[i];
                    //if ((zeren[i] == sname1 && SP1 == SP.决策委员会审批) || zeren[i] == sname2 && SP1 == SP.审核委员会审批)
                    //{
                    //    ht0["zx"] = "1";
                    //}
                    //this.tabCommand.InsertData(ht0);
                }
                this.tabCommand.Update(ds);
                ds.AcceptChanges();
            }
        }

        //删除审批
        public void DelSp(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list1);
        }

        /// <summary>
        /// 得到当前没有批阅完成的审批个数
        /// </summary>
        /// <param name="zcid"></param>
        /// <returns></returns>
        public int GetNoEndSPCount(string bid)
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bid", bid, SearchFieldType.数值型));
            list1.Add(new SearchField(" time1", "null", SearchOperator.空值));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows.Count;
            }
            return result;
        }

        //将信息复制到所有的资产
        public bool CopyZcBCzsbbtoZc(string bid, string id)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("bid", bid, SearchFieldType.数值型));
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
                this.tabCommand.TabName = "U_ZCB2";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("id", id, SearchFieldType.数值型));
                Hashtable ht = this.tabCommand.SearchData(list2);
                ht.Remove("id");
                ht.Remove("bid");
                this.tabCommand.TabName = "U_ZC2";
                if (ids != "")
                {
                    string[] str = ids.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        ht["zcid"] = str[i];
                        this.tabCommand.InsertData(ht);
                    }
                }
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch(Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        //将信息复制到所有的资产
        public bool CopyZcBCzczfstoZc(string bid, string id)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "U_ZCBAOInfo";
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("bid", bid, SearchFieldType.数值型));
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
                this.tabCommand.TabName = "U_ZCB21";
                List<SearchField> list2 = new List<SearchField>();
                list2.Add(new SearchField("id", id, SearchFieldType.数值型));
                Hashtable ht = this.tabCommand.SearchData(list2);
                ht.Remove("id");
                ht.Remove("bid");

                this.tabCommand.TabName = "U_ZC21";

                U_ZCBU zc1 = new U_ZCBU();
                if (ids != "")
                {
                    string[] str = ids.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        
                        ht["czid"] = zc1.GetCurrentZcCZbyID1(str[i])["zcczid"];
                        
                        ht["zcid"] = str[i];
                        this.tabCommand.InsertData(ht);
                    }
                }
                zc1.Close();
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch (Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                return false;
            }
        }

        //得到资产审批列表
        public DataSet GetZcSPList(string czid, string kind)
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


        //批阅资产（部门经理执行审批）
        public string PiYueZcForOffice(string spid, Hashtable ht,string bid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zeren = role1.GetRoleAllUsers("机要室登记人员");
                role1.Close();

                if (zeren.Trim() != "无")
                {
                    string czid = this.PiYue(spid, ht);

                    this.CopySPInfoToZC(bid, spid);

                    if (ht["ps"].ToString() == "同意")
                    {
                        string temp = this.SendSPPerson((zeren.Split(','))[0], czid, SP.机要室编号);
                        if (temp == null)
                        {
                            info1 = "提示：批阅资产完成，已转办公室审批！";
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
            }
        }


        //批阅资产（办公室主任执行批阅）
        public string PiYueZcForSHWeiYuan(string spid, Hashtable ht,string bid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                //修改资产审批表中的“项目申报号”
                string xmsbh = ht["xmsbh"].ToString();    //项目申报号；
                string czid1 = ht["czid"].ToString();   //资产处置Id
                this.tabCommand.TabName = "U_ZCB2";
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
                    string czid = this.PiYue(spid, ht);

                    this.CopySPInfoToZC(bid, spid);

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

        //批阅资产（审核委员会和审核委员会主席执行批阅）
        public string PiYueZcForSH1(string spid, Hashtable ht,string bid)
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

                    this.CopySPInfoToZC(bid, spid);

                    if (ht["zeren"].ToString() == zx1)
                    {
                        if (ht["ps"].ToString() == "送决策委员会")
                        {
                            string temp = this.SendSPPerson(zeren, czid, SP.决策委员会审批);
                            if (temp == null)
                            {
                                info1 = "提示：批阅资产完成，已转审核委员会审批！";
                            }
                            else
                            {
                                info1 = "提示：操作失败，请重新提交审批！";
                            }
                        }
                        else if (ht["ps"].ToString() == "同意")
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

        //批阅资产（决策委员会和决策委员会主席执行批阅）
        public string PiYueZcForSH2(string spid, Hashtable ht,string bid)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                string info1 = null;
                U_RolesBU role1 = new U_RolesBU();
                string zx1 = role1.GetRoleAllUsers("决策委员会主席");
                role1.Close();

                string czid = this.PiYue(spid, ht);

                this.CopySPInfoToZC(bid, spid);

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
            string zcspstatus = "";
            string czid = "";
            List<SearchField> list1 = new List<SearchField>();

            //修改批阅数据中的相关信息
            list1.Add(new SearchField("id", spid, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            czid = ds1.Tables[0].Rows[0]["czid"].ToString();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DictionaryEntry item in ht)
                {
                    ds1.Tables[0].Rows[0][item.Key.ToString()] = item.Value;
                }
                this.tabCommand.Update(ds1);
            }

            //修改资产中相关的数据
            int NewStatus = 0;                      //表示资产调整后的状态；
            list1.Clear();
            string bid = ds1.Tables[0].Rows[0]["bID"].ToString();
            this.tabCommand.TabName = "U_ZCBAO";
            list1.Add(new SearchField("id", bid, SearchFieldType.数值型));
            DataSet ds2 = this.tabCommand.SearchData("id,bstatus", list1);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                int curStatus = Int32.Parse(ds2.Tables[0].Rows[0]["bstatus"].ToString());//表示资产的当前状态；
                NewStatus = curStatus;

                SP curSP = (SP)curStatus;                             //资产当前状态的枚举值
                if (curStatus == 4) curStatus = 10;
                int NextStatus = curStatus + 1;         //表示资产的下一个状态
                int BeginStatus = (int)SP.开始审批;      //表示资产审批的开始状态


                //处理审核委员会和决策委员会主席的情况
                U_RolesBU role1 = new U_RolesBU();
                string zxname1 = role1.GetRoleAllUsers("审核委员会主席");
                bool zx1 = false;
                if (ht["zeren"].ToString() == zxname1)
                {
                    zx1 = true;
                }
                string zxname2 = role1.GetRoleAllUsers("决策委员会主席");
                bool zx2 = false;
                if (ht["zeren"].ToString() == zxname2)
                {
                    zx2 = true;
                }
                role1.Close();


                //根据资产的当前状况进行不同的处理
                if (ht["ps"].ToString() == "不同意")
                {
                    if (curSP == SP.部门审批
                        || (curSP == SP.审核委员会审批 && zx1)
                        || (curSP == SP.决策委员会审批 && zx2)
                        )
                    {
                        NewStatus = BeginStatus;    //回到原来的状态
                    }
                }
                else if (ht["ps"].ToString() == "同意")
                {
                    if (curSP == SP.部门审批
                        || curSP == SP.机要室编号
                        || (curSP == SP.审核委员会审批 && zx1)
                        || (curSP == SP.决策委员会审批 && zx2)
                        )
                    {
                        NewStatus = curStatus + 1;    //前进到下一个状态
                    }
                }
                else
                {
                    if (curSP == SP.审核委员会审批 && zx1)
                    {
                        NewStatus = curStatus + 1;    //前进到"决策委员会审批"
                    }
                }
                string sp1 = NewStatus + "";
                ds2.Tables[0].Rows[0]["bstatus"] = sp1.PadLeft(2, '0');
                this.tabCommand.Update(ds2);
            }

            this.tabCommand.TabName = TabName;
            //修改资产审批的状态
            zcspstatus = NewStatus + "";
            zcspstatus = zcspstatus.PadLeft(2, '0');
            list1.Clear();
            if (bid != "" && zcspstatus != "")
            {
                this.tabCommand.TabName = "U_ZCB2";
                list1.Add(new SearchField("id", czid, SearchFieldType.数值型));
                Hashtable ht0 = new Hashtable();
                ht0["status"] = zcspstatus;
                this.tabCommand.EditQuickData(list1, ht0);
                this.tabCommand.TabName = TabName;
            }

            U_ZCBAOBU zc1 = new U_ZCBAOBU();
            zc1.UpdateZcstatus(bid,zcspstatus , "0");
            zc1.Close();

            return czid;
        }

        private void CopySPInfoToZC(string bid,string spid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", spid, SearchFieldType.数值型));
            Hashtable ht = this.tabCommand.SearchData(list1);
            ht.Remove("bid");

            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            string ids = zcb1.GetZCIDByBID(bid);
            zcb1.Close();
            string[] str = ids.Split(',');
            U_ZCBU zc1 = new U_ZCBU();
            this.tabCommand.TabName = "U_ZCSP";
            for (int i = 0; i < str.Length; i++)
            {
                if (zc1.GetCurrentZcCZbyID1(str[i]) != null)
                {
                    string czid = zc1.GetCurrentZcCZbyID1(str[i])["zcczid"].ToString();
                    ht["zcid"] = str[i];
                    ht["czid"] = czid;
                    ht["PSCount"] = "0";
                    this.tabCommand.InsertData(ht);
                }
            }

            this.tabCommand.TabName = TabName;
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
