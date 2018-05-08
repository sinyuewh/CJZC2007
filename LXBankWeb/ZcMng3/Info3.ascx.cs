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
using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class ZcMng3_Info3 : System.Web.UI.UserControl
{
    String[] contrArrName ={ "hysj1", "hydd1", "yingdao1", 
                             "shidao1", "quexi1", "zcr1" };

    /// <summary>
    /// 设置页面上控件的值
    /// </summary>
    /// <param name="ht"></param>
    public void SetControlData(Hashtable ht)
    {
        foreach (String m in this.contrArrName)
        {
            if (ht.ContainsKey(m))
            {
                Control con1 = this.FindControl(m) as Control;
                if (con1 != null)
                {
                    Util.SetControlValue(con1, ht[m]);      //设置控件的值
                }

                Control con2 = this.FindControl(m+"_1") as Control;
                if (con2 != null)
                {
                    Util.SetControlValue(con2, ht[m]);      //设置控件的值
                }
            }
        }

        U_RolesBU bu1 = new U_RolesBU();
        bool role1 = bu1.isRole("领导秘书");
        bu1.Close();
        
        if (ht["zeren"].ToString() == Page.User.Identity.Name || role1)
        {
            this.row1.Visible = true;
            this.row1_1.Visible = false;
            this.row2.Visible = true;
            this.row2_1.Visible = false;
        }
        else
        {
            this.row1.Visible = false;
            this.row1_1.Visible = true;
            this.row2.Visible = false;
            this.row2_1.Visible = true;
        }


        //设置意见信息
        String weiyuan1 = "";
        String weiyuan2 = "";
        String weiyuan3 = "";

        String zhuxi = "";
        String zhuxiTime = "";
        String zhuxiyijian = "";

        JSJ.CJZC.Business.Comm.GetWeiYuan1(ht["id"].ToString(),"13",
            out weiyuan1,
            out weiyuan2, 
            out weiyuan3,
            out zhuxi, 
            out zhuxiTime, 
            out zhuxiyijian);

        this.ztwy1.Text = weiyuan1;
        this.fdwy1.Text = weiyuan2;
        this.wy3.Text = weiyuan3;

        this.shren1.Text = zhuxi;
        this.shsj1.Text = zhuxiTime;
        this.shyj1.Text = zhuxiyijian; 
    }


    /// <summary>
    /// 得到页面控件的值
    /// </summary>
    /// <param name="ht"></param>
    public void GetControlData(Hashtable ht)
    {
        if (ht == null)
        {
            ht = new Hashtable();
        }

        foreach (String m in this.contrArrName)
        {
            if (ht.ContainsKey(m) == false)
            {
                Control con1 = this.FindControl(m) as Control;
                if (con1 != null)
                {
                    ht.Add(m, Util.GetControlValue(con1));
                }
            }
        }
    }
}
