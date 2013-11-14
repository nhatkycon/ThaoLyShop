using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Ship_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "20";
        using (var con = DAL.con())
        {
            var pg = ShippingDal.pagerNormal(con, string.Format("?q={0}&size={1}&", q, size) + "{1}={0}", false, "SHIP_NgayTao desc", q, Convert.ToInt32(size));
            DanhSach3.List = pg.List;
            paging = pg.Paging;
        }
    }
}