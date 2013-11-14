using System;
using System.Globalization;
using System.Text;
using linh.controls;
using linh.json;
using docsoft.entities;
using docsoft;
using linh.common;
using pmSpa.entities;

public partial class lib_ajax_DatHang1_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var act = Request["act"];
        var GhiChu = Request["GhiChu"];
        var GiaTri = Request["GiaTri"];
        var GiaoHang = Request["GiaoHang"];
        var ID = Request["ID"];
        var KH_DiaChi = Request["KH_DiaChi"];
        var KH_ID = Request["KH_ID"];
        var DH_ID = Request["DH_ID"];

        var KH_Mobile = Request["KH_Mobile"];
        var KH_Ten = Request["KH_Ten"];
        var Ma = Request["Ma"];
        var NguonGoc_ID = Request["NguonGoc_ID"];
        var PhiVanChuyen = Request["PhiVanChuyen"];
        var Readed = Request["Readed"];
        var TT_ID = Request["TT_ID"];
        var FacebookUrl = Request["FacebookUrl"];
        var UuTien = Request["UuTien"];
        var NgayGiao = Request["NgayGiao"];
        var NgayGiaoYeuCau = Request["NgayGiaoYeuCau"];
        var NgayDat = Request["NgayDat"];

        var HH_SoLuong = Request["HH_SoLuong"];
        var HH_ID = Request["HH_ID"];
        var HH_Gia = Request["HH_Gia"];
        var q = Request["q"];
        if (string.IsNullOrEmpty(HH_SoLuong)) HH_SoLuong = "1";

        GiaoHang = !string.IsNullOrEmpty(GiaoHang) ? "true" : "false";
        Readed = !string.IsNullOrEmpty(Readed) ? "true" : "false";
        switch (act)
        {
            case "add":
                #region add
                if (Security.IsAuthenticated())
                {
                    DatHang item;
                    if (string.IsNullOrEmpty(ID))
                    {
                        item = new DatHang();
                        item.ID = Guid.NewGuid();
                        item.NgayTao = DateTime.Now;
                    }
                    else
                    {
                        item = DatHangDal.SelectById(new Guid(ID));

                    }

                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        item.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    if (!string.IsNullOrEmpty(TT_ID))
                    {
                        item.TT_ID = new Guid(TT_ID);
                    }
                    item.GhiChu = GhiChu;
                    item.FacebookUrl = FacebookUrl;
                    item.GiaTri = Convert.ToInt32(GiaTri);
                    item.KH_DiaChi = KH_DiaChi;
                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        item.KH_ID = new Guid(KH_ID);
                    }
                    item.KH_Mobile = KH_Mobile;
                    item.KH_Ten = KH_Ten;
                    item.Ma = Ma;
                    if (!string.IsNullOrEmpty(NgayGiaoYeuCau))
                    {
                        item.NgayGiaoYeuCau = Convert.ToDateTime(NgayGiaoYeuCau, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayDat))
                    {
                        item.NgayDat = Convert.ToDateTime(NgayDat, new CultureInfo("vi-vn"));
                    }
                    else
                    {
                        item.NgayDat = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(NgayGiao))
                    {
                        item.NgayGiao = Convert.ToDateTime(NgayGiao, new CultureInfo("vi-vn"));
                    }
                    item.PhiVanChuyen = Convert.ToInt32(PhiVanChuyen);
                    item.UuTien = Convert.ToInt32(UuTien);
                    item.Readed = Convert.ToBoolean(Readed);
                    item.GiaoHang = Convert.ToBoolean(GiaoHang);
                    item = string.IsNullOrEmpty(ID) ? DatHangDal.Insert(item) : DatHangDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "addHang":
                #region addHang
                if (Security.IsAuthenticated())
                {
                    var item = new DatHangChiTiet
                    {
                        DH_ID = new Guid(DH_ID),
                        HH_ID = new Guid(HH_ID),
                        HH_Gia = Convert.ToInt32(HH_Gia),
                        HH_SoLuong = Convert.ToInt32(HH_SoLuong),
                        ID = Guid.NewGuid()
                    };
                    item.HH_Tong = item.HH_SoLuong * item.HH_Gia;
                    item.NgayTao = DateTime.Now;
                    item = DatHangChiTietDal.Insert(item);
                    HangHoaItem1.Visible = true;
                    HangHoaItem1.Item = item;
                }
                break;
                #endregion
            case "removeHang":
                #region removeHang
                DatHangChiTietDal.DeleteById(new Guid(ID));
                break;
                #endregion
            case "search":
                #region get
                var pagerSearch = DatHangDal.pagerNormal(string.Empty, false, null, q, Convert.ToInt32(100));
                rendertext(JavaScriptConvert.SerializeObject(pagerSearch.List));
                break;
                #endregion
            case "xoa":
                #region add
                if (Security.IsAuthenticated())
                {
                    DatHangDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            default:
                break;
        }
    }
}