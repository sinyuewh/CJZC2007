﻿<%@ page language="C#" autoeventwireup="true" inherits="DangAn_SeePDFFile, App_Web_wg1zrq8e" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0 0 0 0;
            overflow: hidden;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function OpenURL()
        {
            var pdf1 = document.getElementById("YCanPDF");
            if (pdf1 != null && pdf1 != undefined) {
                var fonturl = document.getElementById("pdffont").value;
                var pdfurl = document.getElementById("pdfdoc").value;
                if (fonturl != "" && pdfurl != "") {
                    pdf1.width = screen.availWidth - 30;
                    pdf1.height = screen.availHeight - 30;
                    pdf1.SetRCURL(fonturl, 0);
                    var n = pdf1.SetURL(pdfurl, "");
                    pdf1.ShowOutline(true);
                    pdf1.FitWidth();
                }
                else {
                    alert("PDF文档加载失败，可能是控件未能正确下载！");
                    window.close();
                }
            }
        }
    </script>

</head>
<body onload="javascript:OpenURL();">
    <form id="form1" runat="server">
    <div style="text-align: center; padding: 10 10 10 10">
        <div style ="text-align:left; margin-top:5px; margin-bottom:5px; padding-left:10px">
             <asp:Button ID="button1" runat ="server" Text ="下载档案" ToolTip ="点这里下载档案"
              Height ="25" Width ="200" Font-Bold="true" ForeColor="Red" 
                 onclick="button1_Click" />
        </div>
       
        <object id="YCanPDF" classid="clsid:474C1AB2-EFA5-4A19-9267-BA38B685C74A" codebase="PDFView.cab#version=1,13,1,0"
            width="750" height="450">
        </object>
    </div>
    <asp:HiddenField ID="pdfdoc" runat="server" Value="" />
    <asp:HiddenField ID="pdffont" runat="server" Value="" />
    </form>
</body>
</html>
