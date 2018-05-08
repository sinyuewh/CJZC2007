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
using JSJ.SysFrame.DB;
using System.Collections.Generic;

public partial class ZcMng3_PrintShenBaoBiao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int pos1 = Request.Url.AbsoluteUri.LastIndexOf("/");
            String url1 = Request.Url.AbsoluteUri.Substring(0, pos1);
            this.wordUrl.Value = url1 + "/word1.doc";

            this.BindData();
        }
    }


    //设置数据
    private void BindData()
    {
        if (Request["id"] != null)
        {
            CommTable comm1 = new CommTable();
            comm1.TabName = "U_Zc2";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", Request["id"]));
            Hashtable data=comm1.SearchData(condition);
            comm1.Close();

            if (data != null && data.Count > 0)
            {
                //设置数据1
                this.xmsbh.Value = data["xmsbh"].ToString();
                this.num2.Value = data["num2"].ToString();
                this.xmmc.Value = data["xmmc"].ToString();
                this.zwdw.Value = data["danwei"].ToString();
                this.dbdw.Value = data["bzrmc"].ToString();

                this.zwzgbm.Value = data["zwzg"].ToString();
                this.zqxx.Value = data["zqsx"].ToString();
                this.zclx.Value = data["zclx"].ToString();
                this.zcse.Value = data["zcse"].ToString();
                this.jiazhi.Value = data["jiazhi"].ToString();
                this.zqze.Value = data["zqce"].ToString();

                this.benjin.Value = data["benjin"].ToString();
                this.lixi.Value = data["lixi"].ToString();
                this.xmbj.Value = data["xmbj"].ToString();

                //设置数据2
                this.czfs1.Value = data["czfs1"].ToString();
                this.czba1.Value = data["jtfa1"].ToString();
                this.czjg1.Value = data["czjg1"].ToString();
                this.qcl1.Value = data["qcl1"].ToString();
                this.czfs2.Value = data["czfs2"].ToString();
                this.czba2.Value = data["jtfa2"].ToString();
                this.czjg2.Value = data["czjg2"].ToString();
                this.qcl2.Value = data["qcl2"].ToString();
                this.xgsxsm.Value = data["xgsx"].ToString();

                //设置部门意见
                U_FASPBU bu1 = new U_FASPBU();
                ShenPi info1 = bu1.GetBuMenYiJian(Request["id"]);

                if (info1 != null)
                {
                    this.bmyj.Value = info1.YiJian;
                    this.bmren.Value = info1.Ren;

                    if (info1.ShiJian.Trim() != String.Empty)
                    {
                        this.bmsj.Value = DateTime.Parse(info1.ShiJian).ToString("yyyy年MM月dd日");
                    }
                }

                //设置承办部门和时间
                this.cbbm.Value = data["depart"].ToString();
                this.jbr.Value = data["zeren"].ToString();
                if (data["shijian1"].ToString().Trim() != String.Empty)
                {
                    //this.jbsj.Value = DateTime.Parse(data["shijian1"].ToString().Trim()).ToString("yyyy年MM月dd日");
                }

                //设置评审员的意见
                ShenPi info2 = bu1.GetPSYYiJian(Request["id"]);
                if (info2 != null)
                {
                    this.psyyj.Value = info2.YiJian;
                    this.psyren.Value = info2.Ren;
                    if (info2.ShiJian.Trim() != String.Empty)
                    {
                        this.psysj.Value = DateTime.Parse(info2.ShiJian).ToString("yyyy年MM月dd日");
                    }
                }

                //设置审核委员会信息st
                this.hysj1.Value = data["hysj1"].ToString();
                this.hydd1.Value = data["hydd1"].ToString();
                this.yingdao1.Value = data["yingdao1"].ToString();
                this.shidao1.Value = data["shidao1"].ToString();
                this.quexi1.Value = data["quexi1"].ToString();
                this.zcr1.Value = data["zcr1"].ToString();

                //设置意见信息
                String weiyuan1 = "";
                String weiyuan2 = "";
                String weiyuan3 = "";
                String zhuxi = "";
                String zhuxiTime = "";
                String zhuxiyijian = "";

                JSJ.CJZC.Business.Comm.GetWeiYuan1(Request["id"], "13",
                    out weiyuan1,
                    out weiyuan2, 
                    out weiyuan3,
                    out zhuxi,
                    out zhuxiTime,
                    out zhuxiyijian);

                this.ztwy1.Value = weiyuan1;
                this.fdwy1.Value = weiyuan2;
                this.shren1.Value = zhuxi;
                this.shyj1.Value = zhuxiyijian;
                this.shsj1.Value = zhuxiTime;


                //设置决策委员会信息
                this.hysj2.Value = data["hysj2"].ToString();
                this.hydd2.Value = data["hydd2"].ToString();
                this.yingdao2.Value = data["yingdao2"].ToString();
                this.shidao2.Value = data["shidao2"].ToString();
                this.quexi2.Value = data["quexi2"].ToString();
                this.zcr2.Value = data["zcr2"].ToString();

                JSJ.CJZC.Business.Comm.GetWeiYuan1(Request["id"], "15",
                    out weiyuan1,
                    out weiyuan2,
                    out weiyuan3,
                    out zhuxi,
                    out zhuxiTime,
                    out zhuxiyijian);


                this.ztwy2.Value = weiyuan1;
                this.fdwy2.Value = weiyuan2;
                this.shren2.Value = zhuxi;
                this.shyj2.Value = zhuxiyijian;
                this.shsj2.Value = zhuxiTime;
            }
        }
    }
}
