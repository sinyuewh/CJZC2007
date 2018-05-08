<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true" CodeFile="fangan2.aspx.cs" Inherits="ZcMng3_fangan2" Title="部门的项目审批表" %>

<%@ Register Src="SPListView.ascx" TagName="SPListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:SPListView ID="SPListView1" runat="server" ListFlag="2" />
</asp:Content>

