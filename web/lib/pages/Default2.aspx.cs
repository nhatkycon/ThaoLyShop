using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pmSpa.entities;
using linh.core;

public partial class lib_pages_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var item = (BaseObject)(Activator.CreateInstance(Type.GetType("pmSpa.entities.KhachHang, pmSpa.entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null ")));
        dynamic obj = item.get("B66E418A-3988-4448-B954-18777F05A9DA");
        Response.Write(obj.Ten);
    }
}