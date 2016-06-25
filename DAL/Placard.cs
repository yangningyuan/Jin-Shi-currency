using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DBUtility;
namespace DAL
{
    //Placard
    public partial class Placard
    {

        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int pi_GongGID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Placard");
            strSql.Append(" where ");
            strSql.Append(" pi_GongGID = @pi_GongGID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@pi_GongGID", SqlDbType.Int,4)			};
            parameters[0].Value = pi_GongGID;

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
        public string Add(Model.Placard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Placard(");
            strSql.Append("pi_GongGMC,pi_GongGRQ,pi_GongGLR,pi_Deleted,pi_GongGZR");
            strSql.Append(") values (");
            strSql.Append("@pi_GongGMC,@pi_GongGRQ,@pi_GongGLR,@pi_Deleted,@pi_GongGZR");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        //new SqlParameter("@pi_GongGID", SqlDbType.Int,4) ,            
                        new SqlParameter("@pi_GongGMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pi_GongGRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pi_GongGLR", SqlDbType.NVarChar) ,            
                        new SqlParameter("@pi_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@pi_GongGZR", SqlDbType.Int,4)              
            };
            //parameters[0].Value = model.pi_GongGID;
            parameters[0].Value = model.pi_GongGMC;
            parameters[1].Value = model.pi_GongGRQ;
            parameters[2].Value = model.pi_GongGLR;
            parameters[3].Value = model.pi_Deleted;
            parameters[4].Value = model.pi_GongGZR;
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
        public string Update(Model.Placard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Placard set ");

            //strSql.Append(" pi_GongGID = @pi_GongGID , ");
            strSql.Append(" pi_GongGMC = @pi_GongGMC , ");
            //strSql.Append(" pi_GongGRQ = @pi_GongGRQ , ");
            strSql.Append(" pi_GongGLR = @pi_GongGLR ");
            //strSql.Append(" pi_Deleted = @pi_Deleted , ");
            //strSql.Append(" pi_GongGZR = @pi_GongGZR  ");
            strSql.Append(" where pi_GongGID=@pi_GongGID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@pi_GongGID", SqlDbType.Int,4) ,            
                        new SqlParameter("@pi_GongGMC", SqlDbType.NVarChar,50) ,            
                        //new SqlParameter("@pi_GongGRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pi_GongGLR", SqlDbType.NVarChar) ,            
                        ////new SqlParameter("@pi_Deleted", SqlDbType.Int,4) ,            
                        //new SqlParameter("@pi_GongGZR", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.pi_GongGID;
            parameters[1].Value = model.pi_GongGMC;
            //parameters[2].Value = model.pi_GongGRQ;
            parameters[2].Value = model.pi_GongGLR;
            //parameters[4].Value = model.pi_Deleted;
            //parameters[5].Value = model.pi_GongGZR;
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
        public bool Delete(int pi_GongGID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Placard set");
            strSql.Append(" pi_Deleted=1  where pi_GongGID=@pi_GongGID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pi_GongGID", SqlDbType.Int,4)			};
            parameters[0].Value = pi_GongGID;

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
        public Model.Placard GetModel(int pi_GongGID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pi_GongGID, pi_GongGMC, pi_GongGRQ, pi_GongGLR, pi_Deleted, pi_GongGZR  ");
            strSql.Append("  from Placard ");
            strSql.Append(" where pi_GongGID=@pi_GongGID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pi_GongGID", SqlDbType.Int,4)			};
            parameters[0].Value = pi_GongGID;


            Model.Placard model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.Placard();
                model.pi_GongGID = int.Parse(dt.Rows[0]["pi_GongGID"].ToString());
                model.pi_GongGMC = dt.Rows[0]["pi_GongGMC"].ToString();
                model.pi_GongGRQ = DateTime.Parse(dt.Rows[0]["pi_GongGRQ"].ToString());
                model.pi_GongGLR = dt.Rows[0]["pi_GongGLR"].ToString();
                model.pi_Deleted = int.Parse(dt.Rows[0]["pi_Deleted"].ToString());
                model.pi_GongGZR = int.Parse(dt.Rows[0]["pi_GongGZR"].ToString());

            }
            return model;
        }
    }
}

