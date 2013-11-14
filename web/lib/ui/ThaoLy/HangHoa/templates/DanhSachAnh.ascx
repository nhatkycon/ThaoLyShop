<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSachAnh.ascx.cs" Inherits="lib_ui_ThaoLy_HangHoa_templates_DanhSachAnh" %>
<%@ Register src="AnhItem.ascx" tagname="AnhItem" tagprefix="uc1" %>
<div id="album-view-slider" class="swipe fs-slider">
    <div class="swipe-wrap">       
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:AnhItem ID="AnhItem1" runat="server"  Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>  
      </div>
</div>
