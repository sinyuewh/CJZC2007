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
         #region 属性定义
        private const string TabName = "DA_JieYuan";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
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

        #region 业务方法
        //得到所有借阅单
        public DataSet GetAllBill()
        {
            List<SearchField> list1 = null;
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        public DataSet GetJieyueList1(string zeren)
        {
            List<SearchField> list1 = new List<SearchField>();
            //list1.Add(new SearchField("id", "null", SearchOperator.空值));
            if (zeren != null && zeren.Trim() != "")
            {
                list1.Add(new SearchField("zeren", zeren, SearchOperator.包含));
            }
            return this.GetJyueResult(list1);

        }

        //得到借阅单查询结果
        public DataSet GetJyueResult(List<SearchField> list1)
        {
            DataSet ds = this.tabCommand.SearchData("*", list1);
            return ds;
        }
        //获得借阅单明细信息
        public DataSet GetDetailByID(string id)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds = this.tabCommand.SearchData("*", list2);
            return ds;
        }
        //得到借阅单文件列表
        public DataSet GetFileList(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
            this.tabCommand.TabName = "DA_FileJieYuanBillView";
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //删除一条借阅单
        public void DeleteData(string bill,string id)
        {
            this.tabCommand.DeleteData(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "DA_JieYuanBill";
            this.DeleteJyueBill(bill);
            this.tabCommand.TabName = TabName;

        }
        //删除一条借阅单---同时删除借阅单明细里面的信息
        public void DeleteJyueBill(string bill)
        {
            this.tabCommand.DeleteData(new SearchField("bill", bill, SearchFieldType.字符型));
        }
        //更新借阅单信息
        public void UpdateJieYuanData(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list1, ht);
        }

        //新增借阅文件1
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
                        result = "错误：该档案中的文件【"+item.Key.ToString()+"】不存在！";
                        return result;
                    }
                    else
                    {                  
                        ht1.Add(item.Key, fileid);
                    }
                }

                this.tabCommand.TabName = "DA_JieYuanBill";
                List<SearchField> list1=new List<SearchField>();
                list1.Add(new SearchField("ID","-1",SearchFieldType.数值型));
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
                result = "错误：数据库事务操作失败！";
            }
            return result;
        }

        //新增借阅文件2
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


        //保存文件前查询文件是否已经选择
        public bool PuanDuanFileStatus(string bill,string fileid)
        {
            List<SearchField> list1 = new List<SearchField>();
            this.tabCommand.TabName = "DA_JieYuanBill";
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
            string fileId =null;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileno", fileno, SearchFieldType.字符型));

            
            this.tabCommand.TabName="DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileId = ds.Tables[0].Rows[0]["id"].ToString();
            }


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

        //通过文件名称获得文件ID
        public string GetFileIdByTitleAndAjnum(string title,string ajnum)
        {
            string fileId = "";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("title", title, SearchFieldType.字符型));
            list1.Add(new SearchField("ajnum", ajnum, SearchFieldType.字符型));

            this.tabCommand.TabName = "DA_Files";
            DataSet ds = this.tabCommand.SearchData("id", list1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileId = ds.Tables[0].Rows[0]["id"].ToString();
            }


            this.tabCommand.TabName = TabName;
            return fileId;
        }
        //通过借阅单编号(bill)获得借阅单ID
        public string GetIdBybill(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
            DataSet ds = this.tabCommand.SearchData("id", list1);
            string id = ds.Tables[0].Rows[0]["id"].ToString();
            return id;
        }
        //通过借阅单ID获得借阅单编号(bill)
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
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.TabName = "DA_JieYuanBill";
            DataSet ds1 = this.tabCommand.SearchData("*", list1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Util.DelDataSetData(ds1);
                this.tabCommand.Update(ds1);
            }
            this.tabCommand.TabName = TabName;
        }
        //生成借阅单－改变单据状态
        public bool ShengChengJieYuanBill(string ID, Hashtable ht)
        {
            try
            {
                List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("id", ID, SearchFieldType.数值型));
                this.tabCommand.EditQuickData(list1, ht);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //判断借阅单的状态
        public bool PuDuanStatus(string GridViewID)
        { 
            List<SearchField> list1=new List<SearchField>();
            list1.Add(new SearchField("id",GridViewID,SearchFieldType.数值型));
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
        //判断借阅单的状态1
        public string PuDuanStatus1(string GridViewID)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", GridViewID, SearchFieldType.数值型));
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
        //通过借阅单编号(bill)获得所有文件ID
        public string[] GetAllIdBybill(string bill)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("bill", bill, SearchFieldType.字符型));
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
        //添加归还时间到借阅单
        public void UpdatePaytime(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list1, ht);
        }

        //自动得到借阅单据编号
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
