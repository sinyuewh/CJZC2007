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

public partial class ZcMng1_PrintWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int pos1 = Request.Url.AbsoluteUri.LastIndexOf("/");
            String url1 = Request.Url.AbsoluteUri.Substring(0, pos1);
            this.wordurl.Value = url1 + "/word1.doc";
            this.wordurl1.Value = url1 + "/word2.doc";
            
            //得到数据
            U_ZCBU zc1 = new U_ZCBU();
            this.BindData1(zc1, Request["czczid"].ToString());
            this.BindData2(zc1, Request["czczid"].ToString());
            zc1.Close();
        }
    }


    //绑定资产审批的基本数据
    private void BindData1(U_ZCBU zc1, string czid)
    {
        //设置基本数据
        string[] arr1 = new string[] { "xmsbh", "danwei", "xmbj", "zclx", 
                                        "zcse", "zqze", "bj", "lx", "fsxzly",
                                        "djyj","cbdepart","cbzeren","num2"};
        DataSet ds2 = zc1.GetShenBaoInfo(czid);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            string zcid = ds2.Tables[0].Rows[0]["zcid"].ToString();
            for (int i = 0; i < arr1.Length; i++)
            {
                HiddenField hid1 = this.xmbj.Parent.FindControl(arr1[i]) as HiddenField;
                if (hid1 != null)
                {
                    hid1.Value = ds2.Tables[0].Rows[0][arr1[i]].ToString();
                }
            }
        }

        //调整资产数额的显示
        if (this.zcse.Value.Trim() != String.Empty)
        {
            if (Comm.isNumeric(this.zcse.Value))
            {
                double t1 = double.Parse(this.zcse.Value)/10000;
                this.zcse.Value = String.Format("{0:N2}", t1) + " 万元";
            }
        }

        //调整债权显示的总额
        double bj = double.Parse(ds2.Tables[0].Rows[0]["bj"].ToString())/10000;
        double lx = double.Parse(ds2.Tables[0].Rows[0]["lx"].ToString())/10000;
        double zqze = double.Parse(ds2.Tables[0].Rows[0]["zqze"].ToString())/10000;
        String format1 = "{0:N2}万元。其中：本金   {1:N2}  万元；利息  {2:N2} 万元";
        this.zqze.Value = String.Format(format1, zqze, bj, lx);
        ds2.Dispose();

        //得到部门处理意见
        U_ZCSPBU zcsp1 = new U_ZCSPBU();
        DataSet ds3 = zcsp1.GetZcSPRemark(Request["czczid"].ToString(), SP.部门审批);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            this.bmremark.Value = String.Format("{0}\n\t\t\t\t{1}", ds3.Tables[0].Rows[0]["ps"], ds3.Tables[0].Rows[0]["zeren"]);
            //this.zeren1.Value = ds3.Tables[0].Rows[0]["zeren"].ToString();
            this.zeren1.Value = User.Identity.Name;     //当前用户

            if (ds3.Tables[0].Rows[0]["time1"] != DBNull.Value)
            {
                DateTime dt1 = (DateTime)ds3.Tables[0].Rows[0]["time1"];
                this.time1.Value = dt1.ToString("yyyy 年 MM 月 dd 日");
            }

            DateTime dt2 = (DateTime)ds3.Tables[0].Rows[0]["time0"];
            this.time2.Value = dt2.ToString("yyyy 年 MM 月 dd 日");
        }
        ds3.Dispose();
        

        //得到不同意见审批人
        String[] spyj = new string[] { "13", "15" };
        foreach (String m in spyj)
        {
            DataSet ds11 = zcsp1.GetZcSPList(Request["czczid"].ToString(), m);
            foreach (DataRow dr in ds11.Tables[0].Rows)
            {
                if (m == "13")
                {
                    if (dr["ps"].ToString().Trim() == "同意")
                    {
                        if (this.yj1.Value == "")
                        {
                            this.yj1.Value = dr["zeren"].ToString();
                        }
                        else
                        {
                            this.yj1.Value =this.yj1.Value+"；"+ dr["zeren"].ToString();
                        }
                    }
                    
                    if(dr["ps"].ToString().Trim() == "不同意")
                    {
                        if (this.yj2.Value == "")
                        {
                            this.yj2.Value = dr["zeren"].ToString();
                        }
                        else
                        {
                            this.yj2.Value = this.yj2.Value + "；" + dr["zeren"].ToString();
                        }
                    }
                }
                else
                {
                    if (dr["ps"].ToString().Trim() == "同意")
                    {
                        if (this.yj3.Value == "")
                        {
                            this.yj3.Value = dr["zeren"].ToString();
                        }
                        else
                        {
                            this.yj3.Value = this.yj3.Value + "；" + dr["zeren"].ToString();
                        }
                    }
                    if (dr["ps"].ToString().Trim() == "不同意")
                    {
                        if (this.yj4.Value == "")
                        {
                            this.yj4.Value = dr["zeren"].ToString();
                        }
                        else
                        {
                            this.yj4.Value = this.yj4.Value + "；" + dr["zeren"].ToString();
                        }
                    }
                }
            }
        }
        zcsp1.Close();
    }


    //绑定资产处置数据
    private void BindData2(U_ZCBU zc1, string czid)
    {
        DataSet ds1 = zc1.GetCZFSByCZID(czid);
        int i = 1;
        String[] Afields = new string[] { "czfs", "czjg", "czss", "qcl", "yjfy" };
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            for (int j = 1; j <= 5; j++)
            {
                HiddenField hid1 = this.xmbj.Parent.FindControl(Afields[j-1]+i) as HiddenField;
                if (hid1 != null)
                {
                    hid1.Value = dr[Afields[j-1]].ToString();
                }
            }

            i++;
            if (i > 5)
            {
                break;
            }
        }
        ds1.Dispose();

    }

    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }
}
