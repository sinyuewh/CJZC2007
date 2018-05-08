<%@ Page Language="c#" %>

<script language="C#" runat="server">

    private void Page_Load(object sender, System.EventArgs e)
    {
    }
</script>

<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <meta http-equiv="Expires" content="0">
    <title>插入表格</title>
    <style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}
</style>

    <script language="javascript">
function returnTable() {
	var arr = new Array();

	arr["width"] = document.getElementById('Width').value;  
	arr["height"] = document.getElementById('Height').value;
	arr["cellpadding"] = document.getElementById('Cellpadding').value;  
	arr["cellspacing"] = document.getElementById('Cellspacing').value;
	arr["border"] = document.getElementById('Border').value;  	

	arr["cols"] = document.getElementById('Columns').value;
	arr["rows"] = document.getElementById('Rows').value;
	arr["valigncells"] = document.getElementById('VAlignCells')[document.getElementById('VAlignCells').selectedIndex].value;
	arr["haligncells"] = document.getElementById('HAlignCells')[document.getElementById('HAlignCells').selectedIndex].value;
	arr["percentcols"] = document.getElementById('PercentCols').checked;	
			 
	window.returnValue = arr;
	window.close();	
}		
    </script>

</head>
<body>
    <table width="100%" cellpadding="1" cellspacing="3" border="0">
        <tr>
            <td valign="top">
                <fieldset>
                    <legend>表格</legend>
                    <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                宽度</td>
                            <td>
                                <input type="text" id="Width" name="Width" value="100" style="width: 50px;"></td>
                        </tr>
                        <tr>
                            <td>
                                高度</td>
                            <td>
                                <input type="text" id="Height" name="Height" value="100" style="width: 50px;"></td>
                        </tr>
                        <tr>
                            <td>
                                Cellpadding</td>
                            <td>
                                <input type="text" id="Cellpadding" name="Cellpadding" style="width: 50px;" value="0"></td>
                        </tr>
                        <tr>
                            <td>
                                Cellspacing</td>
                            <td>
                                <input type="text" id="Cellspacing" name="Cellspacing" style="width: 50px;" value="0"></td>
                        </tr>
                        <tr>
                            <td>
                                边框宽度</td>
                            <td>
                                <input type="text" id="Border" name="Border" style="width: 50px;" value="1"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
            <td>
                &nbsp;&nbsp;</td>
            <td valign="top">
                <fieldset>
                    <legend>单元格</legend>
                    <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                列数</td>
                            <td>
                                <input type="text" id="Columns" name="Columns" style="width: 50px;" value="2"></td>
                        </tr>
                        <tr>
                            <td>
                                行数</td>
                            <td>
                                <input type="text" id="Rows" name="Rows" style="width: 50px;" value="2"></td>
                        </tr>
                        <tr>
                            <td>
                                垂直布局</td>
                            <td>
                                <select id="VAlignCells" name="VAlignCells" style="width: 50px;">
                                    <option></option>
                                    <option value="top">置顶</option>
                                    <option value="center">中间</option>
                                    <option value="bottom">置底</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                水平布局</td>
                            <td>
                                <select id="HAlignCells" name="HAlignCells" style="width: 50px;">
                                    <option></option>
                                    <option value="left">居左</option>
                                    <option value="center">居中</option>
                                    <option value="right">居右</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Percent Cols</td>
                            <td>
                                <input type="checkbox" id="PercentCols" name="PercentCols" value="1"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <input type="button" onclick="returnTable();return false;" value="Insert Table">
            </td>
        </tr>
    </table>
</body>
</html>
