<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaItem.ascx.cs" Inherits="lib_ui_DatHang_templates_HangHoaItem" %>
<tr>
     <td>
         <a href="/lib/pages/HangHoa/View.aspx?id=<%=Item._HangHoa.ID %>">
            <%=Item._HangHoa.Ma %>            
        </a>
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
        <a href="javascript:;" class="btn xoaHangBtn" data-id="<%=Item.ID %>">
            <i class="icon icon-remove"></i>
        </a>
    </td>
</tr>