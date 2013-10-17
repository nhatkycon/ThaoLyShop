using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.common;

public partial class lib_ajax_photoreview_Default : basePage
{
    public delegate void SendEmailDele(string email, string tieude, string noidung);
    void sendmailThongbao(string email, string tieude, string noidung)
    {
        omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "mamvui.com", "123$5678");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Request["act"];
        string Ten = Request["Ten"];
        string NoiDung = Request["NoiDung"];
        string Anh = Request["Anh"];
        string Loai = Request["Loai"];
        switch (act)
        {
            case "add":
                #region add
                if(Security.IsAuthenticated())
                {
                    var item = new PhotoReview()
                                   {
                                       Anh = Anh
                                       ,
                                       ID = Guid.NewGuid()
                                       ,
                                       Ten = Ten
                                       ,
                                       NgayTao = DateTime.Now
                                       ,
                                       NoiDung = NoiDung
                                       ,
                                       Loai = Convert.ToInt32(Loai)
                                       ,
                                       Username = Security.Username
                                   };
                    item = PhotoReviewDal.Insert(item);
                    rendertext("1");
                }
                break;
                #endregion
            case "get":
                #region get
                break;
                #endregion
            default:
                break;
        }
    }
}