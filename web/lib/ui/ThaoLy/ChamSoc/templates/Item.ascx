<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_ChamSoc_templates_Item" %>
<tr>
    <td>
        <a href="/lib/pages/ChamSoc/View.aspx?id=<%=Item.ID %>">
            <%=Item.Ma %>            
        </a>
    </td>
    <td>
        <%=Item.LOAI_Ten %>
    </td>
    <td>
        <%=Item.NoiDung %>
    </td>
    <td>
        <%=Item.NguoiTao %>
    </td>
    <td>
        <%=Item.TT_Ten %>
    </td>
    <td>
        <%=Item.NgayTao.ToString("hh:mm dd/MM") %>
    </td>
</tr>