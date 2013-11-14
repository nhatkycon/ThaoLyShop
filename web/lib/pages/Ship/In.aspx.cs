using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Ship_In : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var dhid = Request["dhid"];
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id)) return;
            var Item = ShippingDal.SelectById(con, new Guid(id));
            Item.DH_Ma = DatHangDal.SelectById(Item.DH_ID).Ma;
            InItem1.Item = Item;
            InItem1.ItemDm = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI", con);            
            InItem1.ListDatHangChiTiet = DatHangChiTietDal.SelectByDhId(con, Item.DH_ID.ToString());

            InItem2.Item = Item;
            InItem2.ItemDm = InItem1.ItemDm;
            InItem2.ListDatHangChiTiet = InItem1.ListDatHangChiTiet;
        }
    }
}