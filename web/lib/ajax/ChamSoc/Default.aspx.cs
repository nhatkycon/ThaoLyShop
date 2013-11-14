using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class lib_ajax_ChamSoc_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var act = Request["act"];
        var ID = Request["ID"];
        var Ma = Request["Ma"];
        var KH_ID = Request["KH_ID"];
        var TT_ID = Request["TT_ID"];
        var LOAI_ID = Request["LOAI_ID"];
        var NoiDung = Request["NoiDung"];
        var NguoiTao = Request["NguoiTao"];
        var NgayTao = Request["NgayTao"];
        var q = Request["q"];

        switch (act)
        {
            case "add":

                #region add

                if (Security.IsAuthenticated())
                {
                    ChamSoc item;
                    if (string.IsNullOrEmpty(ID))
                    {
                        item = new ChamSoc {ID = Guid.NewGuid(), NgayTao = DateTime.Now};
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                    }
                    else
                    {
                        item = ChamSocDal.SelectById(new Guid(ID));

                    }
                    item.Ma = Ma;

                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        item.KH_ID = new Guid(KH_ID);
                    }
                    if (!string.IsNullOrEmpty(TT_ID))
                    {
                        item.TT_ID = new Guid(TT_ID);
                    }
                    if (!string.IsNullOrEmpty(LOAI_ID))
                    {
                        item.LOAI_ID = new Guid(LOAI_ID);
                    }
                    item.NoiDung = NoiDung;
                    item.NguoiTao = NguoiTao;

                    item = string.IsNullOrEmpty(ID) ? ChamSocDal.Insert(item) : ChamSocDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;

                #endregion

            case "xoa":

                #region add

                if (Security.IsAuthenticated())
                {
                    ChamSocDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion

            default:
                break;
        }
    }
}