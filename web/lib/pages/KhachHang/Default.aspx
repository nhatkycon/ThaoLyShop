<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_KhachHang_Default" %>

<%@ Register src="../../ui/ThaoLy/KhachHang/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc1" %>

<%@ Register src="../../ui/HeThong/DanhMucByLoaiDanhMuc.ascx" tagname="DanhMucByLoaiDanhMuc" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="KhachHangHeader ModuleHeader well well-small">
        <a href="/lib/pages/KhachHang/Edit.aspx" class="btn">Thêm</a>
        <uc2:DanhMucByLoaiDanhMuc ControlName="NguonGoc_Id" ControlId="NguonGoc_Id" ID="NguonGoc" runat="server" />
        <uc2:DanhMucByLoaiDanhMuc ControlName="KhuVuc_Id" ControlId="KhuVuc_Id" ID="KhuVuc" runat="server" />    
        <input name="q" value="<%=Request["q"] %>" type="text" class="input-xlarge" placeholder="Nhập tên, mobile, địa chỉ, facebook"/>
        <a href="javascript:;" class="btn KhachHangSearchBtn">
            <i class="icon icon-search"></i>
        </a>
        <a href="Default.aspx" class="btn">
            <i class="icon icon-remove"></i>
        </a>
    </div>
    <uc1:DanhSach ID="DanhSach1" runat="server" />
    <ul class="PagingList">
        <%=paging %>
    </ul>
</asp:Content>

