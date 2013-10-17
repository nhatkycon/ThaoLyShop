using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_Thank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var tx = Request["tx"];
        var item = DatHangDal.SelectById(new Guid(id));
        item.ThanhToan = true;
        item.PaypalTx = tx;
        item.Readed = true;
        DatHangDal.Update(item);
        Response.Redirect(string.Format(@"~/Thank/"));

    }
}