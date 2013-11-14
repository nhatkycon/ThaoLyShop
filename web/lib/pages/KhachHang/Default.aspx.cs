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
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var khuVucId = Request["KhuVuc_Id"];
        var nguonGocId = Request["NguonGoc_Id"];
        using(var con = DAL.con())
        {
            var pg = KhachHangDal.pagerAll(string.Format("?q={0}&size={1}&KhuVuc_Id={2}&NguonGoc_Id={3}&", q, size, khuVucId, nguonGocId) + "{1}={0}", false, null, q, Convert.ToInt32(size), khuVucId, nguonGocId);
            DanhSach1.List = pg.List;
            paging = pg.Paging;

            var nguonGocList = DanhMucDal.SelectByLDMMa(con, "NGUON-KH");
            var khuVucList = DanhMucDal.SelectByLDMMa(con, "KHUVUC");

            NguonGoc.List = nguonGocList;
            KhuVuc.List = khuVucList;

        }
    }
}