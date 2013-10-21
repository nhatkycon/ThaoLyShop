<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Them.ascx.cs" Inherits="lib_ui_DatHang_Them" %>
<%@ Import Namespace="linh.controls" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucByLoaiDanhMuc.ascx" tagname="DanhMucByLoaiDanhMuc" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/HeThong/DanhSachHangHoa.ascx" tagname="DanhSachHangHoa" tagprefix="uc2" %>

<%@ Register src="templates/HangHoaDanhSach.ascx" tagname="HangHoaDanhSach" tagprefix="uc3" %>

<%@ Register src="../ThaoLy/HoaDon/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc4" %>

<%@ Register src="../ThaoLy/Ship/templates/DanhSach.ascx" tagname="DanhSach" tagprefix="uc5" %>

<div class="KhachHangHeader ModuleHeader well">
    <a href="Default.aspx" class="btn btn-primary backbtn">
        <i class="icon icon-back"></i> Quay lại
    </a>
</div>
<div class="DatHangForm" >
    
    <div class="form-horizontal">
        <fieldset>
            <div class="row row-fluid">
                <div class="span5">
                    <!-- Text input-->
                    <input id="ID" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="ID" type="text"class="input-xlarge" required="">

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Ten">Mã</label>
                        <div class="controls">
                        <input id="Ma" value="<%=string.IsNullOrEmpty(Item.Ma) ? linh.controls.CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10) : Item.Ma %>" name="Ma" type="text" class="input-xlarge" required="">
                        <p class="help-block">Mã đơn hàng</p>
                        </div>
                    </div>

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="GiaTri">Giá</label>
                        <div class="controls">
                        <input id="GiaTri" value="<%=Item.GiaTri %>" name="GiaTri" type="text" placeholder="Giá đơn hàng" class="input-xlarge" required="">
                        <p class="help-block"></p>
                        </div>
                    </div>            

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="PhiVanChuyen">Phí vận chuyển</label>
                        <div class="controls">
                        <input id="PhiVanChuyen" value="<%=Item.PhiVanChuyen %>" name="PhiVanChuyen" type="text" placeholder="Phí vận chuyển" class="input-xlarge">
                        <p class="help-block">Phí vận chuyển ước lượng</p>
                        </div>
                    </div>
            
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Nguồn gốc</label>
                        <div class="controls">
                        <uc1:DanhMucByLoaiDanhMuc ControlName="NguonGoc_ID" ControlId="NguonGoc_ID" ID="NguonGoc_ID" runat="server" />
                        <p class="help-block">Nguồn gốc
                            </p>
                        </div>
                    </div>
            
                        <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Tình trạng</label>
                        <div class="controls">
                        <uc1:DanhMucByLoaiDanhMuc ControlName="TT_ID" ControlId="TT_ID" ID="KhuVuc_ID" runat="server" />
                        <p class="help-block">Tình trạng đặt hàng
                            </p>
                        </div>
                    </div>
                    
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="UuTien">Ưu tiên</label>
                        <div class="controls">
                        <input id="UuTien" value="<%=Item.UuTien %>" name="UuTien" type="text" placeholder="Mức độ ưu tiên" class="input-xlarge">
                        <p class="help-block">Càng cao càng ưu tiên</p>
                        </div>
                    </div>

                         <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="GiaoHang">Đã giao</label>
                        <div class="controls">
                            <%if(Item.GiaoHang) {%>
                                <input class="GiaoHang" checked="checked" id="GiaoHang" name="GiaoHang" type="checkbox"/>                            
                            <%}
                              else
                              {%>
                                <input class="GiaoHang" id="GiaoHang" name="GiaoHang" type="checkbox"/>                              
                             <% } %>
                        <p class="help-block">Đã giao hàng
                            </p>
                        </div>
                    </div>
                    
                         <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Readed">Xem</label>
                        <div class="controls">
                            <%if (Item.Readed)
                              {%>
                                <input class="Readed" checked="checked" id="Readed" name="Readed" type="checkbox"/>
                            <%}
                              else
                              {%>
                                <input class="Readed" id="Readed" name="Readed" type="checkbox"/>
                             <% } %>
                        <p class="help-block">Tình trạng đã xem đơn hàng chưa
                            </p>
                        </div>
                    </div>
                    <!-- Textarea -->
                    <div class="control-group">
                        <label class="control-label" for="DiaChi">Facebook url</label>
                        <div class="controls">                     
                        <textarea id="FacebookUrl" name="FacebookUrl"><%=Item.FacebookUrl %></textarea>
                        </div>
                    </div>
                    <!-- Textarea -->
                    <div class="control-group">
                        <label class="control-label" for="DiaChi">Ghi chú</label>
                        <div class="controls">                     
                        <textarea id="GhiChu" name="GhiChu"><%=Item.GhiChu %></textarea>
                        </div>
                    </div>
                </div>
                <div class="span5 pull-right">
                    <div class="control-group">
                        <label class="control-label" for="KH_ID">Khách hàng</label>
                        <div class="controls">
                        <input class="KH_Ten" id="KH_Ten" name="KH_Ten" value="<%=Item.KH_Ten %>" data-id="<%=Item.KH_ID %>" type="text"/>
                            <input class="KH_ID" style="display: none;" id="KH_ID" name="KH_ID" value="<%=Item.KH_ID %>" type="text"/>
                             <%if (!string.IsNullOrEmpty(id))
                              {%>
                                    <a class="btn" href="/lib/pages/KhachHang/Edit.aspx?id=<%=Item.KH_ID %>">
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
                    <div class="control-group">
                        <label class="control-label" for="KH_Mobile">Mobile</label>
                        <div class="controls">
                        <input class="KH_Mobile" id="KH_Mobile" value="<%=Item.KH_Mobile %>" name="KH_Mobile" type="text"/>
                        <p class="help-block">Mobile khách hàng
                            </p>
                        </div>
                    </div>
                    
                     <div class="control-group">
                        <label class="control-label" for="KH_Mobile">Ngày đặt</label>
                        <div class="controls">
                            <div id="NgayDatPicker" class="input-append date">
                                <input 
                                    data-format="hh:mm dd/MM/yyyy" 
                                    value="<%=Item.NgayDat ==DateTime.MinValue? string.Empty :  Item.NgayDat.ToString("hh:mm dd/MM/yyyy") %>" 
                                    class="NgayDat" 
                                    id="NgayDat" 
                                    name="NgayDat" 
                                    type="text"/>
                                <span class="add-on">
                                  <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                                  </i>
                                </span>
                            </div>
                        <p class="help-block">Ngày khách hàng đặt
                            </p>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="KH_Mobile">Ngày giao y/c</label>
                        <div class="controls">
                            <div id="NgayGiaoYeuCauPicker" class="input-append date">
                                <input 
                                    data-format="hh:mm dd/MM/yyyy" 
                                    value="<%=Item.NgayGiaoYeuCau ==DateTime.MinValue? string.Empty :  Item.NgayGiaoYeuCau.ToString("hh:mm dd/MM/yyyy") %>" 
                                    class="NgayGiaoYeuCau" 
                                    id="NgayGiaoYeuCau" 
                                    name="NgayGiaoYeuCau" 
                                    type="text"/>
                                <span class="add-on">
                                  <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                                  </i>
                                </span>
                            </div>
                        <p class="help-block">Ngày khách hàng yêu cầu giao
                            </p>
                        </div>
                    </div>
                    
                     <div class="control-group">
                        <label class="control-label" for="KH_Mobile">Ngày giao</label>
                        <div class="controls">
                            <div id="NgayGiaoPicker" class="input-append date">
                                <input 
                                    data-format="hh:mm dd/MM/yyyy" 
                                    value="<%=Item.NgayGiao ==DateTime.MinValue? string.Empty :  Item.NgayGiao.ToString("hh:mm dd/MM/yyyy") %>" 
                                    class="NgayGiao" id="NgayGiao" name="NgayGiao" type="text"/>
                                <span class="add-on">
                                  <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                                  </i>
                                </span>
                            </div>

                        <p class="help-block">Ngày giao hàng
                            </p>
                        </div>
                    </div>

                    <!-- Textarea -->
                    <div class="control-group">
                        <label class="control-label" for="DiaChi">Địa chỉ</label>
                        <div class="controls">                     
                        <textarea id="KH_DiaChi" class="input-large KH_DiaChi" name="KH_DiaChi"><%=Item.KH_DiaChi %></textarea>
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
    <a href="/lib/pages/Ship/Edit.aspx?dhid=<%=Item.ID %>" class="btn btn-success btn-large inDonShipBtn">Thêm ship</a>
        <a href="javascript:;" class="btn btn-warning btn-large xoaBtn">Xóa</a>
        <%}
          else
          {%>
            <a href="javascript:;" class="btn btn-primary btn-large savebtn">Lưu</a>
          <%} %>
</div>

<%if (!string.IsNullOrEmpty(id))
{%>
<hr/>
<h3 class="">Chi tiết</h3>
<table class="table table-striped table-hover DatHangChiTietBox">
    <thead>
        <tr>
            <td>
                Mã
            </td>
            <td>
                Tên
            </td>
            <td>
                Giá
            </td>
            <td>
                Số lượng
            </td>
            <td>
                
            </td>
        </tr>
    </thead>
    <tbody>
        <tr class="ThemHangBox info">
             <td>
                 <input class="HH_Ma" name="HH_Ma" type="text"/>
                 <input class="DH_ID" name="DH_ID" value="<%=Item.ID %>" style="display: none;" type="text"/>
                 <input class="HH_ID" name="HH_ID" style="display: none;" type="text"/>
            </td>
            <td>
                <input class="HH_Ten" name="HH_Ten" type="text"/>
            </td>
            <td>
                <input class="HH_Gia" name="HH_Gia" type="text"/>
            </td>
            <td>
                <input class="HH_SoLuong" name="HH_SoLuong" type="text"/>
                
            </td>
            <td>
                <a href="javascript:;" class="btn themHangBtn">
                    Thêm
                </a>
            </td>
        </tr>
        <uc3:HangHoaDanhSach ID="HangHoaDanhSach1" runat="server" />
    </tbody>
</table>

<h3 class="">Hóa đơn</h3>
<div class="well">
    <a href="javascript:;" data-id="<%=Item.ID %>" class="btn themHoaDonBtn">Thêm</a>
</div>
<uc4:DanhSach ID="DanhSach1" runat="server" />

<h3 class="">Ship</h3>
<div class="well">
    <a href="/lib/pages/Ship/Edit.aspx?dhid=<%=Item.ID %>" data-id="<%=Item.ID %>" class="btn">Thêm</a>
</div>
<uc5:DanhSach ID="DanhSach2" runat="server" />
<script>
    $(function () {
        $('.NguonGoc_ID').val('<%=Item.NguonGoc_ID %>');
        $('.TT_ID').val('<%=Item.TT_ID %>');
    })
</script>
<%} %>