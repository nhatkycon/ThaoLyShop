using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region YeuCauDoiHang
    #region BO
    public class YeuCauDoiHang : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public String HH_Ma { get; set; }
        public DateTime NgayTao { get; set; }
        public String Username { get; set; }
        public Boolean XuLy { get; set; }
        public Int32 LyDo { get; set; }
        #endregion
        #region Contructor
        public YeuCauDoiHang()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return YeuCauDoiHangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class YeuCauDoiHangCollection : BaseEntityCollection<YeuCauDoiHang>
    { }
    #endregion
    #region Dal
    public class YeuCauDoiHangDal
    {
        #region Methods

        public static void DeleteById(Guid YCDH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("YCDH_ID", YCDH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuCauDoiHang_Delete_DeleteById_linhnx", obj);
        }

        public static YeuCauDoiHang Insert(YeuCauDoiHang item)
        {
            var Item = new YeuCauDoiHang();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("YCDH_ID", item.ID);
            obj[1] = new SqlParameter("YCDH_Ten", item.Ten);
            obj[2] = new SqlParameter("YCDH_NoiDung", item.NoiDung);
            obj[3] = new SqlParameter("YCDH_HH_Ma", item.HH_Ma);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("YCDH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("YCDH_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("YCDH_Username", item.Username);
            obj[6] = new SqlParameter("YCDH_XuLy", item.XuLy);
            obj[7] = new SqlParameter("YCDH_LyDo", item.LyDo);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuCauDoiHang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static YeuCauDoiHang Update(YeuCauDoiHang item)
        {
            var Item = new YeuCauDoiHang();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("YCDH_ID", item.ID);
            obj[1] = new SqlParameter("YCDH_Ten", item.Ten);
            obj[2] = new SqlParameter("YCDH_NoiDung", item.NoiDung);
            obj[3] = new SqlParameter("YCDH_HH_Ma", item.HH_Ma);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("YCDH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("YCDH_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("YCDH_Username", item.Username);
            obj[6] = new SqlParameter("YCDH_XuLy", item.XuLy);
            obj[7] = new SqlParameter("YCDH_LyDo", item.LyDo);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuCauDoiHang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static YeuCauDoiHang SelectById(Guid YCDH_ID)
        {
            var Item = new YeuCauDoiHang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("YCDH_ID", YCDH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuCauDoiHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static YeuCauDoiHangCollection SelectAll()
        {
            var List = new YeuCauDoiHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuCauDoiHang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<YeuCauDoiHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<YeuCauDoiHang>("sp_tblYeuCauDoiHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static YeuCauDoiHang getFromReader(IDataReader rd)
        {
            var Item = new YeuCauDoiHang();
            if (rd.FieldExists("YCDH_ID"))
            {
                Item.ID = (Guid)(rd["YCDH_ID"]);
            }
            if (rd.FieldExists("YCDH_Ten"))
            {
                Item.Ten = (String)(rd["YCDH_Ten"]);
            }
            if (rd.FieldExists("YCDH_NoiDung"))
            {
                Item.NoiDung = (String)(rd["YCDH_NoiDung"]);
            }
            if (rd.FieldExists("YCDH_HH_Ma"))
            {
                Item.HH_Ma = (String)(rd["YCDH_HH_Ma"]);
            }
            if (rd.FieldExists("YCDH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["YCDH_NgayTao"]);
            }
            if (rd.FieldExists("YCDH_Username"))
            {
                Item.Username = (String)(rd["YCDH_Username"]);
            }
            if (rd.FieldExists("YCDH_XuLy"))
            {
                Item.XuLy = (Boolean)(rd["YCDH_XuLy"]);
            }
            if (rd.FieldExists("YCDH_LyDo"))
            {
                Item.LyDo = (Int32)(rd["YCDH_LyDo"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
    
}


