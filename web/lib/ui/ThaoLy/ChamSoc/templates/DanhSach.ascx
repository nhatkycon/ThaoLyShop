<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_ChamSoc_templates_DanhSach" %>
<%@ Register src="~/lib/ui/ThaoLy/KhachHang/templates/Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <td>
                Mã
            </td>
            <td>
                Loại
            </td>
            <td>
                Nội dung
            </td>
            <td>
                Nhân viên
            </td>
            <td>
                Tình trạng
            </td>
            <td>
                Ngày tạo
            </td>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>