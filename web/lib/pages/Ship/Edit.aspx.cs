using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Ship_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var dhid = Request["dhid"];
        Shipping Item;
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = new Shipping();
                if (string.IsNullOrEmpty(dhid))
                {
                    Item._DatHang = new DatHang();
                }
                else
                {
                    Item._DatHang = DatHangDal.SelectById(new Guid(dhid));
                    Item.DiaChi = Item._DatHang.KH_DiaChi;
                    Item.DH_ID = Item._DatHang.ID;
                    Item.Phi = Item._DatHang.PhiVanChuyen;
                    Item.PhaiThu = Item._DatHang.Tong;
                }
                Them1.Item = Item;
            }
            else
            {
                Them1.Item = ShippingDal.SelectById(con, new Guid(id));
            }
            var tinhTrangList = DanhMucDal.SelectByLDMMa(con, "TTShip");
            Them1.LisTinhTrang = tinhTrangList;
        }
    }
}