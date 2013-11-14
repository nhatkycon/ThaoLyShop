<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="lib_pages_Login" %>

<%@ Register src="../ui/HeThong/Login.ascx" tagname="Login" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="initial-scale = 1.0,maximum-scale = 1.0" />
    <link href="../css/web/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="../css/web/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/web/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../css/web/animate-custom.css" rel="stylesheet" />
    <link href="../css/web/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/web/font-awesome/css/font-awesome-ie7.min.css" rel="stylesheet" />
    <link href="../css/web/1.css" rel="stylesheet" />
    <link href="../css/admin/redmond/ui-lightness/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" />
    <script src="/lib/js/jqueryLib/jquery-1.8.3.min.js"></script>
    <script src="/lib/js/jqueryLib/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <uc1:Login ID="Login1" runat="server" />
    
    </form>
</body>
</html>
