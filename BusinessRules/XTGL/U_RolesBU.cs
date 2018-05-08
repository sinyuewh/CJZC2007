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
    /// ��ɫ����������
    /// ���룺���ټ�
    /// ʱ�䣺2007��8��5��
    /// </summary>
    public class U_RolesBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_Roles";
        private CommTable tabCommand = null;
        string CurrentUser = null;   //��ʾ��ǰ��¼���û���   
        #endregion

        #region ���캯��
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

        #region ҵ�񷽷�

        //���ܣ��жϵ�ǰ��¼�û��Ƿ�߱�ĳ�ֽ�ɫ
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
        /// �жϵ�ǰ�û��Ƿ���ж����ɫ��֮һ
        /// </summary>
        /// <param name="RoleName">���ɫ������</param>
        /// <returns>����ǣ��򷵻�true�����򷵻�false</returns>
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

        //���ܣ��������еĽ�ɫ
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

        //���ܣ�����ID���õ���ɫ����ϸ����
        public Hashtable GetRoleDetailByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            Hashtable ht = this.tabCommand.SearchData(list1);
            ht.Add("roleusers", this.GetRoleAllUsers(ht["role"].ToString()));
            return ht;
        }

        //���ܣ��õ�ĳ��ɫ�������û�
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
                result = "��";
            }
            return result;
        }

        /// <summary>
        /// �õ���ɫ�û��б����ظ���
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


        //���ܣ��õ�ĳ��ɫ�������û�
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

        //���ܣ�����ID����������ĳ����ɫ���û�
        public void SaveRoles(string id, Hashtable ht)
        {
            string roles = ht["roleusers"].ToString();
            ht.Remove("roleusers");

            //edit roles 
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            DataSet ds1 = this.tabCommand.SearchData("role,remark", list1);
            ds1.Tables[0].Rows[0]["remark"] = ht["remark"].ToString();
            this.tabCommand.Update(ds1);


            //�����û���ɫ
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

        //���ý�ɫ�û�
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

            if (value1 != "��" && value1 != "")
            {
                Util.setListControlByValue(chk1, value1, ',');
            }
        }
        #endregion

        #region ˽�з���
        //���ܣ��õ�ĳ��ɫ�û�������
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

        #region IDisposable ��Ա
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

