using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSJ.SysFrame.DB;
using JSJ.CJZC;
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class DangAn_borrow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ajnum.Text = Request.QueryString["ajnum"];
            this.borrow.Text = User.Identity.Name;
            this.time0.Text = DateTime.Now.ToString();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Button1.Click += new EventHandler(Button1_Click);
        base.OnInit(e);
    }

    //提交确定按钮
    void Button1_Click(object sender, EventArgs e)
    {
        String result = DangAnBU.BorrorAnJuan(this.ajnum.Text, this.time0.Text, this.borrow.Text, this.remark.Text);
        if (String.IsNullOrEmpty(result))
        {
            Util.alert(this.Page, "提示：档案借阅申请操作成功!", "BorrowList.aspx");
        }
        else
        {
            Util.alert(this.Page, result);
        }
    }
}
