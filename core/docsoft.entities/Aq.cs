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
    #region Aq
    #region BO
    public class Aq : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Username { get; set; }
        public String UserFullName { get; set; }
        public String A { get; set; }
        public String Q { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public Aq()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AqDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AqCollection : BaseEntityCollection<Aq>
    { }
    #endregion
    #region Dal
    public class AqDal
    {
        #region Methods

        public static void DeleteById(Guid AQ_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AQ_ID", AQ_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAq_Delete_DeleteById_linhnx", obj);
        }

        public static Aq Insert(Aq item)
        {
            var Item = new Aq();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("AQ_ID", item.ID);
            obj[1] = new SqlParameter("AQ_Username", item.Username);
            obj[2] = new SqlParameter("AQ_UserFullName", item.UserFullName);
            obj[3] = new SqlParameter("AQ_A", item.A);
            obj[4] = new SqlParameter("AQ_Q", item.Q);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("AQ_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("AQ_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("AQ_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("AQ_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAq_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Aq Update(Aq item)
        {
            var Item = new Aq();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("AQ_ID", item.ID);
            obj[1] = new SqlParameter("AQ_Username", item.Username);
            obj[2] = new SqlParameter("AQ_UserFullName", item.UserFullName);
            obj[3] = new SqlParameter("AQ_A", item.A);
            obj[4] = new SqlParameter("AQ_Q", item.Q);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("AQ_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("AQ_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("AQ_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("AQ_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAq_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Aq SelectById(Guid AQ_ID)
        {
            var Item = new Aq();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AQ_ID", AQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAq_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static AqCollection SelectAll()
        {
            return SelectAll(DAL.con());
        }
        public static AqCollection SelectAll(SqlConnection con)
        {
            var List = new AqCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAq_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Aq> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Aq>("sp_tblAq_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Aq getFromReader(IDataReader rd)
        {
            var Item = new Aq();
            if (rd.FieldExists("AQ_ID"))
            {
                Item.ID = (Guid)(rd["AQ_ID"]);
            }
            if (rd.FieldExists("AQ_Username"))
            {
                Item.Username = (String)(rd["AQ_Username"]);
            }
            if (rd.FieldExists("AQ_UserFullName"))
            {
                Item.UserFullName = (String)(rd["AQ_UserFullName"]);
            }
            if (rd.FieldExists("AQ_A"))
            {
                Item.A = (String)(rd["AQ_A"]);
            }
            if (rd.FieldExists("AQ_Q"))
            {
                Item.Q = (String)(rd["AQ_Q"]);
            }
            if (rd.FieldExists("AQ_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["AQ_NgayTao"]);
            }
            if (rd.FieldExists("AQ_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["AQ_ThuTu"]);
            }
            if (rd.FieldExists("AQ_Active"))
            {
                Item.Active = (Boolean)(rd["AQ_Active"]);
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


