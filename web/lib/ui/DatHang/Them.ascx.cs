using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using pmSpa.entities;
using HangHoa = pmSpa.entities.HangHoa;

public partial class lib_ui_DatHang_Them : System.Web.UI.UserControl
{
    public DatHang Item { get; set; }
    public string id { get; set; }
    public List<DanhMuc> ListKhuVuc { get; set; }
    public List<DanhMuc> ListNguonGoc { get; set; }
    public List<docsoft.entities.HangHoa> ListHangHoa { get; set; }
    public List<DatHangChiTiet> ListDatHangChiTiet { get; set; }
    public List<XuatNhap> ListXuatNhap { get; set; }
    public List<Shipping> ListShip { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        NguonGoc_ID.List = ListNguonGoc;
        KhuVuc_ID.List = ListKhuVuc;
        HangHoaDanhSach1.List = ListDatHangChiTiet;
        DanhSach1.List = ListXuatNhap;
        DanhSach2.List = ListShip;
    }
}