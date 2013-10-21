<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_HoaDon_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
        <a href="javascript:;" onclick="quanLyXuatNhapFn.editById('<%=Item.ID %>')">
            <%=Item.Ma %>
        </a>
    </td>
    <td>
        <%=Item.KH_Ten %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.CongTienHang) %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.ThanhToan) %>
    </td>
    <td>
        <%=Item.NgayHoaDon.ToString("dd/MM/yy") %>
    </td>
</tr>