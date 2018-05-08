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

public partial class ZcMng3_Info4 : System.Web.UI.UserControl
{
    String[] contrArrName ={ "hysj2", "hydd2", "yingdao2", 
                             "shidao2", "quexi2", "zcr2"};

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
            this.Row1.Visible = true;
            this.Row2.Visible = true;
            this.Row3.Visible = false;
            this.Row4.Visible = false;
        }
        else
        {
            this.Row1.Visible = false;
            this.Row2.Visible = false;
            this.Row3.Visible = true;
            this.Row4.Visible = true;
        }


        //设置意见信息
        String weiyuan1 = "";
        String weiyuan2 = "";
        String weiyuan3 = "";
        String zhuxi = "";
        String zhuxiTime = "";
        String zhuxiyijian = "";

        
        JSJ.CJZC.Business.Comm.GetWeiYuan1(ht["id"].ToString(), "15",
            out weiyuan1,
            out weiyuan2,
            out weiyuan3,
            out zhuxi,
            out zhuxiTime,
            out zhuxiyijian);

        this.ztwy2.Text = weiyuan1;
        this.fdwy2.Text = weiyuan2;
        this.shren2.Text = zhuxi;
        this.shsj2.Text = zhuxiTime;
        this.shyj2.Text = zhuxiyijian;
        this.wy3.Text = weiyuan3;
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
