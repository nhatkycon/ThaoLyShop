using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_ThaoLy_HangHoa_templates_ViewItem : System.Web.UI.UserControl
{
    public HangHoa Item { get; set; }
    public string id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (Item.ListFiles == null) return;
        DanhSachAnh1.List = Item.ListFiles;
    }
}