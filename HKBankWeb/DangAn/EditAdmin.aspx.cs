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
using System.Data;

public partial class DangAn_EditAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PubComm.SetDepart(this.depart, "");
            DataRow dr1 = null;
            if (Request["id"] != null)
            {
                dr1 = DangAnBU.GetAdmin(Request["id"]);
                if (dr1 != null)
                {
                    this.num.Text = dr1["num"].ToString().Trim();
                    if (this.depart.Items.FindByValue(dr1["depart"].ToString().Trim()) != null)
                    {
                        this.depart.SelectedValue = dr1["depart"].ToString().Trim();
                    }
                }
            }

            this.SetUserList();
            if (dr1 != null)
            {
                if (this.sname.Items.FindByValue(dr1["sname"].ToString().Trim()) != null)
                {
                    this.sname.SelectedValue = dr1["sname"].ToString().Trim();
                }
            }
        }
    }


    private void SetUserList()
    {
        String depart1 = this.depart.SelectedValue;
        if (String.IsNullOrEmpty(depart1) == false)
        {
            U_UserNameBU bu1 = new U_UserNameBU();
            DataSet ds1=bu1.GetAllUserList(depart1);
            bu1.Close();

            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                String oldValue = this.sname.SelectedValue;
                this.sname.Items.Clear();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    ListItem list1 = new ListItem(dr["sname"].ToString(), dr["sname"].ToString());
                    this.sname.Items.Add(list1);
                }

                if (this.sname.Items.FindByValue(oldValue) != null)
                {
                    this.sname.SelectedValue = oldValue;
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.depart.SelectedIndexChanged += new EventHandler(depart_SelectedIndexChanged);
        this.Button1.Click += new EventHandler(Button1_Click);
        base.OnInit(e);
    }

    //提交保存数据
    void Button1_Click(object sender, EventArgs e)
    {
        String num1 = this.num.Text.Trim();
        String depart1 = this.depart.SelectedValue;
        String sname1 = this.sname.SelectedValue;
        String id1 = Request.QueryString["id"];
        if (String.IsNullOrEmpty(id1)) id1 = "-1";

        DangAnBU.UpdateAdmin(id1, num1, depart1, sname1);
        Util.alert(this.Page,"提示：操作成功！", "DangAnDepartManageList.aspx");
    }

    void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetUserList();
    }
}
