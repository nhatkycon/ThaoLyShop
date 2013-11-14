<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_ThaoLy_Store_List" %>
<%@ Register src="templates/ListItem.ascx" tagname="Item" tagprefix="uc1" %>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item2" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>       
