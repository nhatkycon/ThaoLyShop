<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InDanhSach.aspx.cs" Inherits="lib_pages_Ship_InDanhSach" %>

<%@ Register src="../../ui/ThaoLy/Ship/templates/DanhSachIn.ascx" tagname="DanhSachIn" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/web/print.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:DanhSachIn ID="DanhSachIn1" runat="server" />
    
    </div>
    </form>
</body>
</html>
