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

public partial class ZcMng2_Zcczsbb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["czczid"] != null && Request["czczid"].ToString() != "")
            {
                U_ZCBU zc1 = new U_ZCBU();
                this.BindData1(zc1, Request["czczid"].ToString());
                this.BindData2(zc1, Request["czczid"].ToString());
                zc1.Close();
            }
        }
    }

    #region 私有方法

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
                Util.SetControlValue(this.xmbj.Parent.FindControl(arr1[i]), ds2.Tables[0].Rows[0][arr1[i]]);
            }
        }
        this.bj.Text = PubComm.GetNumberFormat(this.bj.Text);
        this.lx.Text = PubComm.GetNumberFormat(this.lx.Text);
        this.zqze.Text = PubComm.GetNumberFormat(this.zqze.Text);
        ds2.Dispose();



        //得到部门审批人和审批意见
        //U_UserNameBU user1 = new U_UserNameBU();
        //string leader = user1.GetDirLeader();
        //user1.Close();

        U_ZCSPBU zcsp1 = new U_ZCSPBU();
        DataSet ds3 = zcsp1.GetZcSPRemark(Request["czczid"].ToString(), SP.部门审批);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            if (ds3.Tables[0].Rows[0]["remark"] != DBNull.Value)
            {
                this.bmremark.Text = ds3.Tables[0].Rows[0]["remark"].ToString();
                this.zeren1.Text =  ds3.Tables[0].Rows[0]["zeren"].ToString();
            }
            if (ds3.Tables[0].Rows[0]["time1"] != DBNull.Value)
            {
                DateTime dt1 = (DateTime)ds3.Tables[0].Rows[0]["time1"];
                this.time1.Text = dt1.ToString("yyyy年MM月dd日");
            }

            DateTime dt2 = (DateTime)ds3.Tables[0].Rows[0]["time0"];
            this.time.Text = dt2.ToString("yyyy年MM月dd日");
        }
        ds3.Dispose();
        zcsp1.Close();
    }


    //绑定资产处置数据
    private void BindData2(U_ZCBU zc1, string czid)
    {
        DataSet ds1 = zc1.GetCZFSByCZID(czid);
        this.repeater1.DataSource = ds1;
        this.repeater1.DataBind();
        ds1.Dispose();

    }
    #endregion
}
