using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_HangHoa_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var dm_id = Request["DM_ID"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        using (var con = DAL.con())
        {
            var pagerGet = HangHoaDal.ByDm(con, string.Format("?q={0}&size={1}&dm_id={2}&", q, size, dm_id) + "{1}={0}", false, "", q, Convert.ToInt32(size), dm_id);
            DanhSach1.List = pagerGet.List;
            paging = pagerGet.Paging;

            var dmHangHoa = DanhMucDal.SelectByLDMMa(con, "NHOM-HH");
            DM_ID.List = dmHangHoa;
        }
    }
}