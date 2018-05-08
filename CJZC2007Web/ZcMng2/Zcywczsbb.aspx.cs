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
using System.Drawing;
using JSJ.CJZC.Business;
using JSJ.SysFrame;

public partial class ZcMng2_Zcywczsbb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Bind();
            this.BindSP(null);
        }
    }
    private void Bind()
    {
        if(Request["id"]!=null)
        {
            string id = Request["id"].ToString();
            U_ZCBU zc1 = new U_ZCBU();
            DataSet ds = zc1.GetZcsbbInfoByID(id);
            string[] arr1 = new string[] {"id","zclx","zcse","xmbj","fsxzly","djyj" };
            for (int i = 0; i < arr1.Length; i++)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Util.SetControlValue(this.zclx.Parent.FindControl(arr1[i]),ds.Tables[0].Rows[0][arr1[i]].ToString());
                }
            }
            this.BindZCCZDetail(zc1);
            U_ZCSPBU sp1 = new U_ZCSPBU();
            sp1.SetPC(this.pc1,id);
            sp1.Close();
            zc1.Close();
        }
    }

    //绑定【资产审批情况】明细
    private void BindSP(U_ZCSPBU sp1)
    {
        if (this.id.Text != "")
        {
            bool flag = false;
            if (sp1 == null)
            {
                sp1 = new U_ZCSPBU();
                flag = true;
            }

            for (int i = 11; i <= 15; i++)
            {
                Repeater repeater1 = this.Repeater11.Parent.FindControl("Repeater" + i) as Repeater;
                if (repeater1 != null)
                {
                    DataSet ds1 = sp1.GetZcSPList(this.id.Text, i + "");
                    repeater1.DataSource = ds1;
                    repeater1.DataBind();

                    if (ds1.Tables[0].Rows.Count == 0)
                    {
                        repeater1.Visible = false;
                    }
                }
            }
            if (flag)
            {
                sp1.Close();
            }
        }
    }


    //绑定资产处置方式明细
    private void BindZCCZDetail(U_ZCBU zc1)
    {
        if (this.id.Text != "")
        {
            DataSet ds2 = zc1.GetCZFSByCZID(this.id.Text);
            this.Repeater6.DataSource = ds2;
            this.Repeater6.DataBind();
            ds2.Dispose();
        }
    }

}
