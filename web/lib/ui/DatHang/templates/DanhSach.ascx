<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_DatHang_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <td>
                #
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
                Ưu tiên
            </td>
            <td>
                Ngày đặt
            </td>
            <td>
                Ngày giao y/c
            </td>
            <td>
                Trạng thái
            </td>
            <td>
                Đã giao
            </td>
        </tr>    
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:Item ID="Item1" runat="server" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>        
    </tbody>
</table>