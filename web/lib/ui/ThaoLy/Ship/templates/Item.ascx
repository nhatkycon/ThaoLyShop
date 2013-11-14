<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_templates_Item" %>
<tr>
    <td>
        <input type="checkbox" class="ship-item-ckb" name="id" value="<%=Item.ID %>"/>
    </td>
    <td>
        <a href="/lib/pages/Ship/Edit.aspx?id=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/DatHang/Edit.aspx?id=<%=Item.DH_ID %>">
            <%=Item.DH_Ma %>
        </a>
    </td>
    <td>
        <%=Item.Phi %>
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
        <%=Item.TT_Ten %>
    </td>
    <td>
        <%=Item.NgayTao.ToString("HH:mm dd/MM") %>
    </td>
    <td>
        <%=Item.NgayGiao.ToString("HH:mm dd/MM") %>
    </td>
    <td>
        <%=Item.DaGiao ? "OK" : "X" %>
    </td>
    <td>
        <%=Item.TraTien ? "OK" : "X" %>
    </td>
</tr>