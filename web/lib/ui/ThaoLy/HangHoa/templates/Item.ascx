<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ThaoLy_HangHoa_templates_Item" %>
<tr class="<%=(Item.SoLuong==0) ? "warning" : "" %>">
    <td>
        <a href="/lib/pages/HangHoa/View.aspx?id=<%=Item.ID %>">
                    <%=Item.Ten %>
        </a>
    </td>
    <td>
        <%=Item.GNY %>
    </td>
    <td>
        <%=Item.SoLuong %>
    </td>
    <td>
        <%if (!string.IsNullOrEmpty(Item.Keywords)) {%>
            <a target="_blank" href="<%=Item.Keywords %>">
                <i class="icon icon-link"></i>
            </a>
        <%} %>
    </td>
</tr>