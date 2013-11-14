using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_DatHang_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var tt_id = Request["TT_ID"];
        var giaoHang = Request["GiaoHang"];        
        if (string.IsNullOrEmpty(size)) size = "10";
        using(var con = DAL.con())
        {
            var pg = DatHangDal.pagerAll(con, string.Format("?q={0}&size={1}&GiaoHang={2}&TT_ID={3}&", q, size,giaoHang,tt_id) + "{1}={0}", false, null, q, Convert.ToInt32(size), tt_id, giaoHang);
            DanhSach1.List = pg.List;
            paging = pg.Paging;
            var tinhTrangList = DanhMucDal.SelectByLDMMa(con, "TTDatHang");
            TT_ID.List = tinhTrangList;
        }
    }
}