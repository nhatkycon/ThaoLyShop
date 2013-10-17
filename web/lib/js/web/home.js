jQuery(function () {
    var slideShowTimer;
    var slideShowInterval = 2000;
    var slideShowInt = 0;
    leenaFn.register();
    leenaFn.updateAccount();
    leenaFn.showRecover();
    leenaFn.changePass();
    leenaFn.postQa();
    leenaFn.postPhotoreview();
    leenaFn.postReturning();
    var loginPnl = $('#login');
    if ($(loginPnl).length > 0) {
        var btn = $(loginPnl).find('.button');
        var u = $(loginPnl).find('[type="text"]');
        var p = $(loginPnl).find('[type="password"]');
        var r = $(loginPnl).find('[type="checkbox"]');
        btn.click(function () {
            var _u = u.val();
            var _p = p.val();
            if (_u == '' || _p == '') {
                alert(loginPnl.attr("data-validatorMsg"));
                return;
            }
            var _r = r.is(':checked');
            adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': _u, 'p': _p, 'r': _r }, function (data) {
                if (data == '0') {
                    alert(loginPnl.attr("data-erorMsg"));
                }
                else {
                    document.location.reload();
                }
            });
        });

        $(p).keypress(function (e) {
            if (e.which == 13) {
                var _u = u.val();
                var _p = p.val();
                if (_u == '' || _p == '') {
                    alert(loginPnl.attr("data-validatorMsg"));
                    return;
                }
                var _r = r.is(':checked');
                adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': _u, 'p': _p, 'r': _r }, function (data) {
                    if (data == '0') {
                        alert(loginPnl.attr("data-erorMsg"));
                    }
                    else {
                        document.location.reload();
                    }
                });
            }
        });

        $(u).keypress(function (e) {
            if (e.which == 13) {
                var _u = u.val();
                var _p = p.val();
                if (_u == '' || _p == '') {
                    alert(loginPnl.attr("data-validatorMsg"));
                    return;
                }
                var _r = r.is(':checked');
                adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': _u, 'p': _p, 'r': _r }, function (data) {
                    if (data == '0') {
                        alert(loginPnl.attr("data-erorMsg"));
                    }
                    else {
                        document.location.reload();
                    }
                });
            }
        });

    }

    var frmSearch = $('#frmSearch');
    if ($(frmSearch).length > 0) {
        var txt = frmSearch.find('.textbox');
        var btn = frmSearch.find('.btn_search');
        btn.click(function () {
            document.location.href = domain + '/Tim/' + txt.val();
        });

        $(txt).keypress(function (e) {
            if (e.which == 13) {
                document.location.href = domain + '/Tim/' + txt.val();
            }
        });
    }

    var sort = $('.sort');
    if ($(sort).length > 0) {
        sort.change(function () {
            var cUrl = sort.attr('data-curl');
            document.location.href = cUrl + sort.val() + '/';
        });
    }

    $('.log-out').click(function () {
        adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subact': 'logout' }, function (data) {
            var l = document.location.href;
            if (l.indexOf('#').length != -1) {
                l = l.substr(0, l.indexOf('#'));
            }
            //document.location.href = l;
            document.location.reload();
        });
    });

    jQuery.each(jQuery('.slides-ten-item'), function (i, _item) {
        var item = jQuery(_item);
        item.mouseenter(function () {
            var item = jQuery(_item);
            var _ref = item.attr('ref');
            var p = item.parent();
            if (item.hasClass('slides-ten-item-focus')) return false;
            p.find('.slides-ten-item-focus').removeClass('slides-ten-item-focus');
            item.addClass('slides-ten-item-focus');
            p.prev().find('.slides-panel-item-focus').removeClass('slides-panel-item-focus');
            p.prev().find('.slides-panel-item[ref=\'' + _ref + '\']').addClass('slides-panel-item-focus');
            slideShowInt = 0;
            if (slideShowTimer) { clearTimeout(slideShowTimer); }
            slideShowTimer = setTimeout(function () {
                playSlidesShow();
            }, slideShowInterval);
        });
    });

    //menufn();
    jQuery(window).scroll(function () {
        //menufn();
    });

    function playSlidesShow() {
        if (slideShowTimer) { clearTimeout(slideShowTimer); }
        if (slideShowInt < 4) { slideShowInt++; }
        else { slideShowInt = 0; }
        slideShowTimer = setTimeout(function () {
            playSelectedShow(slideShowInt);
        }, slideShowInterval);
        //        console.log(slideShowTimer);
        //        console.log(slideShowInt);
    }
    function playSelectedShow(i) {
        var item = jQuery('.slides-ten-item').eq(i);
        var _ref = item.attr('ref');
        var p = item.parent();
        if (item.hasClass('slides-ten-item-focus')) return false;
        p.find('.slides-ten-item-focus').removeClass('slides-ten-item-focus');
        item.addClass('slides-ten-item-focus');
        p.prev().find('.slides-panel-item-focus').removeClass('slides-panel-item-focus');
        p.prev().find('.slides-panel-item[ref=\'' + _ref + '\']').addClass('slides-panel-item-focus');
        if (slideShowTimer) { clearTimeout(slideShowTimer); }
        slideShowTimer = setTimeout(function () {
            playSlidesShow();
        }, slideShowInterval);
    }
    playSlidesShow();

    function getEl(el, fn) {
        var _offset = jQuery(el).offset();
        var _t = _offset.top;
        var _l = _offset.left;
        var _w = el.width();
        var _h = el.height();
        var _pt = parseInt(el.css('padding-top').toString().toLowerCase().replace('px', ''));
        var _pb = parseInt(el.css('padding-bottom').toString().toLowerCase().replace('px', ''));
        var _mt = parseInt(el.css('margin-top').toString().toLowerCase().replace('px', ''));
        var _mb = parseInt(el.css('margin-bottom').toString().toLowerCase().replace('px', ''));
        var _bb = parseInt(el.css('border-bottom-width').toString().toLowerCase().replace('px', ''));
        var _bt = parseInt(el.css('border-top-width').toString().toLowerCase().replace('px', ''));
        var _t1 = 0;
        _t1 = _t + _h + ((_pt == NaN) ? _pt : 0) + ((_pb == NaN) ? _pb : 0) + ((_mt == NaN) ? _mt : 0) + ((_mb == NaN) ? _mb : 0) + ((_bb == NaN) ? _bb : 0) + ((_bt == NaN) ? _bt : 0);
        if (typeof (fn) == 'function') { fn(_t, _l, _w, _t1); }
    }
    var txtSearch = jQuery('.top-search-txt');
    txtSearch.focus(function () {
        var item = jQuery('.top-search-box');
        item.addClass('top-search-box-focus');
        txtSearch.blur(function () {
            item.removeClass('top-search-box-focus');
        });
    });

    var searchBtn = jQuery('.top-search-btn');
    searchBtn.click(function () {
        var searchTxt = jQuery('.top-search-txt');
        var _txt = searchTxt.val();
        var searchSlt = jQuery('.top-search-slt');
        var __domain = jQuery(searchBtn).attr('_domain');
        document.location.href = __domain + '/lib/pages/Tim_kiem.aspx?q=' + _txt + '&type=' + searchSlt.val();
    });

    var searchTxt = jQuery('.top-search-txt');
    searchTxt.focus(function () {
        searchTxt.unbind('keypress').bind('keypress', function (evt) {
            if (evt.keyCode == 13) {
                var _txt = searchTxt.val();
                if (_txt == '') { alert('Vui lòng nhập từ khóa để tìm kiếm'); searchTxt.focus(); return false; }
                var searchSlt = jQuery('.top-search-slt');
                var __domain = jQuery(searchBtn).attr('_domain');
                document.location.href = __domain + '/lib/pages/Tim_kiem.aspx?q=' + _txt + '&type=' + searchSlt.val();
            }
        });
    });
    var searchRsPnl = jQuery('.search-leftPnl');
    if (jQuery(searchRsPnl).length > 0) {
        jQuery.each(searchRsPnl.find('.search-sType-item'), function (i, _item) {
            var item = jQuery(_item);
            item.click(function () {
                var _ref = item.attr('_ref');
                var p = item.parent();
                if (item.hasClass('search-sType-item-active')) return false;
                p.find('.search-sType-item-active').removeClass('search-sType-item-active');
                item.addClass('search-sType-item-active');
                p.next().find('.search-rsPnl-focus').removeClass('search-rsPnl-focus');
                p.next().find('.search-rsPnl[_ref=\'' + _ref + '\']').addClass('search-rsPnl-focus');
            });
        });
    }
    jQuery('form').submit(function () {
        return false;
    });
});

var leenaFn = {
    postQa: function () {
        var post_question = $('.post_question');
        if ($(post_question).length < 1)
            return;
        var Loai = post_question.find('select');
        var CauHoi = post_question.find('input');
        var NoiDung = post_question.find('textarea');
        var btn = post_question.find('.main_btn');

        var url = '.plugin?ref=' + Math.random() + '&act=loadPlug&rqPlug=appStore.leena.QaMgr.Class1, appStore.leena.QaMgr';
        btn.click(function () {
            var _CauHoi = CauHoi.val();
            var _NoiDung = NoiDung.val();
            if (_CauHoi == '' || _NoiDung == '') {
                alert('Type your question');
            }
            _CauHoi = Loai.val() + ': ' + _CauHoi + ' ' + _NoiDung;
            $.ajax({
                url: url,
                data: {
                    subAct: 'post'
                    , CauHoi: _CauHoi
                }
                , success: function (_dt) {
                    if (_dt == '1') {
                        alert('We got your question, we will answer as soon as posible');
                        CauHoi.val('');
                        NoiDung.val('');
                    } else {
                        alert('Something went wrong, please re-try later');
                    }
                }

            });
        });
    }
    ,
    postPhotoreview: function () {
        var box = $('.post-photo-review');
        if ($(box).length < 1)
            return;
        var Ten = box.find('.Ten');
        var input_file = box.find('.input_file');
        var NoiDung = box.find('.NoiDung');
        var btn = box.find('.main_btn');
        var img = box.find('.product_img').find('img');
        var imgBox = box.find('.product_img');

        var url = domain + '/lib/ajax/photoreview/Default.aspx';
        img.show();
        imgBox.show();
        adm.upload(input_file, 'anh', null, function (i) {
            input_file.attr('data-url', i);
            img.attr('src', '/lib/up/i/' + common.imgSize(i, '326'));
        });
        btn.click(function () {
            var _Ten = Ten.val();
            var _NoiDung = NoiDung.val();
            var _Anh = input_file.attr('data-url');
            if (_Ten == '' || _NoiDung == '') {
                alert('Type your content');
            }

            $.ajax({
                url: url,
                type: 'POST',
                data: {
                    act: 'add'
                    , Ten: _Ten
                    , NoiDung: _NoiDung
                    , Loai: 1
                    , Anh: _Anh
                }
                , success: function (_dt) {
                    if (_dt == '1') {
                        Ten.val();
                        NoiDung.val('');
                        input_file.attr('data-url', '');
                        img.attr('src', '');
                        alert('Thank you for your posting! We need to review before show it in list below');
                        document.location.reload();
                    } else {
                    }
                }

            });
        });
    }
    ,
    postReturning: function () {
        var box = $('.post-returning-review');
        if ($(box).length < 1)
            return;
        var askReturning = box.find('.askReturning');
        askReturning.click(function () {
            box.find('form').show();
        });
        var Ten = box.find('.Ten');
        var input_file = box.find('.input_file');
        var NoiDung = box.find('.NoiDung');
        var btn = box.find('.saveBtn');
        var img = box.find('.product_img').find('img');
        var imgBox = box.find('.product_img');

        var url = domain + '/lib/ajax/photoreview/Default.aspx';
        img.show();
        imgBox.show();
        adm.upload(input_file, 'anh', null, function (i) {
            input_file.attr('data-url', i);
            img.attr('src', '/lib/up/i/' + common.imgSize(i, '326'));
        });
        btn.click(function () {
            var _Ten = Ten.val();
            var _NoiDung = NoiDung.val();
            var _Anh = input_file.attr('data-url');
            if (_Ten == '' || _NoiDung == '') {
                alert('Type your content');
            }

            $.ajax({
                url: url,
                type: 'POST',
                data: {
                    act: 'add'
                    , Ten: _Ten
                    , NoiDung: _NoiDung
                    , Loai: 2
                    , Anh: _Anh
                }
                , success: function (_dt) {
                    if (_dt == '1') {
                        Ten.val();
                        NoiDung.val('');
                        input_file.attr('data-url', '');
                        img.attr('src', '');
                        alert('Thank you for your claim! We will reply your request ask soon as possible');
                        document.location.reload();
                    } else {
                    }
                }

            });
        });
    }
    ,
    changePass: function () {
        var changePassBox = $('.changePassBox');
        if ($(changePassBox).length < 1)
            return;
        var changePassBtn = $('.changePassBtn');
        var OldPass = changePassBox.find('.OldPass');
        var NewPass = changePassBox.find('.NewPass');
        var SavePass = changePassBox.find('.SavePass');
        var UndoPass = changePassBox.find('.UndoPass');
        var error = changePassBox.find('.error');
        var success = changePassBox.find('.success');
        changePassBtn.click(function () {
            changePassBox.show();
        });
        UndoPass.click(function () {
            changePassBox.hide();
        });

        var url = '.plugin?ref=' + Math.random() + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien';
        SavePass.click(function () {
            error.hide();
            var _OldPass = OldPass.val();
            var _NewPass = NewPass.val();
            if (_OldPass == '' || _NewPass == '') {
                success.hide();
                error.show();
            }
            $.ajax({
                url: url,
                data: {
                    subAct: 'changePass'
                    , OldPass: _OldPass
                    , NewPass: _NewPass
                }
                , success: function (_dt) {
                    if (_dt == '1') {
                        error.hide();
                        success.show();
                        setTimeout(function () {
                            changePassBox.hide();
                        }, 1000);
                    } else {
                        success.hide();
                        error.show();
                    }
                }

            });
        });
    }
    , showRecover: function () {
        var recoverPnl = jQuery('.recover-password-form');
        if ($(recoverPnl).length < 1)
            return;
        var btn = recoverPnl.find('.getCodeBtn');
        btn.click(function () {
            var errorMsg = btn.attr('data-error');
            var alertMsg = btn.attr('data-alert');
            var user = jQuery('#login-recovery-usr', recoverPnl);
            var _user = user.val();
            if (_user == '') { alert(alertMsg); return false; }
            adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subAct': 'recovery', 'u': _user }, function (_dt) {
                if (_dt == '1') {
                    recoverPnl.hide();
                    var newDlg = jQuery('.recover-password-newpass');
                    leenaFn.showChangePass();
                }
                else {
                    alert(errorMsg);
                }
            });
        });

    },
    showChangePass: function () {
        var newDlg = jQuery('.recover-password-newpass');
        newDlg.show();
        var code = jQuery('#login-changePass-code', newDlg);
        var pwd = jQuery('#login-changePass-pwd', newDlg);
        var user = jQuery('#login-recovery-usr');
        var btn = newDlg.find('.changePassBtn');

        btn.click(function () {
            var errorMsg = btn.attr('data-error');
            var alertMsg = btn.attr('data-alert');
            var _code = code.val();
            var _pwd = pwd.val();
            var _user = user.val();
            if (_code == '' || _pwd == '' || _user == '') {
                alert(alertMsg);
                return false;
            }
            adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subAct': 'changePass', 'code': _code, 'p': _pwd, 'u': _user }, function (_dt) {
                if (_dt == '1') {
                    $('.recover-password-success').show();
                    newDlg.hide();
                } else {
                    alert(errorMsg);
                }
            });
        });
    }
    ,
    updateAccount: function () {
        var box = $('.MyAccount');
        var Email = box.find('.Email');
        var Emaildesc = Email.parent().find('.desc');
        var Emailnotice = Email.parent().find('.notice');
        var Email = box.find('.Email');
        var Username = box.find('.Username');
        var Usernamedesc = Username.parent().find('.desc');
        var Ho = box.find('.Ho');
        var Ten = box.find('.Ten');
        var Mobile = box.find('.Mobile');
        var nam = box.find('#nam');
        var female = box.find('#female');
        var NgaySinh = box.find('.NgaySinh');
        var DiaChi = box.find('.DiaChi');
        var GioiTinh = true;
        var btn = box.find('.main_btn');
        box.find('.error, .desc, .notice').hide();
        var url = '.plugin?ref=' + Math.random() + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien';

        var registerForm = box.find('.LeenaWrap-register');
        var registerSuccess = box.find('.LeenaWrap-register-success');
        NgaySinh.datepicker();
        btn.click(function () {
            box.find('.error, .desc, .notice, .notice-signup').hide();
            var _Email = Email.val();
            var _Mobile = Mobile.val();
            var _Username = Username.val();
            var _Ho = Ho.val();
            var _Ten = Ten.val();
            var _nam = nam.is(':checked');
            var _female = female.is(':checked');
            if (_nam) {
                GioiTinh = true;
            }
            if (_female) {
                GioiTinh = false;
            }
            var _NgaySinh = NgaySinh.val();
            var _DiaChi = DiaChi.val();
            if (_Email == '') { Emaildesc.show(); return; }
            if (_Username == '') { Usernamedesc.show(); return; }
            if (!confirm) { confirmdesc.show(); return; }
            $.ajax({
                url: url,
                data: {
                    Ten: _Ten
                    , Ho: _Ho
                    , NgaySinh: _NgaySinh
                    , Mobile: _Mobile
                    , GioiTinh: GioiTinh
                    , DiaChi: _DiaChi
                    , subAct: 'saveMyInfo'
                },
                success: function (_dt) {
                    $(document).trigger('close.facebox', 'msg-portal-pop-processing');
                    alert('Saving done!');
                }
            });

        });
    }
    ,
    register: function () {
        var box = $('.register_page');
        if ($(box).length < 1)
            return;
        if ($(box).length < 1)
            return;
        var Email = box.find('.Email');
        var Emaildesc = Email.parent().find('.desc');
        var Emailnotice = Email.parent().find('.notice');
        var Email = box.find('.Email');
        var Username = box.find('.Username');
        var Usernamedesc = Username.parent().find('.desc');
        var Password = box.find('.Password');
        var Passworderror = Password.parent().find('.error');
        var PasswordConfirm = box.find('.PasswordConfirm');
        var Ho = box.find('.Ho');
        var Ten = box.find('.Ten');
        var Mobile = box.find('.Mobile');
        var nam = box.find('#nam');
        var female = box.find('#female');
        var NgaySinh = box.find('.NgaySinh');
        var DiaChi = box.find('.DiaChi');
        var confirm = box.find('#confirm');
        var confirmdesc = confirm.parent().find('desc');
        var GioiTinh = true;
        var btn = box.find('.main_btn');
        box.find('.error, .desc, .notice').hide();
        var url = '.plugin?ref=' + Math.random() + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien';

        var registerForm = box.find('.LeenaWrap-register');
        var registerSuccess = box.find('.LeenaWrap-register-success');
        NgaySinh.datepicker();
        btn.click(function () {
            box.find('.error, .desc, .notice, .notice-signup').hide();

            var _Email = Email.val();
            var _Mobile = Mobile.val();
            var _Username = Username.val();
            var _Password = Password.val();
            var _PasswordConfirm = PasswordConfirm.val();
            var _Ho = Ho.val();
            var _Ten = Ten.val();
            var _nam = nam.is(':checked');
            var _female = female.is(':checked');
            if (_nam) {
                GioiTinh = true;
            }
            if (_female) {
                GioiTinh = false;
            }
            var _NgaySinh = NgaySinh.val();
            var _DiaChi = DiaChi.val();
            var _confirm = confirm.is(':checked');
            if (_Email == '') { Emaildesc.show(); return; }
            if (_Username == '') { Usernamedesc.show(); return; }
            //if (_Username == '') { Usernamedesc.show(); return; }
            if (_Password == '' || _Password != _PasswordConfirm) { Passworderror.show(); return; }
            if (!confirm) { confirmdesc.show(); return; }
            $.ajax({
                url: url,
                data: {
                    Ten: _Ten
                    , Ho: _Ho
                    , Email: _Email
                    , Username: _Username
                    , Password: _Password
                    , NgaySinh: _NgaySinh
                    , Mobile: _Mobile
                    , GioiTinh: GioiTinh
                    , DiaChi: _DiaChi
                    , subAct: 'createFb'
                },
                success: function (_dt) {
                    $(document).trigger('close.facebox', 'msg-portal-pop-processing');
                    if (_dt == '0') {
                        $('.notice-signup').show();
                    }
                    else {
                        registerForm.hide();
                        registerSuccess.show();
                        var dt = eval(_dt);
                        registerSuccess.find('.email').html(dt.Email);
                        registerSuccess.find('.username').html(dt.Username);
                        registerSuccess.find('.name').html(dt.Ho + ' ' + dt.Ten);
                    }
                }
            });

        });
    }
}