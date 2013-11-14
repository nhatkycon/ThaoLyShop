using System;
using System.Globalization;
using System.Text;
using linh.controls;
using linh.json;
using docsoft.entities;
using docsoft;
using linh.common;
using pmSpa.entities;


public partial class lib_ajax_KhachHang_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var act = Request["act"];
        var Ten = Request["Ten"];
        var Ho = Request["Ho"];
        var ID = Request["ID"];
        var XungHo = Request["XungHo"];
        var NgaySinh = Request["NgaySinh"];
        var Mobile = Request["Mobile"];
        var FacebookUid = Request["FacebookUid"];
        var NguonGoc_ID = Request["NguonGoc_ID"];
        var KhuVuc_ID = Request["KhuVuc_ID"];
        var DiaChi = Request["DiaChi"];
        var NgungTheoDoi = Request["NgungTheoDoi"];
        var HH_ID = Request["HH_ID"];
        var GhiChu = Request["GhiChu"];
        var FacebookUrl = Request["FacebookUrl"];
        var UuTien = Request["UuTien"];
        var NgayGiao = Request["NgayGiao"];
        var NgayGiaoYeuCau = Request["NgayGiaoYeuCau"];
        var NgayDat = Request["NgayDat"];
        NgungTheoDoi = !string.IsNullOrEmpty(NgungTheoDoi) ? "true" : "false";
        switch (act)
        {
            case "add":
            #region add
                if(Security.IsAuthenticated())
                {
                    KhachHang item;
                    if(string.IsNullOrEmpty(ID))
                    {
                        item=new KhachHang();
                        item.ID = Guid.NewGuid();
                        item.NgayTao = DateTime.Now;
                    }
                    else
                    {
                        item = KhachHangDal.SelectById(new Guid(ID));

                    }
                    item.NguoiTao = Security.Username;
                    item.Ten = Ten;
                    item.Mobile = Mobile;
                    item.FacebookUid = FacebookUid;
                    item.DiaChi = DiaChi;
                    if(!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        item.NguonGoc_ID=new Guid(NguonGoc_ID);
                    }
                    if (!string.IsNullOrEmpty(KhuVuc_ID))
                    {
                        item.KhuVuc_ID = new Guid(KhuVuc_ID);
                    }
                    item.NgungTheoDoi = Convert.ToBoolean(NgungTheoDoi);
                    item.NgayCapNhat = DateTime.Now;
                    item = string.IsNullOrEmpty(ID) ? KhachHangDal.Insert(item) : KhachHangDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
            #endregion
            case "xoa":
                #region add
                if (Security.IsAuthenticated())
                {
                    KhachHangDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            case "addAndShip":
                #region add
                if (Security.IsAuthenticated())
                {
                    var item = new KhachHang
                                   {
                                       ID = Guid.NewGuid(),
                                       NgayTao = DateTime.Now,
                                       NguoiTao = Security.Username,
                                       Ten = Ten,
                                       Mobile = Mobile,
                                       FacebookUid = FacebookUid,
                                       DiaChi = DiaChi,
                                       Ma = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10)
                                   };
                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        item.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    if (!string.IsNullOrEmpty(KhuVuc_ID))
                    {
                        item.KhuVuc_ID = new Guid(KhuVuc_ID);
                    }
                    item.NgungTheoDoi = Convert.ToBoolean(NgungTheoDoi);
                    item = KhachHangDal.Insert(item);

                    var hh = docsoft.entities.HangHoaDal.SelectById(new Guid(HH_ID));

                    var dh = new DatHang
                                 {
                                     GiaTri = Convert.ToInt32(hh.GNY),
                                     ID = Guid.NewGuid(),
                                     KH_DiaChi = DiaChi,
                                     KH_ID = item.ID,
                                     KH_Mobile = Mobile,
                                     KH_Ten = Ten,
                                     Readed = false,
                                     Tong = Convert.ToInt32(hh.GNY),
                                     PhiVanChuyen = 0,
                                     NgayTao = DateTime.Now,
                                     Username = Security.Username,
                                     GhiChu = GhiChu,
                                     FacebookUrl = FacebookUrl,
                                     Ma = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10),
                                     UuTien = Convert.ToInt32(string.IsNullOrEmpty(UuTien) ? "1" : UuTien)
                                 };

                    if (!string.IsNullOrEmpty(NgayGiaoYeuCau))
                    {
                        dh.NgayGiaoYeuCau = Convert.ToDateTime(NgayGiaoYeuCau, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayDat))
                    {
                        dh.NgayDat = Convert.ToDateTime(NgayDat, new CultureInfo("vi-vn"));
                    }
                    else
                    {
                        dh.NgayDat = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(NgayGiao))
                    {
                        dh.NgayGiao = Convert.ToDateTime(NgayGiao, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        dh.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    dh = DatHangDal.Insert(dh);


                    var dhct = new DatHangChiTiet
                                   {
                                       DH_ID = dh.ID,
                                       HH_ID = hh.ID,
                                       HH_Gia = Convert.ToInt32(hh.GNY),
                                       HH_SoLuong = 1,
                                       HH_Ten = hh.Ten,
                                       HH_Tong = Convert.ToInt32(hh.GNY),
                                       ID = Guid.NewGuid(),
                                       NgayTao = DateTime.Now
                                   };
                    dhct = DatHangChiTietDal.Insert(dhct);

                    var ship = new Shipping()
                                   {
                                       ID = Guid.NewGuid()
                                       , DH_ID = dh.ID
                                       , DH_Ma = dh.Ma
                                       , Ma = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10)
                                       , DaGiao = false
                                       , DiaChi = dh.KH_DiaChi
                                       , HD_ID = dhct.HH_ID
                                       , NgayGiao = DateTime.Now
                                       , NgayTao = DateTime.Now
                                       , NguoiTao = Security.Username
                                       , Phi = dh.PhiVanChuyen
                                       , Readed = false
                                       , TraTien = false
                                       , PhaiThu = dh.Tong
                                   };
                    ship = ShippingDal.Insert(ship);

                    // Xuất nhập
                    var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-X");
                    var xn = XuatNhapDal.SelectByDraff(true);
                    xn.TVDV_ID = dh.ID;
                    xn.ChietKhau = 0;
                    xn.ChuyenDoi = false;
                    xn.ConNo = 0;
                    xn.CongTienHang = dh.Tong;
                    xn.DauKy = false;
                    xn.DienGiai = string.Format("Thêm hóa đơn bán lẻ cho đặt hàng {0}", dh.Ma);
                    xn.ID = Guid.NewGuid();
                    xn.KHO_ID = KhoHangDal.SelectAll()[0].ID;
                    xn.KH_ID = dh.KH_ID;
                    xn.KH_Ten = dh.KH_Ten;
                    xn.NgayCapNhat = DateTime.Now;
                    xn.NgayHoaDon = DateTime.Now;
                    xn.NgayTao = DateTime.Now;
                    xn.NguoiCapNhat = Security.Username;
                    xn.NguoiTao = Security.Username;
                    xn.NhanVien = Security.Username;
                    xn.NoiBo = false;
                    xn.ThanhToan = dh.Tong;
                    xn.TuVanVien = Security.Username;
                    xn.VAT = 0;
                    xn.Xuat = true;
                    xn.LOAI_ID = danhMucLoaiXuatNhap.ID;
                    xn = XuatNhapDal.Insert(xn);

                    // Xuất nhập chi tiết

                    var itemXnCt = new XuatNhapChiTiet
                                       {
                                           ID = Guid.NewGuid(),
                                           CKTien = Convert.ToDouble(0),
                                           CKTyLe = Convert.ToDouble(0),
                                           DonGia = Convert.ToDouble(dhct.HH_Gia),
                                           HH_ID = dhct.HH_ID,
                                           GhiChu = GhiChu,
                                           NgayCapNhat = DateTime.Now,
                                           NguoiCapNhat = Security.Username,
                                           SoLuong = Convert.ToDouble(dhct.HH_SoLuong),
                                           Tong = Convert.ToDouble(dhct.HH_Tong),
                                           VAT = Convert.ToDouble(0),
                                           KH_ID = dh.KH_ID
                                       };
                    itemXnCt = XuatNhapChiTietDal.Update(itemXnCt);


                    // Thu chi
                    var thuChi = ThuChiDal.SelectByXnId(xn.ID.ToString());
                    thuChi.LoaiQuy = Convert.ToInt32(0);
                    thuChi.P_ID = xn.KH_ID;
                    thuChi.NgayTao = DateTime.Now;
                    thuChi.SoTien = dh.Tong;
                    if (thuChi.ID == Guid.Empty)
                    {
                        var ndtcItem = DanhMucDal.SelectByMa("NDTC-THU-KHANGTRA");
                        thuChi = ThuChiDal.SelectByDraff(true);
                        thuChi.LoaiCandoi = 0;
                        thuChi.Mota = string.Format("{0}: {1}", ndtcItem.Ten, item.Ma);
                        thuChi.NDTC_ID = ndtcItem.ID;
                        thuChi.Thu = true;
                        thuChi.XN_ID = item.ID;
                        thuChi.NguoiTao = Security.Username;
                        thuChi.NguoiSua = Security.Username;
                        thuChi.NgaySua = DateTime.Now;
                        thuChi.isCandoi = false;
                        ThuChiDal.Insert(thuChi);
                    }
                    else
                    {
                        thuChi.NguoiSua = Security.Username;
                        thuChi.NgaySua = DateTime.Now;
                        ThuChiDal.Update(thuChi);
                    }



                    rendertext(dh.ID.ToString());
                }
                break;
                #endregion
            case "addAndHoaDon":
                #region addAndHoaDon
                if (Security.IsAuthenticated())
                {
                    var item = new KhachHang
                    {
                        ID = Guid.NewGuid(),
                        NgayTao = DateTime.Now,
                        NguoiTao = Security.Username,
                        Ten = Ten,
                        Mobile = Mobile,
                        FacebookUid = FacebookUid,
                        DiaChi = DiaChi,
                        Ma = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10)
                    };
                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        item.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    if (!string.IsNullOrEmpty(KhuVuc_ID))
                    {
                        item.KhuVuc_ID = new Guid(KhuVuc_ID);
                    }
                    item.NgungTheoDoi = Convert.ToBoolean(NgungTheoDoi);
                    item = KhachHangDal.Insert(item);

                    var hh = docsoft.entities.HangHoaDal.SelectById(new Guid(HH_ID));

                    var dh = new DatHang
                    {
                        GiaTri = Convert.ToInt32(hh.GNY),
                        ID = Guid.NewGuid(),
                        KH_DiaChi = DiaChi,
                        KH_ID = item.ID,
                        KH_Mobile = Mobile,
                        KH_Ten = Ten,
                        Readed = false,
                        Tong = Convert.ToInt32(hh.GNY),
                        PhiVanChuyen = 0,
                        NgayTao = DateTime.Now,
                        Username = Security.Username,
                        GhiChu = GhiChu,
                        FacebookUrl = FacebookUrl,
                        Ma = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10),
                        UuTien = Convert.ToInt32(string.IsNullOrEmpty(UuTien) ? "1" : UuTien)
                    };

                    if (!string.IsNullOrEmpty(NgayGiaoYeuCau))
                    {
                        dh.NgayGiaoYeuCau = Convert.ToDateTime(NgayGiaoYeuCau, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayDat))
                    {
                        dh.NgayDat = Convert.ToDateTime(NgayDat, new CultureInfo("vi-vn"));
                    }
                    else
                    {
                        dh.NgayDat = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(NgayGiao))
                    {
                        dh.NgayGiao = Convert.ToDateTime(NgayGiao, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        dh.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    dh = DatHangDal.Insert(dh);


                    var dhct = new DatHangChiTiet
                    {
                        DH_ID = dh.ID,
                        HH_ID = hh.ID,
                        HH_Gia = Convert.ToInt32(hh.GNY),
                        HH_SoLuong = 1,
                        HH_Ten = hh.Ten,
                        HH_Tong = Convert.ToInt32(hh.GNY),
                        ID = Guid.NewGuid(),
                        NgayTao = DateTime.Now
                    };
                    dhct = DatHangChiTietDal.Insert(dhct);

                    var ship = new Shipping()
                    {
                        ID = Guid.NewGuid()
                        ,
                        DH_ID = dh.ID
                        ,
                        DH_Ma = dh.Ma
                        ,
                        Ma = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 10)
                        ,
                        DaGiao = false
                        ,
                        DiaChi = dh.KH_DiaChi
                        ,
                        HD_ID = dhct.HH_ID
                        ,
                        NgayGiao = DateTime.Now
                        ,
                        NgayTao = DateTime.Now
                        ,
                        NguoiTao = Security.Username
                        ,
                        Phi = dh.PhiVanChuyen
                        ,
                        Readed = false
                        ,
                        TraTien = false
                        ,
                        PhaiThu = dh.Tong
                    };
                    ship = ShippingDal.Insert(ship);
                    rendertext(dh.ID.ToString());
                }
                break;
                #endregion
            default:
                break;
        }
    }
}