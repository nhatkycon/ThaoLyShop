using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_ThaoLy_Ship_Them : System.Web.UI.UserControl
{
    public Shipping Item { get; set; }
    public string id { get; set; }
    public string dhid { get; set; }
    public List<DanhMuc> LisTinhTrang { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        dhid = Request["dhid"];
        TT_ID.List = LisTinhTrang;
        
    }
}