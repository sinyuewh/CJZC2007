using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JSJ.SysFrame;
using JSJ.CJZC.Business;
using JSJ.SysFrame.DB;
using System.Data;

public partial class ZcMng1_leader_remarkEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String id1 = Request.QueryString["id"];
            CommTable comm1 = new CommTable("u_zctc");
            Hashtable ht1 = new Hashtable();
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", id1, SearchFieldType.数值型));
            DataSet ds1=comm1.SearchData("*", condition);
            if (ds1 != null)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                this.leader_remark.Text = dr1["leader_remark"].ToString();
            }

            
        }
    }

    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }


    protected void button1_Click(object sender, EventArgs e)
    {
        String id1 = Request.QueryString["id"];
        CommTable comm1 = new CommTable("u_zctc");
        Hashtable ht1 = new Hashtable();
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", id1, SearchFieldType.数值型));

        if (this.leader_remark.Text.Trim() != String.Empty)
        {           
            ht1["leader_remark"] = this.leader_remark.Text.Trim();
            ht1["leader_name"] = Page.User.Identity.Name;
            ht1["leader_time"] = DateTime.Now.ToString();
           
        }
        else
        {
            ht1["leader_remark"] = null;
            ht1["leader_name"] = null;
            ht1["leader_time"] = null;
        }
        comm1.EditQuickData(condition, ht1);
        Util.alert(this.Page, "提示：操作成功！", true);
    }
}
