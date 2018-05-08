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

public partial class ZiChan_AddZC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Comm.SetAccess(User.Identity.Name, "资产管理员"); 
           
            //////////////////////////////////////////////
            U_ItemBU item1 = new U_ItemBU();

            item1.ItemName = "总行委贷";
            item1.SetLiteralControl(this.zhwd, "请选择...");

            item1.ItemName = "行业分类";
            item1.SetLiteralControl(this.sshy, "请选择...");

            item1.ItemName = "银行定义";
            item1.SetLiteralControl(this.bank, "请选择...");

            item1.ItemName = "行政区域";
            item1.SetLiteralControl(this.quyu, "请选择...");

            item1.ItemName = "资产性质分类";
            item1.SetLiteralControl(this.fenlei, "请选择...");

            item1.ItemName = "管辖";
            item1.SetLiteralControl(this.guangxia, "请选择...");


            item1.Setuserkind(this.userkind);

            item1.Close();

            Comm.SetZCB(this.zcbao, null);
            this.time0.Text = DateTime.Now.ToShortDateString();
            ///////////////////////////////////////////////
        }
    }

    //增加资产数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        object[] obj1 = new object[] { danwei,bj,lx1,lx2,lx3,
                                       time0,zhuang,remark,htnum,bank,zhwd,num1,sshy,
                                       quyu,fenlei,userkind,zcbao,huobi,huilv,guangxia,};

        string[] info = new string[] { "单位名称", "初始本金", "初始表内息", "初始表外息", "初始孳生利息", "转入时间" };

        bool check = true;
        for (int i = 0; i < info.Length; i++)
        {
            if (Util.GetControlValue((Control)obj1[i]) == null || Util.GetControlValue((Control)obj1[i]) == "")
            {
                check = false;
                Util.alert(this.Page, "错误提示：【" + info[i] + "】栏目不能为空！");
                break;
            }
        }

        // check true
        if (check)
        {
            try
            {
                Hashtable ht = new Hashtable();
                Util.getPageData(obj1, ht);

                U_ZCBU zc1 = new U_ZCBU();
                zc1.TabCommand.InsertData(ht);
                zc1.Close();
                string url = Request.RawUrl;
                Comm.ShowInfo("增加资产数据成功！", url, true);
            }
            catch
            {
                Util.alert(this.Page, "错误提示：增加资产数据失败，可能的原因是数据类型有错误，请检查【转入时间】日期，【本金利息】等为数值型后重新输入！");
            }
        }
    }
}
