// JScript 文件
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
