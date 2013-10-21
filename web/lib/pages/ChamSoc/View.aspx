<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_ChamSoc_View" %>

<%@ Register src="../../ui/ThaoLy/ChamSoc/Them.ascx" tagname="Them" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Them ID="Them1" runat="server" />
</asp:Content>

