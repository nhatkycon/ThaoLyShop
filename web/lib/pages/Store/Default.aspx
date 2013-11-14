<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Store.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Store_Default" %>

<%@ Register src="../../ui/ThaoLy/Store/List.ascx" tagname="List" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:List ID="List1" runat="server" />
</asp:Content>

