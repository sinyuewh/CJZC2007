<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true" CodeFile="fangan4.aspx.cs" Inherits="ZcMng3_fangan4" Title="需要我审批的项目" %>
<%@ Register Src="SPListView.ascx" TagName="SPListView" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:SPListView ID="SPListView1" runat="server" ListFlag="4" MenuIndex="5" />
</asp:Content>

