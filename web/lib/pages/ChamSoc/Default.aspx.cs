using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ChamSoc_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var tt_id = Request["TT_ID"];
        var loai_id = Request["LOAI_ID"];
        using (var con = DAL.con())
        {

            var pg = ChamSocDal.pagerNormal(con, string.Empty, false, "CS_NgayTao desc", q, 100, tt_id, loai_id);
            DanhSach1.List = pg.List;
            var tinhTrangList = DanhMucDal.SelectByLDMMa(con, "CsTT");
            var loaiList = DanhMucDal.SelectByLDMMa(con, "CsLoai");

            LOAI_ID.List = loaiList;
            TT_ID.List = tinhTrangList;
        }
    }
}