<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_HangHoa_View" %>

<%@ Register src="../../ui/ThaoLy/HangHoa/templates/ViewItem.ascx" tagname="ViewItem" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ViewItem ID="ViewItem1" runat="server" />
</asp:Content>

