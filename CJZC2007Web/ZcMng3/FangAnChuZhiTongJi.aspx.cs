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

public partial class ZcMng3_FangAnChuZhiTongJi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String time0 = DateTime.Parse(Request["time0"]).ToString("yyyy-MM-dd");
            String time1 = DateTime.Parse(Request["time1"]).ToString("yyyy-MM-dd");
            this.BindData1(time0, time1);
            if (Request["tjkind"] == "0")
            {
                this.tjkind.Text = "单个资产";
            }
            else
            {
                this.tjkind.Text = "资产包";
            }
        }
    }

    private void BindData1(String time0, String time1)
    {
        const int MAX_Col = 28;

        //定义类型Hash        
        Hashtable HA = new Hashtable();
        //-----------协商处置--------------------
        HA.Add("协商处置", 6);
        HA.Add("谈判", 7);
        HA.Add("签订协议", 8);
        HA.Add("部分执行", 9);
        HA.Add("全部执行", 10);

        //-----------诉讼处置---------------------
        HA.Add("诉讼处置", 11);
        HA.Add("立案", 12);
        HA.Add("财产保全", 13);
        HA.Add("一审", 14);
        HA.Add("二审", 15);
        HA.Add("申请执行", 16);
        HA.Add("结案", 17);
        HA.Add("中止执行", 18);
        HA.Add("终止执行", 19);

        //----------其他方式--------------------
        HA.Add("其他方式", 20);
        HA.Add("打包处置", 21);
        HA.Add("委托拍卖", 22);
        HA.Add("合作处置", 23);
        HA.Add("委托追偿", 24);
        HA.Add("债权重组", 25);
        HA.Add("破产清偿", 26);


        //计算合计的数组
        int[] total=new int[MAX_Col+2];
        for (int i = 0; i < total.Length; i++)
        {
            total[i] = 0;
        }
        
        //定义ZcID的动态数组
        List<string> ArrZcID = new List<string>();
       
        //定义动态的Table数据
        DataTable dt = new DataTable();
        for (int i = 1; i <= MAX_Col; i++)
        {
            dt.Columns.Add("col" + i);
        }
        dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };      //设置部门名称为主键

        //构建查询的SQL语句 (按项目申报时间来进行统计）
        //统计单条资产的情况
        String keyid = "zcid";
        String sql = @"select u_zc2.id,zcid,u_zc2.depart,shijian1,hysj1,hysj2,status1,status2
                       from u_zc2 inner join u_depart on u_zc2.depart=u_depart.depart
                       where (hysj1 is not null or hysj2 is not null) and zcid is not null ";

        if(Request["tjkind"]=="1")
        {
           sql= @"select u_zc2.id,zcbid,u_zc2.depart,shijian1,hysj1,hysj2,status1,status2
                from u_zc2 inner join u_depart on u_zc2.depart=u_depart.depart
                where (hysj1 is not null or hysj2 is not null) and zcbid is not null ";
           keyid = "zcbid";
        }

        if (String.IsNullOrEmpty(time0) == false)
        {
            sql = sql + " and ( (hysj2 is null and cast(hysj1 as datetime)>='" + time0.Trim()+"') or (hysj2 is not null and cast(hysj2 as datetime)>='"+time0.Trim()+"' ))";
        }
        if (String.IsNullOrEmpty(time1) == false)
        {
            time1 = time1 + " 23:59:59";
            sql = sql + " and ( (hysj2 is null and cast(hysj1 as datetime)<='" + time1.Trim() + "') or (hysj2 is not null and cast(hysj2 as datetime)<='" + time1.Trim() + "' ))";
       
        }
        sql = sql + " order by u_depart.num,hysj2 desc,hysj1 desc";
        
        
        
        ////////////////////////////////////////////////////////////////
        CommTable com1 = new CommTable();
        DataSet ds = com1.TableComm.SearchData(sql);
        foreach (DataRow dr1 in ds.Tables[0].Rows)
        {
            if (ArrZcID.Contains(dr1[keyid].ToString().Trim()) == false)
            {
                ArrZcID.Add(dr1[keyid].ToString().Trim());       //避免重复的zcid
                String depart1 = dr1["depart"].ToString();
                DataRow data1 = dt.Rows.Find(depart1);
                if (data1 == null)
                {
                    data1 = dt.NewRow();
                    data1["col1"] = depart1;
                    for (int i = 2; i <= MAX_Col; i++)
                    {
                        data1["col" + i] = "0";
                    }
                    dt.Rows.Add(data1);
                }

                //计算申报数量
                data1["col2"] = (int.Parse(data1["col2"].ToString()) + 1) + "";
                total[2]++;

                //计算批准项目
                String kind1 = this.GetSpKind(dr1["id"].ToString().Trim(), com1);
                if (kind1 == "1" || kind1 == "2")
                {
                    data1["col3"] = (int.Parse(data1["col3"].ToString()) + 1) + "";
                    total[3]++;
                    if (kind1 == "1")
                    {
                        data1["col4"] = (int.Parse(data1["col4"].ToString()) + 1) + "";
                        total[4]++;
                    }
                    else
                    {
                        data1["col5"] = (int.Parse(data1["col5"].ToString()) + 1) + "";
                        total[5]++;
                    }
                }

                //计算执行状态
                String zx1 = dr1["status1"].ToString().Trim();
                if (zx1 != String.Empty && HA.ContainsKey(zx1))
                {
                    data1["col" + (int)HA[zx1]] = (int.Parse(data1["col" + (int)HA[zx1]].ToString()) + 1) + "";
                    total[(int)HA[zx1]]++;
                }

                String zx2 = dr1["status2"].ToString();
                if (zx2 != String.Empty && HA.ContainsKey(zx2))
                {
                    data1["col" + (int)HA[zx2]] = (int.Parse(data1["col" + (int)HA[zx2]].ToString()) + 1) + "";
                    total[(int)HA[zx2]]++;
                }
            }

        }
        com1.Close();

        //增加合计的行
        if (total[2] > 0)
        {
            DataRow HejiRow =dt.NewRow();
            HejiRow["col1"] = "合计";
            for (int i = 2; i <= MAX_Col; i++)
            {
                HejiRow["col" + i] = total[i].ToString();
            }
            dt.Rows.Add(HejiRow);
        }

        //调整数据的显示
        /*
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                String temp = dr[dt.Columns[j].ColumnName].ToString().Trim();
                if (temp == "0")
                {
                    dr[dt.Columns[j].ColumnName] = " ";
                }
            }
        }*/

        ///////////////////////////////////////////////////////////////////
        this.repeater2.DataSource = dt;
        this.repeater2.DataBind();
    }

   
    //计算资产的审批状态 0－审批中 1－审核委员会批 2－决策委员会批
    private String GetSpKind(String czid, CommTable com1)
    {
        String result = "0";
        String sql = @"select kind from u_zcsp where czid=" + czid + " and ps='同意' and zx is not null and (kind='13' or kind='15' ) ";
        DataSet ds = com1.TableComm.SearchData(sql);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["kind"].ToString() == "13")
            { 
                result = "1"; 
            }
            else
            {
                result = "2";
            }
        }
        return result;
    }
}
