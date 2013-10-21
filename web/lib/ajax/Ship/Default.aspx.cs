using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_Ship_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var act = Request["act"];
        var ID = Request["ID"];
        var Ma = Request["Ma"];
        var So = Request["So"];
        var HD_ID = Request["HD_ID"];
        var DH_ID = Request["DH_ID"];
        var NhanVien = Request["NhanVien"];
        var DiaChi = Request["DiaChi"];
        var NgayGiao = Request["NgayGiao"];
        var TT_ID = Request["TT_ID"];
        var NgayTao = Request["NgayTao"];
        var NguoiTao = Request["NguoiTao"];
        var Phi = Request["Phi"];
        var Readed = Request["Readed"];
        var TraTien = Request["TraTien"];
        var PhaiThu = Request["PhaiThu"];
        var DaGiao = Request["DaGiao"];
        

        var q = Request["q"];
        if (string.IsNullOrEmpty(Phi)) Phi = "1";

        DaGiao = !string.IsNullOrEmpty(DaGiao) ? "true" : "false";
        Readed = !string.IsNullOrEmpty(Readed) ? "true" : "false";
        switch (act)
        {
            case "add":
                #region add
                if (Security.IsAuthenticated())
                {
                    Shipping item;
                    if (string.IsNullOrEmpty(ID))
                    {
                        item = new Shipping();
                        item.ID = Guid.NewGuid();
                        item.NgayTao = DateTime.Now;
                    }
                    else
                    {
                        item = ShippingDal.SelectById(new Guid(ID));

                    }
                    item.NgayTao = DateTime.Now;

                    if (!string.IsNullOrEmpty(TT_ID))
                    {
                        item.TT_ID = new Guid(TT_ID);
                    }
                    if (!string.IsNullOrEmpty(DH_ID))
                    {
                        item.DH_ID = new Guid(DH_ID);
                    }
                    item.Ma = Ma;
                    item.NhanVien = NhanVien;
                    item.Phi = Convert.ToInt32(Phi);
                    item.PhaiThu = Convert.ToInt32(PhaiThu);
                    item.DiaChi = DiaChi;
                    if (!string.IsNullOrEmpty(HD_ID))
                    {
                        item.HD_ID = new Guid(HD_ID);
                    }
                    item.NguoiTao = Security.Username;
                    item.Ma = Ma;
                    if (!string.IsNullOrEmpty(NgayGiao))
                    {
                        item.NgayGiao = Convert.ToDateTime(NgayGiao, new CultureInfo("vi-vn"));
                    }
                   
                    item.Readed = Convert.ToBoolean(Readed);
                    item.DaGiao = Convert.ToBoolean(DaGiao);
                    item.TraTien = Convert.ToBoolean(TraTien);
                    item = string.IsNullOrEmpty(ID) ? ShippingDal.Insert(item) : ShippingDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "search":
                #region get
                var pagerSearch = DatHangDal.pagerNormal(string.Empty, false, null, q, Convert.ToInt32(100));
                rendertext(JavaScriptConvert.SerializeObject(pagerSearch.List));
                break;
                #endregion
            case "xoa":
                #region add
                if (Security.IsAuthenticated())
                {
                    ShippingDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            default:
                break;
        }
    }
}