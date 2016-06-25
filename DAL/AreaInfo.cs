using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类:AreaInfo
    /// </summary>
    public partial class AreaInfo
    {
        public AreaInfo()
        { }

        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        /// <param name="ai_QuYID"></param>
        /// <returns></returns>
        public bool Exists(int ai_QuYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AreaInfo");
            strSql.Append(" where ");
            strSql.Append(" ai_QuYID = @ai_QuYID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_QuYID", SqlDbType.Int,4)
			};
            parameters[0].Value = ai_QuYID;
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
        public string Add(Model.AreaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AreaInfo(");
            strSql.Append("ai_QuYCode,ai_QuYMC,ai_QuYJB,ai_QuYFCode,ai_QuYPX,ai_QuYBZ,ai_Delete");
            strSql.Append(") values (");
            strSql.Append("@ai_QuYCode,@ai_QuYMC,@ai_QuYJB,@ai_QuYFCode,@ai_QuYPX,@ai_QuYBZ,@ai_Delete");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ai_QuYCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ai_QuYMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ai_QuYJB", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_QuYFCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ai_QuYPX", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_QuYBZ", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ai_Delete", SqlDbType.Int,4)                        
            };
            parameters[0].Value = model.ai_QuYCode;
            parameters[1].Value = model.ai_QuYMC;
            parameters[2].Value = model.ai_QuYJB;
            parameters[3].Value = model.ai_QuYFCode;
            parameters[4].Value = model.ai_QuYPX;
            parameters[5].Value = model.ai_QuYBZ;
            parameters[6].Value = model.ai_Delete; 
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
        public string Update(Model.AreaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AreaInfo set ");
            strSql.Append(" ai_QuYMC = @ai_QuYMC , ");
            strSql.Append(" ai_QuYPX = @ai_QuYPX , ");
            strSql.Append(" ai_QuYBZ = @ai_QuYBZ  ");
            strSql.Append(" where ai_QuYCode=@ai_QuYCode ");

            SqlParameter[] parameters = {          
                        new SqlParameter("@ai_QuYCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ai_QuYMC", SqlDbType.NVarChar,50) ,                      
                        new SqlParameter("@ai_QuYPX", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_QuYBZ", SqlDbType.NVarChar) ,                                  
            };
            parameters[0].Value = model.ai_QuYCode;
            parameters[1].Value = model.ai_QuYMC;
            parameters[2].Value = model.ai_QuYJB;
            parameters[3].Value = model.ai_QuYBZ;
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
        public bool Delete(int ai_QuYID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AreaInfo set");
            strSql.Append(" ai_Delete=1  where ai_QuYID=@ai_QuYID");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_QuYID", SqlDbType.Int,4)
			};
            parameters[0].Value = ai_QuYID;
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
        public Model.AreaInfo GetModel(string ai_QuYCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ai_QuYID, ai_QuYCode, ai_QuYMC, ai_QuYJB, ai_QuYFCode, ai_QuYPX, ai_QuYBZ, ai_Delete  ");
            strSql.Append("  from AreaInfo ");
            strSql.Append(" where ai_QuYCode=@ai_QuYCode");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_QuYCode", SqlDbType.NVarChar)
			};
            parameters[0].Value = ai_QuYCode;
            Model.AreaInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.AreaInfo();
                model.ai_QuYID = int.Parse(dt.Rows[0]["ai_QuYID"].ToString());
                model.ai_QuYCode = dt.Rows[0]["ai_QuYCode"].ToString();
                model.ai_QuYMC = dt.Rows[0]["ai_QuYMC"].ToString();
                model.ai_QuYJB = int.Parse(dt.Rows[0]["ai_QuYJB"].ToString());
                model.ai_QuYFCode = dt.Rows[0]["ai_QuYFCode"].ToString();
                model.ai_QuYPX = int.Parse(dt.Rows[0]["ai_QuYPX"].ToString());
                model.ai_QuYBZ = dt.Rows[0]["ai_QuYBZ"].ToString();
                model.ai_Delete = int.Parse(dt.Rows[0]["ai_Delete"].ToString());
            }
            return model;
        }

        /// <summary>
        ///获取分类名称
        /// </summary>
        /// <param name="it_HangYFlCode"></param>
        /// <returns></returns>
        public string GetIndustryName(string ai_QuYCode)
        {
            string Name = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  AreaInfo ");
            strSql.Append(" where ai_QuYCode=@ai_QuYCode");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_QuYCode", SqlDbType.NVarChar)
			};
            parameters[0].Value = ai_QuYCode;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                Name = dt.Rows[0]["ai_QuYMC"].ToString();
            }
            return Name;
        }
    }
}

