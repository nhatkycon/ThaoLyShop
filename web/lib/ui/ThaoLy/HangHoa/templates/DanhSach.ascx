﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_ThaoLy_HangHoa_templates_DanhSach" %>
<%@ Register src="Item.ascx" tagname="Item" tagprefix="uc1" %>
<table class="table table-striped table-hover">
    <thead>
        <tr>
            <th>
                Tên
            </th>
            <th>
                Giá
            </th>
            <th>
                Số lượng
            </th>
            <th>
                Link
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item2" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>
