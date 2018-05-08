
function resetList(){
document.all.contentList.style.height=bheight-27-2;
}
function resetBriefing(){
document.all.briefing.style.left=bwidth-175;
document.all.briefing.style.height=bheight-27-2;
document.all.briefing.style.top=28;
}
function initDiv(){
    bwidth=document.body.offsetWidth;
    bheight=document.body.offsetHeight;
    resetList();
}

function initHomePage(){
    bwidth=document.body.offsetWidth;
    bheight=document.body.offsetHeight;
    document.all.contentList.style.height=bheight;
}

//设置子DIV
//function initChildDiv(){
//bwidth=document.body.offsetWidth;
//bheight=document.body.offsetHeight;
//resetList();
//}
//function resetChildList(){
//document.all.ChildList.style.height=bheight-27-2;
//}

/*打开新窗口调用以下函数-*/
function OpenSmallWin(url)
{
	OpenWin(url,'', '350', '600');
}
function OpenBigWin(url)
{
	OpenWin(url,'', '600', '800');
}
function OpenWinASSiz(url,height,width)
{
	OpenWin(url,'', height, width);
}
/*-------*/

function OpenViewWorkFlow(url)
{
   OpenModalDialog(url, "500","800");
}
function Get_Center(size, side)
{
	self.y_center=(parseInt(screen.height/2));
	self.x_center=(parseInt(screen.width/2));
	center = eval('self.'+side+'_center-('+size+'/2);');
	return(parseInt(center));
}
function OpenPrintWin(url, name, height, width)
{
	var left = Get_Center(width,'x');	
	var top = Get_Center(height,'y');
	if (top > 30)
	{
		top = top - 30;
	}
	window.open(url,name,"height=" + height + ",width=" + width + ",left=" + left + ",top=" + top + ",scrollbars=no,toolbar=no,menubar=yes,location=no,resizable=yes");
}
function OpenPrintBigWin(url, name, height, width)
{
	var left = Get_Center(width,'x');	
	var top = Get_Center(height,'y');
	if (top > 30)
	{
		top = top - 30;
	}
	window.open(url,name,"height=" + height + ",width=" + width + ",left=" + left + ",top=" + top + ",scrollbars=yes,toolbar=no,menubar=yes,location=no,resizable=yes");
}

function OpenEditWin(url)
{
	var height = 700;
	var width = 1000;
	var name = "EditForm";
	OpenWin(url, name, height, width);	
}
function OpenWin(url, name, height, width)
{
	var left = Get_Center(width,'x');	
	var top = Get_Center(height,'y');
	if (top > 30)
	{
		top = top - 30;
	}
	window.open(url,name,"height=" + height + ",width=" + width + ",left=" + left + ",top=" + top + ",scrollbars=no,toolbar=no,menubar=no,location=no,resizable=no");
}
function OpenNewWin(url, name, height, width)
{
	var left = Get_Center(width,'x');	
	var top = Get_Center(height,'y');
	if (top > 30)
	{
		top = top - 30;
	}
	window.open(url,name,"height=" + height + ",width=" + width + ",left=" + left + ",top=" + top + ",scrollbars=no,status=yes,toolbar=yes,menubar=yes,location=yes,resizable=yes");
}

function OpenModalDialog(url, height, width)
{
   window.showModalDialog(url + "&rdm=" + Math.random(),document,"dialogHeight: " + height + "px; dialogWidth: " + width + "px;edge: Raised; center: Yes; help: No; resizable: No; scrollbars:No");
}

function OpenDialog(url, height, width)
{
	return window.showModalDialog(url+ "&rdm=" + Math.random(),document,"dialogHeight: " + height + "px; dialogWidth: " + width + "px;edge: Raised; center: Yes; help: No; resizable: No; scrollbars:No");
}

function OpenSelectEmpAndDepDialog(urlPrex,IdCtr,EmployeeNameCtr,DeptIDCtr,DeptNameCtr,DeptNo)
{
	var url = urlPrex + "Common/Selector/SelectUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&DeptIDCtr=" + DeptIDCtr +"&DeptNameCtr=" + DeptNameCtr + "&DeptNo=" + DeptNo;
	OpenDialog(url, "480", "600")
}

function OpenSelectEmpDialog(urlPrex,IdCtr,EmployeeNameCtr,EmployeeNoCtr,DeptNo)
{
	var url = urlPrex + "Common/Selector/SelectUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&EmployeeNoCtr=" + EmployeeNoCtr + "&DeptNo=" + DeptNo;
	OpenDialog(url, "480", "600")
}
function OpenSelectPostDialog(urlPrex,IdCtr,NameCtr,deptID)
{
	var url = urlPrex + "Common/Selector/SelectPost.aspx?IdCtr=" + IdCtr + "&NameCtr=" + NameCtr+"&deptID="+deptID;
	OpenDialog(url, "442", "600")
}

function OpenSelectHospitalDialog(urlPrex,IdCtr,NameCtr)
{
	var url = urlPrex + "Common/Selector/SelectHospital.aspx?IdCtr=" + IdCtr + "&NameCtr=" + NameCtr;
	OpenDialog(url, "426", "600")
}

function OpenSelectMultiEmpDialog(urlPrex,IdCtr,EmployeeNameCtr,DeptNo,mancount,idvalue,namevalue)
{
	var url = urlPrex+"Common/Selector/SelectMultiUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&DeptNo=" + DeptNo+"&mancount="+mancount+"&idvalue="+escape(idvalue)+"&namevalue="+escape(namevalue);
	OpenDialog(url, "480", "600")
}
function OpenSelectSingleEmp(urlPrex,IdCtr,EmployeeNameCtr,EmployeeNoCtr,EmpNameCtr)
{
	var url = urlPrex + "Common/Selector/SelectUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&EmployeeNoCtr=" + EmployeeNoCtr + "&EmpNameCtr=" + EmpNameCtr;
	OpenDialog(url, "480", "600")
}

function OpenSelectRoleDialog(urlPrex,IdCtr,NameCtr)
{
	var url=urlPrex + "Common/Selector/SelectRole.aspx?IdCtr=" + IdCtr + "&NameCtr=" + NameCtr ;
	OpenDialog(url, "480", "600")
}

//选择单个员工放大镜 
//urlPrex是URL的前缀，例："../../"；//IdCtr是id的控件名；//EmployeeNameCtr是员工姓名的控件名；
//DeptIDCtr是部门ID的控件名，如果不用则给空值；
//DeptNameCtr是部门名称的控件名，如果不用则给空值；
//DeptNo是默认的部门编号。如果有必要可以使用，没必要则给空值；
function OpenSelectEmpAndDepDialog(urlPrex,IdCtr,EmployeeNameCtr,DeptIDCtr,DeptNameCtr,DeptNo)
{
	var url = urlPrex + "Common/Selector/SelectUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&DeptIDCtr=" + DeptIDCtr +"&DeptNameCtr=" + DeptNameCtr + "&DeptNo=" + DeptNo;
	OpenDialog(url, "480", "600")
}

//选择单个员工的放大镜(领用劳保用品专用) 
//urlPrex是URL的前缀，例："../../"；

//EMP_IdCtr是EMP_Id的控件名；

//EMP_NameCtr是EMP_Name的控件名；

//PostionNameCtr是PostionName的控件名，如果不用则给空值；
//EMP_JobDateCtr是EMP_JobDate的控件名，如果不用则给空值；
//EMP_StatureCtr是EMP_Stature的控件名，如果不用则给空值；
//EMP_ClothingSizeCtr是EMP_ClothingSize的控件名，如果不用则给空值；
//EMP_ShoesSizeCtr是EMP_ShoesSize的控件名，如果不用则给空值；
function OpenSelectUserForLaborInsuranceDialog(urlPrex,EMP_IdCtr,EMP_NameCtr,PostionNameCtr,EMP_JobDateCtr,EMP_StatureCtr,EMP_ClothingSizeCtr,EMP_ShoesSizeCtr)
{
	var url = urlPrex + "Common/Selector/SelectUserForLaborInsurance.aspx?EMP_IdCtr=" + EMP_IdCtr 
	+ "&EMP_NameCtr="+ EMP_NameCtr 
	+ "&PostionNameCtr=" + PostionNameCtr
	+ "&EMP_JobDateCtr="+ EMP_JobDateCtr 
	+ "&EMP_StatureCtr=" + EMP_StatureCtr
	+ "&EMP_ClothingSizeCtr="+ EMP_ClothingSizeCtr 
	+ "&EMP_ShoesSizeCtr=" + EMP_ShoesSizeCtr;
	OpenDialog(url, "480", "600")
}

//选择单个员工放大镜 
//urlPrex是URL的前缀，例："../../"；//IdCtr是id的控件名；//EmployeeNameCtr是员工姓名的控件名；
//EmployeeNameCtr是部门ID的控件名，如果不用则给空值；
//DeptNo是默认的部门编号。如果有必要可以使用，没必要则给空值；
function OpenSelectEmpDialog(urlPrex,IdCtr,EmployeeNameCtr,EmployeeNoCtr,DeptNo)
{
	var url = urlPrex + "Common/Selector/SelectUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&EmployeeNoCtr=" + EmployeeNoCtr + "&DeptNo=" + DeptNo;
	OpenDialog(url, "480", "600")
}

//选择单个物资信息放大镜 
//urlPrex是URL的前缀，例："../../"；//I_InvCodeCtr是I_InvCode的控件名；//I_InvNameCtr是I_InvName的控件名；//I_InvStdCtr是I_InvStdCtr的控件名；//I_InvM_UnitCtr是I_InvM_UnitCtr的控件名；//I_InvSPriceCtr是I_InvSPriceCtr的控件名；function OpenSelectInventoryDialog(urlPrex,I_InvCodeCtr,I_InvNameCtr,I_InvStdCtr,I_InvM_UnitCtr,I_InvSPriceCtr)
{
	var url = urlPrex + "Common/Selector/SelectInventory.aspx?I_InvCodeCtr=" + I_InvCodeCtr + "&I_InvNameCtr=" + I_InvNameCtr+ "&I_InvStdCtr=" + I_InvStdCtr+ "&I_InvM_UnitCtr=" + I_InvM_UnitCtr+ "&I_InvSPriceCtr=" + I_InvSPriceCtr;
	OpenDialog(url, "480", "600")
}

//选择单个U8物资类型放大镜 
//urlPrex是URL的前缀，例："../../"；//IC_CodeCtr是IC_Code的控件名；//IC_NameCtr是IC_Name的控件名；function OpenSelectInventoryClassDialog(urlPrex,IC_CodeCtr,IC_NameCtr)
{
	var url = urlPrex + "Common/Selector/SelectInventoryClass.aspx?IC_CodeCtr=" + IC_CodeCtr + "&IC_NameCtr=" + IC_NameCtr;
	OpenDialog(url, "480", "600")
}

//选择单个员工并且带职位的放大镜 
//urlPrex是URL的前缀，例："../../"；//IdCtr是id的控件名；//EmployeeNameCtr是员工姓名的控件名；
//EmployeeNameCtr是部门ID的控件名，如果不用则给空值；
//DeptNo是默认的部门编号。如果有必要可以使用，没必要则给空值；
function OpenSelectEmpWithPostionDialog(urlPrex,IdCtr,EmployeeNameCtr,PostionNameCtr)
{
	var url = urlPrex + "Common/Selector/SelectUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&PostionNameCtr=" + PostionNameCtr;
	OpenDialog(url, "480", "600")
}

//选择单个文书的放大镜 
//urlPrex是URL的前缀，例："../../"；//OF_IdCtr是OF_Id的控件名；//OF_FileNameCtr是OF_FileName的控件名；//OF_PrimaryNoCtr是OF_PrimaryNo的控件名，如果不用则给空值；
function OpenSelectOuterFileDialog(urlPrex,OF_IdCtr,OF_FileNameCtr,OF_PrimaryNoCtr)
{
	var url = urlPrex + "Common/Selector/SelectOuterFile.aspx?OF_IdCtr=" + OF_IdCtr + "&OF_FileNameCtr=" + OF_FileNameCtr + "&OF_PrimaryNoCtr=" + OF_PrimaryNoCtr;
	OpenDialog(url, "480", "600")
}

//选择单个文书的放大镜（带类型）//urlPrex是URL的前缀，例："../../"；//OF_IdCtr是OF_Id的控件名；//OF_FileNameCtr是OF_FileName的控件名；//OF_PrimaryNoCtr是OF_PrimaryNo的控件名，如果不用则给空值；
//OF_TypeCtr是OF_Type的控件名，如果不用则给空值；
function OpenSelectOuterWithTypeFileDialog(urlPrex,OF_IdCtr,OF_FileNameCtr,OF_PrimaryNoCtr,OF_TypeCtr)
{
	var url = urlPrex + "Common/Selector/SelectOuterFile.aspx?OF_IdCtr=" + OF_IdCtr + "&OF_FileNameCtr=" + OF_FileNameCtr + "&OF_PrimaryNoCtr=" + OF_PrimaryNoCtr+"&OF_TypeCtr="+OF_TypeCtr;
	OpenDialog(url, "480", "600")
}

//选择单个设备的放大镜 
//urlPrex是URL的前缀，例："../../"；

//Dev_IDCtr是Dev_ID的控件名；

//Dev_NoCtr是Dev_No的控件名；

//Dev_NameCtr是Dev_Name的控件名，如果不用则给空值；
//Dev_PlaceCtr是Dev_Place的控件名，如果不用则给空值；
//Dev_SpecCtr是Dev_Spec的控件名，如果不用则给空值；
function OpenSelectDeviceDialog(urlPrex,Dev_IDCtr,Dev_NoCtr,Dev_NameCtr,Dev_PlaceCtr,Dev_SpecCtr)
{
	var url = urlPrex + "Common/Selector/SelectDevice.aspx?Dev_IDCtr=" + Dev_IDCtr + "&Dev_NoCtr=" + Dev_NoCtr + "&Dev_NameCtr=" + Dev_NameCtr+"&Dev_PlaceCtr="+Dev_PlaceCtr+"&Dev_SpecCtr="+Dev_SpecCtr;
	OpenDialog(url, "480", "600")
}

//选择多个员工放大镜 
//urlPrex是URL的前缀，例："../../"；

//IdCtr是id的控件名,得到的是个序列，中间用“,”分割；
//EmployeeNameCtr是员工姓名的控件名,得到的是个序列，中间用“,”分割。与ID一一对应；

//DeptNo是默认的部门编号。如果有必要可以使用，没必要则给个空值；
//mancount最多选择人数，如果给值，则默认最多70个人；

//idvalue和namevalue是用来传入原先选定的人员序列，通常是IdCtr和EmployeeNameCtr的值。如果不需要则给空值；
function OpenSelectMultiEmpDialog(urlPrex,IdCtr,EmployeeNameCtr,DeptNo,mancount,idvalue,namevalue)
{
	var url = urlPrex+"Common/Selector/SelectMultiUser.aspx?IdCtr=" + IdCtr + "&EmployeeNameCtr=" + EmployeeNameCtr + "&DeptNo=" + DeptNo+"&mancount="+mancount+"&idvalue="+escape(idvalue)+"&namevalue="+escape(namevalue);
	OpenDialog(url, "480", "600")
}

//选择单个员工放大镜 
//urlPrex是URL的前缀，例："../../"；

//IdCtr是id的控件名；

//EmployeeNameCtr是员工姓名的控件名；
function OpenSelectRoleDialog(urlPrex,IdCtr,NameCtr)
{
	var url = urlPrex + "Common/Selector/SelectRole.aspx?IdCtr=" + IdCtr + "&NameCtr=" + NameCtr;
	OpenDialog(url, "480", "600")
}
		
//选择车辆到各个城市的耗油及其它 
//urlPrex是URL的前缀，例："../../"；
//Car_IDCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//Car_SignNoCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//Car_DriverIDCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//Driver_NameCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//City_KilometreCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//Gas_ExpendNumCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//Gas_ExpMoneyCtr是Car_ID的控件名,如果有必要可以使用，没必要则给个空值；
//CityID是指定到达城市的城市ID,如果有必要可以使用，没必要则给个空值；
function OpenSelectCarToCityExpendGasDialog(urlPrex,Car_IDCtr,Car_SignNoCtr,Car_DriverIDCtr,Driver_NameCtr,City_KilometreCtr,Gas_ExpendNumCtr,Gas_ExpMoneyCtr,CityID)
{
	var url = urlPrex+"Common/Selector/SelectCarToCityExpendGas.aspx?Car_IDCtr=" + Car_IDCtr 
	+ "&Car_SignNoCtr=" + Car_SignNoCtr 
	+ "&Car_DriverIDCtr=" + Car_DriverIDCtr
	+"&Driver_NameCtr="+Driver_NameCtr
	+"&City_KilometreCtr="+City_KilometreCtr
	+"&Gas_ExpendNumCtr="+Gas_ExpendNumCtr
	+"&Gas_ExpMoneyCtr="+Gas_ExpMoneyCtr
	+"&CityID="+CityID;
	OpenDialog(url, "480", "600")
}

//选择单个卷的放大镜

//urlPrex是URL的前缀，例："../../"；
//Vol_NoCtr是Vol_No的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_BoxNoCtr是Vol_BoxNo的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_CabinetNoCtr是Vol_CabinetNo的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_CatTypeIdCtr是Vol_CatTypeId(下拉条)的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_TypeCtr是Vol_Type的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_TitleCtr是Vol_Title的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_YearCtr是Vol_Year的控件名,如果有必要可以使用，没必要则给个空值；
//Vol_IdCtr是Vol_Id的控件名,如果有必要可以使用，没必要则给个空值；
function OpenSelectVolumeDialog(urlPrex,Vol_NoCtr,Vol_BoxNoCtr,Vol_CabinetNoCtr,Vol_CatTypeIdCtr,Vol_PreserveDateCtr,CAT_NameCtr,Vol_TypeCtr,Vol_TitleCtr,Vol_YearCtr,Vol_IdCtr)
{
	var url = urlPrex+"Common/Selector/SelectVolume.aspx?Vol_NoCtr=" + Vol_NoCtr 
	+"&Vol_BoxNoCtr=" + Vol_BoxNoCtr 
	+"&Vol_CabinetNoCtr=" + Vol_CabinetNoCtr
	+"&Vol_CatTypeIdCtr="+Vol_CatTypeIdCtr
	+"&Vol_PreserveDateCtr="+Vol_PreserveDateCtr
	+"&CAT_NameCtr="+CAT_NameCtr
	+"&Vol_TypeCtr="+Vol_TypeCtr
	+"&Vol_TitleCtr="+Vol_TitleCtr
	+"&Vol_YearCtr="+Vol_YearCtr
	+"&Vol_IdCtr="+Vol_IdCtr;
	OpenDialog(url, "480", "800")
}

//选择单个档案的放大镜
//urlPrex是URL的前缀，例："../../"；

//ARC_IdCtr是ARC_Id的控件名,如果有必要可以使用，没必要则给个空值；
//ARC_NoCtr是ARC_No的控件名,如果有必要可以使用，没必要则给个空值；
//ARC_TitleCtr是ARC_Title的控件名,如果有必要可以使用，没必要则给个空值；
//CAT_NameCtr是CAT_Name的控件名,如果有必要可以使用，没必要则给个空值；
function OpenSelectArchiveDialog(urlPrex,ARC_IdCtr,ARC_NoCtr,ARC_TitleCtr,CAT_NameCtr)
{
	var url = urlPrex+"Common/Selector/SelectArchive.aspx?ARC_IdCtr=" + ARC_IdCtr 
	+"&ARC_NoCtr=" + ARC_NoCtr 
	+"&ARC_TitleCtr=" + ARC_TitleCtr
	+"&CAT_NameCtr=" + CAT_NameCtr;
	OpenDialog(url, "480", "800")
}

//选择单个大中修计划的放大镜
//urlPrex是URL的前缀，例："../../"；
//LRP_IDCtr是LRP_ID的控件名,如果有必要可以使用，没必要则给个空值；
//LRP_FormNoCtr是LRP_FormNo的控件名,如果有必要可以使用，没必要则给个空值；
function OpenSelectLargeRepairPlanDialog(urlPrex,LRP_IDCtr,LRP_FormNoCtr)
{
	var url = urlPrex+"Common/Selector/SelectLargeRepairPlan.aspx?LRP_IDCtr=" + LRP_IDCtr+"&LRP_FormNoCtr=" + LRP_FormNoCtr;
	OpenDialog(url, "480", "800")
}

//选择单个部门的放大镜
//urlPrex是URL的前缀，例："../../"；
//dep_idCtr是dep_id的控件名,如果有必要可以使用，没必要则给个空值；
//dep_NameCtr是dep_Name的控件名,如果有必要可以使用，没必要则给个空值；
function OpenSelectDepartmentDialog(urlPrex,dep_idCtr,dep_NameCtr)
{
	var url = urlPrex+"Common/Selector/SelectDepartment.aspx?dep_idCtr=" + dep_idCtr+"&dep_NameCtr=" + dep_NameCtr;
	OpenDialog(url, "480", "800")
}

//选择单个推广材料档案 
//urlPrex是URL的前缀，例："../../"；//IdCtr是id的控件名；//NameCtr是推广材料名称的控件名；
function OpenSelectPromotionMaterialInfoDialog(urlPrex,IdCtr,NameCtr)
{
	var url = urlPrex + "Common/Selector/SelectPromotionMaterial.aspx?IdCtr=" + IdCtr + "&NameCtr=" + NameCtr;
	OpenDialog(url, "580", "800")
}


//选择单个供应商的放大镜

//urlPrex是URL的前缀，例："../../"；
//SUP_IDCtr是SUP_ID的控件名,如果有必要可以使用，没必要则给个空值；
//SUP_SupplierNameCtr是SUP_SupplierName的控件名,如果有必要可以使用，没必要则给个空值；
function OpenSelectSupplierDialog(urlPrex,SUP_IDCtr,SUP_SupplierNameCtr)
{
	var url = urlPrex+"Common/Selector/SelectSupplier.aspx?SUP_IDCtr=" + SUP_IDCtr+"&SUP_SupplierNameCtr=" + SUP_SupplierNameCtr;
	OpenDialog(url, "480", "800")
}
//选择单个客户的放大镜

function OpenSelectCustomerDialog(urlPrex,Cust_IDCtr,Cust_CustomerNameCtr)
{
	var url = urlPrex+"Common/Selector/SelectCustomer.aspx?Cust_IDCtr=" + Cust_IDCtr+"&Cust_CustomerNameCtr=" + Cust_CustomerNameCtr;
	OpenDialog(url, "480", "800")
}

//选择单个合同的放大镜

function OpenSelectContractDialog(urlPrex,Con_IDCtr,Con_ContractNameCtr)
{
	var url = urlPrex+"Common/Selector/SelectContract.aspx?Con_IDCtr=" + Con_IDCtr+"&Con_ContractNameCtr=" + Con_ContractNameCtr;
	OpenDialog(url, "480", "800")
}


// 打开公出申请选择窗口
function OpenSelectEvectionDialog(urlPrex,IdCtr,FormNoCtr,IdValue,FormNoValue)
{
	var url = urlPrex + "Common/Selector/SelectEvectionApply.aspx?IdCtr=" + IdCtr + "&FormNoCtr=" + FormNoCtr + "&IdValue=" + escape(IdValue) + "&FormNoValue=" + escape(FormNoValue) + "&rdm=" + Math.random();
	OpenDialog(url, "480", "640")
}

//选择数据字典 
function OpenSelectDicDialog(Serial,Name,Value,TypeId)
{	
	var url = "Common/Selector/Dictionary.aspx?rdm=" + Math.random() + 
		"&Serial=" + Serial + 
		"&Name=" + Name + 
		"&Value=" + Value + 
		"&TypeId=" + TypeId;
	OpenDialog(url, "480", "600")
}
//选择多个医生
//IDs不在列表中显示的ID
//Num允许选择的数量
function OpenSelectDoctor(urlPrex,IDctr,IDs)
{
   	var url = urlPrex + "Common/Selector/SelectDoctor.aspx?IDctr=" + IDctr + "&IDs=" + IDs;
   	OpenDialog(url, "480", "600")
}
//根据部门选择多个员工
function OpenSelectEmp(urlPrex,IDctr,Namectr,IDs,PostCode,Names)
{
   	var url = urlPrex + "Common/Selector/SelectEmp.aspx?IDctr=" + IDctr + "&Namectr=" + Namectr + "&IDs=" +  escape(IDs) + "&PostCode=" + PostCode + "&Names=" + escape(Names);
   	OpenDialog(url, "500", "600")
}
//选择角色
function OpenSelectRole(urlPrex,IDctr,Namectr,IDs,Names)
{
   	var url = urlPrex + "Common/Selector/SelectRole.aspx?IDctr=" + IDctr + "&Namectr=" + Namectr + "&IDs=" + escape(IDs) + "&Names=" + escape(Names);
   	OpenDialog(url, "500", "600")
}
//选择数据字典
function OpenSelectDictionary(urlPrex,IDctr,dType)
{
   	var url = urlPrex + "Common/Selector/SelectDictionary.aspx?IDctr=" + IDctr + "&dType=" + dType;
   	OpenDialog(url, "500", "600")
}
//选择多个员工
function OpenSelectMultiEmp(urlPrex,IDctr,Namectr,IDs,Names)
{
	var url = urlPrex+"Common/Selector/SelectMultiEmp.aspx?IdCtr=" + IDctr + "&Namectr=" + Namectr + "&IDs=" + escape(IDs) + "&Names=" + escape(Names);
	OpenDialog(url, "500", "600")
}
//根据岗位编码选择多个岗位
//Code岗位编码为空为选择全部岗位
//IDs已选择的岗位ID
//IsDP是否查询上级岗位1为是
function OpenSelectPost(urlPrex,IDctr,Namectr,Code,IDs,IsDP,Names)
{
   	var url = urlPrex + "Common/Selector/SelectParentPost.aspx?IDctr=" + IDctr + "&Namectr=" + Namectr + "&Code=" + Code+ "&IDs=" + IDs+ "&IsDP=" + IsDP + "&Names=" + Names;
   	OpenDialog(url, "500", "600")
}
//选择个人季度费用
function OpenUserCost(urlPrex,IDctr,SeasonCtr,AmountCtr,UsedCostCtr,PlanCostCtr)
{
	var url = urlPrex+"Common/Selector/SelectPAO.aspx?IdCtr=" + IDctr + "&SeasonCtr=" + SeasonCtr + "&AmountCtr=" + AmountCtr +"&UsedCostCtr=" + UsedCostCtr + "&PlanCostCtr=" + PlanCostCtr;
	OpenDialog(url, "500", "600")
}
//选择单个员工
function OpenSelectSingleEmp(urlPrex,IDCtr,NameCtr,DeptIDCtr,DeptCtr)
{
	var url = urlPrex+"Common/Selector/SelectSingleEmp.aspx?IdCtr=" + IDCtr + "&NameCtr=" + NameCtr + "&DeptIDCtr=" + DeptIDCtr + "&DeptCtr=" + DeptCtr;
	OpenDialog(url, "500", "700")
}
function CheckAll(check)
{
	var e = document.forms[0].elements;
	var l = e.length;
	var o;
	for(var i = 0; i < l; i++)
	{
		o = e[i];
		if (o.type == "checkbox")
		{
			o.checked = check;
		}
	}
}
// 设置id匹配的checkbox的选中状态为check
function CheckAll(check, id)
{
	var e = document.forms[0].elements;
	var l = e.length;
	var o;
	for(var i = 0; i < l; i++)
	{
		o = e[i];
		if (o.type == "checkbox" && o.id.indexOf(id) > -1)
		{
			o.checked = check;
		}
	}
}
//单选框必须选择一条记录。

function CheckOne(stralert,varform)
{
	var j=0;
	for ( var i =0; i<varform.elements.length;i++)
	{
		var e = varform.elements[i];
		if(e.type=="radio"&&e.checked==true)
		{
			j++
		}
	}
	if(j == 0)
	{
		alert(stralert);	
		return false; 
	}
}


function ValidateLength(oSrc, args)
{
	args.IsValid = (GetByteLength(args.Value) <= oSrc["limit"]); 
}
function GetByteLength(str)
{
	
	var iLen = 0;
	for(i = 0; i < str.length; i ++)
	{
		//if(str.charCodeAt(i) >= 8481 && str.charCodeAt(i) <= 63486)
		//{
		//	iLen += 2;
		//}
		//else
		//{
			iLen += 1;
		//}
	}
	return iLen;
}
function Trim(str)
{
    str = str.replace(/\ /g, '');
    return str;
}


/*	BEGIN 会计数字大小写转换

*	add by ylren
*/

function NumberToString(number) 
{
 var numericString = number.toString();
 
 var expression  = new RegExp(/^\d+$/);
 var expression2 =  new RegExp(/^\d+\.\d{2}$/);
 var expression1 =  new RegExp(/^\d+\.\d{1}$/);

 if (expression.test(numericString) == false && expression1.test(numericString) == false && expression2.test(numericString) == false)
 {
  //alert("请输入数字，最多两位小数！");
  return;
 }
 
 if (expression1.test(numericString) == true)
 {
  numericString += "0";
 }
 else if (expression.test(numericString) == true)
 {
  numericString += ".00";
 }
 
 /*if (numericString.length > 9)
 {
  //alert("整数部分最多6位，小数部分最多２位！");
  return;
 }*/
 
 return numericString.replace(".", "");
}
function SmallToBig(number)
{
 var chineseDigitalString = '零壹贰叁肆伍陆柒捌玖';
 var arabianDigitalString = '0123456789';
 
 var chineseUnits = new Array("分", "角", "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿");
 var superUnits = new Array("拾", "佰", "仟", "万", "拾", "佰", "仟", "亿");
 
 var numericString = NumberToString(number);
 if (numericString == null) 
 {
  //alert("请输入数字，最多两位小数！");
  return;
 }
 
 var bigStyleString = "";
 var length = numericString.length;
 var index = length - 1;
 var superIndex;
 
  for (var i = 0; i < length; i++)
 {
  var digit = numericString.charAt(i);
  var unit;
  var x;
  
  x = chineseDigitalString.charAt(arabianDigitalString.indexOf(digit))
  unit = chineseUnits[index];

  if(unit == null)
  {  
	superIndex = index - 10;
	while(superIndex > 8)
	{
		superIndex = superIndex - 8;
	}
	superIndex -= 1;
	unit = 	superUnits[superIndex];
  }
  
  bigStyleString += x + unit;
  
  index--;
 } 
 // 叁亿叁仟零佰零拾零万贰仟零佰零拾零元贰角叁分
 
 bigStyleString = bigStyleString.replace(/零仟/g, "零");
 bigStyleString = bigStyleString.replace(/零佰/g, "零");
 bigStyleString = bigStyleString.replace(/零拾/g, "零");
 bigStyleString = bigStyleString.replace(/零{2,}/g, "零");
 bigStyleString = bigStyleString.replace(/零万/g, "万");
 
 if (bigStyleString.indexOf("零元") != 0)
  bigStyleString = bigStyleString.replace(/零元/g, "元");
 else
  bigStyleString = bigStyleString.replace(/零元/g, "");
  
 bigStyleString = bigStyleString.replace(/零角零分/g, "");
 bigStyleString = bigStyleString.replace(/零分/g, ""); 
 
 if (bigStyleString.indexOf("元") == bigStyleString.length - 1)
  bigStyleString += "整";
 if(bigStyleString == "整")
 {
     bigStyleString = "零";
 } 
 return bigStyleString; 
}
/*	END 会计数字大小写转换*/
<!--

// 用途：enter 转化成tab
//使用：onload ="initEnter2Tab()" form标记加上 <form name="frm" type="enter2tab">...</form>

var isCycle = false; //当光标到最后一个元素的时候，是否循环光标焦点，

var iCurrent = -1;
var frmName = "0"//input_form
//
function enterToTab()  //网页里按回车时焦点的转移
{
  var e = document.activeElement;
  if(e == null) return false;
  //获得当前表单的名字

  for(i=0;i<document.forms.length;i++){  
 for(var el in document.forms[i].elements){
  if(e.UniqueID == el.UniqueID){
   frmName = document.forms[i].name
  }    
 } 
  }
  if(window.event.keyCode == 13)
  {  
   switch(e.tagName)//标签类型
 {
     case "INPUT":
   handleInput(e)
   break;
     case "SELECT":
   handleSelect(e)   
   break;  
     case "TEXTAREA":
   handleTextarea(e)
   break;   
         default:  
    //window.status = "未知的标签名称:"+e.tagName+"，不能移动焦点！"
    }  
  }// end if
}
//处理input 标签类型
function handleInput(e)
{
   switch(e.type)
 {
     case "text":
  case "password":
  case "checkbox":
  case "radio":
  case "file":
   moveFocusToNextElement(e)
   break; 
 // case "submit"://处理有提交按钮的情况
  case "button":
   if(isHandleSubmit(e)){
    handleSubmit(e)
    focusOnNextElement(document.forms[frmName].elements,iCurrent-1)
    break;
   }
   moveFocusToNextElement(e)
   break;            
         default:  
        
    }
}
//处理select 标签类型
function handleSelect(e)
{
 moveFocusToNextElement(e)
}
//处理textarea 标签类型
function handleTextarea(e)
{
 //moveFocusToNextElement(e)
}
//移动到下一个元素

function moveFocusToNextElement(e)
{
  var oE = document.forms[frmName].elements, iCurentPos=-1;
  for(var i=0; i<oE.length; i++)
  {
    if(oE[i] == e) iCurentPos = i;
    if(iCurentPos>-1 && iCurentPos+1<oE.length)
    {
    //把焦点设置到下一个可用的元素上  
  focusOnNextElement(oE,iCurentPos)
    }
  }
}
//下一个可用元素得到焦点 n 元素的位置

function focusOnNextElement(oElements,iIndex)
{
	var oE = oElements
	var oldIndex = iIndex 
	while(oE[iIndex+1].type =="hidden" 
		|| oE[iIndex+1].disabled || oE[iIndex+1].tagName == "FIELDSET" || oE[iIndex+1].style.display == "none")
	{ 
		/*window.status += "e.name = "+oE[iIndex+1].name
		window.status += ";e.type = "+oE[iIndex+1].type
		window.status += ";e.disabled = "+oE[iIndex+1].disabled
		window.status += ";e.readOnly = "+oE[iIndex+1].readOnly+"."*/
		iIndex++;
		if(iIndex+1 == oE.length)
		{
		
			if(isCycle)
			{//设置焦点在第一元素
				focusOnNextElement(oE,-1);
			} 
			return;
		}
	}//end while
	iCurrent = iIndex+1
	oE[iCurrent].focus();
        //window.event.keyCode    = 0;
    window.event.returnValue= false; 
    return;
}
function focusFirstElement(oElements,iIndex)
{
	var oE = oElements
	var oldIndex = iIndex 
	while(oE[iIndex+1].type =="hidden" 
		|| oE[iIndex+1].tagName == "SELECT"
		|| oE[iIndex+1].readOnly == true
		|| oE[iIndex+1].disabled || oE[iIndex+1].tagName == "FIELDSET" || oE[iIndex+1].style.display == "none")
	{ 
		/*window.status += "e.name = "+oE[iIndex+1].name
		window.status += ";e.type = "+oE[iIndex+1].type
		window.status += ";e.disabled = "+oE[iIndex+1].disabled
		window.status += ";e.readOnly = "+oE[iIndex+1].readOnly+"."*/
		iIndex++;
		if(iIndex+1 == oE.length)
		{
		
			if(isCycle)
			{//设置焦点在第一元素
				focusFirstElement(oE,-1);
			} 
			return;
		}
	}//end while
	iCurrent = iIndex+1
	oE[iCurrent].focus();
        //window.event.keyCode    = 0;
    window.event.returnValue= false; 
    return;
}

//处理当前元素
function handleSubmit(element)
{
 element.click()
 return; 
}
//判断是否处理提交
function isHandleSubmit(element)
{
 var ret = false;
 if(element !=null && (element.id.toUpperCase() == "SUBMIT" || element.name.toUpperCase() == "SUBMIT" || element.isSubmit)){
  ret = true;
 }
 return ret; 
}
//初始化 initEnter2Tab()
function initEnter2Tab()
{
 for(i=0;i<document.forms.length;i++){
   document.forms[i].onkeydown = function f(){enterToTab();};
 }
 //文档初始化焦点

 if(document.forms[0].elements != null)
 {
  focusFirstElement(document.forms[0].elements,-1)
 }
} 
//格式化数字(数字，小数位数)
function FormatNumber(srcStr,nAfterDot){
    var srcStr,nAfterDot;
    var resultStr,nTen;
    srcStr = ""+srcStr+"";
    strLen = srcStr.length;
    dotPos = srcStr.indexOf(".",0);
    if (dotPos == -1){
        resultStr = srcStr+".";
        for (i=0;i<nAfterDot;i++){
            resultStr = resultStr+"0";
        }
        return resultStr;
    } else{
        if ((strLen - dotPos - 1) >= nAfterDot){
            nAfter = dotPos + nAfterDot + 1;
            nTen =1;
            for(j=0;j<nAfterDot;j++){
            nTen = nTen*10;
        }
        resultStr = Math.round(parseFloat(srcStr)*nTen)/nTen;
        return resultStr;
        } else{
            resultStr = srcStr;
            for (i=0;i<(nAfterDot - strLen + dotPos + 1);i++){
                resultStr = resultStr+"0";
            }
            return resultStr;
        }
    }
}
//Desc:选取所有名字相同的checkbox
//date:2006-06-15
//User:songxq

function selectAll(boxName)
{
   var box = document.getElementsByName(boxName);
   for (var i = 0; i <= box.length-1; i++)
      box[i].checked = true;
}
//Desc:取消选取所有名字相同的checkbox
//date:2006-06-15
//User:songxq
function unSelectAll(boxName)
{
   var box = document.getElementsByName(boxName);
   for (var i = 0; i <= box.length-1; i++)
      box[i].checked = false;
}
//-->

//Desc:清除控件IDCtr,NameCtr(为自定义文本)的值
//date:2006-08-15
//User:张虎
function ClearValue(IDCtr,NameCtr)
{
   document.getElementById(IDCtr).value = "";
   document.getElementById(NameCtr+"_TextBox1").value = "";
}

//ctrl + enter 实现隐藏与打开左边菜单栏的快捷键        
function hotkey() 
{ 
    var iKey=window.event.keyCode; 
    if((iKey==13)&&(event.ctrlKey)) 
    { 
         window.parent.mainFrameSet.cols = window.parent.mainFrameSet.cols=="0,10,*"?"190,10,*":"0,10,*";
    } 
}
document.onkeydown = hotkey;