<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/web/1.css" rel="stylesheet" type="text/css" />
    <link href="../js/fancybox/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />   
    <%--<link href="../css/web/1/1.css" rel="stylesheet" />   --%>  
    <link rel="stylesheet" type="text/css" href="/lib/css/html/common/css/reset.css" media="all" />
	<link rel="stylesheet" type="text/css" href="/lib/css/html/common/css/common.css" media="all" />
    <script src="/lib/js/jquery-1.8.3.min.js"></script>
    <link href="../css/web/1/cart.css" rel="stylesheet" type="text/css" />
	<%--<script type="text/javascript" src="/lib/js/jquery-1.9.1.min.js"></script>--%>
    <script src="/lib/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="/lib/css/html/common/js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="/lib/css/html/common/js/jquery.selectbox.js"></script>
	<script type="text/javascript" src="/lib/css/html/common/js/hoverIntent.js"></script>
	<script type="text/javascript" src="/lib/css/html/common/js/jcarousel.js"></script>
	<script type="text/javascript" src="/lib/css/html/common/js/skitter.js"></script>
	<script type="text/javascript" src="/lib/css/html/common/js/idTabs.js"></script>
    <script type="text/javascript" src="/lib/css/html/common/js/jsCustom.js"></script>
</head>
<body>
    <%=css %>
    <script src="/lib/js/facebox.js" type="text/javascript"></script>
    <script src="/lib/js/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="/lib/js/ckeditor/adapters/jquery.js" type="text/javascript"></script>
    <script src="/lib/js/ckfinder/ckfinder.js" type="text/javascript"></script> 
    <script type="text/javascript">        var _url = '<%=Request.Url.Query %>';</script>  
    <script src="/lib/js/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="/lib/js/slides.min.jquery.js" type="text/javascript"></script>
    <script src="/lib/js/admin.js" type="text/javascript"></script>
    <script src="/lib/js/web/c.js" type="text/javascript"></script>
    <script type="text/javascript">        var domain = '<%=domain %>';</script>    
    <script src="/lib/js/web/_ibuilder.js" type="text/javascript"></script>
    <script src="/lib/js/web/home.js" type="text/javascript"></script>
    <script src="/lib/js/cart.js" type="text/javascript"></script>
    <script src="/lib/css/html/common/js/jquery.selectbox.js" type="text/javascript"></script>
    <div id="LeenaWrap">
    <%=body%>
    </div>
</body>
</html>
