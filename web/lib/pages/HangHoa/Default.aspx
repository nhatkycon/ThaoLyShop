<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/ThaoLyShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_HangHoa_Default" %>
<%@ Register TagPrefix="uc2" TagName="DanhMucByLoaiDanhMuc_1" Src="~/lib/ui/HeThong/DanhMucByLoaiDanhMuc.ascx" %>

<%@ Register src="../../ui/ThaoLy/HangHoa/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="KhachHangHeader ModuleHeader well">
        <uc2:DanhMucByLoaiDanhMuc_1 ControlName="DM_ID" ControlId="DM_ID" ID="DM_ID" runat="server" />
        <uc2:DanhMucByLoaiDanhMuc_1 Visible="False" ControlName="KhuVuc_Id" ControlId="KhuVuc_Id" ID="KhuVuc" runat="server" />    
        <input name="q" value="<%=Request["q"] %>" type="text" class="input-xlarge" placeholder="Nhập tên, mã"/>
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

