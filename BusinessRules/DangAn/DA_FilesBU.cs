using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;

namespace JSJ.CJZC.Business
{
    public class DA_FilesBU:IDisposable
    {
        #region ���Զ���
        private const string TabName = "DA_Files";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public DA_FilesBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public CommTable TabCommand
        {
            get
            {
                return this.tabCommand;
            }
        }

        public DA_FilesBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�
      
        //�õ������б�
        public DataSet GetFileList(string ajNum)
        {
            
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ajnum", ajNum, SearchFieldType.�ַ���));
         
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //�����ļ�
        public bool InsertFileData(Hashtable ht)
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
        // ɾ���ļ�
        public void DelteFile(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("ID", id, SearchFieldType.��ֵ��));
                DataSet ds1 = this.tabCommand.SearchData("*", list1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    Util.DelDataSetData(ds1);
                    this.tabCommand.Update(ds1);
                }
        }

        //�õ�������ϸ
        public DataSet GetFileDetailByID(string id)
        {
            SearchField search1 = new SearchField("id", id, SearchFieldType.��ֵ��);
            DataSet ds = this.tabCommand.SearchData("*", new SearchField[] { search1 });
            return ds;
        }
        //�����ļ���Ϣ
        public void UpdateFileData(string fileID, Hashtable ht)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", fileID, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list2, ht);
        }
        //���ӽ����ˡ�����ʱ�䣬�Ǽ��ˡ��Ǽ�ʱ��
        public void UpdateJieyueInfo(string fileId, Hashtable ht)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id",fileId, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list2, ht);
        }
        //��ȥ�����ˡ�����ʱ�䣬�Ǽ��ˡ��Ǽ�ʱ��
        public void RemoveJieyueInfo(string fileId, Hashtable ht)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", fileId, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list2, ht);
        }
        //�ж��Ƿ�����������ļ���(fileno)
        public bool IsOrNotHave(string fileno)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileno", fileno, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //�ж��ļ����ڵĵ����Ƿ��Ѿ��ƽ�
        public bool IsOrNotMove(string ajnum)
        {
            this.tabCommand.TabName = "DA_AnJuan";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ajnum", ajnum, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows[0]["ajstatus"].ToString()=="2")
            {
                this.tabCommand.TabName = TabName;
                return false;
            }
            else
            {
                this.tabCommand.TabName = TabName;
                return true;
            }

        }
        //�ж��ļ��Ƿ��Ѿ����
        public bool IsOrNotJieYue(string fileId)
        {

            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", fileId, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows[0]["jyue"] != DBNull.Value || ds.Tables[0].Rows[0]["jyuetime"] != DBNull.Value)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        //ͨ���ļ��Ż�ȡ�������
        public string GetajnumByfileId(string fileId)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", fileId, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("ajnum", list1);
            if (ds.Tables[0].Rows[0]["ajnum"].ToString() != null)
            {
                return ds.Tables[0].Rows[0]["ajnum"].ToString().Trim();
            }
            else
            {
                return null;
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
