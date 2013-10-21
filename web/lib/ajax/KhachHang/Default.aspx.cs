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
                    }
                    else
                    {
                        item = KhachHangDal.SelectById(new Guid(ID));

                    }
                    item.NgayTao = DateTime.Now;
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
                    rendertext(dh.ID.ToString());
                }
                break;
                #endregion
            default:
                break;
        }
    }
}