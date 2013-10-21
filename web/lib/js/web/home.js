jQuery(function() {
    thaoLyFn.setup();
});

var thaoLyFn= {
    setup:function () {
        thaoLyFn.KhachHangThemFn();
        thaoLyFn.KhachHangHeaderFn();
        
        thaoLyFn.DatHangThemFn();
        thaoLyFn.ShipThemFn();
    }
    , url: domain + '/lib/ajax/KhachHang/Default.aspx'
    , KhachHangHeaderFn:function () {
        var pnl = $('.KhachHangHeader');
        
        if ($(pnl).length < 1) return;

        var txt = pnl.find('.KhachHangHeaderSearchText');
        var NguonGoc_Id = pnl.find('.NguonGoc_Id');
        var KhuVuc_Id = pnl.find('.KhuVuc_Id');
        var searchBtn = pnl.find('.KhachHangSearchBtn');

        searchBtn.click(function() {
            var data = pnl.find(':input').serialize();
            document.location.href = '?' + data;
        });

    }
    , KhachHangThemFn:function () {
        var pnl = $('.KhachHangForm');
        var savebtn = pnl.find('.savebtn');

        var NgayGiao = pnl.find('#NgayGiaoPicker');
        var NgayGiaoYeuCau = pnl.find('#NgayGiaoYeuCauPicker');
        var NgayDatPicker = pnl.find('#NgayDatPicker');

        NgayGiao.datetimepicker({
            language: 'vi-Vn'
        });
        NgayGiaoYeuCau.datetimepicker({
            language: 'vi-Vn'
        });
        NgayDatPicker.datetimepicker({
            language: 'vi-Vn'
        });
        savebtn.click(function() {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'add' });
            $.ajax({
                url: thaoLyFn.url
                , data: data
                , success:function (dt) {
                    alert('Lưu thành công');
                }
            });
        });
        

        var xoaBtn = pnl.find('.xoaBtn');
        xoaBtn.click(function () {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'xoa' });
            $.ajax({
                url: thaoLyFn.url
                , data: data
                , success: function (dt) {
                    document.location.href = 'Default.aspx';
                }
            });
        });

        var saveAndShipBtn = pnl.find('.saveAndShipBtn');
        saveAndShipBtn.click(function () {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'addAndShip' });
            $.ajax({
                url: thaoLyFn.url
                , data: data
                , success: function (dt) {
                    document.location.href = '../DatHang/Edit.aspx?id=' + dt;
                }
            });
        });
    }
    , KhachHangSaveFn: function () {

    }
    , urlDatHang: domain + '/lib/ajax/DatHang1/Default.aspx'
    , DatHangThemFn: function () {
        var pnl = $('.DatHangForm');
        if ($(pnl).length < 1) return;

        var savebtn = pnl.find('.savebtn');
        var KH_ID = pnl.find('.KH_ID');
        var KH_Ten = pnl.find('.KH_Ten');
        var KH_Mobile = pnl.find('.KH_Mobile');
        var KH_DiaChi = pnl.find('.KH_DiaChi');

        var btnThemNhanhKH = pnl.find('.btnThemNhanhKH');
        var NgayGiao = pnl.find('#NgayGiaoPicker');
        var NgayGiaoYeuCau = pnl.find('#NgayGiaoYeuCauPicker');
        var NgayDatPicker = pnl.find('#NgayDatPicker');
        
        NgayGiao.datetimepicker({
            language: 'vi-Vn'
        });
        NgayGiaoYeuCau.datetimepicker({
            language: 'vi-Vn'
        });
        NgayDatPicker.datetimepicker({
            language: 'vi-Vn'
        });


        adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(KH_Ten, function (event, ui) {
                KH_Ten.attr('data-id', ui.item.id);
                KH_ID.val(ui.item.id);
                KH_Mobile.val(ui.item.Mobile);
                KH_DiaChi.val(ui.item.DiaChi);
            });
            KH_Ten.unbind('click').click(function () {
                KH_Ten.autocomplete('search', '');
            });
            btnThemNhanhKH.unbind('click').click(function () {
                DanhSachKhachHangFn.add(function (_ID, _Ten) {
                    
                }, function (dt1, _Ten, _Mobile, _DiaChi) {
                    KH_Ten.attr('data-id', dt1);
                    KH_Ten.val(_Ten);
                    KH_ID.val(dt1);
                    KH_Mobile.val(ui.item.Mobile);
                    KH_DiaChi.val(_DiaChi);
                });
            });
        });
        

        var xoaBtn = pnl.find('.xoaBtn');
        xoaBtn.click(function () {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'xoa' });
            $.ajax({
                url: thaoLyFn.urlDatHang
                , data: data
                , success: function (dt) {
                    document.location.href = 'Default.aspx';
                }
            });
        });

        savebtn.click(function () {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'add' });
            $.ajax({
                url: thaoLyFn.urlDatHang
                , data: data
                , success: function (dt) {
                    alert('Lưu thành công');
                }
            });
        });


        var ThemHangBox = $('.ThemHangBox');
        if ($(ThemHangBox).length < 1) return;

        adm.regType(typeof (quanLyXuatNhapFn), 'appStore.commonStore.xuatNhapMgr.quanLyXuatNhap.Class1, appStore.commonStore.xuatNhapMgr', function () {
        });

        var DatHangChiTietBox = $('.DatHangChiTietBox');

        var themHangBtn = ThemHangBox.find('.themHangBtn');
        var HH_ID = ThemHangBox.find('.HH_ID');
        var HH_Ten = ThemHangBox.find('.HH_Ten');
        var HH_Ma = ThemHangBox.find('.HH_Ma');
        var HH_Gia = ThemHangBox.find('.HH_Gia');
        var HH_SoLuong = ThemHangBox.find('.HH_SoLuong');
        adm.regType(typeof (hangHoaMgrFn), 'appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr', function () {
            hangHoaMgrFn.autoCompleteByQ(HH_Ma, function (event, ui) {
                HH_Ten.val(ui.item.value);
                HH_ID.val(ui.item.id);
                HH_Ma.val(ui.item.ma);
                HH_Gia.val(ui.item.gia);
            });
            HH_Ma.unbind('click').click(function () {
                HH_Ma.autocomplete('search', '');
            });
        });
        
        themHangBtn.click(function () {
            var data = ThemHangBox.find(':input').serializeArray();
            data.push({ name: 'act', value: 'addHang' });
            $.ajax({
                url: thaoLyFn.urlDatHang
                , data: data
                , success: function (dt) {
                    var itemEl = $(dt).insertAfter(ThemHangBox);

                    HH_ID.val('');
                    HH_Ten.val('');
                    HH_Ma.val('');
                    HH_Gia.val('');
                    HH_SoLuong.val('');
                    
                    itemEl.addClass('animated bounceInDown');
                    setTimeout(function () {
                        itemEl.removeClass('animated bounceInDown');
                    }, 1000);
                }
            });
        });        

        DatHangChiTietBox.on('click', '.xoaHangBtn', function () {
            var item = $(this);
            var con = confirm('Bạn có muốn xóa bỏ không? Nghiêm túc đó!!!');
            if (con) {
                $.ajax({
                    url: thaoLyFn.urlDatHang,
                    data: {
                        act: 'removeHang',
                        ID: item.attr('data-id')
                    },
                    success: function (dt) {
                        var pitem = item.parent().parent();
                        pitem.addClass('animated bounceOutRight');
                        setTimeout(function () {
                            pitem.remove();
                        }, 500);
                    }
                });
            }
        });


        var themHoaDonBtn = $('.themHoaDonBtn');
        themHoaDonBtn.click(function () {
            var item = $(this);
            adm.regType(typeof (quanLyXuatNhapFn), 'appStore.commonStore.xuatNhapMgr.quanLyXuatNhap.Class1, appStore.commonStore.xuatNhapMgr', function () {
                quanLyXuatNhapFn.add(null, function (dt) {
                    document.location.reload();
                }, { TV_ID: item.attr('data-id') }, function (newDlg) {
                    adm.styleButton();
                });
            });
        });

    }
    , DatHangList: function (el, fn, fn1) {
        if (typeof (fn1) != "function") {
                fn1 = function(ul, item) {
                    return $("<li></li>")
                        .data("item.autocomplete", item)
                        .append("<a href=\"javascript:;\">" + item.label + "</a>")
                        .appendTo(ul);
                };
            }
            $(el).autocomplete({
                source: function (request, response) {
                    var term = 'DatHangList-autoCompleteSearch' + request.term;
                    adm.loading('Nạp danh sách');
                    _lastXhr = $.ajax({
                        url: thaoLyFn.urlDatHang,
                        dataType: 'script',
                        data: { 'act': 'search', 'q': request.term },
                        success: function (dt, status, xhr) {
                            adm.loading(null);
                            var data = eval(dt);
                            _cache[term] = data;
                            if (xhr === _lastXhr) {
                                var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                                response($.map(data, function(item) {
                                    if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Email.toLowerCase())) || matcher.test(item.Mobile.toLowerCase()) || matcher.test(adm.normalizeStr(item.Phone.toLowerCase()))) {
                                        return {
                                            label: item.Ma,
                                            value: item.Ma,
                                            id: item.ID,
                                            ma: item.Ma,
                                            KH_Ten: item.KH_Ten,
                                            KH_Mobile: item.KH_Mobile,
                                            KH_DiaChi: item.KH_DiaChi,
                                            NgayGiaoYeuCau: item.NgayGiaoYeuCau
                                        };
                                    }
                                }));
                            }
                        }
                    });
                },
                minLength: 0,
                select: function (event, ui) {
                    fn(event, ui);
                },
                change: function (event, ui) {
                    if (!ui.item) {
                        if ($(this).val() == '') {
                            $(this).attr('_value', '');
                        }
                    }
                },
                delay: 0,
                selectFirst: true
            }).data("autocomplete")._renderItem = fn1;
    }
    , urlShip: domain + '/lib/ajax/Ship/Default.aspx'
    , ShipThemFn:function() {
        var pnl = $('.ShipForm');
        if ($(pnl).length < 1) return;
        
        var savebtn = pnl.find('.savebtn');
        
        var DH_ID = pnl.find('.DH_ID');
        var DH_Ma = pnl.find('.DH_Ma');
        var KH_Mobile = pnl.find('.KH_Mobile');
        var DiaChi = pnl.find('.DiaChi');
        
        var NhanVien_Ten = pnl.find('.NhanVien_Ten');
        var NhanVien = pnl.find('.NhanVien');
        
        var NgayDatPicker = pnl.find('.NgayDatPicker');
        NgayDatPicker.datetimepicker({
            language: 'vi-Vn'
        });
        
        thaoLyFn.DatHangList(DH_Ma, function (event, ui) {
            DH_Ma.attr('data-id', ui.item.id);
            DH_ID.val(ui.item.id);
            KH_Mobile.val(ui.item.KH_Mobile);
            DiaChi.val(ui.item.KH_DiaChi);
        });
        DH_Ma.unbind('click').click(function () {
            DH_Ma.autocomplete('search', '');
        });

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NhanVien_Ten, function (event, ui) {
                NhanVien_Ten.val(ui.item.label);
                NhanVien.val(ui.item.value);
            });
            NhanVien_Ten.unbind('click').click(function () {
                NhanVien_Ten.autocomplete('search', '');
            });
        });


        var xoaBtn = pnl.find('.xoaBtn');
        xoaBtn.click(function () {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'xoa' });
            $.ajax({
                url: thaoLyFn.urlShip
                , data: data
                , success: function (dt) {
                    document.location.href = 'Default.aspx';
                }
            });
        });

        savebtn.click(function () {
            var data = pnl.find(':input').serializeArray();
            data.push({ name: 'act', value: 'add' });
            $.ajax({
                url: thaoLyFn.urlShip
                , data: data
                , success: function (dt) {
                    alert('Lưu thành công');
                    document.location.href = 'Edit.aspx?id=' + dt;
                }
            });
        });
    }
}