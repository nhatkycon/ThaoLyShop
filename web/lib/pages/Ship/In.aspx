<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In.aspx.cs" Inherits="lib_pages_Ship_In" %>

<%@ Register src="../../ui/ThaoLy/Ship/templates/InItem.ascx" tagname="InItem" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/lib/css/web/print.css" rel="stylesheet" />
    <style type="text/css" media="print">
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            <uc1:InItem ID="InItem1" runat="server" />            
        </div>
        <div class="page">
            <uc1:InItem  ID="InItem2" runat="server" />
        </div>
    </form>
</body>
</html>
