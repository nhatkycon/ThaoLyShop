using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace docsoft.entities
{
    #region Shipping
    #region BO
    public class Shipping : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ma { get; set; }
        public Int32 So { get; set; }
        public Guid HD_ID { get; set; }
        public Guid DH_ID { get; set; }
        public String NhanVien { get; set; }
        public String DiaChi { get; set; }
        public DateTime NgayGiao { get; set; }
        public Guid TT_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Int32 Phi { get; set; }
        public Boolean Readed { get; set; }
        public Boolean TraTien { get; set; }
        public Int32 PhaiThu { get; set; }
        public Boolean DaGiao { get; set; }
        #endregion
        #region Contructor
        public Shipping()
        { }
        #endregion
        #region Customs properties

        public string TT_Ten { get; set; }
        public string NhanVien_Ten { get; set; }
        public string DH_Ma { get; set; }
        public DatHang _DatHang { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ShippingDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ShippingCollection : BaseEntityCollection<Shipping>
    { }
    #endregion
    #region Dal
    public class ShippingDal
    {
        #region Methods

        public static void DeleteById(Guid SHIP_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SHIP_ID", SHIP_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblShipping_Delete_DeleteById_linhnx", obj);
        }

        public static Shipping Insert(Shipping item)
        {
            var Item = new Shipping();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("SHIP_ID", item.ID);
            obj[1] = new SqlParameter("SHIP_Ma", item.Ma);
            obj[2] = new SqlParameter("SHIP_So", item.So);
            obj[3] = new SqlParameter("SHIP_HD_ID", item.HD_ID);
            obj[4] = new SqlParameter("SHIP_DH_ID", item.DH_ID);
            obj[5] = new SqlParameter("SHIP_NhanVien", item.NhanVien);
            obj[6] = new SqlParameter("SHIP_DiaChi", item.DiaChi);
            if (item.NgayGiao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("SHIP_NgayGiao", item.NgayGiao);
            }
            else
            {
                obj[7] = new SqlParameter("SHIP_NgayGiao", DBNull.Value);
            }
            obj[8] = new SqlParameter("SHIP_TT_ID", item.TT_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("SHIP_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("SHIP_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("SHIP_NguoiTao", item.NguoiTao);
            obj[11] = new SqlParameter("SHIP_Phi", item.Phi);
            obj[12] = new SqlParameter("SHIP_Readed", item.Readed);
            obj[13] = new SqlParameter("SHIP_TraTien", item.TraTien);
            obj[14] = new SqlParameter("SHIP_PhaiThu", item.PhaiThu);
            obj[15] = new SqlParameter("SHIP_DaGiao", item.DaGiao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblShipping_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Shipping Update(Shipping item)
        {
            var Item = new Shipping();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("SHIP_ID", item.ID);
            obj[1] = new SqlParameter("SHIP_Ma", item.Ma);
            obj[2] = new SqlParameter("SHIP_So", item.So);
            obj[3] = new SqlParameter("SHIP_HD_ID", item.HD_ID);
            obj[4] = new SqlParameter("SHIP_DH_ID", item.DH_ID);
            obj[5] = new SqlParameter("SHIP_NhanVien", item.NhanVien);
            obj[6] = new SqlParameter("SHIP_DiaChi", item.DiaChi);
            if (item.NgayGiao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("SHIP_NgayGiao", item.NgayGiao);
            }
            else
            {
                obj[7] = new SqlParameter("SHIP_NgayGiao", DBNull.Value);
            }
            obj[8] = new SqlParameter("SHIP_TT_ID", item.TT_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("SHIP_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("SHIP_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("SHIP_NguoiTao", item.NguoiTao);
            obj[11] = new SqlParameter("SHIP_Phi", item.Phi);
            obj[12] = new SqlParameter("SHIP_Readed", item.Readed);
            obj[13] = new SqlParameter("SHIP_TraTien", item.TraTien);
            obj[14] = new SqlParameter("SHIP_PhaiThu", item.PhaiThu);
            obj[15] = new SqlParameter("SHIP_DaGiao", item.DaGiao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblShipping_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Shipping SelectById(Guid SHIP_ID)
        {
            var Item = new Shipping();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SHIP_ID", SHIP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblShipping_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ShippingCollection SelectAll()
        {
            var List = new ShippingCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblShipping_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Shipping> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            return pagerNormal(DAL.con(), url, rewrite, sort, q, size);
        }
        #endregion

        #region Utilities

        
        public static Shipping getFromReader(IDataReader rd)
        {
            var Item = new Shipping();
            if (rd.FieldExists("SHIP_ID"))
            {
                Item.ID = (Guid)(rd["SHIP_ID"]);
            }
            if (rd.FieldExists("SHIP_Ma"))
            {
                Item.Ma = (String)(rd["SHIP_Ma"]);
            }
            if (rd.FieldExists("SHIP_So"))
            {
                Item.So = (Int32)(rd["SHIP_So"]);
            }
            if (rd.FieldExists("SHIP_HD_ID"))
            {
                Item.HD_ID = (Guid)(rd["SHIP_HD_ID"]);
            }
            if (rd.FieldExists("SHIP_DH_ID"))
            {
                Item.DH_ID = (Guid)(rd["SHIP_DH_ID"]);
            }
            if (rd.FieldExists("SHIP_NhanVien"))
            {
                Item.NhanVien = (String)(rd["SHIP_NhanVien"]);
            }
            if (rd.FieldExists("SHIP_DiaChi"))
            {
                Item.DiaChi = (String)(rd["SHIP_DiaChi"]);
            }
            if (rd.FieldExists("SHIP_NgayGiao"))
            {
                Item.NgayGiao = (DateTime)(rd["SHIP_NgayGiao"]);
            }
            if (rd.FieldExists("SHIP_TT_ID"))
            {
                Item.TT_ID = (Guid)(rd["SHIP_TT_ID"]);
            }
            if (rd.FieldExists("SHIP_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SHIP_NgayTao"]);
            }
            if (rd.FieldExists("SHIP_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["SHIP_NguoiTao"]);
            }
            if (rd.FieldExists("SHIP_Phi"))
            {
                Item.Phi = (Int32)(rd["SHIP_Phi"]);
            }
            if (rd.FieldExists("SHIP_Readed"))
            {
                Item.Readed = (Boolean)(rd["SHIP_Readed"]);
            }
            if (rd.FieldExists("SHIP_TraTien"))
            {
                Item.TraTien = (Boolean)(rd["SHIP_TraTien"]);
            }
            if (rd.FieldExists("SHIP_PhaiThu"))
            {
                Item.PhaiThu = (Int32)(rd["SHIP_PhaiThu"]);
            }
            if (rd.FieldExists("TT_Ten"))
            {
                Item.TT_Ten = (String)(rd["TT_Ten"]);
            }
            if (rd.FieldExists("SHIP_DaGiao"))
            {
                Item.DaGiao = (Boolean)(rd["SHIP_DaGiao"]);
            }
            if (rd.FieldExists("NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["NhanVien_Ten"]);
            }
            if (rd.FieldExists("DH_Ma"))
            {
                Item.DH_Ma = (String)(rd["DH_Ma"]);
            }
            Item._DatHang = DatHangDal.getFromReader(rd);
            return Item;
        }
        public static Pager<Shipping> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Shipping>(con, "sp_tblShipping_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Shipping SelectById(SqlConnection con, Guid SHIP_ID)
        {
            var Item = new Shipping();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SHIP_ID", SHIP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblShipping_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ShippingCollection SelectByDhId(SqlConnection con,string dhId)
        {
            var list = new ShippingCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DH_ID", dhId);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblShipping_Select_SelectByDhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}
