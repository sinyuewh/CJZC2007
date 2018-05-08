<%@ Page Language="C#" %>
<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int pos1 = Request.Url.AbsoluteUri.LastIndexOf("/");
            String url1 = Request.Url.AbsoluteUri.Substring(0, pos1);
            this.wordUrl.Value = url1 + "/mydata.xls";
            this.filetype.Value = System.IO.Path.GetExtension(this.wordUrl.Value).Replace(".", "");
        }
        base.OnLoad(e);
    }
</script>

<html>
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">              
        function myLoad()
        {
            var url=document.getElementById("wordUrl").value;
            document.getElementById("WebOffice1").OptionFlag=0x0400;
            var type1=document.getElementById("filetype").value;
            if(type1=="txt") type1="doc";
            
            flag =document.getElementById("WebOffice1").LoadOriginalFile(url,type1);
            if( flag==0 )
            {
		        alert("启动Office失败，请检查Office 是否正确安装后重试！");
	        }	
	        else
	        {
	            document.getElementById("WebOffice1").ShowToolBar=0;
	            HiddenMenuAndBar();
	            
	            document.getElementById("WebOffice1").SetTrackRevisions(1);
	            document.getElementById("WebOffice1").ShowRevisions(0);
	            
	            //设置Excel的数据
	            var xlBook=new Object(document.getElementById("WebOffice1").GetDocumentObject());
	            var xlsheet1 = xlBook.Worksheets(1);
	            
	            //得到父窗体的表格数据
	            var t1=window.opener.tab1;          
                for(var i=0;i<t1.rows.length;i++)
                {
                    for(var j=0;j<t1.rows[i].cells.length;j++)
                    {
                        var value1=t1.rows[i].cells[j].innerText;
                        xlsheet1.cells(i+1,j+1)=value1.trim();
                    }
                }
                
                
                //设置第二个单元格的数据
                xlsheet1 = xlBook.Worksheets(2);
                for(var i=0;i<t1.rows.length;i++)
                {
                    for(var j=0;j<t1.rows[i].cells.length;j++)
                    {
                        var value1=t1.rows[i].cells[j].innerText;
                        xlsheet1.cells(i+1,j+1)=value1.trim();
                    }
                }
            }
        }
                             	        
        //关闭窗口
        function myUnload()
        {
            RestoreMenuAndBar();
            document.getElementById("WebOffice1").CloseDoc(0);
            document.getElementById("WebOffice1").close();
        }
        
        function HiddenMenuAndBar()
        {
	        //屏蔽标准工具栏的前几个按钮
	        //document.getElementById("WebOffice1").SetToolBarButton2("Standard",1,1);
	        //document.getElementById("WebOffice1").SetToolBarButton2("Standard",2,1);
	        document.getElementById("WebOffice1").SetToolBarButton2("Standard",3,1);
	        //document.getElementById("WebOffice1").SetToolBarButton2("Standard",6,1);  
        	
	        //屏蔽文件菜单项
	        //document.getElementById("WebOffice1").SetToolBarButton2("Menu Bar",1,1);
	        //屏蔽 保存快捷键(Ctrl+S) 
	        document.getElementById("WebOffice1").SetKeyCtrl(595,-1,0);
	        //屏蔽 打印快捷键(Ctrl+P) 
	        //document.getElementById("WebOffice1").SetKeyCtrl(592,-1,0);
	        
	        //禁止文件保存
	        //document.getElementById("WebOffice1").SetSecurity(0x02);
        }

        //恢复菜单和Bar
        function RestoreMenuAndBar()
        {
	        //恢复被屏蔽的菜单项和快捷键
	        document.getElementById("WebOffice1").SetToolBarButton2("Standard",1,3);
	        document.getElementById("WebOffice1").SetToolBarButton2("Standard",2,3);
	        document.getElementById("WebOffice1").SetToolBarButton2("Standard",3,3);
	        document.getElementById("WebOffice1").SetToolBarButton2("Standard",6,3); 
        	
	        //恢复文件菜单项
	        document.getElementById("WebOffice1").SetToolBarButton2("Menu Bar",1,4);
	        //恢复 保存快捷键(Ctrl+S) 
	        document.getElementById("WebOffice1").SetKeyCtrl(595,0,0);
	        //恢复 打印快捷键(Ctrl+P) 
	        document.getElementById("WebOffice1").SetKeyCtrl(592,0,0);
	        
	        //恢复文件保存
	        //document.getElementById("WebOffice1").SetSecurity(0x02+0x8000);
        }
        
        //保存Excel表格
        function SaveDoc()
        {
            document.getElementById("WebOffice1").ShowDialog(84);
        }
        
        String.prototype.trim = function()
       {
            var reExtraSpace = /^\s*(.*?)\s+$/;
            return this.replace(reExtraSpace,"$1");
       }
    </script>

    <style type="text/css">
        #Button1
        {
            width: 126px;
        }
        #Button2
        {
            width: 114px;
        }
        #but1
        {
            width: 109px;
        }
        #but3
        {
            width: 115px;
        }
        #but4
        {
            width: 113px;
        }
        #butSaveToLocal
        {
            width: 92px;
        }
    </style>
    
</head>
<body onload="javascript:myLoad();" onunload="javascript:myUnload();">
    <form id="form1" runat="server">
    <div>
        <table width="100%" align="center" bgcolor="#c5c5c5" cellpadding="1" cellspacing="1"
            height="100%" border="0">
            <tr bgcolor="#f0f8ff" height="4%" id="Row1">
                <td align="left">
                    <input class="btn" type="button" id="but2" value="保存数据" style="height:25px" 
                        onclick="javaScript:return SaveDoc();" name="but2">
                </td>
            </tr>
            <tr bgcolor="#f0f8ff" height="96%">
                <td align="center">

                    <script src="loadweboffice.js"></script>

                </td>
            </tr>
        </table>
        
        <input id="wordUrl" type="hidden" name="wordUrl" runat="server" />
        <input id="filetype" type="hidden" name="filetype" runat="server" value="doc" />
       
    </div>
    </form>
</body>
</html>
