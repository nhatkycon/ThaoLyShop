<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSachIn.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_templates_DanhSachIn" %>
<%@ Register src="ItemIn.ascx" tagname="Item" tagprefix="uc1" %>
<table class="auto-style1">
    <tr>
        <td>
            <%=ItemDm.Description %>
        </td>
        <td style="width: 300px;">
            <table>
                <tr>
                    <td style="width: 100px; text-align: right;">
                        SỐ:
                    </td>
                    <td>
                        .......................
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right;">
                        Ngày lập:
                    </td>
                    <td>
                        <%=DateTime.Now.ToString("hh:mm dd/MM/yy") %>
                    </td>
                </tr>
            </table>
            <p>
                <i>Liên bàn giao kế toán sau khi ship</i>
            </p>
        </td>
    </tr>    
</table>
<br/>
<table border="1" cellpadding="4" cellspacing="0" width="100%">
    <thead>
        <tr>
            <td>
                Mã
            </td>
            <td>
                Ship
            </td>
            <td>
                T.Hàng
            </td>
            <td>
                K/hàng
            </td>
            <td>
                Mobile
            </td>
            <td>
                Địa chỉ
            </td>
            <td>
                Đã giao
            </td>
            <td>
                Nộp tiền
            </td>
            <td>
                Ký nhận
            </td>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item ID="Item2" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table>

<br/><hr/>
<table>
    <tr>
        <td style="width: 300px;">
            <b>
                Ship
            </b>
        </td>
        <td style="width: 300px;">
            <b>
                Quản lý Ship
            </b>
        </td>
        <td>
            <b>
                Kế toán
            </b>
        </td>
    </tr>
</table>
