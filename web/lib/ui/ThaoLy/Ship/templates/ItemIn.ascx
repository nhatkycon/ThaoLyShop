<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemIn.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_templates_ItemIn" %>
<tr>
    <td>
        <a href="/lib/pages/Ship/Edit.aspx?id=<%=Item.ID %>">
            <%=Item.Ma %><br/>
            <%=Item.DH_Ma %>
        </a>
    </td>
    <td>
        <%=Item.Phi %>
    </td>
    <td>
        <%=Item.PhaiThu %>
    </td>
    <td>
        <%=Item._DatHang.KH_Ten %>
    </td>
    <td>
        <%=Item._DatHang.KH_Mobile %>
    </td>
    <td>
        <%=Item.DiaChi %>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
</tr>