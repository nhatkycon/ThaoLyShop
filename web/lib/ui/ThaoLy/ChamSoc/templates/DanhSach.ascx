<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_ChamSoc_templates_DanhSach" %>
<%@ Register src="~/lib/ui/ThaoLy/ChamSoc/templates/Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <th>
                Mã
            </th>
            <th>
                Loại
            </th>
            <th>
                Nội dung
            </th>
            <th>
                Nhân viên
            </th>
            <th>
                Tình trạng
            </th>
            <th>
                Ngày tạo
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>