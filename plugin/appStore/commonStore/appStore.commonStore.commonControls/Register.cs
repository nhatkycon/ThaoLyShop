﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.commonControls
{
    public class Register : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con, Page page)
        {
            var sb = new StringBuilder();
            var registerHtml = Lib.GetResource(Assembly.GetExecutingAssembly(), "leena_register.htm");
            sb.AppendFormat(@"
<div class=""bodyGlobal top-navi"">
    <div class=""boxGlobal"">
        <div class=""box1Global"">");

            sb.Append(registerHtml);

            sb.AppendFormat(@"</div>                
    </div>
</div>");
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
