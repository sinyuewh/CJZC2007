<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeeWordFile.aspx.cs" Inherits="DangAn_SeeWordFile" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0 0 0 0;
            overflow: hidden;

        }
    </style>

    <script language="javascript" type="text/javascript">
        function myLoad() {
            var url = document.getElementById("wordUrl").value;
            var type1 = document.getElementById("wordExt").value;
            document.getElementById("WebOffice1").OptionFlag = 0x0400;
            flag = document.getElementById("WebOffice1").LoadOriginalFile(url, type1);
            if (flag == 0) {
                alert("启动Office失败，请检查 Microsoft Office 是否正确安装后重试！");
            }
            else {

                if (document.getElementById("isAdmin").value == "") {
                    HiddenMenuAndBar();
                    document.getElementById("WebOffice1").SetToolBarButton2("Menu Bar", 1, 1);
                    document.getElementById("WebOffice1").SetSecurity(0x01);
                    document.getElementById("WebOffice1").SetSecurity(0x02);
                    document.getElementById("WebOffice1").SetSecurity(0x04);
                    document.getElementById("WebOffice1").SetSecurity(0x08);
                    HiddenMenuAndBar();
                }
                document.getElementById("WebOffice1").ShowToolBar = 0;
            }
        }

        //屏蔽Word的菜单和按钮
        function HiddenMenuAndBar() {
            //屏蔽标准工具栏的前几个按钮
            document.getElementById("WebOffice1").SetToolBarButton2("Standard", 3, 1);
            document.getElementById("WebOffice1").SetKeyCtrl(595, -1, 0);
        }

        //恢复菜单和Bar
        function RestoreMenuAndBar() {
            //恢复被屏蔽的菜单项和快捷键
            document.getElementById("WebOffice1").SetToolBarButton2("Standard", 1, 3);
            document.getElementById("WebOffice1").SetToolBarButton2("Standard", 2, 3);
            document.getElementById("WebOffice1").SetToolBarButton2("Standard", 3, 3);
            document.getElementById("WebOffice1").SetToolBarButton2("Standard", 6, 3);

            //恢复文件菜单项
            document.getElementById("WebOffice1").SetToolBarButton2("Menu Bar", 1, 4);
            //恢复 保存快捷键(Ctrl+S) 
            document.getElementById("WebOffice1").SetKeyCtrl(595, 0, 0);
            //恢复 打印快捷键(Ctrl+P) 
            document.getElementById("WebOffice1").SetKeyCtrl(592, 0, 0);

            //恢复文件保存
            document.getElementById("WebOffice1").SetSecurity(0x02 + 0x8000);
        }

        //关闭窗口
        function myUnload() {
            RestoreMenuAndBar();
            document.getElementById("WebOffice1").CloseDoc(0);
            document.getElementById("WebOffice1").close();
        }

        function SaveDoc() {
            if (confirm("提示：确定要保存Office文档吗?")) {
                document.getElementById("WebOffice1").HttpInit();
                document.getElementById("WebOffice1").HttpAddPostString("fileName", document.getElementById("filename").value);
                document.getElementById("WebOffice1").HttpAddPostString("DocType", "doc");
                document.getElementById("WebOffice1").HttpAddPostCurrFile("DocContent", "");
                var vtRet;
                vtRet = document.getElementById("WebOffice1").HttpPost(document.getElementById("saveDoc").value);
                alert(vtRet);
            }
            return false;
        }
    </script>

</head>
<body onload="javascript:myLoad();" onunload="javascript:myUnload();">
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <table width="100%" align="center"  cellpadding="1" cellspacing="1"
            height="100%" border="0">
            <tr bgcolor="#f0f8ff" height="4%" id="Row1" runat="server">
                <td align="left">
                   <input type="button" id="but2" value="保存文档到服务器" style="color: Red; height:25; cursor:hand" title="保存文件到服务器"
                        onclick="javaScript:return SaveDoc();" runat="server" name="but2" />
                </td>
            </tr>
            <tr bgcolor="#f0f8ff" height="96%">
                <td align="center">

                    <script src="loadweboffice.js" type="text/javascript"></script>

                </td>
            </tr>
        </table>
        <input id="wordUrl" type="hidden" name="wordUrl" runat="server" />
        <input id="wordExt" type="hidden" name="wordExt" runat="server" />
        <input id="saveDoc" type="hidden" name="saveDoc" runat="server" />
        <input id="filename" type="hidden" name="filename" runat="server" />
        <input id="isAdmin" type="hidden" name="isAdmin" runat="server" />
    </div>
    </form>
</body>
</html>
