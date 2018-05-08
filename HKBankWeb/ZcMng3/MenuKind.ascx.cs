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
using System.Drawing;

public partial class ZcMng3_MenuKind : System.Web.UI.UserControl
{
    //private int menuIndex = 1;
    public event EventHandler MenuChange;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["menuIndex"] != null)
            {
                ViewState["menuIndex"] = int.Parse(Request["menuIndex"]);
            }
            else
            {
                ViewState["menuIndex"] = 1;
            }
            this.SetMenu((int)ViewState["menuIndex"]);
        }
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        this.SetMenu(int.Parse(e.CommandArgument.ToString()));
        if (MenuChange != null)
        {
            MenuChange(sender, e);
        }
    }

    /// <summary>
    /// 设置是否为编辑模式
    /// </summary>
    /// <param name="visible"></param>
    public bool EditMode
    {
        set
        {
            this.editmenu.Visible = value;
        }
    }

    /// <summary>
    /// 设置资产的ID
    /// 用于设置超链接
    /// </summary>
    /// <param name="zcid"></param>
    public String ZcID
    {
        set
        {
            this.hyp1.NavigateUrl = "~/ZcMng2/ZcDetail1.aspx?id=" + value;
            this.hyp1.Target = "_blank";
            this.hyp1.CssClass = "blue1";
            this.hyp1.Text = ">>浏览相关资产详细情况 ";
        }
    }

    public String ZcbID
    {
        set
        {
            this.hyp1.NavigateUrl = "~/ZcMng2/ZcBaoDetail1.aspx?id=" + value;
            this.hyp1.Target = "_blank";
            this.hyp1.CssClass = "blue1";
            this.hyp1.Text = ">>浏览相关资产包详细情况 ";
        }
    }

    /// <summary>
    /// 得到当前的菜单选项
    /// </summary>
    public int MenuIndex
    {
        get
        {
            return (int)ViewState["menuIndex"];
        }
        set
        {
            ViewState["menuIndex"] = value;
        }
    }


    #region 菜单控制
    /// <summary>
    /// 设置菜单的显示效果
    /// </summary>
    /// <param name="mIndex"></param>
    public  void SetMenu(int mIndex)
    {
        for (int i = 1; i <= 6; i++)
           {
               LinkButton link0 = this.FindControl("link" + i) as LinkButton;
               if (link0 != null)
               {
                   if (i != mIndex)
                   {
                       link0.ForeColor = Color.Blue;
                   }
                   else
                   {
                       link0.ForeColor = Color.Red;
                       this.MenuIndex = mIndex;
                   }
               }
           }
       }

    #endregion

   }
