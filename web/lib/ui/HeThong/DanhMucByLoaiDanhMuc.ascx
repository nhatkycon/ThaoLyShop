<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhMucByLoaiDanhMuc.ascx.cs" Inherits="lib_ui_HeThong_DanhMucByLoaiDanhMuc" %>
<%@ Register src="templates/DanhMucItem.ascx" tagname="DanhMucItem" tagprefix="uc1" %>
<select name="<%=ControlName %>" class="<%=ControlId %>">
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:DanhMucItem ID="DanhMucItem1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</select>



