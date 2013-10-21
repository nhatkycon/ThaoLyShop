<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_ChamSoc_templates_Item" %>
<tr>
    <td>
        <%=Item.Ma %>
    </td>
    <td>
        <%=Item.LOAI_ID %>
    </td>
    <td>
        <%=Item.NoiDung %>
    </td>
    <td>
        <%=Item.NguoiTao %>
    </td>
    <td>
        <%=Item.TT_ID %>
    </td>
    <td>
        <%=Item.NgayTao.ToString("hh:mm dd/MM") %>
    </td>
</tr>