using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Configuration;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �û�ҵ������
    /// ���룺���ټ�
    /// ʱ�䣺2007��8��5��
    /// </summary>
    public class U_UserNameBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_UserName";
        private CommTable tabCommand = null;
        string CurrentUser = null;   //��ʾ��ǰ��¼���û��� 
        #endregion

        #region ���캯��
        public U_UserNameBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public U_UserNameBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="others"></param>
        public void SetOthersReaders(string UserID, String others)
        {
            String sql1 = "select OtherReaders from U_OthersReaders where UserID='" + UserID + "'";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                sql1 = "update U_OthersReaders set OtherReaders='" + others + "' where UserID='"  +UserID + "'";
            }
            else
            {
                sql1 ="Insert into  U_OthersReaders(Userid,OtherReaders) values ('"+UserID+"','"+others+"')";
            }
            this.tabCommand.TableComm.ExecuteNoQuery(sql1);
        }

        /// <summary>
        /// �õ������û��Ķ�����Ϣ
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public String GetOtherReader(String userID)
        {
            string result = String.Empty;
            if (String.IsNullOrEmpty(userID) == false)
            {
                String sql1 = "SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_OthersReaders'";
                DataSet ds1 = this.tabCommand.TableComm.SearchData(sql1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    sql1 = "select OtherReaders from U_OthersReaders where UserID='" + userID + "'";
                    ds1 = this.tabCommand.TableComm.SearchData(sql1);
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        result = ds1.Tables[0].Rows[0][0].ToString();
                    }
                }
                else
                {
                    //������
                    sql1 = @"CREATE TABLE U_OthersReaders
                        (
                    	    UserID nvarchar(50) not null primary key,
   	                        OtherReaders varchar(2000)		 
                        )";
                    this.tabCommand.TableComm.ExecuteNoQuery(sql1);
                }
            }

            return result;
        }


        /// <summary>
        /// ֱ�Ӹ������ŵ�����
        /// </summary>
        /// <param name="UserNames"></param>
        /// <param name="NewLeader"></param>
        public void ChangeUserLeader(String UserNames, String NewLeader)
        {
            if (String.IsNullOrEmpty(UserNames) == false
               && String.IsNullOrEmpty(NewLeader) == false)
            {
                String sname1 = UserNames.Replace(",", "','");
                String sql1 = "update U_UserName set leader='" + NewLeader + "' where sname in ('" + sname1 + "')";

                this.tabCommand.TableComm.ExecuteNoQuery(sql1);
            }
        }

        /// <summary>
        /// �����û����ڵĲ��ţ�ͬʱ�޸��������ݵ������Ϣ
        /// </summary>
        /// <param name="UserNames"></param>
        /// <param name="NewDepart"></param>
        public void ChangeUserDepart(String UserNames, String NewDepart)
        {
            if (String.IsNullOrEmpty(UserNames) == false
                && String.IsNullOrEmpty(NewDepart) == false)
            {
                String sname1 = UserNames.Replace(",", "','");
                String sql1 = "update U_UserName set depart='" + NewDepart + "' where sname in ('" + sname1 + "')";

                //1) �����û����ڵĲ������ݣ�
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                //2) ��������������
                sql1 = "update U_OLDZC set depart='" + NewDepart + "' where zeren in ('" + sname1 + "')";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                sql1 = "update U_ZC set depart='" + NewDepart + "' where zeren in ('" + sname1 + "')";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                sql1 = "update U_ZC2 set depart='" + NewDepart + "' where zeren in ('" + sname1 + "')";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                sql1 = "update XT_UserLog set depart='" + NewDepart + "' where sname in ('" + sname1 + "')";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                sql1 = "update ZX_RCAP set depart='" + NewDepart + "' where sname in ('" + sname1 + "')";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);

                sql1 = "update ZX_WorkLog set depart='" + NewDepart + "' where sname in ('" + sname1 + "')";
                this.tabCommand.TableComm.ExecuteNoQuery(sql1);
            }
        }

        /// <summary>
        /// �õ��Լ����������û����б�
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public String GetSelfAndXiaShu(String userName)
        {
            String result = "";
            String sql = "select distinct sname from U_UserName where sname='" + userName + "' or leader like '%" + userName + "%'";
            DataSet ds1 = this.tabCommand.TableComm.SearchData(sql);
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                if (result == String.Empty)
                {
                    result = dr[0].ToString();
                }
                else
                {
                    result = result + "," + dr[0].ToString();
                }
            }
            return result;
        }

        // ���ܣ�����һ���û�
        public bool InsertData(Hashtable ht)
        {
            try
            {
                this.tabCommand.InsertData(ht);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ���ܣ��޸��û�������
        public bool EditUserData(string id, Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
                this.tabCommand.EditQuickData(list1, ht);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //���ܣ�ɾ��һ���û�
        public void DeleteUser(string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.��ֵ��));
        }

        public DataSet GetAllUserList()
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", "admin", SearchOperator.������));
            return this.tabCommand.SearchData("*", list1, "num");
        }

        //���ܣ��õ����е��û��б�
        public DataSet GetAllUserList(int curPage,int PageSize,out int totalRow)
        {
           return this.GetAllUserList(curPage,string.Empty,PageSize,out totalRow);
        }

        public DataSet GetAllUserList(int curPage,String status1, int PageSize, out int totalRow)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", "admin", SearchOperator.������));
            if (status1 != String.Empty)
            {
                if (status1 == "0")
                {
                    list1.Add(new SearchField("lockflag is null", "", SearchOperator.�û�����));
                }

                if (status1 == "1")
                {
                    list1.Add(new SearchField("lockflag is not null", "", SearchOperator.�û�����));
                }
            }
            return this.tabCommand.SearchData("*", list1, "num", curPage, PageSize, out totalRow);
        }

        //���ܣ��õ�ĳ�����ŵ����е��û��б�
        public DataSet GetAllUserList(string departName)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", "admin", SearchOperator.������));
            list1.Add(new SearchField("lockflag is null", "", SearchOperator.�û�����));
            list1.Add(new SearchField("depart", departName));
            return this.tabCommand.SearchData("depart,sname", list1, "num");
        }

        //���ܣ�����ID�������û�����ϸ����
        public Hashtable GetDetailByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            return this.tabCommand.SearchData(list1);
        }
        
        //���ܣ��ж��û����������½
        public bool Login(string user, string pass)
        {
            bool login = false;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", user));
            list1.Add(new SearchField("password", pass));
            list1.Add(new SearchField("lockflag is null", "", SearchOperator.�û�����));

            DataSet ds1 = this.tabCommand.SearchData("sname,password,login", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                login = true;
                ds1.Tables[0].Rows[0]["login"] = DateTime.Now.ToString();
                this.tabCommand.Update(ds1);
                
                Util.setCookie("currentuser",user);

                //���õ�ǰ�û���Session
                System.Web.HttpContext.Current.Session["currentusername"] = user;
                //FormsAuthentication.RedirectFromLoginPage(user, false);
            }
            ds1.Dispose();
            return login;
        }

        //���ܣ��õ���ǰ�û���ֱ���쵼
        public string GetDirLeader()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", this.CurrentUser, SearchOperator.����));
            DataSet ds1 = this.tabCommand.SearchData("leader", list1, "num");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["leader"] != DBNull.Value)
                {
                    result = ds1.Tables[0].Rows[0]["leader"].ToString();
                }
            }
            ds1.Dispose();
            return result;
        }

        /// <summary>
        /// �õ�ĳ�û����쵼��
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetDirLeader(String userid)
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", userid, SearchOperator.����));
            DataSet ds1 = this.tabCommand.SearchData("leader", list1, "num");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["leader"] != DBNull.Value)
                {
                    result = ds1.Tables[0].Rows[0]["leader"].ToString();
                }
            }
            ds1.Dispose();
            return result;
        }

        // �õ���ǰ�û����ڵĲ���
        public string GetDepart()
        {
            string result = "";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", this.CurrentUser));
            DataSet ds1 = this.tabCommand.SearchData("depart", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = ds1.Tables[0].Rows[0]["depart"].ToString();
            }
            return result;
        }

        // �����û����õ����ڵĲ���
        public string GetDepart1(string sname)
        {
            string result = "";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", sname));
            DataSet ds1 = this.tabCommand.SearchData("depart", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = ds1.Tables[0].Rows[0]["depart"].ToString();
            }
            return result;
        }
        public string GetDepartInfo(string zeren)
        {
            string result = "";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", zeren));
            DataSet ds1 = this.tabCommand.SearchData("depart", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = ds1.Tables[0].Rows[0]["depart"].ToString();
            }
            return result;
        }

        //�޸ĵ�ǰ�û��û��ĵ�¼����
        public bool ModifyPass(string oldpass, string newpass)
        {
            bool result = false;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname", this.CurrentUser));
            list1.Add(new SearchField("password", oldpass));
            DataSet ds1 = this.tabCommand.SearchData("sname,password", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = true;
                ds1.Tables[0].Rows[0]["password"] = newpass;
                this.tabCommand.Update(ds1);
            }
            ds1.Dispose();
            return result;
        }
        //�õ������ʲ�������Ա���ڵĲ����б�
        public string[] GetZcJobDepart()
        {
            string[] result = null;
            U_RolesBU role1 = new U_RolesBU();
            string roleUsers = role1.GetRoleAllUsers("�ʲ�������Ա");
            role1.Close();

            if (roleUsers != "")
            {
                string[] temp = roleUsers.Split(',');
                string temp1 = Util.sqlValue(temp);

                string str1 = "select depart from U_depart where depart in ( select depart from " + this.tabCommand.TabName + " where sname in ( " + temp1 + " )  group by depart ) order by num";
                DataSet ds1 = this.tabCommand.TableComm.SearchData(str1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    result = new string[ds1.Tables[0].Rows.Count];
                }
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    result[i] = ds1.Tables[0].Rows[i]["depart"].ToString();
                }
            }
            return result;
        }
        //���ݲ��ŵõ����е�
        public string[] GetAllPerson(string depart)
        {
            string[] result = null;
            if (depart != "")
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("depart", depart));
                list1.Add(new SearchField("lockflag is null", "",SearchOperator.�û�����));
                DataSet ds1 = this.tabCommand.SearchData("sname", list1,"num");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    result = new string[ds1.Tables[0].Rows.Count];
                }
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    result[i] = ds1.Tables[0].Rows[i]["sname"].ToString();
                }
            }
            return result;
        }


        //�����ʲ�������(֧�ֵ�ѡ�Ͷ�ѡ)
        public void SetZcZeren(ListControl listcontrol)
        {
            U_RolesBU role1 = new U_RolesBU();
            string roleUsers = role1.GetRoleAllUsers("�ʲ�������Ա");
            role1.Close();

            if (roleUsers != "")
            {
                string[] temp = roleUsers.Split(',');
                string temp1 = Util.sqlValue(temp);

                string sql = "select depart,sname from " + this.tabCommand.TabName + " where sname in (" + temp1 + ") order by num";
                DataSet ds = this.tabCommand.TableComm.SearchData(sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string text1 = ds.Tables[0].Rows[i]["sname"].ToString();
                    string value1 = ds.Tables[0].Rows[i]["depart"].ToString();
                    ListItem list1 = new ListItem(text1 + "��" + value1, text1);
                    listcontrol.Items.Add(list1);
                }
            }
        }
        //����ListCheckBox��ֵ
        public void SetUserList(ListControl listcontrol)
        {
            DataSet ds = this.tabCommand.SearchData("sname");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string text1 = ds.Tables[0].Rows[i]["sname"].ToString();
                string value1 = ds.Tables[0].Rows[i]["sname"].ToString();
                ListItem list1 = new ListItem(text1, value1);
                list1.Attributes["value"] = value1;
                listcontrol.Items.Add(list1);
            }
        }
        //�õ��û������Ӧ�Ĳ����б�
        public DataSet GetUserAndDept()
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("sname","admin",SearchOperator.������));
            DataSet ds1 = this.tabCommand.SearchData("sname,depart", list1,"px");
            return ds1;
        }

        //�õ��û������Ӧ�Ĳ����б�
        public DataSet GetUserByDepart(string depart)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("depart", depart, SearchOperator.����));
            DataSet ds1 = this.tabCommand.SearchData("sname", list1, "px");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                return ds1;
            }
            else
            {
                return null;
            }
        }
        //���ݲ��ź�ְ��������
        public string GetSnameByDepartANDJob(string depart,string job)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("depart",depart, SearchOperator.����,SearchFieldType.�ַ���));
            if (job != null && job != "")
            {
                list1.Add(new SearchField("job", job, SearchOperator.����, SearchFieldType.�ַ���));
            }
            DataSet ds1 = this.tabCommand.SearchData("sname", list1);
            string sname = "";
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {
                    sname = ds1.Tables[0].Rows[i]["sname"].ToString();
                }
                else
                {
                    sname = sname + "," + ds1.Tables[0].Rows[i]["sname"].ToString();
                }
            }
            return sname;
        }
        #endregion

        #region ˽�з���

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

