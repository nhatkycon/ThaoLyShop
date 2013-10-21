﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_HeThong_DanhSachHangHoa : System.Web.UI.UserControl
{
    public string ControlId { get; set; }
    public string ControlName { get; set; }
    public List<HangHoa> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}