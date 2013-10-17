using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.hangHoaControls
{
    public class TimKiemView : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            var c = HttpContext.Current;
            var Ma = c.Request["DM_Ma"];
            var sort = c.Request["sort"];
            var q = c.Request["q"];
            if (string.IsNullOrEmpty(sort))
            {
                sort = "HH NgayTao-desc";
            }
            sort = sort.Replace("-", " ");
            var sbItem = new StringBuilder();
            var sbHot = new StringBuilder();
            var sbPager = new StringBuilder();

            var mainStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "TimKiemView.htm");
            var itemStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "TimKiemView-item.htm");
            var pg = HangHoaDal.pagerNormal(string.Format("Tim/{0}/", q) + "/{0}/", true, null, q, 20);
            var list = pg.List;
            var totalItem = pg.List.Count;
            sbPager.Append(pg.Paging);
            foreach (var item in list)
            {
                sbItem.AppendFormat(itemStr, Lib.Bodau(item.DM_Ten)
                , item.Ten
                , item.ID
                , Lib.imgSize(item.Anh, "326")
                , item.Ten
                , Lib.TienVietNam(item.GNY)
                , item.DM_Ten);
            }
            sb.AppendFormat(mainStr
                , string.Format("Show {1} products for <b>{0}</b>", q,pg.Total)
                , sbItem
                , sbPager);
            if (pg.TotalPages > 1)
            {
                sbPager.Append(pg.Paging);
            }
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        

        public string Css { get; set; }
        public string ItemCss { get; set; }
        public string Ten { get; set; }
        public string Top { get; set; }
        public string Header_Url { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ten = GetSetting("Ten", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            Header_Url = GetSetting("Header_Url", SettingNode);
            ItemCss = GetSetting("ItemCss", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSetting Tab1Settings1 = new ModuleSetting();
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
            Tab1Settings1.Key = "ItemCss";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = ItemCss;
            Tab1Settings1.Title = "Class của hàng hóa";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Top == null) Top = "5";
            if (Ten == null) Ten = "Tên Module";
            if (Css == null) Css = "";
            if (Header_Url == null) Header_Url = "";
            base.ImportPlugin();
        }
    }
}
