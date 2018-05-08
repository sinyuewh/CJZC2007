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
        #region 属性定义
        private const string TabName = "DA_Copy";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
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

        #region 业务方法

        //删除复印单及明细
        public void DelCopyData(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.DeleteData(list2);
            //利用完整性自动删除复印明细
        }

        //得到所有复印单
        public DataSet GetAllBill()
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }


        public DataSet GetPrintList1(string zeren)
        {
            List<SearchField> list1 = new List<SearchField>();
            //list1.Add(new SearchField("id", "null", SearchOperator.空值));
            if (zeren != null && zeren.Trim() != "")
            {
                list1.Add(new SearchField("zeren", zeren, SearchOperator.包含));
            }
            return this.GetPrintResult(list1);

        }

        //得到复印单查询结果
        public DataSet GetPrintResult(List<SearchField> list1)
        {
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        //获得复印单明细信息
        public DataSet GetDetailByID(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list2);
            return ds;
        }
        //得到复印单文件列表
        public DataSet GetFileList(string bill)
        {

            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
            this.tabCommand.TabName = "DA_FileCopyBillView";
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }

        //更新复印单信息
        public void UpdateCopyData(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list1, ht);
        }
        //新增复印文件
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
        //保存文件前查询文件是否已经选择
        public bool PuanDuanFileStatus(string bill, string fileid)
        {
            List<SearchField> list1 = new List<SearchField>();
            this.tabCommand.TabName = "DA_CopyBill";
            list1.Add(new SearchField("fileid", fileid, SearchFieldType.数值型));
            list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
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
        //通过文号获得文件ID
        public string GetFileIdByFileno(string fileno)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileno", fileno, SearchFieldType.字符型));
            this.tabCommand.TabName = "DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string fileId = ds.Tables[0].Rows[0]["id"].ToString();
            this.tabCommand.TabName = TabName;
            return fileId;
        }

        //通过文件名称获得文件ID
        public string GetFileIdByTitle(string title)
        {
            string fileId = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("title", title, SearchFieldType.字符型));
            this.tabCommand.TabName = "DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileId = ds.Tables[0].Rows[0]["id"].ToString();
            }
            this.tabCommand.TabName = TabName;
            return fileId;
        }
        //通过复印单编号(bill)获得借阅单ID
        public string GetIdBybill(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string id = ds.Tables[0].Rows[0]["id"].ToString();
            return id;
        }
        //通过复印单ID获得借阅单编号(bill)
        public string GetbillById(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("bill", list1);
            string bill = ds.Tables[0].Rows[0]["bill"].ToString();
            return bill;
        }
        //删除Repeater里面的文件
        public void DeleteFile(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileid", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "DA_CopyBill";
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Util.DelDataSetData(ds1);
                this.tabCommand.Update(ds1);
            }
            this.tabCommand.TabName = TabName;
        }
        //自动得到复印单据编号
        public string GetBillNum()
        {
            string result = null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("year(billtime)", DateTime.Now.Year.ToString() + "", SearchFieldType.数值型));
            list1.Add(new SearchField("month(billtime)", DateTime.Now.Month.ToString() + "", SearchFieldType.数值型));
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

        #region 私有方法

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
