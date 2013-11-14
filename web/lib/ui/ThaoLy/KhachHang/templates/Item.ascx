<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_KhachHang_templates_Item" %>
<tr>
    <td class="td320 td768 td1024">
        <a href="/lib/pages/KhachHang/Edit.aspx?id=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td class="td320 td768 td1024">
        <a href="/lib/pages/KhachHang/Edit.aspx?id=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td class="td320 td768 td1024">
        <%=Item.FacebookUid %>
    </td>
    <td class="td320 td768 td1024">
        <%=Item.Mobile %>
    </td>
    <td class="td320 td768 td1024">
        <%=Item.DiaChi %>
    </td>
    <td class="td320 td768 td1024">
        <%=Item.KhuVuc_Ten %>
    </td>
    <td class="td320 td768 td1024">
        <%=Item.NguonGoc_Ten %>
    </td>
</tr>