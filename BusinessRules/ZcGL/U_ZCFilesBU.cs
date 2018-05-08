using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.IO;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �û�ҵ������
    /// </summary>
    public class U_ZCFilesBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_ZCFiles";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public U_ZCFilesBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ZCFilesBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�

        public void DeleteFile(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["AttachFile"] != DBNull.Value)
                {
                    string f1 = ds1.Tables[0].Rows[0]["AttachFile"].ToString();
                    f1 = System.Web.HttpContext.Current.Application["root"] + "/Common/AttachFiles/" + f1;
                    string FileName = System.Web.HttpContext.Current.Server.MapPath(f1);
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                }

                Util.DelDataSetData(ds1);
                this.tabCommand.Update(ds1);
            }
        }

        public void InsertData(Hashtable ht)
        {
            this.tabCommand.InsertData(ht);
        }


        //�õ�����������
        public int GetAttachFileCount(string parentid)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("tcid", parentid, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("count(*) count1", list1);
            return int.Parse(ds.Tables[0].Rows[0]["count1"].ToString());

        }

        public DataSet GetAttachList(string parentid,string bkind)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("tcid", parentid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("bkind",bkind,SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1, "id");
            ds.Tables[0].Columns.Add("num");
            ds.Tables[0].Columns.Add("filename");
            ds.Tables[0].Columns.Add("AttachFile1");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["num"] = i + 1;
                string temp = ds.Tables[0].Rows[i]["AttachFile"].ToString();
                ds.Tables[0].Rows[i]["filename"] = temp.Split('_')[2];
                ds.Tables[0].Rows[i]["AttachFile1"] = ds.Tables[0].Rows[i]["AttachFile"];
                ds.Tables[0].Rows[i]["AttachFile"] = System.Web.HttpContext.Current.Server.UrlEncode(ds.Tables[0].Rows[i]["AttachFile"].ToString());
            }
            return ds;

        }
        public DataSet GetAttachListByZCID(string zcid)
        {
            this.tabCommand.TabName = "ZCFileView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", zcid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("bkind", "0", SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1, "kind");
            ds.Tables[0].Columns.Add("num");
            ds.Tables[0].Columns.Add("filename");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["num"] = i + 1;
                string temp = ds.Tables[0].Rows[i]["AttachFile"].ToString();
                ds.Tables[0].Rows[i]["filename"] = temp.Split('_')[2];
                ds.Tables[0].Rows[i]["AttachFile"] = System.Web.HttpContext.Current.Server.UrlEncode(ds.Tables[0].Rows[i]["AttachFile"].ToString());
            }
            this.tabCommand.TabName = TabName;
            return ds;

        }

        public DataSet GetAttachListByBID(string bid)
        {
            this.tabCommand.TabName = "ZCBAOFileView";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("zcid", bid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("bkind", "1", SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1, "kind");
            ds.Tables[0].Columns.Add("num");
            ds.Tables[0].Columns.Add("filename");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["num"] = i + 1;
                string temp = ds.Tables[0].Rows[i]["AttachFile"].ToString();
                ds.Tables[0].Rows[i]["filename"] = temp.Split('_')[2];
                ds.Tables[0].Rows[i]["AttachFile"] = System.Web.HttpContext.Current.Server.UrlEncode(ds.Tables[0].Rows[i]["AttachFile"].ToString());
            }
            this.tabCommand.TabName = TabName;
            return ds;

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
