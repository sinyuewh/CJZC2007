using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class saveWordDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// 在此处放置用户代码以初始化页面
		if(!Page.IsPostBack )
		{
            String filename = Request["fileName"];
            if ( Request.Files.Count >0 && String.IsNullOrEmpty(filename)==false)
			{
				HttpPostedFile file1 = Request.Files[0];
                file1.SaveAs(Server.MapPath("Common/AttachFiles/" + filename));
                Response.Write("保存文件成功！");
			}
			else
			{
				Response.Write("保存文件失败！");
			}

            Response.End();
	    }
    }
}
