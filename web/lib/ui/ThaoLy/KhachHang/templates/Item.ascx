<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_KhachHang_templates_Item" %>
<tr>
    <td>
        <a href="Edit.aspx?id=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td>
        <%=Item.FacebookUid %>
    </td>
    <td>
        <%=Item.Mobile %>
    </td>
    <td>
        <%=Item.DiaChi %>
    </td>
    <td>
        <%=Item.KhuVuc_Ten %>
    </td>
    <td>
        <%=Item.NguonGoc_Ten %>
    </td>
</tr>