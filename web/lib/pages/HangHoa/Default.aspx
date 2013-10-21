﻿<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_HangHoa_Default" %>
<%@ Register TagPrefix="uc2" TagName="DanhMucByLoaiDanhMuc_1" Src="~/lib/ui/HeThong/DanhMucByLoaiDanhMuc.ascx" %>

<%@ Register src="../../ui/ThaoLy/HangHoa/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="KhachHangHeader ModuleHeader well">
        <uc2:DanhMucByLoaiDanhMuc_1 Visible="False" ControlName="NguonGoc_Id" ControlId="NguonGoc_Id" ID="NguonGoc" runat="server" />
        <uc2:DanhMucByLoaiDanhMuc_1 Visible="False" ControlName="KhuVuc_Id" ControlId="KhuVuc_Id" ID="KhuVuc" runat="server" />    
        <input name="q" value="<%=Request["q"] %>" type="text" class="input-xlarge"/>
        <a href="javascript:;" class="btn KhachHangSearchBtn">
            <i class="icon icon-search"></i>
        </a>
        <a href="Default.aspx" class="btn">
            <i class="icon icon-remove"></i>
        </a>
    </div>
    <h3>Danh sách hàng hóa</h3>
            <uc1:DanhSach ID="DanhSach1" runat="server" />
</asp:Content>

