using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using DBUtility;
using System.Data.SqlClient;

namespace DAL
{
    public class CommoditySortInfo
    {
        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int sp_FenLID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CommoditySortInfo");
            strSql.Append(" where ");
            strSql.Append(" sp_FenLID = @sp_FenLID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@sp_FenLID", SqlDbType.Int,4)
			};
            parameters[0].Value = sp_FenLID;
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
        public string Add(Model.CommoditySortInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CommoditySortInfo(");
            strSql.Append("sp_FenLCode,sp_FenLMC,sp_FenLJB,sp_FCode,sp_Deleted,sp_FenLPX,sp_FenLBZ");
            strSql.Append(") values (");
            strSql.Append("@sp_FenLCode,@sp_FenLMC,@sp_FenLJB,@sp_FCode,@sp_Deleted,@sp_FenLPX,@sp_FenLBZ");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@sp_FenLCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sp_FenLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sp_FenLJB", SqlDbType.Int,4) ,            
                        new SqlParameter("@sp_FCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sp_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@sp_FenLPX", SqlDbType.Int,4) ,            
                        new SqlParameter("@sp_FenLBZ", SqlDbType.NVarChar)             
              
            };

            parameters[0].Value = model.sp_FenLCode;
            parameters[1].Value = model.sp_FenLMC;
            parameters[2].Value = model.sp_FenLJB;
            parameters[3].Value = model.sp_FCode;
            parameters[4].Value = model.sp_Deleted;
            parameters[5].Value = model.sp_FenLPX;
            parameters[6].Value = model.sp_FenLBZ; string result = "";
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
        public string Update(Model.CommoditySortInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommoditySortInfo set ");
            strSql.Append(" sp_FenLMC = @sp_FenLMC , ");
            strSql.Append(" sp_FenLPX = @sp_FenLPX , ");
            strSql.Append(" sp_FenLBZ = @sp_FenLBZ  ");
            strSql.Append(" where sp_FenLCode=@sp_FenLCode ");
            SqlParameter[] parameters = {           
                        new SqlParameter("@sp_FenLCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sp_FenLMC", SqlDbType.NVarChar,50) ,                                 
                        new SqlParameter("@sp_FenLPX", SqlDbType.Int,4) ,            
                        new SqlParameter("@sp_FenLBZ", SqlDbType.NVarChar)             
              
            };
            parameters[0].Value = model.sp_FenLCode;
            parameters[1].Value = model.sp_FenLMC;
            parameters[2].Value = model.sp_FenLPX;
            parameters[3].Value = model.sp_FenLBZ;
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
        public bool Delete(int sp_FenLID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update CommoditySortInfo set");
            strSql.Append(" sp_Deleted=1  where sp_FenLID=@sp_FenLID");
            SqlParameter[] parameters = {
					new SqlParameter("@sp_FenLID", SqlDbType.Int,4)
			};
            parameters[0].Value = sp_FenLID;
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
        public Model.CommoditySortInfo GetModel(string sp_FenLCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sp_FenLID, sp_FenLCode, sp_FenLMC, sp_FenLJB, sp_FCode, sp_Deleted, sp_FenLPX, sp_FenLBZ  ");
            strSql.Append("  from CommoditySortInfo ");
            strSql.Append(" where sp_FenLCode=@sp_FenLCode");
            SqlParameter[] parameters = {
					new SqlParameter("@sp_FenLCode", SqlDbType.NVarChar)
			};
            parameters[0].Value = sp_FenLCode;
            Model.CommoditySortInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.CommoditySortInfo();
                model.sp_FenLID = int.Parse(dt.Rows[0]["sp_FenLID"].ToString());
                model.sp_FenLCode = dt.Rows[0]["sp_FenLCode"].ToString();
                model.sp_FenLMC = dt.Rows[0]["sp_FenLMC"].ToString();
                model.sp_FenLJB = int.Parse(dt.Rows[0]["sp_FenLJB"].ToString());
                model.sp_FCode = dt.Rows[0]["sp_FCode"].ToString();
                model.sp_Deleted = int.Parse(dt.Rows[0]["sp_Deleted"].ToString());
                model.sp_FenLPX = int.Parse(dt.Rows[0]["sp_FenLPX"].ToString());
                model.sp_FenLBZ = dt.Rows[0]["sp_FenLBZ"].ToString();

            }
            return model;
        }

        /// <summary>
        ///获取分类名称
        /// </summary>
        /// <param name="it_HangYFlCode"></param>
        /// <returns></returns>
        public string GetCommoditySortName(string sp_FenLCode)
        {
            string Name = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  CommoditySortInfo ");
            strSql.Append(" where sp_FenLCode=@sp_FenLCode");
            SqlParameter[] parameters = {
					new SqlParameter("@sp_FenLCode", SqlDbType.NVarChar)
			};
            parameters[0].Value = sp_FenLCode;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                Name = dt.Rows[0]["sp_FenLMC"].ToString();
            }
            return Name;
        }

        /// <summary>
        ///获取分类名称
        /// </summary>
        /// <param name="Strwhere"></param>
        /// <returns></returns>
        public DataTable GetCommoditySortDataTable(string sp_FCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  CommoditySortInfo ");
            strSql.Append(" where sp_FCode=@sp_FCode and sp_Deleted=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@sp_FCode", SqlDbType.NVarChar)
			};
            parameters[0].Value = sp_FCode;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            return dt;
        }

    }
}
