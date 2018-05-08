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
using System.Collections.Generic;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using JSJ.CJZC.Business;

public partial class ZcMng1_AdvanceSearch : System.Web.UI.UserControl
{
    public event EventHandler OnMySearchClick;
    private List<SearchField> searchcondition=null;

    //设置部门行的隐藏状态与否
    public void SetDepartRow(bool RowVisible)
    {
        this.DepartRow.Visible = RowVisible;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Comm.SetDepart(this.depart, "所有部门");
            Comm.SetZCStatus(this.status, "所有状态");
            

            /////////////////////////////////////

            this.depart.SelectedValue = "";
            this.zcbao.SelectedValue = "";
            ///////////////////////////////////////
            U_ItemBU item1 = new U_ItemBU();
            item1.ItemName = "政策包";
            item1.SetLiteralControl(this.zcbao, "全部...");
            this.zcbao.SelectedValue = "";

            item1.ItemName = "行政区域";
            item1.SetLiteralControl(this.quyu, "全部...");

            item1.ItemName = "行业分类";
            item1.SetLiteralControl(this.hangye, "全部...");

            item1.ItemName = "资产性质分类";
            item1.SetLiteralControl(this.fenlei, "全部...");

            
            item1.Close();

            U_ZCBAOBU zcb1 = new U_ZCBAOBU();
            zcb1.SetBstatus(this.Bstatus, "全部...");
            zcb1.Close();
            ////////////////////////////////////////////

            depart_SelectedIndexChanged(this.depart, e);

            U_ItemBU item = new U_ItemBU();
            item.Setuserkind(this.userkind);
            item.Close();


            //调整执行状态的选择 (====2013年新增=====）
            Comm.SetProfile("方案执行结果", this.spresult, "");
            Comm.SetProfile("方案执行状态大类", this.status1, "全部...");

            //this.status1.Items.Add(new ListItem("全部...", ""));
            this.status2.Items.Add(new ListItem("全部...", ""));
           
        }

        this.danwei.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.Button1.ClientID + ".click(); return false; } ");
        this.num1.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.Button1.ClientID + ".click(); return false; } ");
        this.num2.Attributes.Add("onkeydown", "javascript:if( event.keyCode == 13 ) { " + this.Button1.ClientID + ".click(); return false; } ");
    }

    //建立资产的查询条件
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<SearchField> list1 = new List<SearchField>();
        ////////////////////////////////////////////////
        //单位名称1
        if (this.danwei.Text.Trim() != "")
        {
            list1.Add(new SearchField("danwei", this.danwei.Text.Trim(), SearchOperator.包含));
        }


        if (this.num1.Text.Trim() != "")
        {
            list1.Add(new SearchField("num1", this.num1.Text.Trim(), SearchOperator.包含));
        }



        if (this.num2.Text.Trim() != "")
        {
            string num2 = this.num2.Text.Trim();
            string num2Search = "";
            string[] str = num2.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    num2Search = "charindex('" + str[i].Trim() + "',num2) > 0";
                }
                else
                {
                    num2Search = num2Search + " or charindex('" + str[i].Trim() + "',num2) > 0";
                }
            }
            if (num2Search != "")
            {
                list1.Add(new SearchField("", num2Search, SearchOperator.用户定义));
            }
        }


        //政策包3
        if (this.zcbao.SelectedValue != "")
        {
            list1.Add(new SearchField("zcbao", this.zcbao.SelectedValue));
        }

        //行业
        if (this.hangye.SelectedValue != "")
        {
            list1.Add(new SearchField("sshy", this.hangye.SelectedValue));
        }

        //区域
        if (this.quyu.SelectedValue != "")
        {
            list1.Add(new SearchField("quyu", this.quyu.SelectedValue));
        }

        //管辖
        if (this.Bstatus.SelectedValue != "")
        {
            list1.Add(new SearchField("Bstatus", this.Bstatus.SelectedValue));
        }

        //资产类别
        if (this.fenlei.SelectedValue != "")
        {
            list1.Add(new SearchField("fenlei", this.fenlei.SelectedValue));
        }

        //责任部门4
        if (this.depart.SelectedValue != "")
        {
            list1.Add(new SearchField("depart", this.depart.SelectedValue));
        }
        //责任人5
        if (this.zeren.SelectedValue != "")
        {
            list1.Add(new SearchField("zeren", this.zeren.SelectedValue));
        }
        //资产状态

        if (this.status.SelectedValue != "")
        {
            if (this.status.SelectedValue.Length > 1)
            {
                list1.Add(new SearchField("status", this.status.SelectedValue));
            }
            else
            {
                list1.Add(new SearchField("left(status,1)", this.status.SelectedValue));
            }
        }

        //用户自定义分类

        string userkind = "";
        int last = 0;
        bool first = true;
        string userkind2 = "";
        for (int i = 0; i < this.userkind.Items.Count; i++)
        {
            ListItem list2 = this.userkind.Items[i];
            if (list2.Selected)
            {
                last = i;
            }
        }
        for (int i = 0; i < this.userkind.Items.Count; i++)
        {
            ListItem list3 = this.userkind.Items[i];
            if (list3.Selected)
            {
                if (first)
                {
                    userkind = " ( charindex('" + list3.Value + "',userkind) >0 ";
                    first = false;
                }
                if (first == false && i < last)
                {
                    userkind = userkind + " or  charindex('" + list3.Value + "',userkind) >0 ";
                }
                if (first == false && i == last)
                {
                    userkind = userkind + " or  charindex('" + list3.Value + "',userkind) >0 )";
                }
                if (first == true && i == last)
                {
                    userkind = " charindex('" + list3.Value + "',userkind) >0 ";
                }
                if (userkind2 == "")
                {
                    userkind2 = list3.Value;
                }
                else
                {
                    userkind2 = userkind2 + "," + list3.Value;
                }
            }
        }
        if (userkind != "")
        {
            list1.Add(new SearchField("", userkind, SearchOperator.用户定义));
        }

        //是否包含资产包内的资产（不包含资产包的资产）
        if (this.SearchKind.SelectedValue == "0")
        {
            Hashtable ht1 = new Hashtable();
            String[] str1 = new String[] { "FixZcUserKind.aspx", "FixZcBao.aspx",
                                           "MyZc.aspx", "MyFixZcUserKind.aspx" };
            String[] str2 = new String[] { "ZiChangFengPei.aspx", "FixZeren.aspx" };
            String[] str3 = new String[] { "MyZcTime0.aspx" };
            String[] str4 = new String[] { "MyDepartZc.aspx" };
            String[] str5 = new String[] { "MyDepartZcTime0.aspx" };
            foreach (String m in str1)
            {
                ht1.Add(m.ToLower().Trim(), "U_ZC");
            }
            foreach (String m in str2)
            {
                ht1.Add(m.ToLower().Trim(), "ZCView");
            }
            foreach (String m in str3)
            {
                ht1.Add(m.ToLower().Trim(), "ZCTimeView");
            }
            foreach (String m in str4)
            {
                ht1.Add(m.ToLower().Trim(), "ZCMyDepartZc");
            }
            foreach (String m in str5)
            {
                ht1.Add(m.ToLower().Trim(), "ZCDepartTimeView");
            }

            String v1 = "U_ZC";
            String oldUrl = Request.RawUrl.ToLower().Trim();
            foreach (DictionaryEntry m in ht1)
            {
                String key1 = m.Key.ToString();
                if (oldUrl.Contains(key1))
                {
                    v1 = m.Value.ToString();
                    break;
                }
            }

            String searchValue = String.Format("not exists (select * from u_zcbaoinfo where u_zcbaoinfo.zcid={0}.id)", v1);
            list1.Add(new SearchField(searchValue, "", SearchOperator.用户定义));
        }

        #region Code1
        /*
        String sql1 = "( 1=1 ";
        String sql0 = sql1;
        String ViewName = "U_ZC2SearchView2";
        if (this.SearchKind.SelectedValue=="1")
        {
            ViewName = "U_ZC2BaoSearchView2";
        }

        //5－审批状态
        String sp1 = JSJ.SysFrame.Util.getListControlValue(this.spstatus);
        if (String.IsNullOrEmpty(sp1) == false)
        {
            sql1 = sql1 + " and TB.spstatus in(" + sp1 + ")";
        }

        //6－执行结果（处理没有审批表的情况）
        sp1 = JSJ.SysFrame.Util.getListControlValue(this.spresult);
        if (String.IsNullOrEmpty(sp1) == false)
        {
            sp1 = sp1.Replace(",", "','");
            sql1 = sql1 + " and ( TB.spresult in('" + sp1 + "')";

            //处理其他的选项
            if (sp1.IndexOf("其他") >= 0)
            {
                sql1 = sql1 + " or ( TB.spresult is null or TB.spresult='' )";
            }
            sql1 = sql1 + " ) ";
        }


        //7－执行状态1
        if (String.IsNullOrEmpty(this.status1.SelectedValue) == false)
        {
            sql1 = sql1 + " and TB.status1='" + this.status1.SelectedValue + "'";
        }

        //8－执行状态2
        if (String.IsNullOrEmpty(this.status2.SelectedValue) == false)
        {
            sql1 = sql1 + " and TB.status2='" + this.status2.SelectedValue + "'";
        }

        //9－执行时间1
        if (String.IsNullOrEmpty(this.time1.Text.Trim()) == false)
        {
            sql1 = sql1 + " and TB.spdotime>='" + this.time1.Text.Trim() + "'";
        }

        //执行时间2
        if (String.IsNullOrEmpty(this.time2.Text.Trim()) == false)
        {
            String t2 = DateTime.Parse(this.time2.Text.Trim()).ToString("yyyy-MM-dd") + " 23:59:59";
            sql1 = sql1 + " and TB.spdotime<='" + t2 + "'";
        }
        sql1 = sql1 + " ) ";
        sql0 = sql0 + " ) ";
        sql1 = sql1.Replace("TB.", ViewName + ".");



        if (sql1 != sql0)
        {
            list1.Add(new SearchField(sql1, "", SearchOperator.用户定义));
        }*/
        #endregion


        if (OnMySearchClick != null)
        {
            this.searchcondition = list1;
            OnMySearchClick(this, e);  //发送点击事件
        }
    }


    public List<SearchField> SearchConditon
    {
        get
        {
            return this.searchcondition;
        }
    }

    //选择修改部门
    protected void depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depart1 = this.depart.SelectedValue;
        Comm.SetZeRen(this.zeren, depart1, "所有责任人");
        this.zeren.SelectedValue = "";
    }


    protected void status1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.status2.Items.Clear();
        Comm.SetProfile(this.status1.SelectedValue, this.status2, "全部...");
    }
    
}
