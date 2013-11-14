using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_ThaoLy_Store_templates_ViewItem : System.Web.UI.UserControl
{
    public DanhMuc Item { get; set; }
    public List<HangHoa> List { get; set; }
    public string id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        HHList1.List = List;
    }
}