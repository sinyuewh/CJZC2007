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
using JSJ.SysFrame.DB;

public partial class ZcMng3_ZcZx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["kind"] != null && Request["kind"].Trim() != String.Empty)
            {
                ZCStatusBU bu1 = new ZCStatusBU();
                this.dckind.Text=bu1.GetTextByStatus(Request["kind"]);
                bu1.Close();
            }
        }
    }


    //取消返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditSbb.aspx?menuIndex=6&id="+Request["czid"], true);
    }

    //执行数据处理
    protected void Button2_Click(object sender, EventArgs e)
    {
        CommTable comm1 = new CommTable();
        comm1.TableConnect.BeginTrans();
        try
        {
            comm1.TabName = "U_ZCTC";
            Hashtable data = new Hashtable();
            data["zcid"] = Request["zcid"];
            data["czid"] = Request["czid"];
            data["time0"] = DateTime.Now.ToString();
            data["remark"] = this.remark.Text;
            data["didian"] = this.didian.Text;
            data["jieguo"] = this.jieguo.Text;
            data["kind"] = Request["kind"];
            data["zeren"] = User.Identity.Name;
            comm1.InsertData(data);

            //更新U_ZC和U_ZC2中的相关状态数据
            if (Request["kind"] != null)
            {
                SearchField search0 = new SearchField("id", Request["zcid"]);
                comm1.TabName = "U_ZC";
                Hashtable ht = new Hashtable();
                ht["status"] = Request["kind"].Trim();
                comm1.EditQuickData(search0, ht);

                comm1.TabName = "U_ZC2";
                search0 = new SearchField("id", Request["czid"]);
                comm1.EditQuickData(search0, ht);
            }
            comm1.TableConnect.CommitTrans();
            this.Button1_Click(sender, e);
        }
        catch (Exception err)
        {
            comm1.TableConnect.RollBackTrans();
            JSJ.SysFrame.Util.alert(this.Page, "错误：数据库事务错误，请重试！");
        }

        comm1.Close();
    }
}
