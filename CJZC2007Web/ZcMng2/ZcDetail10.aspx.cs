using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class ZcMng2_ZcDetail10 : System.Web.UI.Page
{
    String[] arr1 = new string[] {"depart","zeren","danwei","zhwd","num1","num2","huobi","huilv",
                                   "bj","lx1","lx2","lx3","sshy","quyu","guangxia","zcbao",
                                   "zcbao","bank","zhuang","htnum","time0","status","userkind","zcid","xgr","xgsj",
                                    "zzjg","jysfzc","clsj","zczb","dqjj","qygm","dwdz",
                                   "dwfzr","qyjjxz","yxzzzk","xdri","dkffrq1","jklsh",
                                   "dkye","dkffrq2","htdqr","zjycszje","zydbfs","dbrwmc",
                                   "yyldxt","xcyqrq","jrblsj","guangxia","fenlei","remark",};

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindDate();
        }
    }
    private void BindDate()
    {
        if (Request["id"] != null)
        {
            string id = Request["id"].ToString();
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetOldZCInfoByID(id);
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //设置管理员字段
                for (int i = 0; i < arr1.Length; i++)
                {
                    Util.SetControlValue(this.zcbao.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
                }
            }
            ds.Dispose();

        }
    }
}
