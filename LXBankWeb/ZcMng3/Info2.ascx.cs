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

public partial class ZcMng3_Info2 : System.Web.UI.UserControl
{
    String[] contrArrName ={ "czfs1", "jtfa1", "czjg1", "qcl1", "djyj","fsxzly",
                             "czfs2", "jtfa2", "czjg2", "qcl2" ,"xgsx"};
    
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
                Control con1=this.FindControl(m) as Control;
                if(con1!=null)
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

        if (ht["zeren"].ToString() != Page.User.Identity.Name)
        {
            this.tab1.Visible = false;
        }
        else
        {
            this.tab2.Visible = false;
        }
    }


    public bool EditMode
    {
        set
        {
            if (value == false)
            {
                this.Row1.Visible = false;
                this.Row2.Visible = false;
            }
        }
    }


    public bool NewMode
    {
        set
        {
            if (value == true)
            {
                this.tab2.Visible = false;
                this.tab1.Visible = true;
            }
        }
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


    /// <summary>
    /// 设置相关的页面处理意见
    /// </summary>
    /// <param name="czid"></param>
    public void SetYiJian(String czid)
    {
        U_FASPBU bu1 = new U_FASPBU();
        ShenPi info1 = bu1.GetBuMenYiJian(czid);

        if (info1 != null)
        {
            this.yj1.Text = info1.YiJian;
            this.ren1.Text = info1.Ren;

            this.yj1_1.Text = info1.YiJian;
            this.ren1_1.Text = info1.Ren;

            if (info1.ShiJian.Trim() != String.Empty)
            {
                info1.ShiJian = DateTime.Parse(info1.ShiJian).ToString("yyyy年MM月dd日");
            }
            this.time1.Text = info1.ShiJian;
            this.time1_1.Text = info1.ShiJian;
        }

        
        ShenPi info2 = bu1.GetPSYYiJian(czid);
        if (info2 != null)
        {
            this.yj2.Text = info2.YiJian;
            this.ren2.Text = info2.Ren;

            this.yj2_1.Text = info2.YiJian;
            this.ren2_1.Text = info2.Ren;

            if (info2.ShiJian.Trim() != String.Empty)
            {
                info2.ShiJian = DateTime.Parse(info2.ShiJian).ToString("yyyy年MM月dd日");
            }
            this.time2.Text = info2.ShiJian;
            this.time2_1.Text = info2.ShiJian;
        }
    }
}
