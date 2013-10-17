var PrMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=appStore.leena.prMgr.Class1, appStore.leena.prMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#PrMgrMdl-List').jqGrid({
            url: PrMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Username', 'Điểm','Hàng', 'Ngày tạo', 'Active'],
            colModel: [
            { name: 'PR_ID', key: true, sortable: true, hidden: true },
            { name: 'PR_UserFullName', width: 60, sortable: false, editable: true },
            { name: 'PR_Username', width: 15, resizable: true, sortable: false },
            { name: 'PR_Q', width: 15, resizable: true, sortable: false },
            { name: 'PR_HH_ID', width: 15, resizable: true, sortable: false },
            { name: 'PR_Ngaytao', width: 10, resizable: true, sortable: false },
            { name: 'PR_Active', width: 2, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Photo review',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'PR_Ngaytao',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#PrMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#PrMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-PrMgrMdl');
        var __q = $(searchTxt).val();
        var DM_ID = $('.mdl-head-PrMgrMdlFilterByDm');
        var _dm_id = '';
        if (DM_ID.val() != '') {
            _dm_id = DM_ID.attr('_value');
        }
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#PrMgrMdl-List').jqGrid('setGridParam', { url: PrMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
             + '&_DM_ID=' + _dm_id
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#PrMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#PrMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                PrMgrFn.loadHtml(function () {
                    var newDlg = $('#PrMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                PrMgrFn.save(function () { PrMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                PrMgrFn.save(function () { PrMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            PrMgrFn.clearform();
                            PrMgrFn.popfn();
                            $.ajax({
                                url: PrMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var HH_ID = $('.HH_ID', newDlg);
                                    var Username = $('.Username', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var NoiDUng = $('.NoiDUng', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    var Diem = $('.Diem', newDlg);
                                    var img = $('img', newDlg);

                                    ID.val(dt.ID);
                                    Ten.val(dt.Ten);
                                    Diem.val(dt.Diem);
                                    Username.val(dt.Username);
                                    NoiDUng.val(dt.NoiDung);
                                    HH_ID.val(dt._HangHoa.Ten);
                                    HH_ID.attr('data-id', dt.HH_ID);
                                    img.attr('src','/lib/up/i/' +  adm.imgSize(dt.Anh, '326'));
                                    if (dt.Duyet) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked', 'checked'); }
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
        if (jQuery('#PrMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#PrMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: PrMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#PrMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#PrMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var HH_ID = $('.HH_ID', newDlg);
        var Username = $('.Username', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDUng = $('.NoiDUng', newDlg);
        var Active = $('.Active', newDlg);
        var Diem = $('.Diem', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ten = Ten.val();
        var _Username = Username.val();
        var _NoiDUng = NoiDUng.val();
        var _Diem = Diem.val();
        var _HH_ID = HH_ID.attr('data-id');
        var _Active = Active.is(':checked');

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: PrMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'HH_ID': _HH_ID,
                'Ten': _Ten,
                'Diem': _Diem,
                'Username': _Username,
                'NoiDUng': _NoiDUng,
                'Active': _Active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#PrMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        PrMgrFn.loadHtml(function () {
            var newDlg = $('#PrMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        PrMgrFn.save(function () {
                            PrMgrFn.clearform();
                        }, '#PrMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        PrMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#PrMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    PrMgrFn.clearform();
                    PrMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#PrMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var HH_ID = $('.HH_ID', newDlg);
        var Username = $('.Username', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDUng = $('.NoiDUng', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        adm.regType(typeof (hangHoaMgrFn), 'appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr', function () {
            hangHoaMgrFn.autoCompleteByQ(HH_ID, function (event, ui) {
                HH_ID.attr('data-id', ui.item.id);
                HH_ID.val(ui.item.label);
            });
            HH_ID.unbind('click').click(function () {
                HangHoa.autocomplete('search', '');
            });
        });
        adm.createFck(NoiDUng);
    },
    clearform: function () {
        var newDlg = $('#PrMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var HH_ID = $('.HH_ID', newDlg);
        var Username = $('.Username', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDUng = $('.NoiDUng', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $('input, textarea', newDlg).val('');
        HH_ID.attr('data-id', '');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#PrMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.leena.prMgr.htm.htm")%>',
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
