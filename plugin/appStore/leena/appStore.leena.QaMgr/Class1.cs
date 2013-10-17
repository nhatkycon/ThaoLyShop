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

[assembly: WebResource("appStore.leena.QaMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.leena.QaMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.leena.QaMgr
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
            var CauHoi = c.Request["CauHoi"];
            var TraLoi = c.Request["TraLoi"];
            var Active = c.Request["Active"];

            if(!Security.IsAuthenticated())
            {
                Response.Clear();
                Response.End();                
            }
            var _q = c.Request["q"];
            #endregion

            List<jgridRow> listRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get

                    var pagerGet = AqDal.pagerNormal(null, false, null, null, Convert.ToInt32(jgRows));
                    foreach (var item in pagerGet.List)
                    {
                        listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.UserFullName
                            , item.Username
                            , item.Q
                            , string.Format("{0:dd-MM-yy}",item.NgayTao)
                            , item.Active.ToString()
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
                        var item = new Aq();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = AqDal.SelectById(new Guid(ID));
                        }
                        item.Active = Convert.ToBoolean(Active);
                        item.Username = Username;
                        item.UserFullName = Ten;
                        item.A = TraLoi;
                        item.Q = CauHoi;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = AqDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item = AqDal.Insert(item);
                        }
                        sb.Append("1");
                    }
                    
                    break;
                    #endregion
                case "post":
                    #region post
                    if (Security.IsAuthenticated())
                    {
                        var memitem = MemberDal.SelectByUser(Security.Username);
                        var item = new Aq();
                        item.Active = false;
                        item.Username = Username;
                        item.UserFullName = memitem.Ho + " " + memitem.Ten;
                        item.Q = CauHoi;
                        item.ID = Guid.NewGuid();
                        item.NgayTao = DateTime.Now;
                        item = AqDal.Insert(item);
                        sb.Append("1");
                    }

                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(AqDal.SelectById(new Guid(ID))));

                    }
                    break;
                    #endregion
                case "del":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        AqDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion                
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.leena.QaMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.leena.QaMgr.JScript1.js")
                            , "{QaMgrFn.loadgrid();}");
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
