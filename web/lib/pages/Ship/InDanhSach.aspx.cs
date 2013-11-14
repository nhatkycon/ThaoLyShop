using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Ship_InDanhSach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["id"];
        if(string.IsNullOrWhiteSpace(id)) return;

        var ids = id.Split(new char[] {','}).Where(x => x.Length > 3).ToList();
        if(!ids.Any()) return;
        var joined = string.Join(",", ids.ToArray());
        using (var con = DAL.con())
        {
            var list = ShippingDal.SelectByIdList(con, joined);
            DanhSachIn1.List = list;
            DanhSachIn1.ItemDm = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI", con);
        }
    }
}