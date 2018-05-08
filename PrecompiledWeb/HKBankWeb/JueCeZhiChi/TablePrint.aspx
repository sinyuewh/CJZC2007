<%@ page language="C#" autoeventwireup="true" inherits="JueCeZhiChi_JZTCPrint, App_Web_uajp-wst" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>统计表</title>

    <script language="javascript">     
        function setTableData()
        {
            var win1=window.opener;
            if(win1!=null)
            { 
               var t1=win1.document.getElementById('<%#Request.QueryString["tab1"]%>');
               var t2=document.getElementById("tab1");
                
               //设置报表的标题
               document.getElementById("tName").innerHTML="<strong>"+t1.rows[0].cells[0].innerText+"</strong>";
               window.document.title=t1.rows[0].cells[0].innerText;
            
               //设置报表的数据
               var tLenth=t1.rows.length;
               for(var i=1;i<tLenth;i++)
               {
                  for(var k=0;k<t1.rows[i].cells.length;k++)
                  {
                     if(i==1)
                     {
                        t2.rows[i-1].cells[k].innerHTML="<b>"+t1.rows[i].cells[k].innerHTML+"</b>";
                     }
                     else
                     {
                        if(k==0 || k==1)
                        {
                            t2.rows[i-1].cells[k].innerText=t1.rows[i].cells[k].innerText;
                        }
                        else
                        {
                            t2.rows[i-1].cells[k].innerHTML=t1.rows[i].cells[k].innerText+"&nbsp;";
                        } 
                     }
                  }                   
                }
            }
        }
    </script>

</head>
<body style="background-color: White" onload="javaScript:setTableData();">
    <form id="form1" runat="server">
        <div>
            <br />
            <table id="tab0" cellspacing="1" cellpadding="1" align="Center" width='<%#Request.QueryString["width"]%>pt'>
                <tr>
                    <td height="40" align="center" valign="top">
                        <span style="font-size: 16pt;" id="tName">## </span>
                    </td>
                </tr>
            </table>
            <table id="tab1" cellspacing="1" cellpadding="1" align="Center" width='<%#Request.QueryString["width"]%>pt'
                bgcolor="black">

                <script language="javascript">
                CreateTable(<%#Request.QueryString["tabRow"]%>);
                function CreateTable(tabRows)
                {
                    var maxCol=<%#Request.QueryString["maxCol"]%>;
                    for(var k1=0;k1<tabRows-1;k1++)
                    {
                        document.writeln("<tr align=\"center\" height=\"25\" bgcolor=\"white\">");
                        for(var k=0;k<maxCol;k++)
                        {
                            if(k==0 || k==1)
                            {
                                document.writeln("<td></td>");
                            }
                            else
                            {
                                document.writeln("<td align='right'></td>");
                            }
                         }
                        document.writeln("</tr>");
                    }
                }
                </script>

            </table>
        </div>
    </form>
</body>
</html>
