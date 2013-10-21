<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaDanhSach.ascx.cs" Inherits="lib_ui_DatHang_templates_HangHoaDanhSach" %>
<%@ Register src="HangHoaItem.ascx" tagname="HangHoaItem" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:HangHoaItem ID="HangHoaItem1" runat="server"  Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>        

