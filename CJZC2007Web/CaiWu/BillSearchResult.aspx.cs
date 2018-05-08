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

public partial class CaiWu_CheckingBill : System.Web.UI.Page
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


    private void BindData()
    {
        List<SearchField> list1 = (List<SearchField>)ViewState["SearchCondition"];
        string kind = ViewState["SearchKind"].ToString();
        CW_ShouKuanBU shoukuan1 = new CW_ShouKuanBU();
        DataSet ds = shoukuan1.GetBillList(kind, list1,true );
        shoukuan1.Close();
        if (kind == "0" || kind == "1")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["danwei1"] = "合计";
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


    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (ViewState["SearchKind"].ToString() == "1")
        {
            this.GridView1.Columns[4].HeaderText = "费用合计";
        }
        if (ViewState["SearchKind"].ToString() == "2" || ViewState["SearchKind"].ToString() == "3")
        {
            this.GridView1.Columns[4].Visible = false;
        }

    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lab1 = e.Row.FindControl("danwei") as Label;
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

        if (e.Row.FindControl("dellinBtn") != null)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("dellinBtn");
            if (Comm.IsRole("系统管理员") == false)
            {
                link1.Visible = false;
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (id != "")
        {
            this.DeleteData(id, ViewState["SearchKind"].ToString());
        }

        this.BindData();
    }


    #region Private Function
    //删除单据
    private void DeleteData(String billid, String billkind)
    {
        String kind = ViewState["SearchKind"].ToString();
        if (kind == "0")
        {
            this.DeleteShoukuan(billid);             //删除收款凭证
        }
        else if (kind == "1")
        {
            this.DeletePay(billid);                 //删除付款凭证
        }
        else if (kind == "2")
        {
            JSJ.SysFrame.Util.alert(this.Page, "提示：暂时不支持入库凭证的删除");
            this.BindData();
            //this.DeleteInstock(billid);             //删除入库凭证
        }
        else if (kind == "3")
        {
            //this.DeleteOutstock(billid);            //删除出库凭证  
            JSJ.SysFrame.Util.alert(this.Page, "提示：暂时不支持出库凭证的删除");
            this.BindData();
        }
        else
        {
            ;
        }
    }


    //删除收款凭证
    private void DeleteShoukuan(String id)
    {
        List<SearchField> condition = new List<SearchField>();
        CommTable com1 = new CommTable();
        com1.TableConnect.BeginTrans();
        try
        {
            com1.TabName = "CW_ShouKuan";
            condition.Add(new SearchField("id", id, SearchFieldType.数值型));
            DataSet ds1 = com1.SearchData("*", condition);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                String zcid = dr1["zcid"].ToString();
                String checktime = dr1["checktime"].ToString().Trim();
                double  pbj = 0;
                if (String.IsNullOrEmpty(dr1["pbj"].ToString().Trim()) == false)
                {
                    pbj=double.Parse(dr1["pbj"].ToString());
                }
                double plx = 0;
                if(String.IsNullOrEmpty(dr1["plx"].ToString().Trim())==false)
                {
                    plx=double.Parse(dr1["plx"].ToString());
                }

                //删除收款凭证的数据
                dr1.Delete();
                com1.Update(ds1);

                //如果收款凭证已审核，则需调整资产中的相关数据
                if (String.IsNullOrEmpty(checktime) == false)
                {
                    com1.TabName = "u_zc3";
                    condition.Clear();
                    condition.Add(new SearchField("id", zcid, SearchFieldType.数值型));
                    DataSet ds2 = com1.SearchData("*", condition);
                    if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr2 = ds2.Tables[0].Rows[0];
                        dr2["pbj"]=double.Parse(dr2["pbj"].ToString())-pbj;
                        dr2["plx"]=double.Parse(dr2["plx"].ToString())-plx;
                        com1.Update(ds2);
                    }
                }
            }
            com1.TableConnect.CommitTrans();
        }
        catch (Exception err)
        {
            com1.TableConnect.RollBackTrans();
        }
        finally
        {
            com1.Close();
        }
    }


    //删除付款
    private void DeletePay(String id)
    {
        List<SearchField> condition = new List<SearchField>();
        CommTable com1 = new CommTable();
        com1.TableConnect.BeginTrans();
        try
        {
            com1.TabName = "CW_Pay";
            condition.Add(new SearchField("id",id,SearchFieldType.数值型));
            DataSet ds1=com1.SearchData("*",condition);
            Hashtable fee = new Hashtable();
            if(ds1!=null && ds1.Tables[0].Rows.Count>0)
            {
                DataRow dr1=ds1.Tables[0].Rows[0];
                String zcid=dr1["zcid"].ToString();
                String checktime=dr1["checktime"].ToString().Trim();
                for(int i=1;i<=20;i++)
                {
                    string key1="fee"+i;
                    double temp=0;
                    if(String.IsNullOrEmpty(dr1[key1].ToString().Trim())==false)
                    {
                        temp=double.Parse(dr1[key1].ToString().Trim());
                    }
                    fee.Add(key1,temp);
                }

                //删除付款凭证数据
                dr1.Delete();
                com1.Update(ds1);

                //如果付款凭证已审核，则调整相关资产的数据
                if(String.IsNullOrEmpty(checktime)==false)
                {
                    com1.TabName="U_Zc3";
                    condition.Clear();
                    condition.Add(new SearchField("id",zcid,SearchFieldType.数值型));
                    DataSet ds2=com1.SearchData("*",condition);
                    if(ds2!=null && ds2.Tables[0].Rows.Count>0)
                    {
                        DataRow dr2=ds2.Tables[0].Rows[0];
                        foreach (DictionaryEntry item in fee)
                        {
                            if(0 != (double)item.Value)
                            {
                                dr2[item.Key.ToString()] = double.Parse(dr2[item.Key.ToString()].ToString()) - (double)item.Value;
                            }
                        }
                        com1.Update(ds2);
                    }
                }
            }
            com1.TableConnect.CommitTrans();
        }
        catch (Exception err)
        {
            com1.TableConnect.RollBackTrans();
        }
        finally
        {
            com1.Close();
        }
    }


    //删除入库凭证
    private void DeleteInstock(String id)
    {
    }

    //删除出库凭证
    private void DeleteOutstock(String id)
    {
    }
    #endregion
}
