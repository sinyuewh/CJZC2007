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
using JSJ.SysFrame;
using JSJ.CJZC;
using JSJ.CJZC.Business;

public partial class ZcMng3_Upgrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        SinConnect conn1 = new SinConnect();
        SinCommand comm1 = new SinCommand(conn1);

        //2）调整U_ZC2中的部分数据
        String sql1 = "select U_ZC.*,U_ZC1.bzrmc from U_ZC left outer join U_ZC1 on U_ZC.id=U_ZC1.id";
        DataSet ds0 = comm1.SearchData(sql1);
        DataColumn col1=ds0.Tables[0].Columns["id"];
        ds0.Tables[0].PrimaryKey = new DataColumn[] { col1 };

        sql1 = "select * from U_ZC2";
        DataSet ds1 = comm1.SearchData(sql1);
        for(int i=0;i<ds1.Tables[0].Rows.Count;i++)
        {
            DataRow dr = ds1.Tables[0].Rows[i];
            DataRow dr1 = ds0.Tables[0].Rows.Find(dr["zcid"]);
            if (dr1 != null)
            {
                double bj = 0;          //本金
                double lixi = 0;        //利息

                dr["num2"] = dr1["num2"];
                dr["xmmc"] = dr1["danwei"];
                dr["danwei"] = dr1["danwei"];
                dr["bzrmc"] = dr1["bzrmc"];


                //计算本金和利息
                if (dr1["bj"].ToString().Trim() != String.Empty)
                {
                    bj = double.Parse(dr1["bj"].ToString().Trim());
                }

                if (dr1["lx1"].ToString().Trim() != String.Empty)
                {
                    lixi =+ double.Parse(dr1["lx1"].ToString().Trim());
                }

                if (dr1["lx2"].ToString().Trim() != String.Empty)
                {
                    lixi = +double.Parse(dr1["lx2"].ToString().Trim());
                }

                if (dr1["lx3"].ToString().Trim() != String.Empty)
                {
                    lixi = +double.Parse(dr1["lx3"].ToString().Trim());
                }

                dr["zqce"] = bj + lixi;
                dr["benjin"] = bj;
                dr["lixi"] = lixi;
                dr["depart"] = dr1["depart"];
                dr["zeren"] = dr1["zeren"];
            }
        }
        comm1.Update(ds1);      //更新ds1的数据

        //3) 将u_zc21中数据导入U_zc2



        //3）在角色表中增加一条数据“领导秘书”
        /*
        sql1 = "select * from U_Roles where Role='领导秘书'";
        ds1.Clear();
        ds1 = comm1.SearchData(sql1);
        int num = 10;
        if (ds1.Tables[0].Rows.Count == 0)
        {
            sql1 = "select top 1 num from U_Roles order by num desc";
            DataSet ds2 = comm1.SearchData(sql1);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                num = int.Parse(ds2.Tables[0].Rows[0]["num"].ToString()) + 1;
            }

            //插入数据
            sql1 = "insert into U_Roles(num,role,remark) values ('"+num+"','领导秘书','领导秘书，可代替领导批阅资产处置方案审批表')";
            comm1.ExecuteNoQuery(sql1);
        }
        */

        comm1.Close();
        conn1.Close();
        Response.Write("<br><center>升级数据库操作成功！</center>");
        Response.End();
    }


    protected override void OnUnload(EventArgs e)
    {
        Util.CloseDefaultConnect();
        base.OnUnload(e);
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        SinConnect conn1 = new SinConnect();
        SinCommand comm1 = new SinCommand(conn1);

        //2）调整U_ZC2中的部分数据
        String sql1 = "select * from U_ZC21 order by zcid ";
        DataSet ds0 = comm1.SearchData(sql1);
       
        sql1 = "select * from U_ZC2";
        DataSet ds1 = comm1.SearchData(sql1);
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            DataRow dr = ds1.Tables[0].Rows[i];
            DataRow[] dr1s= ds0.Tables[0].Select("zcid=" + dr["zcid"].ToString());
            for (int j = 0; j < dr1s.Length; j++)
            {
                if (j < 2)
                {
                    //处置方式
                    dr["czfs" + (j + 1)] = dr1s[j]["czfs"];

                    //具体方法
                    String temp = "";
                    if (dr1s[j]["yjfy"].ToString().Trim() != String.Empty)
                    {
                        temp = "预计费用：" + dr1s[j]["yjfy"];
                    }

                    if (dr1s[j]["czss"].ToString().Trim() != String.Empty)
                    {
                        if (temp != String.Empty)
                        {
                            temp = temp+"\n"+"处置损失：" + dr1s[j]["czss"];
                        }
                        else
                        {
                            temp = "处置损失：" + dr1s[j]["czss"];
                        }
                    }
                    if (temp != String.Empty)
                    {
                        dr["jtfa" + (j + 1)] = temp;
                    }

                    //处置价格
                    dr["czjg" + (j + 1)] = dr1s[j]["czjg"];

                    //清偿率
                    dr["qcl" + (j + 1)] = dr1s[j]["qcl"];
                }
                else
                {
                    break;
                }
            }
            
        }
        comm1.Update(ds1);      //更新ds1的数据

        //3) 将u_zc21中数据导入U_zc2

        comm1.Close();
        conn1.Close();
        Response.Write("<br><center>升级数据库操作成功！</center>");
        Response.End();

    }

    //增加评审员的处理意见
    protected void Button3_Click(object sender, EventArgs e)
    {
       U_RolesBU role = new U_RolesBU();
       String user1 = role.GetRoleAllUsers("资产评审员");
       role.Close();

        SinConnect conn1 = new SinConnect();
        SinCommand comm1 = new SinCommand(conn1);

        //2）调整U_ZC2中的部分数据
        String sql1 = "SELECT * FROM U_ZCSP WHERE (kind = '12') ORDER BY CZID ";
        DataSet ds0 = comm1.SearchData(sql1);
        DataSet ds1 = ds0.Copy();
        foreach(DataRow dr0 in ds1.Tables[0].Rows)
        {
            DataRow dr = ds0.Tables[0].NewRow();
            dr["czid"] = dr0["czid"];
            dr["zcid"] = dr0["zcid"];
            dr["time0"] = dr0["time0"];
            dr["zeren"] = user1;
            dr["time1"] = dr0["time0"];
            dr["remark"] = "同意";
            dr["kind"] = "17";
            dr["ps"] = "同意";
            dr["pscount"] = dr0["pscount"];
            dr["zx"] = dr0["zx"];

            ds0.Tables[0].Rows.Add(dr);
        }
        comm1.Update(ds0);

        comm1.Close();
        conn1.Close();
        Response.Write("<br><center>升级数据库操作成功！</center>");
        Response.End();
    }
}
