using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;

namespace JSJ.CJZC.Business
{
    public class ZC2BU
    {
        public int GetChuZhiCountByID(int zcid)
        {
            int result = 0;
            CommTable com1 = new CommTable();
            com1.TabName = "U_ZC2";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("zcid", zcid.ToString(),SearchFieldType.数值型));
            condition.Add(new SearchField("exists ( select * from U_ZCSP where CZID=U_ZC2.id )", "", SearchOperator.用户定义));
            DataSet ds1 = com1.SearchData("count(*) count1", condition);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds1.Tables[0].Rows[0]["count1"].ToString());
            }
            com1.Close();
            return result;
        }
    }
}
