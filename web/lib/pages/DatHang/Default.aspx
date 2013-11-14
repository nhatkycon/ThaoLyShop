<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_DatHang_Default" %>
<%@ Register src="../../ui/HeThong/DanhMucByLoaiDanhMuc.ascx" tagname="DanhMucByLoaiDanhMuc" tagprefix="uc2" %>
<%@ Register src="../../ui/DatHang/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="KhachHangHeader ModuleHeader well form-inline">
            <a href="Edit.aspx" class="btn">Thêm</a>
            <uc2:DanhMucByLoaiDanhMuc ControlName="TT_ID" ControlId="TT_ID" ID="TT_ID" runat="server" />
            <uc2:DanhMucByLoaiDanhMuc Visible="False" ControlName="KhuVuc_Id" ControlId="KhuVuc_Id" ID="KhuVuc" runat="server" />   
            <label class="checkbox">
                <input type="checkbox"name="GiaoHang" id="GiaoHang"/> 
                Đã giao
            </label>
            <input name="q" placeholder="Nhập tên, mobile, địa chỉ, mã đặt hàng" value="<%=Request["q"] %>" type="text" class="input-xlarge"/>
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

