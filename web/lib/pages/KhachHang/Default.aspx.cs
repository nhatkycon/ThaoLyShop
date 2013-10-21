using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
using pmSpa.entities;

public partial class lib_pages_KhachHang_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "100";
        var khuVucId = Request["KhuVuc_Id"];
        var nguonGocId = Request["NguonGoc_Id"];
        using(var con = DAL.con())
        {
            var pg = KhachHangDal.pagerAll(string.Empty, false, null, q, Convert.ToInt32(size), khuVucId, nguonGocId);
            DanhSach1.List = pg.List;

            var nguonGocList = DanhMucDal.SelectByLDMMa(con, "NGUON-KH");
            var khuVucList = DanhMucDal.SelectByLDMMa(con, "KHUVUC");

            NguonGoc.List = nguonGocList;
            KhuVuc.List = khuVucList;

        }
    }
}