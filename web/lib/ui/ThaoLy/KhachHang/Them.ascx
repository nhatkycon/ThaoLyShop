<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Them.ascx.cs" Inherits="lib_ui_ThaoLy_KhachHang_Them" %>
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
<div class="KhachHangForm" >
    <div class="form-horizontal">
        <fieldset>
            <div class="row row-fluid">
                    <!-- Text input-->
                    
                    <input id="ID" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="ID" type="text"class="input-xlarge" required="">

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Ten">Họ và Tên</label>
                        <div class="controls">
                        <input id="Ten" value="<%=Item.Ten %>" name="Ten" type="text" placeholder="vd: Nguyễn Xuân Linh" class="input-xlarge" required="">
                        <p class="help-block">Nhập họ và tên đầy đủ của bạn</p>
                        </div>
                    </div>

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Điện thoại</label>
                        <div class="controls">
                        <input id="Mobile" value="<%=Item.Mobile %>" name="Mobile" type="text" placeholder="Số điện thoại di động" class="input-xlarge" required="">
                        <p class="help-block">Chúng tôi sẽ gọi lại cho quý khách</p>
                        </div>
                    </div>            

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Facebook</label>
                        <div class="controls">
                        <input id="FacebookUid" value="<%=Item.FacebookUid %>" name="FacebookUid" type="text" placeholder="Địa chỉ facebook của khách" class="input-xlarge">
                        <p class="help-block">Địa chỉ Facebook</p>
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
                        <label class="control-label" for="Mobile">Khu vực</label>
                        <div class="controls">
                        <uc1:DanhMucByLoaiDanhMuc ControlName="KhuVuc_ID" ControlId="KhuVuc_ID" ID="KhuVuc_ID" runat="server" />
                        <p class="help-block">Khu vực
                            </p>
                        </div>
                    </div>
                         <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Trạng thái</label>
                        <div class="controls">
                            <%if (Item.NgungTheoDoi)
                              {%>
                                <input class="NgungTheoDoi" id="NgungTheoDoi" checked="checked" name="NgungTheoDoi" type="checkbox"/>
                            <%}
                              else
                              {%>
                                <input class="NgungTheoDoi" id="NgungTheoDoi" name="NgungTheoDoi" type="checkbox"/>
                             <% } %>
                        
                        <p class="help-block">Bỏ theo dõi
                            </p>
                        </div>
                    </div>
                    <!-- Textarea -->
                    <div class="control-group">
                        <label class="control-label" for="DiaChi">Địa chỉ</label>
                        <div class="controls">                     
                        <textarea id="DiaChi" name="DiaChi"><%=Item.DiaChi %></textarea>
                        </div>
                    </div>
                <%if (string.IsNullOrEmpty(id))
                {%>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Email">Hàng</label>
                        <div class="controls">
                        <uc2:DanhSachHangHoa ControlName="HH_ID" ControlId="HH_ID" Visible="False" ID="DanhSachHangHoa1" runat="server" />
                            <input class="HH_Ma" name="HH_Ma" type="text" value=""/>
                            <input class="HH_ID" style="display: none;" name="HH_ID" type="text" value=""/>
                        <p class="help-block">Hàng hóa, đúng màu và cỡ</p>
                        </div>
                    </div>
                    
                    <div class="control-group">
                        <label class="control-label" for="KH_Mobile">Ngày đặt</label>
                        <div class="controls">
                            <div id="NgayDatPicker" class="input-append date">
                                <input 
                                    value="<%=DateTime.Now.ToString("hh:mm dd/MM/yyyy") %>"
                                    data-format="hh:mm dd/MM/yyyy" 
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
                        <label class="control-label" for="KH_Mobile">Ngày yêu cầu</label>
                        <div class="controls">
                            <div id="NgayGiaoYeuCauPicker" class="input-append date">
                                <input 
                                    data-format="hh:mm dd/MM/yyyy" 
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

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="GhiChu">Ghi chú</label>
                        <div class="controls">
                        <textarea id="GhiChu" name="GhiChu"><%=Item.DiaChi %></textarea>
                        </div>
                    </div>
            
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="GhiChu">Facebook Url</label>
                        <div class="controls">
                        <textarea id="FacebookUrl" name="FacebookUrl"><%=Item.DiaChi %></textarea>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Ưu tiên</label>
                        <div class="controls">
                        <input class="UuTien" id="UuTien" name="UuTien" type="text"/>
                        <p class="help-block">Mức độ ưu tiên của đơn hàng</p>
                        </div>
                    </div>
                <%} %>
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
        <a href="javascript:;" class="btn btn-success btn-large saveAndHdBtn">Tạo đặt hàng</a>
        <a href="javascript:;" class="btn btn-success btn-large saveAndShipBtn">Tạo hóa đơn</a>
        <%} %>
</div>

<%if (!string.IsNullOrEmpty(id))
{%>
<script>
    $(function () {
        $('.NguonGoc_ID').val('<%=Item.NguonGoc_ID %>');
        $('.KhuVuc_ID').val('<%=Item.KhuVuc_ID %>');
    })
</script>
<hr/>
<h3 class="">Đơn</h3>
<uc3:DanhSach ID="DanhSach1" runat="server" />
<h3 class="">Hàng</h3>
<uc5:HangHoaDanhSachView ID="HangHoaDanhSachView1" runat="server" />
<h3 class="">Chăm sóc</h3>
<div class="well">
    <a href="/lib/pages/ChamSoc/View.aspx?khId=<%=Item.ID %>" class="btn">Thêm</a>
</div>
<uc6:DanhSach ID="DanhSach2" runat="server" />
<%} %>