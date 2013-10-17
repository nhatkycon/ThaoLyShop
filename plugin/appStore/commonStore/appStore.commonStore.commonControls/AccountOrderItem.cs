using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.commonControls
{
    public class AccountOrderItem : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con, Page page)
        {
            var c = HttpContext.Current;
            var sb = new StringBuilder();
            var sbYeuThich = new StringBuilder();
            var sbOrder = new StringBuilder();
            var sbHangHoa = new StringBuilder();
            var _ID =  c.Request["DH_ID"];
            var itemStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "AccountOrderItem.htm");
            var itemYeuThichStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "AccountOrderItem-item.htm");
            var itemHangHoaStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "AccountOrderItem-item-hangHoa.htm");
            var orders = DatHangDal.SelectById(new Guid(_ID));

            var hangHoa = DatHangChiTietDal.SelectByDhId(_ID);

            if(Security.IsAuthenticated())
            {
                sbYeuThich.AppendFormat(itemYeuThichStr
                        , orders.ID
                        , orders.NgayTao
                        , orders.Tong
                        , string.Empty
                        , orders.ThanhToan ? "Paid" : "UnPaid");

                foreach (var item in hangHoa)
                {
                    sbHangHoa.AppendFormat(itemHangHoaStr
                        , Lib.Bodau(item._HangHoa.DM_Ten)
                        , item._HangHoa.Ten
                        , item.ID
                        , Lib.imgSize(item._HangHoa.Anh, "326")
                        , item._HangHoa.Ten
                        , Lib.TienVietNam(item.HH_Tong)
                        , item._HangHoa.DM_Ten
                        , item.HH_SoLuong);
                }

                sb.AppendFormat(itemStr, sbYeuThich, sbHangHoa, orders.KH_DiaChi, Lib.TienVietNam(orders.Tong));
            }
            else
            {
                sb.AppendFormat("Please login to view your account");                
            }
            Html = sb.ToString();
            base.KhoiTao(con);
        }


        public string Ma { get; set; }
        public string Css { get; set; }
        public string HtmlStr { get; set; }
        public string Ten { get; set; }
        public string Top { get; set; }
        public string Header_Url { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma = GetSetting("Ma", SettingNode);
            Ten = GetSetting("Ten", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            Header_Url = GetSetting("Header_Url", SettingNode);
            HtmlStr = GetSetting("HtmlStr", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSetting Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ma";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ma;
            Tab1Settings1.Title = "Mã danh mục";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ten";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ten;
            Tab1Settings1.Title = "Tên";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Top";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Top;
            Tab1Settings1.Title = "Số lượng";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Css";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Css;
            Tab1Settings1.Title = "Css";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Header_Url";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Header_Url;
            Tab1Settings1.Title = "Url";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "HtmlStr";
            Tab1Settings1.Type = "Html";
            Tab1Settings1.Value = HtmlStr;
            Tab1Settings1.Title = "Nội dung";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Ma == null) Ma = "";
            if (Top == null) Top = "5";
            if (Ten == null) Ten = "Tên Module";
            if (Css == null) Css = "";
            if (Header_Url == null) Header_Url = "";
            base.ImportPlugin();
        }
        
        
    }
}
