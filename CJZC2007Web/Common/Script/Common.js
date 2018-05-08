/*
  公共脚本库
  编码：陈家兴
  编码时间：2007年1月25日
*/
//用于多选的操作
function selectAll(c0,c1)
{ 
    state1=document.forms[0][c0].checked;	
	for(i=0;i<document.forms[0].elements.length;i++)
	{
		var item1=document.forms[0].elements[i];
		if(item1.name==c1 && item1.type=="checkbox")
		{
			item1.checked=state1;
		}
	}
	
}

//得到单选按钮选中的值
//其中radio1表示单选控件的名字（支持无、1个、多个的情况）
function getRadioValue(radio1)
{
    var result="";
    if(document.forms[0][radio1]!=undefined)
    {
        var sel=document.forms[0][radio1];
        if(sel.length==undefined)   //表示不是一个数组
        {
            if(sel.checked)
            {
                result=sel.value;
            }
        }
        else
        {
            for(var i=0;i<sel.length;i++)
            {
                if(sel[i].checked)
                {
                    result=sel[i].value;
                    break;
                }
            }
        }
    }
    return result;
}


//得到多选按钮选中的值
//其中check1表示多选控件的名字（支持无、1个、多个的情况）
function getCheckValue(check1)
{
    var result="";
    if(document.forms[0][check1]!=undefined)
    {
        var sel=document.forms[0][check1];
        if(sel.length==undefined)   //表示不是一个数组
        {
            if(sel.checked)
            {
                result=sel.value;
            }
        }
        else
        {
            for(var i=0;i<sel.length;i++)
            {
                if(sel[i].checked)
                {
                   
                   if(result=="")
                   {
                      result=sel[i].value;
                   }
                   else
                   {
                      result=result+","+sel[i].value;  
                   }
                }
            }
        }
    }
    return result;
}


//得到多选列表中选中的值
//其中为多选列表的名字
function getSelectValue(select1)
{
    var result="";
    if(document.forms[0][select1]!=undefined)
    {
        var sel=document.forms[0][select1].options;
        for(var i=0;i<sel.length;i++)
        {
            if(sel[i].selected)
            {
               
               if(result=="")
               {
                  result=sel[i].value;
               }
               else
               {
                  result=result+","+sel[i].value;  
               }
            }
        }
        
    }
    return result;
}


//用于通过Open 打开特定的窗口
function winOpenOfen(openUrl,wid1,hei1)
{
	win1=winOpen(openUrl,wid1,hei1,-1,-1);
}


function winOpen(openUrl,wid1,hei1,left1,top1)
{
	h1=window.screen.availHeight;
	w1=window.screen.availWidth;
	if(top1==-1)
	{
		top1=(h1-hei1)/2;
	}
	if(left1==-1)
	{
		left1=(w1-wid1)/2;
	}
	
	win1=window.open(openUrl,"","left="+left1+",top="+top1+",width="+wid1+",height="+hei1);
}

//获取值,并付给两个控件
//add by chenjx 2007-1-26
function getElement(value1,ControlId1,ControlId2)
{
   //value1=(value1.trim()==undefined?'/':value1);
   var temp = value1.split('|');
   document.getElementById(ControlId1).value = temp[0];
   document.getElementById(ControlId2).value = temp[1];
   return false;
}


