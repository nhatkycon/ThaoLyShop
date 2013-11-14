<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover ShipDanhSach">
    <thead>
        <tr>
            <th>
                <input type="checkbox" class="ship-all-ckb" name="id"/>
            </th>
            <th>
                Mã
            </th>
            <th>
                Đặt hàng
            </th>
            <th>
                Phí
            </th>
            <th>
                Khách hàng
            </th>
            <th>
                Mobile
            </th>
            <th>
                Địa chỉ
            </th>
            <th>
                Tình trạng
            </th>
            <th>
                Ngày tạo
            </th>
            <th>
                Ngày giao
            </th>
            <th>
                Đã giao
            </th>
            <th>
                Nộp tiền
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item2" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>
