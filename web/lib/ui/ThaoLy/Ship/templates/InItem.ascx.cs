using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_ThaoLy_Ship_templates_InItem : System.Web.UI.UserControl
{
    public Shipping Item { get; set; }
    public DanhMuc ItemDm { get; set; }
    public List<DatHangChiTiet> ListDatHangChiTiet { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        HangHoaDanhSachIn1.List = ListDatHangChiTiet;
    }
}