<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InItem.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_templates_InItem" %>
<%@ Register src="../../../DatHang/templates/HangHoaDanhSachView.ascx" tagname="HangHoaDanhSachView" tagprefix="uc1" %>
<%@ Register src="../../../DatHang/templates/HangHoaDanhSachIn.ascx" tagname="HangHoaDanhSachIn" tagprefix="uc2" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<table class="auto-style1">
    <tr>
        <td>
            <%=ItemDm.Description %>
        </td>
        <td style="width: 300px;">
            <table>
                <tr>
                    <td style="width: 100px; text-align: right;">
                        Số phiếu:
                    </td>
                    <td>
                        <%=Item.Ma %>
                    </td>                    
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right;">
                        Ngày lập:
                    </td>
                    <td>
                        <%=Item.NgayTao.ToString("hh:mm dd/MM/yy") %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>    
</table>
<table class="auto-style1">
    <tr>
        <td>
            <h1>
                <center>
                    ĐƠN SHIP HÀNG                    
                </center>
            </h1>
        </td>
    </tr>
</table>
<h4>
    Người ship: .................... 
</h4>
<table width="100%">
    <tr>
        <td valign="top" style="width: 50%;">
            <h3>
                Khách hàng
            </h3>
            <table border="1" cellpadding="4" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Họ và Tên:
                    </td>
                    <td>
                        <%=Item._DatHang.KH_Ten %>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Mobile:
                    </td>
                    <td>
                        <%=Item._DatHang.KH_Mobile %>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Địa chỉ:
                    </td>
                    <td>
                        <%=Item._DatHang.KH_DiaChi %>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Ngày đặt:
                    </td>
                    <td>
                        <%=Item._DatHang.KH_Mobile %>
                    </td>
                </tr>
            </table>            
        </td>
        <td valign="top" style="width: 50%;">
            <h3>
                Tiền
            </h3>
            <table border="1" cellpadding="4" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Tiền hàng:
                    </td>
                    <td>
                        <%=Item.PhaiThu %>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Phí ship:
                    </td>
                    <td>
                        <%=Item.Phi %>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right; font-style: italic;">
                        Tổng:
                    </td>
                    <td>
                        <%=Item.Phi + Item.PhaiThu %>
                    </td>
                </tr>
            </table>            
        </td>
    </tr>
</table>
<hr/>
<br/>
<h3>
    Hàng hóa    
</h3>
<br/>
<uc2:HangHoaDanhSachIn ID="HangHoaDanhSachIn1" runat="server" />
<br/>
<br/>
<table width="100%"  cellpadding="4" cellspacing="0">
    <tr>
        <td style="text-align: center; width: 25%; font-weight: bold;">
            NGƯỜI LẬP PHIẾU
        </td>
        <td style="text-align: center; width: 25%; font-weight: bold;">
            NGƯỜI NHẬN HÀNG
        </td>
        <td style="text-align: center; width: 25%; font-weight: bold;">
            NGƯỜI SHIP
        </td>
        <td style="text-align: center; width: 25%; font-weight: bold;">
            
        </td>
    </tr>
    <tr>
        <td style="text-align: center; width: 25%; font-weight: bold;">
        </td>
        <td style="text-align: center; width: 25%; font-weight: bold;">
        </td>
        <td style="text-align: center; width: 25%; font-weight: bold;">
        </td>
        <td style="text-align: center; width: 25%; font-weight: bold;">
        </td>
    </tr>

</table>