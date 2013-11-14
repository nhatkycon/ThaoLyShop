<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Them.ascx.cs" Inherits="lib_ui_ThaoLy_ChamSoc_Them" %>
<%@ Import Namespace="linh.controls" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucByLoaiDanhMuc.ascx" tagname="DanhMucByLoaiDanhMuc" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/HeThong/DanhSachHangHoa.ascx" tagname="DanhSachHangHoa" tagprefix="uc2" %>
<%@ Register src="../../DatHang/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc3" %>
<%@ Register src="../../DatHang/templates/HangHoaDanhSach.ascx" tagname="HangHoaDanhSach" tagprefix="uc4" %>
<%@ Register src="../../DatHang/templates/HangHoaDanhSachView.ascx" tagname="HangHoaDanhSachView" tagprefix="uc5" %>
<%@ Register src="../ChamSoc/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc6" %>
<div class="KhachHangHeader ModuleHeader well">
    <a href="Default.aspx" class="btn btn-primary backbtn">
        <i class="icon icon-back"></i> Quay lại
    </a>
</div>
<div class="ChamSocForm" >
    <div class="form-horizontal">
        <fieldset>
            <div class="row row-fluid">
                <div class="span5">
                    <!-- Text input-->
                    <%if(string.IsNullOrEmpty(khId))
                      { %>
                    <div class="control-group">
                        <label class="control-label" for="KH_ID">Khách hàng</label>
                        <div class="controls">
                        <input class="KH_Ten" id="KH_Ten" name="KH_Ten" value="<%= Item.KH_Ten %>" data-id="<%= Item.KH_ID %>" type="text"/>
                            <input class="KH_ID" style="display: none;" id="KH_ID" name="KH_ID" value="<%= Item.KH_ID %>" type="text"/>
                             <% if (!string.IsNullOrEmpty(id))
                                {%>
                                    <a class="btn" href="/lib/pages/KhachHang/Edit.aspx?id=<%= Item.KH_ID %>">
                                        <i class="icon icon-link"></i>
                                    </a>
                            <% } %>
                            <a href="javascript:;" class="btn btnThemNhanhKH">
                                <i class="icon icon-add"></i> Thêm nhanh
                            </a>
                        <p class="help-block">
                           
                            </p>
                        </div>
                    </div>
                    <% }
                      else
                      {%>
                        <input name="KH_ID" value="<%=Item.KH_ID %>" style="display: none;"/>                          
                    <%  }%>
                    <input id="ID" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="ID" type="text"class="input-xlarge" required="">
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Ten">Mã</label>
                        <div class="controls">
                        <input id="Ma" value="<%=string.IsNullOrEmpty(Item.Ma) ? linh.controls.CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10) : Item.Ma %>" name="Ma" type="text" class="input-xlarge" required="">
                        <p class="help-block">Mã chăm sóc</p>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Loại</label>
                        <div class="controls">
                        <uc1:DanhMucByLoaiDanhMuc ControlName="LOAI_ID" ControlId="LOAI_ID" ID="LOAI_ID" runat="server" />
                        <p class="help-block">Loại
                            </p>
                        </div>
                    </div>                    
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Tình trạng</label>
                        <div class="controls">
                        <uc1:DanhMucByLoaiDanhMuc ControlName="TT_ID" ControlId="TT_ID" ID="TT_ID" runat="server" />
                        <p class="help-block">Tình trạng
                            </p>
                        </div>
                    </div>            
                    <!-- Textarea -->
                    <div class="control-group">
                        <label class="control-label" for="NoiDung">Nội dung</label>
                        <div class="controls">                     
                        <textarea id="NoiDung" name="NoiDung"><%=Item.NoiDung %></textarea>
                        </div>
                    </div>
                </div>
            </div>
        <div class="alert alert-success">
            Thêm thành công
        </div>
        <div class="alert alert-error">
            Bạn cần nhập Tên, Email, và Mobile<br/>                        
        </div>
        </fieldset>
        </div>
        <hr/>
        <%if (!string.IsNullOrEmpty(id))
          {%>
        <a href="javascript:;" class="btn btn-primary btn-large savebtn">Lưu</a>
        <a href="javascript:;" class="btn btn-warning btn-large xoaBtn">Xóa</a>
        <%}
        else
        {%>
        <a href="javascript:;" class="btn btn-primary btn-large savebtn">Lưu</a>
        <%} %>
</div>
<%if(!string.IsNullOrEmpty(id)){ %>
<script>
    $(function () {
        $('.LOAI_ID').val('<%=Item.LOAI_ID %>');
        $('.TT_ID').val('<%=Item.TT_ID %>');
    })
</script>
<%} %>