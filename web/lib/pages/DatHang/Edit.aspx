<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="lib_pages_DatHang_Edit" %>

<%@ Register src="../../ui/DatHang/Them.ascx" tagname="Them" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Them ID="Them1" runat="server" />
</asp:Content>

