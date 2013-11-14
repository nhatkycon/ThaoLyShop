using System;
using docsoft.entities;
using linh.core.dal;
public partial class lib_pages_Store_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["id"];

        using (var con = DAL.con())
        {
            var item = DanhMucDal.SelectById(new Guid(id));
            ViewItem1.Item = item;
            var pg = HangHoaDal.ByDm(con, null, false, "", null, 100, id);
            ViewItem1.List = pg.List;
        }
    }
}