using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �ʼ��ռ��䴦����
    /// ���룺
    /// ʱ��:8��13��
    /// </summary>
    public class ZX_EmailBu : IDisposable
    {
        #region ���Զ���
        private const string TabName = "ZX_Email";
        private CommTable tabCommand = null;
        private string curUser = null;
        #endregion

        #region ���캯��
        public ZX_EmailBu(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
            this.curUser = System.Web.HttpContext.Current.User.Identity.Name;
        }

        public ZX_EmailBu()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�

        /// <summary>
        /// ����˵�����ظ��ʼ�
        /// </summary>
        /// <param name="letterid"></param>
        /// <param name="remark"></param>
        public void setReplyEmail(string letterid,string remark)
        {
            Hashtable ht = new Hashtable();

            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", letterid));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr=ds.Tables[0].Rows[0];
                ht["title"] = "���ظ���"+dr["title"].ToString();
                ht["from1"] = this.curUser;
                ht["to1"] = dr["from1"].ToString();
                ht["time0"] = System.DateTime.Now.ToString();
                ht["remark"] = dr["remark"] + "<br><hr>����������£�" + remark;
                dr["back"] = null;
                this.tabCommand.Update(ds);
                ds.AcceptChanges();
            }

            this.AddMail(ht);
        }

        /// <summary>
        /// �����ʼ���ID�ж��ʼ��Ƿ���Ҫ��ִ
        /// </summary>
        /// <param name="letterid"></param>
        /// <returns></returns>
        public bool getHuiZhi(string letterid)
        {
            bool huizhi = false;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", letterid));
            list1.Add(new SearchField("to1", curUser));
            list1.Add(new SearchField("back", "",SearchOperator.�ǿ�ֵ));
            DataSet ds1 = this.tabCommand.SearchData("back", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                huizhi = true;
            }
            return huizhi;
        }

        //�õ������ʼ���ID���ռ��䣩
        public int GetNewMailID()
        {
            int temp = 0;

            //��ʾ���ѹ��ġ����ʼ���
            string newEmailID = Util.getCookieValue("NewEmailID");
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("to1", curUser));
            list1.Add(new SearchField("readcount", "null", SearchOperator.��ֵ));
            DataSet ds = this.tabCommand.SearchData("id", list1,"id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                temp = (int)ds.Tables[0].Rows[0]["id"];
            }
            if (newEmailID != "")
            {
                if (Int32.Parse(newEmailID) == temp)
                {
                    temp = 0;
                }
            }

            return temp;
        }

        //�õ����ʼ�������
        public int GetNewMailCount()
        {
            int result = 0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("to1", curUser));
            list1.Add(new SearchField("readcount", "null",SearchOperator.��ֵ));
            DataSet ds1 = this.tabCommand.SearchData("count(*) as mailCount", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = Int32.Parse(ds1.Tables[0].Rows[0][0].ToString());
                ds1.Dispose();
            }
            return result;
        }

        public Hashtable GetMailDetailByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id));
            list1.Add(new SearchField("to1", curUser));
            return this.tabCommand.SearchData(list1);
        }


        //receive mail ds
        public DataSet GetUserMail(int curpage, int pageSize, string orderBy, out int totalRow)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("to1", curUser));
            DataSet ds1 = this.tabCommand.SearchData("*", list1,orderBy,curpage,pageSize,out totalRow);
            return ds1;
        }


        //get user receive mail
        public DataSet GetUserMail(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id));
            list1.Add(new SearchField("to1", curUser));
            
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            Hashtable ht = new Hashtable();
            ht.Add("readcount", "1");
            this.tabCommand.EditQuickData(list1, ht);
            
            return ds1;
        }

        public DataSet GetUserMail1(string ids)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", ids, SearchOperator.����, SearchFieldType.��ֵ��));

            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            return ds1;
        }
       
        //del mail
        public void DelMail(string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.��ֵ��));
        }

        //send mail
        public bool AddMail(Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", "-1",SearchFieldType.��ֵ��));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                string[] Arrto1 = ht["to1"].ToString().Split(',');
                for (int i = 0; i < Arrto1.Length; i++)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["title"] = ht["title"];
                    dr["to1"] = Arrto1[i];
                    dr["time0"] = DateTime.Now.ToString();
                    dr["from1"] = ht["from1"];
                    dr["remark"] = ht["remark"];
                    
                    if (ht["file1"] != null)
                    {
                        dr["file1"] = ht["file1"];
                    }
                    if (ht["file2"] != null)
                    {
                        dr["file2"] = ht["file2"];
                    }
                    if (ht["file3"] != null)
                    {
                        dr["file3"] = ht["file3"];
                    }
                    if (ht["file4"] != null)
                    {
                        dr["file4"] = ht["file4"];
                    }
                    if (ht["file5"] != null)
                    {
                        dr["file5"] = ht["file5"];
                    }
                    if (ht.ContainsKey("back"))
                    {
                        dr["back"] = ht["back"];
                    }
                    if (ht.ContainsKey("url"))
                    {
                        dr["url"] = ht["url"];
                    }
                    ds.Tables[0].Rows.Add(dr);
                }
                this.tabCommand.Update(ds);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //ͨ����������շ���
        public bool AddMailTwo(Hashtable ht)
        {
            this.tabCommand.TableConnect.BeginTrans();
            try
            {
                this.tabCommand.TabName = "ZX_Email1";
                this.tabCommand.InsertData(ht);
                this.tabCommand.TabName = TabName;

                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", "-1", SearchFieldType.��ֵ��));
                DataSet ds = this.tabCommand.SearchData("*", list1);
                string[] Arrto1 = ht["to1"].ToString().Split(',');
                for (int i = 0; i < Arrto1.Length; i++)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["title"] = ht["title"];
                    dr["to1"] = Arrto1[i];
                    dr["time0"] = DateTime.Now.ToString();
                    dr["from1"] = ht["from1"];
                    dr["remark"] = ht["remark"];
                    if (ht["file1"] != null)
                    {
                        dr["file1"] = ht["file1"];
                    }
                    if (ht["file2"] != null)
                    {
                        dr["file2"] = ht["file2"];
                    }
                    if (ht["file3"] != null)
                    {
                        dr["file3"] = ht["file3"];
                    }
                    if (ht["file4"] != null)
                    {
                        dr["file4"] = ht["file4"];
                    }
                    if (ht["file5"] != null)
                    {
                        dr["file5"] = ht["file5"];
                    }
                    ds.Tables[0].Rows.Add(dr);
                }
                this.tabCommand.Update(ds);
                this.tabCommand.TableConnect.CommitTrans();
                return true;
            }
            catch(Exception err)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                throw err;
                //return false;
            }
        }

        //read or not
        public bool IfRead(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id));
            DataSet ds1 = this.tabCommand.SearchData("readcount", list1);
            if (ds1.Tables[0].Rows[0]["readcount"] != DBNull.Value)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IfCzFile(string file, string kind)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("file"+kind,file));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
