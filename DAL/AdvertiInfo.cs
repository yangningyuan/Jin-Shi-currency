using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace DAL
{
    //AdvertiInfo
    public partial class AdvertiInfo
    {

        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int gg_GongGID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AdvertiInfo");
            strSql.Append(" where ");
            strSql.Append(" gg_GongGID = @gg_GongGID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@gg_GongGID", SqlDbType.Int,4)
			};
            parameters[0].Value = gg_GongGID;
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
        public string Add(Model.AdvertiInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdvertiInfo(");
            strSql.Append("gg_JieSRJ,gg_TianJRQ,gg_CaoZR,gg_LianJDZ,gg_GongGWZ,gg_TuPLJ,gg_Delete,gg_Enabled,gg_Remark,gg_KaiSRJ");
            strSql.Append(") values (");
            strSql.Append("@gg_JieSRJ,@gg_TianJRQ,@gg_CaoZR,@gg_LianJDZ,@gg_GongGWZ,@gg_TuPLJ,@gg_Delete,@gg_Enabled,@gg_Remark,@gg_KaiSRJ");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@gg_JieSRJ", SqlDbType.DateTime) ,            
                        new SqlParameter("@gg_TianJRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@gg_CaoZR", SqlDbType.Int,4) ,                    
                        new SqlParameter("@gg_LianJDZ", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@gg_GongGWZ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@gg_TuPLJ", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@gg_Delete", SqlDbType.Int,4) ,            
                        new SqlParameter("@gg_Enabled", SqlDbType.Int,4) ,            
                        new SqlParameter("@gg_Remark", SqlDbType.NVarChar) ,            
                        new SqlParameter("@gg_KaiSRJ", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.gg_JieSRJ;
            parameters[1].Value = model.gg_TianJRQ;
            parameters[2].Value = model.gg_CaoZR;
            parameters[3].Value = model.gg_LianJDZ;
            parameters[4].Value = model.gg_GongGWZ;
            parameters[5].Value = model.gg_TuPLJ;
            parameters[6].Value = model.gg_Delete;
            parameters[7].Value = model.gg_Enabled;
            parameters[8].Value = model.gg_Remark;
            parameters[9].Value = model.gg_KaiSRJ;
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
        public string Update(Model.AdvertiInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdvertiInfo set ");
            strSql.Append(" gg_JieSRJ = @gg_JieSRJ , ");
            strSql.Append(" gg_GongGWZ = @gg_GongGWZ , ");
            strSql.Append(" gg_TuPLJ = @gg_TuPLJ , ");
            strSql.Append(" gg_Remark = @gg_Remark , ");
            strSql.Append(" gg_LianJDZ = @gg_LianJDZ , ");
            strSql.Append(" gg_KaiSRJ = @gg_KaiSRJ , ");
            strSql.Append(" gg_Enabled = @gg_Enabled  ");
            strSql.Append(" where gg_GongGID=@gg_GongGID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@gg_GongGID", SqlDbType.Int,4) ,            
                        new SqlParameter("@gg_JieSRJ", SqlDbType.DateTime) ,              
                        new SqlParameter("@gg_GongGWZ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@gg_TuPLJ", SqlDbType.NVarChar,300) , 
                        new SqlParameter("@gg_Remark", SqlDbType.NVarChar,300) , 
                        new SqlParameter("@gg_LianJDZ", SqlDbType.NVarChar) , 
                        new SqlParameter("@gg_KaiSRJ", SqlDbType.DateTime)  ,
                        new SqlParameter("@gg_Enabled", SqlDbType.Int,4) 
              
            };
            parameters[0].Value = model.gg_GongGID;
            parameters[1].Value = model.gg_JieSRJ;
            parameters[2].Value = model.gg_GongGWZ;
            parameters[3].Value = model.gg_TuPLJ;
            parameters[4].Value = model.gg_Remark;
            parameters[5].Value = model.gg_LianJDZ;
            parameters[6].Value = model.gg_KaiSRJ;
            parameters[7].Value = model.gg_Enabled;
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
        /// 禁用启用
        /// </summary>
        /// <param name="gg_ID"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public string Update_Enable(int gg_ID, int isEnable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdvertiInfo set ");
            strSql.Append(" gg_Enabled = @gg_Enabled  ");
            strSql.Append(" where gg_GongGID=@gg_GongGID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@gg_GongGID", SqlDbType.Int,4) ,       
                        new SqlParameter("@gg_Enabled", SqlDbType.Int,4)           
              
            };
            parameters[0].Value = gg_ID;
            parameters[1].Value = isEnable;

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
        public bool Delete(int gg_GongGID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdvertiInfo set");
            strSql.Append(" gg_Delete=1  where gg_GongGID=@gg_GongGID");
            SqlParameter[] parameters = {
					new SqlParameter("@gg_GongGID", SqlDbType.Int,4)
			};
            parameters[0].Value = gg_GongGID;
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
        public Model.AdvertiInfo GetModel(int gg_GongGID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gg_GongGID, gg_JieSRJ, gg_TianJRQ, gg_CaoZR, gg_LianJDZ, gg_GongGWZ, gg_TuPLJ, gg_Delete, gg_Enabled, gg_Remark, gg_KaiSRJ  ");
            strSql.Append("  from AdvertiInfo ");
            strSql.Append(" where gg_GongGID=@gg_GongGID");
            SqlParameter[] parameters = {
					new SqlParameter("@gg_GongGID", SqlDbType.Int,4)
			};
            parameters[0].Value = gg_GongGID;
            Model.AdvertiInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters); if (dt.Rows.Count > 0)
            {
                model = new Model.AdvertiInfo();
                model.gg_GongGID = int.Parse(dt.Rows[0]["gg_GongGID"].ToString());
                model.gg_JieSRJ = DateTime.Parse(dt.Rows[0]["gg_JieSRJ"].ToString());
                model.gg_TianJRQ = DateTime.Parse(dt.Rows[0]["gg_TianJRQ"].ToString());
                model.gg_CaoZR = int.Parse(dt.Rows[0]["gg_CaoZR"].ToString());
                model.gg_LianJDZ = dt.Rows[0]["gg_LianJDZ"].ToString();
                model.gg_GongGWZ = dt.Rows[0]["gg_GongGWZ"].ToString();
                model.gg_TuPLJ = dt.Rows[0]["gg_TuPLJ"].ToString();
                model.gg_Delete = int.Parse(dt.Rows[0]["gg_Delete"].ToString());
                model.gg_Enabled = int.Parse(dt.Rows[0]["gg_Enabled"].ToString());
                model.gg_Remark = dt.Rows[0]["gg_Remark"].ToString();
                model.gg_KaiSRJ = DateTime.Parse(dt.Rows[0]["gg_KaiSRJ"].ToString());

            }
            return model;
        }

        /// <summary>
        /// 获取相关数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere,string Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Top + " gg_GongGID, gg_JieSRJ, gg_TianJRQ, gg_CaoZR, gg_LianJDZ, gg_GongGWZ, gg_TuPLJ, gg_Delete, gg_Enabled, gg_Remark, gg_KaiSRJ  ");
            strSql.Append("  from AdvertiInfo ");
            strSql.Append(" where 1=1 ");
            if (strWhere.Trim() != "")
                strSql.Append(strWhere);
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (dt.Rows.Count <= 0)
                return null;

            return dt;
        }
    }
}
