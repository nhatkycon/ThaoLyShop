using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_ThaoLy_Store_templates_HHList : System.Web.UI.UserControl
{
    public List<HangHoa> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(List==null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}