var QaMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=appStore.leena.QaMgr.Class1, appStore.leena.QaMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#QaMgrMdl-List').jqGrid({
            url: QaMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Username', 'Hỏi', 'Ngày tạo',  'Active'],
            colModel: [
            { name: 'AQ_ID', key: true, sortable: true, hidden: true },
            { name: 'AQ_UserFullName', width: 15, sortable: false, editable: true },
            { name: 'AQ_Username', width: 15, resizable: true, sortable: false },
            { name: 'AQ_Q', width: 60, resizable: true, sortable: false },
            { name: 'AQ_Ngaytao', width: 10, resizable: true, sortable: false },
            { name: 'AQ_Active', width: 2, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Hỏi đáp',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'HD_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#QaMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#QaMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-QaMgrMdl');
        var __q = $(searchTxt).val();
        var DM_ID = $('.mdl-head-QaMgrMdlFilterByDm');
        var _dm_id = '';
        if (DM_ID.val() != '') {
            _dm_id = DM_ID.attr('_value');
        }
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#QaMgrMdl-List').jqGrid('setGridParam', { url: QaMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
             + '&_DM_ID=' + _dm_id
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#QaMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#QaMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                QaMgrFn.loadHtml(function () {
                    var newDlg = $('#QaMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                QaMgrFn.save(function () { QaMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                QaMgrFn.save(function () { QaMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            QaMgrFn.clearform();
                            QaMgrFn.popfn();
                            $.ajax({
                                url: QaMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Username = $('.Username', newDlg);
                                    var CauHoi = $('.CauHoi', newDlg);
                                    var TraLoi = $('.TraLoi', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    Ten.val(dt.UserFullName);
                                    Username.val(dt.Username);
                                    CauHoi.val(dt.Q);
                                    TraLoi.val(dt.A);
                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked', 'checked'); }
                                    spbMsg.html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery('#QaMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#QaMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa hỏi đáp này?')) {
                    $.ajax({
                        url: QaMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#QaMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#QaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        var Ten = $('.Ten', newDlg);
        var CauHoi = $('.CauHoi', newDlg);
        var TraLoi = $('.TraLoi', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ten = Ten.val();
        var _Username = Username.val();
        var _CauHoi = CauHoi.val();
        var _TraLoi = TraLoi.val();
        var _Active = Active.is(':checked');

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; }
        if (_CauHoi == '' || _TraLoi =='') {
            if (_HD_ID == '') {
                err += 'Nhập đầy đủ câu hỏi và trả lời<br/>';
            }
        }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: QaMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'Ten': _Ten,
                'Username': _Username,
                'CauHoi': _CauHoi,
                'TraLoi': _TraLoi,
                'Active': _Active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#QaMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        QaMgrFn.loadHtml(function () {
            var newDlg = $('#QaMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        QaMgrFn.save(function () {
                            QaMgrFn.clearform();
                        }, '#QaMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        QaMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#QaMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    QaMgrFn.clearform();
                    QaMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#QaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        var Ten = $('.Ten', newDlg);
        var CauHoi = $('.CauHoi', newDlg);
        var TraLoi = $('.TraLoi', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(Username, function (e, ui) {
                Username.val(ui.item.value);
            });
        });

        adm.createFck(TraLoi);
    },
    clearform: function () {
        var newDlg = $('#QaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        var Ten = $('.Ten', newDlg);
        var CauHoi = $('.CauHoi', newDlg);
        var TraLoi = $('.TraLoi', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $('input, textarea', newDlg).val('');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#QaMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.leena.QaMgr.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('body').append(dt);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    }
}
