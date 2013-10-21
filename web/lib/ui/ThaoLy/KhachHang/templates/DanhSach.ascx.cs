using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pmSpa.entities;

public partial class lib_ui_ThaoLy_KhachHang_templates_DanhSach : System.Web.UI.UserControl
{
    public List<KhachHang> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}