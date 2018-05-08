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
using JSJ.SysFrame.DB;
using System.Collections.Generic;
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class ZcMng3_ChangeZXStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (String.IsNullOrEmpty(Request.QueryString["czid"]) == false)
            {
                String zcResult = this.GetZcResult(Request.QueryString["czid"]);
                PubComm.SetProfile("方案执行结果", this.spresult, "请选择...");
                if (this.spresult.Items.FindByValue(zcResult) != null)
                {
                    this.spresult.SelectedValue = zcResult;
                }

                PubComm.SetProfile(this.spresult.SelectedValue, this.status1, "请选择...");
                PubComm.SetProfile(this.status1.SelectedValue, this.status2, "请选择...");

            }

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("status1", this.status1.SelectedValue);
        ht.Add("status2", this.status2.SelectedValue);
        ht.Add("zcid", Request.QueryString["zcid"]);
        ht.Add("time0", DateTime.Now.ToString());
        ht.Add("zeren", User.Identity.Name);
        if (this.remark.Text.Trim() != String.Empty)
        {
            ht.Add("remark", this.remark.Text);
        }
        else
        {
            ht.Add("remark", "无");
        }

        ht.Add("czid", Request.QueryString["czid"]);
        ht.Add("kind", "2");

        if (this.dotime.Text.Trim() != String.Empty)
        {
            ht.Add("dotime",this.dotime.Text);
        }

        CommTable comm1 = null;
        bool success = false;
        try
        {
            comm1 = new CommTable();
            comm1.TableConnect.BeginTrans();
            //新增U_ZCTC表中的数据
            comm1.TabName = "U_ZCTC";
            comm1.InsertData(ht);

            //更改U_ZC2中表的数据
            String zcid = null;
            String zcbid = null;
            comm1.TabName = "U_ZC2";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", Request.QueryString["czid"]));
            DataSet ds1 = comm1.SearchData("id,zcid,zcbid,spresult,status1,status2,spdotime", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                zcid = dr1["zcid"].ToString().Trim();
                zcbid = dr1["zcbid"].ToString().Trim();

                dr1["spresult"] = this.spresult.SelectedValue;
                dr1["status1"] = this.status1.SelectedValue;
                dr1["status2"] = this.status2.SelectedValue;
                if (String.IsNullOrEmpty(this.dotime.Text.Trim()) == false)
                {
                    dr1["spdotime"] = this.dotime.Text.Trim();
                }
                comm1.Update(ds1);
            }
           
            //更新资产或资产包中的相关数据
            if (String.IsNullOrEmpty(zcid) == false ||
                String.IsNullOrEmpty(zcbid) == false)
            {
                condition.Clear();
                //优先考虑资产包
                if (String.IsNullOrEmpty(zcbid) == false)
                {
                    comm1.TabName = "U_ZCBAO";
                    condition.Add(new SearchField("id", zcbid, SearchFieldType.数值型));
                }
                else
                {
                    comm1.TabName = "U_ZC";
                    condition.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                }

                DataSet ds2 = comm1.SearchData("id,spresult,status1,status2,spdotime", condition);
                if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                {
                    DataRow dr2 = ds2.Tables[0].Rows[0];
                    dr2["spresult"] = this.spresult.SelectedValue;
                    dr2["status1"] = this.status1.SelectedValue;
                    dr2["status2"] = this.status2.SelectedValue;
                    if (String.IsNullOrEmpty(this.dotime.Text.Trim()) == false)
                    {
                        dr2["spdotime"] = this.dotime.Text.Trim();
                    }
                    comm1.Update(ds2);
                }
            }

            comm1.TableConnect.CommitTrans();
            success = true;
        }
        catch (Exception err)
        {
            comm1.TableConnect.RollBackTrans();
        }
        finally
        {
            comm1.Close();
        }

        //更改数据后返回
        if (success)
        {
            Response.Redirect("EditSbb.aspx?id=" + Request.QueryString["czid"] + "&menuIndex=6", true);
        }
        else
        {
            JSJ.SysFrame.Util.alert(this.Page, "提示：数据库事务处理失败，请重试！");
        }
    }

    //更改小类的内容
    protected void status1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.status2.Items.Clear();
        PubComm.SetProfile(this.status1.SelectedValue, this.status2, "请选择...");
    }


    //更改小类的内容
    protected void spresult_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.status1.Items.Clear();
        PubComm.SetProfile(this.spresult.SelectedValue, this.status1, "请选择...");

        this.status2.Items.Clear();
        PubComm.SetProfile(this.status1.SelectedValue, this.status2, "请选择...");
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (this.spresult.SelectedValue == "未启动" || this.spresult.SelectedValue == "其他")
        {
            this.span1.Visible = false;
        }
        else
        {
            this.span1.Visible = true;
        }
        base.OnPreRender(e);
    }


    #region Private Function
    /// <summary>
    /// 得到资产审批的执行状态
    /// </summary>
    /// <param name="spid"></param>
    /// <returns></returns>
    private String GetZcResult(String spid)
    {
        String result = String.Empty;
        CommTable com1 = new CommTable();
        com1.TabName = "U_ZC2";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", spid, SearchFieldType.数值型));
        DataSet ds1 = com1.SearchData("spresult", condition);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds1.Tables[0].Rows[0];
            result = dr["spresult"].ToString().Trim();
        }
        com1.Close();
        return result;
    }
    #endregion
}
