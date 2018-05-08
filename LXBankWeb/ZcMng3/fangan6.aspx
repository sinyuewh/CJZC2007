<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true"
    CodeFile="fangan6.aspx.cs" Inherits="ZcMng3_fangan6" Title="领导秘书专栏" %>

<%@ Register Src="SPListView.ascx" TagName="SPListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SPListView ID="SPListView1" runat="server" ListFlag="6"  MenuIndex="5"/>
</asp:Content>
