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
    public class DA_JieYuanBU:IDisposable
    {
         #region ���Զ���
        private const string TabName = "DA_JieYuan";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public DA_JieYuanBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public DA_JieYuanBU()
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
        //�õ����н��ĵ�
        public DataSet GetAllBill()
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        public DataSet GetJieyueList1(string zeren)
        {
            List<SearchField> list1 = new List<SearchField>();
            //list1.Add(new SearchField("id", "null", SearchOperator.��ֵ));
            if (zeren != null && zeren.Trim() != "")
            {
                list1.Add(new SearchField("zeren", zeren, SearchOperator.����));
            }
            return this.GetJyueResult(list1);

        }

        //�õ����ĵ���ѯ���
        public DataSet GetJyueResult(List<SearchField> list1)
        {
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        //��ý��ĵ���ϸ��Ϣ
        public DataSet GetDetailByID(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list2);
            return ds;
        }
        //�õ����ĵ��ļ��б�
        public DataSet GetFileList(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
            this.tabCommand.TabName = "DA_FileJieYuanBillView";
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //ɾ��һ�����ĵ�
        public void DeleteData(string bill,string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "DA_JieYuanBill";
            this.DeleteJyueBill(bill);
            this.tabCommand.TabName = TabName;

        }
        //ɾ��һ�����ĵ�---ͬʱɾ�����ĵ���ϸ�������Ϣ
        public void DeleteJyueBill(string bill)
        {
            this.tabCommand.DeleteData(new SearchField("bill", bill, SearchFieldType.�ַ���));
        }
        //���½��ĵ���Ϣ
        public void UpdateJieYuanData(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list1, ht);
        }

        //���������ļ�1
        public string AddJyueFileData(string bill,Hashtable ht)
        {
            string result=null;
            Hashtable ht1 = new Hashtable();
            try
            {
                this.tabCommand.TableConnect.BeginTrans();
                foreach (DictionaryEntry item in ht)
                {
                    string[] str = item.Value.ToString().Split('_');
                    string fileid = this.GetFileIdByTitleAndAjnum(str[0], str[1]);
                    if (fileid == "")
                    {
                        result = "���󣺸õ����е��ļ���"+item.Key.ToString()+"�������ڣ�";
                        return result;
                    }
                    else
                    {                  
                        ht1.Add(item.Key, fileid);
                    }
                }

                this.tabCommand.TabName = "DA_JieYuanBill";
                List<SearchField> list1=new List<SearchField>();
                list1.Add(new SearchField("ID","-1",SearchFieldType.��ֵ��));
                DataSet ds1 = this.TabCommand.SearchData("*",list1);
                foreach (DictionaryEntry item in ht1)
                {
                    DataRow dr = ds1.Tables[0].NewRow();
                    dr["bill"] = bill;
                    dr["fileid"] = item.Value.ToString();
                    ds1.Tables[0].Rows.Add(dr);
                }
                this.tabCommand.Update(ds1);                
                this.tabCommand.TabName = TabName;
                this.tabCommand.TableConnect.CommitTrans();
            }
            catch(Exception err1)
            {
                this.tabCommand.TableConnect.RollBackTrans();
                result = "�������ݿ��������ʧ�ܣ�";
            }
            return result;
        }

        //���������ļ�2
        public bool AddJyueFileData(Hashtable ht)
        {
            this.tabCommand.TabName = "DA_JieYuanBill";
            string bill = ht["bill"].ToString();
            string fileid=ht["fileid"].ToString();
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
        public bool PuanDuanFileStatus(string bill,string fileid)
        {
            List<SearchField> list1 = new List<SearchField>();
            this.tabCommand.TabName = "DA_JieYuanBill";
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
            string fileId =null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileno", fileno, SearchFieldType.�ַ���));

            
            this.tabCommand.TabName="DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileId = ds.Tables[0].Rows[0]["id"].ToString();
            }


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

        //ͨ���ļ����ƻ���ļ�ID
        public string GetFileIdByTitleAndAjnum(string title,string ajnum)
        {
            string fileId = "";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("title", title, SearchFieldType.�ַ���));
            list1.Add(new SearchField("ajnum", ajnum, SearchFieldType.�ַ���));

            this.tabCommand.TabName = "DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileId = ds.Tables[0].Rows[0]["id"].ToString();
            }


            this.tabCommand.TabName = TabName;
            return fileId;
        }
        //ͨ�����ĵ����(bill)��ý��ĵ�ID
        public string GetIdBybill(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string id = ds.Tables[0].Rows[0]["id"].ToString();
            return id;
        }
        //ͨ�����ĵ�ID��ý��ĵ����(bill)
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
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.TabName = "DA_JieYuanBill";
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Util.DelDataSetData(ds1);
                this.tabCommand.Update(ds1);
            }
            this.tabCommand.TabName = TabName;
        }
        //���ɽ��ĵ����ı䵥��״̬
        public bool ShengChengJieYuanBill(string ID, Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", ID, SearchFieldType.��ֵ��));
                this.tabCommand.EditQuickData(list1, ht);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //�жϽ��ĵ���״̬
        public bool PuDuanStatus(string GridViewID)
        { 
            List<SearchField> list1=new List<SearchField>();
            list1.Add(new SearchField("id",GridViewID,SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("*", list1);
            if (ds.Tables[0].Rows[0]["status"]!=DBNull.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //�жϽ��ĵ���״̬1
        public string PuDuanStatus1(string GridViewID)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", GridViewID, SearchFieldType.��ֵ��));
            DataSet ds = this.tabCommand.SearchData("status", list1);
            if (ds.Tables[0].Rows[0]["status"].ToString() !=null )
            {
                return ds.Tables[0].Rows[0]["status"].ToString().Trim();
            }
            else
            {
                return null;
            }
        }
        //ͨ�����ĵ����(bill)��������ļ�ID
        public string[] GetAllIdBybill(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.�ַ���));
            this.tabCommand.TabName = "DA_JieYuanBill";
            DataSet ds = this.tabCommand.SearchData("fileid", list1);
            string[] allId = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                allId[i] = ds.Tables[0].Rows[i]["fileid"].ToString();
            }
                //= ds.Tables[0].Rows[0]["id"].ToString();
            this.tabCommand.TabName = TabName;
           return allId;
        }
        //��ӹ黹ʱ�䵽���ĵ�
        public void UpdatePaytime(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            this.tabCommand.EditQuickData(list1, ht);
        }

        //�Զ��õ����ĵ��ݱ��
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
