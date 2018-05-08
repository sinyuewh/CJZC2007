using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.CJZC.Business;
using JSJ.SysFrame;
using System.Data;
using System.Collections;

public partial class ZcMng2_ZcDetail11 : System.Web.UI.Page
{
    string[] arr1 = new string[] { "sszt", "zxzt", "sszl", "最后中断诉讼时效时间", "诉讼时效到期日", 
                                    "最后中断保证时效时间", "保证时效到期日", "时效中断方式", "执行时效到期日", 
                                    "查封时效到期日", "查封文字描述", "是否破产", "宣告破产裁定书文号", 
                                    "破产审理法院", "破产审理法官", "破产债权申报时间", "破产申报债权金额", 
                                    "破产终结日", "终结破产裁定文书号", "分配财产金额", "起诉时间", 
                                    "上诉时间", "申请执行时间", "一审法院", "一审代理人", 
                                    "一审主审法官", "联系方式1", "一审代理律师", "联系方式2", 
                                    "一审判决书文号", "一审判决时间", "一审判决金额", "二审法院", 
                                    "二审代理人", "二审主审法官", "联系方式3", "二审代理律师", 
                                    "联系方式4", "二审判决书文号", "二审判决时间", "二审判决金额", 
                                    "执行法院", "执行法官", "联系方式5", "备注" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }


    //设置页面信息
    private void BindData()
    {
        if (Request["id"] != null)
        {
            string zcid = Request["id"].ToString();
            U_ZCBU zc1 = new U_ZCBU();

            DataSet ds = zc1.GetZCSSInfo(zcid);
            string user1 = zc1.GetZerenByZCID(zcid);
            zc1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Util.SetControlValue(this.sszt.Parent.FindControl(arr1[i]), ds.Tables[0].Rows[0][arr1[i]]);
                    Util.SetControlValue(this.sszt.Parent.FindControl(arr1[i] + "_1"), ds.Tables[0].Rows[0][arr1[i]]);
                } 
            }
            ds.Dispose();

           
            //设置按钮的权限            
            if (user1 == User.Identity.Name || (user1.Trim() == "" && PubComm.IsRole("系统管理员")))
            {
                this.Button1.Visible = true;
               
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (this.sszl.Parent.FindControl(arr1[i] + "_1") != null)
                    {
                        this.sszl.Parent.FindControl(arr1[i] + "_1").Visible = false;
                    }
                }
            }
            else
            {
                this.Button1.Visible = false;
                
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (this.sszl.Parent.FindControl(arr1[i]) != null)
                    {
                        this.sszl.Parent.FindControl(arr1[i]).Visible = false;
                    }
                }
            }

        }
    }

    protected void SaveDataClick(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        foreach (string item in arr1)
        {
            ht[item] = Util.GetControlValue(this.sszl.Parent.FindControl(item));
        }

        try
        {
            U_ZCBU zc1 = new U_ZCBU();
            ht["id"] = Request["id"];
            
            zc1.UpDateZCSSInfo(Request["id"], ht);
            zc1.Close();
            Util.alert(this.Page, "操作提示：更新资料成功！");
        }
        catch (Exception err1)
        {
            Util.alert(this.Page, "错误提示：更新资产数据失败，可能的原因是数据类型有错误，请检查重新输入！");
        }
    }
}
