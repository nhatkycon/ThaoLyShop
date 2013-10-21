$(function () {
    cart.setup();
    cart.YeuThichFn();
});
var cart = {
    url: domain + '/lib/ajax/datHang/Default.aspx',
    urlBl: domain + '/lib/ajax/comment/Default.aspx',
    setup: function () {
        $('.buybtn, .btn_checkout').click(function () {
            var item = $(this);
            var _id = item.attr('data-id');
            var lbl = item.attr('data-label');
            var soluong = item.attr('data-amout');
            if (soluong == '0') {
                alert('You cannot order this item\nOut of stock!');
                return;
            }

            item.html('&nbsp;&nbsp;Processing...');
            item.addClass('btn-loading');
            //var pItem = $('.galery');
            //pItem.effect('transfer', { to: '.shopcart', className: 'ui-effects-transfer' }, 500, function() {
            //});
            $.ajax({
                url: cart.url,
                dataType: 'SCRIPT',
                type: 'POST',
                data: { 'ref': Math.random(), 'act': 'add', 'ID': _id },
                success: function (_dt) {
                    item.html(lbl);
                    cart.get(function () {
                        item.removeClass('btn-loading');
                    });
                }
            });
        });
        //cart.getBl();



        var cart_box = $('.cart-box');
        var cartbody = $('.cart-body');
        if ($(cartbody).length == 0)
            return;
        cart.get();

        var checkoutBtn = cartbody.find('.checkoutBtn');
        checkoutBtn.click(function () {
            var car_info = cartbody.find('.cart-info');
            var cart_task = cartbody.find('.cart-task');
            cart_task.hide(200);
            car_info.show(200);
            var cart_send = car_info.find('.cart-send');
            var b = car_info.find('table');
            cart_send.click(function () {
                var item = $(this);
                var Ten = b.find('.Ten');
                var Email = b.find('.Email');
                var Mobile = b.find('.Mobile');
                var DiaChi = b.find('.DiaChi');
                var GhiChu = b.find('.GhiChu');
                var _Ten = Ten.val();
                var _Email = Email.val();
                var _Mobile = Mobile.val();
                var _DiaChi = DiaChi.val();
                var _GhiChu = GhiChu.val();
                var err = '';
                if (_Ten == '') err += 'Nhập tên\n';
                if (_Mobile == '') err += 'Nhập điện thoại\n';
                if (_DiaChi == '') err += 'Nhập địa chỉ\n';
                if (err != '') {
                    alert('Lỗi\n' + err + '\nBạn vui lòng hoàn thành nhé :P');
                    return false;
                }
                item.html('&nbsp;&nbsp;Đang xử lý...');
                item.addClass('btn-loading');
                $.ajax({
                    url: cart.url,
                    dataType: 'SCRIPT',
                    type: 'POST',
                    data: {
                        'ref': Math.random(),
                        'act': 'save',
                        'Ten': _Ten,
                        'Email': _Email,
                        'Mobile': _Mobile,
                        'DiaChi': _DiaChi,
                        'GhiChu': _GhiChu
                    },
                    success: function (_dt) {
                        var dt = eval(_dt);

                        item.html('sending...');
                        item.removeClass('btn-loading');
                        $('.cart-tong').hide();
                        var cart_payment = $('.cart-payment');
                        car_info.hide();
                        var tygia = cart_payment.attr('data-tygia');
                        cart_payment.show();
                        cart_box.hide();
                        cart_payment.find('[name="amount"]').val(parseInt(Math.round(dt.GiaTri) / parseInt(tygia)) + '.00');
                        cart_payment.find('[name="return"]').val('http://leenaa.co.kr/lib/thank.aspx?ID=' + dt.ID);
                        $('form').unbind('submit')
                        //alert('cám ơn bạn đã đặt hàng, chúng tôi sẽ gọi lại cho bạn ngay lập tức');
                        //cart_box.html('');
                        //b.find('input, textarea').val('');
                        //b.removeClass('cart-info-active');
                        //$(document).trigger('close.facebox', 'thanh-toan');
                    }
                });
            });
        });
    },
    getBl: function () {
        $.ajax({
            url: cart.urlBl,
            dataType: 'SCRIPT',
            type: 'POST',
            data: { 'ref': Math.random(), 'act': 'get' },
            success: function (_dt) {
                $('.bl-box').html(_dt);
            }
        });
    },
    get: function (fn) {
        var cart_box = $('.cart-box');
        //cart_box.html('&nbsp;&nbsp;Đang cập nhật...');
        cart_box.addClass('btn-loading');
        var num = $('.shopcart').find('.num');
        num.html('..');
        $.ajax({
            url: cart.url,
            dataType: 'SCRIPT',
            type: 'POST',
            data: { 'ref': Math.random(), 'act': 'get' },
            success: function (_dt) {
                var dt = eval(_dt);
                // Leenaa
                num.html('( ' + dt.TotalItem + ' )');
                cart_box.removeClass('btn-loading');
                cart.xuLyGet(dt, function () {
                    if (typeof (fn) == 'function') { fn(); }
                });
            }
        });
    },
    xuLyGet: function (_dt, fn) {
        var dt = eval(_dt);
        var cart_body = $('.cart-body');
        if ($(cart_body).length < 1)
            return;
        var cart_tong = cart_body.find('.cart-tong');
        //        if (dt.Total < 80) {
        //            if (dt.Total == '0') {
        //                cart_body.find('.cart-ship').removeClass('cart-ship-active');
        //                cart_tong.hide();
        //            }
        //            else {
        //                cart_body.find('.cart-ship').addClass('cart-ship-active');
        //                cart_tong.show();
        //            }
        //        }
        //        else {
        //            cart_body.find('.cart-ship').removeClass('cart-ship-active');
        //            cart_tong.show();
        //        }
        if (dt.Total == '0') {
            cart_body.find('.cart-ship').removeClass('cart-ship-active');
            cart_tong.hide();
        }
        else {
            cart_body.find('.cart-ship').addClass('cart-ship-active');
            cart_tong.show();
        }
        cart_body.find('.cart-tong-label').html(formatMoney(dt.Total + dt.ShipCost) + ' won');
        var l = '';
        var cart_box = cart_body.find('.cart-box');
        cart_box.html('');
        $.each(dt.List, function (i, v) {
            var vItem = $(v);
            //var nItem = $('#cart-item').tmpl(vItem).prependTo(cart_box);
            l = $('#cart-item').tmpl(vItem).html();
            var nItem = $(l).appendTo(cart_box);
            nItem.find('a').attr('_id', i);
            nItem.find('.cart-item-gia').html(formatMoney(v.Gia * v.SoLuong) + ' won');
            nItem.find('.cart-item-soLuong').val(v.SoLuong);
            nItem.find('.cart-item-img').attr('src', domain + '/lib/up/i/' + v.Img);
            nItem.find('.cart-item-ten').html(v.Ten);
            nItem.find('.cart-item-ten').attr('href', '/Products/Caterogy/' + v.Ten + '/' + i + '.html');
            nItem.find('a.cart-item-xoa').click(function () {
                var aItem = $(this);
                var con = confirm(aItem.attr('data-msg'));
                if (con) {
                    $.ajax({
                        url: cart.url,
                        dataType: 'SCRIPT',
                        type: 'POST',
                        data: { 'ref': Math.random(), 'act': 'del', 'ID': aItem.attr('_id') },
                        success: function (_dt) {
                            cart.xuLyGet(_dt);
                        }
                    });
                }
            });

            nItem.find('select').change(function () {
                var sItem = $(this);
                var _v = sItem.val();
                var _vRef = _v;
                if (_v == '0') {
                    var p = prompt(sItem.attr('data-msg'));
                    if (p) {
                        if (cart.isInt(p)) {
                            nItem.find('option[selected="selected"]').removeAttr('selected');
                            $('<option value="' + p + '" selected="selected">' + p + '</option>').insertBefore(nItem.find('option:last'));
                            _v = p;
                        }
                        else {
                            alert('Amount should be in number ^_^');
                        }
                    }
                }
                if (cart.isInt(v)) {
                    if (parseInt(_v) > 0) {
                        $.ajax({
                            url: cart.url,
                            dataType: 'SCRIPT',
                            type: 'POST',
                            data: { 'ref': Math.random(), 'act': 'UpSl', 'ID': sItem.parent().find('.cart-item-xoa').attr('_id'), 'SoLuong': _v },
                            success: function (_dt) {
                                cart.xuLyGet(_dt);
                            }
                        });
                    }
                }
            });
        });
        if (typeof (fn) == 'function') { fn(); }
    },
    buildSoLuong: function (SoLuong) {
        var l = '';
        l += '<select _value="' + SoLuong + '" class="cart-item-soLuong">';
        for (i = 1; i < 10; i++) {
            l += '<option value="' + i + '" ' + (i == SoLuong ? ' selected="selected"' : '') + '>' + i + '</option>';
        }
        if (SoLuong > 10) {
            l += '<option value="' + SoLuong + '" selected="selected">' + SoLuong + '</option>';
        }
        l += '<option value="0">Số khác</option>';
        l += '</select>';
        return l;
    },
    YeuThichFn: function () {
        $('.btn_like').click(function () {
            var item = $(this);
            var _id = item.attr('data-id');
            var lbl = item.attr('data-label');
            $.ajax({
                url: cart.url,
                dataType: 'SCRIPT',
                type: 'POST',
                data: { 'ref': Math.random(), 'act': 'addWishList', 'ID': _id },
                success: function (_dt) {
                    item.html(lbl);
                }
            });
        });
        $('.btn_unlike').click(function () {
            var item = $(this);
            var _id = item.attr('data-id');
            var lbl = item.attr('data-label');
            $.ajax({
                url: cart.url,
                dataType: 'SCRIPT',
                type: 'POST',
                data: { 'ref': Math.random(), 'act': 'delWishList', 'ID': _id },
                success: function (_dt) {
                    item.html(lbl);
                    item.parent().parent().remove();
                }
            });
        });
    }
    ,
    isInt: function (s) {
        var isInteger = function (s) {
            var i;
            if (isEmpty(s))
                if (isInteger.arguments.length == 1) return false;
                else return (isInteger.arguments[1] == true);

            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);

                if (!isDigit(c)) return false;
            }

            function isEmpty(s) {
                return ((s == null) || (s.length == 0))
            }

            function isDigit(c) {
                return ((c >= "0") && (c <= "9"))
            }
            return true;
        }
        return isInteger(s);
    }
}