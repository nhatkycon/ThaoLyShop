using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
using pmSpa.entities;
using HangHoaDal = docsoft.entities.HangHoaDal;

public partial class lib_pages_DatHang_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];

        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Them1.Item = new DatHang(); ;
            }
            else
            {
                Them1.Item = DatHangDal.SelectById(new Guid(id));
                Them1.ListDatHangChiTiet = DatHangChiTietDal.SelectByDhId(con, id);
            }

            var nguonGocList = DanhMucDal.SelectByLDMMa(con, "NGUON-KH");
            var tinhTrangList = DanhMucDal.SelectByLDMMa(con, "TTDatHang");

            Them1.ListNguonGoc = nguonGocList;
            Them1.ListKhuVuc = tinhTrangList;

            var pagerGet = docsoft.entities.HangHoaDal.ByDm(con, "", false, "", "", 100, null);
            Them1.ListHangHoa = pagerGet.List;

            var listXuatNhap = XuatNhapDal.SelectTvDv(con, id);
            Them1.ListXuatNhap = listXuatNhap;

            var listShip = ShippingDal.SelectByDhId(con, id);
            Them1.ListShip = listShip;

        }
    }
}