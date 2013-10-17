using System;
using System.Text;
using linh.frm;
using docsoft.entities;
using docsoft;
using System.Data.SqlClient;
using System.Xml;
using System.Linq;
public partial class lib_pages_Default : basePage
{
    public string body;
    public string toolBox;
    XmlDocument xmlDoc = new XmlDocument();
    IPlug _IPlug;
    public string css;
    public const string Admin = "sspa";
    protected void Page_Load(object sender, EventArgs e)
    {

        var ghId = Request["GH_ID"];
        var isAdmin = Security.Username == Admin;
        var alias = Request["pages"];
        var sb = new StringBuilder();
        #region ToolBox
        if (isAdmin)
        {
            sb.AppendFormat(@"<div class=""toolbox"">
    <div class=""toolbox-header"">
        <a _url=""getThemes"" _ref=""1"" class=""toolbox-item toolbox-item-color"" href=""javascript:;"">Đổi màu</a>
        <a _url=""portal-module-get"" _ref=""2"" class=""toolbox-item toolbox-item-module"" href=""javascript:;"">Thêm module</a>
        <a class=""toolbox-item"" href=""{0}/lib/admin/Default.htm"">Quản trị</a>
    </div>
    <div class=""toolbox-box"">
        <div  _load=""0"" _ref=""1"" class=""toolbox-body"">
            <div class=""toolbox-mainContent"">
            </div>
            <div class=""toolbox-footer"">
                <a href=""javascript:;"" class=""globalSave toolbox-save"">Lưu</a>
                <a href=""javascript:;"" class=""globalSave toolbox-cancel"">Đóng lại</a>
            </div>
        </div>
        <div _load=""0"" _ref=""2"" class=""toolbox-body"">
            <div class=""toolbox-mainContent module-store"">
            </div>
            <div class=""toolbox-footer"">
                <a href=""javascript:;"" class=""globalSave toolbox-save"">Lưu</a>
                <a href=""javascript:;"" class=""globalSave toolbox-cancel"">Đóng lại</a>
            </div>
        </div>
    </div>
</div>", domain);
        }

        #endregion
        using (var con = linh.core.dal.DAL.con())
        {
            var itemDongMo = DanhMucDal.SelectByMa("HETHONG-DONG");
            if (itemDongMo.GiaTri == "1")
            {
                rendertext(itemDongMo.Description);
            }

            #region ZoneTop
            Zone _ZoneTop = ZoneDal.SelectByMa(con, "Top");
            if (_ZoneTop.ID != 0)
            {
                sb.Append(_ZoneTop.HtmlBefore);
                sb.AppendFormat(@"<div class=""zone{2}"" style=""width:{0};"" id=""{1}"">", _ZoneTop.Width, _ZoneTop.ID, string.IsNullOrEmpty(_ZoneTop.CssClass) ? "" : string.Format(" {0}", _ZoneTop.CssClass));
                if (isAdmin) { sb.AppendFormat(@"<div modify=""true"" class=""zone-content"" modify=""true"">"); }
                foreach (PluginZone plugin in PluginZoneDal.SelectByZid(con, _ZoneTop.ID))
                {

                    sb.Append(buildModule(con, plugin, _ZoneTop.ID));

                }
                if (isAdmin) { sb.AppendFormat(@"</div>"); }
                sb.AppendFormat(@"</div>");
                sb.Append(_ZoneTop.HtmlAfter);
            }
            #endregion
            #region NoiDung
            var zones = ZoneDal.SelectByAlias(con, alias);
            foreach (var zone in zones)
            {
                var plugins = PluginZoneDal.SelectByZid(con, zone.ID);
                sb.Append(zone.HtmlBefore);
                sb.AppendFormat(@"<div class=""zone{2}"" style=""width:{0};"" id=""{1}"">", zone.Width, zone.ID, string.IsNullOrEmpty(zone.CssClass) ? "" : string.Format(" {0}", zone.CssClass));
                if (isAdmin) { sb.AppendFormat(@"<div modify=""true"" class=""zone-content"" modify=""true"">"); }
                foreach (var plugin in plugins)
                {
                    sb.Append(buildModule(con, plugin, zone.ID));

                }
                if (isAdmin) { sb.AppendFormat(@"</div>"); }
                sb.AppendFormat(@"</div>");
                sb.Append(zone.HtmlAfter);
            }
            #endregion
            #region footer
            _ZoneTop = ZoneDal.SelectByMa(con, "Bottom");
            if (_ZoneTop.ID != 0)
            {
                sb.Append(_ZoneTop.HtmlBefore);
                sb.AppendFormat(@"<div class=""zone{2}"" style=""width:{0};"" id=""{1}"">", _ZoneTop.Width, _ZoneTop.ID, string.IsNullOrEmpty(_ZoneTop.CssClass) ? "" : string.Format(" {0}", _ZoneTop.CssClass));
                if (isAdmin) { sb.AppendFormat(@"<div modify=""true"" class=""zone-content"" modify=""true"">"); }
                foreach (PluginZone plugin in PluginZoneDal.SelectByZid(con, _ZoneTop.ID))
                {

                    sb.Append(buildModule(con, plugin, _ZoneTop.ID));

                }
                if (isAdmin) { sb.AppendFormat(@"</div>"); }
                sb.AppendFormat(@"</div>");
                sb.Append(_ZoneTop.HtmlAfter);
            }

            #endregion

            //var listThemes = DanhMucDal.SelectByLDMMa(con, "THEMES");
            //var myList = from p
            //             in listThemes
            //             where p.KyHieu == "1"
            //             select p;
            //if (myList.Any())
            //{
            //    css = string.Format(@"<link id=""css"" href=""{0}/lib/css/web/{1}/1.css"" rel=""stylesheet"" type=""text/css"" />", domain, myList.ToList()[0].GiaTri);
            //}
        }
        body = ResourceHelper(sb.ToString(), Lang);
        if (Session["Title"] != null)
        {
            Page.Title = Session["Title"].ToString();
        }
        
    }
    public string buildModule(SqlConnection con, PluginZone plugin, int zone)
    {
        bool isAdmin = Security.Username == Admin;
        try
        {
            xmlDoc.LoadXml(plugin.Settings);
            var _PluginType = xmlDoc.LastChild.Attributes["PluginType"].Value;
            _IPlug = (IPlug)(Activator.CreateInstance(Type.GetType(_PluginType)));
            _IPlug.ImportPlugin();
            _IPlug.LoadSetting(xmlDoc.LastChild);
            _IPlug.KhoiTao(con, this.Page);
            if (_IPlug.Title != null)
                return string.Format(@"
<div id=""{1}"" class=""mdl{5}"" zone=""{2}"">{4}    
    <div class=""mdl-body"">{0}</div>
</div>", _IPlug.Html, plugin.ID, zone, _IPlug.PluginType, isAdmin ? string.Format(@"<div class=""mdl-head"">
        <span class=""mdl-tool"">
            <a href=""javascript:;"" _type=""{2}"" _id=""{1}"" class=""mdl-tool-btn mdl-tool-edit"">sửa</a>
            <a href=""javascript:;"" _id=""{1}"" class=""mdl-tool-btn mdl-tool-del"">xóa</a>
        </span>
        <span class=""mdl-move-icon""></span>
        <span class=""mdl-title"">{0}</span>
    </div>", _IPlug.Title, plugin.ID, _IPlug.PluginType) : "", string.IsNullOrEmpty(_IPlug.PluginCss) ? "" : string.Format(" {0}", _IPlug.PluginCss));
        }
        catch (Exception ex)
        {
            return string.Format(@"
<div id=""{1}"" class=""mdl{5}"" zone=""{2}"">{4}    
    <div class=""mdl-body"">{0}</div>
</div>", ex.Message, plugin.ID, zone, _IPlug.PluginType, isAdmin ? string.Format(@"<div class=""mdl-head"">
        <span class=""mdl-tool"">
            <a href=""javascript:;"" _type=""{4}"" _id=""{2}"" class=""mdl-tool-btn mdl-tool-edit"">sửa</a>
            <a href=""javascript:;"" _id=""{2}"" class=""mdl-tool-btn mdl-tool-del"">xóa</a>
        </span>
        <span class=""mdl-move-icon""></span>
        <span class=""mdl-title"">{0}</span>
    </div>", _IPlug.Title, ex.Message, plugin.ID, zone, _IPlug.PluginType) : "", string.IsNullOrEmpty(_IPlug.PluginCss) ? "" : string.Format(" {0}", _IPlug.PluginCss));
        }
        return null;
    }
    public string buildModule(IPlug _IPlug, int id, int zone)
    {
        bool isAdmin = Security.Username == Admin;
        return string.Format(@"
<div id=""{1}"" class=""mdl"" zone=""{2}"">{3}    
    <div class=""mdl-body"">{0}</div>
</div>", _IPlug.Html, id, zone, isAdmin ? string.Format(@"<div class=""mdl-head"">
        <span class=""mdl-tool"">
            <a href=""javascript:;"" _type=""{2}"" _id=""{1}"" class=""mdl-tool-btn mdl-tool-edit"">sửa</a>
            <a href=""javascript:;"" _id=""{1}"" class=""mdl-tool-btn mdl-tool-del"">xóa</a>
        </span>
        <span class=""mdl-move-icon""></span>
        <span class=""mdl-title"">{0}</span>
    </div>", _IPlug.Title, id, _IPlug.PluginType) : "");
    }
}