<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <td>
                Mã
            </td>
            <td>
                Đặt hàng
            </td>
            <td>
                Phí
            </td>
            <td>
                Khách hàng
            </td>
            <td>
                Mobile
            </td>
            <td>
                Địa chỉ
            </td>
            <td>
                Tình trạng
            </td>
            <td>
                Ngày tạo
            </td>
            <td>
                Ngày giao
            </td>
            <td>
                Đã giao
            </td>
            <td>
                Nộp tiền
            </td>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item2" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>
