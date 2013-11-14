using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ChamSoc_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var khId = Request["khId"];
        ChamSoc Item;
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = new ChamSoc();
                if (!string.IsNullOrEmpty(khId)) Item.KH_ID = new Guid(khId);
                Them1.Item = Item;
            }
            else
            {
                Them1.Item = ChamSocDal.SelectById(con, new Guid(id));
            }
            var tinhTrangList = DanhMucDal.SelectByLDMMa(con, "CsTT");
            var loaiList = DanhMucDal.SelectByLDMMa(con, "CsLoai");
            Them1.ListTT = tinhTrangList;
            Them1.ListLoai = loaiList;
        }
    }
}