<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HangHoaItemView.ascx.cs" Inherits="lib_ui_DatHang_templates_HangHoaItemView" %>
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
        <%=Item._HangHoa.SoLuong %>
    </td>
    <td>
        <%=Item.NgayTao.ToString("hh:mm dd/MM/yy") %>
    </td>
    <td>
        <a href="/lib/pages/DatHang/Edit.aspx?id=<%=Item.DH_ID %>">
            Đặt hàng
        </a>
    </td>
</tr>