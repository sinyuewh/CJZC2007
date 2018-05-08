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
using System.Collections.Generic;

public partial class ZcMng3_AddSbb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.MenuKind1.EditMode=false;      //隐藏编辑状态才有的菜单；
            if (Request["zcid"] != null && Request["zcid"].Trim() != String.Empty)
            {
                U_FASPBU bu1 = new U_FASPBU();
                Hashtable ht = bu1.GetInfo1(Request["zcid"]);
                ht["bstatus"] = "0";
                ht["status"] = "04";        //设置为部门审批

                this.Info1.SetControlData(ht);
                this.Info1.NewMode = true;
                this.Info2.NewMode = true;
                this.Info2.EditMode = false;
                
                this.MenuKind1.ZcID = Request["zcid"];
            }


            if (String.IsNullOrEmpty(Request["zcbid"]) == false)
            {
                this.Info1.NewMode = true;
                this.Info2.NewMode = true;
                this.Info2.EditMode = false;
                this.MenuKind1.ZcbID = Request["zcbid"];

                U_ZCBAOBU bu1 = new U_ZCBAOBU();
                DataSet ds= bu1.GetDetailByID(Request["zcbid"], "*");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Hashtable ht2 = new Hashtable();
                    foreach (DataColumn col in dr.Table.Columns)
                    {
                        String colName = col.ColumnName.ToLower().Trim();
                        if (ht2.ContainsKey(colName) == false)
                        {
                            ht2.Add(colName, dr[colName].ToString());
                        }
                    }

                    //调整部分数据
                    ht2["zeren"] = ht2["bzeren"];
                    ht2["xmmc"] = ht2["bname"];
                    ht2["status"] = ht2["bstatus"];
                    ht2["spkind"] = "1";

                    ht2["bstatus"] = "0";
                    ht2["status"] = "04";        //设置为部门审批
                   
                    //根据资产包的信息计算资产的总金额
                    CommTable com1 = new CommTable();
                    com1.TabName = "U_ZCBaoInfo";
                    List<SearchField> condition = new List<SearchField>();
                    condition.Add(new SearchField("bid", Request["zcbid"], SearchFieldType.数值型));
                    DataSet ds0 = com1.SearchData("zcid", condition);
                    String zcid = "";
                    foreach (DataRow dr1 in ds0.Tables[0].Rows)
                    {
                        if (zcid == String.Empty)
                        {
                            zcid = dr1["zcid"].ToString();
                        }
                        else
                        {
                            zcid = zcid + "," + dr1["zcid"].ToString();
                        }
                    }

                    com1.TabName = "U_ZC";
                    condition.Clear();
                    condition.Add(new SearchField("id", zcid, SearchOperator.集合,SearchFieldType.数值型));
                    DataSet ds1 = com1.SearchData("sum(cast(isnull(bj,0) as numeric(18,2))),sum(cast(isnull(lx1,0) as numeric(18,2))),sum(cast(isnull(lx2,0) as numeric(18,2))),sum(cast(isnull(lx3,0) as numeric(18,2)))", condition);
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr2 = ds1.Tables[0].Rows[0];
                        ht2["benjin"]=dr2[0].ToString();
                        ht2["zqce"] = double.Parse(dr2[0].ToString()) + double.Parse(dr2[1].ToString()) 
                            + double.Parse(dr2[2].ToString()) + double.Parse(dr2[3].ToString());
                        ht2["lixi"] = double.Parse(dr2[1].ToString())
                            + double.Parse(dr2[2].ToString()) + double.Parse(dr2[3].ToString());
                    }
                    com1.Close();
                    ////////////////////////////////////////////////////////////////////////
                    this.Info1.SetControlData(ht2);
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.MenuKind1.MenuChange += new EventHandler(MenuKind1_MenuChange);
        base.OnInit(e);
    }

   

    void MenuKind1_MenuChange(object sender, EventArgs e)
    {
        int index1 = this.MenuKind1.MenuIndex;
        for (int i = 1; i <= 4; i++)
        {
            Control con1 = this.MenuKind1.Parent.FindControl("info" + i) as Control;
            if (con1 != null)
            {
                if (i != index1)
                {
                    con1.Visible = false;
                }
                else
                {
                    con1.Visible = true;
                }
            }
        }
    }

    //保存新数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable data = new Hashtable();
        this.Info1.GetControlData(data);
        this.Info2.GetControlData(data);

        if (data["xmmc"].ToString().Trim() != String.Empty)
        {
            //设置某些字段的默认值
            data.Add("zcid", Request["zcid"]);
            //data.Add("spstatus", "0");
            data.Add("spkind", "0");
            data.Add("zcbid", Request["zcbid"]);

            data.Add("time0", DateTime.Now.ToString());

            U_FASPBU bu1 = new U_FASPBU();
            int zcid = bu1.InsertData(data);
            if (zcid != 0)
            {
                Response.Redirect("EditSbb.aspx?id="+zcid, true);
            }
            else
            {
                Util.alert(this.Page, "提示：数据提交错误，可能的原因是网络中断，请重试！");
            }
        }
        else
        {
            Util.alert(this.Page, "错误：项目名称不能为空！");
        }
    }
}
