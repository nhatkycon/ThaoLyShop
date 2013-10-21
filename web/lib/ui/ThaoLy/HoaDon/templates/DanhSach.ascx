<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_HoaDon_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <asp:Repeater runat="server" ID="rpt">
        <HeaderTemplate>
            <thead>
        <tr>
            <td>
                Mã
            </td>
            <td>
                Khách hàng
            </td>
            <td>
                Cộng
            </td>
            <td>
                Thanh toán
            </td>
            <td>
                Ngày
            </td>
        </tr>    
    </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <uc1:Item ID="Item2" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>
