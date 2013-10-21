using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core.dal;

public partial class lib_pages_DatHang_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "100";
        using(var con = DAL.con())
        {
            var pg = DatHangDal.pagerNormal(con, string.Empty, false, null, q, Convert.ToInt32(size));
            DanhSach1.List = pg.List;
        }
    }
}