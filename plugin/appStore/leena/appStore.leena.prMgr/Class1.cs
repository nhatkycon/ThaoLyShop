﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.IO;
using System.Web;

[assembly: WebResource("appStore.leena.prMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.leena.prMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.leena.prMgr
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            var c = HttpContext.Current;
            #region Variables
            var ID = c.Request["ID"];
            var Ten = c.Request["Ten"];
            var Username = c.Request["Username"];
            var HH_ID = c.Request["HH_ID"];
            var NoiDUng = c.Request["NoiDUng"];
            var Active = c.Request["Active"];
            var Diem = c.Request["Diem"];

            if(!Security.IsAuthenticated())
            {
                Response.Clear();
                Response.End();                
            }
            var _q = c.Request["q"];
            #endregion
            int Loai = 1;
            List<jgridRow> listRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get

                    var pagerGet = PhotoReviewDal.pagerByLoai(null, false, null, null, Convert.ToInt32(jgRows), Loai);
                    foreach (var item in pagerGet.List)
                    {
                        listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.Ten
                            , item.Username
                            , item.Diem.ToString()
                            , item._HangHoa.Ten
                            , string.Format("{0:dd-MM-yy}",item.NgayTao)
                            , item.Duyet.ToString()
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                #endregion
               
                case "save":
                    #region chỉnh sửa
                    if (Security.IsAuthenticated())
                    {
                        var item = new PhotoReview();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = PhotoReviewDal.SelectById(new Guid(ID));
                        }
                        item.Loai = Loai;
                        item.Duyet = Convert.ToBoolean(Active);
                        item.Username = Username;
                        item.Ten = Ten;
                        item.NoiDung = NoiDUng;
                        if (!string.IsNullOrEmpty(HH_ID))
                        {
                            item.HH_ID = new Guid(HH_ID);
                        }
                        if (!string.IsNullOrEmpty(Diem))
                        {
                            item.Diem = Convert.ToInt32(Diem);
                        }
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = PhotoReviewDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item = PhotoReviewDal.Insert(item);
                        }
                        sb.Append("1");
                    }
                    
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(PhotoReviewDal.SelectById(new Guid(ID))));

                    }
                    break;
                    #endregion
                case "del":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        PhotoReviewDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion                
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.leena.prMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.leena.prMgr.JScript1.js")
                            , "{PrMgrFn.loadgrid();}");
                        sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                        break;
                    }
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
