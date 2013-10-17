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
    #region PhotoReview
    #region BO
    public class PhotoReview : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Duyet { get; set; }
        public String Username { get; set; }
        public Guid HH_ID { get; set; }
        public String Anh { get; set; }
        public Int32 Diem { get; set; }
        public Int32 Loai { get; set; }
        #endregion
        #region Contructor
        public PhotoReview()
        { }
        #endregion
        #region Customs properties

        public HangHoa _HangHoa { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhotoReviewDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhotoReviewCollection : BaseEntityCollection<PhotoReview>
    { }
    #endregion
    #region Dal
    public class PhotoReviewDal
    {
        #region Methods

        public static void DeleteById(Guid PR_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PR_ID", PR_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Delete_DeleteById_linhnx", obj);
        }

        public static PhotoReview Insert(PhotoReview item)
        {
            var Item = new PhotoReview();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("PR_ID", item.ID);
            obj[1] = new SqlParameter("PR_Ten", item.Ten);
            obj[2] = new SqlParameter("PR_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PR_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("PR_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("PR_Duyet", item.Duyet);
            obj[5] = new SqlParameter("PR_Username", item.Username);
            obj[6] = new SqlParameter("PR_HH_ID", item.HH_ID);
            obj[7] = new SqlParameter("PR_Anh", item.Anh);
            obj[8] = new SqlParameter("PR_Diem", item.Diem);
            obj[9] = new SqlParameter("PR_Loai", item.Loai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhotoReview Update(PhotoReview item)
        {
            var Item = new PhotoReview();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("PR_ID", item.ID);
            obj[1] = new SqlParameter("PR_Ten", item.Ten);
            obj[2] = new SqlParameter("PR_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PR_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("PR_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("PR_Duyet", item.Duyet);
            obj[5] = new SqlParameter("PR_Username", item.Username);
            obj[6] = new SqlParameter("PR_HH_ID", item.HH_ID);
            obj[7] = new SqlParameter("PR_Anh", item.Anh);
            obj[8] = new SqlParameter("PR_Diem", item.Diem);
            obj[9] = new SqlParameter("PR_Loai", item.Loai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhotoReview SelectById(Guid PR_ID)
        {
            var Item = new PhotoReview();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PR_ID", PR_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhotoReviewCollection SelectAll()
        {
            var List = new PhotoReviewCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhotoReview> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<PhotoReview>("sp_tblPhotoReview_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhotoReview getFromReader(IDataReader rd)
        {
            var Item = new PhotoReview();
            if (rd.FieldExists("PR_ID"))
            {
                Item.ID = (Guid)(rd["PR_ID"]);
            }
            if (rd.FieldExists("PR_Ten"))
            {
                Item.Ten = (String)(rd["PR_Ten"]);
            }
            if (rd.FieldExists("PR_NoiDung"))
            {
                Item.NoiDung = (String)(rd["PR_NoiDung"]);
            }
            if (rd.FieldExists("PR_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PR_NgayTao"]);
            }
            if (rd.FieldExists("PR_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["PR_Duyet"]);
            }
            if (rd.FieldExists("PR_Username"))
            {
                Item.Username = (String)(rd["PR_Username"]);
            }
            if (rd.FieldExists("PR_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["PR_HH_ID"]);
            }
            if (rd.FieldExists("PR_Anh"))
            {
                Item.Anh = (String)(rd["PR_Anh"]);
            }
            if (rd.FieldExists("PR_Diem"))
            {
                Item.Diem = (Int32)(rd["PR_Diem"]);
            }
            if (rd.FieldExists("PR_Loai"))
            {
                Item.Loai = (Int32)(rd["PR_Loai"]);
            }
            var Hang = new HangHoa();
            Hang = HangHoaDal.getFromReader(rd);
            Item._HangHoa = Hang;
            return Item;
        }
        #endregion

        #region Extend
        public static PhotoReviewCollection SelectActive(int Top)
        {
            var List = new PhotoReviewCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Select_SelectActive_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static PhotoReviewCollection SelectUser(int Top, string Username, int Loai)
        {
            var List = new PhotoReviewCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Username", Username);
            obj[2] = new SqlParameter("Loai", Loai);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhotoReview_Select_SelectUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhotoReview> pagerByLoai(string url, bool rewrite, string sort, string q, int size, int Loai)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            obj[2] = new SqlParameter("Loai", Loai);
            var pg = new Pager<PhotoReview>("sp_tblPhotoReview_Pager_ByLoai_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
    
}


