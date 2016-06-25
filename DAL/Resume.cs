using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using Common;
namespace DAL
{
    /// <summary>
    /// 数据访问类:Resume
    /// </summary>
    public partial class Resume
    {
        public Resume()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int r_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Resume");
            strSql.Append(" where r_id=@r_id");
            SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.Int,4)
			};
            parameters[0].Value = r_id;

            bool bl = true;
            try
            {
                object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                if (Convert.ToInt32(o) == 0)
                {
                    bl = false;
                }
            }
            catch (Exception ex)
            {
                bl = false;
            }

            return bl;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.Resume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Resume(");
            strSql.Append("re_id,r_fileurl,r_delete,r_createdate)");
            strSql.Append(" values (");
            strSql.Append("@re_id,@r_fileurl,@r_delete,@r_createdate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@re_id", SqlDbType.Int,4),
					new SqlParameter("@r_fileurl", SqlDbType.NVarChar,500),
					new SqlParameter("@r_delete", SqlDbType.Int,4),
                    new SqlParameter("@r_createdate",SqlDbType.DateTime)};
            parameters[0].Value = model.re_id;
            parameters[1].Value = model.r_fileurl;
            parameters[2].Value = model.r_delete;
            parameters[3].Value = model.r_createdate;
            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.Resume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Resume set ");
            strSql.Append("re_id=@re_id,");
            strSql.Append("r_fileurl=@r_fileurl,");
            strSql.Append("r_delete=@r_delete,");
            strSql.Append("r_createdate=@r_createdate");
            strSql.Append(" where r_id=@r_id");
            SqlParameter[] parameters = {
					new SqlParameter("@re_id", SqlDbType.Int,4),
					new SqlParameter("@r_fileurl", SqlDbType.NVarChar,500),
					new SqlParameter("@r_delete", SqlDbType.Int,4),
                    new SqlParameter("@r_createdate",SqlDbType.DateTime),
					new SqlParameter("@r_id", SqlDbType.Int,4)};
            parameters[0].Value = model.re_id;
            parameters[1].Value = model.r_fileurl;
            parameters[2].Value = model.r_delete;
            parameters[3].Value = model.r_createdate;
            parameters[4].Value = model.r_id;

            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int r_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Resume ");
            strSql.Append(" where r_id=@r_id");
            SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.Int,4)
			};
            parameters[0].Value = r_id;

            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Resume GetModel(int r_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 r_id,re_id,r_fileurl,r_delete,r_createdate from Resume ");
            strSql.Append(" where r_id=@r_id");
            SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.Int,4)
			};
            parameters[0].Value = r_id;

            Model.Resume model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.Resume();
                model.r_id = int.Parse(dt.Rows[0]["r_id"].ToString());
                model.re_id = int.Parse(dt.Rows[0]["re_id"].ToString());
                model.r_fileurl = dt.Rows[0]["r_fileurl"].ToString();
                model.r_delete = int.Parse(dt.Rows[0]["r_delete"].ToString());
                model.r_createdate = DateTime.Parse(dt.Rows[0]["r_createdate"].ToString());
            }
            return model;
        }


        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select r_id,re_id,r_fileurl,r_delete ");
        //    strSql.Append(" FROM Resume ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            
        //}



        
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Resume";
            parameters[1].Value = "r_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
