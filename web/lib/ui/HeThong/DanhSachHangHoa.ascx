<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSachHangHoa.ascx.cs" Inherits="lib_ui_HeThong_DanhSachHangHoa" %>
<%@ Register src="templates/HangHoaItem.ascx" tagname="HangHoaItem" tagprefix="uc1" %>
<select name="<%=ControlName %>" class="<%=ControlId %>">
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:HangHoaItem ID="HangHoaItem1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</select>
