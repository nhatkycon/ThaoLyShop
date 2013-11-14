using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
public partial class lib_pages_Store_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        using (var con = DAL.con())
        {
            var dmHangHoa = DanhMucDal.SelectByLDMMa(con, "NHOM-HH");
            List1.List = dmHangHoa;

        }
    }
}