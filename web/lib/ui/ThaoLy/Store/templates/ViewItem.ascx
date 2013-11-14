<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewItem.ascx.cs" Inherits="lib_ui_ThaoLy_Store_templates_ViewItem" %>
<%@ Import Namespace="linh.common" %>
<%@ Register src="HHList.ascx" tagname="HHList" tagprefix="uc1" %>
<div itemscope class="product-view row-fluid" itemtype="http://data-vocabulary.org/Product">
    <div class="product-item-imgbox span4">
        <img id="img" itemprop="image" data-zoom-image="/lib/up/i/<%=Lib.imgSize(Item.Anh,"full") %>" class="img-rounded imgholder product-item-img" src="/lib/up/i/<%=Lib.imgSize(Item.Anh,"400") %>"/>
    </div>
    <div class="product-item-infobox span8">
        <h1 itemprop="name">
            <%=Item.Ten %>
        </h1>
        <p class="product-item-stock">
            Giá: 
            <span itemprop="price"><%=Item.GiaTri %></span>k
        </p>
        <div class="product-item-desc">
            <%=Item.KeyWords %>
        </div>
        <uc1:HHList ID="HHList1" runat="server" />        
    </div>
    <div class="product-item-description">
        <%=Item.Description %>
    </div>
    <div class="fb-comments" 
        data-href="http://thaolyshop.com/lib/pages/store/View.aspx?id=<%=Item.ID %>" 
        data-colorscheme="light" 
        data-numposts="5" 
        data-width="1000">
    </div>
</div>
<script>
    $("#img").elevateZoom();
</script>
