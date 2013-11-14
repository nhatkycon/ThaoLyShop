<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListItem.ascx.cs" Inherits="lib_ui_ThaoLy_Store_templates_ListItem" %>
<%@ Import Namespace="linh.common" %>
<%if(Item.ID==Guid.Empty || string.IsNullOrEmpty(Item.Anh) || Item.PID==Guid.Empty) return; %>
<div class="product-item">
    <a href="/lib/pages/Store/View.aspx?id=<%=Item.ID %>" class="product-item-imgbox">
	    <img class="img-rounded product-item-img" src="/lib/up/i/<%=Lib.imgSize(Item.Anh,"400") %>"/>        
    </a>
    <div class="product-item-infobox">
        <h4>
            <a class="product-item-title" title="<%=Item.Ten %>" href="/lib/pages/Store/View.aspx?id=<%=Item.ID %>">
	            <%=Item.Ten %> <%=Item.GiaTri %>k
	        </a>    
        </h4>
    </div>
</div>