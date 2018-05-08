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
    /// �����ֵ䴦��ҵ����
    /// ���룺���ټ�
    /// ʱ�䣺2007��8��5��
    /// </summary>
    public class U_ItemBU : IDisposable
    {
        #region ���Զ���
        private const string TabName = "U_Item";
        private CommTable tabCommand = null;
        private string itemName = null;
        #endregion

        #region ���캯��
        public U_ItemBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public U_ItemBU()
            : this(Util.GetDefaultConnect())
        {

        }

        public U_ItemBU(string itemName)
            : this(Util.GetDefaultConnect())
        {
            this.itemName = itemName;
        }

        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }
        #endregion

        #region ҵ�񷽷�
        //���ܣ��õ����е������ֵ��б�
        public DataSet GetAllItem()
        {
            List<SearchField> list1 = null;
            return this.tabCommand.SearchData("*", list1, "num");
        }


        //���ܣ�����id���õ���ϸ����
        public Hashtable GetDetailByID(string id)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            Hashtable ht = this.tabCommand.SearchData(list1);
            return ht;
        }

        //���ܣ����������ֵ�
        public void SaveObject(string id, Hashtable ht)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.��ֵ��));
            DataSet ds1 = this.tabCommand.SearchData("itemtext,itemvalue,id", list1);
            ds1.Tables[0].Rows[0]["itemvalue"] = ht["itemvalue"].ToString();
            this.tabCommand.Update(ds1);
            ds1.Dispose();
        }


        //���ܣ����������ֵ��������1
        public void SetLiteralControl(ListControl drop1,string itemname, string blankValue)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("itemText", itemname));
            DataSet ds1 = this.tabCommand.SearchData("itemtext,itemvalue", list1, "num");
            string temp = null;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                temp = ds1.Tables[0].Rows[0][1].ToString();
            }
            if (temp != null)
            {
                string[] arr = temp.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    ListItem list0 = new ListItem(arr[i], arr[i]);
                    drop1.Items.Add(list0);
                }
            }

            if (blankValue != null && blankValue != "")
            {
                ListItem list0 = new ListItem(blankValue, "");
                drop1.Items.Insert(0, list0);
            }

        }

        //���ܣ����������ֵ��������2
        public void SetLiteralControl(ListControl drop1, string blankValue)
        {
            this.SetLiteralControl(drop1, this.ItemName, blankValue);
        }

        //���ܣ�����û��Զ���������Ϣ
        public void Setuserkind(ListControl chk1)
        {
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ItemText", "�û��Զ������"));
            DataSet ds1 = this.tabCommand.SearchData("ItemText,ItemValue", list1, null);
            string temp = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                temp = ds1.Tables[0].Rows[0][1].ToString();
            }
            if (temp != null)
            {
                string[] arr = temp.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    ListItem list0 = new ListItem(arr[i],arr[i]);
                    chk1.Items.Add(list0);
                }
            }
        }

       

        //���ܣ�����û��Զ���������Ϣ
        public void SetStatus(CheckBoxList chk1,string str1)
        {
            this.tabCommand.TabName = "U_ZCStatus";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("statusText", str1,SearchOperator.����,SearchFieldType.�ַ���));
            list1.Add(new SearchField("statusText", str1 + "��ȫ��", SearchOperator.������, SearchFieldType.�ַ���));
            DataSet ds1 = this.tabCommand.SearchData("statusText,statusValue", list1, "statusValue");
            string temp1 = "";
            string temp2 = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        temp1 = ds1.Tables[0].Rows[i]["statusText"].ToString();
                        temp2 = ds1.Tables[0].Rows[i]["statusValue"].ToString();
                    }
                    else
                    {
                        temp1 = temp1 + "," + ds1.Tables[0].Rows[i]["statusText"].ToString();
                        temp2 = temp2 + "," + ds1.Tables[0].Rows[i]["statusValue"].ToString();
                    }
                }
            }
            if (temp1 != null && temp2 != null)
            {
                string[] arr1 = temp1.Split(',');
                string[] arr2 = temp2.Split(',');
                for (int i = 0; i < arr1.Length; i++)
                {
                    ListItem list0 = new ListItem(arr1[i], arr2[i]);
                    chk1.Items.Add(list0);
                }
            }
            this.tabCommand.TabName = TabName;
        }


        /// <summary>
        /// �õ���Ԫ������ҵĻ���
        /// </summary>
        /// <returns></returns>
        public double getHuilv()
        {
            double huilv = 1.0;
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("ItemText", "��Ԫ������һ���"));
            DataSet ds1 = this.tabCommand.SearchData("ItemText,ItemValue", list1, null);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                huilv = double.Parse(ds1.Tables[0].Rows[0][1].ToString());
            }
            return huilv;
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

