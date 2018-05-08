
function word_onload()
{
	document.getElementById("WebOffice1").LoadOriginalFile(document.getElementById("wordUrl").value,"doc");
	
	//设置书签(1)的值
	
	var str1=  "xmsbh,num2,xmmc,zwdw,dbdw,zwzgbm,"  +
               "zqxx,zclx,zcse,jiazhi,zqze,benjin,lixi,xmbj" +
               ",czfs1,czba1,czjg1,qcl1,czfs2,czba2,czjg2,qcl2" +
               ",xgsxsm,bmyj,bmren,bmsj,cbbm,jbr,jbsj,psyyj,psyren,psysj" +
               ",hysj1,hydd1,yingdao1,shidao1,quexi1,zcr1,ztwy1,fdwy1,shyj1,shren1,shsj1" +
               ",hysj2,hydd2,yingdao2,shidao2,quexi2,zcr2,ztwy2,fdwy2,shyj2,shren2,shsj2";
               
	var arr1=str1.split(",");
	for(var i=0;i<arr1.length;i++)
	{
		document.getElementById("WebOffice1").SetFieldValue(arr1[i], document.getElementById(arr1[i]).value, "");
	}
	//alert(1);
}

   					
function word_onunload()
{
	RestoreMenuAndBar();
	document.getElementById("WebOffice1").Close();
}

			
//打印文档
function PrintMyDoc()
{
	document.getElementById("WebOffice1").PrintDoc(1);
}

//保存文件到本地
function SaveToLocal()
{
	var filename=window.prompt("请输入要保存文件的完整路径，如C:\\123.doc","C:\\文件.doc");
	if(filename!=null && filename!="")
	{
		var succ=document.getElementById("WebOffice1").SaveAs(filename,0);
		alert("提示：文件已成功的保存！");
	}
}


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
}