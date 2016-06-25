using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace DAL
{
    public class Plat_UserlInfo
    {

        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int pt_YongHID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Plat_UserlInfo");
            strSql.Append(" where ");
            strSql.Append(" pt_YongHID = @pt_YongHID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = pt_YongHID;
            bool bl = true;
            try
            {
                object o = SqlHelper.ExecuteScalar(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        public string Add(Model.Plat_UserlInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Plat_UserlInfo(");
            strSql.Append("pt_DengLMC,pt_DengLMM,pt_ZhuCSJ,pt_Enabled,pt_Deleted,pt_ZCBZ");
            strSql.Append(") values (");
            strSql.Append("@pt_DengLMC,@pt_DengLMM,@pt_ZhuCSJ,@pt_Enabled,@pt_Deleted,@pt_ZCBZ");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_ZhuCSJ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pt_Enabled", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_ZCBZ", SqlDbType.NVarChar,50)             
              
            };
            parameters[0].Value = model.pt_DengLMC;
            parameters[1].Value = model.pt_DengLMM;
            parameters[2].Value = model.pt_ZhuCSJ;
            parameters[3].Value = model.pt_Enabled;
            parameters[4].Value = model.pt_Deleted;
            parameters[5].Value = model.pt_ZCBZ; string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        public string Update(Model.Plat_UserlInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Plat_UserlInfo set ");
            strSql.Append(" pt_DengLMC = @pt_DengLMC , ");
            strSql.Append(" pt_DengLMM = @pt_DengLMM , ");
            strSql.Append(" pt_ZhuCSJ = @pt_ZhuCSJ , ");
            strSql.Append(" pt_Enabled = @pt_Enabled , ");
            strSql.Append(" pt_Deleted = @pt_Deleted , ");
            strSql.Append(" pt_ZCBZ = @pt_ZCBZ  ");
            strSql.Append(" where pt_YongHID=@pt_YongHID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@pt_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_ZhuCSJ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pt_Enabled", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_ZCBZ", SqlDbType.NVarChar,50)             
              
            };
            parameters[0].Value = model.pt_YongHID;
            parameters[1].Value = model.pt_DengLMC;
            parameters[2].Value = model.pt_DengLMM;
            parameters[3].Value = model.pt_ZhuCSJ;
            parameters[4].Value = model.pt_Enabled;
            parameters[5].Value = model.pt_Deleted;
            parameters[6].Value = model.pt_ZCBZ;
            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Delete(int pt_YongHID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Plat_UserlInfo set");
            strSql.Append(" IsDelete=1  where pt_YongHID=@pt_YongHID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = pt_YongHID;
            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        public Model.Plat_UserlInfo GetModel(int pt_YongHID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pt_YongHID, pt_DengLMC, pt_DengLMM, pt_ZhuCSJ, pt_Enabled, pt_Deleted, pt_ZCBZ  ");
            strSql.Append("  from Plat_UserlInfo ");
            strSql.Append(" where pt_YongHID=@pt_YongHID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = pt_YongHID;
            Model.Plat_UserlInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.Plat_UserlInfo();
                model.pt_YongHID = int.Parse(dt.Rows[0]["pt_YongHID"].ToString());
                model.pt_DengLMC = dt.Rows[0]["pt_DengLMC"].ToString();
                model.pt_DengLMM = dt.Rows[0]["pt_DengLMM"].ToString();
                model.pt_ZhuCSJ = DateTime.Parse(dt.Rows[0]["pt_ZhuCSJ"].ToString());
                model.pt_Enabled = int.Parse(dt.Rows[0]["pt_Enabled"].ToString());
                model.pt_Deleted = int.Parse(dt.Rows[0]["pt_Deleted"].ToString());
                model.pt_ZCBZ = dt.Rows[0]["pt_ZCBZ"].ToString();
            }
            return model;
        }

    }
}
