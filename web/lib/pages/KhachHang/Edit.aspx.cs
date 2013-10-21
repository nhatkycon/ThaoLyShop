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

public partial class lib_pages_KhachHang_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Them1.Item = new KhachHang(); ;
            }
            else
            {
                Them1.Item = KhachHangDal.SelectById(new Guid(id));
                Them1.ListDatHang = DatHangDal.SelectByKhId(con, id, 100);
            }

            var nguonGocList = DanhMucDal.SelectByLDMMa(con, "NGUON-KH");
            var khuVucList = DanhMucDal.SelectByLDMMa(con, "KHUVUC");

            Them1.ListNguonGoc = nguonGocList;
            Them1.ListKhuVuc= khuVucList;

            var pagerGet = HangHoaDal.ByDm(con, "", false, "", "", 100, null);
            Them1.ListHangHoa = pagerGet.List;

            Them1.ListDatHangChiTiet = DatHangChiTietDal.SelectByKhId(con, id);

            var listChamSoc = ChamSocDal.SelectByKhId(con, id);
            Them1.ListChamSoc = listChamSoc;

        }
    }
}