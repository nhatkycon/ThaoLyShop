<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_DatHang_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <th>
                #
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
                Ưu tiên
            </th>
            <th>
                Ngày đặt
            </th>
            <th>
                Ngày giao y/c
            </th>
            <th>
                Trạng thái
            </th>
            <th>
                Đã giao
            </th>
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