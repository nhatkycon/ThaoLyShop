<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaDanhSachView.ascx.cs" Inherits="lib_ui_DatHang_templates_HangHoaDanhSachView" %>
<%@ Register src="HangHoaItemView.ascx" tagname="HangHoaItemView" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <td>
                Mã
            </td>
            <td>
                Tên
            </td>
            <td>
                Giá
            </td>
            <td>
                Số lượng
            </td>
            <td>
                Ngày
            </td>
            <td>
                Xem đơn
            </td>
        </tr>    
    </thead>
    <tbody>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:HangHoaItemView ID="HangHoaItemView1" runat="server"   Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>     
    </tbody>
</table>     