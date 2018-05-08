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

public partial class CaiWu_ZcBaoBillSearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["SearchCondition"] = HttpContext.Current.Items["SearchCondition"];
            ViewState["SearchKind"] = HttpContext.Current.Items["SearchKind"];
            this.BindData();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
        this.GridView1.RowDeleting += new GridViewDeleteEventHandler(GridView1_RowDeleting);
        base.OnInit(e);
    }

    void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }

    //处理资产包的删除
    void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String id = e.CommandArgument.ToString();
        if (String.IsNullOrEmpty(id) == false)
        {
            string kind = ViewState["SearchKind"].ToString();
            if (kind == "0")
            {
                this.DeleteZcBaoBill(id);
            }
            else if (kind == "1")
            {
                this.DeleteZcBaoBillForPay(id);
            }
            else
            {
                Util.alert(this.Page, "提示：目前删除功能仅支持收款和支出票据！");
            }
            this.BindData();
        }
    }


    private void BindData()
    {
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition"];
        string kind = ViewState["SearchKind"].ToString();
        CW_ShouKuan1BU shoukuan1 = new CW_ShouKuan1BU();
        DataSet ds = shoukuan1.GetBillList(kind, list1, true);
        shoukuan1.Close();
        if (kind == "0" || kind == "1")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["bname"] = "合计";
                dr["bxhj"] = "0";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr["bxhj"] = double.Parse(dr["bxhj"].ToString()) + double.Parse(ds.Tables[0].Rows[i]["bxhj"].ToString());
                }
                ds.Tables[0].Rows.Add(dr);
            }

        }
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }

    //删除资产包单据数据（收款）
    private void DeleteZcBaoBill(String id)
    {
        CommTable com1 = new CommTable();
        com1.TableConnect.BeginTrans();
        try
        {
            //1) 得到单据的信息
            bool flag = false;
            com1.TabName = "CW_ShouKuan1";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = com1.SearchData("*", list1);
            double pbj = 0;
            double plx = 0;
            String bid = String.Empty;
            
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                if (dr1["checktime"].ToString().Trim() != String.Empty)
                {
                    flag = true;            //表示单据已经审核过了
                }

                bid = dr1["bid"].ToString();
                //计算审核过的本金和利息
                if (dr1["pbj"] != DBNull.Value)
                {
                    pbj = double.Parse(dr1["pbj"].ToString());
                }
                if (dr1["plx"] != DBNull.Value)
                {
                    plx = double.Parse(dr1["plx"].ToString());
                }

                dr1.Delete();
                com1.Update(ds1);               //删除单据的数据


                //2) 处理资产包的数据
                if (flag && String.IsNullOrEmpty(bid)==false)
                {
                    list1.Clear();
                    list1.Add(new SearchField("id", bid, SearchFieldType.数值型));
                    com1.TabName = "U_ZCBAO";
                    DataSet ds0 = com1.SearchData("*", list1);
                    if (ds0!=null && ds0.Tables[0].Rows.Count > 0)
                    {
                        double bljsk = 0;
                        if (ds0.Tables[0].Rows[0]["bljsk"] != DBNull.Value)
                        {
                            bljsk = double.Parse(ds0.Tables[0].Rows[0]["bljsk"].ToString());
                        }

                        bljsk = bljsk - pbj - plx;

                        ds0.Tables[0].Rows[0]["bljsk"] = bljsk;   //更新资产包的数据
                        com1.Update(ds0);
                    }
                }
            }

            com1.TableConnect.CommitTrans();        //提交事务处理
        }
        catch (Exception err)
        {
            com1.TableConnect.RollBackTrans();      //取消事务处理
            Util.alert(this.Page, "提示：删除单据操作失败，请重试！");
        }
        finally
        {
            if (com1 != null) { com1.Close(); }
        }
    }


    //删除资产包单据数据（收款）
    private void DeleteZcBaoBillForPay(String id)
    {
        CommTable com1 = new CommTable();
        com1.TableConnect.BeginTrans();

        string[] arr1 = new string[] { "fee1", "fee2","fee3","fee4","fee5","fee6",
                                           "fee7","fee8","fee9","fee10","fee11","fee12" };
        double[] fee = new double[arr1.Length];
        try
        {
            //1) 得到单据的信息
            bool flag = false;
            com1.TabName = "CW_Pay1";
            List<SearchField> list1 = new List<SearchField>();
            list1.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = com1.SearchData("*", list1);
            double pbj = 0;
            double plx = 0;
            String bid = String.Empty;

            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                if (dr1["checktime"].ToString().Trim() != String.Empty)
                {
                    flag = true;            //表示单据已经审核过了
                }

                bid = dr1["bid"].ToString();
                //计算审核过的支出费用
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (dr1[arr1[i]] != DBNull.Value)
                    {
                        fee[i] = double.Parse(dr1[arr1[i]].ToString());
                    }
                }

                dr1.Delete();
                com1.Update(ds1);               //删除单据的数据


                //2) 处理资产包的数据
                if (flag && String.IsNullOrEmpty(bid) == false)
                {
                    list1.Clear();
                    list1.Add(new SearchField("id", bid, SearchFieldType.数值型));
                    com1.TabName = "U_ZCBAO";
                    DataSet ds0 = com1.SearchData("*", list1);
                    if (ds0 != null && ds0.Tables[0].Rows.Count > 0)
                    {
                        double bljzc = 0;
                        double bljzc1 = 0;
                        if (ds0.Tables[0].Rows[0]["bljzc"] != DBNull.Value)
                        {
                            bljzc = double.Parse(ds0.Tables[0].Rows[0]["bljzc"].ToString());
                        }

                        for (int i = 0; i < arr1.Length; i++)
                        {
                            bljzc1 = bljzc1 + fee[i];
                        }
                        ds0.Tables[0].Rows[0]["bljzc"] = bljzc - bljzc1; //更新资产包的数据
                        com1.Update(ds0);
                    }
                }
            }

            com1.TableConnect.CommitTrans();        //提交事务处理
        }
        catch (Exception err)
        {
            com1.TableConnect.RollBackTrans();      //取消事务处理
            Util.alert(this.Page, "提示：删除单据操作失败，请重试！");
        }
        finally
        {
            if (com1 != null) { com1.Close(); }
        }
    }


    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (ViewState["SearchKind"].ToString() == "1")
        {
            this.GridView1.Columns[4].HeaderText = "费用合计";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lab1 = e.Row.FindControl("bname") as Label;
        if (lab1 != null)
        {
            if (lab1.Text == "合计")
            {
                Label lab2 = e.Row.FindControl("Liulan") as Label;
                if (lab2 != null)
                {
                    lab2.Text = "";
                }
            }
        }

        LinkButton link1 = e.Row.FindControl("dellinBtn") as LinkButton;
        if (link1 != null)
        {
            if (PubComm.IsRole("系统管理员") == false || (lab1 != null && lab1.Text == "合计"))
            {
                link1.Visible = false;
            }
        }
    }
}
