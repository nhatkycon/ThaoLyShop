<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaDanhSachIn.ascx.cs" Inherits="lib_ui_DatHang_templates_HangHoaDanhSachIn" %>
<%@ Register src="HangHoaItemIn.ascx" tagname="HangHoaItemIn" tagprefix="uc2" %>
<table border="1" cellpadding="4" cellspacing="0" width="100%">
    <thead style="font-weight: bold;">
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
                Tổng
            </td>
        </tr>    
    </thead>
    <tbody>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc2:HangHoaItemIn ID="HangHoaItemIn1" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>     
    </tbody>
</table>     
     