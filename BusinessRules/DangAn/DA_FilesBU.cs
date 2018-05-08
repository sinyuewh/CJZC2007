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
        #region 属性定义
        private const string TabName = "DA_Files";
        private CommTable tabCommand = null;
        #endregion

        #region 构造函数
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

        #region 业务方法
      
        //得到数据列表
        public DataSet GetFileList(string ajNum)
        {
            
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ajnum", ajNum, SearchFieldType.字符型));
         
            DataSet ds = this.tabCommand.SearchData("*", list1);
            this.tabCommand.TabName = TabName;
            return ds;
        }
        //新增文件
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
        // 删除文件
        public void DelteFile(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
                list1.Add(new SearchField("ID", id, SearchFieldType.数值型));
                DataSet ds1 = this.tabCommand.SearchData("*", list1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    Util.DelDataSetData(ds1);
                    this.tabCommand.Update(ds1);
                }
        }

        //得到数据详细
        public DataSet GetFileDetailByID(string id)
        {
            SearchField search1 = new SearchField("id", id, SearchFieldType.数值型);
            DataSet ds = this.tabCommand.SearchData("*", new SearchField[] { search1 });
            return ds;
        }
        //更新文件信息
        public void UpdateFileData(string fileID, Hashtable ht)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", fileID, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list2, ht);
        }
        //增加借阅人、借阅时间，登记人、登记时间
        public void UpdateJieyueInfo(string fileId, Hashtable ht)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id",fileId, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list2, ht);
        }
        //减去借阅人、借阅时间，登记人、登记时间
        public void RemoveJieyueInfo(string fileId, Hashtable ht)
        {
            List<SearchField> list2 = new List<SearchField>();
            list2.Add(new SearchField("id", fileId, SearchFieldType.数值型));
            this.tabCommand.EditQuickData(list2, ht);
        }
        //判断是否存在这样的文件名(fileno)
        public bool IsOrNotHave(string fileno)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("fileno", fileno, SearchFieldType.字符型));
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
        //判断文件所在的档案是否已经移交
        public bool IsOrNotMove(string ajnum)
        {
            this.tabCommand.TabName = "DA_AnJuan";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ajnum", ajnum, SearchFieldType.字符型));
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
        //判断文件是否已经借出
        public bool IsOrNotJieYue(string fileId)
        {

            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", fileId, SearchFieldType.数值型));
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
        //通过文件号获取档案编号
        public string GetajnumByfileId(string fileId)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", fileId, SearchFieldType.数值型));
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
