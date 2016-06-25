using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace DAL
{
    public class AboutUsInfo
    {
        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int au_XinXID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AboutUsInfo");
            strSql.Append(" where ");
            strSql.Append(" au_XinXID = @au_XinXID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@au_XinXID", SqlDbType.Int,4)
			};
            parameters[0].Value = au_XinXID;
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
        public string Add(Model.AboutUsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AboutUsInfo(");
            strSql.Append("au_XinMC,au_XinPX,au_XinXNR,au_TuPLJ,au_Deleted");
            strSql.Append(") values (");
            strSql.Append("@au_XinMC,@au_XinPX,@au_XinXNR,@au_TuPLJ,@au_Deleted");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@au_XinMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@au_XinPX", SqlDbType.Int,4) ,            
                        new SqlParameter("@au_XinXNR", SqlDbType.VarChar) ,            
                        new SqlParameter("@au_TuPLJ", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@au_Deleted", SqlDbType.Int,4)             
              
            };
            parameters[0].Value = model.au_XinMC;
            parameters[1].Value = model.au_XinPX;
            parameters[2].Value = model.au_XinXNR;
            parameters[3].Value = model.au_TuPLJ;
            parameters[4].Value = model.au_Deleted; string result = "";
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
        public string Update(Model.AboutUsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AboutUsInfo set ");

            strSql.Append(" au_XinMC = @au_XinMC , ");
            strSql.Append(" au_XinPX = @au_XinPX , ");
            strSql.Append(" au_XinXNR = @au_XinXNR , ");
            strSql.Append(" au_TuPLJ = @au_TuPLJ , ");
            strSql.Append(" au_Deleted = @au_Deleted  ");
            strSql.Append(" where au_XinXID=@au_XinXID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@au_XinXID", SqlDbType.Int,4) ,            
                        new SqlParameter("@au_XinMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@au_XinPX", SqlDbType.Int,4) ,            
                        new SqlParameter("@au_XinXNR", SqlDbType.VarChar) ,            
                        new SqlParameter("@au_TuPLJ", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@au_Deleted", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.au_XinXID;
            parameters[1].Value = model.au_XinMC;
            parameters[2].Value = model.au_XinPX;
            parameters[3].Value = model.au_XinXNR;
            parameters[4].Value = model.au_TuPLJ;
            parameters[5].Value = model.au_Deleted;
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
        public bool Delete(int au_XinXID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AboutUsInfo set");
            strSql.Append(" IsDelete=1  where au_XinXID=@au_XinXID");
            SqlParameter[] parameters = {
					new SqlParameter("@au_XinXID", SqlDbType.Int,4)
			};
            parameters[0].Value = au_XinXID;


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
        public Model.AboutUsInfo GetModel(int au_XinXID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select au_XinXID, au_XinMC, au_XinPX, au_XinXNR, au_TuPLJ, au_Deleted  ");
            strSql.Append("  from AboutUsInfo ");
            strSql.Append(" where au_XinXID=@au_XinXID");
            SqlParameter[] parameters = {
					new SqlParameter("@au_XinXID", SqlDbType.Int,4)
			};
            parameters[0].Value = au_XinXID;
            Model.AboutUsInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.AboutUsInfo();
                model.au_XinXID = int.Parse(dt.Rows[0]["au_XinXID"].ToString());
                model.au_XinMC = dt.Rows[0]["au_XinMC"].ToString();
                model.au_XinPX = int.Parse(dt.Rows[0]["au_XinPX"].ToString());
                model.au_XinXNR = dt.Rows[0]["au_XinXNR"].ToString();
                model.au_TuPLJ = dt.Rows[0]["au_TuPLJ"].ToString();
                model.au_Deleted = int.Parse(dt.Rows[0]["au_Deleted"].ToString());

            }
            return model;
        }
        #region 2012/11/15 张瑞丹
        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update_lanmu(Model.AboutUsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AboutUsInfo set ");
            strSql.Append(" au_XinMC = @au_XinMC , ");
            strSql.Append(" au_XinPX = @au_XinPX ");
            strSql.Append(" where au_XinXID=@au_XinXID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@au_XinXID", SqlDbType.Int,4) ,            
                        new SqlParameter("@au_XinMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@au_XinPX", SqlDbType.Int,4)           
            };

            parameters[0].Value = model.au_XinXID;
            parameters[1].Value = model.au_XinMC;
            parameters[2].Value = model.au_XinPX;
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
        /// 更新内容
        /// </summary>
        public string Update_neirong(Model.AboutUsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AboutUsInfo set ");
            strSql.Append(" au_XinXNR = @au_XinXNR , ");
            strSql.Append(" au_TuPLJ = @au_TuPLJ  ");
            strSql.Append(" where au_XinXID=@au_XinXID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@au_XinXID", SqlDbType.Int,4) ,                     
                        new SqlParameter("@au_XinXNR", SqlDbType.VarChar) ,            
                        new SqlParameter("@au_TuPLJ", SqlDbType.NVarChar,500)                       
            };

            parameters[0].Value = model.au_XinXID;
            parameters[1].Value = model.au_XinXNR;
            parameters[2].Value = model.au_TuPLJ;
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
        #endregion
    }
}