<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_KhachHang_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <th class="td320 td768 td1024">
                Mã
            </th>
            <th class="td320 td768 td1024">
                Tên
            </th>
            <th class="td320 td768 td1024">
                Face
            </th>
            <th class="td320 td768 td1024">
                Mobile
            </th>
            <th class="td320 td768 td1024">
                Địa chỉ
            </th>
            <th class="td320 td768 td1024">
                Khu vực
            </th>
            <th class="td320 td768 td1024">
                Nguồn gốc
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>