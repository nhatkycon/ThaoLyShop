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
    #region YeuThich
    #region BO
    public class YeuThich : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid HH_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public YeuThich()
        { }
        #endregion
        #region Customs properties

        public HangHoa _HangHoa { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return YeuThichDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class YeuThichCollection : BaseEntityCollection<YeuThich>
    { }
    #endregion
    #region Dal
    public class YeuThichDal
    {
        #region Methods

        public static void DeleteById(Guid YT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("YT_ID", YT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuThich_Delete_DeleteById_linhnx", obj);
        }

        public static YeuThich Insert(YeuThich item)
        {
            var Item = new YeuThich();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("YT_ID", item.ID);
            obj[1] = new SqlParameter("YT_HH_ID", item.HH_ID);
            obj[2] = new SqlParameter("YT_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("YT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("YT_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuThich_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static YeuThich Update(YeuThich item)
        {
            var Item = new YeuThich();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("YT_ID", item.ID);
            obj[1] = new SqlParameter("YT_HH_ID", item.HH_ID);
            obj[2] = new SqlParameter("YT_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("YT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("YT_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuThich_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static YeuThich SelectById(Guid YT_ID)
        {
            var Item = new YeuThich();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("YT_ID", YT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuThich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static YeuThichCollection SelectAll()
        {
            var List = new YeuThichCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblYeuThich_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<YeuThich> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<YeuThich>("sp_tblYeuThich_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static YeuThich getFromReader(IDataReader rd)
        {
            var Item = new YeuThich();
            if (rd.FieldExists("YT_ID"))
            {
                Item.ID = (Guid)(rd["YT_ID"]);
            }
            if (rd.FieldExists("YT_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["YT_HH_ID"]);
            }
            if (rd.FieldExists("YT_Username"))
            {
                Item.Username = (String)(rd["YT_Username"]);
            }
            if (rd.FieldExists("YT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["YT_NgayTao"]);
            }
            Item._HangHoa = HangHoaDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static YeuThichCollection SelectByUser(SqlConnection con, string Username, int Top)
        {
            var List = new YeuThichCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Top", Top);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblYeuThich_Select_ByUser", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion
}


