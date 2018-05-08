<%@ page title="档案电子稿上传" language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_UploadDangAnFile, App_Web_gn-rd1mt" stylesheettheme="CjzcWeb" %>
<script runat="server">
    protected override void OnInit(EventArgs e)
    {
        this.button1.Click += new EventHandler(button1_Click);
        this.button2.Click += new EventHandler(button2_Click);
        base.OnInit(e);
    }

    void button2_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(this.num2.Text.Trim()) == false)
        {
            Response.Redirect("DangAnFileWeiHu.aspx?num2=" + this.num2.Text.Trim(), true);
        }
        else
        {
            JSJ.SysFrame.Util.alert(this.Page, "错误：请输入正确的档案号！");
        }
    }

    //开始上传档案文件
    void button1_Click(object sender, EventArgs e)
    {
        if (this.num2.Text.Trim() != String.Empty
            && this.file.HasFile)
        {
            if(this.CheckNum2(this.num2.Text.Trim()))
            {
                this.InsertDangAnDianZiFile(this.num2.Text.Trim(), this.file);
            }
            else
            {
                 JSJ.SysFrame.Util.alert(this.Page, "错误：您输入的档案号不存在！");
            }
        }
        else
        {
            JSJ.SysFrame.Util.alert(this.Page, "错误：请输入正确的档案号和正确的电子文件！");
        }
    }

    private void InsertDangAnDianZiFile(String num2,FileUpload file1)
    {
        String fileName1 =System.IO.Path.GetFileName(file1.FileName);
        String Extension = System.IO.Path.GetExtension(file1.FileName);
        String fileName2=Comm.GetMd5(fileName1+System.Guid.NewGuid().ToString())+Extension;
        
        
        JSJ.SysFrame.DB.CommTable com1 = new JSJ.SysFrame.DB.CommTable("DA_AJDZFile");
        Hashtable ht1 = new Hashtable();
        ht1["ajnum"] = num2;
        ht1["time0"] = DateTime.Now.ToString();
        ht1["ljren"] = Page.User.Identity.Name;
        ht1["ajfile"] = fileName1;
        ht1["ajTrueFile"] = fileName2;
        com1.InsertData(ht1);
        com1.Close();
        
        //保存文件到目录
        file1.SaveAs(Server.MapPath("~/common/AttachFiles/"+fileName2));
        JSJ.SysFrame.Util.alert(this.Page, "提示：上传档案电子文件操作成功！");
        
    }
    
    //判断档案号是否存在
    private bool CheckNum2(String num2)
    {
        bool succ = false;
        if (String.IsNullOrEmpty(num2) == false)
        {
            JSJ.SysFrame.DB.CommTable com1 = new JSJ.SysFrame.DB.CommTable("U_ZC");
            System.Collections.Generic.List<JSJ.SysFrame.DB.SearchField> list1 =
                new System.Collections.Generic.List<JSJ.SysFrame.DB.SearchField>();
            list1.Add(new JSJ.SysFrame.DB.SearchField("num2", num2));
            System.Data.DataSet ds1 = com1.SearchData("count(*)", list1);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                int t1 = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                if (t1 > 0)
                {
                    succ = true;
                }
            }
            com1.Close();
        }
        return succ;
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="60%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 档 案 电 子 稿 上 传</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产档案编号：
            </td>
            <td>
                <asp:TextBox ID="num2" runat="server" Width="240"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                档案电子文件：
            </td>
            <td>
                <asp:FileUpload ID="file" runat="server" Width="315" CssClass="text />
            </td>
        </tr>
        <tr height="45">
            <td colspan="2" align="center">
                <asp:Button ID="button1" runat="server" Text="上传档案文件" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="button2" runat="server" Text="浏览以前上传的文件" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
