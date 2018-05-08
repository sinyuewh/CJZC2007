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
using JSJ.SysFrame;
using System.Collections.Generic;
using System.IO;

public partial class ZcMng3_Info1 : System.Web.UI.UserControl
{
    String[] contrArrName ={ "depart", "zeren", "shijian1", "shijian2", "status", "xmsbh", 
                             "num2","xmmc","danwei","bzrmc","zwzg","zqsx","zclx",
                             "zcse","jiazhi","zqce","benjin","lixi","xmbj"};

    protected override void OnLoad(EventArgs e)
    {
        this.shijian1.Attributes["onfocus"] = "setday(this)";
        this.shijian2.Attributes["onfocus"] = "setday(this)";
        this.zqsx.Attributes["onfocus"] = "setday(this)";


        //增加对资产包的处理
        if (!Page.IsPostBack)
        {
            String str1 = Request.RawUrl.ToLower();
            if (str1.IndexOf("zcmng3/editsbb.aspx") > 0)
            {
                this.RowFile1.Visible = true;
            }

            if(String.IsNullOrEmpty(Request["id"])==false)
            {
                this.BindAttachFile(Request["id"]);
            }
        }
        base.OnLoad(e);
    }
    /// <summary>
    /// 设置页面上控件的值
    /// </summary>
    /// <param name="ht"></param>
    public void SetControlData(Hashtable ht)
    {
        foreach (String m in this.contrArrName)
        {
            if (ht.ContainsKey(m))
            {
                Control con1 = this.FindControl(m) as Control;
                if (con1 != null)
                {
                    Util.SetControlValue(con1, ht[m]);      //设置控件的值
                }

                Control con2 = this.FindControl(m+"_1") as Control;
                if (con2 != null)
                {
                    Util.SetControlValue(con2, ht[m]);      //设置控件的值
                }
            }
        }

        //调整部分数据的显示
        if (this.zqce.Text.Trim() != String.Empty)
        {
            this.zqce.Text = String.Format("{0:N2}", double.Parse(this.zqce.Text));
            this.zqce_1.Text = String.Format("{0:N2}", double.Parse(this.zqce.Text));
        }
        if (this.benjin.Text.Trim() != String.Empty)
        {
            this.benjin.Text = String.Format("{0:N2}", double.Parse(this.benjin.Text));
            this.benjin_1.Text = String.Format("{0:N2}", double.Parse(this.benjin.Text));
        }

        if (this.lixi.Text.Trim() != String.Empty)
        {
            this.lixi.Text = String.Format("{0:N2}", double.Parse(this.lixi.Text));
            this.lixi_1.Text = String.Format("{0:N2}", double.Parse(this.lixi.Text));
        }

        if (this.shijian1.Text.Trim() != String.Empty)
        {
            this.shijian1.Text = DateTime.Parse(this.shijian1.Text).ToString("yyyy-MM-dd");
            this.shijian1_1.Text = DateTime.Parse(this.shijian1.Text).ToString("yyyy-MM-dd");
        }

        if (this.shijian2.Text.Trim() != String.Empty)
        {
            this.shijian2.Text = DateTime.Parse(this.shijian2.Text).ToString("yyyy-MM-dd");
            this.shijian2_1.Text = DateTime.Parse(this.shijian2.Text).ToString("yyyy-MM-dd");
        }

        //得到状态的显示
        ZCStatusBU bu1 = new ZCStatusBU();
        this.statusText.Text =bu1.GetTextByStatus(this.status.Text);
        this.statusText_1.Text = this.statusText.Text;
        bu1.Close();

        if (ht["zeren"].ToString() == Page.User.Identity.Name)
        {
            this.tab2.Visible = false;
        }
        else
        {
            this.tab1.Visible = false;
        }
    }

    public bool NewMode
    {
        set
        {
            if (value == true)
            {
                this.tab2.Visible = false;
                this.tab1.Visible = true;
            }
        }
    }


    /// <summary>
    /// 得到页面控件的值
    /// </summary>
    /// <param name="ht"></param>
    public void GetControlData(Hashtable ht)
    {
        if (ht == null)
        {
            ht = new Hashtable();
        }

        foreach (String m in this.contrArrName)
        {
            if (ht.ContainsKey(m) == false)
            {
                Control con1 = this.FindControl(m) as Control;
                if (con1 != null)
                {
                    ht.Add(m, Util.GetControlValue(con1));
                }
            }
        }
    }


    


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.FileBytes.Length > 0)
        {
            String fileName = this.FileUpload1.FileName;
            String savefileName = fileName + "_" + Page.User.Identity.Name + "_" + DateTime.Now.ToString();
            savefileName = Comm.GetMd5(savefileName) + ".data";

            /////////////////////////////////////////
            this.FileUpload1.SaveAs(Server.MapPath("~/Common/AttachFiles/" + savefileName));
            /////////////////////////////////////////
            CommTable comm1 = new CommTable();
            comm1.TabName = "U_CZFile";
            Hashtable ht = new Hashtable();
            ht["czid"] = Request["id"];
            ht["FileName"] = savefileName;
            ht["trueName"] = fileName;
            comm1.InsertData(ht);
            comm1.Close();

            Response.Redirect(Request.PathInfo, true);
        }
        else
        {
            JSJ.SysFrame.Util.alert(this.Page, "请点浏览选择一个要上传的文件！");
        }
    }


    #region private Function
    /// <summary>
    /// 设置资产包的信息
    /// </summary>
    /// <param name="zcbid"></param>
    private void SetZcBaoInfo(String zcbid)
    {
        CommTable com1 = new CommTable();
        com1.TabName = "U_ZCBAO";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("id", zcbid));
        DataSet ds1 = com1.SearchData("bname,bstatus,bzeren", condition);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds1.Tables[0].Rows[0];

        }
        com1.Close();
    }


    /// <summary>
    /// 绑定所包含的附件
    /// </summary>
    /// <param name="zcid"></param>
    private void BindAttachFile(String czid)
    {
        CommTable comm1 = new CommTable();
        comm1.TabName = "U_CZFile";
        List<SearchField> condition = new List<SearchField>();
        condition.Add(new SearchField("czid", czid, SearchFieldType.数值型));
        DataSet ds1 = comm1.SearchData("*", condition);
        this.Repeater1.DataSource = ds1;
        this.Repeater2.DataSource = ds1;
        this.Repeater1.DataBind();
        this.Repeater2.DataBind();
        comm1.Close();
    }
    #endregion

    protected void Button2_Click(object sender, EventArgs e)
    {
        String sel = Request.Form["selFile"];
        if (String.IsNullOrEmpty(sel) == false)
        {
            CommTable comm1 = new CommTable();
            comm1.TabName = "U_CZFile";
            List<SearchField> condition = new List<SearchField>();
            condition.Add(new SearchField("id", sel, SearchOperator.集合,SearchFieldType.数值型));
            DataSet ds1 = comm1.SearchData("*", condition);
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                String fileName = dr["FileName"].ToString();
                dr.Delete();
                String file1 = Server.MapPath("~/Common/AttachFiles/" + fileName);
                if (File.Exists(file1)) File.Delete(file1);
            }
            comm1.Update(ds1);
        }

        Response.Redirect(Request.PathInfo, true);
    }
}
