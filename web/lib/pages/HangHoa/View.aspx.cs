using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_HangHoa_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];

        using (var con = DAL.con())
        {
            var item = HangHoaDal.SelectById(con, new Guid(id));
            item.ListFiles = FilesDal.SelectByPRowId(con, item.ID, 20);
            ViewItem1.Item = item;

        }
    }
}