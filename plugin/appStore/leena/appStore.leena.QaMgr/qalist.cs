using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.leena.QaMgr
{
    public class QaList : PlugUI
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
            var slideSb = new StringBuilder();
            var sbMnu = new StringBuilder();
            var list = AqDal.SelectAll();
            var listE = from p in list
                        where p.Active == true
                        orderby p.NgayTao descending 
                        select p;

            var listDm = GetTree(DanhMucDal.SelectByLDMMa(con, "SUBMENU"));
            var main = Lib.GetResource(Assembly.GetExecutingAssembly(), "qalist.htm");
            var itemStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "qalist-item.htm");
            var item1Str = Lib.GetResource(Assembly.GetExecutingAssembly(), "ViewDmHtml-item.htm");
            var itemLoggedInStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "qalist-loggedIn.htm");
            var itemUnLoggedInStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "qalist-unLoggedIn.htm");
            foreach (var item in listE)
            {
                slideSb.AppendFormat(itemStr
                                     , item.Q
                                     , item.A
                                     , item.UserFullName
                                     , item.NgayTao.ToString("dd/MM/yyyy"));


            }
            foreach (var item in listDm)
            {
                sbMnu.AppendFormat(item1Str, item.GiaTri, item.Ten, item.GiaTri, item.GiaTri.IndexOf("Qa") != -1 ? "active" : "");
            }
            var pagingStr = string.Empty;
            sb.AppendFormat(main, slideSb, sbMnu
                , Security.IsAuthenticated() ? itemLoggedInStr : itemUnLoggedInStr);
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        public string Ma { get; set; }
        public string Css { get; set; }
        public string ItemCss { get; set; }
        public string Top { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma = GetSetting("Ma", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            ItemCss = GetSetting("ItemCss", SettingNode);
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
            Tab1Settings1.Key = "ItemCss";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = ItemCss;
            Tab1Settings1.Title = "Class của hàng hóa";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Ma == null) Ma = "";
            if (Top == null) Top = "5";
            if (Css == null) Css = "";
            base.ImportPlugin();
        }
        #region TreeProcess
        List<DanhMuc> GetTree(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<DanhMuc> GetTreeTop(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
            foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
            return tree.ToList();
        }
        #endregion
    }
}
