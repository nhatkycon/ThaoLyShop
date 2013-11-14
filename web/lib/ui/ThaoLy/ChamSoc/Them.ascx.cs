using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_ThaoLy_ChamSoc_Them : System.Web.UI.UserControl
{
    public string id { get; set; }
    public string khId { get; set; }
    public ChamSoc Item { get; set; }
    public List<DanhMuc> ListTT { get; set; }
    public List<DanhMuc> ListLoai { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        khId = Request["khId"];
        TT_ID.List = ListTT;
        LOAI_ID.List = ListLoai;
    }
}