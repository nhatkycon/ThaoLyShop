<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Them.ascx.cs" Inherits="lib_ui_ThaoLy_Ship_Them" %>
<%@ Import Namespace="linh.controls" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucByLoaiDanhMuc.ascx" tagname="DanhMucByLoaiDanhMuc" tagprefix="uc1" %>
<div class="KhachHangHeader ModuleHeader well">
    <a href="Default.aspx" class="btn btn-primary backbtn">
        <i class="icon icon-back"></i> Quay lại
    </a>
</div>
<div class="ShipForm" >
    
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
                        <p class="help-block"></p>
                        </div>
                    </div>

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="NhanVien">Nhân viên</label>
                        <div class="controls">
                            <input id="NhanVien_Ten" value="<%=Item.NhanVien_Ten %>" name="NhanVien_Ten" type="text" class="input-xlarge NhanVien_Ten" required="">
                            <input id="NhanVien" value="<%=Item.NhanVien %>" name="NhanVien" type="text" class="input-xlarge NhanVien" style="display: none;">
                        <p class="help-block"></p>
                        </div>
                    </div>            

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Phi">Phí</label>
                        <div class="controls">
                        <input id="Phi" value="<%=Item.Phi %>" name="Phi" type="text" placeholder="Phí vận chuyển" class="input-xlarge">
                        <p class="help-block">Phí vận chuyển </p>
                        </div>
                    </div>
            
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="PhaiThu">Phải thu</label>
                        <div class="controls">
                        <input id="PhaiThu" value="<%=Item.PhaiThu %>" name="PhaiThu" type="text" placeholder="Phải thu" class="input-xlarge">
                        <p class="help-block">Tiền phải thu </p>
                        </div>
                    </div>

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="TT_ID">Tình trạng</label>
                        <div class="controls">
                        <uc1:DanhMucByLoaiDanhMuc ControlName="TT_ID" ControlId="TT_ID" ID="TT_ID" runat="server" />
                        <p class="help-block">Tình trạng
                            </p>
                        </div>
                    </div>
            
                         <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="GiaoHang">Đã giao</label>
                        <div class="controls">
                            <%if(Item.DaGiao) {%>
                                <input class="DaGiao" checked="checked" id="DaGiao" name="DaGiao" type="checkbox"/>                            
                            <%}
                              else
                              {%>
                                <input class="DaGiao" id="DaGiao" name="DaGiao" type="checkbox"/>                              
                             <% } %>
                        <p class="help-block">Đã giao hàng
                            </p>
                        </div>
                    </div>
                    
                         <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Readed">Nộp thu ngân</label>
                        <div class="controls">
                            <%if (Item.TraTien)
                              {%>
                                <input class="TraTien" checked="checked" id="TraTien" name="TraTien" type="checkbox"/>
                            <%}
                              else
                              {%>
                                <input class="TraTien" id="TraTien" name="TraTien" type="checkbox"/>
                             <% } %>
                        <p class="help-block">Shipper đã trả tiền nhân viên thu ngân hay chưa
                            </p>
                        </div>
                    </div>
                </div>
                <div class="span5 pull-right">
                    <div class="control-group">
                        <label class="control-label" for="DH_ID">Đơn hàng</label>
                        <div class="controls">
                            <input class="DH_Ma" id="DH_Ma" name="DH_Ma" value="<%=Item._DatHang.Ma %>" data-id="<%=Item.DH_ID %>" type="text"/>
                            <input class="DH_ID" style="display: none;" id="DH_ID" name="DH_ID" value="<%=Item.DH_ID %>" type="text"/>
                             <%if (Item.DH_ID!= Guid.Empty)
                              {%>
                                    <a class="btn" href="/lib/pages/DatHang/Edit.aspx?id=<%=Item.DH_ID %>">
                                        <i class="icon icon-link"></i>
                                    </a>
                            <% } %>
                        <p class="help-block">
                            </p>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="KH_Mobile">Mobile</label>
                        <div class="controls">
                        <input class="KH_Mobile" id="KH_Mobile" value="<%=Item._DatHang.KH_Mobile %>" name="KH_Mobile" type="text"/>
                        <p class="help-block">Mobile khách hàng
                            </p>
                        </div>
                    </div>
                    
                     <div class="control-group">
                        <label class="control-label" for="NgayGiao">Ngày giao</label>
                        <div class="controls">
                            <div id="NgayDatPicker" class="input-append date NgayDatPicker">
                                <input 
                                    data-format="hh:mm dd/MM/yyyy" 
                                    value="<%=Item.NgayGiao ==DateTime.MinValue? string.Empty :  Item.NgayGiao.ToString("hh:mm dd/MM/yyyy") %>" 
                                    class="NgayGiao" 
                                    id="NgayGiao" 
                                    name="NgayGiao" 
                                    type="text"/>
                                <span class="add-on">
                                  <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                                  </i>
                                </span>
                            </div>
                        <p class="help-block">Ngày giao
                            </p>
                        </div>
                    </div>

                    <!-- Textarea -->
                    <div class="control-group">
                        <label class="control-label" for="DiaChi">Địa chỉ</label>
                        <div class="controls">                     
                        <textarea id="DiaChi" class="input-large DiaChi" name="DiaChi"><%=Item.DiaChi %></textarea>
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
        <a href="/lib/pages/Ship/In.aspx?id=<%=Item.ID %>" target="_blank" class="btn btn-success btn-large inDonShipBtn">In đơn ship</a>
        <a href="javascript:;" class="btn btn-warning btn-large xoaBtn">Xóa</a>
        <%}
          else
          {%>
            <a href="javascript:;" class="btn btn-primary btn-large savebtn">Lưu</a>
          <%} %>
</div>