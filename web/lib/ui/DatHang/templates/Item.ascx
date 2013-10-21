<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_DatHang_templates_Item" %>
<tr class="<%=Item.GiaoHang ? "success" : "" %>">
    <td>
        <a href="/lib/pages/DatHang/Edit.aspx?id=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/KhachHang/Edit.aspx?id=<%=Item.KH_ID %>">
            <%=Item.KH_Ten %>
        </a>
    </td>
    <td>
        <%=Item.KH_Mobile %>
    </td>
    <td>
        <%=Item.KH_DiaChi %>
    </td>
    <td>
        <%=Item.UuTien %>
    </td>
    <td>
        <%=Item.NgayDat == DateTime.MinValue ? string.Empty : Item.NgayDat.ToString("hh:mm dd/MM") %>
    </td>
    <td>
        <%=Item.NgayGiaoYeuCau == DateTime.MinValue ? string.Empty : Item.NgayGiaoYeuCau.ToString("hh:mm dd/MM") %>
    </td>
    <td>
        <%=Item.TT_Ten %>
    </td>
    <td>
        <%=Item.GiaoHang ? "OK" : "X" %>
    </td>
</tr>