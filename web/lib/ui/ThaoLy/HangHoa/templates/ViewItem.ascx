<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewItem.ascx.cs" Inherits="lib_ui_ThaoLy_HangHoa_templates_ViewItem" %>
<%@ Import Namespace="linh.common" %>
<%@ Register src="DanhSachAnh.ascx" tagname="DanhSachAnh" tagprefix="uc1" %>
<div class="KhachHangHeader ModuleHeader well">
    <a href="Default.aspx" class="btn btn-primary backbtn">
        <i class="icon icon-back"></i> Quay lại
    </a>
</div>
<div class="KhachHangForm" >
    <div class="form-horizontal">
        <fieldset>
                    <!-- Text input-->
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Ten">Mã</label>
                        <div class="controls">
                        <%=Item.Ma %>
                        </div>
                    </div>

        

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">Tên</label>
                        <div class="controls">
                        <%=Item.Ten %>
                        </div>
                    </div>            

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">
                            Giá
                        </label>
                        <div class="controls">
                            <%=Lib.TienVietNam(Item.GNY) %>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label" for="Mobile">
                            Số lượng
                        </label>
                        <div class="controls">
                            <%=Item.SoLuong %>
                        </div>
                    </div>
                <uc1:DanhSachAnh ID="DanhSachAnh1" runat="server" />
        <div class="alert alert-success">
            Thêm thành công
        </div>
        <div class="alert alert-error">
            Bạn cần nhập Tên, Email, và Mobile<br/>                        
        </div>
        </fieldset>
        </div>
        <hr/>
        <a href="/lib/pages/DatHang/Edit.aspx" class="btn btn-primary">Tạo đơn hàng</a>
</div>