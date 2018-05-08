<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true" CodeFile="fangan3.aspx.cs" Inherits="ZcMng3_fangan3" Title="公司的项目审批表" %>

<%@ Register Src="SPListView.ascx" TagName="SPListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:SPListView ID="SPListView1" runat="server" ListFlag="3" />
</asp:Content>

