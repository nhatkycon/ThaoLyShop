<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaItemIn.ascx.cs" Inherits="lib_ui_DatHang_templates_HangHoaItemIn" %>
<tr>
     <td>
        <%=Item._HangHoa.Ma %>
    </td>    
    <td>
        <%=Item._HangHoa.Ten %>
    </td>
    <td>
        <%=Item._HangHoa.GNY %>
    </td>
    <td>
        <%=Item.HH_SoLuong %>
    </td>
    <td>
        <% = Item.HH_Gia * Item.HH_SoLuong %>
    </td>
</tr>