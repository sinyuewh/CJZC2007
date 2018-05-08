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

public partial class ZcMng2_Zcjbzlb : System.Web.UI.Page
{
    string[] arr1 = new string[] {"depart","zeren","danwei","zhwd","num1","num2","huobi","huilv",
                                   "bj","lx1","lx2","lx3","sshy","quyu","guangxia","zcbao",
                                   "zcbao","bank","zhuang","htnum","time0","status","userkind",
                                    "zzjg","jysfzc","clsj","zczb","dqjj","qygm","dwdz",
                                   "dwfzr","qyjjxz","yxzzzk","xdri","dkffrq1","jklsh",
                                   "dkye","dkffrq2","htdqr","zjycszje","zydbfs","dbrwmc",
                                   "yyldxt","xcyqrq","jrblsj","guangxia","fenlei","remark",};


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        if (Request["zcid"] != null)
        {
            string id = Request["zcid"];
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetDetailByID(id);
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Util.SetControlValue(this.zcbao.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
                }

                if (ds.Tables[0].Rows[0]["time0"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["time0"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("time0"), dt);
                }
                if (ds.Tables[0].Rows[0]["status"] != DBNull.Value)
                {
                    string st = ds.Tables[0].Rows[0]["statusText"].ToString();
                    Util.SetControlValue(this.zcbao.Parent.FindControl("status"), st);
                }
                if (ds.Tables[0].Rows[0]["clsj"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["clsj"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("clsj"), dt);
                }
                if (ds.Tables[0].Rows[0]["xdri"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["xdri"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("xdri"), dt);
                }
                if (ds.Tables[0].Rows[0]["dkffrq1"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["dkffrq1"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("dkffrq1"),dt);
                }
                if (ds.Tables[0].Rows[0]["dkffrq2"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["dkffrq2"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("dkffrq2"), dt);
                }
                if (ds.Tables[0].Rows[0]["htdqr"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["htdqr"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("htdqr"),dt);
                }
                if(ds.Tables[0].Rows[0]["xcyqrq"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["xcyqrq"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("xcyqrq"), dt);
                }
                if (ds.Tables[0].Rows[0]["jrblsj"] != DBNull.Value)
                {
                    string dt = DateTime.Parse(ds.Tables[0].Rows[0]["jrblsj"].ToString()).ToString("yyyy-MM-dd");
                    Util.SetControlValue(this.zcbao.Parent.FindControl("jrblsj"),dt);
                }

                //设置数字金额的显示
                string[] num1 = new string[] { "bj", "lx1", "lx2", "lx3", "zczb", "dkye", "zjycszje" };
                for (int i = 0; i < num1.Length; i++)
                {
                    Label l1 = this.bj.Parent.FindControl(num1[i]) as Label;
                    if (l1 != null)
                    {
                        l1.Text = PubComm.GetNumberFormat(l1.Text);
                    }
                }
            }
            ds.Dispose();
        }
    }
}
