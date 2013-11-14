<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AnhItem.ascx.cs" Inherits="lib_ui_ThaoLy_HangHoa_templates_AnhItem" %>
<%@ Import Namespace="linh.common" %>
<a href="/lib/up/sanPham/<%=Item.ThuMuc %>/<%=Lib.imgSize(Item.Path,"full") %>" class="product-item-relateImg" style="">
    <img class="product-item-relateImg-img" src="/lib/up/sanPham/<%=Item.ThuMuc %>/<%=Item.Path %>"/>
 </a>