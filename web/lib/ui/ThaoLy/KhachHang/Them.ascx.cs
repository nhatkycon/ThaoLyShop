using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using pmSpa.entities;
using HangHoa = docsoft.entities.HangHoa;
using HangHoaDal = docsoft.entities.HangHoaDal;

public partial class lib_ui_ThaoLy_KhachHang_Them : System.Web.UI.UserControl
{
    public KhachHang Item { get; set; }
    public string id { get; set; }
    public List<DanhMuc> ListKhuVuc { get; set; }
    public List<DanhMuc> ListNguonGoc { get; set; }
    public List<HangHoa> ListHangHoa { get; set; }

    public List<DatHang> ListDatHang { get; set; }
    public List<DatHangChiTiet> ListDatHangChiTiet { get; set; }
    public List<ChamSoc> ListChamSoc { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        NguonGoc_ID.List = ListNguonGoc;
        KhuVuc_ID.List = ListKhuVuc;
        DanhSachHangHoa1.List = ListHangHoa;
        DanhSach1.List = ListDatHang;
        HangHoaDanhSachView1.List = ListDatHangChiTiet;
        DanhSach2.List = ListChamSoc;
    }
}