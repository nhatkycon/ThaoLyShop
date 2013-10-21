<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaItem.ascx.cs" Inherits="lib_ui_HeThong_templates_HangHoaItem" %>
<option value="<%=Item.ID %>">
    <%=Item.Ma %>: <%=Item.Ten %> [<%=Item.SoLuong %>]
</option>