using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Web;
using System.Web.Security;
using System.Collections;

namespace JSJ.CJZC.Business
{
    public class DA_CopyBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "DA_Copy";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public DA_CopyBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public DA_CopyBU()
            : this(Util.GetDefaultConnect())
        {

        }
        public CommTable TabCommand
        {
            get
            {
                return this.tabCommand;
            }
        }
        #endregion

        #region ҵ�񷽷�

        //ɾ����ӡ������ϸ
        public void DelCopyData(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.DeleteData(list2);
            //�����������Զ�ɾ����ӡ��ϸ
        }

        //�õ����и�ӡ��
        public DataSet GetAllBill()
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }


        public DataSet GetPrintList1(string zeren)
        {
            List<SearchField> list1 = new List<SearchField>();
            //list1.Add(new SearchField("id", "null", SearchOperator.��ֵ));
            if (zeren != null && zeren.Trim() != "")
            {
                list1.Add(new SearchField("zeren", zeren, SearchOperator.����));
            }
            return this.GetPrintResult(list1);

        }

        //�õ���ӡ����ѯ���
        public DataSet GetPrintResult(List<SearchField> list1)
        {
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        //��ø�ӡ����ϸ��Ϣ
        public DataSet GetDetailByID(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list2);
            return ds;
        }
        //�õ���ӡ���ļ��б�
        public DataSet GetFileList(string bill)
        {

            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
            this.tabCommand.TabName = "DA_FileCopyBillView";
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //���¸�ӡ����Ϣ
        public void UpdateCopyData(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list1, ht);
        }
        //������ӡ�ļ�
        public bool AddCopyFileData(Hashtable ht)
        {
            this.tabCommand.TabName = "DA_CopyBill";
            string bill = ht["bill"].ToString();
            string fileid = ht["fileid"].ToString();
            bool result = this.PuanDuanFileStatus(bill, fileid);
            if (result)
            {
                this.tabCommand.InsertData(ht);
                this.tabCommand.TabName = TabName;
                return true;
            }
            else
            {
                this.tabCommand.TabName = TabName;
                return false;
            }

        }
        //�����ļ�ǰ��ѯ�ļ��Ƿ��Ѿ�ѡ��
        public bool PuanDuanFileStatus(string bill, string fileid)
        {
            List<SearchField> list1 = new List<SearchField>();
            this.tabCommand.TabName = "DA_CopyBill";
            list1.Add(new SearchField("fileid", fileid, SearchFieldType.��ֵ��));
            list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            //this.tabCommand.TabName = TabName;
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //ͨ���ĺŻ���ļ�ID
        public string GetFileIdByFileno(string fileno)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileno", fileno, SearchFieldType.�ַ���));
            this.tabCommand.TabName = "DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string fileId = ds.Tables[0].Rows[0]["id"].ToString();
            this.tabCommand.TabName = TabName;
            return fileId;
        }

        //ͨ���ļ����ƻ���ļ�ID
        public string GetFileIdByTitle(string title)
        {
            string fileId = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("title", title, SearchFieldType.�ַ���));
            this.tabCommand.TabName = "DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileId = ds.Tables[0].Rows[0]["id"].ToString();
            }
            this.tabCommand.TabName = TabName;
            return fileId;
        }
        //ͨ����ӡ�����(bill)��ý��ĵ�ID
        public string GetIdBybill(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string id = ds.Tables[0].Rows[0]["id"].ToString();
            return id;
        }
        //ͨ����ӡ��ID��ý��ĵ����(bill)
        public string GetbillById(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("bill", list1);
            string bill = ds.Tables[0].Rows[0]["bill"].ToString();
            return bill;
        }
        //ɾ��Repeater������ļ�
        public void DeleteFile(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileid", id, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "DA_CopyBill";
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Util.DelDataSetData(ds1);
                this.tabCommand.Update(ds1);
            }
            this.tabCommand.TabName = TabName;
        }
        //�Զ��õ���ӡ���ݱ��
        public string GetBillNum()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("year(billtime)", DateTime.Now.Year.ToString() + "", SearchFieldType.��ֵ��));
            list1.Add(new SearchField("month(billtime)", DateTime.Now.Month.ToString() + "", SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData(" top 1 Right(bill,2) as bill", list1, "id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int num1 = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                num1++;
                result = DateTime.Now.ToString("yyyyMM") + num1.ToString().PadLeft(2, '0');
            }
            else
            {
                result = DateTime.Now.ToString("yyyyMM01");
            }
            return result;
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
