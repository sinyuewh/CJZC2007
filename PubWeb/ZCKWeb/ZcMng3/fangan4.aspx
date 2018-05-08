<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_fangan4, App_Web_e4dfeo-d" title="需要我审批的项目" stylesheettheme="CjzcWeb" %>
<%@ Register Src="SPListView.ascx" TagName="SPListView" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:SPListView ID="SPListView1" runat="server" ListFlag="4" MenuIndex="5" />
</asp:Content>

