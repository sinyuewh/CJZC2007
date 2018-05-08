using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Web.UI.WebControls;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// 角色处理务处理类
    /// 编码：金寿吉
    /// 时间：2007年8月5日
    /// </summary>
    public class U_RolesBU : IDisposable
    {
        #region 属性定义
        private const string TabName = "U_Roles";
        private CommTable tabCommand = null;
        string CurrentUser = null;   //表示当前登录的用户名   
        #endregion

        #region 构造函数
        public U_RolesBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public U_RolesBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region 业务方法

        //功能：判断当前登录用户是否具备某种角色
        public bool isRole(string RoleName)
        {
            if (CurrentUser == "admin")
            {
                return true;
            }
            else
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("sname", CurrentUser));
                list1.Add(new SearchField("role", RoleName));
                this.tabCommand.TabName = "U_RoleUsers";
                DataSet ds1 = this.tabCommand.SearchData("id", list1);
                this.tabCommand.TabName = TabName;

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 判断当前用户是否具有多个角色中之一
        /// </summary>
        /// <param name="RoleName">多角色的数组</param>
        /// <returns>如果是，则返回true，否则返回false</returns>
        public bool isRole(string[] RoleName)
        {
            bool result = false;
            if (CurrentUser == "admin")
            {
                result = true; ;
            }
            else
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("sname", CurrentUser));
                SearchField search0 = null;
                foreach (String role in RoleName)
                {
                    SearchField temp = new SearchField("role", role);
                    if (search0 == null)
                    {
                        search0 = temp;
                    }
                    else
                    {
                        search0 = Comm.GetSearchFieldOR(search0, temp);
                    }
                }
                if (search0 != null)
                {
                    list1.Add(search0);
                }
                this.tabCommand.TabName = "U_RoleUsers";
                DataSet ds1 = this.tabCommand.SearchData("id", list1);
                this.tabCommand.TabName = TabName;

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        //功能：返回所有的角色
        public DataSet GetAllRoles()
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("*", list1, "num");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("xuhao");
                ds.Tables[0].Columns.Add("usercount");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["xuhao"] = (i + 1) + "";
                    ds.Tables[0].Rows[i]["usercount"] = this.GetRoleUserCount(ds.Tables[0].Rows[i]["role"].ToString());
                }
            }
            return ds;
        }

        //功能：根据ID，得到角色的详细资料
        public Hashtable GetRoleDetailByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            Hashtable ht = this.tabCommand.SearchData(list1);
            ht.Add("roleusers", this.GetRoleAllUsers(ht["role"].ToString()));
            return ht;
        }

        //功能：得到某角色的所有用户
        public string GetRoleAllUsers(string role)
        {
            string result = "";
            this.tabCommand.TabName = "U_RoleUsers";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("role", role));
            DataSet ds = this.tabCommand.SearchData("sname", list1, "num");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (result != "")
                {
                    result = result + ",";
                }
                result = result + ds.Tables[0].Rows[i][0].ToString();
            }
            this.tabCommand.TabName = TabName;
            if (result == "")
            {
                result = "无";
            }
            return result;
        }

        /// <summary>
        /// 得到角色用户列表（无重复）
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<String> GetRoleAllUsersList1(string role)
        {
            List<string> list1 = new List<string>();
            String sname1 = this.GetRoleAllUsers(role);
            if (String.IsNullOrEmpty(sname1) == false)
            {
                String[] arr1 = sname1.Split(',');
                foreach (String m in arr1)
                {
                    if (list1.Contains(m) == false)
                    {
                        list1.Add(m);
                    }
                }
            }
            return list1;
        }


        //功能：得到某角色的所有用户
        public string GetRoleAllUsersList(string role)
        {
            string result = "";
            this.tabCommand.TabName = "U_RoleUsers";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("role", role));
            DataSet ds = this.tabCommand.SearchData("sname", list1, "num");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (result != "")
                {
                    result = result + ",";
                }
                result = result + "'"+ds.Tables[0].Rows[i][0].ToString()+"'";
            }
            this.tabCommand.TabName = TabName;
            return result;
        }

        //功能：根据ID，重新设置某个角色的用户
        public void SaveRoles(string id, Hashtable ht)
        {
            string roles = ht["roleusers"].ToString();
            ht.Remove("roleusers");

            //edit roles 
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = this.tabCommand.SearchData("role,remark", list1);
            ds1.Tables[0].Rows[0]["remark"] = ht["remark"].ToString();
            this.tabCommand.Update(ds1);


            //调整用户角色
            if (roles != null)
            {
                this.tabCommand.TabName = "U_RoleUsers";
                list1.Clear();
                list1.Add(new SearchField("role", ds1.Tables[0].Rows[0]["role"].ToString()));
                DataSet ds2 = this.tabCommand.SearchData("*", list1);
                Util.DelDataSetData(ds2);
                String[] Aroles = roles.Split(',');
                for (int i = 0; i < Aroles.Length; i++)
                {
                    DataRow dr = ds2.Tables[0].NewRow();
                    dr["num"] = (i + 1) + "";
                    dr["sname"] = Aroles[i];
                    dr["role"] = ds1.Tables[0].Rows[0]["role"].ToString();
                    ds2.Tables[0].Rows.Add(dr);
                }
                this.tabCommand.Update(ds2);

                ds2.Dispose();
                this.tabCommand.TabName = TabName;
            }
            ds1.Dispose();
        }

        //设置角色用户
        public void SetRoleUsers(CheckBoxList chk1, string value1)
        {
            U_UserNameBU user1 = new U_UserNameBU();
            DataSet ds1 = user1.GetAllUserList();
            user1.Close();

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ListItem list1 = new ListItem(ds1.Tables[0].Rows[i]["sname"].ToString(), ds1.Tables[0].Rows[i]["sname"].ToString());
                chk1.Items.Add(list1);
            }

            if (value1 != "无" && value1 != "")
            {
                Util.setListControlByValue(chk1, value1, ',');
            }
        }
        #endregion

        #region 私有方法
        //功能：得到某角色用户的数量
        private int GetRoleUserCount(string role)
        {
            int result = 0;
            string sql = "select count(*) from U_RoleUsers where role='" + role + "'";
            DataSet ds = this.tabCommand.TableComm.SearchData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
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

