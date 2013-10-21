<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_HangHoa_templates_Item" %>
<tr>
    <td>
        <a href="/lib/pages/HangHoa/View.aspx?id=<%=Item.ID %>">
            <%=Item.Ma %>            
        </a>
    </td>
    <td>
        <%=Item.Ten %>
    </td>
    <td>
        <%=Item.GNY %>
    </td>
    <td>
        <%=Item.Sizes %>
    </td>
    <td>
        <%=Item.Colors %>
    </td>
    <td>
        <%=Item.SoLuong %>
    </td>
</tr>