<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Ship_Default" %>

<%@ Register src="../../ui/ThaoLy/Ship/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc1" %>
<%@ Register TagPrefix="uc2" TagName="DanhMucByLoaiDanhMuc_1" Src="~/lib/ui/HeThong/DanhMucByLoaiDanhMuc.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="KhachHangHeader ShipHeader ModuleHeader well">
        <a href="Edit.aspx" class="btn">Thêm</a>
        <a href="javascript:;" class="btn btnPrint btn-info">In lựa chọn</a>
        <uc2:DanhMucByLoaiDanhMuc_1 Visible="False" ControlName="TT_ID" ControlId="TT_ID" ID="TT_ID" runat="server" />
        <input name="q" value="<%=Request["q"] %>" type="text" class="input-xlarge" placeholder="Nhập mã, địa chỉ"/>
        <a href="javascript:;" class="btn KhachHangSearchBtn">
            <i class="icon icon-search"></i>
        </a>
        <a href="Default.aspx" class="btn">
            <i class="icon icon-remove"></i>
        </a>
    </div>
    <uc1:DanhSach ID="DanhSach3" runat="server" />
    <ul class="PagingList">
        <%=paging %>
    </ul>
</asp:Content>

